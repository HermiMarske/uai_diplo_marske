USE [UAI_GESTION_AGUILA]
GO

/****** Object:  Table [dbo].[Pilotos]    Script Date: 24/06/2019 1:00:05 ******/
DROP TABLE [dbo].[Pilotos]
GO

/****** Object:  Table [dbo].[Pilotos]    Script Date: 24/06/2019 1:00:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pilotos](
	[ID_Piloto] [int] IDENTITY(1,1) NOT NULL,
	[licencia] [varchar](70) NULL,
	[dvh] [int] NULL,
	[fechaInicioApto] [date] NULL,
	[fechaVencimientoApto] [date] NULL,
	[FK_Persona] [int] NULL,
 CONSTRAINT [PK_Pilotos] PRIMARY KEY CLUSTERED 
(
	[ID_Piloto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

DROP TABLE [dbo].[Psicofisicos]
GO
