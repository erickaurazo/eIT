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
    public class HorarioTrabajoByPersonalNegocios
    {

        public List<HORARIO_PERSONAL> ListarPersonalConHorariosDeTrabajo(string periodo)
        {
            List<HORARIO_PERSONAL> listado = new List<HORARIO_PERSONAL>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (RecursosHumanosDataContext contexto = new RecursosHumanosDataContext(cnx))
            {
                contexto.CommandTimeout = 300;
                listado = contexto.HORARIO_PERSONAL.ToList();

            }

            return listado;

        }

        public List<HORARIO_PERSONAL> BuscarPersonalConHorariosDeTrabajoByCodigoPerosnal(string periodo)
        {
            List<HORARIO_PERSONAL> listado = new List<HORARIO_PERSONAL>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (RecursosHumanosDataContext contexto = new RecursosHumanosDataContext(cnx))
            {
                contexto.CommandTimeout = 300;
                listado = contexto.HORARIO_PERSONAL.ToList();

            }

            return listado;

        }
    }
}
