USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ListarFamilias]    Script Date: 23/04/2019 22:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Listado de Familias
-- =============================================
CREATE PROCEDURE [dbo].[ListarFamilias]

AS
	SET NOCOUNT ON;
	SELECT idFamilia, descripcion
	FROM Familia

RETURN

INSERT INTO Familia (descripcion) values 
('ADMIN_SEGURIDAD'), 
('ADMIN_USUARIOS'),
('ADMIN_EMPLEADOS'),
('ADMIN_CLIENTES'),
('ADMIN_ACTIVIDADES'),
('ADMIN_RECURSOS')    


/****** Object:  Table [dbo].[Patente]    Script Date: 23/04/2019 23:35:58 ******/
DROP TABLE [dbo].[Patente]
GO

/****** Object:  Table [dbo].[Patente]    Script Date: 23/04/2019 23:35:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Patente](
	[idPatente] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](20) NOT NULL,
	[dvh] [int] NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[idPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO Patente (codigo) VALUES 
('ADM_CLIENTES_ALTA'),
('ADM_CLIENTES_BAJA'),
('ADM_CLIENTES_VER'),
('ADM_CLIENTES_MODIF'),

('ADM_USUARIOS_ALTA'),
('ADM_USUARIOS_BAJA'),
('ADM_USUARIOS_VER'),
('ADM_USUARIOS_MODIF'),
('ADM_USUARIOS_PERM')




