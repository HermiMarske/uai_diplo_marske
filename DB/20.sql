USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[LogIn]    Script Date: 12/3/2019 22:01:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Logueo de usuario
-- =============================================
CREATE PROCEDURE [dbo].[LogIn]

@usuario varchar,
@password varchar

AS
	SET NOCOUNT ON;
	DECLARE @usuarioID int
	DECLARE @usuarioBD varchar
	DECLARE @passwordBD varchar
	DECLARE @contador int

	SELECT @usuarioID = ID_Usuario FROM Usuarios WHERE usuario = @usuario

	SELECT @usuarioBD = usuario FROM Usuarios WHERE ID_Usuario = @usuarioID

	SELECT @passwordBD = clave FROM Usuarios WHERE ID_Usuario = @usuarioID

	SELECT @contador = CII FROM Usuarios WHERE ID_Usuario = @usuarioID

	IF (@usuarioID = null)
    BEGIN
	  SELECT 'AUTH_USR_FAILED'
    END;

	IF ((@passwordBD = @password) AND (@usuario = @usuarioBD) AND (@contador <= 3))
	BEGIN
		UPDATE Usuarios SET CII = 0 WHERE ID_Usuario = @usuarioID
		SELECT 'AUTH_OK'
	END;

	IF ((@passwordBD != @password) AND (@usuario = @usuarioBD) AND (@contador <= 3))
	BEGIN
		UPDATE Usuarios SET CII = @contador + 1 WHERE ID_Usuario = @usuarioID
		SELECT 'AUTH_FAILED'
	END;

	IF ((@passwordBD != @password) AND (@usuario = @usuarioBD) AND (@contador = 3))
	BEGIN
		UPDATE Usuarios SET habilitado = 'NO' WHERE ID_Usuario = @usuarioID
		SELECT 'USR_BLOCKED'
	END;

RETURN
