USE [UAI_GESTION_AGUILA]
GO

/****** Object:  StoredProcedure [dbo].[AltaUsuario]    Script Date: 09/04/2019 21:34:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/07
-- Description:	Alta de usuarios
-- =============================================
CREATE PROCEDURE [dbo].[AltaUsuario]

	

	@dniPersona varchar(20),
	@nombre varchar(50),
	@apellido varchar(50),
	@sexo varchar(20),
	@fechaNacimiento date,
	@usuario varchar(20),
	@clave varchar(2000),
	@respuesta varchar(50),
	@fk_pregunta int


AS
	DECLARE @idPersona int = 0;
	DECLARE @idUsuario int = 0;
	SELECT TOP 1 @idPersona = ID_Persona FROM Personas WHERE dni = @dniPersona;
	SELECT TOP 1 @idUsuario = ID_Usuario FROM Usuarios WHERE FK_Persona = @idPersona;

	IF (NOT(@idPersona = 0) AND (@idUsuario = 0))
	BEGIN
		INSERT INTO Usuarios(usuario,clave, CII, habilitado, FK_Persona, respuesta, FK_Pregunta) VALUES (@usuario, @clave, 0, 1, @idPersona, @respuesta, @fk_pregunta)
		SELECT 'USER_CREATED_EXISTING_PERSON' as 'success';
	END;
	ELSE IF (@idPersona = 0 AND @dniPersona IS NULL)
		SELECT 'MISSING_DATA' as 'error';
	ELSE IF (@idUsuario = 0)
	BEGIN
		INSERT INTO Personas(dni,nombre,apellido,sexo, fechaNacimiento) VALUES (@dniPersona, @nombre, @apellido, @sexo, @fechaNacimiento)
		SELECT @idPersona = SCOPE_IDENTITY();
		
		INSERT INTO Usuarios(usuario,clave, CII, habilitado, FK_Persona, respuesta, FK_Pregunta) VALUES (@usuario, @clave, 0, 1, @idPersona, @respuesta, @fk_pregunta)
		SELECT TOP 1 'USER_CREATED_PERSON_CREATED' as 'success', @idPersona as 'ID_Persona';
	END;
	ELSE
		SELECT TOP 1 'PERSON_HAS_USER' as 'error', usuario FROM Usuarios WHERE ID_Usuario = @idUsuario;
GO

