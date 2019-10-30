using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using RecursosHumanos.Datos;

namespace RecursosHumanos.Negocios
{
    public class IngresoSalidaPersonalNegocio
    {

        public List<ST_RepoteMarcacionPersonal> ListadoMarcacionPersonalPuertaByPeriodo(string periodo, string codigoConsulta, string idplanilla, string idsubplanilla, string codigoDesde, string periododesde, string periodoHasta)
       {

           List<ST_RepoteMarcacionPersonal> listadoResultadoConsulta = new List<Datos.ST_RepoteMarcacionPersonal>();

           string cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();
           using (RecursosHumanosDataContext contexto = new RecursosHumanosDataContext(cnx))
           {
               
               /*Cuando solo deseo la asistencia de un trabajador*/
               if (codigoDesde != "")
               {
                   listadoResultadoConsulta = contexto.ST_RepoteMarcacionPersonalByCodigoPersonal(codigoConsulta,periododesde,periodoHasta,"",codigoDesde).ToList();
               }
                   /*Buscar por codigo de planilla*/
               else if (idplanilla != "" && idsubplanilla == "")
               {
                   listadoResultadoConsulta = contexto.ST_RepoteMarcacionPersonalByPlanilla(codigoConsulta, periododesde, periodoHasta, idplanilla, idsubplanilla).ToList();
               }
                   /*Buscar por planilla y subplanilla*/
               else if (idplanilla != "" && idsubplanilla != "")
               {

               }
               

           }
           return listadoResultadoConsulta;
       }


        public List<ST_RepoteMarcacionPersonalByCodigoPersonalListadoResult> ListadoMarcacionPersonalPuertaByPeriodoRPT(string periodo, string codigoConsulta)
        {
            List<ST_RepoteMarcacionPersonalByCodigoPersonalListadoResult> listadoResultadoConsulta = new List<Datos.ST_RepoteMarcacionPersonalByCodigoPersonalListadoResult>();
            string cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();
            using (RecursosHumanosDataContext contexto = new RecursosHumanosDataContext(cnx))
            {
                listadoResultadoConsulta = contexto.ST_RepoteMarcacionPersonalByCodigoPersonalListado(codigoConsulta).ToList();
            }
            return listadoResultadoConsulta;
        }



        public string ObtenerCodigoUnicoDeConsulta(string periodo)
        {
            string codigo = string.Empty;
            string cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();
            using (RecursosHumanosDataContext contexto = new RecursosHumanosDataContext(cnx))
            {
                codigo = contexto.ObtenerId().FirstOrDefault().Codigo.Trim();
            }

            return codigo;

        }

    }
}
