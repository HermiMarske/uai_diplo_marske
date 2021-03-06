USE [master]
GO
/****** Object:  Database [UAI_GESTION_AGUILA]    Script Date: 17/07/2019 23:57:41 ******/
CREATE DATABASE [UAI_GESTION_AGUILA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UAI_GESTION_AGUILA', FILENAME = N'E:\MSSQL14.MSSQLSERVER\MSSQL\DATA\UAI_GESTION_AGUILA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UAI_GESTION_AGUILA_log', FILENAME = N'E:\MSSQL14.MSSQLSERVER\MSSQL\DATA\UAI_GESTION_AGUILA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UAI_GESTION_AGUILA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET ARITHABORT OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET RECOVERY FULL 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET  MULTI_USER 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UAI_GESTION_AGUILA', N'ON'
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET QUERY_STORE = OFF
GO
USE [UAI_GESTION_AGUILA]
GO
/****** Object:  Table [dbo].[Actividades]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividades](
	[idActividad] [int] IDENTITY(1,1) NOT NULL,
	[horaInicio] [datetime] NULL,
	[horas] [int] NULL,
	[texto] [varchar](5000) NULL,
	[pilotoFK] [int] NULL,
	[localidadFK] [int] NULL,
	[clienteFK] [int] NULL,
	[avionFK] [int] NULL,
 CONSTRAINT [PK_Actividades] PRIMARY KEY CLUSTERED 
(
	[idActividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aviones]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aviones](
	[ID_Avion] [int] IDENTITY(1,1) NOT NULL,
	[matricula] [varchar](50) NULL,
	[marca] [varchar](50) NULL,
	[modelo] [varchar](50) NULL,
	[habilitado] [bit] NULL,
 CONSTRAINT [PK_Aviones] PRIMARY KEY CLUSTERED 
(
	[ID_Avion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[ID_Bitacora] [int] IDENTITY(1,1) NOT NULL,
	[timeStamp] [datetime] NULL,
	[criticidad] [varchar](50) NULL,
	[descripcion] [varchar](500) NULL,
	[FK_Usuario] [int] NULL,
	[DVH] [int] NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[ID_Bitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ID_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[razonSocial] [varchar](50) NULL,
	[cuil] [varchar](50) NULL,
	[tipoCliente] [varchar](50) NULL,
	[FK_Persona] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DDVV]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DDVV](
	[ID_DVV] [int] IDENTITY(1,1) NOT NULL,
	[tabla] [varchar](50) NULL,
	[dvv] [bigint] NULL,
 CONSTRAINT [PK_DDVV] PRIMARY KEY CLUSTERED 
(
	[ID_DVV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Domicilio]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Domicilio](
	[ID_Domicilio] [int] IDENTITY(1,1) NOT NULL,
	[calle] [varchar](50) NULL,
	[numero] [varchar](20) NULL,
	[piso] [int] NULL,
	[dpto] [varchar](5) NULL,
	[comentarios] [varchar](100) NULL,
	[codPostal] [varchar](20) NULL,
	[tipoDomicilio] [varchar](20) NULL,
	[FK_Localidad] [int] NULL,
	[FK_Persona] [int] NULL,
 CONSTRAINT [PK_Domicilio] PRIMARY KEY CLUSTERED 
(
	[ID_Domicilio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[idFamilia] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](5000) NOT NULL,
	[borrado] [datetime] NULL,
 CONSTRAINT [PK_Familia] PRIMARY KEY CLUSTERED 
(
	[idFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia_Patente]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Patente](
	[idFamiliaPatente] [int] IDENTITY(1,1) NOT NULL,
	[familiaFK] [int] NOT NULL,
	[patenteFK] [int] NOT NULL,
	[dvh] [int] NULL,
 CONSTRAINT [PK_Familia_Patente] PRIMARY KEY CLUSTERED 
(
	[idFamiliaPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HabilitacionAviones]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HabilitacionAviones](
	[idHabilitacionAvion] [int] NOT NULL,
	[fechaInicio] [date] NULL,
	[fechaFin] [date] NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_HabilitacionAviones] PRIMARY KEY CLUSTERED 
(
	[idHabilitacionAvion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HabilitacionesPilotos]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HabilitacionesPilotos](
	[idHabilitacionPiloto] [int] NOT NULL,
	[fechaInicio] [date] NULL,
	[fechaFin] [date] NULL,
	[motivo] [varchar](100) NULL,
 CONSTRAINT [PK_HabilitacionesPilotos] PRIMARY KEY CLUSTERED 
(
	[idHabilitacionPiloto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idiomas]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idiomas](
	[idIdioma] [int] NOT NULL,
	[nombre] [varchar](20) NULL,
	[locale] [varchar](10) NULL,
 CONSTRAINT [PK_Idiomas] PRIMARY KEY CLUSTERED 
(
	[idIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[ID_Localidad] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[FK_Provincia] [int] NULL,
	[referencia] [int] NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[ID_Localidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mails]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mails](
	[ID_Mail] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](20) NULL,
	[mail] [varchar](100) NULL,
	[FK_Persona] [int] NULL,
 CONSTRAINT [PK_Mails] PRIMARY KEY CLUSTERED 
(
	[ID_Mail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[ID_Pais] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[ID_Pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patente]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[idPatente] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](5000) NOT NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[idPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 17/07/2019 23:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[ID_Persona] [int] IDENTITY(1,1) NOT NULL,
	[dni] [varchar](20) NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[sexo] [varchar](20) NULL,
	[fechaNacimiento] [date] NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[ID_Persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pilotos]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pilotos](
	[ID_Piloto] [int] IDENTITY(1,1) NOT NULL,
	[licencia] [varchar](70) NULL,
	[dvh] [int] NULL,
	[fechaInicioApto] [date] NULL,
	[fechaVencimientoApto] [date] NULL,
	[FK_Persona] [int] NULL,
 CONSTRAINT [PK_Pilotos] PRIMARY KEY CLUSTERED 
(
	[ID_Piloto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preguntas]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas](
	[idPregunta] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](20) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Preguntas] PRIMARY KEY CLUSTERED 
(
	[idPregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[ID_Provincia] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[FK_Pais] [int] NULL,
 CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED 
(
	[ID_Provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefono](
	[ID_Telefono] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](20) NULL,
	[numero] [varchar](30) NULL,
	[FK_Persona] [int] NULL,
 CONSTRAINT [PK_Telefono] PRIMARY KEY CLUSTERED 
(
	[ID_Telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPersonas]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPersonas](
	[idTipoPersona] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TipoPersonas] PRIMARY KEY CLUSTERED 
(
	[idTipoPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Familia]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Familia](
	[idUsuFam] [int] IDENTITY(1,1) NOT NULL,
	[familiaFK] [int] NOT NULL,
	[usuarioFK] [int] NOT NULL,
	[dvh] [int] NULL,
 CONSTRAINT [PK_Usuario_Familia] PRIMARY KEY CLUSTERED 
(
	[idUsuFam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Patente]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Patente](
	[idUsuarioPatente] [int] IDENTITY(1,1) NOT NULL,
	[patenteFK] [int] NOT NULL,
	[usuarioFK] [int] NOT NULL,
	[negado] [bit] NULL,
	[dvh] [int] NULL,
 CONSTRAINT [PK_Usuario_Patente] PRIMARY KEY CLUSTERED 
(
	[idUsuarioPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](500) NOT NULL,
	[clave] [varchar](2000) NOT NULL,
	[CII] [int] NOT NULL,
	[habilitado] [bit] NOT NULL,
	[idioma] [varchar](5) NOT NULL,
	[DVH] [int] NULL,
	[FK_Persona] [int] NULL,
	[respuesta] [varchar](30) NULL,
	[FK_Pregunta] [int] NULL,
	[deleteTime] [datetime] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((0)) FOR [CII]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((1)) FOR [habilitado]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ('es-AR') FOR [idioma]
GO
ALTER TABLE [dbo].[Actividades]  WITH CHECK ADD  CONSTRAINT [FK_Actividades_Actividades] FOREIGN KEY([idActividad])
REFERENCES [dbo].[Actividades] ([idActividad])
GO
ALTER TABLE [dbo].[Actividades] CHECK CONSTRAINT [FK_Actividades_Actividades]
GO
/****** Object:  StoredProcedure [dbo].[AltaCliente]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Alta de clientes
-- =============================================
CREATE PROCEDURE [dbo].[AltaCliente]

	

	@razonSocial varchar(20),
	@cuil varchar(20),
	@tipoCliente varchar(20),
	@dni varchar(20),
	@nombre varchar(50),
	@apellido varchar(50),
	@sexo varchar(20),
	@fechaNacimiento date


AS
	DECLARE @Persona_FK int;
	INSERT INTO Personas(dni,nombre,apellido,sexo, fechaNacimiento) VALUES (@dni, @nombre, @apellido, @sexo, @fechaNacimiento)
	SELECT @Persona_FK = SCOPE_IDENTITY()
	INSERT INTO Cliente(razonSocial,cuil,tipoCliente,FK_Persona) VALUES(@razonSocial, @cuil,@tipoCliente,@Persona_FK)

	
SELECT @Persona_FK
GO
/****** Object:  StoredProcedure [dbo].[AltaDomicilio]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/15
-- Description:	Alta de	Domicilio
-- =============================================
CREATE PROCEDURE [dbo].[AltaDomicilio]


	@calle varchar(50),
	@numero varchar(20),
	@piso int,
	@dpto varchar(5),
	@comentarios varchar(100),
	@codPostal varchar(20),
	@tipoDomicilio varchar(20),
	@fk_localidad int,
	@fk_persona int



AS
	
	INSERT INTO Domicilio(calle,numero,piso,dpto, comentarios, codPostal,tipoDomicilio, FK_Localidad, FK_Persona)
	VALUES (@calle, @numero, @piso, @dpto, @comentarios, @codPostal, @tipoDomicilio, @fk_localidad, @fk_persona)

	
RETURN 0

/****** Object:  StoredProcedure [dbo].[AltaMail]    Script Date: 08/04/2019 01:29:13 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[AltaMail]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/15
-- Description:	Alta de	Mails
-- =============================================
CREATE PROCEDURE [dbo].[AltaMail]


	@tipo varchar(20),
	@mail varchar(100),
	@fk_persona int

AS
	
	INSERT INTO Mails(tipo, mail, FK_Persona)
	VALUES (@tipo, @mail, @fk_persona)

RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[AltaTelefono]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/15
-- Description:	Alta de	Telefono
-- =============================================
CREATE PROCEDURE [dbo].[AltaTelefono]


	@tipo varchar(20),
	@numero varchar(30),
	@fk_persona int

AS
	
	INSERT INTO Telefono(tipo,numero, FK_Persona)
	VALUES (@tipo, @numero, @fk_persona)

RETURN 0

/****** Object:  StoredProcedure [dbo].[AltaDomicilio]    Script Date: 08/04/2019 01:28:41 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[AltaUsuario]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/07
-- Description:	Alta de usuarios
-- =============================================
CREATE PROCEDURE [dbo].[AltaUsuario]

	

	@dniPersona varchar(20),
	@nombre varchar(50),
	@apellido varchar(50),
	@sexo varchar(20),
	@fechaNacimiento date,
	@usuario varchar(20),
	@clave varchar(2000),
	@respuesta varchar(50),
	@fk_pregunta int


AS
	DECLARE @idPersona int = 0;
	DECLARE @idUsuario int = 0;
	SELECT TOP 1 @idPersona = ID_Persona FROM Personas WHERE dni = @dniPersona;
	SELECT TOP 1 @idUsuario = ID_Usuario FROM Usuarios WHERE FK_Persona = @idPersona;

	IF (NOT(@idPersona = 0) AND (@idUsuario = 0))
	BEGIN
		INSERT INTO Usuarios(usuario,clave, CII, habilitado, FK_Persona, respuesta, FK_Pregunta) VALUES (@usuario, @clave, 0, 1, @idPersona, @respuesta, @fk_pregunta)
		SELECT 'USER_CREATED_EXISTING_PERSON' as 'success';
	END;
	ELSE IF (@idPersona = 0 AND @dniPersona IS NULL)
		SELECT 'MISSING_DATA' as 'error';
	ELSE IF (@idUsuario = 0 AND @idPersona = 0)
	BEGIN
		INSERT INTO Personas(dni,nombre,apellido,sexo, fechaNacimiento) VALUES (@dniPersona, @nombre, @apellido, @sexo, @fechaNacimiento)
		SELECT @idPersona = SCOPE_IDENTITY();
		
		INSERT INTO Usuarios(usuario,clave, CII, habilitado, FK_Persona, respuesta, FK_Pregunta) VALUES (@usuario, @clave, 0, 1, @idPersona, @respuesta, @fk_pregunta)
		SELECT TOP 1 'USER_CREATED_PERSON_CREATED' as 'success', @idPersona as 'ID_Persona';
	END;
	ELSE
		SELECT TOP 1 'PERSON_HAS_USER' as 'error', usuario FROM Usuarios WHERE ID_Usuario = @idUsuario;
GO
/****** Object:  StoredProcedure [dbo].[AltaUsuarioPersExistente]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/07
-- Description:	Alta de clientes
-- =============================================
CREATE PROCEDURE [dbo].[AltaUsuarioPersExistente]

	

	@idPersona int,
	@usuario varchar(20),
	@clave varchar(2000),
	@respuesta varchar(50),
	@fk_pregunta int


AS
	
	INSERT INTO Usuarios(usuario,clave, CII, habilitado, FK_Persona, respuesta, FK_Pregunta) VALUES (@usuario, @clave, 0, 1, @idPersona, @respuesta, @fk_pregunta)
	
GO
/****** Object:  StoredProcedure [dbo].[BorrarCliente]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Borrado permanente de Cliente
-- =============================================
CREATE PROCEDURE [dbo].[BorrarCliente]

@idCliente int

AS
  SET NOCOUNT ON;

  DECLARE @personaId int;

  SELECT @personaId = (SELECT FK_Persona FROM dbo.Cliente 
  WHERE ID_Cliente = @idCliente);



  DELETE FROM Cliente WHERE ID_Cliente = @idCliente;
  IF (NOT((SELECT COUNT(*) FROM Pilotos WHERE FK_Persona = @personaId) = 1 OR (SELECT COUNT(*) FROM Usuarios WHERE FK_Persona = @personaId) = 1))
    BEGIN
	  DELETE FROM Telefono WHERE FK_Persona = @personaId;
	  DELETE FROM Domicilio WHERE FK_Persona = @personaId;
	  DELETE FROM Personas WHERE ID_Persona = @personaId;
	  SELECT 'Se borraron todos los datos del cliente'
    END;
  ELSE 
	SELECT 'Se borraron solo los datos del cliente'
GO
/****** Object:  StoredProcedure [dbo].[BorrarDomicilios]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Borrar Domicilios de cliente
-- =============================================
CREATE PROCEDURE [dbo].[BorrarDomicilios]

@idCliente int

AS
  SET NOCOUNT ON;

  DECLARE @personaId int;

  SELECT @personaId = (SELECT FK_Persona FROM dbo.Cliente 
  WHERE ID_Cliente = @idCliente);

  DELETE FROM Domicilio WHERE FK_Persona = @personaId;
GO
/****** Object:  StoredProcedure [dbo].[BorrarMails]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Borrar Mails de persona
-- =============================================
CREATE PROCEDURE [dbo].[BorrarMails]

@idPersona int

AS
  SET NOCOUNT ON;

  DELETE FROM Mails WHERE FK_Persona = @idPersona;


/****** Object:  StoredProcedure [dbo].[AltaTelefono]    Script Date: 08/04/2019 01:28:42 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[BorrarTelefonos]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Borrar telefonos de cliente
-- =============================================
CREATE PROCEDURE [dbo].[BorrarTelefonos]

@idCliente int

AS
  SET NOCOUNT ON;

  DECLARE @personaId int;

  SELECT @personaId = (SELECT FK_Persona FROM dbo.Cliente 
  WHERE ID_Cliente = @idCliente);

  DELETE FROM Telefono WHERE FK_Persona = @personaId;


GO
/****** Object:  StoredProcedure [dbo].[BorrarUsuario]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Borrado permanente de USUARIO
-- =============================================
CREATE PROCEDURE [dbo].[BorrarUsuario]

@idUsuario int

AS
  SET NOCOUNT ON;

  DECLARE @personaId int;

  SELECT @personaId = (SELECT FK_Persona FROM dbo.Usuarios
  WHERE ID_Usuario = @idUsuario);



  DELETE FROM Usuarios WHERE ID_Usuario = @idUsuario;
  IF (NOT((SELECT COUNT(*) FROM Pilotos WHERE FK_Persona = @personaId) = 1 OR (SELECT COUNT(*) FROM Cliente WHERE FK_Persona = @personaId) = 1))
    BEGIN
	  DELETE FROM Telefono WHERE FK_Persona = @personaId;
	  DELETE FROM Domicilio WHERE FK_Persona = @personaId;
	  DELETE FROM Personas WHERE ID_Persona = @personaId;
	  SELECT 'Se borraron todos los datos del Usuario'
    END;
  ELSE
	SELECT 'Se borraron solo los datos del Usuario'

/****** Object:  StoredProcedure [dbo].[BorrarCliente]    Script Date: 18/04/2019 08:38:56 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ListarActividades]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/11
-- Description:	Listado de Actividades
-- =============================================
CREATE PROCEDURE [dbo].[ListarActividades]

AS
	SET NOCOUNT ON;
	SELECT a.idActividad, a.horaInicio, l.descripcion, c.razonSocial 
	FROM Actividades a, Localidades l, Cliente c
	WHERE a.clienteFK = c.ID_Cliente AND a.localidadFK = l.ID_Localidad
RETURN

GO
/****** Object:  StoredProcedure [dbo].[ListarAvionesCombo]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/11
-- Description:	Listado de Aviones
-- =============================================
CREATE PROCEDURE [dbo].[ListarAvionesCombo]

AS
	SET NOCOUNT ON;
	SELECT ID_Avion, matricula
	FROM Aviones
RETURN
GO
/****** Object:  StoredProcedure [dbo].[ListarClientes]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Listado de clientes
-- =============================================
CREATE PROCEDURE [dbo].[ListarClientes]

AS
	SET NOCOUNT ON;
	SELECT ID_Cliente, razonSocial, cuil, tipoCliente,FK_Persona,dni,nombre,apellido,sexo,fechaNacimiento 
	FROM Cliente, Personas
	WHERE FK_Persona = ID_Persona
RETURN
GO
/****** Object:  StoredProcedure [dbo].[ListarClientesCombo]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/11
-- Description:	Listado de Usuarios
-- =============================================
CREATE PROCEDURE [dbo].[ListarClientesCombo]

AS
	SET NOCOUNT ON;
	SELECT ID_Cliente, razonSocial
	FROM Cliente
RETURN
GO
/****** Object:  StoredProcedure [dbo].[ListarFamilias]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/22
-- Description:	Listado de Familias
-- =============================================
CREATE PROCEDURE [dbo].[ListarFamilias]

AS
	SET NOCOUNT ON;
	SELECT idFamilia, descripcion 
	FROM Familia

RETURN
GO
/****** Object:  StoredProcedure [dbo].[ListarLocalidades]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Lista de Provincias
-- =============================================
CREATE PROCEDURE [dbo].[ListarLocalidades]

@provincia int

AS
  SET NOCOUNT ON;
  SELECT  descripcion, ID_Localidad, referencia
  FROM Localidades
  WHERE Localidades.FK_Provincia = @provincia

RETURN
GO
/****** Object:  StoredProcedure [dbo].[ListarPaises]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Alta de clientes
-- =============================================
CREATE PROCEDURE [dbo].[ListarPaises]

AS
	SET NOCOUNT ON;
	SELECT * 
	FROM Pais

RETURN
GO
/****** Object:  StoredProcedure [dbo].[ListarPatentes]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 25/4/2019
-- Description:  Lista de patentes por familia usando asociacion de tabla de coso
-- =============================================
CREATE PROCEDURE [dbo].[ListarPatentes]

@idFamilia int

AS
  SET NOCOUNT ON;

SELECT p.idPatente, p.codigo
 FROM Patente p JOIN Familia_Patente pf ON p.idPatente = pf.patenteFK 
 WHERE pf.familiaFK = @idFamilia

RETURN
GO
/****** Object:  StoredProcedure [dbo].[ListarPatentesFamilias]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 5/5/2019
-- Description:  Lista de patentes de familias bleh
-- =============================================
CREATE PROCEDURE [dbo].[ListarPatentesFamilias]

AS
  SET NOCOUNT ON;

 SELECT f.idFamilia, f.descripcion, p.idPatente, p.codigo
 FROM Familia f LEFT JOIN Familia_Patente pf ON f.idFamilia = pf.familiaFK, 
 Patente p WHERE p.idPatente = pf.patenteFK ORDER BY f.idFamilia; 

RETURN
GO
/****** Object:  StoredProcedure [dbo].[ListarPilotos]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/11
-- Description:	Listado de Usuarios
-- =============================================
CREATE PROCEDURE [dbo].[ListarPilotos]

AS
	SET NOCOUNT ON;
	SELECT ID_Piloto, licencia, FK_Persona,nombre,apellido 
	FROM Pilotos, Personas
	WHERE FK_Persona = ID_Persona
RETURN
GO
/****** Object:  StoredProcedure [dbo].[ListarPilotosCombo]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Alta de clientes
-- =============================================
CREATE PROCEDURE [dbo].[ListarPilotosCombo]

AS
	SET NOCOUNT ON;
	SELECT p.ID_Piloto, per.nombre, per.apellido
	FROM Pilotos p, Personas per 
	WHERE p.FK_Persona = per.ID_Persona

RETURN
GO
/****** Object:  StoredProcedure [dbo].[ListarProvincias]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Lista de Provincias
-- =============================================
CREATE PROCEDURE [dbo].[ListarProvincias]

@pais int

AS
  SET NOCOUNT ON;
  SELECT  descripcion, ID_Provincia
  FROM Provincias
  WHERE Provincias.FK_Pais = @pais

RETURN
GO
/****** Object:  StoredProcedure [dbo].[ListarTodasPatentes]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 25/4/2019
-- Description:  Lista de patentes general
-- =============================================
CREATE PROCEDURE [dbo].[ListarTodasPatentes]

AS
  SET NOCOUNT ON;

SELECT idPatente, codigo
 FROM Patente 
RETURN
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuarios]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/07/11
-- Description:	Listado de Usuarios
-- =============================================
CREATE PROCEDURE [dbo].[ListarUsuarios]

AS
	SET NOCOUNT ON;
	SELECT ID_Usuario, usuario, FK_Persona,nombre,apellido, habilitado
	FROM Usuarios, Personas
	WHERE FK_Persona = ID_Persona
RETURN
GO
/****** Object:  StoredProcedure [dbo].[LogIn]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Logueo de usuario
-- =============================================
CREATE PROCEDURE [dbo].[LogIn]

@usuario varchar(20),
@password varchar(2000)

AS
	SET NOCOUNT ON;
	DECLARE @usuarioExists int = 0;
	DECLARE @contadorValid int = 0;
	DECLARE @passwordMatch int = 0;
	DECLARE @enabled int = 0;

	SELECT @usuarioExists = ID_Usuario, @contadorValid = CII, @passwordMatch = CAST(CASE WHEN clave = @password THEN 1 ELSE 0 END AS bit) FROM Usuarios WHERE usuario = @usuario

	IF (@usuarioExists = 0) SELECT 'AUTH_USR_FAILED';
	ELSE IF (@contadorValid = 3)
	BEGIN
	  UPDATE Usuarios SET habilitado = 0 WHERE ID_Usuario = @usuarioExists;
	  SELECT 'USR_BLOCKED';
	END;
	ELSE IF (@passwordMatch = 0)
	BEGIN
	  UPDATE Usuarios SET CII = CII+1 WHERE ID_Usuario = @usuarioExists;
      SELECT 'AUTH_FAILED';
	END;
	ELSE IF (@enabled = 1)
	BEGIN
	  UPDATE Usuarios SET CII = 0 WHERE ID_Usuario = @usuarioExists;
	  SELECT @usuarioExists;
	END;
	ELSE SELECT 'USR_BLOCKED';

RETURN
GO
/****** Object:  StoredProcedure [dbo].[ModificarCliente]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Modificacion de clientes
-- =============================================
CREATE PROCEDURE [dbo].[ModificarCliente]

	
	@idCliente int,
	@razonSocial varchar(20),
	@cuil varchar(20),
	@tipoCliente varchar(20),
	@dni varchar(20),
	@nombre varchar(50),
	@apellido varchar(50),
	@sexo varchar(20),
	@fechaNacimiento date


AS
	DECLARE @Persona_FK int;

	SELECT @Persona_FK = FK_Persona FROM Cliente WHERE ID_Cliente = @idCliente

	UPDATE Cliente 
	SET 
		razonSocial = @razonSocial,
		cuil = @cuil,
		tipoCliente = @tipoCliente
	WHERE 
		ID_Cliente = @idCliente

	UPDATE Personas 
	SET
		dni = @dni,
		nombre = @nombre,
		apellido = @apellido,
		sexo = @sexo,
		fechaNacimiento = @fechaNacimiento
	WHERE
		ID_Persona = @Persona_FK
GO
/****** Object:  StoredProcedure [dbo].[ModificarDomicilios]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/15
-- Description:	Modificacion de	Domicilios
-- =============================================
CREATE PROCEDURE [dbo].[ModificarDomicilios]

	@idCliente int,
	@calle varchar(50),
	@numero varchar(20),
	@piso int,
	@dpto varchar(5),
	@comentarios varchar(100),
	@codPostal varchar(20),
	@tipoDomicilio varchar(20),
	@fk_localidad int
	



AS

  DECLARE @personaId int;

  SELECT @personaId = (SELECT FK_Persona FROM dbo.Cliente 
  WHERE ID_Cliente = @idCliente);
	
	INSERT INTO Domicilio(calle,numero,piso,dpto, comentarios, codPostal,tipoDomicilio, FK_Localidad, FK_Persona)
	VALUES (@calle, @numero, @piso, @dpto, @comentarios, @codPostal, @tipoDomicilio, @fk_localidad, @personaId)

	
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[ModificarTelefonos]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Modificacion de telefonos de cliente
-- =============================================
CREATE PROCEDURE [dbo].[ModificarTelefonos]

@idCliente int,
@tipo varchar(20),
@numero varchar(30)

AS
  SET NOCOUNT ON;

  DECLARE @personaId int;

  SELECT @personaId = (SELECT FK_Persona FROM dbo.Cliente 
  WHERE ID_Cliente = @idCliente);


  	INSERT INTO Telefono(tipo,numero, FK_Persona)
	VALUES (@tipo, @numero, @personaId)

GO
/****** Object:  StoredProcedure [dbo].[ModificarUsuario]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Modificacion de Usuarios
-- =============================================
CREATE PROCEDURE [dbo].[ModificarUsuario]

	
	@idUsuario int,
	@fkPregunta int,
	@respuesta varchar(20),
	@clave varchar(20),
	@dni varchar(20),
	@nombre varchar(50),
	@apellido varchar(50),
	@sexo varchar(20),
	@fechaNacimiento date


AS
	DECLARE @Persona_FK int;

	SELECT @Persona_FK = FK_Persona FROM Usuarios WHERE ID_Usuario = @idUsuario

	UPDATE Usuarios
	SET 
		FK_Pregunta = @fkPregunta,
		respuesta = @respuesta,
		clave = @clave
	WHERE 
		ID_Usuario = @idUsuario

	UPDATE Personas 
	SET
		dni = @dni,
		nombre = @nombre,
		apellido = @apellido,
		sexo = @sexo,
		fechaNacimiento = @fechaNacimiento
	WHERE
		ID_Persona = @Persona_FK
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCliente]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Obtiene cliente para poder llenar campos y editar
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerCliente]

@idCliente int

AS
  SET NOCOUNT ON;

  DECLARE @personaId int;
  
  IF ((SELECT COUNT(*) FROM Cliente WHERE ID_Cliente = @idCliente) = 0 )
    BEGIN
	  SELECT 'El cliente no existe'
    END;

SELECT ID_Cliente, razonSocial, cuil, tipoCliente, FK_Persona, dni, nombre,apellido, sexo, fechaNacimiento FROM Cliente, Personas WHERE ID_Cliente = @idCliente AND (Personas.ID_Persona = FK_Persona);
GO
/****** Object:  StoredProcedure [dbo].[ObtenerDomicilios]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Obtiene los domicilios para poder editar personas
-- Params: Recibe como parametro un id de persona, el cual obtengo de la query anterior (Obtener cliente) de FK Persona. Lo mismo puedo hacer con los usuarios y los pilotos
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerDomicilios]

@id int

AS
  SET NOCOUNT ON;

  
  IF ((SELECT COUNT(*) FROM Domicilio WHERE FK_Persona = @id) = 0 )
    BEGIN
	  SELECT 'La persona no tiene domicilios'
    END;

SELECT d.ID_Domicilio, d.calle, d.numero, d.piso, d.dpto, d.comentarios, d.codPostal, d.tipoDomicilio, d.FK_Persona, l.ID_Localidad, l.descripcion, p.ID_Provincia, p.descripcion, ps.ID_Pais, ps.nombre FROM Domicilio d inner JOIN Localidades l ON l.ID_Localidad = d.FK_Localidad inner JOIN Provincias p ON p.ID_Provincia = l.FK_Provincia inner JOIN Pais ps ON ps.ID_Pais = p.FK_Pais where d.FK_Persona = @id;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerMails]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Obtiene los mails para poder editar personas
-- Params: Recibe como parametro un id de persona, el cual obtengo de la query anterior (Obtener cliente) de FK Persona. Lo mismo puedo hacer con los usuarios y los pilotos
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerMails]

@id int

AS
  SET NOCOUNT ON;

  
  IF ((SELECT COUNT(*) FROM Mails WHERE FK_Persona = @id) = 0 )
    BEGIN
	  SELECT 'La persona no tiene mails'
    END;

SELECT * FROM Mails WHERE FK_Persona = @id;

/****** Object:  StoredProcedure [dbo].[BorrarMails]    Script Date: 07/04/2019 19:53:04 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ObtenerPersona]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Obtiene cliente para poder llenar campos y editar
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerPersona]

@dniPersona varchar(20)

AS
  SET NOCOUNT ON;
  
  SELECT ID_Persona, dni, nombre, apellido, sexo, fechaNacimiento FROM Personas where dni = @dniPersona;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerTelefonos]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Obtiene los telefonos para poder editar personas
-- Params: Recibe como parametro un id de persona, el cual obtengo de la query anterior (Obtener cliente) de FK Persona. Lo mismo puedo hacer con los usuarios y los pilotos
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerTelefonos]

@id int

AS
  SET NOCOUNT ON;

  
  IF ((SELECT COUNT(*) FROM Telefono WHERE FK_Persona = @id) = 0 )
    BEGIN
	  SELECT 'La persona no tiene telefonos'
    END;

SELECT * FROM Telefono WHERE FK_Persona = @id;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuario]    Script Date: 17/07/2019 23:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Obtiene cliente para poder llenar campos y editar
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerUsuario]

@dniPersona varchar(20)

AS
  SET NOCOUNT ON;
  
  SELECT ID_Persona, dni, nombre, apellido, sexo, fechaNacimiento FROM Personas where dni = @dniPersona;
GO
USE [master]
GO
ALTER DATABASE [UAI_GESTION_AGUILA] SET  READ_WRITE 
GO
