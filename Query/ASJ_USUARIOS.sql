USE [AGRICOLA2017]
GO

/******Agrege la columna empresaId por el multiempresa y luego asignar manualmente el codigo de empresa a "001" ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ASJ_USUARIOS](
	[IdUsuario] [varchar](20) NOT NULL,
	[IdCodigoGeneral] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[NombreCompleto] [varchar](150) NOT NULL,
	[AREA] [varchar](50) NULL,
	[email] [varchar](60) NULL,
	[idestado] [char](10) NULL,
	[Local] [varchar](50) NULL,
	[nivel] [char](10) NOT NULL CONSTRAINT [DF_ASJ_USUARIOS_nivel]  DEFAULT ('1'),
	[IDSUCURSAL] [char](3) NOT NULL CONSTRAINT [DF_ASJ_USUARIOS_idsucursal]  DEFAULT ((1)),
	[SUCURSAL] [varchar](100) NOT NULL CONSTRAINT [DF_ASJ_USUARIOS_SUCURSAL]  DEFAULT (''),
	[id_puerta] [int] NOT NULL CONSTRAINT [DF_ASJ_USUARIOS_id_puerta]  DEFAULT ((1)),
	[puerta] [varchar](30) NOT NULL CONSTRAINT [DF_ASJ_USUARIOS_puerta]  DEFAULT (''),
	[EmpresaID] [char](3) NULL,
 CONSTRAINT [PK_ASJ_USUARIOS] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/*
update ASJ_USUARIOS
set EmpresaID = '001'
*/

