USE [UAI_GESTION_AGUILA]
GO

/****** Object:  Table [dbo].[Patente]    Script Date: 08/07/2019 20:49:39 ******/
DROP TABLE [dbo].[Patente]
GO

/****** Object:  Table [dbo].[Patente]    Script Date: 08/07/2019 20:49:39 ******/
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


