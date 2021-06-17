use dbmovies

select * from tbl_movies

use AdventureWorks2019

select DepartmentID,Name from HumanResources.Department 
select * from HumanResources.Employee
select * from HumanResources.EmployeeDepartmentHistory
select *from Person.Person
select e.BusinessEntityID,p.FirstName,e.BirthDate,e.MaritalStatus,e.Gender,e.HireDate from HumanResources.EmployeeDepartmentHistory dh join HumanResources.Department d 
on d.DepartmentID=dh.DepartmentID join HumanResources.Employee e on e.BusinessEntityID=dh.BusinessEntityID 
join Person.Person p on p.BusinessEntityID=e.BusinessEntityID
where d.DepartmentID = 2