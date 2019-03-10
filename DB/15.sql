USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[AltaCliente]    Script Date: 9/3/2019 23:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Modificacion de clientes
-- =============================================
CREATE PROCEDURE [dbo].[ModificarCliente]

	
	@idCliente int,
	@razonSocial varchar(20),
	@cuil varchar(20),
	@tipoCliente varchar(20),
	@dni varchar(20),
	@nombre varchar(50),
	@apellido varchar(50),
	@sexo varchar(20),
	@fechaNacimiento date


AS
	DECLARE @Persona_FK int;

	SELECT @Persona_FK = FK_Persona FROM Cliente WHERE ID_Cliente = @idCliente

	UPDATE Cliente 
	SET 
		razonSocial = @razonSocial,
		cuil = @cuil,
		tipoCliente = @tipoCliente
	WHERE 
		ID_Cliente = @idCliente

	UPDATE Personas 
	SET
		dni = @dni,
		nombre = @nombre,
		apellido = @apellido,
		sexo = @sexo,
		fechaNacimiento = @fechaNacimiento
	WHERE
		ID_Persona = @Persona_FK


