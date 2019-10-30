using RecursosHumanos.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;


namespace RecursosHumanos.Negocios
{
    public class ASJ_ConsumidorByRacimoNegocio
    {

        public List<ASJ_ConsumidorByRacimo> ObtenerListadoConsumidoresByRacimo()
        {
            List<ASJ_ConsumidorByRacimo> listado = new List<ASJ_ConsumidorByRacimo>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (AgricolaSanJoseDataContext contexto = new AgricolaSanJoseDataContext(cnx))
            {
                listado = contexto.ASJ_ConsumidorByRacimo.ToList();
            }

                return listado;
        }

        public void Registrar(ASJ_ConsumidorByRacimo oConsumidorByRacimo)
        {           
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (AgricolaSanJoseDataContext contexto = new AgricolaSanJoseDataContext(cnx))
            {
            
                var resultadoConsulta = contexto.ASJ_ConsumidorByRacimo.Where(x=> x.idConsumidor == oConsumidorByRacimo.idConsumidor).ToList();

                if (resultadoConsulta.Count() == 0)
                {
                    #region Registrar()
                    ASJ_ConsumidorByRacimo asjConsumidorByRacimo = new ASJ_ConsumidorByRacimo();
                    asjConsumidorByRacimo.idEmpresa = "001";
                    asjConsumidorByRacimo.idConsumidor = oConsumidorByRacimo.idConsumidor;
                    asjConsumidorByRacimo.numeroRacimos = oConsumidorByRacimo.numeroRacimos;
                    contexto.ASJ_ConsumidorByRacimo.InsertOnSubmit(asjConsumidorByRacimo);
                    contexto.SubmitChanges();
                    #endregion
                }
                else if (resultadoConsulta.Count() == 1)
                {
                    #region Modificar()

                    ASJ_ConsumidorByRacimo asjConsumidorByRacimo = new ASJ_ConsumidorByRacimo();
                    asjConsumidorByRacimo = resultadoConsulta.Single();
                    //asjConsumidorByRacimo.idEmpresa = oConsumidorByRacimo.idEmpresa;
                    //asjConsumidorByRacimo.idConsumidor = oConsumidorByRacimo.idConsumidor;
                    asjConsumidorByRacimo.numeroRacimos = oConsumidorByRacimo.numeroRacimos;
                    //contexto.ASJ_ConsumidorByRacimo.InsertOnSubmit(asjConsumidorByRacimo);
                    contexto.SubmitChanges();
                    #endregion
                }

            }

            
        }

        public void Eliminar(ASJ_ConsumidorByRacimo oConsumidorByRacimo)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (AgricolaSanJoseDataContext contexto = new AgricolaSanJoseDataContext(cnx))
            {
                var resultadoConsulta = contexto.ASJ_ConsumidorByRacimo.Where(x => x.idConsumidor == oConsumidorByRacimo.idConsumidor).ToList();
                if (resultadoConsulta.Count() == 1)
                {
                    #region Eliminar()
                    ASJ_ConsumidorByRacimo asjConsumidorByRacimo = new ASJ_ConsumidorByRacimo();
                    asjConsumidorByRacimo = resultadoConsulta.Single();                    
                    contexto.ASJ_ConsumidorByRacimo.DefaultIfEmpty(asjConsumidorByRacimo);
                    contexto.SubmitChanges();
                    #endregion
                }
            }


        }

        public List<ASJ_ObtenerListadoConsumidorByAreaByRacimoNyNumeroPlantasResult> ObtenerListadoConsumidoresByRacimoByNroPlantas(string periodo)
        {

            List<ASJ_ObtenerListadoConsumidorByAreaByRacimoNyNumeroPlantasResult> listado = new List<ASJ_ObtenerListadoConsumidorByAreaByRacimoNyNumeroPlantasResult>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            
            using (AgricolaSanJoseDataContext contexto = new AgricolaSanJoseDataContext(cnx))
            {
                listado = contexto.ASJ_ObtenerListadoConsumidorByAreaByRacimoNyNumeroPlantas().ToList();
            }

            return listado;
        }





    }
}
