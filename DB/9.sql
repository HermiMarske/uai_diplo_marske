USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[BorrarCliente]    Script Date: 13/02/2019 23:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Borrado permanente de Cliente
-- =============================================
CREATE PROCEDURE [dbo].[BorrarCliente]

@idCliente int

AS
  SET NOCOUNT ON;

  DECLARE @personaId int;

  SELECT @personaId = (SELECT FK_Persona FROM dbo.Cliente 
  WHERE ID_Cliente = @idCliente);



  DELETE FROM Cliente WHERE ID_Cliente = @idCliente;
  IF ((SELECT COUNT(*) FROM Pilotos WHERE FK_Persona = @personaId) = 0 OR (SELECT COUNT(*) FROM Usuarios WHERE FK_Persona = @personaId) = 0)
    BEGIN
	  DELETE FROM Telefono WHERE FK_Persona = @personaId;
	  DELETE FROM Domicilio WHERE FK_Persona = @personaId;
	  DELETE FROM Personas WHERE ID_Persona = @personaId;
	  SELECT 'Se borraron todos los datos del cliente'
    END;

SELECT 'Se borraron solo los datos del cliente'