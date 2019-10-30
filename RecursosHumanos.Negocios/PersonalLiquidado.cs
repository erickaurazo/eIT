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
    public class PersonalLiquidado
    {
        private string cnx;
        public List<SJ_RHPersonalLiquidadoResult> Listar(string Periodo, string tipoPlanilla)
        {
            List<SJ_RHPersonalLiquidadoResult> ListapersonalLiquidado = new List<SJ_RHPersonalLiquidadoResult>();
            cnx = ConfigurationManager.AppSettings["bd" + Periodo.Substring(0,4)].ToString();
            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                ListapersonalLiquidado = Modelo.SJ_RHPersonalLiquidado(Periodo, tipoPlanilla).ToList();
            }

            return ListapersonalLiquidado;
        }
    }
}
