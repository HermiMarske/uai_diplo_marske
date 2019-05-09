USE [UAI_GESTION_AGUILA]
GO

/****** Object:  Table [dbo].[Usuario_Patente]    Script Date: 8/5/2019 22:31:57 ******/
DROP TABLE [dbo].[Usuario_Patente]
GO


/****** Object:  Table [dbo].[Usuario_Patente]    Script Date: 8/5/2019 22:22:13 ******/
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


