use pubs

select * from authors

create table tblMovie (id int identity(1,1) primary key,name varchar(10) not null,duration float)

select * from tblMovie

insert into tblMovie(name,duration)values('Master',20.3)