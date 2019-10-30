using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportistaMto.Datos
{
    public class ProgramacionRefrigerioMultiples
    {

        public int codigo { get; set; }
        public string dniTrabajador { get; set; }
        public string nombresTrabajador { get; set; }
        public string hospedajeCodigo { get; set; }
        public string hospedajeDescripcion { get; set; }
        public int pensionCodigo { get; set; }
        public string pensionDescripcion { get; set; }
        public int almuerzo { get; set; }
        public int desayuno { get; set; }
        public int cena { get; set; }
        public DateTime validoDesde { get; set; }
        public DateTime validoHasta { get; set; }
        public string codigoSubPlanilla { get; set; }
        public string subPlanilla { get; set; }
        public string codigoPersonalGeneral { get; set; }
        public int idHospedajePersonal { get; set; }
    }
}
