USE [UAI_GESTION_AGUILA]
GO
/****** Object:  StoredProcedure [dbo].[ListarTodasPatentes]    Script Date: 5/5/2019 03:06:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 25/4/2019
-- Description:  Lista de patentes general
-- =============================================
CREATE PROCEDURE [dbo].[ListarTodasPatentes]

AS
  SET NOCOUNT ON;

SELECT idPatente, codigo
 FROM Patente 
RETURN
