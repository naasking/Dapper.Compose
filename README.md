# Dapper.Compose

Dapper is a great tool, but it carries an implicit limitation of stringly queries:
we have to write lots of small, easily testable queries so we can validate them
against the database. This unfortunately ends up incurring many round trips,
because there's no straightforward way to safely combine small queries into larger
queries.

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
		public static readonly Query<EmployeeOrders> GetOrdersByEmployeeId =
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

    var results = Queries.GetOrdersByEmployeeId.Execute(
		dbConnection, new { employeeId = ... });

The only caveat is that you still have to ensure you're using the correct
parameter names, but this is no worse than ordinary Dapper.

This provides a simple framework to incrementally build up your application,
where you can easily compose previously written small queries into larger
multiqueries that minimize database rountrips.

# Queries as Embedded Resources

Embedding SQL queries as strings in your assembly is generally terrible for
many reasons. You don't get intellisense, you can't easily test the query
for well-formedness, SQL queries can get somewhat long which ends up
seriously cluttering your code, and so on.

Fortunately, .NET has long had the ability to ship other file types along
with code via embedded resources. So add an .sql file to your project:

    -- in ProjectName/Queries/GetEmployee.sql
    select EmployeeID, FirstName, LastName from Employees where EmployeeId = @employeeID

Then mark it as an embedded resource in the build properties and in
your program call:

	public static class Queries
	{
	    // individual query to obtain an employee
	    public static readonly Query<Employee> GetEmployeeById = Query.Single<Employee>(
	        Query.Load<Employee>("ProjectName.Queries.GetEmployee.sql"));
        ...
    }

While editing an .sql file you get full intellisense and query validation if
you're connected to your database, and long query strings are no longer
cluttering your code.

There's one other convenient feature available for query validation
purposes: you can identify only the section of an .sql containing your
query, and anything before that marker will be ignored:

    -- in ProjectName/Queries/GetEmployee.sql
    -- everything until the comment "-- Dapper.Compose.Query" is ignored by Query.Load
    declare @employeeID int = 3

    -- Dapper.Compose.Query
    select EmployeeID, FirstName, LastName from Employees where EmployeeId = @employeeID

Notice how this SQL query is now a fully runnable query as-is. Query.Load
will ignore anything before the comment "-- Dapper.Compose.Query", but the
prologue that's ignored makes the whole query trivial to test:

    var dbConnection = ...; // open connection
    foreach (var query in Query.GetRunnable<Employee>())
        dbConnection.Execute(query.Value);

Any query with the marker comment is assumed to be runnable, so you can load
them all and run them as-is to check whether they return proper results or
whether they generate any errors indicating a possible schema mismatch.

Shout out to [QueryFirst](https://github.com/bbsimonbb/query-first) for inspiring
this idea. That project will be a promising solution once it develops a
little more.

# Including Updates in a Query

This library primarily deals with queries that return results, but updates don't
actually return results so that makes them difficult to compose like other queries.

For example, suppose you're writing some kind of email front-end that needs to
return the list of unread messages to show some useful links on the toolbar.
However, viewing an individual message should actually mark that message as
read so it's no longer in the list.

Your query to return the list of unread messages might be something like:

	--GetEmailSummaries: return list of unread messages
	USE EmailDB
	declare @userid int = 103

	-- Dapper.Compose.Query
	select N.Id, substring(N.Text, 1, 25) as Summary, N.Version as Date, N.Tag
	from dbo.Emails_To X inner
	join dbo.Emails N ON X.EmailId  = N.Id inner
	join dbo.Users U ON U.EmailAddress = X.Address
	where U.UserId = @userid and X.DateRead is null

For the email viewing page, you'd combine it with an update query like this:

	--MarkEmailRead: mark a note as read
	USE EmailDB
	declare @userId int = 103
	declare @emailId int = 103

	-- Dapper.Compose.Query
	declare @email nvarchar(128) = (select EmailAddress from dbo.Users where UserId=@userId)

	update N
	set N.DateRead = GetDate()
	from dbo.Emails_To N
	where N.EmailId = @emailId and N.Address = @email

	select @@ROWCOUNT

And we might combine them all in code returning a view model for the message
viewing page as follows:

	static readonly Query<ReadEmailViewModel> getReadNote = Query.Combine(
				GetAuthenticatedUserById, MarkEmailRead, GetEmailSummaries, GetEmailById,
				(user, _, unread, current) => new ReadEmailViewModel
				{
					User = user,
					Messages = unread,
					Email = current,
				});

The _ parameter corresponds to the `select @@ROWCOUNT` line in the
MarkEmailRead query, which isn't typically used so it's just discarded.

Here you can see how you can combine sequences of sophisticated queries
so you only need one round-trip to the server.

# Validating Queries in Code

Aside from the above query validation, you can also bind default query
parameter values via attributes. So given a static query class like:

	public static class Queries
	{
	    // individual query to obtain an employee
	    [QueryParam(nameof(Employee.EmployeeID), 3)]
	    public static readonly Query<Employee> GetEmployeeById = Query.Single<Employee>(
	        Query.Load<Employee>("ProjectName.Queries.GetEmployee.sql"));
        ...
    }

You can run all static members of a class bound like this via single call:

    Query.Validate<Queries>(dbConnection);

This is useful for queries that accept types that are awkward to express in
SQL, like arrays.

# Installation

The prerelease version is on nuget and fully functional. Just install with:

    Install-Package Dapper.Compose -pre

# Building

If you want to build and run the tests, note that you'll need the Northwind database
installed. This was the simplest way for me to run some tests, although I plan to
switch to an embedded database at some point. Contributions are welcome!

# Future Work

 * Associations aren't supported -- this one might be tricky!