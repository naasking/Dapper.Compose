# Dapper.Compose

Dapper is a great tool, but it carries an implicit limitation of stringly queries:
we have to write lots of small, easily testable queries so we can validate them
against the database. This unfortunately ends up incurring many round trips,
because there's no straightforward way to combine small queries into larger queries.

This is the purpose of Dapper.Compose. Suppose we start with the Northwind
database, and we want a simple dynamic web page listing the orders an employee
is managing. Using Dapper.Compose, we might write it like so:

	public static class Queries
	{
		// individual query to obtain an employee
		public static readonly Query<Employee> GetEmployeeById = Query.Single<Employee>(
			@"select EmployeeID, FirstName, LastName from Employees where EmployeeId = @employeeID");

		// get the list of orders an employee is managing
		public static readonly Query<List<Order>> GetOrdersByEmployeeId = Query.List<Order>(
			"select OrderID, OrderDate, EmployeeID from Orders where EmployeeId = @employeeID");

		// the combined query
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

The only caveat is that you still have to ensure you're using the correct
parameter names, but this is no worse than ordinary Dapper.

This provides a simple framework to incrementally build up your application,
where you can easily reuse queries while minimizing database rountrips.

# Future Work

 * Associations aren't supported -- this one might be tricky!
 * Automatic testing: Query constructors could accept a parameter name and a
   sample value. Writing an automatic query validation tool then becomes
   trivial, as we just iterate over all instances in an assembly and call
   Execute with the sample parameters.