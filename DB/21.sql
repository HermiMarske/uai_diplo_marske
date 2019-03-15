USE [UAI_GESTION_AGUILA]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 15/3/2019 00:08:54 ******/
DROP TABLE [dbo].[Usuarios]
GO




USE [UAI_GESTION_AGUILA]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 15/3/2019 00:06:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](20) NULL,
	[clave] [varchar](500) NULL,
	[CII] [int] NULL,
	[habilitado] [bit]NULL,
	[DVH] [int] NULL,
	[FK_Persona] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

