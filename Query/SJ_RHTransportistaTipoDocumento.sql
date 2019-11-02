USE [AGRICOLA2017]
GO

/****** Object:  Table [dbo].[SJ_RHTransportistaTipoDocumento]    Script Date: 31/10/2019 11:28:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SJ_RHTransportistaTipoDocumento](
	[TypeDocumentId] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](50) NOT NULL,
	[abbreviature] [char](3) NULL,
	[status] [tinyint] NOT NULL CONSTRAINT [DF_SJ_RHTransportistaTipoDocumento_status]  DEFAULT ((1)),
 CONSTRAINT [PK_SJ_RHTransportistaTipoDocumento] PRIMARY KEY CLUSTERED 
(
	[TypeDocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


