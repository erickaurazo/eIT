using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportistaMto.Datos
{
    public class DescuentoByInasistenciaRefrigerio
    {

        public string codigoPersonal { get; set; }
        public string dniPersonal { get; set; }
        public string nombres { get; set; }
        public int? diasAusentes { get; set; }
        public decimal? importeDescuento { get; set; }

    }
}
