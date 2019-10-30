using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportistaMto.Datos
{
    public class IndicadorAsistencia
    {

        public DateTime fecha { get; set; }
        public string codigoTrabajador { get; set; }
        public string NombresTrabajador { get; set; }
        public decimal? horasTrabajadas { get; set; }
        public decimal? minutosTrabajadas { get; set; }
        public decimal? racimosTrabajador { get; set; }
        public string codigoConsumidor { get; set; }
        public string consumidor { get; set; }
        public string subPlanilla { get; set; }
        public string actividad { get; set; }
        public string labor { get; set; }
        public string idProyecto { get; set; }
        public string proyecto { get; set; }
    }
}
