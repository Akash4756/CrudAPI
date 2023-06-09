USE [cruddb]
GO
/****** Object:  Table [dbo].[Emp_Detail]    Script Date: 18-05-2023 17:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emp_Detail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](20) NOT NULL,
	[Gender] [varchar](20) NOT NULL,
	[Mobile] [varchar](15) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[IsActive] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Admin]    Script Date: 18-05-2023 17:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Emp_Detail] ON 

INSERT [dbo].[Emp_Detail] ([Id], [Name], [Email], [Password], [Gender], [Mobile], [Address], [IsActive]) VALUES (3, N'Akash Kumar Yadav', N'akash34@gmail.com', N'Akash@321', N'Male', N'9830524613', N'Dhanbad', 1)
INSERT [dbo].[Emp_Detail] ([Id], [Name], [Email], [Password], [Gender], [Mobile], [Address], [IsActive]) VALUES (4, N'Prasoon Kumar', N'kumar142@gmail.com', N'Prasoon@124', N'Male', N'8126662534', N'Bihar', 1)
INSERT [dbo].[Emp_Detail] ([Id], [Name], [Email], [Password], [Gender], [Mobile], [Address], [IsActive]) VALUES (5, N'Gaurav Kumar', N'gaurav241@gmail.com', N'Gaurav@1874', N'Male', N'8875469234', N'Jharkhand', 1)
INSERT [dbo].[Emp_Detail] ([Id], [Name], [Email], [Password], [Gender], [Mobile], [Address], [IsActive]) VALUES (6, N'Subham Verma', N'subham245@gmail.com', N'Subham@654', N'Male', N'8814699325', N'Durgapur', 1)
INSERT [dbo].[Emp_Detail] ([Id], [Name], [Email], [Password], [Gender], [Mobile], [Address], [IsActive]) VALUES (7, N'Akash Yadav', N'yadav254@gmail.com', N'Akash@321', N'Male', N'9830524699', N'Dhanbad', 1)
INSERT [dbo].[Emp_Detail] ([Id], [Name], [Email], [Password], [Gender], [Mobile], [Address], [IsActive]) VALUES (8, N'Aditya Bhagat', N'aditya24@gmail.com', N'Aditya@321', N'Male', N'9830524699', N'Durgapur', 1)
SET IDENTITY_INSERT [dbo].[Emp_Detail] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Admin] ON 

INSERT [dbo].[tbl_Admin] ([Id], [Name], [Email], [Password]) VALUES (1, N'admin', N'admin@gmail.com', N'12345')
SET IDENTITY_INSERT [dbo].[tbl_Admin] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_emp_detail]    Script Date: 18-05-2023 17:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_delete_emp_detail]
@Id int
as
begin
delete from Emp_Detail where Id=@Id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_get_emp_detail]    Script Date: 18-05-2023 17:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_get_emp_detail]
@Id int=null
as 
begin
select Id,Name,Email,Password,Gender,Mobile,Address,IsActive from Emp_Detail where Id=ISNULL(@Id,Id)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_emp_detail]    Script Date: 18-05-2023 17:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_insert_emp_detail]
@Name varchar(100),
@Email varchar(50),
@Password varchar(100),
@Gender varchar(15),
@Mobile varchar(15),
@Address varchar(100),
@IsActive tinyint

as 
begin
declare @c as int
select @c=count(*) from Emp_Detail where Email=@Email
if(@c>0)
begin
select 0 as created
end
else
begin
insert into Emp_Detail(Name,Email,Password,Gender,Mobile,Address,IsActive)values
	(@Name,@Email,@Password,@Gender,@Mobile,@Address,@IsActive)
select 1 as created
end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_login_user]    Script Date: 18-05-2023 17:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_login_user]
@Email varchar(50),
@Password varchar(100)
as
begin
	if(exists(select Email from tbl_Admin where Email=@Email and Password=@Password))
	begin
		select 1 isauthenticated
	end
	else
	begin
		select 0 isauthenticated
	end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_update_emp_detail]    Script Date: 18-05-2023 17:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_update_emp_detail]
@Id int,
@Name varchar(100),
@Email varchar(50),
@Password varchar(100),
@Gender varchar(15),
@Mobile varchar(15),
@Address varchar(100),
@IsActive tinyint
as
begin
update Emp_Detail set Name=ISNULL(@Name,Name),
					  Email=ISNULL(@Email,Email),
					  Password=ISNULL(@Password,Password),
					  Gender=ISNULL(@Gender,Gender),
					  Mobile=ISNULL(@Mobile,Mobile),
					  Address=ISNULL(@Address,Address),
					  IsActive=ISNULL(@IsActive,IsActive)
					  where Id=@Id
select 1 as updated
end
GO
