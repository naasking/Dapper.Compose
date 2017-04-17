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
        /// <param name="sqlFormat">A formatted SQL query.</param>
        /// <param name="parameters">The SQL query parameters.</param>
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

        internal static readonly Func<SqlMapper.GridReader, T> Single = Query.Reader<T, T>(nameof(SqlMapper.GridReader.ReadSingle));
        internal static readonly Func<SqlMapper.GridReader, Task<T>> SingleAsync = Query.Reader<T, Task<T>>(nameof(SqlMapper.GridReader.ReadSingleAsync));
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
        /// Create a query returning a single value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
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
        /// <param name="parameters"></param>
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
        /// <param name="parameters"></param>
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
        /// <param name="parameters"></param>
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
        /// <param name="parameters"></param>
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
                    if (line.Length > 0 && (line[0] != '-' && line[1] != '-'))
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
        /// <typeparam name="T">Any type whose assembly we're querying.</typeparam>
        /// <returns>The list of queries embedded in the assembly.</returns>
        public static IEnumerable<KeyValuePair<string, string>> GetRunnable<T>()
        {
            var asm = typeof(T).GetTypeInfo().Assembly;
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
    }
}
