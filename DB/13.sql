USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCliente]    Script Date: 18/2/2019 01:11:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Obtiene cliente para poder llenar campos y editar
-- =============================================
ALTER PROCEDURE [dbo].[ObtenerCliente]

@idCliente int

AS
  SET NOCOUNT ON;

  DECLARE @personaId int;
  
  IF ((SELECT COUNT(*) FROM Cliente WHERE ID_Cliente = @idCliente) = 0 )
    BEGIN
	  SELECT 'El cliente no existe'
    END;

SELECT ID_Cliente, razonSocial, cuil, tipoCliente, FK_Persona, dni, nombre,apellido, sexo, fechaNacimiento FROM Cliente, Personas WHERE ID_Cliente = @idCliente AND (Personas.ID_Persona = FK_Persona);