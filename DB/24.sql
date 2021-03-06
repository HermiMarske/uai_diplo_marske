USE [UAI_GESTION_AGUILA]
GO
ALTER TABLE dbo.Usuarios ALTER COLUMN clave VARCHAR(2000) NOT NULL
GO
ALTER TABLE dbo.Usuarios ALTER COLUMN usuario VARCHAR(20) NOT NULL
GO
ALTER TABLE dbo.Usuarios ALTER COLUMN CII INT NOT NULL;
GO
ALTER TABLE dbo.Usuarios ADD DEFAULT 0 FOR CII;
GO
ALTER TABLE dbo.Usuarios ALTER COLUMN habilitado BIT NOT NULL;
GO
ALTER TABLE dbo.Usuarios ADD DEFAULT 1 FOR habilitado;
GO
/****** Object:  StoredProcedure [dbo].[LogIn]    Script Date: 16/3/2019 18:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Logueo de usuario
-- =============================================
ALTER PROCEDURE [dbo].[LogIn]

@usuario varchar(20),
@password varchar(2000)

AS
	SET NOCOUNT ON;
	DECLARE @usuarioExists int = 0;
	DECLARE @contadorValid int = 0;
	DECLARE @passwordMatch int = 0;
	DECLARE @enabled int = 0;

	SELECT @usuarioExists = ID_Usuario, @contadorValid = CII, @passwordMatch = CAST(CASE WHEN clave = @password THEN 1 ELSE 0 END AS bit) FROM Usuarios WHERE usuario = @usuario

	IF (@usuarioExists = 0) SELECT 'AUTH_USR_FAILED';
	ELSE IF (@contadorValid = 3)
	BEGIN
	  UPDATE Usuarios SET habilitado = 0 WHERE ID_Usuario = @usuarioExists;
	  SELECT 'USR_BLOCKED';
	END;
	ELSE IF (@passwordMatch = 0)
	BEGIN
	  UPDATE Usuarios SET CII = CII+1 WHERE ID_Usuario = @usuarioExists;
      SELECT 'AUTH_FAILED';
	END;
	ELSE IF (@enabled = 1)
	BEGIN
	  UPDATE Usuarios SET CII = 0 WHERE ID_Usuario = @usuarioExists;
	  SELECT @usuarioExists;
	END;
	ELSE SELECT 'USR_BLOCKED';

RETURN