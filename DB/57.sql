USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ListarPilotos]    Script Date: 26/06/2019 1:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/11
-- Description:	Listado de Usuarios
-- =============================================
CREATE PROCEDURE [dbo].[ListarClientesCombo]

AS
	SET NOCOUNT ON;
	SELECT ID_Cliente, razonSocial
	FROM Cliente
RETURN
