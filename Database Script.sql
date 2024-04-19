USE [master]
GO
/****** Object:  Database [phonelibrary]    Script Date: 4/19/2024 17:46:37 ******/
CREATE DATABASE [phonelibrary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'phonelibrary', FILENAME = N'{your path}\phonelibrary.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'phonelibrary_log', FILENAME = N'{your path}\phonelibrary_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [phonelibrary] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [phonelibrary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [phonelibrary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [phonelibrary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [phonelibrary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [phonelibrary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [phonelibrary] SET ARITHABORT OFF 
GO
ALTER DATABASE [phonelibrary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [phonelibrary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [phonelibrary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [phonelibrary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [phonelibrary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [phonelibrary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [phonelibrary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [phonelibrary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [phonelibrary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [phonelibrary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [phonelibrary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [phonelibrary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [phonelibrary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [phonelibrary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [phonelibrary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [phonelibrary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [phonelibrary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [phonelibrary] SET RECOVERY FULL 
GO
ALTER DATABASE [phonelibrary] SET  MULTI_USER 
GO
ALTER DATABASE [phonelibrary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [phonelibrary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [phonelibrary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [phonelibrary] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [phonelibrary] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [phonelibrary] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'phonelibrary', N'ON'
GO
ALTER DATABASE [phonelibrary] SET QUERY_STORE = OFF
GO
USE [phonelibrary]
GO
/****** Object:  Table [dbo].[tContacts]    Script Date: 4/19/2024 17:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tContacts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Mobile1] [nvarchar](15) NULL,
	[Mobile2] [nvarchar](15) NULL,
	[Phone1] [nvarchar](15) NULL,
	[Phone2] [nvarchar](15) NULL,
	[DateCreated] [date] NULL,
 CONSTRAINT [PK_tContacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tContactSubContacts]    Script Date: 4/19/2024 17:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tContactSubContacts](
	[ParentContactId] [bigint] NULL,
	[Title] [nvarchar](50) NULL,
	[Phone] [nvarchar](15) NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [phonelibrary] SET  READ_WRITE 
GO