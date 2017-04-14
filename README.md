# Dapper.Compose

Dapper is neat, but it carries an implicit limitation of stringly queries. This
encourages a writing lots of small, easily testable queries, but which ultimately
incur many round trips to the database.

If it were instead possible to reify Dapper queries as first class values, and
it were relatively safe to combine them without too much boilerplate, then it
becomes possible to write small, testable queries and compose them into larger
more efficient queries.

This is the purpose of my current prototype of Dapper.Compose. Suppose we start
with the Northwind database, and we want a simple dynamic web page listing the
orders an employee is managing. Using Dapper.Compose, we might write it like so:

	public static class Queries
	{
		// individual query to obtain an employee
		public static readonly Query<Employee> GetEmployeeById = Query.Single<Employee>(
			@"select EmployeeID, FirstName, LastName from Employees where EmployeeId = @employeeID");

		// get the list of orders an employee is managing
        public static readonly Query<IEnumerable<Order>> GetOrdersByEmployeeId = Query.List<Order>(
			"select OrderID, OrderDate, EmployeeID from Orders where EmployeeId = @employeeID");

		// 
        public static readonly Query<EmployeeOrders> GetEmployeeOrdersByEmployeeId =
			Query.Combine(GetEmployeeById, GetOrdersByEmployeeId,
						 (e, o) => new EmployeeOrders { Employee = e, Orders = o.ToList() });
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
	
	public class EmployeeOrders
    {
        public Employee Employee { get; set; }
        public List<Order> Orders { get; set; }
    }

So the queries are still individually usable, but are easily combined into
larger queries that still only perform a single round trip to the database. On
our dynamic web page, our model would be EmployeeOrders which we would obtain
like so:

    var results = Queries.GetEmployeeOrdersByEmployeeId.Execute(
		dbConnection, new { employeeId = ... });

# Future Work

 * async queries -- this will probably require a QueryAsync<T>
 * associations aren't supported -- this one might be tricky!