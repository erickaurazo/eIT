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
    public class SubPlanillasRRHH
    {

        public List<GRUPO_TRABAJO> ListadoSubPlanillasActivas(string periodo)
        {
            List<GRUPO_TRABAJO> listadoSubPlanilla = new List<GRUPO_TRABAJO>();

            string cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (RecursosHumanosDataContext contexto = new RecursosHumanosDataContext(cnx))
            {
                listadoSubPlanilla = new List<GRUPO_TRABAJO>();
                listadoSubPlanilla = contexto.GRUPO_TRABAJO.Where(x => x.ESTADO == 1).ToList();

                listadoSubPlanilla.Add(new GRUPO_TRABAJO { IDGRUPOTRABAJO = "", DESCRIPCION = "TODOS" });

            }

            return listadoSubPlanilla.OrderBy(x => x.IDGRUPOTRABAJO).ToList();
        }

    }
}
