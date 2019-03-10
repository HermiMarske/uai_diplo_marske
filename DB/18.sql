USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[BorrarDomicilios]    Script Date: 10/3/2019 16:01:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Borrar Domicilios de cliente
-- =============================================
CREATE PROCEDURE [dbo].[BorrarDomicilios]

@idCliente int

AS
  SET NOCOUNT ON;

  DECLARE @personaId int;

  SELECT @personaId = (SELECT FK_Persona FROM dbo.Cliente 
  WHERE ID_Cliente = @idCliente);

  DELETE FROM Domicilio WHERE FK_Persona = @personaId;
