create database StoreHouse

use StoreHouse


--Tables

Create Table Categorys(
CategoryID int not null identity(1,1) primary key,
Name nvarchar(50) not null,
Description nvarchar(50) not null
)
go



create table Products(
ProductID int not null identity(1,1) primary key,
Name  nvarchar(50) not null,
Description nvarchar(50) not null,
Price decimal(18,2) not null,
Stock int not null,
CategoryID int, 
constraint fk_products_category foreign key(CategoryID) references Categorys(CategoryID) on delete cascade
)
go


Create Table Rols(
RolID int not null identity(1,1) primary key,
Name nvarchar(50)
)

Create Table Users(
UserID int not null identity(1,1) primary key,
UserName nvarchar(20)not null,
Email nvarchar(30) unique not null,
Password nvarchar(20) not null,
Name nvarchar(50) not null
)
go

---Store Procedures


--- Products

create procedure Sp_Products_Create 
@Name nvarchar(50),
@Description nvarchar(50), 
@Price decimal(18,2), 
@Stock int, 
@CategoryID int
as 
begin

	insert into Products values(@Name,@Description, @Price, @Stock, @CategoryID)

end 

go



create procedure Sp_Products_Update
@ProductID int,
@Name nvarchar(50),
@Description nvarchar(50), 
@Price decimal(18,2), 
@Stock int, 
@CategoryID int
as 
begin

	update Products set Name=@Name, Description=@Description, Price=@Price, Stock= @Stock,CategoryID=@CategoryID where ProductID=@ProductID

end 

go

create procedure Sp_Products_Delete
@ProductID int
as 
begin

	delete from Products where ProductID=@ProductID

end 

go


create procedure SP_Products_GetAll 
@SearchQuery nvarchar(max)
as 
begin

	if (@SearchQuery is null)
	begin
		select * from Products
	end

	ELSE
	begin
		select * from Products where Name like  '%'+@SearchQuery + '%'
	end

end

go

create procedure SP_Products_GetByID
@ProductID int
as
begin

	select * from Products where ProductID=@ProductID

end

go

create procedure SP_Products_GetByCategory 
@CategoryID int
as
begin
	select * from Products where CategoryID=@CategoryID
end

go

---Categorys
create procedure Sp_Categorys_Create
@Name nvarchar(50),
@Description nvarchar(50)
as 
begin

	insert into Categorys values ( @Name, @Description)

end 

go

create procedure Sp_Categorys_Update
@CategoryID int,
@Name nvarchar(50),
@Description nvarchar(50)
as 
begin

	update Categorys set Name=@Name, Description=@Description where  CategoryID=@CategoryID 

end 

go

create procedure SP_Categorys_Delete
@CategoryID int
as
begin

	delete  from Categorys where CategoryID=@CategoryID

end

go

create procedure SP_Categorys_GetAll 
@SearchQuery nvarchar(max)
as 
begin

	if (@SearchQuery is null)
	begin
		select * from Categorys
	end

	ELSE
	begin
		select * from Categorys where Name like '%'+@SearchQuery + '%'
	end

end

go

create procedure SP_Categorys_GetByID
@CategoryID int
as
begin

	select * from Categorys where CategoryID=@CategoryID

end

go

---Users

create procedure Sp_Users_Create
@UserName nvarchar(20),
@Email nvarchar(30) ,
@Password nvarchar(20),
@Name nvarchar(50)
as
begin

insert into Users Values(@UserName,@Email, @Password, @Name)

end

go

create procedure Sp_Users_Update
@UserID int,
@UserName nvarchar(20),
@Email nvarchar(30) ,
@Password nvarchar(20),
@Name nvarchar(50)
as
begin

update  Users set UserName=@UserName,Email=@Email,Password= @Password, Name=@Name where UserID=@UserID

end

go

create procedure Sp_Users_GetByUserNameAndPassword
@Email nvarchar(20),
@Password nvarchar(20)
as
begin
select * from Users where Email=@Email and Password=@Password
end

go

create procedure Sp_Users_GetByID
@UserID int
as
begin
	select * from Users where UserID=UserID
end

create procedure SP_Users_GetByEmailOrUsername
@EmailOrUsername nvarchar(max)
as
begin

	select * from Users where Email=@EmailOrUsername or Username=@EmailOrUsername

end




