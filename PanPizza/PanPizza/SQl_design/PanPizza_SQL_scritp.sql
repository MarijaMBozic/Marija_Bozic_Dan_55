IF DB_ID('PanPizzaDB') IS NULL
CREATE DATABASE PanPizzaDB
GO
USE PanPizzaDB;

drop table if exists tblOrder
drop table if exists tblSize
drop table if exists tblIngredients

create table tblSize(
SizeID int identity(1,1) primary key,
Name nvarchar(100) not null
)

create table tblIngredients(
IngredientsId int identity(1,1) primary key,
Name nvarchar(100) not null,
Price money not null
)

create table tblOrder (
OrderID int identity(1,1) primary key,
SizeId int not null,
FOREIGN KEY (SizeId) REFERENCES tblSize(SizeId),
IngredientsId int not null,
FOREIGN KEY (IngredientsId) REFERENCES tblIngredients(IngredientsId),
PhoneNumber bigint
)

Insert into tblSize(Name)
Values('Mala'),
	('Srednja'),
	('Velika')

Insert into tblIngredients(Name, Price)
Values('Salami', 100),
	('Sunka', 120),
	('Kulen', 130),
	('Kecap', 20),
	('Majonez', 30),
	('Ljuta paprika', 50),
	('Masline', 150),
	('Origano', 50),
	('Susam', 60),
	('Sir', 90)


CREATE PROCEDURE Get_AllSize
AS
	select SizeID, Name  from tblSize
GO

CREATE PROCEDURE Get_AllIngredients
AS
	select IngredientsId, Name, Price  from tblIngredients
GO

