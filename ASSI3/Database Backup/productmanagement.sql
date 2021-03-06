USE [master]
GO
/****** Object:  Database [productmanagement]    Script Date: 01-01-2020 23:59:24 ******/
CREATE DATABASE [productmanagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'productmanagement', FILENAME = N'C:\Users\Yesha\productmanagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'productmanagement_log', FILENAME = N'C:\Users\Yesha\productmanagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [productmanagement] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [productmanagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [productmanagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [productmanagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [productmanagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [productmanagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [productmanagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [productmanagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [productmanagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [productmanagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [productmanagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [productmanagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [productmanagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [productmanagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [productmanagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [productmanagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [productmanagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [productmanagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [productmanagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [productmanagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [productmanagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [productmanagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [productmanagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [productmanagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [productmanagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [productmanagement] SET  MULTI_USER 
GO
ALTER DATABASE [productmanagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [productmanagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [productmanagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [productmanagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [productmanagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [productmanagement] SET QUERY_STORE = OFF
GO
USE [productmanagement]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [productmanagement]
GO
/****** Object:  Table [dbo].[Tbl_Category]    Script Date: 01-01-2020 23:59:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Category](
	[C_Id] [int] IDENTITY(1,1) NOT NULL,
	[C_Name] [varchar](20) NOT NULL,
	[C_Fkey_Uid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[C_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Products]    Script Date: 01-01-2020 23:59:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Products](
	[P_Id] [int] IDENTITY(1,1) NOT NULL,
	[P_Name] [varchar](50) NOT NULL,
	[P_Price] [varchar](20) NOT NULL,
	[P_Qty] [varchar](20) NOT NULL,
	[P_Short_Description] [varchar](100) NOT NULL,
	[P_Long_Description] [varchar](150) NOT NULL,
	[P_SImage] [varchar](100) NOT NULL,
	[P_LImage] [varchar](150) NOT NULL,
	[P_Fkey_Cid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[P_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Users]    Script Date: 01-01-2020 23:59:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Users](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Email] [varchar](50) NOT NULL,
	[User_Password] [varchar](30) NOT NULL,
	[User_Name] [varchar](100) NOT NULL,
	[User_Image] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Category] ON 

INSERT [dbo].[Tbl_Category] ([C_Id], [C_Name], [C_Fkey_Uid]) VALUES (1, N'Earrings', 1)
INSERT [dbo].[Tbl_Category] ([C_Id], [C_Name], [C_Fkey_Uid]) VALUES (2, N'Earrings', 2)
INSERT [dbo].[Tbl_Category] ([C_Id], [C_Name], [C_Fkey_Uid]) VALUES (3007, N'Nacklace', 2)
INSERT [dbo].[Tbl_Category] ([C_Id], [C_Name], [C_Fkey_Uid]) VALUES (3008, N'Ring', 2)
SET IDENTITY_INSERT [dbo].[Tbl_Category] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Products] ON 

INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (1, N'Silk Thread Earring', N'120', N'6', N'Beautiful Silk Thread Earring', N'Beautiful Silk Thread Earring, color:red', N'~/Content/images/012.jpg', N'~/Content/images/012.jpg', 2)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (2, N'Silk Thread Earring', N'120', N'9', N'Awasome Silk Thread Jhumki Earring', N'Awasome Silk Thread Jhumki Earring, color :Marun', N'~/Content/images/020.jpg', N'~/Content/images/020.jpg', 2)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (3, N'Silk Thread Jhumki', N'100', N'2', N'Beautiful Silk Thread Earring', N'Beautiful Silk Thread Jhumki Earrings , color:Yellow', N'~/Content/images/014.jpg', N'~/Content/images/014.jpg', 2)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (4, N'Beautiful Earrings', N'100', N'4', N'Awasome Earring', N'Beautiful Silk Thread Earring, color:red and black', N'~/Content/images/018.jpg', N'~/Content/images/018.jpg', 2)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (5, N'Silk Thread Earring', N'250', N'4', N'Market Connect Silk Thread Earring', N'Market Connect Silk Thread Earring, color:Pink', N'~/Content/images/015.jpg', N'~/Content/images/015.jpg', 2)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (6, N'Diamond Nacklace', N'5000', N'2', N'Awasome Diamond Nacklace', N'Awasome Diamond Nacklace', N'~/Content/images/0n6.jpg', N'~/Content/images/0n6.jpg', 3007)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (7, N'Beautiful  Red Diamond Nacklace', N'4500', N'8', N'Beautiful Diamond Nacklace', N'Beautiful Diamond Nacklace,Color:White and Red', N'~/Content/images/0n10.jpg', N'~/Content/images/0n10.jpg', 3007)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (8, N'Diamond Nacklace', N'4500', N'7', N'Beautiful Diamond Nacklace', N'Beautiful Diamond Nacklace,Color:White', N'~/Content/images/0n9.jpg', N'~/Content/images/0n9.jpg', 3007)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (9, N'Golden Naklace', N'3000', N'3', N'Beautiful Golden Nacklace', N'Beautiful Golden Nacklace', N'~/Content/images/0n8.jpg', N'~/Content/images/0n8.jpg', 3007)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (10, N'Beautiful Nacklace', N'3500', N'4', N'Beautiful Golden Nacklace', N'Beautiful Golden Nacklace,Color:Red and Golden', N'~/Content/images/0n12.jpg', N'~/Content/images/0n12.jpg', 3007)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (11, N'Silk Thread Earring', N'120', N'5', N'Beautiful Silk Thread Earring', N'Beautiful Silk Thread  Earrings , color:White and Blue', N'~/Content/images/043.jpg', N'~/Content/images/043.jpg', 2)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (12, N'Diamond Ring', N'500', N'7', N'Beautiful Diamond Ring', N'Beautiful Diamond Ring,Buy 1 get 1 Free', N'~/Content/images/0r6.jpg', N'~/Content/images/0r6.jpg', 3008)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (13, N'Diamond Ring', N'450', N'6', N'Awasome Diamond Ring', N'Awasome Red Diamond Ring,Color:Golden ', N'~/Content/images/0r5.jpg', N'~/Content/images/0r5.jpg', 3008)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (14, N'Diamond Ring', N'350', N'6', N'Beautiful Diamond Ring', N'Beautiful Diamond Ring,Buy 2 get 1 Free', N'~/Content/images/0r7.jpg', N'~/Content/images/0r7.jpg', 3008)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (15, N'Silk Thread Jhumki', N'120', N'5', N'Beautiful Silk Thread Earring', N'Beautiful Silk Thread Earring , Color:Pink', N'~/Content/images/013.jpg', N'~/Content/images/013.jpg', 2)
INSERT [dbo].[Tbl_Products] ([P_Id], [P_Name], [P_Price], [P_Qty], [P_Short_Description], [P_Long_Description], [P_SImage], [P_LImage], [P_Fkey_Cid]) VALUES (16, N'Beautiful Silk Thread Earring', N'150', N'7', N'Beautiful Silk Thread Earring', N'Beautiful Silk Thread Earring, color:Pink and Orange', N'~/Content/images/024.jpg', N'~/Content/images/024.jpg', 2)
SET IDENTITY_INSERT [dbo].[Tbl_Products] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Users] ON 

INSERT [dbo].[Tbl_Users] ([User_Id], [User_Email], [User_Password], [User_Name], [User_Image]) VALUES (1, N'shah@gmail.com', N'shah', N'shah', N'~/Content/images/016.jpg')
INSERT [dbo].[Tbl_Users] ([User_Id], [User_Email], [User_Password], [User_Name], [User_Image]) VALUES (2, N'yesha@gmail.com', N'yesha', N'yesha', N'~/Content/images/016.jpg')
INSERT [dbo].[Tbl_Users] ([User_Id], [User_Email], [User_Password], [User_Name], [User_Image]) VALUES (2002, N'honey@gmail.com', N'honey', N'honey', N'~/Content/images/016.jpg')
INSERT [dbo].[Tbl_Users] ([User_Id], [User_Email], [User_Password], [User_Name], [User_Image]) VALUES (3002, N'kashak@gmail.com', N'kashak', N'kashak', N'~/Content/images/020150418_161428.jpg')
INSERT [dbo].[Tbl_Users] ([User_Id], [User_Email], [User_Password], [User_Name], [User_Image]) VALUES (3016, N'bindu@gmail.com', N'bindu', N'bindu', N'-1')
SET IDENTITY_INSERT [dbo].[Tbl_Users] OFF
ALTER TABLE [dbo].[Tbl_Category]  WITH CHECK ADD FOREIGN KEY([C_Fkey_Uid])
REFERENCES [dbo].[Tbl_Users] ([User_Id])
GO
ALTER TABLE [dbo].[Tbl_Products]  WITH CHECK ADD FOREIGN KEY([P_Fkey_Cid])
REFERENCES [dbo].[Tbl_Category] ([C_Id])
GO
USE [master]
GO
ALTER DATABASE [productmanagement] SET  READ_WRITE 
GO
