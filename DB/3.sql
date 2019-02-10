USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[AltaCliente]    Script Date: 10/2/2019 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Alta de clientes
-- =============================================
ALTER PROCEDURE [dbo].[AltaCliente]

	

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
	INSERT INTO Personas(dni,nombre,apellido,sexo, fechaNacimiento) VALUES (@dni, @nombre, @apellido, @sexo, @fechaNacimiento)
	SELECT @Persona_FK = SCOPE_IDENTITY()
	INSERT INTO Cliente(razonSocial,cuil,tipoCliente,FK_Persona) VALUES(@razonSocial, @cuil,@tipoCliente,@Persona_FK)

	
SELECT @Persona_FK

