USE [master]
GO
/****** Object:  Database [CALL_CENTER_DB]    Script Date: 10/11/2023 15:02:57 ******/
CREATE DATABASE [CALL_CENTER_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CALL_CENTER_DB', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CALL_CENTER_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CALL_CENTER_DB_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CALL_CENTER_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CALL_CENTER_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CALL_CENTER_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CALL_CENTER_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CALL_CENTER_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CALL_CENTER_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CALL_CENTER_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CALL_CENTER_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CALL_CENTER_DB] SET  MULTI_USER 
GO
ALTER DATABASE [CALL_CENTER_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CALL_CENTER_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CALL_CENTER_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CALL_CENTER_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CALL_CENTER_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CALL_CENTER_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CALL_CENTER_DB', N'ON'
GO
ALTER DATABASE [CALL_CENTER_DB] SET QUERY_STORE = OFF
GO
USE [CALL_CENTER_DB]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 10/11/2023 15:02:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estados]    Script Date: 10/11/2023 15:02:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estados](
	[idEstado] [int] IDENTITY(1,1) NOT NULL,
	[estado] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[incidente]    Script Date: 10/11/2023 15:02:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[incidente](
	[idIncidente] [int] IDENTITY(1,1) NOT NULL,
	[idEstado] [int] NOT NULL,
	[IdPrioridad] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Descripcion] [varchar](300) NOT NULL,
	[Idmotivo] [int] NOT NULL,
	[IdResponsable] [int] NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[FechaUltimaModificacion] [date] NULL,
	[ComentarioCierre] [varchar](300) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[motivo]    Script Date: 10/11/2023 15:02:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[motivo](
	[Idmotivo] [int] IDENTITY(1,1) NOT NULL,
	[motivo] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prioridad]    Script Date: 10/11/2023 15:02:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prioridad](
	[IdPrioridad] [int] IDENTITY(1,1) NOT NULL,
	[Prioridad] [varchar](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoUsuario]    Script Date: 10/11/2023 15:02:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoUsuario](
	[IdTipoDeUsuario] [int] IDENTITY(1,1) NOT NULL,
	[TipoUsuario] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 10/11/2023 15:02:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[loginusuario] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[idTipoUsuario] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[clientes] ON 

INSERT [dbo].[clientes] ([IdCliente], [Nombre], [Apellido], [Email], [Telefono]) VALUES (1, N'Cliente1', N'Test1', N'cliente@cliente.com', N'555-1111')
INSERT [dbo].[clientes] ([IdCliente], [Nombre], [Apellido], [Email], [Telefono]) VALUES (2, N'Cliente2', N'Test2', N'cliente2@cliente.com', N'555-1112')
INSERT [dbo].[clientes] ([IdCliente], [Nombre], [Apellido], [Email], [Telefono]) VALUES (3, N'Cliente 3', N'Test3', N'cliente3@cliente.com', N'555-1113')
INSERT [dbo].[clientes] ([IdCliente], [Nombre], [Apellido], [Email], [Telefono]) VALUES (4, N'Cliente4', N'Test4', N'cliente4@cliente.com', N'555-1114')
SET IDENTITY_INSERT [dbo].[clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[estados] ON 

INSERT [dbo].[estados] ([idEstado], [estado]) VALUES (1, N'Abierto')
INSERT [dbo].[estados] ([idEstado], [estado]) VALUES (2, N'En Análisis')
INSERT [dbo].[estados] ([idEstado], [estado]) VALUES (3, N'Cerrado')
INSERT [dbo].[estados] ([idEstado], [estado]) VALUES (4, N'Reabierto')
INSERT [dbo].[estados] ([idEstado], [estado]) VALUES (5, N'Asignado')
INSERT [dbo].[estados] ([idEstado], [estado]) VALUES (6, N'Resuelto')
SET IDENTITY_INSERT [dbo].[estados] OFF
GO
SET IDENTITY_INSERT [dbo].[incidente] ON 

INSERT [dbo].[incidente] ([idIncidente], [idEstado], [IdPrioridad], [IdCliente], [Descripcion], [Idmotivo], [IdResponsable], [FechaCreacion], [FechaUltimaModificacion]) VALUES (1, 6, 1, 1, N'Test', 1, 1, CAST(N'2023-11-09' AS Date), CAST(N'2023-11-10' AS Date))
INSERT [dbo].[incidente] ([idIncidente], [idEstado], [IdPrioridad], [IdCliente], [Descripcion], [Idmotivo], [IdResponsable], [FechaCreacion], [FechaUltimaModificacion]) VALUES (2, 6, 1, 1, N'abs', 1, 1, CAST(N'2023-11-09' AS Date), CAST(N'2023-11-10' AS Date))
INSERT [dbo].[incidente] ([idIncidente], [idEstado], [IdPrioridad], [IdCliente], [Descripcion], [Idmotivo], [IdResponsable], [FechaCreacion], [FechaUltimaModificacion]) VALUES (3, 6, 1, 1, N'test123', 1, 1, CAST(N'2023-11-09' AS Date), CAST(N'2023-11-10' AS Date))
INSERT [dbo].[incidente] ([idIncidente], [idEstado], [IdPrioridad], [IdCliente], [Descripcion], [Idmotivo], [IdResponsable], [FechaCreacion], [FechaUltimaModificacion]) VALUES (4, 6, 1, 1, N'prueba', 1, 1, CAST(N'2023-11-09' AS Date), CAST(N'2023-11-10' AS Date))
INSERT [dbo].[incidente] ([idIncidente], [idEstado], [IdPrioridad], [IdCliente], [Descripcion], [Idmotivo], [IdResponsable], [FechaCreacion], [FechaUltimaModificacion]) VALUES (5, 6, 1, 1, N'prueba', 1, 1, CAST(N'2023-11-09' AS Date), CAST(N'2023-11-10' AS Date))
INSERT [dbo].[incidente] ([idIncidente], [idEstado], [IdPrioridad], [IdCliente], [Descripcion], [Idmotivo], [IdResponsable], [FechaCreacion], [FechaUltimaModificacion]) VALUES (6, 1, 1, 1, N'', 1, 1, CAST(N'2023-11-09' AS Date), CAST(N'2023-11-09' AS Date))
INSERT [dbo].[incidente] ([idIncidente], [idEstado], [IdPrioridad], [IdCliente], [Descripcion], [Idmotivo], [IdResponsable], [FechaCreacion], [FechaUltimaModificacion]) VALUES (7, 1, 2, 2, N'123', 2, 1, CAST(N'2023-11-09' AS Date), CAST(N'2023-11-09' AS Date))
SET IDENTITY_INSERT [dbo].[incidente] OFF
GO
SET IDENTITY_INSERT [dbo].[motivo] ON 

INSERT [dbo].[motivo] ([Idmotivo], [motivo]) VALUES (1, N'Falla producto')
INSERT [dbo].[motivo] ([Idmotivo], [motivo]) VALUES (2, N'Servicio')
SET IDENTITY_INSERT [dbo].[motivo] OFF
GO
SET IDENTITY_INSERT [dbo].[prioridad] ON 

INSERT [dbo].[prioridad] ([IdPrioridad], [Prioridad]) VALUES (1, N'Baja')
INSERT [dbo].[prioridad] ([IdPrioridad], [Prioridad]) VALUES (2, N'Media')
INSERT [dbo].[prioridad] ([IdPrioridad], [Prioridad]) VALUES (3, N'Alta')
SET IDENTITY_INSERT [dbo].[prioridad] OFF
GO
SET IDENTITY_INSERT [dbo].[tipoUsuario] ON 

INSERT [dbo].[tipoUsuario] ([IdTipoDeUsuario], [TipoUsuario]) VALUES (1, N'Administrador')
INSERT [dbo].[tipoUsuario] ([IdTipoDeUsuario], [TipoUsuario]) VALUES (2, N'Supervisor')
INSERT [dbo].[tipoUsuario] ([IdTipoDeUsuario], [TipoUsuario]) VALUES (3, N'Telefonista ')
SET IDENTITY_INSERT [dbo].[tipoUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([idUsuario], [Nombre], [Apellido], [email], [loginusuario], [password], [idTipoUsuario]) VALUES (1, N'test', N'test', N'test@test.com', N'test', N'test', NULL)
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
USE [master]
GO
ALTER DATABASE [CALL_CENTER_DB] SET  READ_WRITE 
GO
