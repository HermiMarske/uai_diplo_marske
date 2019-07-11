USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuarios]    Script Date: 11/7/2019 01:47:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/07/11
-- Description:	Listado de Usuarios
-- =============================================
ALTER PROCEDURE [dbo].[ListarUsuarios]

AS
	SET NOCOUNT ON;
	SELECT ID_Usuario, usuario, FK_Persona,nombre,apellido, habilitado
	FROM Usuarios, Personas
	WHERE FK_Persona = ID_Persona
RETURN
