USE [UAI_GESTION_AGUILA]
GO

/****** Object:  Table [dbo].[Familia]    Script Date: 08/07/2019 20:48:25 ******/
DROP TABLE [dbo].[Familia]
GO

/****** Object:  Table [dbo].[Familia]    Script Date: 08/07/2019 20:48:25 ******/
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


