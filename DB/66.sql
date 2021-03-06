USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuarios]    Script Date: 21/7/2019 03:44:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/11
-- Description:	Listado de Usuarios
-- =============================================
ALTER PROCEDURE [dbo].[ListarUsuarios]

AS
	SET NOCOUNT ON;
	SELECT ID_Usuario, usuario, FK_Persona,nombre,apellido, habilitado
	FROM Usuarios, Personas
	WHERE FK_Persona = ID_Persona AND deleteTime IS NULL
RETURN
