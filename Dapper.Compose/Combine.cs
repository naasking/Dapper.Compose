using System;

namespace Dapper.Compose
{
    public static partial class Query
    {
        /// <summary>
        /// Combine 1 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, TResult>(Query<T0> q0, Query<T1> q1, Func<T0, T1, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql);
        }

        /// <summary>
        /// Combine 2 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Func<T0, T1, T2, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql);
        }

        /// <summary>
        /// Combine 3 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Func<T0, T1, T2, T3, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql);
        }

        /// <summary>
        /// Combine 4 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Func<T0, T1, T2, T3, T4, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql);
        }

        /// <summary>
        /// Combine 5 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Func<T0, T1, T2, T3, T4, T5, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql);
        }

        /// <summary>
        /// Combine 6 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Func<T0, T1, T2, T3, T4, T5, T6, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql);
        }

        /// <summary>
        /// Combine 7 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql);
        }

        /// <summary>
        /// Combine 8 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql);
        }

        /// <summary>
        /// Combine 9 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql);
        }

        /// <summary>
        /// Combine 10 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql);
        }

        /// <summary>
        /// Combine 11 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql);
        }

        /// <summary>
        /// Combine 12 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql);
        }

        /// <summary>
        /// Combine 13 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql);
        }

        /// <summary>
        /// Combine 14 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql);
        }

        /// <summary>
        /// Combine 15 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql);
        }

        /// <summary>
        /// Combine 16 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql);
        }

        /// <summary>
        /// Combine 17 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql);
        }

        /// <summary>
        /// Combine 18 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="T18">Return type of <paramref name="q18" />.</typeparam>
        /// <param name="q18">Query #18 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Query<T18> q18, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x), q18.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x), await q18.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql + "\r\n" + q18.Sql);
        }

        /// <summary>
        /// Combine 19 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="T18">Return type of <paramref name="q18" />.</typeparam>
        /// <param name="q18">Query #18 in the multiquery.</param>
        /// <typeparam name="T19">Return type of <paramref name="q19" />.</typeparam>
        /// <param name="q19">Query #19 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Query<T18> q18, Query<T19> q19, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x), q18.Read(x), q19.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x), await q18.ReadAsync(x), await q19.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql + "\r\n" + q18.Sql + "\r\n" + q19.Sql);
        }

        /// <summary>
        /// Combine 20 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="T18">Return type of <paramref name="q18" />.</typeparam>
        /// <param name="q18">Query #18 in the multiquery.</param>
        /// <typeparam name="T19">Return type of <paramref name="q19" />.</typeparam>
        /// <param name="q19">Query #19 in the multiquery.</param>
        /// <typeparam name="T20">Return type of <paramref name="q20" />.</typeparam>
        /// <param name="q20">Query #20 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Query<T18> q18, Query<T19> q19, Query<T20> q20, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x), q18.Read(x), q19.Read(x), q20.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x), await q18.ReadAsync(x), await q19.ReadAsync(x), await q20.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql + "\r\n" + q18.Sql + "\r\n" + q19.Sql + "\r\n" + q20.Sql);
        }

        /// <summary>
        /// Combine 21 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="T18">Return type of <paramref name="q18" />.</typeparam>
        /// <param name="q18">Query #18 in the multiquery.</param>
        /// <typeparam name="T19">Return type of <paramref name="q19" />.</typeparam>
        /// <param name="q19">Query #19 in the multiquery.</param>
        /// <typeparam name="T20">Return type of <paramref name="q20" />.</typeparam>
        /// <param name="q20">Query #20 in the multiquery.</param>
        /// <typeparam name="T21">Return type of <paramref name="q21" />.</typeparam>
        /// <param name="q21">Query #21 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Query<T18> q18, Query<T19> q19, Query<T20> q20, Query<T21> q21, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x), q18.Read(x), q19.Read(x), q20.Read(x), q21.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x), await q18.ReadAsync(x), await q19.ReadAsync(x), await q20.ReadAsync(x), await q21.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql + "\r\n" + q18.Sql + "\r\n" + q19.Sql + "\r\n" + q20.Sql + "\r\n" + q21.Sql);
        }

        /// <summary>
        /// Combine 22 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="T18">Return type of <paramref name="q18" />.</typeparam>
        /// <param name="q18">Query #18 in the multiquery.</param>
        /// <typeparam name="T19">Return type of <paramref name="q19" />.</typeparam>
        /// <param name="q19">Query #19 in the multiquery.</param>
        /// <typeparam name="T20">Return type of <paramref name="q20" />.</typeparam>
        /// <param name="q20">Query #20 in the multiquery.</param>
        /// <typeparam name="T21">Return type of <paramref name="q21" />.</typeparam>
        /// <param name="q21">Query #21 in the multiquery.</param>
        /// <typeparam name="T22">Return type of <paramref name="q22" />.</typeparam>
        /// <param name="q22">Query #22 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Query<T18> q18, Query<T19> q19, Query<T20> q20, Query<T21> q21, Query<T22> q22, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x), q18.Read(x), q19.Read(x), q20.Read(x), q21.Read(x), q22.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x), await q18.ReadAsync(x), await q19.ReadAsync(x), await q20.ReadAsync(x), await q21.ReadAsync(x), await q22.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql + "\r\n" + q18.Sql + "\r\n" + q19.Sql + "\r\n" + q20.Sql + "\r\n" + q21.Sql + "\r\n" + q22.Sql);
        }

        /// <summary>
        /// Combine 23 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="T18">Return type of <paramref name="q18" />.</typeparam>
        /// <param name="q18">Query #18 in the multiquery.</param>
        /// <typeparam name="T19">Return type of <paramref name="q19" />.</typeparam>
        /// <param name="q19">Query #19 in the multiquery.</param>
        /// <typeparam name="T20">Return type of <paramref name="q20" />.</typeparam>
        /// <param name="q20">Query #20 in the multiquery.</param>
        /// <typeparam name="T21">Return type of <paramref name="q21" />.</typeparam>
        /// <param name="q21">Query #21 in the multiquery.</param>
        /// <typeparam name="T22">Return type of <paramref name="q22" />.</typeparam>
        /// <param name="q22">Query #22 in the multiquery.</param>
        /// <typeparam name="T23">Return type of <paramref name="q23" />.</typeparam>
        /// <param name="q23">Query #23 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Query<T18> q18, Query<T19> q19, Query<T20> q20, Query<T21> q21, Query<T22> q22, Query<T23> q23, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x), q18.Read(x), q19.Read(x), q20.Read(x), q21.Read(x), q22.Read(x), q23.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x), await q18.ReadAsync(x), await q19.ReadAsync(x), await q20.ReadAsync(x), await q21.ReadAsync(x), await q22.ReadAsync(x), await q23.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql + "\r\n" + q18.Sql + "\r\n" + q19.Sql + "\r\n" + q20.Sql + "\r\n" + q21.Sql + "\r\n" + q22.Sql + "\r\n" + q23.Sql);
        }

        /// <summary>
        /// Combine 24 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="T18">Return type of <paramref name="q18" />.</typeparam>
        /// <param name="q18">Query #18 in the multiquery.</param>
        /// <typeparam name="T19">Return type of <paramref name="q19" />.</typeparam>
        /// <param name="q19">Query #19 in the multiquery.</param>
        /// <typeparam name="T20">Return type of <paramref name="q20" />.</typeparam>
        /// <param name="q20">Query #20 in the multiquery.</param>
        /// <typeparam name="T21">Return type of <paramref name="q21" />.</typeparam>
        /// <param name="q21">Query #21 in the multiquery.</param>
        /// <typeparam name="T22">Return type of <paramref name="q22" />.</typeparam>
        /// <param name="q22">Query #22 in the multiquery.</param>
        /// <typeparam name="T23">Return type of <paramref name="q23" />.</typeparam>
        /// <param name="q23">Query #23 in the multiquery.</param>
        /// <typeparam name="T24">Return type of <paramref name="q24" />.</typeparam>
        /// <param name="q24">Query #24 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Query<T18> q18, Query<T19> q19, Query<T20> q20, Query<T21> q21, Query<T22> q22, Query<T23> q23, Query<T24> q24, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x), q18.Read(x), q19.Read(x), q20.Read(x), q21.Read(x), q22.Read(x), q23.Read(x), q24.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x), await q18.ReadAsync(x), await q19.ReadAsync(x), await q20.ReadAsync(x), await q21.ReadAsync(x), await q22.ReadAsync(x), await q23.ReadAsync(x), await q24.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql + "\r\n" + q18.Sql + "\r\n" + q19.Sql + "\r\n" + q20.Sql + "\r\n" + q21.Sql + "\r\n" + q22.Sql + "\r\n" + q23.Sql + "\r\n" + q24.Sql);
        }

        /// <summary>
        /// Combine 25 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="T18">Return type of <paramref name="q18" />.</typeparam>
        /// <param name="q18">Query #18 in the multiquery.</param>
        /// <typeparam name="T19">Return type of <paramref name="q19" />.</typeparam>
        /// <param name="q19">Query #19 in the multiquery.</param>
        /// <typeparam name="T20">Return type of <paramref name="q20" />.</typeparam>
        /// <param name="q20">Query #20 in the multiquery.</param>
        /// <typeparam name="T21">Return type of <paramref name="q21" />.</typeparam>
        /// <param name="q21">Query #21 in the multiquery.</param>
        /// <typeparam name="T22">Return type of <paramref name="q22" />.</typeparam>
        /// <param name="q22">Query #22 in the multiquery.</param>
        /// <typeparam name="T23">Return type of <paramref name="q23" />.</typeparam>
        /// <param name="q23">Query #23 in the multiquery.</param>
        /// <typeparam name="T24">Return type of <paramref name="q24" />.</typeparam>
        /// <param name="q24">Query #24 in the multiquery.</param>
        /// <typeparam name="T25">Return type of <paramref name="q25" />.</typeparam>
        /// <param name="q25">Query #25 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Query<T18> q18, Query<T19> q19, Query<T20> q20, Query<T21> q21, Query<T22> q22, Query<T23> q23, Query<T24> q24, Query<T25> q25, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x), q18.Read(x), q19.Read(x), q20.Read(x), q21.Read(x), q22.Read(x), q23.Read(x), q24.Read(x), q25.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x), await q18.ReadAsync(x), await q19.ReadAsync(x), await q20.ReadAsync(x), await q21.ReadAsync(x), await q22.ReadAsync(x), await q23.ReadAsync(x), await q24.ReadAsync(x), await q25.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql + "\r\n" + q18.Sql + "\r\n" + q19.Sql + "\r\n" + q20.Sql + "\r\n" + q21.Sql + "\r\n" + q22.Sql + "\r\n" + q23.Sql + "\r\n" + q24.Sql + "\r\n" + q25.Sql);
        }

        /// <summary>
        /// Combine 26 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="T18">Return type of <paramref name="q18" />.</typeparam>
        /// <param name="q18">Query #18 in the multiquery.</param>
        /// <typeparam name="T19">Return type of <paramref name="q19" />.</typeparam>
        /// <param name="q19">Query #19 in the multiquery.</param>
        /// <typeparam name="T20">Return type of <paramref name="q20" />.</typeparam>
        /// <param name="q20">Query #20 in the multiquery.</param>
        /// <typeparam name="T21">Return type of <paramref name="q21" />.</typeparam>
        /// <param name="q21">Query #21 in the multiquery.</param>
        /// <typeparam name="T22">Return type of <paramref name="q22" />.</typeparam>
        /// <param name="q22">Query #22 in the multiquery.</param>
        /// <typeparam name="T23">Return type of <paramref name="q23" />.</typeparam>
        /// <param name="q23">Query #23 in the multiquery.</param>
        /// <typeparam name="T24">Return type of <paramref name="q24" />.</typeparam>
        /// <param name="q24">Query #24 in the multiquery.</param>
        /// <typeparam name="T25">Return type of <paramref name="q25" />.</typeparam>
        /// <param name="q25">Query #25 in the multiquery.</param>
        /// <typeparam name="T26">Return type of <paramref name="q26" />.</typeparam>
        /// <param name="q26">Query #26 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Query<T18> q18, Query<T19> q19, Query<T20> q20, Query<T21> q21, Query<T22> q22, Query<T23> q23, Query<T24> q24, Query<T25> q25, Query<T26> q26, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x), q18.Read(x), q19.Read(x), q20.Read(x), q21.Read(x), q22.Read(x), q23.Read(x), q24.Read(x), q25.Read(x), q26.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x), await q18.ReadAsync(x), await q19.ReadAsync(x), await q20.ReadAsync(x), await q21.ReadAsync(x), await q22.ReadAsync(x), await q23.ReadAsync(x), await q24.ReadAsync(x), await q25.ReadAsync(x), await q26.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql + "\r\n" + q18.Sql + "\r\n" + q19.Sql + "\r\n" + q20.Sql + "\r\n" + q21.Sql + "\r\n" + q22.Sql + "\r\n" + q23.Sql + "\r\n" + q24.Sql + "\r\n" + q25.Sql + "\r\n" + q26.Sql);
        }

        /// <summary>
        /// Combine 27 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="T18">Return type of <paramref name="q18" />.</typeparam>
        /// <param name="q18">Query #18 in the multiquery.</param>
        /// <typeparam name="T19">Return type of <paramref name="q19" />.</typeparam>
        /// <param name="q19">Query #19 in the multiquery.</param>
        /// <typeparam name="T20">Return type of <paramref name="q20" />.</typeparam>
        /// <param name="q20">Query #20 in the multiquery.</param>
        /// <typeparam name="T21">Return type of <paramref name="q21" />.</typeparam>
        /// <param name="q21">Query #21 in the multiquery.</param>
        /// <typeparam name="T22">Return type of <paramref name="q22" />.</typeparam>
        /// <param name="q22">Query #22 in the multiquery.</param>
        /// <typeparam name="T23">Return type of <paramref name="q23" />.</typeparam>
        /// <param name="q23">Query #23 in the multiquery.</param>
        /// <typeparam name="T24">Return type of <paramref name="q24" />.</typeparam>
        /// <param name="q24">Query #24 in the multiquery.</param>
        /// <typeparam name="T25">Return type of <paramref name="q25" />.</typeparam>
        /// <param name="q25">Query #25 in the multiquery.</param>
        /// <typeparam name="T26">Return type of <paramref name="q26" />.</typeparam>
        /// <param name="q26">Query #26 in the multiquery.</param>
        /// <typeparam name="T27">Return type of <paramref name="q27" />.</typeparam>
        /// <param name="q27">Query #27 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Query<T18> q18, Query<T19> q19, Query<T20> q20, Query<T21> q21, Query<T22> q22, Query<T23> q23, Query<T24> q24, Query<T25> q25, Query<T26> q26, Query<T27> q27, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x), q18.Read(x), q19.Read(x), q20.Read(x), q21.Read(x), q22.Read(x), q23.Read(x), q24.Read(x), q25.Read(x), q26.Read(x), q27.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x), await q18.ReadAsync(x), await q19.ReadAsync(x), await q20.ReadAsync(x), await q21.ReadAsync(x), await q22.ReadAsync(x), await q23.ReadAsync(x), await q24.ReadAsync(x), await q25.ReadAsync(x), await q26.ReadAsync(x), await q27.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql + "\r\n" + q18.Sql + "\r\n" + q19.Sql + "\r\n" + q20.Sql + "\r\n" + q21.Sql + "\r\n" + q22.Sql + "\r\n" + q23.Sql + "\r\n" + q24.Sql + "\r\n" + q25.Sql + "\r\n" + q26.Sql + "\r\n" + q27.Sql);
        }

        /// <summary>
        /// Combine 28 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="T18">Return type of <paramref name="q18" />.</typeparam>
        /// <param name="q18">Query #18 in the multiquery.</param>
        /// <typeparam name="T19">Return type of <paramref name="q19" />.</typeparam>
        /// <param name="q19">Query #19 in the multiquery.</param>
        /// <typeparam name="T20">Return type of <paramref name="q20" />.</typeparam>
        /// <param name="q20">Query #20 in the multiquery.</param>
        /// <typeparam name="T21">Return type of <paramref name="q21" />.</typeparam>
        /// <param name="q21">Query #21 in the multiquery.</param>
        /// <typeparam name="T22">Return type of <paramref name="q22" />.</typeparam>
        /// <param name="q22">Query #22 in the multiquery.</param>
        /// <typeparam name="T23">Return type of <paramref name="q23" />.</typeparam>
        /// <param name="q23">Query #23 in the multiquery.</param>
        /// <typeparam name="T24">Return type of <paramref name="q24" />.</typeparam>
        /// <param name="q24">Query #24 in the multiquery.</param>
        /// <typeparam name="T25">Return type of <paramref name="q25" />.</typeparam>
        /// <param name="q25">Query #25 in the multiquery.</param>
        /// <typeparam name="T26">Return type of <paramref name="q26" />.</typeparam>
        /// <param name="q26">Query #26 in the multiquery.</param>
        /// <typeparam name="T27">Return type of <paramref name="q27" />.</typeparam>
        /// <param name="q27">Query #27 in the multiquery.</param>
        /// <typeparam name="T28">Return type of <paramref name="q28" />.</typeparam>
        /// <param name="q28">Query #28 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Query<T18> q18, Query<T19> q19, Query<T20> q20, Query<T21> q21, Query<T22> q22, Query<T23> q23, Query<T24> q24, Query<T25> q25, Query<T26> q26, Query<T27> q27, Query<T28> q28, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x), q18.Read(x), q19.Read(x), q20.Read(x), q21.Read(x), q22.Read(x), q23.Read(x), q24.Read(x), q25.Read(x), q26.Read(x), q27.Read(x), q28.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x), await q18.ReadAsync(x), await q19.ReadAsync(x), await q20.ReadAsync(x), await q21.ReadAsync(x), await q22.ReadAsync(x), await q23.ReadAsync(x), await q24.ReadAsync(x), await q25.ReadAsync(x), await q26.ReadAsync(x), await q27.ReadAsync(x), await q28.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql + "\r\n" + q18.Sql + "\r\n" + q19.Sql + "\r\n" + q20.Sql + "\r\n" + q21.Sql + "\r\n" + q22.Sql + "\r\n" + q23.Sql + "\r\n" + q24.Sql + "\r\n" + q25.Sql + "\r\n" + q26.Sql + "\r\n" + q27.Sql + "\r\n" + q28.Sql);
        }

        /// <summary>
        /// Combine 29 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="T18">Return type of <paramref name="q18" />.</typeparam>
        /// <param name="q18">Query #18 in the multiquery.</param>
        /// <typeparam name="T19">Return type of <paramref name="q19" />.</typeparam>
        /// <param name="q19">Query #19 in the multiquery.</param>
        /// <typeparam name="T20">Return type of <paramref name="q20" />.</typeparam>
        /// <param name="q20">Query #20 in the multiquery.</param>
        /// <typeparam name="T21">Return type of <paramref name="q21" />.</typeparam>
        /// <param name="q21">Query #21 in the multiquery.</param>
        /// <typeparam name="T22">Return type of <paramref name="q22" />.</typeparam>
        /// <param name="q22">Query #22 in the multiquery.</param>
        /// <typeparam name="T23">Return type of <paramref name="q23" />.</typeparam>
        /// <param name="q23">Query #23 in the multiquery.</param>
        /// <typeparam name="T24">Return type of <paramref name="q24" />.</typeparam>
        /// <param name="q24">Query #24 in the multiquery.</param>
        /// <typeparam name="T25">Return type of <paramref name="q25" />.</typeparam>
        /// <param name="q25">Query #25 in the multiquery.</param>
        /// <typeparam name="T26">Return type of <paramref name="q26" />.</typeparam>
        /// <param name="q26">Query #26 in the multiquery.</param>
        /// <typeparam name="T27">Return type of <paramref name="q27" />.</typeparam>
        /// <param name="q27">Query #27 in the multiquery.</param>
        /// <typeparam name="T28">Return type of <paramref name="q28" />.</typeparam>
        /// <param name="q28">Query #28 in the multiquery.</param>
        /// <typeparam name="T29">Return type of <paramref name="q29" />.</typeparam>
        /// <param name="q29">Query #29 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Query<T18> q18, Query<T19> q19, Query<T20> q20, Query<T21> q21, Query<T22> q22, Query<T23> q23, Query<T24> q24, Query<T25> q25, Query<T26> q26, Query<T27> q27, Query<T28> q28, Query<T29> q29, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x), q18.Read(x), q19.Read(x), q20.Read(x), q21.Read(x), q22.Read(x), q23.Read(x), q24.Read(x), q25.Read(x), q26.Read(x), q27.Read(x), q28.Read(x), q29.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x), await q18.ReadAsync(x), await q19.ReadAsync(x), await q20.ReadAsync(x), await q21.ReadAsync(x), await q22.ReadAsync(x), await q23.ReadAsync(x), await q24.ReadAsync(x), await q25.ReadAsync(x), await q26.ReadAsync(x), await q27.ReadAsync(x), await q28.ReadAsync(x), await q29.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql + "\r\n" + q18.Sql + "\r\n" + q19.Sql + "\r\n" + q20.Sql + "\r\n" + q21.Sql + "\r\n" + q22.Sql + "\r\n" + q23.Sql + "\r\n" + q24.Sql + "\r\n" + q25.Sql + "\r\n" + q26.Sql + "\r\n" + q27.Sql + "\r\n" + q28.Sql + "\r\n" + q29.Sql);
        }

        /// <summary>
        /// Combine 30 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="T18">Return type of <paramref name="q18" />.</typeparam>
        /// <param name="q18">Query #18 in the multiquery.</param>
        /// <typeparam name="T19">Return type of <paramref name="q19" />.</typeparam>
        /// <param name="q19">Query #19 in the multiquery.</param>
        /// <typeparam name="T20">Return type of <paramref name="q20" />.</typeparam>
        /// <param name="q20">Query #20 in the multiquery.</param>
        /// <typeparam name="T21">Return type of <paramref name="q21" />.</typeparam>
        /// <param name="q21">Query #21 in the multiquery.</param>
        /// <typeparam name="T22">Return type of <paramref name="q22" />.</typeparam>
        /// <param name="q22">Query #22 in the multiquery.</param>
        /// <typeparam name="T23">Return type of <paramref name="q23" />.</typeparam>
        /// <param name="q23">Query #23 in the multiquery.</param>
        /// <typeparam name="T24">Return type of <paramref name="q24" />.</typeparam>
        /// <param name="q24">Query #24 in the multiquery.</param>
        /// <typeparam name="T25">Return type of <paramref name="q25" />.</typeparam>
        /// <param name="q25">Query #25 in the multiquery.</param>
        /// <typeparam name="T26">Return type of <paramref name="q26" />.</typeparam>
        /// <param name="q26">Query #26 in the multiquery.</param>
        /// <typeparam name="T27">Return type of <paramref name="q27" />.</typeparam>
        /// <param name="q27">Query #27 in the multiquery.</param>
        /// <typeparam name="T28">Return type of <paramref name="q28" />.</typeparam>
        /// <param name="q28">Query #28 in the multiquery.</param>
        /// <typeparam name="T29">Return type of <paramref name="q29" />.</typeparam>
        /// <param name="q29">Query #29 in the multiquery.</param>
        /// <typeparam name="T30">Return type of <paramref name="q30" />.</typeparam>
        /// <param name="q30">Query #30 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Query<T18> q18, Query<T19> q19, Query<T20> q20, Query<T21> q21, Query<T22> q22, Query<T23> q23, Query<T24> q24, Query<T25> q25, Query<T26> q26, Query<T27> q27, Query<T28> q28, Query<T29> q29, Query<T30> q30, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x), q18.Read(x), q19.Read(x), q20.Read(x), q21.Read(x), q22.Read(x), q23.Read(x), q24.Read(x), q25.Read(x), q26.Read(x), q27.Read(x), q28.Read(x), q29.Read(x), q30.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x), await q18.ReadAsync(x), await q19.ReadAsync(x), await q20.ReadAsync(x), await q21.ReadAsync(x), await q22.ReadAsync(x), await q23.ReadAsync(x), await q24.ReadAsync(x), await q25.ReadAsync(x), await q26.ReadAsync(x), await q27.ReadAsync(x), await q28.ReadAsync(x), await q29.ReadAsync(x), await q30.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql + "\r\n" + q18.Sql + "\r\n" + q19.Sql + "\r\n" + q20.Sql + "\r\n" + q21.Sql + "\r\n" + q22.Sql + "\r\n" + q23.Sql + "\r\n" + q24.Sql + "\r\n" + q25.Sql + "\r\n" + q26.Sql + "\r\n" + q27.Sql + "\r\n" + q28.Sql + "\r\n" + q29.Sql + "\r\n" + q30.Sql);
        }

        /// <summary>
        /// Combine 31 subqueries into a multiquery.
        /// </summary>
        /// <param name="selector">Build the return value for the set of subqueries.</param>
        /// <typeparam name="T0">Return type of query <paramref name="q0" />.</typeparam>
        /// <param name="q0">Query #0 in the multiquery.</param>
        /// <typeparam name="T1">Return type of <paramref name="q1" />.</typeparam>
        /// <param name="q1">Query #1 in the multiquery.</param>
        /// <typeparam name="T2">Return type of <paramref name="q2" />.</typeparam>
        /// <param name="q2">Query #2 in the multiquery.</param>
        /// <typeparam name="T3">Return type of <paramref name="q3" />.</typeparam>
        /// <param name="q3">Query #3 in the multiquery.</param>
        /// <typeparam name="T4">Return type of <paramref name="q4" />.</typeparam>
        /// <param name="q4">Query #4 in the multiquery.</param>
        /// <typeparam name="T5">Return type of <paramref name="q5" />.</typeparam>
        /// <param name="q5">Query #5 in the multiquery.</param>
        /// <typeparam name="T6">Return type of <paramref name="q6" />.</typeparam>
        /// <param name="q6">Query #6 in the multiquery.</param>
        /// <typeparam name="T7">Return type of <paramref name="q7" />.</typeparam>
        /// <param name="q7">Query #7 in the multiquery.</param>
        /// <typeparam name="T8">Return type of <paramref name="q8" />.</typeparam>
        /// <param name="q8">Query #8 in the multiquery.</param>
        /// <typeparam name="T9">Return type of <paramref name="q9" />.</typeparam>
        /// <param name="q9">Query #9 in the multiquery.</param>
        /// <typeparam name="T10">Return type of <paramref name="q10" />.</typeparam>
        /// <param name="q10">Query #10 in the multiquery.</param>
        /// <typeparam name="T11">Return type of <paramref name="q11" />.</typeparam>
        /// <param name="q11">Query #11 in the multiquery.</param>
        /// <typeparam name="T12">Return type of <paramref name="q12" />.</typeparam>
        /// <param name="q12">Query #12 in the multiquery.</param>
        /// <typeparam name="T13">Return type of <paramref name="q13" />.</typeparam>
        /// <param name="q13">Query #13 in the multiquery.</param>
        /// <typeparam name="T14">Return type of <paramref name="q14" />.</typeparam>
        /// <param name="q14">Query #14 in the multiquery.</param>
        /// <typeparam name="T15">Return type of <paramref name="q15" />.</typeparam>
        /// <param name="q15">Query #15 in the multiquery.</param>
        /// <typeparam name="T16">Return type of <paramref name="q16" />.</typeparam>
        /// <param name="q16">Query #16 in the multiquery.</param>
        /// <typeparam name="T17">Return type of <paramref name="q17" />.</typeparam>
        /// <param name="q17">Query #17 in the multiquery.</param>
        /// <typeparam name="T18">Return type of <paramref name="q18" />.</typeparam>
        /// <param name="q18">Query #18 in the multiquery.</param>
        /// <typeparam name="T19">Return type of <paramref name="q19" />.</typeparam>
        /// <param name="q19">Query #19 in the multiquery.</param>
        /// <typeparam name="T20">Return type of <paramref name="q20" />.</typeparam>
        /// <param name="q20">Query #20 in the multiquery.</param>
        /// <typeparam name="T21">Return type of <paramref name="q21" />.</typeparam>
        /// <param name="q21">Query #21 in the multiquery.</param>
        /// <typeparam name="T22">Return type of <paramref name="q22" />.</typeparam>
        /// <param name="q22">Query #22 in the multiquery.</param>
        /// <typeparam name="T23">Return type of <paramref name="q23" />.</typeparam>
        /// <param name="q23">Query #23 in the multiquery.</param>
        /// <typeparam name="T24">Return type of <paramref name="q24" />.</typeparam>
        /// <param name="q24">Query #24 in the multiquery.</param>
        /// <typeparam name="T25">Return type of <paramref name="q25" />.</typeparam>
        /// <param name="q25">Query #25 in the multiquery.</param>
        /// <typeparam name="T26">Return type of <paramref name="q26" />.</typeparam>
        /// <param name="q26">Query #26 in the multiquery.</param>
        /// <typeparam name="T27">Return type of <paramref name="q27" />.</typeparam>
        /// <param name="q27">Query #27 in the multiquery.</param>
        /// <typeparam name="T28">Return type of <paramref name="q28" />.</typeparam>
        /// <param name="q28">Query #28 in the multiquery.</param>
        /// <typeparam name="T29">Return type of <paramref name="q29" />.</typeparam>
        /// <param name="q29">Query #29 in the multiquery.</param>
        /// <typeparam name="T30">Return type of <paramref name="q30" />.</typeparam>
        /// <param name="q30">Query #30 in the multiquery.</param>
        /// <typeparam name="T31">Return type of <paramref name="q31" />.</typeparam>
        /// <param name="q31">Query #31 in the multiquery.</param>
        /// <typeparam name="TResult">The final return.</typeparam>
        /// <returns>A value constructed from the various subqueries.</returns>
        public static MultiQuery<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Query<T16> q16, Query<T17> q17, Query<T18> q18, Query<T19> q19, Query<T20> q20, Query<T21> q21, Query<T22> q22, Query<T23> q23, Query<T24> q24, Query<T25> q25, Query<T26> q26, Query<T27> q27, Query<T28> q28, Query<T29> q29, Query<T30> q30, Query<T31> q31, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, TResult> selector)
        {
            return new MultiQuery<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x), q16.Read(x), q17.Read(x), q18.Read(x), q19.Read(x), q20.Read(x), q21.Read(x), q22.Read(x), q23.Read(x), q24.Read(x), q25.Read(x), q26.Read(x), q27.Read(x), q28.Read(x), q29.Read(x), q30.Read(x), q31.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x), await q16.ReadAsync(x), await q17.ReadAsync(x), await q18.ReadAsync(x), await q19.ReadAsync(x), await q20.ReadAsync(x), await q21.ReadAsync(x), await q22.ReadAsync(x), await q23.ReadAsync(x), await q24.ReadAsync(x), await q25.ReadAsync(x), await q26.ReadAsync(x), await q27.ReadAsync(x), await q28.ReadAsync(x), await q29.ReadAsync(x), await q30.ReadAsync(x), await q31.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql + "\r\n" + q16.Sql + "\r\n" + q17.Sql + "\r\n" + q18.Sql + "\r\n" + q19.Sql + "\r\n" + q20.Sql + "\r\n" + q21.Sql + "\r\n" + q22.Sql + "\r\n" + q23.Sql + "\r\n" + q24.Sql + "\r\n" + q25.Sql + "\r\n" + q26.Sql + "\r\n" + q27.Sql + "\r\n" + q28.Sql + "\r\n" + q29.Sql + "\r\n" + q30.Sql + "\r\n" + q31.Sql);
        }

	}

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <typeparam name="T18">Type of parameter <paramref name="arg18" />.</typeparam>
    /// <param name="arg18">Parameter #18 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <typeparam name="T18">Type of parameter <paramref name="arg18" />.</typeparam>
    /// <param name="arg18">Parameter #18 of the function.</param>
    /// <typeparam name="T19">Type of parameter <paramref name="arg19" />.</typeparam>
    /// <param name="arg19">Parameter #19 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18, T19 arg19);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <typeparam name="T18">Type of parameter <paramref name="arg18" />.</typeparam>
    /// <param name="arg18">Parameter #18 of the function.</param>
    /// <typeparam name="T19">Type of parameter <paramref name="arg19" />.</typeparam>
    /// <param name="arg19">Parameter #19 of the function.</param>
    /// <typeparam name="T20">Type of parameter <paramref name="arg20" />.</typeparam>
    /// <param name="arg20">Parameter #20 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18, T19 arg19, T20 arg20);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <typeparam name="T18">Type of parameter <paramref name="arg18" />.</typeparam>
    /// <param name="arg18">Parameter #18 of the function.</param>
    /// <typeparam name="T19">Type of parameter <paramref name="arg19" />.</typeparam>
    /// <param name="arg19">Parameter #19 of the function.</param>
    /// <typeparam name="T20">Type of parameter <paramref name="arg20" />.</typeparam>
    /// <param name="arg20">Parameter #20 of the function.</param>
    /// <typeparam name="T21">Type of parameter <paramref name="arg21" />.</typeparam>
    /// <param name="arg21">Parameter #21 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18, T19 arg19, T20 arg20, T21 arg21);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <typeparam name="T18">Type of parameter <paramref name="arg18" />.</typeparam>
    /// <param name="arg18">Parameter #18 of the function.</param>
    /// <typeparam name="T19">Type of parameter <paramref name="arg19" />.</typeparam>
    /// <param name="arg19">Parameter #19 of the function.</param>
    /// <typeparam name="T20">Type of parameter <paramref name="arg20" />.</typeparam>
    /// <param name="arg20">Parameter #20 of the function.</param>
    /// <typeparam name="T21">Type of parameter <paramref name="arg21" />.</typeparam>
    /// <param name="arg21">Parameter #21 of the function.</param>
    /// <typeparam name="T22">Type of parameter <paramref name="arg22" />.</typeparam>
    /// <param name="arg22">Parameter #22 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18, T19 arg19, T20 arg20, T21 arg21, T22 arg22);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <typeparam name="T18">Type of parameter <paramref name="arg18" />.</typeparam>
    /// <param name="arg18">Parameter #18 of the function.</param>
    /// <typeparam name="T19">Type of parameter <paramref name="arg19" />.</typeparam>
    /// <param name="arg19">Parameter #19 of the function.</param>
    /// <typeparam name="T20">Type of parameter <paramref name="arg20" />.</typeparam>
    /// <param name="arg20">Parameter #20 of the function.</param>
    /// <typeparam name="T21">Type of parameter <paramref name="arg21" />.</typeparam>
    /// <param name="arg21">Parameter #21 of the function.</param>
    /// <typeparam name="T22">Type of parameter <paramref name="arg22" />.</typeparam>
    /// <param name="arg22">Parameter #22 of the function.</param>
    /// <typeparam name="T23">Type of parameter <paramref name="arg23" />.</typeparam>
    /// <param name="arg23">Parameter #23 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18, T19 arg19, T20 arg20, T21 arg21, T22 arg22, T23 arg23);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <typeparam name="T18">Type of parameter <paramref name="arg18" />.</typeparam>
    /// <param name="arg18">Parameter #18 of the function.</param>
    /// <typeparam name="T19">Type of parameter <paramref name="arg19" />.</typeparam>
    /// <param name="arg19">Parameter #19 of the function.</param>
    /// <typeparam name="T20">Type of parameter <paramref name="arg20" />.</typeparam>
    /// <param name="arg20">Parameter #20 of the function.</param>
    /// <typeparam name="T21">Type of parameter <paramref name="arg21" />.</typeparam>
    /// <param name="arg21">Parameter #21 of the function.</param>
    /// <typeparam name="T22">Type of parameter <paramref name="arg22" />.</typeparam>
    /// <param name="arg22">Parameter #22 of the function.</param>
    /// <typeparam name="T23">Type of parameter <paramref name="arg23" />.</typeparam>
    /// <param name="arg23">Parameter #23 of the function.</param>
    /// <typeparam name="T24">Type of parameter <paramref name="arg24" />.</typeparam>
    /// <param name="arg24">Parameter #24 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18, T19 arg19, T20 arg20, T21 arg21, T22 arg22, T23 arg23, T24 arg24);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <typeparam name="T18">Type of parameter <paramref name="arg18" />.</typeparam>
    /// <param name="arg18">Parameter #18 of the function.</param>
    /// <typeparam name="T19">Type of parameter <paramref name="arg19" />.</typeparam>
    /// <param name="arg19">Parameter #19 of the function.</param>
    /// <typeparam name="T20">Type of parameter <paramref name="arg20" />.</typeparam>
    /// <param name="arg20">Parameter #20 of the function.</param>
    /// <typeparam name="T21">Type of parameter <paramref name="arg21" />.</typeparam>
    /// <param name="arg21">Parameter #21 of the function.</param>
    /// <typeparam name="T22">Type of parameter <paramref name="arg22" />.</typeparam>
    /// <param name="arg22">Parameter #22 of the function.</param>
    /// <typeparam name="T23">Type of parameter <paramref name="arg23" />.</typeparam>
    /// <param name="arg23">Parameter #23 of the function.</param>
    /// <typeparam name="T24">Type of parameter <paramref name="arg24" />.</typeparam>
    /// <param name="arg24">Parameter #24 of the function.</param>
    /// <typeparam name="T25">Type of parameter <paramref name="arg25" />.</typeparam>
    /// <param name="arg25">Parameter #25 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18, T19 arg19, T20 arg20, T21 arg21, T22 arg22, T23 arg23, T24 arg24, T25 arg25);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <typeparam name="T18">Type of parameter <paramref name="arg18" />.</typeparam>
    /// <param name="arg18">Parameter #18 of the function.</param>
    /// <typeparam name="T19">Type of parameter <paramref name="arg19" />.</typeparam>
    /// <param name="arg19">Parameter #19 of the function.</param>
    /// <typeparam name="T20">Type of parameter <paramref name="arg20" />.</typeparam>
    /// <param name="arg20">Parameter #20 of the function.</param>
    /// <typeparam name="T21">Type of parameter <paramref name="arg21" />.</typeparam>
    /// <param name="arg21">Parameter #21 of the function.</param>
    /// <typeparam name="T22">Type of parameter <paramref name="arg22" />.</typeparam>
    /// <param name="arg22">Parameter #22 of the function.</param>
    /// <typeparam name="T23">Type of parameter <paramref name="arg23" />.</typeparam>
    /// <param name="arg23">Parameter #23 of the function.</param>
    /// <typeparam name="T24">Type of parameter <paramref name="arg24" />.</typeparam>
    /// <param name="arg24">Parameter #24 of the function.</param>
    /// <typeparam name="T25">Type of parameter <paramref name="arg25" />.</typeparam>
    /// <param name="arg25">Parameter #25 of the function.</param>
    /// <typeparam name="T26">Type of parameter <paramref name="arg26" />.</typeparam>
    /// <param name="arg26">Parameter #26 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18, T19 arg19, T20 arg20, T21 arg21, T22 arg22, T23 arg23, T24 arg24, T25 arg25, T26 arg26);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <typeparam name="T18">Type of parameter <paramref name="arg18" />.</typeparam>
    /// <param name="arg18">Parameter #18 of the function.</param>
    /// <typeparam name="T19">Type of parameter <paramref name="arg19" />.</typeparam>
    /// <param name="arg19">Parameter #19 of the function.</param>
    /// <typeparam name="T20">Type of parameter <paramref name="arg20" />.</typeparam>
    /// <param name="arg20">Parameter #20 of the function.</param>
    /// <typeparam name="T21">Type of parameter <paramref name="arg21" />.</typeparam>
    /// <param name="arg21">Parameter #21 of the function.</param>
    /// <typeparam name="T22">Type of parameter <paramref name="arg22" />.</typeparam>
    /// <param name="arg22">Parameter #22 of the function.</param>
    /// <typeparam name="T23">Type of parameter <paramref name="arg23" />.</typeparam>
    /// <param name="arg23">Parameter #23 of the function.</param>
    /// <typeparam name="T24">Type of parameter <paramref name="arg24" />.</typeparam>
    /// <param name="arg24">Parameter #24 of the function.</param>
    /// <typeparam name="T25">Type of parameter <paramref name="arg25" />.</typeparam>
    /// <param name="arg25">Parameter #25 of the function.</param>
    /// <typeparam name="T26">Type of parameter <paramref name="arg26" />.</typeparam>
    /// <param name="arg26">Parameter #26 of the function.</param>
    /// <typeparam name="T27">Type of parameter <paramref name="arg27" />.</typeparam>
    /// <param name="arg27">Parameter #27 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18, T19 arg19, T20 arg20, T21 arg21, T22 arg22, T23 arg23, T24 arg24, T25 arg25, T26 arg26, T27 arg27);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <typeparam name="T18">Type of parameter <paramref name="arg18" />.</typeparam>
    /// <param name="arg18">Parameter #18 of the function.</param>
    /// <typeparam name="T19">Type of parameter <paramref name="arg19" />.</typeparam>
    /// <param name="arg19">Parameter #19 of the function.</param>
    /// <typeparam name="T20">Type of parameter <paramref name="arg20" />.</typeparam>
    /// <param name="arg20">Parameter #20 of the function.</param>
    /// <typeparam name="T21">Type of parameter <paramref name="arg21" />.</typeparam>
    /// <param name="arg21">Parameter #21 of the function.</param>
    /// <typeparam name="T22">Type of parameter <paramref name="arg22" />.</typeparam>
    /// <param name="arg22">Parameter #22 of the function.</param>
    /// <typeparam name="T23">Type of parameter <paramref name="arg23" />.</typeparam>
    /// <param name="arg23">Parameter #23 of the function.</param>
    /// <typeparam name="T24">Type of parameter <paramref name="arg24" />.</typeparam>
    /// <param name="arg24">Parameter #24 of the function.</param>
    /// <typeparam name="T25">Type of parameter <paramref name="arg25" />.</typeparam>
    /// <param name="arg25">Parameter #25 of the function.</param>
    /// <typeparam name="T26">Type of parameter <paramref name="arg26" />.</typeparam>
    /// <param name="arg26">Parameter #26 of the function.</param>
    /// <typeparam name="T27">Type of parameter <paramref name="arg27" />.</typeparam>
    /// <param name="arg27">Parameter #27 of the function.</param>
    /// <typeparam name="T28">Type of parameter <paramref name="arg28" />.</typeparam>
    /// <param name="arg28">Parameter #28 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18, T19 arg19, T20 arg20, T21 arg21, T22 arg22, T23 arg23, T24 arg24, T25 arg25, T26 arg26, T27 arg27, T28 arg28);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <typeparam name="T18">Type of parameter <paramref name="arg18" />.</typeparam>
    /// <param name="arg18">Parameter #18 of the function.</param>
    /// <typeparam name="T19">Type of parameter <paramref name="arg19" />.</typeparam>
    /// <param name="arg19">Parameter #19 of the function.</param>
    /// <typeparam name="T20">Type of parameter <paramref name="arg20" />.</typeparam>
    /// <param name="arg20">Parameter #20 of the function.</param>
    /// <typeparam name="T21">Type of parameter <paramref name="arg21" />.</typeparam>
    /// <param name="arg21">Parameter #21 of the function.</param>
    /// <typeparam name="T22">Type of parameter <paramref name="arg22" />.</typeparam>
    /// <param name="arg22">Parameter #22 of the function.</param>
    /// <typeparam name="T23">Type of parameter <paramref name="arg23" />.</typeparam>
    /// <param name="arg23">Parameter #23 of the function.</param>
    /// <typeparam name="T24">Type of parameter <paramref name="arg24" />.</typeparam>
    /// <param name="arg24">Parameter #24 of the function.</param>
    /// <typeparam name="T25">Type of parameter <paramref name="arg25" />.</typeparam>
    /// <param name="arg25">Parameter #25 of the function.</param>
    /// <typeparam name="T26">Type of parameter <paramref name="arg26" />.</typeparam>
    /// <param name="arg26">Parameter #26 of the function.</param>
    /// <typeparam name="T27">Type of parameter <paramref name="arg27" />.</typeparam>
    /// <param name="arg27">Parameter #27 of the function.</param>
    /// <typeparam name="T28">Type of parameter <paramref name="arg28" />.</typeparam>
    /// <param name="arg28">Parameter #28 of the function.</param>
    /// <typeparam name="T29">Type of parameter <paramref name="arg29" />.</typeparam>
    /// <param name="arg29">Parameter #29 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18, T19 arg19, T20 arg20, T21 arg21, T22 arg22, T23 arg23, T24 arg24, T25 arg25, T26 arg26, T27 arg27, T28 arg28, T29 arg29);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <typeparam name="T18">Type of parameter <paramref name="arg18" />.</typeparam>
    /// <param name="arg18">Parameter #18 of the function.</param>
    /// <typeparam name="T19">Type of parameter <paramref name="arg19" />.</typeparam>
    /// <param name="arg19">Parameter #19 of the function.</param>
    /// <typeparam name="T20">Type of parameter <paramref name="arg20" />.</typeparam>
    /// <param name="arg20">Parameter #20 of the function.</param>
    /// <typeparam name="T21">Type of parameter <paramref name="arg21" />.</typeparam>
    /// <param name="arg21">Parameter #21 of the function.</param>
    /// <typeparam name="T22">Type of parameter <paramref name="arg22" />.</typeparam>
    /// <param name="arg22">Parameter #22 of the function.</param>
    /// <typeparam name="T23">Type of parameter <paramref name="arg23" />.</typeparam>
    /// <param name="arg23">Parameter #23 of the function.</param>
    /// <typeparam name="T24">Type of parameter <paramref name="arg24" />.</typeparam>
    /// <param name="arg24">Parameter #24 of the function.</param>
    /// <typeparam name="T25">Type of parameter <paramref name="arg25" />.</typeparam>
    /// <param name="arg25">Parameter #25 of the function.</param>
    /// <typeparam name="T26">Type of parameter <paramref name="arg26" />.</typeparam>
    /// <param name="arg26">Parameter #26 of the function.</param>
    /// <typeparam name="T27">Type of parameter <paramref name="arg27" />.</typeparam>
    /// <param name="arg27">Parameter #27 of the function.</param>
    /// <typeparam name="T28">Type of parameter <paramref name="arg28" />.</typeparam>
    /// <param name="arg28">Parameter #28 of the function.</param>
    /// <typeparam name="T29">Type of parameter <paramref name="arg29" />.</typeparam>
    /// <param name="arg29">Parameter #29 of the function.</param>
    /// <typeparam name="T30">Type of parameter <paramref name="arg30" />.</typeparam>
    /// <param name="arg30">Parameter #30 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18, T19 arg19, T20 arg20, T21 arg21, T22 arg22, T23 arg23, T24 arg24, T25 arg25, T26 arg26, T27 arg27, T28 arg28, T29 arg29, T30 arg30);

    /// <summary>
    /// Parameterized delegate.
    /// </summary>
    /// <typeparam name="T0">Return type of query <paramref name="arg0" />.</typeparam>
    /// <typeparam name="TResult">Return type of the function.</typeparam>
    /// <param name="arg0">Parameter #0 of the function.</param>
    /// <typeparam name="T1">Type of parameter <paramref name="arg1" />.</typeparam>
    /// <param name="arg1">Parameter #1 of the function.</param>
    /// <typeparam name="T2">Type of parameter <paramref name="arg2" />.</typeparam>
    /// <param name="arg2">Parameter #2 of the function.</param>
    /// <typeparam name="T3">Type of parameter <paramref name="arg3" />.</typeparam>
    /// <param name="arg3">Parameter #3 of the function.</param>
    /// <typeparam name="T4">Type of parameter <paramref name="arg4" />.</typeparam>
    /// <param name="arg4">Parameter #4 of the function.</param>
    /// <typeparam name="T5">Type of parameter <paramref name="arg5" />.</typeparam>
    /// <param name="arg5">Parameter #5 of the function.</param>
    /// <typeparam name="T6">Type of parameter <paramref name="arg6" />.</typeparam>
    /// <param name="arg6">Parameter #6 of the function.</param>
    /// <typeparam name="T7">Type of parameter <paramref name="arg7" />.</typeparam>
    /// <param name="arg7">Parameter #7 of the function.</param>
    /// <typeparam name="T8">Type of parameter <paramref name="arg8" />.</typeparam>
    /// <param name="arg8">Parameter #8 of the function.</param>
    /// <typeparam name="T9">Type of parameter <paramref name="arg9" />.</typeparam>
    /// <param name="arg9">Parameter #9 of the function.</param>
    /// <typeparam name="T10">Type of parameter <paramref name="arg10" />.</typeparam>
    /// <param name="arg10">Parameter #10 of the function.</param>
    /// <typeparam name="T11">Type of parameter <paramref name="arg11" />.</typeparam>
    /// <param name="arg11">Parameter #11 of the function.</param>
    /// <typeparam name="T12">Type of parameter <paramref name="arg12" />.</typeparam>
    /// <param name="arg12">Parameter #12 of the function.</param>
    /// <typeparam name="T13">Type of parameter <paramref name="arg13" />.</typeparam>
    /// <param name="arg13">Parameter #13 of the function.</param>
    /// <typeparam name="T14">Type of parameter <paramref name="arg14" />.</typeparam>
    /// <param name="arg14">Parameter #14 of the function.</param>
    /// <typeparam name="T15">Type of parameter <paramref name="arg15" />.</typeparam>
    /// <param name="arg15">Parameter #15 of the function.</param>
    /// <typeparam name="T16">Type of parameter <paramref name="arg16" />.</typeparam>
    /// <param name="arg16">Parameter #16 of the function.</param>
    /// <typeparam name="T17">Type of parameter <paramref name="arg17" />.</typeparam>
    /// <param name="arg17">Parameter #17 of the function.</param>
    /// <typeparam name="T18">Type of parameter <paramref name="arg18" />.</typeparam>
    /// <param name="arg18">Parameter #18 of the function.</param>
    /// <typeparam name="T19">Type of parameter <paramref name="arg19" />.</typeparam>
    /// <param name="arg19">Parameter #19 of the function.</param>
    /// <typeparam name="T20">Type of parameter <paramref name="arg20" />.</typeparam>
    /// <param name="arg20">Parameter #20 of the function.</param>
    /// <typeparam name="T21">Type of parameter <paramref name="arg21" />.</typeparam>
    /// <param name="arg21">Parameter #21 of the function.</param>
    /// <typeparam name="T22">Type of parameter <paramref name="arg22" />.</typeparam>
    /// <param name="arg22">Parameter #22 of the function.</param>
    /// <typeparam name="T23">Type of parameter <paramref name="arg23" />.</typeparam>
    /// <param name="arg23">Parameter #23 of the function.</param>
    /// <typeparam name="T24">Type of parameter <paramref name="arg24" />.</typeparam>
    /// <param name="arg24">Parameter #24 of the function.</param>
    /// <typeparam name="T25">Type of parameter <paramref name="arg25" />.</typeparam>
    /// <param name="arg25">Parameter #25 of the function.</param>
    /// <typeparam name="T26">Type of parameter <paramref name="arg26" />.</typeparam>
    /// <param name="arg26">Parameter #26 of the function.</param>
    /// <typeparam name="T27">Type of parameter <paramref name="arg27" />.</typeparam>
    /// <param name="arg27">Parameter #27 of the function.</param>
    /// <typeparam name="T28">Type of parameter <paramref name="arg28" />.</typeparam>
    /// <param name="arg28">Parameter #28 of the function.</param>
    /// <typeparam name="T29">Type of parameter <paramref name="arg29" />.</typeparam>
    /// <param name="arg29">Parameter #29 of the function.</param>
    /// <typeparam name="T30">Type of parameter <paramref name="arg30" />.</typeparam>
    /// <param name="arg30">Parameter #30 of the function.</param>
    /// <typeparam name="T31">Type of parameter <paramref name="arg31" />.</typeparam>
    /// <param name="arg31">Parameter #31 of the function.</param>
    /// <returns>A value constructed from the various subqueries.</returns>
	public delegate TResult Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, TResult>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18, T19 arg19, T20 arg20, T21 arg21, T22 arg22, T23 arg23, T24 arg24, T25 arg25, T26 arg26, T27 arg27, T28 arg28, T29 arg29, T30 arg30, T31 arg31);
}