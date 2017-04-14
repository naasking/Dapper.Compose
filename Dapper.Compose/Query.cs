using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="sql">A formatted SQL query.</param>
        /// <param name="parameters">The SQL query parameters.</param>
        public Query(Func<SqlMapper.GridReader, T> read, string sql, params object[] parameters)
            : this(read, string.Format(sql, parameters))
        {
        }

        /// <summary>
        /// Construct a query.
        /// </summary>
        /// <param name="read">The materializing function.</param>
        /// <param name="sql">A formatted SQL query.</param>
        public Query(Func<SqlMapper.GridReader, T> read, string sql) : this()
        {
            Sql = sql;
            Read = read;
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
        /// The materializer for a single result.
        /// </summary>
        public static readonly Func<SqlMapper.GridReader, T> Single = Query.Reader<T>("ReadSingle");

        /// <summary>
        /// The materializer for a single optional result.
        /// </summary>
        public static readonly Func<SqlMapper.GridReader, T> SingleOrDefault = Query.Reader<T>("ReadSingleOrDefault");

        /// <summary>
        /// The materializer for the first result.
        /// </summary>
        public static readonly Func<SqlMapper.GridReader, T> First = Query.Reader<T>("ReadFirst");

        /// <summary>
        /// The materializer for the first optional result.
        /// </summary>
        public static readonly Func<SqlMapper.GridReader, T> FirstOrDefault = Query.Reader<T>("ReadFirstOrDefault");

        /// <summary>
        /// The materializer for a list of results.
        /// </summary>
        // passing buffered = true means the result is already a list
        public static readonly Func<SqlMapper.GridReader, IEnumerable<T>> List = x => x.Read<T>(true) as List<T>;
    }

    /// <summary>
    /// Query combinators.
    /// </summary>
    public static partial class Query
    {
        internal static Func<SqlMapper.GridReader, T> Reader<T>(string name, params Type[] argTypes)
        {
            // construct an open instance delegate on Grid Reader
            var method = typeof(SqlMapper.GridReader)
                         .GetMethods()
                         .Single(x => x.Name.Equals(name, StringComparison.Ordinal) && x.IsGenericMethodDefinition)
                         .MakeGenericMethod(typeof(T));
            return (Func<SqlMapper.GridReader, T>)Delegate.CreateDelegate(typeof(Func<SqlMapper.GridReader, T>), null, method);
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
            return new Query<T>(Query<T>.Single, sql, parameters);
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
            return new Query<T>(Query<T>.SingleOrDefault, sql, parameters);
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
            return new Query<T>(Query<T>.First, sql, parameters);
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
            return new Query<T>(Query<T>.FirstOrDefault, sql, parameters);
        }

        /// <summary>
        /// Create a query possibly returning a list of values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Query<IEnumerable<T>> List<T>(string sql, params object[] parameters)
        {
            return new Query<IEnumerable<T>>(Query<T>.List, sql, parameters);
        }
    }
}
