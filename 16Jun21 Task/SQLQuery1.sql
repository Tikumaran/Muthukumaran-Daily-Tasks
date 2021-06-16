create database dbMovies

use dbMovies

create table tbl_movies(
 Movie_Id int Identity(1,1),
 Movie_Name varchar(20),
 Constraint Pk_MID Primary Key(Movie_Id)
)
select * from tbl_movies