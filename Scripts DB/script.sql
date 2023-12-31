USE [master]
GO
/****** Object:  Database [CALL_CENTER_DB]    Script Date: 11/10/2023 5:16:16 PM ******/
CREATE DATABASE [CALL_CENTER_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CALL_CENTER_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CALL_CENTER_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CALL_CENTER_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CALL_CENTER_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
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
ALTER DATABASE [CALL_CENTER_DB] SET QUERY_STORE = OFF
GO
USE [CALL_CENTER_DB]
GO
/****** Object:  Table [dbo].[EstadosIncidentes]    Script Date: 11/10/2023 5:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadosIncidentes](
	[IdEstado] [int] IDENTITY(1,1) NOT NULL,
	[estado] [varchar](50) NULL,
 CONSTRAINT [PK_estado] PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incidentes]    Script Date: 11/10/2023 5:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incidentes](
	[IdIncidente] [int] IDENTITY(1,1) NOT NULL,
	[idEstado] [int] NOT NULL,
	[descripcion] [varchar](300) NOT NULL,
	[idMotivo] [int] NOT NULL,
	[idResponsable] [int] NOT NULL,
	[fechaCreacion] [date] NOT NULL,
	[fechaUltimaModificacion] [date] NULL,
	[idCliente] [int] NULL,
	[IdPrioridad] [int] NULL,
	[comentarioCierre] [varchar](100) NULL,
 CONSTRAINT [PK_incidente] PRIMARY KEY CLUSTERED 
(
	[IdIncidente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motivos]    Script Date: 11/10/2023 5:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motivos](
	[IdMotivo] [int] IDENTITY(1,1) NOT NULL,
	[motivo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_motivo] PRIMARY KEY CLUSTERED 
(
	[IdMotivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 11/10/2023 5:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[Idpersona] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[telefono] [varchar](10) NULL,
 CONSTRAINT [PK_personas] PRIMARY KEY CLUSTERED 
(
	[Idpersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prioridades]    Script Date: 11/10/2023 5:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prioridades](
	[IdPrioridad] [int] IDENTITY(1,1) NOT NULL,
	[prioridad] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPrioridad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposUsuarios]    Script Date: 11/10/2023 5:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposUsuarios](
	[IdTipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[tipoUsuario] [varchar](50) NULL,
 CONSTRAINT [PK_tipousuario] PRIMARY KEY CLUSTERED 
(
	[IdTipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 11/10/2023 5:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[login] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[idTipoUsuario] [int] NULL,
	[idPersona] [int] NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EstadosIncidentes] ON 

INSERT [dbo].[EstadosIncidentes] ([IdEstado], [estado]) VALUES (1, N'Abierto')
INSERT [dbo].[EstadosIncidentes] ([IdEstado], [estado]) VALUES (2, N'En Analisis')
INSERT [dbo].[EstadosIncidentes] ([IdEstado], [estado]) VALUES (3, N'Cerrado')
INSERT [dbo].[EstadosIncidentes] ([IdEstado], [estado]) VALUES (4, N'Reabierto')
INSERT [dbo].[EstadosIncidentes] ([IdEstado], [estado]) VALUES (5, N'Asignado')
INSERT [dbo].[EstadosIncidentes] ([IdEstado], [estado]) VALUES (6, N'Resuelto')
SET IDENTITY_INSERT [dbo].[EstadosIncidentes] OFF
GO
SET IDENTITY_INSERT [dbo].[Incidentes] ON 

INSERT [dbo].[Incidentes] ([IdIncidente], [idEstado], [descripcion], [idMotivo], [idResponsable], [fechaCreacion], [fechaUltimaModificacion], [idCliente], [IdPrioridad], [comentarioCierre]) VALUES (1, 1, N'prueba1', 1, 1, CAST(N'2023-11-10' AS Date), CAST(N'2023-11-10' AS Date), 2, 3, NULL)
INSERT [dbo].[Incidentes] ([IdIncidente], [idEstado], [descripcion], [idMotivo], [idResponsable], [fechaCreacion], [fechaUltimaModificacion], [idCliente], [IdPrioridad], [comentarioCierre]) VALUES (2, 3, N'prueba2', 3, 1, CAST(N'2023-11-10' AS Date), CAST(N'2023-11-10' AS Date), 2, 1, NULL)
SET IDENTITY_INSERT [dbo].[Incidentes] OFF
GO
SET IDENTITY_INSERT [dbo].[Motivos] ON 

INSERT [dbo].[Motivos] ([IdMotivo], [motivo]) VALUES (1, N'Internet')
INSERT [dbo].[Motivos] ([IdMotivo], [motivo]) VALUES (2, N'Telefonia')
INSERT [dbo].[Motivos] ([IdMotivo], [motivo]) VALUES (3, N'Pagos')
SET IDENTITY_INSERT [dbo].[Motivos] OFF
GO
SET IDENTITY_INSERT [dbo].[Personas] ON 

INSERT [dbo].[Personas] ([Idpersona], [nombre], [apellido], [email], [telefono]) VALUES (1, N'Matias', N'Ferrero', N'matiasferrerov@gmail.com', N'1122859956')
INSERT [dbo].[Personas] ([Idpersona], [nombre], [apellido], [email], [telefono]) VALUES (2, N'Prueba', N'Prueba', N'prueba@prueba.com', N'1122859956')
SET IDENTITY_INSERT [dbo].[Personas] OFF
GO
SET IDENTITY_INSERT [dbo].[prioridades] ON 

INSERT [dbo].[prioridades] ([IdPrioridad], [prioridad]) VALUES (1, N'Alta')
INSERT [dbo].[prioridades] ([IdPrioridad], [prioridad]) VALUES (2, N'Media')
INSERT [dbo].[prioridades] ([IdPrioridad], [prioridad]) VALUES (3, N'Baja')
SET IDENTITY_INSERT [dbo].[prioridades] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposUsuarios] ON 

INSERT [dbo].[TiposUsuarios] ([IdTipoUsuario], [tipoUsuario]) VALUES (1, N'Administrador')
INSERT [dbo].[TiposUsuarios] ([IdTipoUsuario], [tipoUsuario]) VALUES (2, N'Telefonista')
INSERT [dbo].[TiposUsuarios] ([IdTipoUsuario], [tipoUsuario]) VALUES (3, N'Supervisor')
INSERT [dbo].[TiposUsuarios] ([IdTipoUsuario], [tipoUsuario]) VALUES (4, N'Cliente')
SET IDENTITY_INSERT [dbo].[TiposUsuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [login], [password], [idTipoUsuario], [idPersona]) VALUES (1, N'mati', N'mati', 1, 1)
INSERT [dbo].[Usuarios] ([IdUsuario], [login], [password], [idTipoUsuario], [idPersona]) VALUES (2, N'prueba', N'prueba', 1, 2)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Incidentes]  WITH CHECK ADD FOREIGN KEY([IdPrioridad])
REFERENCES [dbo].[prioridades] ([IdPrioridad])
GO
ALTER TABLE [dbo].[Incidentes]  WITH CHECK ADD  CONSTRAINT [FK_estado] FOREIGN KEY([idEstado])
REFERENCES [dbo].[EstadosIncidentes] ([IdEstado])
GO
ALTER TABLE [dbo].[Incidentes] CHECK CONSTRAINT [FK_estado]
GO
ALTER TABLE [dbo].[Incidentes]  WITH CHECK ADD  CONSTRAINT [FK_idCliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Personas] ([Idpersona])
GO
ALTER TABLE [dbo].[Incidentes] CHECK CONSTRAINT [FK_idCliente]
GO
ALTER TABLE [dbo].[Incidentes]  WITH CHECK ADD  CONSTRAINT [FK_motivo] FOREIGN KEY([idMotivo])
REFERENCES [dbo].[Motivos] ([IdMotivo])
GO
ALTER TABLE [dbo].[Incidentes] CHECK CONSTRAINT [FK_motivo]
GO
ALTER TABLE [dbo].[Incidentes]  WITH CHECK ADD  CONSTRAINT [FK_responsable] FOREIGN KEY([idResponsable])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Incidentes] CHECK CONSTRAINT [FK_responsable]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_idPersona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Personas] ([Idpersona])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_idPersona]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_tipousuario] FOREIGN KEY([idTipoUsuario])
REFERENCES [dbo].[TiposUsuarios] ([IdTipoUsuario])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_tipousuario]
GO
USE [master]
GO
ALTER DATABASE [CALL_CENTER_DB] SET  READ_WRITE 
GO
