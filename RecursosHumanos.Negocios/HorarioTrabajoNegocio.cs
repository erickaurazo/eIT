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
    public class HorarioTrabajoNegocio
    {




        public List<HORARIO_TRABAJO> ListarHorariosDeTrabajo(string periodo)
        {
            List<HORARIO_TRABAJO> listado = new List<HORARIO_TRABAJO>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (RecursosHumanosDataContext contexto = new RecursosHumanosDataContext(cnx))
            {
                contexto.CommandTimeout = 300;
                listado = contexto.HORARIO_TRABAJO.ToList();

            }

            return listado;

        }

    }
}
