create database dbSoftTransport

use dbSoftTransport--AA12DD0000create table tblEmployee(Id int identity(101,1) primary key,Name varchar(20) not null,Password varchar(20) not null,Location varchar(20),Phone varchar(20),Vechicle_Id char(8))create table tblDriver(ID int identity(1000,1) primary key,Name varchar(20),Phone varchar(20),status varchar(50) check(status in ('active','not active')))create table tblVehicle(Vechicle_number char(8) primary key,Type varchar(10),Capacity int,Driver_ID int references tblDriver(id),Filled_Status int ,status varchar(50) check(status in ('running','discard')))alter table tblEmployeeadd constraint fk_VID foreign key(Vechicle_Id) references tblVehicle(Vechicle_number)

alter proc proc_InsertEmployee(@eName varchar(20),
@ePassword varchar(20),
@eLocation varchar(20),
@ePhone varchar(20),
@eVehile char(8))
as
 begin
   Insert Into tblEmployee (Name,Password,Location,Phone,Vechicle_Id) values(@eName,@ePassword,@eLocation,@ePhone,@eVehile)
 end

 alter proc proc_UpdateEmployee(@eid int,
 @ePassword varchar(20))
 as
 begin
  Update tblEmployee set Password=@ePassword where Id=@eid
 end

 create proc proc_UpdateEmployeeDetails(@eid int,
 @eName varchar(20),
 @eLocation varchar(20),
 @ePhone varchar(20))
 as
 begin
  Update tblEmployee set Name=@eName,Location=@eLocation,Phone=@ePhone where Id=@eid
 end


 create proc proc_InsertDriver(@dName varchar(20),
 @dPhone varchar(20),
 @dStatus varchar(50))
 as
  Insert Into tblDriver (Name,Phone,status) values(@dName,@dPhone,@dStatus)

  create proc proc_GetAllEmployees
  as
	select * from tblEmployee

	Insert Into tblEmployee (Name,Password,Location,Phone,Vechicle_Id) values('seethu','1334','MDU','5644454546','TN8A1000')