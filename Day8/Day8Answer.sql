create database dbTrainingTask

/*Create the following tables
Employee(id-identity starts in 100 inc by 1,
Name,age, phone9cannot be null, gender)*/

create table tblEmployee (id int identity(100,1) primary key,
Name varchar(20) not null,age int default 18 not null,
phone int not null,gender varchar(6)not null)

/*Salary(id-identity starts at 1 increments by 100,
Basic,HRA,DA,deductions)*/

create table tblSalary(id int identity(1,100) primary key,
Basic float,HRA float,DA float,Deductions float)

/*EmployeeSalary(transaction_number int,
employee_id-reference Employee's Id 
Salary_id reference Salary Id,
Date)
PS - In teh emeployee salary table transaction number is the primary key
the combination of employee_id, salary_id and date should always be unique*/

create table tblEmployee_Salary(transaction_number int primary key,  employee_id int references tblEmployee(id),salary_id  int references tblSalary(id), Date date,constraint unq_empsal UNIQUE (employee_id,salary_id,date))
 --Add a column email-varchar(100) to the employee table
alter table tblEmployee add Email varchar(100)
alter table tblEmployee alter column Email varchar(100) not null
alter table tblEmployee alter column phone varchar(15) not null

--Insert few records in all the tables
--tblEmployee
insert into tblEmployee(Name,age,phone,gender,Email) values('MUTHUKUMARAN',default,9087303575,'Male','tikumaran@gmail.com')
insert into tblEmployee(Name,age,phone,gender,Email) values('ARUNKUMARAN',24,7904357540,'Male','akumaran@gmail.com')
insert into tblEmployee(Name,age,phone,gender,Email) values('KUMARI',45,7962156225,'FeMale','kumari@gmail.com')
insert into tblEmployee(Name,age,phone,gender,Email) values('MUTHU',23,9087304562,'Male','tikumaran@gmail.com')
insert into tblEmployee(Name,age,phone,gender,Email) values('SIVAKUMARAN',19,9087301020,'Male','sivakum@gmail.com')

--tblSalary

insert into tblSalary(Basic,HRA,DA,Deductions)values(25000,12500,10000,2000)
insert into tblSalary(Basic,HRA,DA,Deductions)values(35000,17500,12000,3000)
insert into tblSalary(Basic,HRA,DA,Deductions)values(40000,20000,10000,2000)
insert into tblSalary(Basic,HRA,DA,Deductions)values(25000,12500,10000,2000)
insert into tblSalary(Basic,HRA,DA,Deductions)values(15000,10500,5000,1000)

--tblEmployee_Salary

insert into tblEmployee_Salary(transaction_number,employee_id,salary_id,Date)values(6,102,501,'01-03-2021')
insert into tblEmployee_Salary(transaction_number,employee_id,salary_id,Date)values(11,102,1001,'01-04-2021')
insert into tblEmployee_Salary(transaction_number,employee_id,salary_id,Date)values(7,103,601,'05-02-2021')
insert into tblEmployee_Salary(transaction_number,employee_id,salary_id,Date)values(12,103,1101,'05-03-2021')
insert into tblEmployee_Salary(transaction_number,employee_id,salary_id,Date)values(8,104,701,'04-26-2021')
insert into tblEmployee_Salary(transaction_number,employee_id,salary_id,Date)values(13,104,1201,'05-26-2021')
insert into tblEmployee_Salary(transaction_number,employee_id,salary_id,Date)values(9,105,801,'04-10-2021')
insert into tblEmployee_Salary(transaction_number,employee_id,salary_id,Date)values(14,105,1301,'05-10-2021')
insert into tblEmployee_Salary(transaction_number,employee_id,salary_id,Date)values(10,106,901,'03-20-2021')
insert into tblEmployee_Salary(transaction_number,employee_id,salary_id,Date)values(15,106,1401,'04-20-2021')

select * from tblEmployee
select *from tblSalary
select *from tblEmployee_Salary

/*Create a procedure which will print the total salary of employee by taking the employee id and the date
total = Basic+HRA+DA-deductions*/

alter proc proc_TotalSalaryofEmployee(@emp_id int,@date date)
as
begin
	declare 
	@Total int
	set @Total=(select Basic+HRA+DA-Deductions from tblSalary where id=
	(select salary_id from tblEmployee_Salary where employee_id=@emp_id and Date=@date))
	select @Total Total_Salary
end

exec proc_TotalSalaryofEmployee 102,'2021-01-02'

--Create a procudure which will calculate the average salary of an employee taking his ID

create proc proc_PrintAverageSalary(@eid int)
as
begin
 select avg(Basic+HRA+DA-Deductions) from tblSalary es join tblEmployee_Salary s
 on
 s.salary_id=es.id
 where s.employee_id=@eid
end

exec proc_PrintAverageSalary 102

/*Create a procedure which will catculate tax payable by employee
Slabs as follows
total - 100000 - 0%
100000 > total < 200000 - 5%
200000 > total < 350000 - 6%
total > 350000 - 7.5%*/

create proc proc_CalculateTax(@eid int,@tax float out)
as
begin
declare
@total float,
@taxPayable float
  set @total = (select sum(Basic+HRA+DA-Deductions) from tblEmployee_Salary es join tblSalary s
  on es.salary_id = s.id
  where es.employee_id = @eid )
  if(@total<100000)
	set @tax = 0
  else if(@total>100000 and @total<200000)
    set @tax = 5
  else if(@total>200000 and @total<350000)
    set @tax = 6
  else 
    set @tax = 7.5
  set @taxPayable = @total*@tax/100
  select concat('Total tax ',@taxPayable)
end

declare 
@myTax float
exec proc_CalculateTax 102, @myTax out
print @myTax