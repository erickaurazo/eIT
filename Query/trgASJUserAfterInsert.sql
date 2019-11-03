USE [AGRICOLA2017]
GO
/****** Object:  Trigger [dbo].[trgASJUserAfterInsert]    Script Date: 02/11/2019 21:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER TRIGGER [dbo].[trgASJUserAfterInsert] ON [dbo].[ASJ_USUARIOS] 
FOR INSERT
AS
	declare @Codigo char(20);
	select @Codigo=i.IdUsuario from inserted i;	

	insert into PrivilegioFormulario
    SELECT @Codigo , formularioCodigo,0	,0	,0	,0	,0	,0,	1,	0  FROM FormularioSistema
	PRINT 'Privilegios actualizados'

