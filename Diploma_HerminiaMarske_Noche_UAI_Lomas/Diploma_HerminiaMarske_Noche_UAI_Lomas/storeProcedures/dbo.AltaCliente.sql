CREATE PROCEDURE [dbo].[AltaCliente]
	@razonSocial varchar(20),
	@cuil varchar(20)
AS
	INSERT INTO Clientes VALUES(@razonSocial, @cuil)
	
RETURN 0
