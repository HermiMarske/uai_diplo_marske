USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerDomicilios]    Script Date: 28/02/2019 02:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Obtiene los domicilios para poder editar personas
-- Params: Recibe como parametro un id de persona, el cual obtengo de la query anterior (Obtener cliente) de FK Persona. Lo mismo puedo hacer con los usuarios y los pilotos
-- =============================================
ALTER PROCEDURE [dbo].[ObtenerDomicilios]

@id int

AS
  SET NOCOUNT ON;

  
  IF ((SELECT COUNT(*) FROM Domicilio WHERE FK_Persona = @id) = 0 )
    BEGIN
	  SELECT 'La persona no tiene domicilios'
    END;

SELECT d.ID_Domicilio, d.calle, d.numero, d.piso, d.dpto, d.comentarios, d.codPostal, d.tipoDomicilio, d.FK_Persona, l.ID_Localidad, l.descripcion, p.ID_Provincia, p.descripcion, ps.ID_Pais, ps.nombre FROM Domicilio d inner JOIN Localidades l ON l.ID_Localidad = d.FK_Localidad inner JOIN Provincias p ON p.ID_Provincia = l.FK_Provincia inner JOIN Pais ps ON ps.ID_Pais = p.FK_Pais where d.FK_Persona = @id;