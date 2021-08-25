using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper.Compose
{
    /// <summary>
    /// A query function.
    /// </summary>
    /// <typeparam name="T0">The type constraint for generic parameters.</typeparam>
    /// <remarks>
    /// This encapsulates a generic, constrained query function, where the return type
    /// being operated upon doesn't change but must satisfy a type constraint.
    /// 
    /// If no constraint is applicable, then you can use QueryFunc&lt;object&gt;.
    /// 
    /// An example of a constrained generic query is a generic paging query:
    /// <code>
    /// select r.*
    /// from (
    ///   --Dapper.Compose.QueryFunc(0)
    /// ) r
    /// where r.PageRow between 1 + (@page-1) * @pageSize and @page * @pageSize
    /// </code>
    /// This query does not alter the type of the data being operated on, only the subset of
    /// results that are returned. You can load this as a QueryFunc&;lt;object&gt; and apply
    /// it to any existing SQL query:
    /// <code>
    /// QueryFunc&lt;object&gt; page = Query.ListFunc&lt;object&gt;(@"select r.*
    /// from (
    ///   --Dapper.Compose.QueryFunc
    /// ) r
    /// where r.PageRow between 1 + (@page-1) * @pageSize and @page * @pageSize");
    /// 
    /// Query&lt;List&lt;User&gt;&gt; users = page.Apply(Query.List&lt;User&gt;("select * from Users"));
    /// </code>
    /// </remarks>
    public struct QueryFunc<T0>
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
            where T : T0
        {
            return new Query<T>(x.Read, x.ReadAsync, Sql.Replace("--Dapper.Query.QueryFunc(0)", x.Sql));
        }
    }
}
