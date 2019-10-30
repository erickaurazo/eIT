using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using RecursosHumanos.Datos;
using MyControlsDataBinding.Busquedas;


namespace RecursosHumanos.Negocios
{
    public class HorarioRefrigerioNegocio
    {

        public List<HORARIO_REFRIGERIO> ListarHorariosDeRefrigerio(string periodo)
        {
            List<HORARIO_REFRIGERIO> listado = new List<HORARIO_REFRIGERIO>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (RecursosHumanosDataContext contexto = new RecursosHumanosDataContext(cnx))
            {
                contexto.CommandTimeout = 300;
                listado = contexto.HORARIO_REFRIGERIO.ToList();

            }

            return listado;

        }

    }
}
