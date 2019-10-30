using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;

namespace RecursosHumanos.Negocios
{
    public class PlanillasRRHHNegocio
    {

        public List<Planilla> ListadoPlanillasActivas(string periodo)
        {
            List<Planilla> listadoPlanilla = new List<Planilla>();

            string cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (ExoticsModelDataContext contexto = new ExoticsModelDataContext(cnx))
            {
                listadoPlanilla = new List<Planilla>();
                listadoPlanilla = contexto.Planilla.Where(x => x.estado == 1).ToList();
            }

            return listadoPlanilla;
        }

    }
}
