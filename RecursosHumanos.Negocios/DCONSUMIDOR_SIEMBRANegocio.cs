using RecursosHumanos.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;


namespace RecursosHumanos.Negocios
{
   public class DCONSUMIDOR_SIEMBRANegocio
    {

        public void ActualizarNumeroPlantasEnConsumidor(DCONSUMIDOR_SIEMBRA oConsumidor)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (AgricolaSanJoseDataContext contexto = new AgricolaSanJoseDataContext(cnx))
            {
                var resultado = contexto.DCONSUMIDOR_SIEMBRA.Where(x => x.idconsumidor == oConsumidor.idconsumidor && x.idsiembra == oConsumidor.idsiembra).ToList();
                if (resultado.Count() == 1)
                {
                    #region Modificar()
                    DCONSUMIDOR_SIEMBRA oConsumidorModificado = new DCONSUMIDOR_SIEMBRA();
                    oConsumidorModificado = resultado.Single();
                    oConsumidorModificado.nroplantas = oConsumidor.nroplantas;
                    contexto.SubmitChanges();
                    #endregion
                }

            }
        }

    }
}
