USE [UAI_GESTION_AGUILA]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 10/2/2019 01:32:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[ID_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[razonSocial] [varchar](50) NULL,
	[cuil] [varchar](50) NULL,
	[tipoCliente] [varchar](50) NULL,
	[FK_Persona] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


