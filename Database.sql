USE [master]
GO
/****** Object:  Database [testReal]    Script Date: 20/02/2020 20:58:04 ******/
CREATE DATABASE [testReal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestReal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TestReal.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestReal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TestReal_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [testReal] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [testReal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [testReal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [testReal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [testReal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [testReal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [testReal] SET ARITHABORT OFF 
GO
ALTER DATABASE [testReal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [testReal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [testReal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [testReal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [testReal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [testReal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [testReal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [testReal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [testReal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [testReal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [testReal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [testReal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [testReal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [testReal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [testReal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [testReal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [testReal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [testReal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [testReal] SET  MULTI_USER 
GO
ALTER DATABASE [testReal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [testReal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [testReal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [testReal] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [testReal] SET DELAYED_DURABILITY = DISABLED 
GO
USE [testReal]
GO
/****** Object:  Table [dbo].[key]    Script Date: 20/02/2020 20:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[key](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[keycode] [varchar](50) NOT NULL,
 CONSTRAINT [PK_key] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[logins]    Script Date: 20/02/2020 20:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[logins](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[login] [varchar](50) NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_logins] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[products]    Script Date: 20/02/2020 20:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[products](
	[productId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[description] [varchar](50) NULL,
	[amount] [numeric](5, 0) NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reserves]    Script Date: 20/02/2020 20:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reserves](
	[idreserve] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[iduser] [numeric](18, 0) NULL,
	[idproduct] [numeric](18, 0) NULL,
	[amountreserved] [numeric](5, 0) NULL,
	[datereserved] [datetime] NULL,
 CONSTRAINT [PK_reserves] PRIMARY KEY CLUSTERED 
(
	[idreserve] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user]    Script Date: 20/02/2020 20:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[login] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[role] [varchar](50) NULL,
	[age] [int] NULL,
	[gender] [varchar](50) NULL,
	[nationality] [varchar](50) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[key] ON 

GO
INSERT [dbo].[key] ([Id], [keycode]) VALUES (CAST(1 AS Numeric(18, 0)), N'12345')
GO
SET IDENTITY_INSERT [dbo].[key] OFF
GO
SET IDENTITY_INSERT [dbo].[logins] ON 

GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(1 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-19 16:13:07.167' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(2 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-19 16:18:51.267' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(3 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-19 16:25:48.870' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(4 AS Numeric(18, 0)), N'amanda', CAST(N'2020-02-19 16:26:12.320' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(5 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-19 16:26:26.273' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(6 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-20 11:27:20.813' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(7 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-20 11:31:43.080' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(8 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-20 11:39:22.550' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(9 AS Numeric(18, 0)), N'amanda', CAST(N'2020-02-20 11:42:13.757' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(10 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-20 12:09:50.263' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(11 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-20 12:14:25.613' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(12 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-20 12:36:48.067' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(13 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-20 13:38:41.887' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(14 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-20 13:41:05.143' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(15 AS Numeric(18, 0)), N'jose', CAST(N'2020-02-20 13:42:10.243' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(16 AS Numeric(18, 0)), N'jose', CAST(N'2020-02-20 13:49:15.327' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(17 AS Numeric(18, 0)), N'jose', CAST(N'2020-02-20 13:53:10.913' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(18 AS Numeric(18, 0)), N'jose', CAST(N'2020-02-20 13:56:14.207' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(19 AS Numeric(18, 0)), N'jose', CAST(N'2020-02-20 14:47:04.910' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(20 AS Numeric(18, 0)), N'jose', CAST(N'2020-02-20 14:50:56.393' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(21 AS Numeric(18, 0)), N'jose', CAST(N'2020-02-20 14:54:36.693' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(22 AS Numeric(18, 0)), N'jose', CAST(N'2020-02-20 15:08:39.887' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(23 AS Numeric(18, 0)), N'jose', CAST(N'2020-02-20 15:10:19.223' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(24 AS Numeric(18, 0)), N'jose', CAST(N'2020-02-20 15:13:23.743' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(25 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-20 16:24:56.553' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(26 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-20 16:49:43.280' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(27 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-20 17:38:46.167' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(28 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-20 17:40:43.737' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(29 AS Numeric(18, 0)), N'amanda', CAST(N'2020-02-20 17:45:42.457' AS DateTime))
GO
INSERT [dbo].[logins] ([id], [login], [date]) VALUES (CAST(30 AS Numeric(18, 0)), N'admin', CAST(N'2020-02-20 17:47:38.940' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[logins] OFF
GO
SET IDENTITY_INSERT [dbo].[products] ON 

GO
INSERT [dbo].[products] ([productId], [description], [amount]) VALUES (CAST(1 AS Numeric(18, 0)), N'Product 1', CAST(2 AS Numeric(5, 0)))
GO
INSERT [dbo].[products] ([productId], [description], [amount]) VALUES (CAST(2 AS Numeric(18, 0)), N'Product 2', CAST(5 AS Numeric(5, 0)))
GO
INSERT [dbo].[products] ([productId], [description], [amount]) VALUES (CAST(3 AS Numeric(18, 0)), N'Product 3', CAST(46 AS Numeric(5, 0)))
GO
INSERT [dbo].[products] ([productId], [description], [amount]) VALUES (CAST(4 AS Numeric(18, 0)), N'Product 4', CAST(1 AS Numeric(5, 0)))
GO
SET IDENTITY_INSERT [dbo].[products] OFF
GO
SET IDENTITY_INSERT [dbo].[reserves] ON 

GO
INSERT [dbo].[reserves] ([idreserve], [iduser], [idproduct], [amountreserved], [datereserved]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(5, 0)), CAST(N'2020-02-20 14:55:35.180' AS DateTime))
GO
INSERT [dbo].[reserves] ([idreserve], [iduser], [idproduct], [amountreserved], [datereserved]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(3 AS Numeric(5, 0)), CAST(N'2020-02-20 15:14:08.837' AS DateTime))
GO
INSERT [dbo].[reserves] ([idreserve], [iduser], [idproduct], [amountreserved], [datereserved]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(5, 0)), CAST(N'2020-02-20 17:47:15.557' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[reserves] OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON 

GO
INSERT [dbo].[user] ([Id], [login], [password], [role], [age], [gender], [nationality]) VALUES (CAST(1 AS Numeric(18, 0)), N'admin', N'u66xS9m0mZjZgD1mxHLHlw==', N'admin', 30, N'male', N'Colombian')
GO
INSERT [dbo].[user] ([Id], [login], [password], [role], [age], [gender], [nationality]) VALUES (CAST(2 AS Numeric(18, 0)), N'amanda', N'qS/+qUxQ9jQ5+BgR1hugCA==', N'user', 34, N'female', N'France')
GO
INSERT [dbo].[user] ([Id], [login], [password], [role], [age], [gender], [nationality]) VALUES (CAST(3 AS Numeric(18, 0)), N'jose', N'm6fIlhcKO8j+UuVxW7vwFw==', N'user', 39, N'male', N'Col')
GO
SET IDENTITY_INSERT [dbo].[user] OFF
GO
/****** Object:  Index [IX_FK_reserves_Products]    Script Date: 20/02/2020 20:58:04 ******/
CREATE NONCLUSTERED INDEX [IX_FK_reserves_Products] ON [dbo].[reserves]
(
	[idproduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_reserves_user]    Script Date: 20/02/2020 20:58:04 ******/
CREATE NONCLUSTERED INDEX [IX_FK_reserves_user] ON [dbo].[reserves]
(
	[iduser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[reserves]  WITH CHECK ADD  CONSTRAINT [FK_reserves_Products] FOREIGN KEY([idproduct])
REFERENCES [dbo].[products] ([productId])
GO
ALTER TABLE [dbo].[reserves] CHECK CONSTRAINT [FK_reserves_Products]
GO
ALTER TABLE [dbo].[reserves]  WITH CHECK ADD  CONSTRAINT [FK_reserves_user] FOREIGN KEY([iduser])
REFERENCES [dbo].[user] ([Id])
GO
ALTER TABLE [dbo].[reserves] CHECK CONSTRAINT [FK_reserves_user]
GO
USE [master]
GO
ALTER DATABASE [testReal] SET  READ_WRITE 
GO
