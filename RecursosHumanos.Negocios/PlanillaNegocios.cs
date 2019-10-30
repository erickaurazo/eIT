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
    public class PlanillaNegocios
    {
        private string cnx;

        public List<SJ_RHPlanillaTipoResult> Listar(string Periodo)
        {
            List<SJ_RHPlanillaTipoResult> tipoPlanilla = new List<SJ_RHPlanillaTipoResult>();
            cnx = ConfigurationManager.AppSettings["bd" + Periodo].ToString();
            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                tipoPlanilla = Modelo.SJ_RHPlanillaTipo().ToList();
            }
            return tipoPlanilla;
        }




        public List<Planilla> ListarPlanillas(string Periodo)
        {
            List<Planilla> tipoPlanilla = new List<Planilla>();
            cnx = ConfigurationManager.AppSettings["bd" + (Periodo != null ? Periodo.Substring(0,4) : "2018" ) ].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(cnx))
            {
                tipoPlanilla = Modelo.Planilla.ToList();
            }
            return tipoPlanilla;
        }

    }
}
