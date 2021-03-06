USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ListarActividades]    Script Date: 02/07/2019 23:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/11
-- Description:	Listado de Actividades
-- =============================================
CREATE PROCEDURE [dbo].[ListarActividades]

AS
	SET NOCOUNT ON;
	SELECT a.idActividad, a.horaInicio, l.descripcion, c.razonSocial 
	FROM Actividades a, Localidades l, Cliente c
	WHERE a.clienteFK = c.ID_Cliente AND a.localidadFK = l.ID_Localidad
RETURN

