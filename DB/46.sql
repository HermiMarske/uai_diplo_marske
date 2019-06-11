USE [UAI_GESTION_AGUILA]
GO

/****** Object:  Table [dbo].[Bitacora]    Script Date: 11/06/2019 0:46:00 ******/
DROP TABLE [dbo].[Bitacora]
GO

/****** Object:  Table [dbo].[Bitacora]    Script Date: 11/06/2019 0:46:00 ******/
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
	[DVH] [int] NULL
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[ID_Bitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

