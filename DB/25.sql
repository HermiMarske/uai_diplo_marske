USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuario]    Script Date: 03/04/2019 23:19:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Obtiene cliente para poder llenar campos y editar
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerUsuario]

@dniPersona varchar(20)

AS
  SET NOCOUNT ON;
  
  SELECT ID_Persona, dni, nombre, apellido, sexo, fechaNacimiento FROM Personas where dni = @dniPersona;