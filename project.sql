create database ChandanaMuttur_week2_ProductsDBAPI

create table Products 
(
	pId int primary key,
	pName varchar(60),
	pPrice int,
	pAvailableQty int,
	pDescription varchar(60),
	pIsInStock bit
)

create table Customers 
(
	cId int primary key,
	cName varchar(60),
	cAddress varchar(60),
	cWalletBalance decimal(18,2)
)

create table Orders
(
	oId int primary key,
	cId int,
	pId int,
	oStatus varchar(60) check(oStatus in ('Delivered', 'In progress','Cancelled','Failed')),
	foreign key (cId) references Customers(cId),
	foreign key (pId) references Products(pId)
)
