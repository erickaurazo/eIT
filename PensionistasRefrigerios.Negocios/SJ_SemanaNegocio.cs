using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransportistaMto.Datos;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;

namespace Transportista.Negocios
{
    public class SJ_SemanaNegocio
    {


        public SJ_Semana ObtenerSemanaPorNroSemana(SJ_Semana oSemanaConsulta)
        {
            SJ_Semana oSemana = new SJ_Semana();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            try
            {

                using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
                {
                    var resultadoConsulta = contexto.SJ_Semanas.Where(x => x.año == oSemanaConsulta.año && x.semana == oSemanaConsulta.semana).ToList();

                    if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                    {
                        oSemana = resultadoConsulta.Single();
                    }
                    else
                    {
                        oSemana = new SJ_Semana();
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
