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
    public class LaborNegocio
    {
        private string oConexion;

        public List<Labor> ListadoLabores(string periodoConsulta)
        {
            List<Labor> labores = new List<Labor>();

            using (TransactionScope Scope = new TransactionScope())
            {
                oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
                using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
                {
                    labores = Modelo.Labor.Where(x => x.estado == 1).ToList();

                }
                Scope.Complete();
            }

            return labores;
        }

        public List<Labor> ListadoTodasLabores(string periodoConsulta)
        {
            List<Labor> labores = new List<Labor>();

            using (TransactionScope Scope = new TransactionScope())
            {
                oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
                using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
                {
                    labores = Modelo.Labor.ToList();

                }
                Scope.Complete();
            }

            return labores;
        }

        public List<ext_ListarLaboresByCodigoActividadResult> ListadoTodasLaboresByCodigoActividad(string periodoConsulta, string codigoActividad)
        {
            List<ext_ListarLaboresByCodigoActividadResult> labores = new List<ext_ListarLaboresByCodigoActividadResult>();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                labores = Modelo.ext_ListarLaboresByCodigoActividad(codigoActividad).ToList();
            }
            return labores;
        }

        public string ObtenerNombreLaborByCodigoLaborByCodigoActividad(string periodoConsulta, string codigoActividad, string codigoLabor)
        {
            string nombre = string.Empty;
            if (codigoActividad != "" && codigoLabor != "")
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
                    using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
                    {
                        var resultado = Modelo.Labor.Where(x => x.codigoActividad == codigoActividad && x.codigoLabor == codigoLabor).ToList();
                        if (resultado.ToList().Count > 0)
                        {
                            nombre = resultado.FirstOrDefault().descripcion.Trim() != null ? resultado.FirstOrDefault().descripcion.Trim() : string.Empty;
                        }
                    }
                    Scope.Complete();
                }
            }
            return nombre;
        }

    }
}
