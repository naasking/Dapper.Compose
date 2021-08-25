using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper.Compose
{
    /// <summary>
    /// A query function.
    /// </summary>
    /// <typeparam name="TConstraint">The constraint that any parameters must satisfy.</typeparam>
    /// <remarks>
    /// This type of query function applies an SQL query to a SQL template of sorts, to generate a new SQL
    /// query that returns a different type.
    /// 
    /// For instance, we could write a COUNT query function like so:
    /// <code>
    /// select count(*)
    /// from(
    ///   --Dapper.Compose.QueryFunc
    /// ) C
    /// </code>
    /// We load it as a QueryFunc&lt;object, int&gt;, an we can generate a COUNT(*) query for any
    /// SQL query.
    /// </remarks>
    public struct QueryFunc<T0, T1>
    {
        /// <summary>
        /// Construct a new query function.
        /// </summary>
        /// <param name="sql"></param>
        public QueryFunc(Func<SqlMapper.GridReader, T1> read, Func<SqlMapper.GridReader, Task<T1>> readAsync, string sql)
        {
            this.Sql = sql;
            this.Read = read;
            this.ReadAsync = readAsync;
        }

        /// <summary>
        /// The SQL template.
        /// </summary>
        public string Sql { get; private set; }

        /// <summary>
        /// The function used to materialize the result from the reader.
        /// </summary>
        public Func<SqlMapper.GridReader, T1> Read { get; private set; }

        /// <summary>
        /// The function used to asynchronously materialize the result from the reader.
        /// </summary>
        public Func<SqlMapper.GridReader, Task<T1>> ReadAsync { get; private set; }

        /// <summary>
        /// Generate a new query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x"></param>
        /// <returns></returns>
        public Query<T1> Apply(Query<T0> x)
        {
            return new Query<T1>(Read, ReadAsync, Sql.Replace("--Dapper.Query.QueryFunc", x.Sql));
        }
    }
}
