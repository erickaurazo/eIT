using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportistaMto.Datos
{
    public class RefrigerioAgrupado
    {
        public DateTime? Fecha { get; set; }
        public string CodPension { get; set; }
        public string Pension { get; set; }
        public string DNITrabajador { get; set; }
        public string Trabajador { get; set; }
        public bool? Desayuno { get; set; }
        public bool? Almuerzo { get; set; }
        public bool? Cena { get; set; }
        public int nroDesayuno { get; set; }
        public int nroAlmuerzo { get; set; }
        public int nroCena { get; set; }

        public decimal ImporteDesayuno { get; set; }
        public decimal ImporteAlmuerzo { get; set; }
        public decimal ImporteCena { get; set; }

        public int nroRefrigeriosxPension { get; set; }
        public string SubPlanilla { get; set; }
        public string Condicion { get; set; }
        public string CodigoPersonal { get; set; }

        public string Inasistencia { get; set; }
        public string DescanzoMedico { get; set; }
        public string LicenciaPermiso { get; set; }
        public string Suspencion { get; set; }
        public string Vacaciones { get; set; }
        public decimal? Importe { get; set; }

        public string idHospedaje { get; set; }
        public string hospedaje { get; set; }
        

    }
}
