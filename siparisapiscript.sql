USE [master]
GO
/****** Object:  Database [siparisapi]    Script Date: 28.03.2022 14:45:59 ******/
CREATE DATABASE [siparisapi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'siparisapi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\siparisapi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'siparisapi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\siparisapi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [siparisapi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [siparisapi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [siparisapi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [siparisapi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [siparisapi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [siparisapi] SET ARITHABORT OFF 
GO
ALTER DATABASE [siparisapi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [siparisapi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [siparisapi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [siparisapi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [siparisapi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [siparisapi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [siparisapi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [siparisapi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [siparisapi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [siparisapi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [siparisapi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [siparisapi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [siparisapi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [siparisapi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [siparisapi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [siparisapi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [siparisapi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [siparisapi] SET RECOVERY FULL 
GO
ALTER DATABASE [siparisapi] SET  MULTI_USER 
GO
ALTER DATABASE [siparisapi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [siparisapi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [siparisapi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [siparisapi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [siparisapi] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'siparisapi', N'ON'
GO
ALTER DATABASE [siparisapi] SET QUERY_STORE = OFF
GO
USE [siparisapi]
GO
/****** Object:  Table [dbo].[tblkullanici]    Script Date: 28.03.2022 14:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblkullanici](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kullaniciadi] [varchar](50) NULL,
	[sifre] [varchar](50) NULL,
 CONSTRAINT [PK_tblkullanici] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblmusteriler]    Script Date: 28.03.2022 14:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblmusteriler](
	[musteriid] [int] IDENTITY(1,1) NOT NULL,
	[ad] [varchar](50) NULL,
	[soyad] [varchar](50) NULL,
	[adres] [varchar](50) NULL,
	[sehir] [varchar](50) NULL,
 CONSTRAINT [PK_tblmusteriler] PRIMARY KEY CLUSTERED 
(
	[musteriid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblsiparisdetay]    Script Date: 28.03.2022 14:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblsiparisdetay](
	[siparisdetayid] [int] IDENTITY(1,1) NOT NULL,
	[siparisaciklama] [varchar](50) NULL,
	[siparisadet] [int] NULL,
	[siparisfiyat] [int] NULL,
 CONSTRAINT [PK_tblsiparisdetay] PRIMARY KEY CLUSTERED 
(
	[siparisdetayid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblsiparisler]    Script Date: 28.03.2022 14:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblsiparisler](
	[siparisid] [int] IDENTITY(1,1) NOT NULL,
	[siparisadi] [varchar](50) NULL,
	[siparistarihi] [varchar](50) NULL,
 CONSTRAINT [PK_tblsiparisler] PRIMARY KEY CLUSTERED 
(
	[siparisid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblkullanici] ON 

INSERT [dbo].[tblkullanici] ([id], [kullaniciadi], [sifre]) VALUES (1, N'rükna', N'1234')
SET IDENTITY_INSERT [dbo].[tblkullanici] OFF
GO
SET IDENTITY_INSERT [dbo].[tblmusteriler] ON 

INSERT [dbo].[tblmusteriler] ([musteriid], [ad], [soyad], [adres], [sehir]) VALUES (1, N'Rükna', N'Kavraş', N'Sancaktepe', N'İstanbul')
INSERT [dbo].[tblmusteriler] ([musteriid], [ad], [soyad], [adres], [sehir]) VALUES (2, N'Kübra', N'Şahin', N'Çekmeköy', N'İstanbul')
SET IDENTITY_INSERT [dbo].[tblmusteriler] OFF
GO
SET IDENTITY_INSERT [dbo].[tblsiparisdetay] ON 

INSERT [dbo].[tblsiparisdetay] ([siparisdetayid], [siparisaciklama], [siparisadet], [siparisfiyat]) VALUES (1, N'teslim edildi', 1, 50)
INSERT [dbo].[tblsiparisdetay] ([siparisdetayid], [siparisaciklama], [siparisadet], [siparisfiyat]) VALUES (2, N'teslim edildi', 2, 150)
INSERT [dbo].[tblsiparisdetay] ([siparisdetayid], [siparisaciklama], [siparisadet], [siparisfiyat]) VALUES (3, N'teslim edildi', 3, 60)
SET IDENTITY_INSERT [dbo].[tblsiparisdetay] OFF
GO
SET IDENTITY_INSERT [dbo].[tblsiparisler] ON 

INSERT [dbo].[tblsiparisler] ([siparisid], [siparisadi], [siparistarihi]) VALUES (1, N'Pasta', N'23.01.2022')
INSERT [dbo].[tblsiparisler] ([siparisid], [siparisadi], [siparistarihi]) VALUES (2, N'Sıvıyağ', N'11.02.2021')
INSERT [dbo].[tblsiparisler] ([siparisid], [siparisadi], [siparistarihi]) VALUES (3, N'Pizza', N'22.02.2022')
SET IDENTITY_INSERT [dbo].[tblsiparisler] OFF
GO
USE [master]
GO
ALTER DATABASE [siparisapi] SET  READ_WRITE 
GO
