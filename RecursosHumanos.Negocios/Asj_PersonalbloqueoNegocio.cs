using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using System.Data.OleDb;
using System.Data;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using System.Globalization;
using System.Data.Odbc;

namespace RecursosHumanos.Negocios
{
    public class Asj_PersonalbloqueoNegocio
    {


        public List<ASJ_ObtenerListadoDePersonalbloqueadoResult> ObtenerListadoDePersonalbloqueado(string periodo)
        {
            List<ASJ_ObtenerListadoDePersonalbloqueadoResult> listado = new List<ASJ_ObtenerListadoDePersonalbloqueadoResult>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (AgricolaSanJoseDataContext contexto = new AgricolaSanJoseDataContext(cnx))
            {
                listado = contexto.ASJ_ObtenerListadoDePersonalbloqueado().ToList();
            }

            return listado;
        }

    }
}
