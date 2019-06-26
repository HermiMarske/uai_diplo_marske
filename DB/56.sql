USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ListarPilotosCombo]    Script Date: 26/06/2019 1:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/11
-- Description:	Alta de clientes
-- =============================================
CREATE PROCEDURE [dbo].[ListarPilotosCombo]

AS
	SET NOCOUNT ON;
	SELECT p.ID_Piloto, per.nombre, per.apellido
	FROM Pilotos p, Personas per 
	WHERE p.FK_Persona = per.ID_Persona

RETURN
