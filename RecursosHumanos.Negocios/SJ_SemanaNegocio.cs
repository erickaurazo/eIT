using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Configuration;

namespace RecursosHumanos.Negocios
{
    public class SJ_SemanaNegocio
    {
        private SJ_Semana oSemana;

        public SJ_Semana ObtenerSemanaPorNroSemana(SJ_Semana oSemanaConsulta, string periodo)
        {
            oSemana = new SJ_Semana();
            string cnx = string.Empty;
            cnx = string.Empty;
            if (periodo != string.Empty)
            {
                cnx = ConfigurationManager.AppSettings["bd"+ periodo].ToString();
                using (AgricolaSanJoseDataContext datos = new AgricolaSanJoseDataContext(cnx))
                {

                }
            }
            else
            {
                #region Selecionar semana()                
                oSemana = new SJ_Semana();                
                cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
                using (RecursosHumanosDataContext contexto = new RecursosHumanosDataContext(cnx))
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
                }
                #endregion

            }
            return oSemana;

        }

    }
}
