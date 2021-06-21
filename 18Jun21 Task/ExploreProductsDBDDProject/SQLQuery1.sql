use AdventureWorks2019

select * from Production.Product

select * from Production.ProductCategory

select * from Production.ProductSubcategory

select * from Production.ProductDescription

select * from Production.ProductModel

select p.ProductID,p.Name ProductName,psc.Name SubCategory,pc.Name Category from Production.Product p join Production.ProductSubcategory psc 
on p.ProductSubcategoryID=psc.ProductSubcategoryID join Production.ProductCategory pc on 
pc.ProductCategoryID=psc.ProductCategoryID
where pc.ProductCategoryID = 1