using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Compose;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ComposeTests
{
    static class Program
    {
        static void Main(string[] args)
        {
            var db = new SqlConnection(@"Data Source=.\SA;Initial Catalog=NORTHWND;Integrated Security=True");
            db.Open();
            StandardTests(db);
            EmbeddedQueryTests(db);

            var test = Query.Load<Employee>($"{nameof(ComposeTests)}.Queries.test.sql");
            Debug.Assert(test == @"INSERT INTO [WS].[ProductChannelProperty] (
ProductIntegrationKey,
ChannelIntegrationKey
VALUES(
@productintegrationkey,
@channelintegrationkey
)
");

            foreach (var x in Query.Validate(db, typeof(Program)))
            {
                Console.Error.WriteLine(x);
                Console.Error.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }

        static void StandardTests(IDbConnection db)
        {
            getEmployeeAndOrders = Query.Combine(getEmployee, getEmployeeOrders, (e, o) => new EmployeeOrders { Employee = e, Orders = o });
            TestPlainDapper(db);
            TestCombinedQueries(db);

            var t0 = TestPlainDapperAsync(db);
            t0.Wait();
            var t1 = TestCombinedQueriesAsync(db);
            t1.Wait();
        }

        // an example of reified queries and their composition
        [QueryParam("employeeId", 3)]
        static Query<Employee> getEmployee = Query.Single<Employee>(@"select FirstName, EmployeeID, LastName from Employees where EmployeeId = @employeeID");
        [QueryParam(nameof(Employee.EmployeeID), 3)]
        static Query<List<Order>> getEmployeeOrders = Query.List<Order>(@"select ROW_NUMBER() over (order by OrderID) as Row, OrderID, OrderDate, EmployeeID from Orders where EmployeeId = @employeeID");
        [QueryParam(nameof(Order.EmployeeID), 3)]
        static Query<EmployeeOrders> getEmployeeAndOrders;
        
        // dummy static members
        static int foo;
        [QueryParam("dummy", "dummy")]
        static string dummy;

        static void TestCount<T>(IDbConnection db, Query<List<T>> query, object param, int expectedCount)
        {
            var count = query.Count().Execute(db, param);
            Debug.Assert(count == expectedCount);
        }

        static void TestPaged<T>(IDbConnection db, Query<List<T>> query, object param, int expectedCount)
        {
            var results = query.Paged().Execute(db, param);
            Debug.Assert(results.Count == expectedCount);
        }

        static void TestPlainDapper(IDbConnection db)
        {
            var janet = getEmployee.Execute(db, new { employeeId = 3 });
            var janetsOrders = getEmployeeOrders.Execute(db, new { employeeId = 3 });
            CheckResults(janet, janetsOrders);
            TestCount(db, getEmployeeOrders, new { employeeId = 3 }, 127);
            TestPaged(db, getEmployeeOrders, new { employeeId = 3, page = 2, pageSize = 50 }, 50);
        }

        static void TestCombinedQueries(IDbConnection db)
        {
            var janet = getEmployeeAndOrders.Execute(db, new { employeeId = 3 });
            CheckResults(janet.Employee, janet.Orders);
        }

        static async Task TestCountAsync<T>(IDbConnection db, Query<List<T>> query, object param, int expectedCount)
        {
            var count = await query.Count().ExecuteAsync(db, param);
            Debug.Assert(count == expectedCount);
        }

        static async Task TestPagedAsync<T>(IDbConnection db, Query<List<T>> query, object param, int expectedCount)
        {
            var results = await query.Paged().ExecuteAsync(db, param);
            Debug.Assert(results.Count == expectedCount);
        }

        static async Task TestPlainDapperAsync(IDbConnection db)
        {
            var janet = await getEmployee.ExecuteAsync(db, new { employeeId = 3 });
            var janetsOrders = await getEmployeeOrders.ExecuteAsync(db, new { employeeId = 3 });
            CheckResults(janet, janetsOrders);
            await TestCountAsync(db, getEmployeeOrders, new { employeeId = 3 }, 127);
            await TestPagedAsync(db, getEmployeeOrders, new { employeeId = 3, page = 2, pageSize = 50 }, 50);
        }

        static async Task TestCombinedQueriesAsync(IDbConnection db)
        {
            var janet = await getEmployeeAndOrders.ExecuteAsync(db, new { employeeId = 3 });
            CheckResults(janet.Employee, janet.Orders);
        }

        static void EmbeddedQueryTests(IDbConnection db)
        {
            foreach (var sql in Query.GetRunnable(typeof(Employee)))
            {
                if (!sql.Key.Contains("Invalid"))
                    CheckJanet(db.QuerySingle<Employee>(sql.Value));
            }
            getEmployee = Query.Single<Employee>(Query.Load<Employee>($"{nameof(ComposeTests)}.Queries.GetEmployee.sql"));
            getEmployeeOrders = Query.List<Order>(Query.Load<EmployeeOrders>($"{nameof(ComposeTests)}.Queries.GetEmployeeOrders.sql"));
            StandardTests(db);

            var getEmployeeInvalid = Query.Single<Employee>(Query.Load<Employee>($"{nameof(ComposeTests)}.Queries.GetEmployeeInvalid.sql"));

            try
            {
                var err = getEmployeeInvalid.Execute(db);
            }
            catch
            {
                return;
            }
            Debug.Assert(false);
        }

        static void CheckResults(Employee janet, IEnumerable<Order> orders)
        {
            CheckJanet(janet);
            Debug.Assert(orders.Count() == 127);
        }

        static void CheckJanet(Employee janet)
        {
            Debug.Assert(janet.FirstName == "Janet");
            Debug.Assert(janet.LastName == "Leverling");
        }

        public class EmployeeOrders
        {
            public Employee Employee { get; set; }
            public List<Order> Orders { get; set; }
        }

        public class Employee
        {
            public int EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Order
        {
            public int OrderID { get; set; }
            public DateTime? OrderDate { get; set; }
            public int EmployeeID { get; set; }
        }
    }
}
