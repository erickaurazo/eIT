alter Procedure [dbo].[SJ_RHListadoVencimientoDocumentosByUnidadTransportes]

as      

(      
SELECT       
T.Id,       
T.RUC,       
rtrim(C.RAZON_SOCIAL) AS RazonSocial,      
rtrim(T.Placa) AS Placa,       
rtrim(T.NombreCorto) AS PseudoNombre,       
rtrim(T.TipoMovilidad) as IdTipoMovilidad ,       
CASE T.TipoMovilidad         
WHEN '001'  THEN 'COASTER'         
WHEN '002'  THEN 'BUS'        
WHEN '003'  THEN 'COMBI'     
WHEN '004'  THEN 'MINIBUS'     
WHEN '005'  THEN 'MINIVAN'   
ELSE 'No Definido'        
END as TipoMovilidad,        
T.NumeroAsientos,      
T.PesoMaximo,      
T.EsMovilidadLocal,      
T.EsInterLocal,      
T.AnioFabricacion,      
T.Marca,      
T.Modelo,      
T.IdEstado,    
isnull(D.Item,'') as itemContrato,
d.FechaInicio,
d.FechaTermino,
DATEDIFF(day,  getdate(),d.FechaTermino) as diasRestantes,
isnull(td.description,'') as documento, 
 RTRIM(E.DESCRIPCION) AS estadoUnidadMovil   
 FROM SJ_RHTRANSPORTISTA T      
left join CLIEPROV C ON T.RUC= C.IDCLIEPROV      
left JOIN ESTADOS E ON T.IDESTADO=E.IDESTADO 
LEFT JOIN SJ_RHTransportistaContrato D ON T.Id= D.Id
LEFT JOIN SJ_RHTransportistaTipoDocumento td ON D.TypeDocumentId = TD.TypeDocumentId      
)      
order by C.RAZON_SOCIAL, Placa DESC      






