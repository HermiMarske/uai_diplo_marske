
USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ListarPatentes]    Script Date: 25/4/2019 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 25/4/2019
-- Description:  Lista de patentes por familia usando asociacion de tabla de coso
-- =============================================
CREATE PROCEDURE [dbo].[ListarPatentes]

@idFamilia int

AS
  SET NOCOUNT ON;

SELECT p.idPatente, p.codigo
 FROM Patente p JOIN Familia_Patente pf ON p.idPatente = pf.patenteFK 
 WHERE pf.familiaFK = 2

RETURN
