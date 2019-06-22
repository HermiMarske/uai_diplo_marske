USE [UAI_GESTION_AGUILA]
GO

ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [DF__Usuarios__habili__1A34DF26]
GO

ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [DF__Usuarios__CII__1940BAED]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 20/6/2019 14:05:27 ******/
DROP TABLE [dbo].[Usuarios]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 20/6/2019 14:05:27 ******/
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

ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (('es-AR')) FOR [idioma]
GO