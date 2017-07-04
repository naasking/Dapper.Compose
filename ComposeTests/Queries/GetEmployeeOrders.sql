-- test query, no header
select ROW_NUMBER() over (order by OrderID) as Row, OrderID, OrderDate, EmployeeID
from Orders
where EmployeeId = @employeeID