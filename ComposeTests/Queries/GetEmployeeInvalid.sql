-- Get an employee
USE NORTHWND

declare @employeeId int = 3

-- Dapper.Compose.Query

select EmployeeID, FirstNames, LastName from Employees where EmployeeId = @employeeID