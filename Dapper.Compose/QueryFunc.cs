using System;
using System.Data;
using System.Threading.Tasks;

namespace Dapper.Compose
{
    /// <summary>
    /// A query function.
    /// </summary>
    /// <typeparam name="T0">The type constraint for query 0.</typeparam>
    /// <remarks>
    /// This type of query function applies an SQL query to a SQL template of sorts, to generate a new SQL
    /// query that returns a different type.
    /// 
    /// For instance, we could write a COUNT query function like so:
    /// <code>
    /// select count(*)
    /// from(
    ///   --Dapper.Compose.QueryFunc(0)
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
        /// <param name="read">The materializing function.</param>
        /// <param name="readAsync">The async materializing function.</param>
        /// <param name="sql">An SQL query.</param>
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
        /// <typeparam name="T">The type returned by the given query.</typeparam>
        /// <param name="x">The query to transform.</param>
        /// <returns>A new query with the given transformation applied.</returns>
        public Query<T1> Apply<TQuery0>(Query<TQuery0> q0)
            where TQuery0 : T0
        {
            var sql = Sql
                         .Replace("--Dapper.Query.QueryFunc(0)", q0.Sql)
                         ;
            return new Query<T1>(Read, ReadAsync, sql);
        }
    }

    /// <summary>
    /// A query function.
    /// </summary>
    /// <typeparam name="T0">The type constraint for query 0.</typeparam>
    /// <typeparam name="T1">The type constraint for query 1.</typeparam>
    /// <remarks>
    /// This type of query function applies an SQL query to a SQL template of sorts, to generate a new SQL
    /// query that returns a different type.
    /// 
    /// For instance, we could write a COUNT query function like so:
    /// <code>
    /// select count(*)
    /// from(
    ///   --Dapper.Compose.QueryFunc(0)
    /// ) C
    /// </code>
    /// We load it as a QueryFunc&lt;object, int&gt;, an we can generate a COUNT(*) query for any
    /// SQL query.
    /// </remarks>
    public struct QueryFunc<T0, T1, T2>
    {
        /// <summary>
        /// Construct a new query function.
        /// </summary>
        /// <param name="read">The materializing function.</param>
        /// <param name="readAsync">The async materializing function.</param>
        /// <param name="sql">An SQL query.</param>
        public QueryFunc(Func<SqlMapper.GridReader, T2> read, Func<SqlMapper.GridReader, Task<T2>> readAsync, string sql)
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
        public Func<SqlMapper.GridReader, T2> Read { get; private set; }

        /// <summary>
        /// The function used to asynchronously materialize the result from the reader.
        /// </summary>
        public Func<SqlMapper.GridReader, Task<T2>> ReadAsync { get; private set; }

        /// <summary>
        /// Generate a new query
        /// </summary>
        /// <typeparam name="T">The type returned by the given query.</typeparam>
        /// <param name="x">The query to transform.</param>
        /// <returns>A new query with the given transformation applied.</returns>
        public Query<T2> Apply<TQuery0, TQuery1>(Query<TQuery0> q0, Query<TQuery1> q1)
            where TQuery0 : T0
            where TQuery1 : T1
        {
            var sql = Sql
                         .Replace("--Dapper.Query.QueryFunc(0)", q0.Sql)
                         .Replace("--Dapper.Query.QueryFunc(1)", q1.Sql)
                         ;
            return new Query<T2>(Read, ReadAsync, sql);
        }
    }

    /// <summary>
    /// A query function.
    /// </summary>
    /// <typeparam name="T0">The type constraint for query 0.</typeparam>
    /// <typeparam name="T1">The type constraint for query 1.</typeparam>
    /// <typeparam name="T2">The type constraint for query 2.</typeparam>
    /// <remarks>
    /// This type of query function applies an SQL query to a SQL template of sorts, to generate a new SQL
    /// query that returns a different type.
    /// 
    /// For instance, we could write a COUNT query function like so:
    /// <code>
    /// select count(*)
    /// from(
    ///   --Dapper.Compose.QueryFunc(0)
    /// ) C
    /// </code>
    /// We load it as a QueryFunc&lt;object, int&gt;, an we can generate a COUNT(*) query for any
    /// SQL query.
    /// </remarks>
    public struct QueryFunc<T0, T1, T2, T3>
    {
        /// <summary>
        /// Construct a new query function.
        /// </summary>
        /// <param name="read">The materializing function.</param>
        /// <param name="readAsync">The async materializing function.</param>
        /// <param name="sql">An SQL query.</param>
        public QueryFunc(Func<SqlMapper.GridReader, T3> read, Func<SqlMapper.GridReader, Task<T3>> readAsync, string sql)
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
        public Func<SqlMapper.GridReader, T3> Read { get; private set; }

        /// <summary>
        /// The function used to asynchronously materialize the result from the reader.
        /// </summary>
        public Func<SqlMapper.GridReader, Task<T3>> ReadAsync { get; private set; }

        /// <summary>
        /// Generate a new query
        /// </summary>
        /// <typeparam name="T">The type returned by the given query.</typeparam>
        /// <param name="x">The query to transform.</param>
        /// <returns>A new query with the given transformation applied.</returns>
        public Query<T3> Apply<TQuery0, TQuery1, TQuery2>(Query<TQuery0> q0, Query<TQuery1> q1, Query<TQuery2> q2)
            where TQuery0 : T0
            where TQuery1 : T1
            where TQuery2 : T2
        {
            var sql = Sql
                         .Replace("--Dapper.Query.QueryFunc(0)", q0.Sql)
                         .Replace("--Dapper.Query.QueryFunc(1)", q1.Sql)
                         .Replace("--Dapper.Query.QueryFunc(2)", q2.Sql)
                         ;
            return new Query<T3>(Read, ReadAsync, sql);
        }
    }

    /// <summary>
    /// A query function.
    /// </summary>
    /// <typeparam name="T0">The type constraint for query 0.</typeparam>
    /// <typeparam name="T1">The type constraint for query 1.</typeparam>
    /// <typeparam name="T2">The type constraint for query 2.</typeparam>
    /// <typeparam name="T3">The type constraint for query 3.</typeparam>
    /// <remarks>
    /// This type of query function applies an SQL query to a SQL template of sorts, to generate a new SQL
    /// query that returns a different type.
    /// 
    /// For instance, we could write a COUNT query function like so:
    /// <code>
    /// select count(*)
    /// from(
    ///   --Dapper.Compose.QueryFunc(0)
    /// ) C
    /// </code>
    /// We load it as a QueryFunc&lt;object, int&gt;, an we can generate a COUNT(*) query for any
    /// SQL query.
    /// </remarks>
    public struct QueryFunc<T0, T1, T2, T3, T4>
    {
        /// <summary>
        /// Construct a new query function.
        /// </summary>
        /// <param name="read">The materializing function.</param>
        /// <param name="readAsync">The async materializing function.</param>
        /// <param name="sql">An SQL query.</param>
        public QueryFunc(Func<SqlMapper.GridReader, T4> read, Func<SqlMapper.GridReader, Task<T4>> readAsync, string sql)
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
        public Func<SqlMapper.GridReader, T4> Read { get; private set; }

        /// <summary>
        /// The function used to asynchronously materialize the result from the reader.
        /// </summary>
        public Func<SqlMapper.GridReader, Task<T4>> ReadAsync { get; private set; }

        /// <summary>
        /// Generate a new query
        /// </summary>
        /// <typeparam name="T">The type returned by the given query.</typeparam>
        /// <param name="x">The query to transform.</param>
        /// <returns>A new query with the given transformation applied.</returns>
        public Query<T4> Apply<TQuery0, TQuery1, TQuery2, TQuery3>(Query<TQuery0> q0, Query<TQuery1> q1, Query<TQuery2> q2, Query<TQuery3> q3)
            where TQuery0 : T0
            where TQuery1 : T1
            where TQuery2 : T2
            where TQuery3 : T3
        {
            var sql = Sql
                         .Replace("--Dapper.Query.QueryFunc(0)", q0.Sql)
                         .Replace("--Dapper.Query.QueryFunc(1)", q1.Sql)
                         .Replace("--Dapper.Query.QueryFunc(2)", q2.Sql)
                         .Replace("--Dapper.Query.QueryFunc(3)", q3.Sql)
                         ;
            return new Query<T4>(Read, ReadAsync, sql);
        }
    }

    /// <summary>
    /// A query function.
    /// </summary>
    /// <typeparam name="T0">The type constraint for query 0.</typeparam>
    /// <typeparam name="T1">The type constraint for query 1.</typeparam>
    /// <typeparam name="T2">The type constraint for query 2.</typeparam>
    /// <typeparam name="T3">The type constraint for query 3.</typeparam>
    /// <typeparam name="T4">The type constraint for query 4.</typeparam>
    /// <remarks>
    /// This type of query function applies an SQL query to a SQL template of sorts, to generate a new SQL
    /// query that returns a different type.
    /// 
    /// For instance, we could write a COUNT query function like so:
    /// <code>
    /// select count(*)
    /// from(
    ///   --Dapper.Compose.QueryFunc(0)
    /// ) C
    /// </code>
    /// We load it as a QueryFunc&lt;object, int&gt;, an we can generate a COUNT(*) query for any
    /// SQL query.
    /// </remarks>
    public struct QueryFunc<T0, T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Construct a new query function.
        /// </summary>
        /// <param name="read">The materializing function.</param>
        /// <param name="readAsync">The async materializing function.</param>
        /// <param name="sql">An SQL query.</param>
        public QueryFunc(Func<SqlMapper.GridReader, T5> read, Func<SqlMapper.GridReader, Task<T5>> readAsync, string sql)
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
        public Func<SqlMapper.GridReader, T5> Read { get; private set; }

        /// <summary>
        /// The function used to asynchronously materialize the result from the reader.
        /// </summary>
        public Func<SqlMapper.GridReader, Task<T5>> ReadAsync { get; private set; }

        /// <summary>
        /// Generate a new query
        /// </summary>
        /// <typeparam name="T">The type returned by the given query.</typeparam>
        /// <param name="x">The query to transform.</param>
        /// <returns>A new query with the given transformation applied.</returns>
        public Query<T5> Apply<TQuery0, TQuery1, TQuery2, TQuery3, TQuery4>(Query<TQuery0> q0, Query<TQuery1> q1, Query<TQuery2> q2, Query<TQuery3> q3, Query<TQuery4> q4)
            where TQuery0 : T0
            where TQuery1 : T1
            where TQuery2 : T2
            where TQuery3 : T3
            where TQuery4 : T4
        {
            var sql = Sql
                         .Replace("--Dapper.Query.QueryFunc(0)", q0.Sql)
                         .Replace("--Dapper.Query.QueryFunc(1)", q1.Sql)
                         .Replace("--Dapper.Query.QueryFunc(2)", q2.Sql)
                         .Replace("--Dapper.Query.QueryFunc(3)", q3.Sql)
                         .Replace("--Dapper.Query.QueryFunc(4)", q4.Sql)
                         ;
            return new Query<T5>(Read, ReadAsync, sql);
        }
    }

    /// <summary>
    /// A query function.
    /// </summary>
    /// <typeparam name="T0">The type constraint for query 0.</typeparam>
    /// <typeparam name="T1">The type constraint for query 1.</typeparam>
    /// <typeparam name="T2">The type constraint for query 2.</typeparam>
    /// <typeparam name="T3">The type constraint for query 3.</typeparam>
    /// <typeparam name="T4">The type constraint for query 4.</typeparam>
    /// <typeparam name="T5">The type constraint for query 5.</typeparam>
    /// <remarks>
    /// This type of query function applies an SQL query to a SQL template of sorts, to generate a new SQL
    /// query that returns a different type.
    /// 
    /// For instance, we could write a COUNT query function like so:
    /// <code>
    /// select count(*)
    /// from(
    ///   --Dapper.Compose.QueryFunc(0)
    /// ) C
    /// </code>
    /// We load it as a QueryFunc&lt;object, int&gt;, an we can generate a COUNT(*) query for any
    /// SQL query.
    /// </remarks>
    public struct QueryFunc<T0, T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        /// Construct a new query function.
        /// </summary>
        /// <param name="read">The materializing function.</param>
        /// <param name="readAsync">The async materializing function.</param>
        /// <param name="sql">An SQL query.</param>
        public QueryFunc(Func<SqlMapper.GridReader, T6> read, Func<SqlMapper.GridReader, Task<T6>> readAsync, string sql)
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
        public Func<SqlMapper.GridReader, T6> Read { get; private set; }

        /// <summary>
        /// The function used to asynchronously materialize the result from the reader.
        /// </summary>
        public Func<SqlMapper.GridReader, Task<T6>> ReadAsync { get; private set; }

        /// <summary>
        /// Generate a new query
        /// </summary>
        /// <typeparam name="T">The type returned by the given query.</typeparam>
        /// <param name="x">The query to transform.</param>
        /// <returns>A new query with the given transformation applied.</returns>
        public Query<T6> Apply<TQuery0, TQuery1, TQuery2, TQuery3, TQuery4, TQuery5>(Query<TQuery0> q0, Query<TQuery1> q1, Query<TQuery2> q2, Query<TQuery3> q3, Query<TQuery4> q4, Query<TQuery5> q5)
            where TQuery0 : T0
            where TQuery1 : T1
            where TQuery2 : T2
            where TQuery3 : T3
            where TQuery4 : T4
            where TQuery5 : T5
        {
            var sql = Sql
                         .Replace("--Dapper.Query.QueryFunc(0)", q0.Sql)
                         .Replace("--Dapper.Query.QueryFunc(1)", q1.Sql)
                         .Replace("--Dapper.Query.QueryFunc(2)", q2.Sql)
                         .Replace("--Dapper.Query.QueryFunc(3)", q3.Sql)
                         .Replace("--Dapper.Query.QueryFunc(4)", q4.Sql)
                         .Replace("--Dapper.Query.QueryFunc(5)", q5.Sql)
                         ;
            return new Query<T6>(Read, ReadAsync, sql);
        }
    }

    /// <summary>
    /// A query function.
    /// </summary>
    /// <typeparam name="T0">The type constraint for query 0.</typeparam>
    /// <typeparam name="T1">The type constraint for query 1.</typeparam>
    /// <typeparam name="T2">The type constraint for query 2.</typeparam>
    /// <typeparam name="T3">The type constraint for query 3.</typeparam>
    /// <typeparam name="T4">The type constraint for query 4.</typeparam>
    /// <typeparam name="T5">The type constraint for query 5.</typeparam>
    /// <typeparam name="T6">The type constraint for query 6.</typeparam>
    /// <remarks>
    /// This type of query function applies an SQL query to a SQL template of sorts, to generate a new SQL
    /// query that returns a different type.
    /// 
    /// For instance, we could write a COUNT query function like so:
    /// <code>
    /// select count(*)
    /// from(
    ///   --Dapper.Compose.QueryFunc(0)
    /// ) C
    /// </code>
    /// We load it as a QueryFunc&lt;object, int&gt;, an we can generate a COUNT(*) query for any
    /// SQL query.
    /// </remarks>
    public struct QueryFunc<T0, T1, T2, T3, T4, T5, T6, T7>
    {
        /// <summary>
        /// Construct a new query function.
        /// </summary>
        /// <param name="read">The materializing function.</param>
        /// <param name="readAsync">The async materializing function.</param>
        /// <param name="sql">An SQL query.</param>
        public QueryFunc(Func<SqlMapper.GridReader, T7> read, Func<SqlMapper.GridReader, Task<T7>> readAsync, string sql)
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
        public Func<SqlMapper.GridReader, T7> Read { get; private set; }

        /// <summary>
        /// The function used to asynchronously materialize the result from the reader.
        /// </summary>
        public Func<SqlMapper.GridReader, Task<T7>> ReadAsync { get; private set; }

        /// <summary>
        /// Generate a new query
        /// </summary>
        /// <typeparam name="T">The type returned by the given query.</typeparam>
        /// <param name="x">The query to transform.</param>
        /// <returns>A new query with the given transformation applied.</returns>
        public Query<T7> Apply<TQuery0, TQuery1, TQuery2, TQuery3, TQuery4, TQuery5, TQuery6>(Query<TQuery0> q0, Query<TQuery1> q1, Query<TQuery2> q2, Query<TQuery3> q3, Query<TQuery4> q4, Query<TQuery5> q5, Query<TQuery6> q6)
            where TQuery0 : T0
            where TQuery1 : T1
            where TQuery2 : T2
            where TQuery3 : T3
            where TQuery4 : T4
            where TQuery5 : T5
            where TQuery6 : T6
        {
            var sql = Sql
                         .Replace("--Dapper.Query.QueryFunc(0)", q0.Sql)
                         .Replace("--Dapper.Query.QueryFunc(1)", q1.Sql)
                         .Replace("--Dapper.Query.QueryFunc(2)", q2.Sql)
                         .Replace("--Dapper.Query.QueryFunc(3)", q3.Sql)
                         .Replace("--Dapper.Query.QueryFunc(4)", q4.Sql)
                         .Replace("--Dapper.Query.QueryFunc(5)", q5.Sql)
                         .Replace("--Dapper.Query.QueryFunc(6)", q6.Sql)
                         ;
            return new Query<T7>(Read, ReadAsync, sql);
        }
    }

    /// <summary>
    /// A query function.
    /// </summary>
    /// <typeparam name="T0">The type constraint for query 0.</typeparam>
    /// <typeparam name="T1">The type constraint for query 1.</typeparam>
    /// <typeparam name="T2">The type constraint for query 2.</typeparam>
    /// <typeparam name="T3">The type constraint for query 3.</typeparam>
    /// <typeparam name="T4">The type constraint for query 4.</typeparam>
    /// <typeparam name="T5">The type constraint for query 5.</typeparam>
    /// <typeparam name="T6">The type constraint for query 6.</typeparam>
    /// <typeparam name="T7">The type constraint for query 7.</typeparam>
    /// <remarks>
    /// This type of query function applies an SQL query to a SQL template of sorts, to generate a new SQL
    /// query that returns a different type.
    /// 
    /// For instance, we could write a COUNT query function like so:
    /// <code>
    /// select count(*)
    /// from(
    ///   --Dapper.Compose.QueryFunc(0)
    /// ) C
    /// </code>
    /// We load it as a QueryFunc&lt;object, int&gt;, an we can generate a COUNT(*) query for any
    /// SQL query.
    /// </remarks>
    public struct QueryFunc<T0, T1, T2, T3, T4, T5, T6, T7, T8>
    {
        /// <summary>
        /// Construct a new query function.
        /// </summary>
        /// <param name="read">The materializing function.</param>
        /// <param name="readAsync">The async materializing function.</param>
        /// <param name="sql">An SQL query.</param>
        public QueryFunc(Func<SqlMapper.GridReader, T8> read, Func<SqlMapper.GridReader, Task<T8>> readAsync, string sql)
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
        public Func<SqlMapper.GridReader, T8> Read { get; private set; }

        /// <summary>
        /// The function used to asynchronously materialize the result from the reader.
        /// </summary>
        public Func<SqlMapper.GridReader, Task<T8>> ReadAsync { get; private set; }

        /// <summary>
        /// Generate a new query
        /// </summary>
        /// <typeparam name="T">The type returned by the given query.</typeparam>
        /// <param name="x">The query to transform.</param>
        /// <returns>A new query with the given transformation applied.</returns>
        public Query<T8> Apply<TQuery0, TQuery1, TQuery2, TQuery3, TQuery4, TQuery5, TQuery6, TQuery7>(Query<TQuery0> q0, Query<TQuery1> q1, Query<TQuery2> q2, Query<TQuery3> q3, Query<TQuery4> q4, Query<TQuery5> q5, Query<TQuery6> q6, Query<TQuery7> q7)
            where TQuery0 : T0
            where TQuery1 : T1
            where TQuery2 : T2
            where TQuery3 : T3
            where TQuery4 : T4
            where TQuery5 : T5
            where TQuery6 : T6
            where TQuery7 : T7
        {
            var sql = Sql
                         .Replace("--Dapper.Query.QueryFunc(0)", q0.Sql)
                         .Replace("--Dapper.Query.QueryFunc(1)", q1.Sql)
                         .Replace("--Dapper.Query.QueryFunc(2)", q2.Sql)
                         .Replace("--Dapper.Query.QueryFunc(3)", q3.Sql)
                         .Replace("--Dapper.Query.QueryFunc(4)", q4.Sql)
                         .Replace("--Dapper.Query.QueryFunc(5)", q5.Sql)
                         .Replace("--Dapper.Query.QueryFunc(6)", q6.Sql)
                         .Replace("--Dapper.Query.QueryFunc(7)", q7.Sql)
                         ;
            return new Query<T8>(Read, ReadAsync, sql);
        }
    }

}