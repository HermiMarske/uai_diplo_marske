USE [UAI_GESTION_AGUILA]
GO

ALTER TABLE [dbo].[Actividades] DROP CONSTRAINT [FK_Actividades_Actividades]
GO

/****** Object:  Table [dbo].[Actividades]    Script Date: 26/06/2019 0:02:22 ******/
DROP TABLE [dbo].[Actividades]
GO

/****** Object:  Table [dbo].[Actividades]    Script Date: 26/06/2019 0:02:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Actividades](
	[idActividad] [int] IDENTITY(1,1) NOT NULL,
	[horaInicio] [datetime] NULL,
	[horas] [int] NULL,
	[texto] [varchar](5000) NULL,
	[pilotoFK] [int] NULL,
	[localidadFK] [int] NULL,
	[clienteFK] [int] NULL,
	[avionFK] [int] NULL,
 CONSTRAINT [PK_Actividades] PRIMARY KEY CLUSTERED 
(
	[idActividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Actividades]  WITH CHECK ADD  CONSTRAINT [FK_Actividades_Actividades] FOREIGN KEY([idActividad])
REFERENCES [dbo].[Actividades] ([idActividad])
GO

ALTER TABLE [dbo].[Actividades] CHECK CONSTRAINT [FK_Actividades_Actividades]
GO


