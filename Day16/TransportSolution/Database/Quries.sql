create database dbSoftTransport

use dbSoftTransport

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