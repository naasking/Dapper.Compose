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
        public static Query<TResult> Combine<T0, T1, TResult>(Query<T0> q0, Query<T1> q1, Func<T0, T1, TResult> selector)
        {
            return new Query<TResult>(
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
        public static Query<TResult> Combine<T0, T1, T2, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Func<T0, T1, T2, TResult> selector)
        {
            return new Query<TResult>(
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
        public static Query<TResult> Combine<T0, T1, T2, T3, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Func<T0, T1, T2, T3, TResult> selector)
        {
            return new Query<TResult>(
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
        public static Query<TResult> Combine<T0, T1, T2, T3, T4, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Func<T0, T1, T2, T3, T4, TResult> selector)
        {
            return new Query<TResult>(
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
        public static Query<TResult> Combine<T0, T1, T2, T3, T4, T5, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Func<T0, T1, T2, T3, T4, T5, TResult> selector)
        {
            return new Query<TResult>(
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
        public static Query<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Func<T0, T1, T2, T3, T4, T5, T6, TResult> selector)
        {
            return new Query<TResult>(
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
        public static Query<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> selector)
        {
            return new Query<TResult>(
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
        public static Query<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> selector)
        {
            return new Query<TResult>(
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
        public static Query<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> selector)
        {
            return new Query<TResult>(
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
        public static Query<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> selector)
        {
            return new Query<TResult>(
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
        public static Query<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> selector)
        {
            return new Query<TResult>(
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
        public static Query<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> selector)
        {
            return new Query<TResult>(
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
        public static Query<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> selector)
        {
            return new Query<TResult>(
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
        public static Query<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> selector)
        {
            return new Query<TResult>(
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
        public static Query<TResult> Combine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Query<T0> q0, Query<T1> q1, Query<T2> q2, Query<T3> q3, Query<T4> q4, Query<T5> q5, Query<T6> q6, Query<T7> q7, Query<T8> q8, Query<T9> q9, Query<T10> q10, Query<T11> q11, Query<T12> q12, Query<T13> q13, Query<T14> q14, Query<T15> q15, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> selector)
        {
            return new Query<TResult>(
				x => selector(q0.Read(x), q1.Read(x), q2.Read(x), q3.Read(x), q4.Read(x), q5.Read(x), q6.Read(x), q7.Read(x), q8.Read(x), q9.Read(x), q10.Read(x), q11.Read(x), q12.Read(x), q13.Read(x), q14.Read(x), q15.Read(x)),
				async x => selector(await q0.ReadAsync(x), await q1.ReadAsync(x), await q2.ReadAsync(x), await q3.ReadAsync(x), await q4.ReadAsync(x), await q5.ReadAsync(x), await q6.ReadAsync(x), await q7.ReadAsync(x), await q8.ReadAsync(x), await q9.ReadAsync(x), await q10.ReadAsync(x), await q11.ReadAsync(x), await q12.ReadAsync(x), await q13.ReadAsync(x), await q14.ReadAsync(x), await q15.ReadAsync(x)),
				q0.Sql  + "\r\n" + q1.Sql + "\r\n" + q2.Sql + "\r\n" + q3.Sql + "\r\n" + q4.Sql + "\r\n" + q5.Sql + "\r\n" + q6.Sql + "\r\n" + q7.Sql + "\r\n" + q8.Sql + "\r\n" + q9.Sql + "\r\n" + q10.Sql + "\r\n" + q11.Sql + "\r\n" + q12.Sql + "\r\n" + q13.Sql + "\r\n" + q14.Sql + "\r\n" + q15.Sql);
        }

	}
}