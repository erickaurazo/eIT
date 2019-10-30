using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportistaMto.Datos
{
 public   class oCabeceraImportacionParteTransporteTercerosByMovil
    {

        public string empresaCodigo { get; set; }
        public string empresaDescripcion { get; set; }
        public string codigoFormulario { get; set; }
        public string periodo { get; set; }
        public string periodoFormato { get; set; }
        public string numeroManual { get; set; }
        public string codigoDocumento { get; set; }
        public string serieDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string fechaDocumento { get; set; }
        public string estadoCodigo { get; set; }

        public string estadoDescripcion { get; set; }
        public string unidadMovilCodigo { get; set; }
        public string unidadMovilPlaca { get; set; }
        public string unidadMovilRUC { get; set; }

        public string unidadMovilTipoMovilidad { get; set; }
        public string unidadMovilNombreComercial { get; set; }
        public string unidadMovilRazonSocial { get; set; }
        public string unidadMovilNumeroAsientos { get; set; }
        public string conductorCodigo { get; set; }
        public string conductorDNI { get; set; }

        public string conductorNombres { get; set; }
        public string rutaOrigenCodigo { get; set; }
        public string rutaOrigenItem { get; set; }
        public string rutaOrigenDescripcion { get; set; }
        public string rutaOrigenPrecio { get; set; }



        public string rutaDestinoCodigo { get; set; }
        public string rutaDestinoItem { get; set; }
        public string rutaDestinoDescripcion { get; set; }
        public string rutDestinoPrecio { get; set; }



    }
}
