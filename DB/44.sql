USE [UAI_GESTION_AGUILA]
GO

/****** Object:  Table [dbo].[Bitacora]    Script Date: 27/05/2019 22:47:58 ******/
DROP TABLE [dbo].[Bitacora]
GO



USE [UAI_GESTION_AGUILA]
GO

/****** Object:  Table [dbo].[Bitacora]    Script Date: 19/05/2019 3:19:47 ******/
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
	[dvh] [int] NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[ID_Bitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO