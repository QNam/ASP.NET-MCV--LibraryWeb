USE [master]
GO
/****** Object:  Database [library]    Script Date: 4/9/2019 5:13:36 PM ******/
CREATE DATABASE [library]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'library', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\library.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'library_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\library_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [library] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [library] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [library] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [library] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [library] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [library] SET ARITHABORT OFF 
GO
ALTER DATABASE [library] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [library] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [library] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [library] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [library] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [library] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [library] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [library] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [library] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [library] SET  ENABLE_BROKER 
GO
ALTER DATABASE [library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [library] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [library] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [library] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [library] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [library] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [library] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [library] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [library] SET  MULTI_USER 
GO
ALTER DATABASE [library] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [library] SET DB_CHAINING OFF 
GO
ALTER DATABASE [library] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [library] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [library] SET DELAYED_DURABILITY = DISABLED 
GO
USE [library]
GO
/****** Object:  Table [dbo].[author]    Script Date: 4/9/2019 5:13:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[author](
	[author_id] [int] IDENTITY(1,1) NOT NULL,
	[author_name] [nvarchar](150) NULL,
 CONSTRAINT [PK_author] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[book]    Script Date: 4/9/2019 5:13:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[book](
	[book_id] [int] IDENTITY(1,1) NOT NULL,
	[book_name] [nvarchar](250) NULL,
	[book_qty] [int] NULL CONSTRAINT [DF_book_book_qty]  DEFAULT ((0)),
	[vendor_id] [int] NOT NULL,
	[author_id] [int] NOT NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[book_price] [int] NULL CONSTRAINT [DF_book_book_price]  DEFAULT ((0)),
 CONSTRAINT [PK_book] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cate_book]    Script Date: 4/9/2019 5:13:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cate_book](
	[cate_id] [int] NULL,
	[book_id] [int] NULL,
	[cate_book_id] [int] NOT NULL,
 CONSTRAINT [PK_cate_book] PRIMARY KEY CLUSTERED 
(
	[cate_book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[category]    Script Date: 4/9/2019 5:13:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[cat_id] [int] IDENTITY(0,1) NOT NULL,
	[cat_name] [nvarchar](250) NULL,
	[cat_parent] [int] NOT NULL CONSTRAINT [DF_category_cat_parent]  DEFAULT ((0)),
 CONSTRAINT [PK_Table_] PRIMARY KEY CLUSTERED 
(
	[cat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detail_order]    Script Date: 4/9/2019 5:13:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detail_order](
	[order_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[status] [int] NULL CONSTRAINT [DF_detail_order_status]  DEFAULT ((0)),
	[book_status] [int] NOT NULL CONSTRAINT [DF_detail_order_book_status]  DEFAULT ((0)),
	[book_deposit] [int] NULL CONSTRAINT [DF_detail_order_book_price]  DEFAULT ((0)),
	[order_qty] [int] NULL CONSTRAINT [DF_detail_order_order_qty]  DEFAULT ((1)),
 CONSTRAINT [PK_detail_order] PRIMARY KEY CLUSTERED 
(
	[order_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[order]    Script Date: 4/9/2019 5:13:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[order_from] [date] NULL,
	[order_to] [date] NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[user_id] [int] NOT NULL,
	[order_pay] [int] NULL CONSTRAINT [DF_order_order_pay]  DEFAULT ((0)),
	[order_deposit] [int] NULL CONSTRAINT [DF_order_order_deposit]  DEFAULT ((0)),
	[order_forfeit] [int] NULL CONSTRAINT [DF_order_order_forfeit]  DEFAULT ((0)),
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user]    Script Date: 4/9/2019 5:13:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](100) NULL,
	[user_phone] [nchar](10) NOT NULL,
	[createed_at] [date] NULL,
	[updated_at] [date] NULL,
	[user_addr] [varchar](150) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[vendor]    Script Date: 4/9/2019 5:13:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vendor](
	[vendor_id] [int] IDENTITY(1,1) NOT NULL,
	[vendor_name] [nchar](150) NULL,
	[vendor_phone] [nchar](12) NULL,
	[vendor_address] [nvarchar](250) NULL,
 CONSTRAINT [PK_vendor] PRIMARY KEY CLUSTERED 
(
	[vendor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Cate_Book1]    Script Date: 4/9/2019 5:13:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Cate_Book1] ON [dbo].[cate_book]
(
	[cate_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cate_Book2]    Script Date: 4/9/2019 5:13:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Cate_Book2] ON [dbo].[cate_book]
(
	[cate_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_order_user]    Script Date: 4/9/2019 5:13:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_order_user] ON [dbo].[order]
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Uq_user]    Script Date: 4/9/2019 5:13:36 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Uq_user] ON [dbo].[user]
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[book]  WITH CHECK ADD  CONSTRAINT [FK_book_author] FOREIGN KEY([author_id])
REFERENCES [dbo].[author] ([author_id])
GO
ALTER TABLE [dbo].[book] CHECK CONSTRAINT [FK_book_author]
GO
ALTER TABLE [dbo].[book]  WITH CHECK ADD  CONSTRAINT [FK_book_vendor] FOREIGN KEY([vendor_id])
REFERENCES [dbo].[vendor] ([vendor_id])
GO
ALTER TABLE [dbo].[book] CHECK CONSTRAINT [FK_book_vendor]
GO
ALTER TABLE [dbo].[cate_book]  WITH CHECK ADD  CONSTRAINT [FK_cate_book_book] FOREIGN KEY([book_id])
REFERENCES [dbo].[book] ([book_id])
GO
ALTER TABLE [dbo].[cate_book] CHECK CONSTRAINT [FK_cate_book_book]
GO
ALTER TABLE [dbo].[cate_book]  WITH CHECK ADD  CONSTRAINT [FK_cate_book_category] FOREIGN KEY([cate_id])
REFERENCES [dbo].[category] ([cat_id])
GO
ALTER TABLE [dbo].[cate_book] CHECK CONSTRAINT [FK_cate_book_category]
GO
ALTER TABLE [dbo].[detail_order]  WITH CHECK ADD  CONSTRAINT [FK_detail_order_order] FOREIGN KEY([order_id])
REFERENCES [dbo].[order] ([order_id])
GO
ALTER TABLE [dbo].[detail_order] CHECK CONSTRAINT [FK_detail_order_order]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([user_id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_user]
GO
USE [master]
GO
ALTER DATABASE [library] SET  READ_WRITE 
GO
