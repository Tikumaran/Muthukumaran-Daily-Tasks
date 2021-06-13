create database BooksDb

use BooksDb

create table tbl_author(
AuthorID int identity(1,1),
AuthorName varchar(20),
constraint PK_auth Primary Key (AuthorID))

create table tbl_books
(
BookID int identity(1,1),
Title varchar(50),
AuthorID int,
Price money,
constraint PK_book Primary key (BookID),
constraint FK_auth Foreign key(AuthorID) 
references tbl_author(AuthorID)
)

--Store Procedure

--1.Insert Book---

create proc sp_InsertBook
@Title varchar(20),
@AuthorID int,
@Price money
as
Begin
insert into tbl_Books(Title,AuthorID,Price)
values(@Title,@AuthorID,@Price)
End

--2. Update Book--

create proc sp_UpdateBook
@BookID int,
@Price money
as
Begin
update tbl_Books set Price=@Price where BookID=@BookID
End

--3. Delete Book--

create proc sp_DeleteBook
@BookID int
as
Begin
delete from tbl_Books where BookID=@BookID
End

--4. Insert Author--

create proc sp_InsertAuthor
@AuthorName varchar(20)
as
Begin
insert into tbl_author(AuthorName)
values(@AuthorName)
End

--5. Update Author--

create proc sp_UpdateAuthor
@AuthorID int,
@AuthorName varchar(20)
as
Begin
update tbl_author set AuthorName=@AuthorName where AuthorID=@AuthorID
End

--6. Delete Author--

create proc sp_DeleteAuthor
@AuthorID int
as
Begin
delete from tbl_author where AuthorID=@AuthorID
End

--SP Testing--

select * from tbl_Books

select *from tbl_author

--1.--
exec sp_InsertBook 'Origin',7,150

--2.--
exec  sp_UpdateBook 11,200

--3.--
exec  sp_DeleteBook 11

--4.--
exec sp_InsertAuthor 'Jayakanthan'

--5.--
exec  sp_UpdateAuthor 8,'Jayakanthan.JK'

--6.--
exec  sp_DeleteAuthor 1008