USE [master]
GO
/****** Object:  Database [SoftTradePlus]    Script Date: 26.05.2021 16:45:59 ******/
CREATE DATABASE [SoftTradePlus]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SoftTradePlus', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SoftTradePlus.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SoftTradePlus_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SoftTradePlus_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SoftTradePlus] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SoftTradePlus].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SoftTradePlus] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SoftTradePlus] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SoftTradePlus] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SoftTradePlus] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SoftTradePlus] SET ARITHABORT OFF 
GO
ALTER DATABASE [SoftTradePlus] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SoftTradePlus] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SoftTradePlus] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SoftTradePlus] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SoftTradePlus] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SoftTradePlus] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SoftTradePlus] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SoftTradePlus] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SoftTradePlus] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SoftTradePlus] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SoftTradePlus] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SoftTradePlus] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SoftTradePlus] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SoftTradePlus] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SoftTradePlus] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SoftTradePlus] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SoftTradePlus] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SoftTradePlus] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SoftTradePlus] SET  MULTI_USER 
GO
ALTER DATABASE [SoftTradePlus] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SoftTradePlus] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SoftTradePlus] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SoftTradePlus] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SoftTradePlus] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SoftTradePlus]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 26.05.2021 16:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Manager_Id] [int] NOT NULL,
	[Client_Status] [int] NOT NULL,
	[Client_Type] [int] NOT NULL,
 CONSTRAINT [Id_Pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClientStatus]    Script Date: 26.05.2021 16:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientStatus](
	[Id] [int] NOT NULL,
	[Status_Type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ClientStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClientTypes]    Script Date: 26.05.2021 16:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientTypes](
	[Id] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ClientTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Managers]    Script Date: 26.05.2021 16:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Managers](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Client_Id] [int] NOT NULL,
 CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product_Type]    Script Date: 26.05.2021 16:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product_Type](
	[Id] [int] NOT NULL,
	[Product_Type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Product_Type] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 26.05.2021 16:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[Subscribe_Type] [int] NOT NULL,
	[Period] [date] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Purchased_Box]    Script Date: 26.05.2021 16:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchased_Box](
	[Order_Id] [int] NOT NULL,
	[Client_Id] [int] NOT NULL,
	[Product_Id] [int] NOT NULL,
	[Purchase_Time] [date] NULL,
 CONSTRAINT [PK_Purchused_Box] PRIMARY KEY CLUSTERED 
(
	[Order_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [Client_Status_Id] FOREIGN KEY([Client_Status])
REFERENCES [dbo].[ClientStatus] ([Id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [Client_Status_Id]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [Client_Type_FK] FOREIGN KEY([Client_Type])
REFERENCES [dbo].[ClientTypes] ([Id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [Client_Type_FK]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [Manager_FK] FOREIGN KEY([Manager_Id])
REFERENCES [dbo].[Managers] ([Id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [Manager_FK]
GO
ALTER TABLE [dbo].[Managers]  WITH CHECK ADD  CONSTRAINT [Client_FK] FOREIGN KEY([Client_Id])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[Managers] CHECK CONSTRAINT [Client_FK]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [Subscribe_Type_FK] FOREIGN KEY([Subscribe_Type])
REFERENCES [dbo].[Product_Type] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [Subscribe_Type_FK]
GO
ALTER TABLE [dbo].[Purchased_Box]  WITH CHECK ADD  CONSTRAINT [Client_Id_FK] FOREIGN KEY([Client_Id])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[Purchased_Box] CHECK CONSTRAINT [Client_Id_FK]
GO
ALTER TABLE [dbo].[Purchased_Box]  WITH CHECK ADD  CONSTRAINT [Product_Id_FK] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Purchased_Box] CHECK CONSTRAINT [Product_Id_FK]
GO
USE [master]
GO
ALTER DATABASE [SoftTradePlus] SET  READ_WRITE 
GO
