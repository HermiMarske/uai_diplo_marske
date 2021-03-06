USE [UAI_GESTION_AGUILA]
GO
/****** Object:  Table [dbo].[Actividades]    Script Date: 04/02/2019 22:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividades](
	[idActividad] [int] NOT NULL,
	[fecha] [date] NULL,
	[horaInicio] [time](7) NULL,
	[horaFin] [time](7) NULL,
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
/****** Object:  Table [dbo].[Aviones]    Script Date: 04/02/2019 22:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aviones](
	[idAvion] [int] NOT NULL,
	[marca] [varchar](50) NULL,
	[modelo] [varchar](50) NULL,
	[patente] [varchar](50) NULL,
	[habilitacionAvionFK] [int] NULL,
 CONSTRAINT [PK_Aviones] PRIMARY KEY CLUSTERED 
(
	[idAvion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 04/02/2019 22:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[idBitacora] [int] NOT NULL,
	[fecha] [date] NULL,
	[hora] [time](7) NULL,
	[descripcion] [varchar](500) NULL,
	[criticidad] [varchar](10) NULL,
	[dvh] [int] NULL,
	[usuarioFK] [int] NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[idBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 04/02/2019 22:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ID_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[razonSocial] [varchar](50) NULL,
	[cuil] [varchar](50) NULL,
	[tipoCliente] [bit] NULL,
	[FK_Persona] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Domicilio]    Script Date: 04/02/2019 22:36:56 ******/
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
/****** Object:  Table [dbo].[DVV]    Script Date: 04/02/2019 22:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVV](
	[idDVV] [int] NOT NULL,
	[tabla] [int] NULL,
	[dvv] [bigint] NULL,
 CONSTRAINT [PK_DVV] PRIMARY KEY CLUSTERED 
(
	[idDVV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia]    Script Date: 04/02/2019 22:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[idFamilia] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
	[dvh] [int] NULL,
 CONSTRAINT [PK_Familia] PRIMARY KEY CLUSTERED 
(
	[idFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia_Patente]    Script Date: 04/02/2019 22:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Patente](
	[idFamiliaPatente] [int] NOT NULL,
	[familiaFK] [int] NULL,
	[patenteFK] [int] NULL,
	[dvh] [int] NULL,
 CONSTRAINT [PK_Familia_Patente] PRIMARY KEY CLUSTERED 
(
	[idFamiliaPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HabilitacionAviones]    Script Date: 04/02/2019 22:36:56 ******/
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
/****** Object:  Table [dbo].[HabilitacionesPilotos]    Script Date: 04/02/2019 22:36:56 ******/
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
/****** Object:  Table [dbo].[Idiomas]    Script Date: 04/02/2019 22:36:56 ******/
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
/****** Object:  Table [dbo].[Localidades]    Script Date: 04/02/2019 22:36:56 ******/
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
/****** Object:  Table [dbo].[Pais]    Script Date: 04/02/2019 22:36:56 ******/
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
/****** Object:  Table [dbo].[Patente]    Script Date: 04/02/2019 22:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[idPatente] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
	[dvh] [int] NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[idPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 04/02/2019 22:36:56 ******/
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
/****** Object:  Table [dbo].[Pilotos]    Script Date: 04/02/2019 22:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pilotos](
	[idPiloto] [int] NOT NULL,
	[licencia] [varchar](50) NULL,
	[dvh] [int] NULL,
	[habilitacionPilotoFK] [int] NULL,
	[psicofisicoFK] [int] NULL,
	[personaFK] [int] NULL,
 CONSTRAINT [PK_Pilotos] PRIMARY KEY CLUSTERED 
(
	[idPiloto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 04/02/2019 22:36:56 ******/
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
/****** Object:  Table [dbo].[Psicofisicos]    Script Date: 04/02/2019 22:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Psicofisicos](
	[idPsicofisico] [int] NOT NULL,
	[fechaInicio] [date] NULL,
	[fechaFin] [date] NULL,
 CONSTRAINT [PK_Psicofisicos] PRIMARY KEY CLUSTERED 
(
	[idPsicofisico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 04/02/2019 22:36:56 ******/
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
/****** Object:  Table [dbo].[TipoPersonas]    Script Date: 04/02/2019 22:36:56 ******/
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
/****** Object:  Table [dbo].[Usuario_Familia]    Script Date: 04/02/2019 22:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Familia](
	[idUsuFam] [int] NOT NULL,
	[familiaFK] [int] NULL,
	[usuarioFK] [int] NULL,
	[dvh] [int] NULL,
 CONSTRAINT [PK_Usuario_Familia] PRIMARY KEY CLUSTERED 
(
	[idUsuFam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Patente]    Script Date: 04/02/2019 22:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Patente](
	[idUsuarioPatente] [int] NOT NULL,
	[patenteFK] [int] NULL,
	[usuarioFK] [int] NULL,
	[dvh] [int] NULL,
 CONSTRAINT [PK_Usuario_Patente] PRIMARY KEY CLUSTERED 
(
	[idUsuarioPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 04/02/2019 22:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] NOT NULL,
	[usuario] [varchar](50) NULL,
	[clave] [varchar](500) NULL,
	[cii] [int] NULL,
	[habilitado] [bit] NULL,
	[dvh] [int] NULL,
	[idPersonaFK] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Actividades]  WITH CHECK ADD  CONSTRAINT [FK_Actividades_Actividades] FOREIGN KEY([idActividad])
REFERENCES [dbo].[Actividades] ([idActividad])
GO
ALTER TABLE [dbo].[Actividades] CHECK CONSTRAINT [FK_Actividades_Actividades]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Usuarios]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Usuarios1] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Usuarios1]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Usuarios2] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Usuarios2]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Usuarios3] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Usuarios3]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Usuarios4] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Usuarios4]
GO
/****** Object:  StoredProcedure [dbo].[AltaCliente]    Script Date: 04/02/2019 22:36:56 ******/
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
	@dni varchar(20),
	@nombre varchar(50),
	@apellido varchar(50),
	@sexo varchar(20),
	@fechaNacimiento date


AS
	DECLARE @Persona_FK int;
	INSERT INTO Personas(dni,nombre,apellido,sexo, fechaNacimiento) VALUES (@dni, @nombre, @apellido, @sexo, @fechaNacimiento)
	SELECT @Persona_FK = SCOPE_IDENTITY()
	INSERT INTO Cliente(razonSocial,cuil,FK_Persona) VALUES(@razonSocial, @cuil,@Persona_FK)

	
SELECT @Persona_FK

GO
/****** Object:  StoredProcedure [dbo].[AltaDomicilio]    Script Date: 04/02/2019 22:36:56 ******/
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
GO
/****** Object:  StoredProcedure [dbo].[AltaTelefono]    Script Date: 04/02/2019 22:36:56 ******/
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
GO
/****** Object:  StoredProcedure [dbo].[ListarLocalidades]    Script Date: 04/02/2019 22:36:56 ******/
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
/****** Object:  StoredProcedure [dbo].[ListarPaises]    Script Date: 04/02/2019 22:36:56 ******/
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
/****** Object:  StoredProcedure [dbo].[ListarProvincias]    Script Date: 04/02/2019 22:36:56 ******/
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
