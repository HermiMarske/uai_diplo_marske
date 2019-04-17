USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[BorrarUsuario]    Script Date: 10/4/2019 23:57:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Borrado permanente de USUARIO
-- =============================================
CREATE PROCEDURE [dbo].[BorrarUsuario]

@idUsuario int

AS
  SET NOCOUNT ON;

  DECLARE @personaId int;

  SELECT @personaId = (SELECT FK_Persona FROM dbo.Usuarios
  WHERE ID_Usuario = @idUsuario);



  DELETE FROM Usuarios WHERE ID_Usuario = @idUsuario;
  IF ((SELECT COUNT(*) FROM Pilotos WHERE FK_Persona = @personaId) = 0 OR (SELECT COUNT(*) FROM Cliente WHERE FK_Persona = @personaId) = 0)
    BEGIN
	  DELETE FROM Telefono WHERE FK_Persona = @personaId;
	  DELETE FROM Domicilio WHERE FK_Persona = @personaId;
	  DELETE FROM Personas WHERE ID_Persona = @personaId;
	  SELECT 'Se borraron todos los datos del cliente'
    END;

SELECT 'Se borraron solo los datos del cliente'