USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCliente]    Script Date: 13/02/2019 21:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Obtiene cliente para poder llenar campos y editar
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerCliente]

@idCliente int

AS
  SET NOCOUNT ON;

  DECLARE @personaId int;
  
  IF ((SELECT COUNT(*) FROM Cliente WHERE ID_Cliente = @idCliente) = 0 )
    BEGIN
	  SELECT 'El cliente no existe'
    END;

SELECT * FROM Cliente, Personas WHERE ID_Cliente = @idCliente;