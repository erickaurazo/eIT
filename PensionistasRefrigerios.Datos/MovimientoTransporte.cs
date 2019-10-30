using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportistaMto.Datos
{
    public class MovimientoTransporte
    {

        public string codigoMovimiento { get; set; }
        public string codigoFacturacion { get; set; }
        public string documentoMovimiento { get; set; }
        public DateTime? fechaMovimiento { get; set; }
        public string socumentoMovimiento { get; set; }
        public Int32? semanaRecorrido { get; set; }
        public Int32? semanaFacturacion { get; set; }
        public string DocumentoPago { get; set; }
        public DateTime? FechaDocumentoPago { get; set; }
        public string estadoDocumentoPago { get; set; }
        public string tipoTransporte { get; set; }
        public decimal? valorVenta { get; set; }
        public decimal? igv { get; set; }
        public decimal? importePagar { get; set; }
        public string chofer { get; set; }
        public string placa { get; set; }
        public Int32? numeroPersonas { get; set; }

    }
}
