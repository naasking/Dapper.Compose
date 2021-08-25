using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper.Compose
{
    public struct MultiQuery<T>
    {
        Query<T> query;

        internal MultiQuery(Func<SqlMapper.GridReader, T> read, Func<SqlMapper.GridReader, Task<T>> readAsync, string sql)
        {
            this.query = new Query<T>(read, readAsync, sql);
        }

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
            return query.Execute(db, param, transaction, commandTimeout, commandType);
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
        public Task<T> ExecuteAsync(IDbConnection db, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            return query.ExecuteAsync(db, param, transaction, commandTimeout, commandType);
        }
    }
}
