USE [UAI_GESTION_AGUILA]
GO

/****** Object:  Table [dbo].[Preguntas]    Script Date: 08/04/2019 01:14:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Preguntas](
	[idPregunta] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](20) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Preguntas] PRIMARY KEY CLUSTERED 
(
	[idPregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO Preguntas (codigo, descripcion) VALUES 
	('MASCOTA', 'Nombre primera mascota'),
	('PRIMER_AMOR', 'Nombre de primer amor'),
	('PROFESOR_FAV', 'Profesor favorito'),
	('PERSONAJE_HISTORICO', 'Personaje historico favorito'),
	('APELLIDO_MADRE', 'Apellido de soltera de madre'),
	('DIBUJO_FAV', 'Dibujo animado favorito'),
	('DEPORTE_FAV', 'Deporte favorito'),
	('COMIDA_FAV', 'Comida favorita')
GO