using System;
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
        public Query(Func<SqlMapper.GridReader, T> read, Func<SqlMapper.GridReader, Task<T>> readAsync, string sqlFormat, params object[] parameters)
            : this()
        {
            //FIXME: this method of composing async queries isn't quite ideal, because building a multiquery
            //from another multiquery would execute a sync selector in the middle of an async computation. I
            //could circumvent this by requiring either a second async selector, or making the selector itself
            //async and synchronizing it explicitly for sync query execution, thus incurring overhead.
            Sql = string.Format(sqlFormat, parameters);
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
        public static Query<T> Single<T>(string sql, params object[] parameters)
        {
            return new Query<T>(Query<T>.Single, Query<T>.SingleAsync, sql, parameters);
        }

        /// <summary>
        /// Create a query possibly returning a single.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Query<T> SingleOrDefault<T>(string sql, params object[] parameters)
        {
            return new Query<T>(Query<T>.SingleOrDefault, Query<T>.SingleOrDefaultAsync, sql, parameters);
        }

        /// <summary>
        /// Create a query returning the first value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Query<T> First<T>(string sql, params object[] parameters)
        {
            return new Query<T>(Query<T>.First, Query<T>.FirstAsync, sql, parameters);
        }

        /// <summary>
        /// Create a query possibly returning the first optional value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Query<T> FirstOrDefault<T>(string sql, params object[] parameters)
        {
            return new Query<T>(Query<T>.FirstOrDefault, Query<T>.FirstOrDefaultAsync, sql, parameters);
        }

        /// <summary>
        /// Create a query possibly returning a list of values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Query<List<T>> List<T>(string sql, params object[] parameters)
        {
            return new Query<List<T>>(Query<T>.List, Query<T>.ListAsync, sql, parameters);
        }
    }
}
