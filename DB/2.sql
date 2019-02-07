SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Listado de clientes
-- =============================================
ALTER PROCEDURE [dbo].[ListarClientes]

AS
	SET NOCOUNT ON;
	SELECT ID_Cliente, razonSocial, cuil, tipoCliente,FK_Persona,ID_Persona,dni,nombre,apellido,sexo,fechaNacimiento 
	FROM Cliente, Personas
	WHERE FK_Persona = ID_Persona
RETURN
