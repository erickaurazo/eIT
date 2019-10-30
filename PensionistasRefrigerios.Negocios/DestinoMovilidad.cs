using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using TransportistaMto.Datos;

namespace Transportista.Negocios
{
    public class DestinoMovilidad
    {

        public List<SJ_RHDestinoMovilidad> ListadoDestinos()
        {
            List<SJ_RHDestinoMovilidad> listado = new List<SJ_RHDestinoMovilidad>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                listado = Modelo.SJ_RHDestinoMovilidads.ToList();
            }
            return listado;
        }

    }
}
