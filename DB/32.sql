USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuarios]    Script Date: 16/4/2019 22:48:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/11
-- Description:	Listado de Usuarios
-- =============================================
CREATE PROCEDURE [dbo].[ListarUsuarios]

AS
	SET NOCOUNT ON;
	SELECT ID_Usuario, usuario, FK_Persona,nombre,apellido 
	FROM Usuarios, Personas
	WHERE FK_Persona = ID_Persona
RETURN
