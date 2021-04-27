select * from publishers

select * from authors

select * from titles

select * from titleauthor

select * from sales

select * from stores

--Q1.Select the author firtname and last name

select au_fname,au_lname from authors

--Q2. Sort the titles by the title name in descending order and print all the details

select distinct title from titles order by title desc  --select * from titles order by title desc

--Q3.Print the number of titles published by every author

select count(title) Num_OF_title from titles group by pub_id

--Q4.print the author name and title name

select au_fname,au_lname,title from authors a Inner join titleauthor ta
on
a.au_id=ta.au_id Inner join titles t
on
t.title_id=ta.title_id

--Q5.print the publisher name and the average advance for every publisher

select pub_name,avg(advance) AVG_advance from publishers p join titles t
on
p.pub_id=t.pub_id
group by pub_name

--Q6.print the publishername, author name, title name and the sale amount(qty*price)

select pub_name,au_fname,au_lname,title,qty*price amount from publishers p Inner Join titles t
on 
p.pub_id=t.pub_id inner join authors a 
on
a.au_id=au_id inner join sales s
on 
s.title_id=t.title_id


