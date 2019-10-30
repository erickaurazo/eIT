using RecursosHumanos.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;



namespace RecursosHumanos.Negocios
{
    public class ConsumidorEtiquetaNegocio
    {

        public List<CONSUMIDORETIQUETA> ObtenerListadoEtiquetasByConsumidor()
        {
            List<CONSUMIDORETIQUETA> listado = new List<CONSUMIDORETIQUETA>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (AgricolaSanJoseDataContext contexto = new AgricolaSanJoseDataContext(cnx))
            {
                listado = contexto.CONSUMIDORETIQUETA.ToList();
            }

            return listado;
        }

    }
}
