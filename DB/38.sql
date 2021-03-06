USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ListarPatentesFamilias]    Script Date: 5/5/2019 03:06:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 5/5/2019
-- Description:  Lista de patentes de familias bleh
-- =============================================
CREATE PROCEDURE [dbo].[ListarPatentesFamilias]

AS
  SET NOCOUNT ON;

 SELECT f.idFamilia, f.descripcion, p.idPatente, p.codigo
 FROM Familia f LEFT JOIN Familia_Patente pf ON f.idFamilia = pf.familiaFK, 
 Patente p WHERE p.idPatente = pf.patenteFK ORDER BY f.idFamilia; 

RETURN
