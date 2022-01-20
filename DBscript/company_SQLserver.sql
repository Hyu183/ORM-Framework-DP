USE [master]
GO
/****** Object:  Database [company]    Script Date: 19/1/2022 10:09:07 AM ******/
CREATE DATABASE [company]
 CONTAINMENT = NONE
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [company] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [company].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [company] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [company] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [company] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [company] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [company] SET ARITHABORT OFF 
GO
ALTER DATABASE [company] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [company] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [company] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [company] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [company] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [company] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [company] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [company] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [company] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [company] SET  DISABLE_BROKER 
GO
ALTER DATABASE [company] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [company] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [company] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [company] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [company] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [company] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [company] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [company] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [company] SET  MULTI_USER 
GO
ALTER DATABASE [company] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [company] SET DB_CHAINING OFF 
GO
ALTER DATABASE [company] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [company] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [company] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [company] SET QUERY_STORE = OFF
GO
USE [company]
GO
/****** Object:  Table [dbo].[company]    Script Date: 19/1/2022 10:09:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[num_of_employee] [int] NULL,
	[established_date] [datetime] NULL,
	[tax_code_id] [int] NULL,
 CONSTRAINT [PK_company] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 19/1/2022 10:09:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](60) NULL,
	[sex] [varchar](10) NULL,
	[age] [int] NULL,
	[salary] [int] NULL,
	[company_id] [int] NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tax_name]    Script Date: 19/1/2022 10:09:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tax_name](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code_name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_tax_name] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[company] ON 
GO
INSERT [dbo].[company] ([id], [name], [num_of_employee], [established_date], [tax_code_id]) VALUES (1, N'Google', 10000, CAST(N'2022-01-12T23:14:58.000' AS DateTime), 1)
GO
INSERT [dbo].[company] ([id], [name], [num_of_employee], [established_date], [tax_code_id]) VALUES (2, N'Facebook', 9929, CAST(N'2022-01-12T23:14:58.000' AS DateTime), 2)
GO
INSERT [dbo].[company] ([id], [name], [num_of_employee], [established_date], [tax_code_id]) VALUES (3, N'Amazon', 2500, CAST(N'2022-01-12T23:15:41.000' AS DateTime), 3)
GO
SET IDENTITY_INSERT [dbo].[company] OFF
GO
SET IDENTITY_INSERT [dbo].[employee] ON 
GO
INSERT [dbo].[employee] ([id], [name], [sex], [age], [salary], [company_id]) VALUES (1, N'ABC', N'Male', 23, 120000, 1)
GO
INSERT [dbo].[employee] ([id], [name], [sex], [age], [salary], [company_id]) VALUES (2, N'XYZ', N'Female', 19, 6000, 2)
GO
SET IDENTITY_INSERT [dbo].[employee] OFF
GO
SET IDENTITY_INSERT [dbo].[tax_name] ON 
GO
INSERT [dbo].[tax_name] ([id], [code_name]) VALUES (1, N'ALM112')
GO
INSERT [dbo].[tax_name] ([id], [code_name]) VALUES (2, N'CFF227')
GO
INSERT [dbo].[tax_name] ([id], [code_name]) VALUES (3, N'CFF229')
GO
SET IDENTITY_INSERT [dbo].[tax_name] OFF
GO
ALTER TABLE [dbo].[company]  WITH CHECK ADD  CONSTRAINT [FK_company_tax_name] FOREIGN KEY([tax_code_id])
REFERENCES [dbo].[tax_name] ([id])
GO
ALTER TABLE [dbo].[company] CHECK CONSTRAINT [FK_company_tax_name]
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_company] FOREIGN KEY([company_id])
REFERENCES [dbo].[company] ([id])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_employee_company]
GO
USE [master]
GO
ALTER DATABASE [company] SET  READ_WRITE 
GO
USE company
GO
SELECT * FROM company WHERE id>0
SELECT * FROM company WHERE id>0 GROUP BY tax_code_id HAVING COUNT(name)>1