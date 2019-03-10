USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ModificarDomicilios]    Script Date: 10/3/2019 16:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/15
-- Description:	Modificacion de	Domicilios
-- =============================================
CREATE PROCEDURE [dbo].[ModificarDomicilios]

	@idCliente int,
	@calle varchar(50),
	@numero varchar(20),
	@piso int,
	@dpto varchar(5),
	@comentarios varchar(100),
	@codPostal varchar(20),
	@tipoDomicilio varchar(20),
	@fk_localidad int
	



AS

  DECLARE @personaId int;

  SELECT @personaId = (SELECT FK_Persona FROM dbo.Cliente 
  WHERE ID_Cliente = @idCliente);
	
	INSERT INTO Domicilio(calle,numero,piso,dpto, comentarios, codPostal,tipoDomicilio, FK_Localidad, FK_Persona)
	VALUES (@calle, @numero, @piso, @dpto, @comentarios, @codPostal, @tipoDomicilio, @fk_localidad, @personaId)

	
RETURN 0
