using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Configuration;

namespace RecursosHumanos.Negocios
{
    public class DiasEfectivosNegocios
    {
        List<sj_GetHorasEfectivasRemuneradasResult> listado = new List<sj_GetHorasEfectivasRemuneradasResult>();
        public List<sj_GetHorasEfectivasRemuneradasResult> GetListado(string fechaInicio, string fechaFinal, string tipoPlanilla)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + Convert.ToDateTime(fechaFinal.ToString().Trim()).Year.ToString()].ToString();
            
            using (RecursosHumanosDataContext contexto = new RecursosHumanosDataContext(cnx))
            {
               
                if (contexto.sj_GetHorasEfectivasRemuneradas(fechaInicio, fechaFinal, tipoPlanilla).ToList().Count > 0)
                    {
                        listado = new List<sj_GetHorasEfectivasRemuneradasResult>();
                        listado = contexto.sj_GetHorasEfectivasRemuneradas(fechaInicio, fechaFinal,tipoPlanilla).ToList();
                    }
                    else
                    {
                        listado = new List<sj_GetHorasEfectivasRemuneradasResult>();
                    }                
            }
            return listado;
        }
    }
}
