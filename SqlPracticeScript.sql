USE [master]
GO

/****** Object:  Database [SqlPractice]    Script Date: 20-12-2024 19:12:21 ******/
CREATE DATABASE [SqlPractice]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SqlPractice', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SqlPractice.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SqlPractice_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SqlPractice_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SqlPractice].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [SqlPractice] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [SqlPractice] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [SqlPractice] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [SqlPractice] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [SqlPractice] SET ARITHABORT OFF 
GO

ALTER DATABASE [SqlPractice] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [SqlPractice] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [SqlPractice] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [SqlPractice] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [SqlPractice] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [SqlPractice] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [SqlPractice] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [SqlPractice] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [SqlPractice] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [SqlPractice] SET  DISABLE_BROKER 
GO

ALTER DATABASE [SqlPractice] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [SqlPractice] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [SqlPractice] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [SqlPractice] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [SqlPractice] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [SqlPractice] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [SqlPractice] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [SqlPractice] SET RECOVERY FULL 
GO

ALTER DATABASE [SqlPractice] SET  MULTI_USER 
GO

ALTER DATABASE [SqlPractice] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [SqlPractice] SET DB_CHAINING OFF 
GO

ALTER DATABASE [SqlPractice] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [SqlPractice] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [SqlPractice] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [SqlPractice] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [SqlPractice] SET QUERY_STORE = OFF
GO

ALTER DATABASE [SqlPractice] SET  READ_WRITE 
GO


---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [SqlPractice]
GO

/****** Object:  Table [dbo].[Depatment]    Script Date: 20-12-2024 19:13:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Depatment](
	[DeptId] [int] NOT NULL,
	[DeptName] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[DeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [SqlPractice]
GO

/****** Object:  Table [dbo].[employee]    Script Date: 20-12-2024 19:13:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpName] [varchar](200) NULL,
	[Salary] [int] NULL,
	[City] [varchar](200) NULL,
	[Email] [varchar](50) NULL,
	[Mobile] [varchar](11) NULL,
	[Age] [varchar](3) NULL,
	[Status] [bit] NULL,
	[DeptId] [int] NULL,
 CONSTRAINT [PK__employee__3214EC07B41151A2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[employee] ADD  CONSTRAINT [DF__employee__Status__34C8D9D1]  DEFAULT ((0)) FOR [Status]
GO