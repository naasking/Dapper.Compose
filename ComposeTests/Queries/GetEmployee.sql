-- Get an employee
USE NORTHWND

declare @employeeId int = 3

-- Dapper.Compose.Query

select EmployeeID, FirstName, LastName from Employees where EmployeeId = @employeeID