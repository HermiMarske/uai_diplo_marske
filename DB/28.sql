USE [UAI_GESTION_AGUILA]
GO

/****** Object:  Table [dbo].[Mails]    Script Date: 08/04/2019 01:30:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Mails](
	[ID_Mail] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](20) NULL,
	[mail] [varchar](100) NULL,
	[FK_Persona] [int] NULL,
 CONSTRAINT [PK_Mails] PRIMARY KEY CLUSTERED 
(
	[ID_Mail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [DF__Usuarios__habili__1A9EF37A]
GO

ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [DF__Usuarios__CII__19AACF41]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 09/04/2019 21:42:24 ******/
DROP TABLE [dbo].[Usuarios]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 09/04/2019 21:42:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](20) NOT NULL,
	[clave] [varchar](2000) NOT NULL,
	[CII] [int] NOT NULL,
	[habilitado] [bit] NOT NULL,
	[DVH] [int] NULL,
	[FK_Persona] [int] NULL,
	[respuesta] [varchar](30) NULL,
	[FK_Pregunta] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((0)) FOR [CII]
GO

ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((1)) FOR [habilitado]
GO


/****** Object:  StoredProcedure [dbo].[AltaUsuarioPersExistente]    Script Date: 07/04/2019 23:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2019/04/07
-- Description:	Alta de clientes
-- =============================================
CREATE PROCEDURE [dbo].[AltaUsuarioPersExistente]

	

	@idPersona int,
	@usuario varchar(20),
	@clave varchar(2000),
	@respuesta varchar(50),
	@fk_pregunta int


AS
	
	INSERT INTO Usuarios(usuario,clave, CII, habilitado, FK_Persona, respuesta, FK_Pregunta) VALUES (@usuario, @clave, 0, 1, @idPersona, @respuesta, @fk_pregunta)
	
/****** Object:  StoredProcedure [dbo].[ObtenerMails]    Script Date: 07/04/2019 20:31:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Obtiene los mails para poder editar personas
-- Params: Recibe como parametro un id de persona, el cual obtengo de la query anterior (Obtener cliente) de FK Persona. Lo mismo puedo hacer con los usuarios y los pilotos
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerMails]

@id int

AS
  SET NOCOUNT ON;

  
  IF ((SELECT COUNT(*) FROM Mails WHERE FK_Persona = @id) = 0 )
    BEGIN
	  SELECT 'La persona no tiene mails'
    END;

SELECT * FROM Mails WHERE FK_Persona = @id;

/****** Object:  StoredProcedure [dbo].[BorrarMails]    Script Date: 07/04/2019 19:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    Herminia Marske
-- Create date: 2019/01/24
-- Description:  Borrar Mails de persona
-- =============================================
CREATE PROCEDURE [dbo].[BorrarMails]

@idPersona int

AS
  SET NOCOUNT ON;

  DELETE FROM Mails WHERE FK_Persona = @idPersona;


/****** Object:  StoredProcedure [dbo].[AltaTelefono]    Script Date: 08/04/2019 01:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/15
-- Description:	Alta de	Telefono
-- =============================================
ALTER PROCEDURE [dbo].[AltaTelefono]


	@tipo varchar(20),
	@numero varchar(30),
	@fk_persona int

AS
	
	INSERT INTO Telefono(tipo,numero, FK_Persona)
	VALUES (@tipo, @numero, @fk_persona)

RETURN 0

/****** Object:  StoredProcedure [dbo].[AltaDomicilio]    Script Date: 08/04/2019 01:28:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/15
-- Description:	Alta de	Domicilio
-- =============================================
ALTER PROCEDURE [dbo].[AltaDomicilio]


	@calle varchar(50),
	@numero varchar(20),
	@piso int,
	@dpto varchar(5),
	@comentarios varchar(100),
	@codPostal varchar(20),
	@tipoDomicilio varchar(20),
	@fk_localidad int,
	@fk_persona int



AS
	
	INSERT INTO Domicilio(calle,numero,piso,dpto, comentarios, codPostal,tipoDomicilio, FK_Localidad, FK_Persona)
	VALUES (@calle, @numero, @piso, @dpto, @comentarios, @codPostal, @tipoDomicilio, @fk_localidad, @fk_persona)

	
RETURN 0

/****** Object:  StoredProcedure [dbo].[AltaMail]    Script Date: 08/04/2019 01:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Herminia Marske
-- Create date: 2018/11/15
-- Description:	Alta de	Mails
-- =============================================
CREATE PROCEDURE [dbo].[AltaMail]


	@tipo varchar(20),
	@mail varchar(100),
	@fk_persona int

AS
	
	INSERT INTO Mails(tipo, mail, FK_Persona)
	VALUES (@tipo, @mail, @fk_persona)

RETURN 0
