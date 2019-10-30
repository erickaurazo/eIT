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
    public class PersonaNegocio
    {
        private string oConexion;

        public string ObtenerNombrePersona(string periodoConsulta, string codigoPersonal)
        {
            string nombresCompleto = string.Empty;

            using (TransactionScope Scope = new TransactionScope())
            {
                oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
                using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
                {
                    nombresCompleto = Modelo.Personas.Where(x => x.codigoPersona == codigoPersonal).FirstOrDefault().nombres.Trim() != null ? Modelo.Personas.Where(x => x.codigoPersona == codigoPersonal).FirstOrDefault().nombres.Trim() : string.Empty;
                    
                }
            }
            return nombresCompleto;
        }

        public List<Persona> ObtenerListadoTodoPersona(string periodoConsulta)
        {
            List<Persona> listado = new List<Persona>();

            using (TransactionScope Scope = new TransactionScope())
            {
                oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
                using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
                {
                    listado = Modelo.Personas.ToList();
                }
            }
            return listado;
        }

    }
}
