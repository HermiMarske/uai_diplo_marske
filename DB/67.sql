USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ListarFamilias]    Script Date: 21/7/2019 03:54:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Listado de Familias
-- =============================================
ALTER PROCEDURE [dbo].[ListarFamilias]

AS
	SET NOCOUNT ON;
	SELECT idFamilia, descripcion
	FROM Familia
	WHERE borrado IS NULL

RETURN
