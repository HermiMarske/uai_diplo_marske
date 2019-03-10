USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ModificarTelefonos]    Script Date: 10/3/2019 15:03:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Modificacion de telefonos de cliente
-- =============================================
CREATE PROCEDURE [dbo].[ModificarTelefonos]

@idCliente int,
@tipo varchar(20),
@numero varchar(30)

AS
  SET NOCOUNT ON;

  DECLARE @personaId int;

  SELECT @personaId = (SELECT FK_Persona FROM dbo.Cliente 
  WHERE ID_Cliente = @idCliente);


  	INSERT INTO Telefono(tipo,numero, FK_Persona)
	VALUES (@tipo, @numero, @personaId)
