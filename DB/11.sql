USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerTelefonos]    Script Date: 13/02/2019 21:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Obtiene los telefonos para poder editar personas
-- Params: Recibe como parametro un id de persona, el cual obtengo de la query anterior (Obtener cliente) de FK Persona. Lo mismo puedo hacer con los usuarios y los pilotos
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerTelefonos]

@id int

AS
  SET NOCOUNT ON;

  
  IF ((SELECT COUNT(*) FROM Telefono WHERE FK_Persona = @id) = 0 )
    BEGIN
	  SELECT 'La persona no tiene telefonos'
    END;

SELECT * FROM Telefono WHERE FK_Persona = @id;