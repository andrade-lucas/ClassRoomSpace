USE [master]
GO
/****** Object:  Database [classroomspace]    Script Date: 09/07/2019 18:01:26 ******/
CREATE DATABASE [classroomspace]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'classroomspace', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\classroomspace.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'classroomspace_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\classroomspace_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [classroomspace] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [classroomspace].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [classroomspace] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [classroomspace] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [classroomspace] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [classroomspace] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [classroomspace] SET ARITHABORT OFF 
GO
ALTER DATABASE [classroomspace] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [classroomspace] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [classroomspace] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [classroomspace] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [classroomspace] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [classroomspace] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [classroomspace] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [classroomspace] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [classroomspace] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [classroomspace] SET  ENABLE_BROKER 
GO
ALTER DATABASE [classroomspace] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [classroomspace] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [classroomspace] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [classroomspace] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [classroomspace] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [classroomspace] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [classroomspace] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [classroomspace] SET RECOVERY FULL 
GO
ALTER DATABASE [classroomspace] SET  MULTI_USER 
GO
ALTER DATABASE [classroomspace] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [classroomspace] SET DB_CHAINING OFF 
GO
ALTER DATABASE [classroomspace] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [classroomspace] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [classroomspace] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'classroomspace', N'ON'
GO
ALTER DATABASE [classroomspace] SET QUERY_STORE = OFF
GO
USE [classroomspace]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 09/07/2019 18:01:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [uniqueidentifier] NOT NULL,
	[Street] [varchar](100) NOT NULL,
	[Number] [varchar](20) NOT NULL,
	[District] [varchar](60) NOT NULL,
	[City] [varchar](60) NULL,
	[State] [varchar](2) NULL,
	[ZipCode] [varchar](20) NULL,
	[Country] [varchar](60) NULL,
	[IdOwner] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Block]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Block](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [varchar](60) NOT NULL,
	[IdCollege] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[College]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[College](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](60) NOT NULL,
	[LastName] [varchar](60) NOT NULL,
	[Document] [varchar](14) NOT NULL,
	[Email] [varchar](160) NOT NULL,
	[Phone] [varchar](20) NULL,
	[Image] [varchar](1024) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](60) NOT NULL,
	[LastName] [varchar](60) NOT NULL,
	[Document] [varchar](14) NULL,
	[Email] [varchar](160) NOT NULL,
	[Password] [varchar](180) NOT NULL,
	[Phone] [varchar](20) NULL,
	[Status] [bit] NOT NULL,
	[Image] [varchar](1024) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Block]  WITH CHECK ADD FOREIGN KEY([IdCollege])
REFERENCES [dbo].[College] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[spAuthUser]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spAuthUser]
	@email varchar(160),
	@password varchar(180)
as
select
	[Id],
	[FirstName] as [Name],
	[Email]
from
	[User]
where
	[Email] = @email and [Password] = @password
GO
/****** Object:  StoredProcedure [dbo].[spCreateAddress]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spCreateAddress]
	@id uniqueidentifier,
	@street varchar(100),
	@number varchar(20),
	@district varchar(60),
	@city varchar(60),
	@state varchar(2),
	@zipCode varchar(20),
	@country varchar(60),
	@idOwner uniqueidentifier
as
insert into [Address] (
	[Id], [Street], [Number], [District], [City], [State], [ZipCode], [Country], [IdOwner]
) values (
	@id, @street, @number, @district, @city, @state, @zipCode, @country, @idOwner
)
GO
/****** Object:  StoredProcedure [dbo].[spCreateBlock]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spCreateBlock]
	@id uniqueidentifier,
	@description varchar(60),
	@idCollege uniqueidentifier
as
insert into [Block] (
	[Id], [Description], [IdCollege] )
values (
	@id, @description, @idCollege )
GO
/****** Object:  StoredProcedure [dbo].[spCreateCollege]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spCreateCollege]
	@id uniqueidentifier,
	@firstName varchar(60),
	@lastName varchar(60),
	@document varchar(14),
	@email varchar(160),
	@phone varchar(20),
	@image varchar(1024)
as
insert into [College] (
	[Id], [FirstName], [LastName], [Document], [Email], [Phone], [Image]
) values (
	@id, @firstName, @lastName, @document, @email, @phone, @image
)
GO
/****** Object:  StoredProcedure [dbo].[spCreateUser]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spCreateUser] 
	@id uniqueidentifier, 
	@firstName varchar(60), 
	@lastName varchar(60), 
	@document varchar(14), 
	@email varchar(160), 
	@password varchar(180), 
	@phone varchar(20), 
	@status bit, 
	@image varchar(1024)
as
insert into [User]([Id], [FirstName], [LastName], [Document], [Email], [Password], [Phone], [Status], [Image])
values
(@id, @firstName, @lastName, @document, @email, @password, @phone, @status, @image)
GO
/****** Object:  StoredProcedure [dbo].[spDeleteAddress]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDeleteAddress]
	@id uniqueidentifier
as
delete from [Address] where [Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spDeleteBlock]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDeleteBlock]
	@id uniqueidentifier
as
delete from [Block]
where
	[Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spDeleteCollege]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDeleteCollege]
	@id uniqueidentifier
as
delete from [College] where [Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spDeleteUser]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDeleteUser]
	@id uniqueidentifier
as
delete from [User] where [Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spEditAddress]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spEditAddress]
	@id uniqueidentifier,
	@street varchar(100),
	@number varchar(20),
	@district varchar(60),
	@city varchar(60),
	@state varchar(2),
	@zipCode varchar(20),
	@country varchar(60),
	@idOwner uniqueidentifier
as
update [Address] set
	[Street] = @street,
	[Number] = @number,
	[District] = @district,
	[City] = @city,
	[State] = @state,
	[ZipCode] = @zipCode,
	[Country] = @country,
	[IdOwner] = @idOwner
where
	[Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spEditBlock]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spEditBlock]
	@id uniqueidentifier,
	@description varchar(60),
	@idCollege uniqueidentifier
as
update [Block] set
	[Description] = @description,
	[IdCollege] = @idCollege
where
	[Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spEditCollege]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spEditCollege]
	@id uniqueidentifier,
	@firstName varchar(60),
	@lastName varchar(60),
	@document varchar(14),
	@email varchar(160),
	@phone varchar(20),
	@image varchar(1024)
as
update [College] set
	[FirstName] = @firstName,
	[LastName] = @lastName,
	[Document] = @document,
	[Email] = @email,
	[Phone] = @phone,
	[Image] = @image
where
	[Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spEditUser]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spEditUser] 
	@id uniqueidentifier, 
	@firstName varchar(60), 
	@lastName varchar(60), 
	@document varchar(14), 
	@phone varchar(20), 
	@status bit, 
	@image varchar(1024)
as
update [User] set
	[FirstName] = @firstName,
	[LastName] = @lastName,
	[Document] = @document,
	[Phone] = @phone,
	[Status] = @status,
	[Image] = @image
where
	[Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spEmailExists]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spEmailExists]
	@email varchar(160)
as
	select case when exists(
		select [Id] from [User] where [Email] = @email
	)
	then cast(1 as bit)
	else cast(0 as bit) end
GO
/****** Object:  StoredProcedure [dbo].[spGetAddresses]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetAddresses]
	@idOwner uniqueidentifier
as
select 
	* 
from 
	[Address]
where 
	[IdOwner] = @idOwner
GO
/****** Object:  StoredProcedure [dbo].[spGetBlockById]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetBlockById]
	@id uniqueidentifier
as
select 
	[Id], [Description], [IdCollege]
from
	[Block]
where
	[Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spGetBlocks]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetBlocks]
as
select 
	[Id], [Description], [IdCollege]
from
	[Block]
GO
/****** Object:  StoredProcedure [dbo].[spGetUserById]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetUserById]
	@id uniqueidentifier
as
select
	[Id], [FirstName], [LastName], [Document], [Email], [Phone], [Status], [Image]
from
	[User]
where
	[Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spGetUsers]    Script Date: 09/07/2019 18:01:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetUsers]
as
select
	[Id], 
	concat([FirstName], ' ', [LastName]) as [Name],
	[Email],
	[status]
from [User] 
GO
USE [master]
GO
ALTER DATABASE [classroomspace] SET  READ_WRITE 
GO
