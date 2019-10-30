using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Configuration;

namespace RecursosHumanos.Negocios
{
    public class MovimientoPlanillaNegocio
    {

        public List<Temp_ST_ReportePlanillaByConceptosRemuneracionSemanal> ObtenerListadoReportePlanillaByConceptoRemuneracio(string idPlanilla, string semana, string periodo)
        {

            List<Temp_ST_ReportePlanillaByConceptosRemuneracionSemanal> listado = new List<Temp_ST_ReportePlanillaByConceptosRemuneracionSemanal>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim().Substring(0, 4)].ToString().Trim();

            using (RecursosHumanosDataContext contexto = new RecursosHumanosDataContext(cnx))
            {
                contexto.CommandTimeout = 9000;

                listado = contexto.ST_ReportePlanillaByConceptosRemuneracionSemanal(semana, periodo, idPlanilla).ToList();
                contexto.Connection.Close();
                contexto.Dispose();

            }

            return listado;


        }

    }
}
