USE [UAI_GESTION_AGUILA]
GO

/****** Object:  Table [dbo].[Aviones]    Script Date: 23/06/2019 3:26:52 ******/
DROP TABLE [dbo].[Aviones]
GO

/****** Object:  Table [dbo].[Aviones]    Script Date: 23/06/2019 3:26:52 ******/
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


