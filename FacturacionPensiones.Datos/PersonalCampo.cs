using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transportista.Datos
{
    public class PersonalCampo
    {
        public int codigo { get; set; }
        public string codigoPersonal { get; set; }
        public string nroDNI { get; set; }
        public string Nombres { get; set; }
        public int tipoRefriferio { get; set; }
        public string refriferio { get; set; }
        public string nroDNIPension { get; set; }
        public string pension { get; set; }
        public DateTime? fecha { get; set; }
        public string estado { get; set; }
        public string fechaDesde { get; set; }
        public string fechaHasta { get; set; }
    }
}
