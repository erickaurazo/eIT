alter procedure [dbo].[SJ_RHListarDetalleTransportistaContrato]
@Id as int
as
(

Select
C.Id , 
C.ITEM,
C.FechaInicio,
C.FechaTermino, 
C.TypeDocumentId,
Dd.description as documento ,
rtrim(C.Observacion) as Observacion, 
C.IdEstado,
RTRIM(E.DESCRIPCION) AS Estado
 FROM SJ_RHTransportistaContrato C 
 LEFT JOIN ESTADOS E ON  C.IdeSTADO=E.IdEstado
 LEFT JOIN SJ_RHTransportistaTipoDocumento DD ON
 C.TypeDocumentId = DD.TypeDocumentId
 where C.id = @Id 
 )
