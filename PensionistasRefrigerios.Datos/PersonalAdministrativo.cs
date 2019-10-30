using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportistaMto.Datos
{
    public class PersonalAdministrativo
    {

        public DateTime? fecha { get; set; }
        public string diaSemana { get; set; }
        public string codigoPersonal { get; set; }
        public string personal { get; set; }
        public string nroDocumento { get; set; }
        public string areaTrabajo { get; set; }
        public string cargo { get; set; }
        public DateTime? ingreso { get; set; }
        public DateTime? horaSalidaRefrigerio { get; set; }
        public DateTime? horaRetornoRefrigerio { get; set; }
        public DateTime? horaSalidaRefrigerioDesayuno { get; set; }
        public DateTime? horaRetornoRefrigerioDesayuno { get; set; }
        public DateTime? salida { get; set; }
        public decimal? HorasTrabajadas { get; set; }
        public int? Asistio { get; set; }
        public string estado { get; set; }

    }
}
