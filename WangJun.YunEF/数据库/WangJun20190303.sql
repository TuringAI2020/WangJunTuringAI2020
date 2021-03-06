USE [master]
GO
/****** Object:  Database [WangJun]    Script Date: 2019/3/3 23:41:35 ******/
CREATE DATABASE [WangJun]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WangJun', FILENAME = N'C:\MSSQL\WangJun.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WangJun_log', FILENAME = N'C:\MSSQL\WangJun_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WangJun] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WangJun].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WangJun] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WangJun] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WangJun] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WangJun] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WangJun] SET ARITHABORT OFF 
GO
ALTER DATABASE [WangJun] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WangJun] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WangJun] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WangJun] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WangJun] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WangJun] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WangJun] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WangJun] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WangJun] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WangJun] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WangJun] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WangJun] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WangJun] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WangJun] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WangJun] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WangJun] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WangJun] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WangJun] SET RECOVERY FULL 
GO
ALTER DATABASE [WangJun] SET  MULTI_USER 
GO
ALTER DATABASE [WangJun] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WangJun] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WangJun] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WangJun] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WangJun] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WangJun', N'ON'
GO
ALTER DATABASE [WangJun] SET QUERY_STORE = OFF
GO
USE [WangJun]
GO
/****** Object:  Table [dbo].[YunForm]    Script Date: 2019/3/3 23:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YunForm](
	[ID] [uniqueidentifier] NOT NULL,
	[FormType] [int] NULL,
	[MD5] [uniqueidentifier] NULL,
	[ValueS01] [nvarchar](50) NULL,
	[ValueI01] [int] NULL,
	[ValueI02] [int] NULL,
	[Status] [int] NULL,
	[StatusText] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[CreatorID] [uniqueidentifier] NULL,
	[CreatorName] [nvarchar](50) NULL,
	[UpdaterID] [uniqueidentifier] NULL,
	[UpdaterName] [nvarchar](50) NULL,
	[Title] [nvarchar](200) NULL,
	[SourceUrl] [nvarchar](2048) NULL,
	[Html] [nvarchar](max) NULL,
	[PlainText] [nvarchar](max) NULL,
	[SummaryText] [nvarchar](max) NULL,
	[SourceID] [uniqueidentifier] NULL,
	[SourceName] [nvarchar](50) NULL,
	[PermissionGroupID] [uniqueidentifier] NULL,
	[PermissionGroupName] [nvarchar](50) NULL,
	[BinData] [varbinary](max) NULL,
	[FormTypeName] [nvarchar](50) NULL,
	[ValueI03] [int] NULL,
	[ValueI04] [int] NULL,
 CONSTRAINT [PK_YunForm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YunOrder]    Script Date: 2019/3/3 23:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YunOrder](
	[ID] [uniqueidentifier] NOT NULL,
	[OrderID] [uniqueidentifier] NULL,
	[GroupID] [uniqueidentifier] NULL,
	[GoodsID] [uniqueidentifier] NULL,
	[SourceID] [uniqueidentifier] NULL,
	[Status] [int] NULL,
	[Count] [int] NULL,
	[PayID] [uniqueidentifier] NULL,
	[ConsumerID] [uniqueidentifier] NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_YunOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YunQRCode]    Script Date: 2019/3/3 23:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YunQRCode](
	[ID] [uniqueidentifier] NOT NULL,
	[QRCode] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[OrderID] [uniqueidentifier] NULL,
	[CreateTime] [datetime] NULL,
	[CheckInStartTime] [datetime] NULL,
	[CheckInEndTime] [datetime] NULL,
	[ExpiryTime] [datetime] NULL,
	[QRCodeType] [int] NULL,
 CONSTRAINT [PK_YunQRCode] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YunRelation]    Script Date: 2019/3/3 23:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YunRelation](
	[ID] [uniqueidentifier] NOT NULL,
	[GroupID] [uniqueidentifier] NULL,
	[GroupName] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Type] [int] NULL,
	[TypeName] [nvarchar](50) NULL,
	[Sort01] [int] NULL,
	[KeyA01] [nvarchar](50) NULL,
	[ValueA01] [int] NULL,
 CONSTRAINT [PK_YunRelation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [WangJun] SET  READ_WRITE 
GO
