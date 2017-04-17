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
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SqlConnection(@"Data Source=.\SA;Initial Catalog=NORTHWND;Integrated Security=True");
            db.Open();
            StandardTests(db);
            EmbeddedQueryTests(db);

            foreach (var x in Query.Validate<Program>(db))
                Console.Error.WriteLine(x);
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
        [QueryParam("employeeId", 3, 4, 5)]
        static Query<Employee> getEmployee = Query.Single<Employee>(@"select EmployeeID, FirstName, LastName from Employees where EmployeeId = @employeeID");
        [QueryParam(nameof(Employee.EmployeeID), 3)]
        static Query<List<Order>> getEmployeeOrders = Query.List<Order>(@"select OrderID, OrderDate, EmployeeID from Orders where EmployeeId = @employeeID");
        [QueryParam(nameof(Order.EmployeeID), 3)]
        static Query<EmployeeOrders> getEmployeeAndOrders;
        
        // dummy static members
        static int foo;
        [QueryParam("dummy", "dummy")]
        static string dummy;

        static void TestPlainDapper(IDbConnection db)
        {
            var janet = getEmployee.Execute(db, new { employeeId = 3 });
            var janetsOrders = getEmployeeOrders.Execute(db, new { employeeId = 3 });
            CheckResults(janet, janetsOrders);
        }

        static void TestCombinedQueries(IDbConnection db)
        {
            var janet = getEmployeeAndOrders.Execute(db, new { employeeId = 3 });
            CheckResults(janet.Employee, janet.Orders);
        }

        static async Task TestPlainDapperAsync(IDbConnection db)
        {
            var janet = await getEmployee.ExecuteAsync(db, new { employeeId = 3 });
            var janetsOrders = await getEmployeeOrders.ExecuteAsync(db, new { employeeId = 3 });
            CheckResults(janet, janetsOrders);
        }

        static async Task TestCombinedQueriesAsync(IDbConnection db)
        {
            var janet = await getEmployeeAndOrders.ExecuteAsync(db, new { employeeId = 3 });
            CheckResults(janet.Employee, janet.Orders);
        }

        static void EmbeddedQueryTests(IDbConnection db)
        {
            foreach (var sql in Query.GetRunnable<Employee>())
            {
                CheckJanet(db.QuerySingle<Employee>(sql.Value));
            }
            getEmployee = Query.Single<Employee>(Query.Load<Employee>($"{nameof(ComposeTests)}.Queries.GetEmployee.sql"));
            getEmployeeOrders = Query.List<Order>(Query.Load<EmployeeOrders>($"{nameof(ComposeTests)}.Queries.GetEmployeeOrders.sql"));
            StandardTests(db);
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
