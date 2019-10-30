using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportistaMto.Datos
{
    public class DistribucionFacturacionByConsumidorBySubPlanilla
    {
        public DateTime fecha { get; set; }
        public string idConsumidor { get; set; }
        public string consumidor { get; set; }
        public string subplanilla { get; set; }
        public string dniPension { get; set; }
        public string pension { get; set; }
        public decimal? factor { get; set; }
        public decimal? importe { get; set; }
        public string concepto { get; set; }
    }
}
