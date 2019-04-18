USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[BorrarUsuario]    Script Date: 18/04/2019 07:56:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Borrado permanente de USUARIO
-- =============================================
ALTER PROCEDURE [dbo].[BorrarUsuario]

@idUsuario int

AS
  SET NOCOUNT ON;

  DECLARE @personaId int;

  SELECT @personaId = (SELECT FK_Persona FROM dbo.Usuarios
  WHERE ID_Usuario = @idUsuario);



  DELETE FROM Usuarios WHERE ID_Usuario = @idUsuario;
  IF (NOT((SELECT COUNT(*) FROM Pilotos WHERE FK_Persona = @personaId) = 1 OR (SELECT COUNT(*) FROM Cliente WHERE FK_Persona = @personaId) = 1))
    BEGIN
	  DELETE FROM Telefono WHERE FK_Persona = @personaId;
	  DELETE FROM Domicilio WHERE FK_Persona = @personaId;
	  DELETE FROM Personas WHERE ID_Persona = @personaId;
	  SELECT 'Se borraron todos los datos del Usuario'
    END;
  ELSE
	SELECT 'Se borraron solo los datos del Usuario'

/****** Object:  StoredProcedure [dbo].[BorrarCliente]    Script Date: 18/04/2019 08:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Borrado permanente de Cliente
-- =============================================
ALTER PROCEDURE [dbo].[BorrarCliente]

@idCliente int

AS
  SET NOCOUNT ON;

  DECLARE @personaId int;

  SELECT @personaId = (SELECT FK_Persona FROM dbo.Cliente 
  WHERE ID_Cliente = @idCliente);



  DELETE FROM Cliente WHERE ID_Cliente = @idCliente;
  IF (NOT((SELECT COUNT(*) FROM Pilotos WHERE FK_Persona = @personaId) = 1 OR (SELECT COUNT(*) FROM Usuarios WHERE FK_Persona = @personaId) = 1))
    BEGIN
	  DELETE FROM Telefono WHERE FK_Persona = @personaId;
	  DELETE FROM Domicilio WHERE FK_Persona = @personaId;
	  DELETE FROM Personas WHERE ID_Persona = @personaId;
	  SELECT 'Se borraron todos los datos del cliente'
    END;
  ELSE 
	SELECT 'Se borraron solo los datos del cliente'