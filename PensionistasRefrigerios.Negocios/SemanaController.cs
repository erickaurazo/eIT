using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding.Busquedas;
using Asistencia.Datos;

namespace Asistencia.Negocios
{
    public class SemanaController
    {


        public SJ_Semanas ObtenerSemanaPorNroSemana(SJ_Semanas oSemanaConsulta, string periodo)
        {
            SJ_Semanas oSemana = new SJ_Semanas();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();
            try
            {

                using (BDAsistenciaDataContext contexto = new BDAsistenciaDataContext(cnx))
                {
                    var resultadoConsulta = contexto.SJ_Semanas.Where(x => x.año == oSemanaConsulta.año && x.semana == oSemanaConsulta.semana).ToList();

                    if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                    {
                        oSemana = resultadoConsulta.Single();
                    }
                    else
                    {
                        oSemana = new SJ_Semanas();
                        oSemana.semana = oSemanaConsulta.semana;
                        oSemana.año = oSemanaConsulta.año;
                        oSemana.desde = DateTime.Now;
                        oSemana.hasta = DateTime.Now;
                    }
                    return oSemana;
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

         

        }

    }
}
