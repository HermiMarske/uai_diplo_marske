USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ListarPilotos]    Script Date: 24/06/2019 22:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/11
-- Description:	Listado de Usuarios
-- =============================================
CREATE PROCEDURE [dbo].[ListarPilotos]

AS
	SET NOCOUNT ON;
	SELECT ID_Piloto, licencia, FK_Persona,nombre,apellido 
	FROM Pilotos, Personas
	WHERE FK_Persona = ID_Persona
RETURN
