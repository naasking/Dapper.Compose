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

        /// <summary>
        /// A query function that transforms a single result.
        /// </summary>
        /// <typeparam name="T0">The input type.</typeparam>
        /// <typeparam name="T1">The returned type.</typeparam>
        /// <param name="sql">The SQL query to transform <typeparamref name="T0"/> to <typeparamref name="T1"/>.</param>
        /// <returns>A query function that can transform queries returning a single result.</returns>
        public static QueryFunc<T0, T1> Single<T0, T1>(string sql)
        {
            return new QueryFunc<T0, T1>(Query<T1>.Single, Query<T1>.SingleAsync, sql);
        }

        /// <summary>
        /// A query function that transforms a single result.
        /// </summary>
        /// <typeparam name="T0">The input type.</typeparam>
        /// <typeparam name="T1">The returned type.</typeparam>
        /// <param name="sql">The SQL query to transform <typeparamref name="T0"/> to <typeparamref name="T1"/>.</param>
        /// <returns>A query function that can transform queries returning a single result.</returns>
        public static QueryFunc<T0, T1> SingleOrDefault<T0, T1>(string sql)
        {
            return new QueryFunc<T0, T1>(Query<T1>.SingleOrDefault, Query<T1>.SingleOrDefaultAsync, sql);
        }

        /// <summary>
        /// A query function that transforms the first result.
        /// </summary>
        /// <typeparam name="T0">The input type.</typeparam>
        /// <typeparam name="T1">The returned type.</typeparam>
        /// <param name="sql">The SQL query to transform <typeparamref name="T0"/> to <typeparamref name="T1"/>.</param>
        /// <returns>A query function that can transform queries returning the first result.</returns>
        public static QueryFunc<T0, T1> First<T0, T1>(string sql)
        {
            return new QueryFunc<T0, T1>(Query<T1>.First, Query<T1>.FirstAsync, sql);
        }

        /// <summary>
        /// A query function that transforms the first result.
        /// </summary>
        /// <typeparam name="T0">The input type.</typeparam>
        /// <typeparam name="T1">The returned type.</typeparam>
        /// <param name="sql">The SQL query to transform <typeparamref name="T0"/> to <typeparamref name="T1"/>.</param>
        /// <returns>A query function that can transform queries returning the first result.</returns>
        public static QueryFunc<T0, T1> FirstOrDefault<T0, T1>(string sql)
        {
            return new QueryFunc<T0, T1>(Query<T1>.FirstOrDefault, Query<T1>.FirstOrDefaultAsync, sql);
        }

        /// <summary>
        /// A query function that transforms a list of results.
        /// </summary>
        /// <typeparam name="T0">The input type.</typeparam>
        /// <typeparam name="T1">The returned type.</typeparam>
        /// <param name="sql">The SQL query to transform a list of type <typeparamref name="T0"/> to <typeparamref name="T1"/>.</param>
        /// <returns>A query function that can transform queries returning a list of results.</returns>
        public static QueryFunc<List<T0>, List<T1>> List<T0, T1>(string sql)
        {
            return new QueryFunc<List<T0>, List<T1>>(Query<T1>.List, Query<T1>.ListAsync, sql);
        }

        public delegate T1 QueryF<T0, out T1>(Query<T0> query);

        /// <summary>
        /// A query function that transforms a list of results.
        /// </summary>
        /// <typeparam name="T0">The input type.</typeparam>
        /// <typeparam name="T1">The returned type.</typeparam>
        /// <param name="sql">The SQL query to transform a list of type <typeparamref name="T0"/> to <typeparamref name="T1"/>.</param>
        /// <returns>A query function that can transform queries returning a list of results.</returns>
        public static Func<Query<List<T0>>, Query<List<T1>>> ListF<T0, T1>(string sql)
        {
            return q => new Query<List<T1>>(Query<T1>.List, Query<T1>.ListAsync, sql.Replace("--Dapper.Compose.QueryFunc", q.Sql));
        }

        /// <summary>
        /// A query function that transforms a list of results.
        /// </summary>
        /// <typeparam name="T0">The input type.</typeparam>
        /// <typeparam name="T1">The returned type.</typeparam>
        /// <param name="sql">The SQL query to transform a list of type <typeparamref name="T0"/> to <typeparamref name="T1"/>.</param>
        /// <returns>A query function that can transform queries returning a list of results.</returns>
        public static Func<Query<List<T0>>, Query<T1>> SingleF<T0, T1>(string sql)
        {
            return q => new Query<T1>(Query<T1>.Single, Query<T1>.SingleAsync, sql.Replace("--Dapper.Compose.QueryFunc", q.Sql));
        }

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
            return Load(typeof(T).GetTypeInfo().Assembly, resourceName);
        }

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
        public static string Load(Assembly assembly, string resourceName)
        {
            int queryStart;
            var sql = Load(assembly, resourceName, out queryStart);
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
        /// <remarks>
        /// The key is the runnable file name, the value is the embedded SQL.
        /// </remarks>
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

        static readonly MethodInfo validate = new Action<IDbConnection, Query<int>, IDictionary<string, object>, IDbTransaction>(Validate<int>)
            .GetMethodInfo()
            .GetGenericMethodDefinition();

        /// <summary>
        /// Run all tests available through <paramref name="type"/>:
        /// * Iterate through <paramref name="type"/>'s static members and invoke any queries with
        ///   parameter bindings via <see cref="QueryParamAttribute"/>.
        /// * Execute any runnable queries embedded as resources.
        /// </summary>
        /// <param name="db">The database connection to use.</param>
        /// <param name="type">The type to inspect for queries.</param>
        /// <param name="transaction">The transaction in which to execute.</param>
        /// <returns>The set of errors generated.</returns>
        public static IEnumerable<KeyValuePair<string, Exception>> Validate(IDbConnection db, Type type, IDbTransaction transaction = null)
        {
            var args = new object[4];
            args[0] = db;
            args[3] = transaction ?? (transaction = db.BeginTransaction());
            Exception e;
            // run queries defined in fields
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            {
                if (!field.FieldType.IsConstructedGenericType || field.FieldType.GetGenericTypeDefinition() != typeof(Query<>))
                    continue;
                var query = field.GetValue(null);
                if (query != null)
                {
                    var attr = field.GetCustomAttributes<QueryParamAttribute>()
                                    .ToDictionary(x => x.Name, x => x.Value);
                    if (attr.Count > 0)
                    {
                        args[1] = query;
                        args[2] = attr;
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
            // run all queries defined as embedded resoruces
            foreach(var query in GetRunnable(type))
            {
                try
                {
                    db.Execute(query.Value, transaction: transaction);
                    continue;
                }
                catch (Exception ex)
                {
                    e = ex;
                }
                yield return new KeyValuePair<string, Exception>(query.Key, e);
            }
        }

        static void Validate<T>(IDbConnection db, Query<T> query, IDictionary<string, object> param, IDbTransaction transaction)
        {
            var cmd = db.CreateCommand();
            cmd.CommandText = query.Sql;
            if (transaction != null)
                cmd.Transaction = transaction;
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
