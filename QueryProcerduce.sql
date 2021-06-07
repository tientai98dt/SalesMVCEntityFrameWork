create proc Sp_Login
	@username varchar(20),
	@passwork varchar(50)
as
begin
	declare @count int
	declare @res int
	select @count = COUNT(*) from Login where UserName = @username and PassWord = @passwork
	if @count > 0
		set @res = 1
	else
		set @res = 0
	select @res
end

create proc Sp_Category_ListAll
as
select * from Categories order by CategoryId asc

create proc Sp_Customer_ListAll
as
select * from Customers order by CustomerId asc