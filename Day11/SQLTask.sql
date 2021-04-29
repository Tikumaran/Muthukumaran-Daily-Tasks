use pubs

--1) Print the city name and the count of authors from every city

select city,count(au_fname) authors from authors group by city

--2) Print the authors who are not from the city in which the publisher 'New Moon Books' is from.

select au_fname,city from authors where city not in(
select city from publishers where pub_name='New Moon Books')

--3) Create a procudure that will take the author first name and last name and new price 
--The procedure should update the price of the books written by the author with the give name 

alter procedure proc_UpdatePriceforSales(@au_fname varchar(10),@au_lname varchar(10),@newPrice float(10))
as
begin
    update dbo.titles set price=@newPrice where title_id in(
	select title_id from titleauthor where au_id in(
	select au_id from authors where au_fname=@au_fname and au_lname=@au_lname))
end

exec proc_UpdatePriceforSales 'Johnson','White',30.25

/*4) Create a function that will calculate tax for the sale of every book
If quantity <10 tax is 2%
10 -20 tax is 5%
20 - 50 tax is 6%
above 30 tax is 7.5%
The fuction should take quantity and return tax
*/
create function fn_TaxCalculate()
returns @BookSalesTax Table
(
Bookname varchar(15),
 Quentity int,
 Tax float
)
as
begin 
declare
@Quentity int,
@Tax float,
@TaxPay float,
@Bookname varchar(15)
	set @Quentity=(Select qty from sales where title_id in(
					select distinct title_id from titles))
	if(@Quentity <= 10)
		set @Tax = 2
	else if(@Quentity > 10 and @Quentity <= 20)
	    set @Tax = 5
	else if(@Quentity > 20 and @Quentity <= 30)
		set @Tax = 6
	else 
		set @Tax = 7.5
	
	set @TaxPay = @Quentity * @tax /100
	
	insert into @BookSalesTax values(@Bookname,@Quentity,@TaxPay)
	return 
end

Select * from dbo.fn_TaxCalculate()