USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ListarAvionesCombo]    Script Date: 26/06/2019 1:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/11
-- Description:	Listado de Aviones
-- =============================================
CREATE PROCEDURE [dbo].[ListarAvionesCombo]

AS
	SET NOCOUNT ON;
	SELECT ID_Avion, matricula
	FROM Aviones
RETURN