using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper.Compose
{
    /// <summary>
    /// A query function.
    /// </summary>
    /// <typeparam name="TConstraint">The type constraint for generic parameters.</typeparam>
    /// <remarks>
    /// This encapsulates a generic, constrained query function, where the return type
    /// being operated upon doesn't change but must satisfy a type constraint.
    /// 
    /// If no constraint is applicable, then you can use QueryFunc&lt;object&gt;.
    /// </remarks>
    public struct QueryFunc<TConstraint>
    {
        /// <summary>
        /// Construct a new query function.
        /// </summary>
        /// <param name="sql"></param>
        public QueryFunc(string sql)
        {
            this.Sql = sql;
        }

        /// <summary>
        /// The SQL template.
        /// </summary>
        public string Sql { get; private set; }

        /// <summary>
        /// Generate a new query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x"></param>
        /// <returns></returns>
        public Query<T> Apply<T>(Query<T> x)
            where T : TConstraint
        {
            return new Query<T>(x.Read, x.ReadAsync, Sql.Replace("--Dapper.Query.QueryFunc", x.Sql));
        }
    }
}
