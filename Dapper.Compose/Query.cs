using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Data;

namespace Dapper.Compose
{
    /// <summary>
    /// A query reified as a value.
    /// </summary>
    /// <typeparam name="T">The type of the query result.</typeparam>
    /// <remarks>
    /// Reified queries make it possible to combine small well-understood queries into larger
    /// queries that ultimately reduce the number of round trips to the database. The object
    /// materialization is handled for you because they are encapsulated in the smaller query
    /// objects.
    /// 
    /// To accomplish this, the individual small queries are a little slower because of the need
    /// for a uniform API, but this extra cost is generally dwarfed by network rountrips.
    /// </remarks>
    public struct Query<T>
    {
        /// <summary>
        /// Construct a query.
        /// </summary>
        /// <param name="read">The materializing function.</param>
        /// <param name="readAsync">The async materializing function.</param>
        /// <param name="sql">An SQL query.</param>
        public Query(Func<SqlMapper.GridReader, T> read, Func<SqlMapper.GridReader, Task<T>> readAsync, string sql)
            : this()
        {
            //FIXME: this method of composing async queries isn't quite ideal, because building a multiquery
            //from another multiquery would execute a sync selector in the middle of an async computation. I
            //could circumvent this by requiring either a second async selector, or making the selector itself
            //async and synchronizing it explicitly for sync query execution, thus incurring overhead.
            Sql = sql;
            Read = read;
            ReadAsync = readAsync;
        }

        /// <summary>
        /// The SQL query.
        /// </summary>
        public string Sql { get; private set; }

        /// <summary>
        /// The function used to materialize the result from the reader.
        /// </summary>
        public Func<SqlMapper.GridReader, T> Read { get; private set; }

        /// <summary>
        /// The function used to asynchronously materialize the result from the reader.
        /// </summary>
        public Func<SqlMapper.GridReader, Task<T>> ReadAsync { get; private set; }

        /// <summary>
        /// Execute this query.
        /// </summary>
        /// <param name="db">The database connection.</param>
        /// <param name="param">The query parameters.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="commandTimeout">The timeout to apply.</param>
        /// <param name="commandType">The command type.</param>
        /// <returns>The value resulting from executing this query against the database.</returns>
        public T Execute(IDbConnection db, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            using (var results = db.QueryMultiple(Sql, param, transaction, commandTimeout, commandType))
                return Read(results);
        }

        /// <summary>
        /// Asynchronously execute this query.
        /// </summary>
        /// <param name="db">The database connection.</param>
        /// <param name="param">The query parameters.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="commandTimeout">The timeout to apply.</param>
        /// <param name="commandType">The command type.</param>
        /// <returns>The value resulting from executing this query against the database.</returns>
        public async Task<T> ExecuteAsync(IDbConnection db, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            using (var results = await db.QueryMultipleAsync(Sql, param, transaction, commandTimeout, commandType))
                return await ReadAsync(results);
        }

        internal static readonly Func<SqlMapper.GridReader, T> Single = Query.ReadSingle<T>;
        internal static readonly Func<SqlMapper.GridReader, Task<T>> SingleAsync = Query.ReadSingleAsync<T>;
        internal static readonly Func<SqlMapper.GridReader, T> SingleOrDefault = Query.Reader<T, T>(nameof(SqlMapper.GridReader.ReadSingleOrDefault));
        internal static readonly Func<SqlMapper.GridReader, Task<T>> SingleOrDefaultAsync = Query.Reader<T, Task<T>>(nameof(SqlMapper.GridReader.ReadSingleOrDefaultAsync));
        internal static readonly Func<SqlMapper.GridReader, T> First = Query.Reader<T, T>(nameof(SqlMapper.GridReader.ReadFirst));
        internal static readonly Func<SqlMapper.GridReader, Task<T>> FirstAsync = Query.Reader<T, Task<T>>(nameof(SqlMapper.GridReader.ReadFirstAsync));
        internal static readonly Func<SqlMapper.GridReader, T> FirstOrDefault = Query.Reader<T, T>(nameof(SqlMapper.GridReader.ReadFirstOrDefault));
        internal static readonly Func<SqlMapper.GridReader, Task<T>> FirstOrDefaultAsync = Query.Reader<T, Task<T>>(nameof(SqlMapper.GridReader.ReadFirstOrDefaultAsync));
        internal static readonly Func<SqlMapper.GridReader, List<T>> List = x => x.Read<T>(true) as List<T>;
        internal static readonly Func<SqlMapper.GridReader, Task<List<T>>> ListAsync = async x => await x.ReadAsync<T>(true) as List<T>;
    }

    /// <summary>
    /// Query combinators.
    /// </summary>
    public static partial class Query
    {
        /// <summary>
        /// Return an open instance delegate that dispatches right into the grid reader.
        /// </summary>
        internal static Func<SqlMapper.GridReader, TReturn> Reader<T, TReturn>(string name, params Type[] argTypes)
        {
            // construct an open instance delegate on Grid Reader
            var method = typeof(SqlMapper.GridReader)
                         .GetTypeInfo()
                         .GetDeclaredMethods(name)
                         .Single(x => x.IsGenericMethodDefinition)
                         .MakeGenericMethod(typeof(T));
            return (Func<SqlMapper.GridReader, TReturn>)method.CreateDelegate(typeof(Func<SqlMapper.GridReader, TReturn>), null);
        }

        /// <summary>
        /// Wrapper for ReadSingle which throws a more usable exception.
        /// </summary>
        internal static TReturn ReadSingle<TReturn>(SqlMapper.GridReader grid)
        {
            try
            {
                return grid.ReadSingle<TReturn>();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"The query for {typeof(TReturn).Name} returned no results", e);
            }
        }

        /// <summary>
        /// Wrapper for ReadSingle which throws a more usable exception.
        /// </summary>
        internal static async Task<TReturn> ReadSingleAsync<TReturn>(SqlMapper.GridReader grid)
        {
            try
            {
                return await grid.ReadSingleAsync<TReturn>();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"The query for {typeof(TReturn).Name} returned no results", e);
            }
        }

        /// <summary>
        /// Generate a count query.
        /// </summary>
        /// <typeparam name="T">The type of query results.</typeparam>
        /// <param name="query">The query whose results we wish to count.</param>
        /// <returns>A query that counts the results of the given query.</returns>
        /// <remarks>
        /// This uses a simple and portable SQL subquery to count the result set.
        /// </remarks>
        public static Query<int> Count<T>(this Query<List<T>> query)
        {
            // generate a query alias
            var r = "count_" + Math.Abs(query.Sql.GetHashCode()) + "_" + Math.Abs(query.Read.GetHashCode()) + "_" + Math.Abs(query.ReadAsync.GetHashCode());
            return Single<int>($"select count(*) from ({query.Sql}) {r}");
        }

        /// <summary>
        /// Generate a page count query.
        /// </summary>
        /// <typeparam name="T">The type of query results.</typeparam>
        /// <param name="query">The query whose results we wish to count.</param>
        /// <param name="pageSizeVar">The variable specifying the size of the page.</param>
        /// <returns>A query that counts the results of the given query.</returns>
        /// <remarks>
        /// This uses a simple and portable SQL subquery to count the result set in number of pages.
        /// </remarks>
        public static Query<int> PageCount<T>(this Query<List<T>> query, string pageSizeVar = "@pageSize")
        {
            // generate a pseudo-unique query alias
            var r = "pagecount_" + Math.Abs(query.Sql.GetHashCode()) + "_" + Math.Abs(query.Read.GetHashCode()) + "_" + Math.Abs(query.ReadAsync.GetHashCode());
            return Single<int>($"select 1 + count(*)/{pageSizeVar} from ({query.Sql}) {r}");
        }

        /// <summary>
        /// Generate a paged query.
        /// </summary>
        /// <typeparam name="T">The type of query results.</typeparam>
        /// <param name="query">The query whose results to page.</param>
        /// <param name="rowColumn">The name of the column containing the current row number.</param>
        /// <param name="pageSizeVar">The variable specifying the size of the page.</param>
        /// <param name="pageVar">The variable designating the page of results to fetch. The page must be &gt;= 1.</param>
        /// <returns>A query that counts the results of the given query.</returns>
        /// <remarks>
        /// This uses a simple and portable SQL subquery to paginate the result set using some query parameters with configurable names.
        /// </remarks>
        public static Query<List<T>> Paged<T>(this Query<List<T>> query, string rowColumn = "row", string pageSizeVar = "@pageSize", string pageVar = "@page")
        {
            // generate a pseudo-unique query alias
            var r = "_paged_" + Math.Abs(query.Sql.GetHashCode()) + "_" + Math.Abs(query.Read.GetHashCode()) + "_" + Math.Abs(query.ReadAsync.GetHashCode());
            return List<T>($@"
select {r}.*
from (
{query.Sql}
) {r}
where {r}.{rowColumn} between 1 + ({pageVar} - 1) * {pageSizeVar} and {pageVar} * {pageSizeVar}");
        }

        /// <summary>
        /// Create a query returning a single value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static Query<T> Single<T>(string sql)
        {
            return new Query<T>(Query<T>.Single, Query<T>.SingleAsync, sql);
        }

        /// <summary>
        /// Create a query possibly returning a single.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static Query<T> SingleOrDefault<T>(string sql)
        {
            return new Query<T>(Query<T>.SingleOrDefault, Query<T>.SingleOrDefaultAsync, sql);
        }

        /// <summary>
        /// Create a query returning the first value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static Query<T> First<T>(string sql)
        {
            return new Query<T>(Query<T>.First, Query<T>.FirstAsync, sql);
        }

        /// <summary>
        /// Create a query possibly returning the first optional value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static Query<T> FirstOrDefault<T>(string sql)
        {
            return new Query<T>(Query<T>.FirstOrDefault, Query<T>.FirstOrDefaultAsync, sql);
        }

        /// <summary>
        /// Create a query possibly returning a list of values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static Query<List<T>> List<T>(string sql)
        {
            return new Query<List<T>>(Query<T>.List, Query<T>.ListAsync, sql);
        }

        ///// <summary>
        ///// Create a query possibly returning a list of values.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="sql"></param>
        ///// <param name="parameters"></param>
        ///// <returns></returns>
        //public static Query<IEnumerable<T>> Stream<T, T0>(string sql, Func<T, T0, T> map, string splitOn = "id")
        //{
        //    return new Query<IEnumerable<T>>(x => x.Read(map, splitOn), x => Task.FromResult(x.Read(map, splitOn)), sql);
        //}

        ///// <summary>
        ///// Create a query possibly returning a list of values.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="sql"></param>
        ///// <param name="parameters"></param>
        ///// <returns></returns>
        //public static Query<IEnumerable<T>> Stream<T, T0, T1>(string sql, Func<T, T0, T1, T> map, string splitOn = "id")
        //{
        //    return new Query<IEnumerable<T>>(x => x.Read(map, splitOn), x => Task.FromResult(x.Read(map, splitOn)), sql);
        //}

        /// <summary>
        /// Load a query as an embedded resource.
        /// </summary>
        /// <typeparam name="T">Any type whose assembly contains the embedded queries.</typeparam>
        /// <param name="resourceName">The name of the embedded query.</param>
        /// <returns>The embedded query.</returns>
        /// <remarks>
        /// Two formatted files are accepted:
        /// 
        /// 1. Plain files containing just the SQL needed (or line comments which are skipped)
        /// 2. A structured file where the actually query appears after a line comment starting with "-- Dapper.Compose.Query".
        /// 
        /// The structured format permits testing embedded queries. For instance, you can place variable declarations
        /// for all query parameters before the "-- Dapper.Compose.Query" line so that the file is actually fully
        /// executable on its own. Then you can load all such resources and execute them in your unit tests.
        /// </remarks>
        public static string Load<T>(string resourceName)
        {
            int queryStart;
            var sql = Load(typeof(T).GetTypeInfo().Assembly, resourceName, out queryStart);
            return sql.ToString(queryStart, sql.Length - queryStart);
        }

        static StringBuilder Load(Assembly asm, string resourceName, out int queryStart)
        {
            var buf = new StringBuilder();
            queryStart = 0;
            using (var stream = new StreamReader(asm.GetManifestResourceStream(resourceName)))
            {
                while (!stream.EndOfStream)
                {
                    var line = stream.ReadLine().Trim();
                    if (line.Length < 2 || (line[0] != '-' && line[1] != '-'))
                        buf.AppendLine(line);
                    else if (IsQueryMarker(line))
                        queryStart = buf.Length;
                }
                return buf;
            }
        }

        static bool IsQueryMarker(string line)
        {
            if (line.Length == 0 || line[0] != '-' || line[1] != '-')
                return false;
            var mark = typeof(Query).FullName;
            int i = 2;
            while (i < line.Length && char.IsWhiteSpace(line[i]))
                ++i;
            int k;
            for (k = 0; k < mark.Length && i < line.Length; ++i, ++k)
                if (line[i] != mark[k])
                    return false;
            return k == mark.Length;
        }

        /// <summary>
        /// Get the runnable queries embedded in a given type's assembly.
        /// </summary>
        /// <returns>The list of queries embedded in the assembly.</returns>
        public static IEnumerable<KeyValuePair<string, string>> GetRunnable(Type type)
        {
            var asm = type.GetTypeInfo().Assembly;
            foreach (var name in asm.GetManifestResourceNames())
            {
                if (name.EndsWith(".sql", StringComparison.OrdinalIgnoreCase))
                {
                    int queryStart;
                    var sql = Load(asm, name, out queryStart);
                    if (queryStart > 0)
                        yield return new KeyValuePair<string, string>(name, sql.ToString());
                }
            }
        }
        
        static readonly MethodInfo validate = new Action<IDbConnection, Query<int>, IDictionary<string, object>>(Validate<int>)
            .GetMethodInfo()
            .GetGenericMethodDefinition();

        /// <summary>
        /// Iterate through <paramref name="type"/>'s static members and invoke any queries with
        /// parameter bindings via <see cref="QueryParamAttribute"/>.
        /// </summary>
        /// <param name="db">The database connection to use.</param>
        /// <param name="type">The type to inspect for queries.</param>
        /// <returns>The set of errors generated.</returns>
        public static IEnumerable<KeyValuePair<string, Exception>> Validate(IDbConnection db, Type type)
        {
            var args = new object[3];
            args[0] = db;
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            {
                var query = field.GetValue(null); //FIXME: ensure it's a Query<T>
                if (query != null && field.FieldType.IsConstructedGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(Query<>))
                {
                    var attr = field.GetCustomAttributes<QueryParamAttribute>()
                                    .ToDictionary(x => x.Name, x => x.Value);
                    if (attr.Count > 0)
                    {
                        args[1] = query;
                        args[2] = attr;
                        Exception e;
                        try
                        {
                            validate.MakeGenericMethod(field.FieldType.GetGenericArguments()[0])
                                    .Invoke(null, args);
                            continue;
                        }
                        catch (Exception ex)
                        {
                            e = ex;
                        }
                        yield return new KeyValuePair<string, Exception>(field.Name, e);
                    }
                }
            }
        }

        static void Validate<T>(IDbConnection db, Query<T> query, IDictionary<string, object> param)
        {
            var cmd = db.CreateCommand();
            cmd.CommandText = query.Sql;
            foreach (var x in param)
            {
                var p = cmd.CreateParameter();
                p.ParameterName = x.Key;
                p.Value = x.Value;
                cmd.Parameters.Add(p);
            }
            cmd.ExecuteNonQuery();
        }
    }
}
