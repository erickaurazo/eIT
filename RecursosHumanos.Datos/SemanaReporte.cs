using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursosHumanos.Datos
{
   public class SemanaReporte
    {
        public string codigoPersonal { get; set; }
        public string Nombres { get; set; }
        public string codigoAFP { get; set; }
        public string cargo { get; set; }
        public string grupoTrabajo { get; set; }
        public decimal? dia01 { get; set; }
        public decimal? dia02 { get; set; }
        public decimal? dia03 { get; set; }
        public decimal? dia04 { get; set; }
        public decimal? dia05 { get; set; }
        public decimal? dia06 { get; set; }
        public decimal? dia07 { get; set; }
        public decimal? horasTotal { get; set; }
        public decimal? diasTrabajados { get; set; }
        public decimal? horasNormales { get; set; }
        public decimal? horas25 { get; set; }
        public decimal? horas35 { get; set; }
    }
}
