USE [UAI_GESTION_AGUILA]
GO

/****** Object:  Table [dbo].[Patente]    Script Date: 08/04/2019 00:42:21 ******/
DROP TABLE [dbo].[Patente]
GO

/****** Object:  Table [dbo].[Patente]    Script Date: 08/04/2019 00:42:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Patente](
	[idPatente] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](20) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[dvh] [int] NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[idPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Familia]    Script Date: 08/04/2019 00:43:53 ******/
DROP TABLE [dbo].[Familia]
GO

/****** Object:  Table [dbo].[Familia]    Script Date: 08/04/2019 00:43:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Familia](
	[idFamilia] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[dvh] [int] NULL,
 CONSTRAINT [PK_Familia] PRIMARY KEY CLUSTERED 
(
	[idFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Familia_Patente]    Script Date: 08/04/2019 00:45:05 ******/
DROP TABLE [dbo].[Familia_Patente]
GO

/****** Object:  Table [dbo].[Familia_Patente]    Script Date: 08/04/2019 00:45:05 ******/
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

/****** Object:  Table [dbo].[Usuario_Patente]    Script Date: 08/04/2019 01:03:17 ******/
DROP TABLE [dbo].[Usuario_Patente]
GO

/****** Object:  Table [dbo].[Usuario_Patente]    Script Date: 08/04/2019 01:03:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario_Patente](
	[idUsuarioPatente] [int] IDENTITY(1,1) NOT NULL,
	[patenteFK] [int] NOT NULL,
	[usuarioFK] [int] NOT NULL,
	[dvh] [int] NULL,
 CONSTRAINT [PK_Usuario_Patente] PRIMARY KEY CLUSTERED 
(
	[idUsuarioPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Usuario_Familia]    Script Date: 08/04/2019 01:03:57 ******/
DROP TABLE [dbo].[Usuario_Familia]
GO

/****** Object:  Table [dbo].[Usuario_Familia]    Script Date: 08/04/2019 01:03:57 ******/
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

