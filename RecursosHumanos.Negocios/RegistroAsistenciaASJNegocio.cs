using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Configuration;

namespace RecursosHumanos.Negocios
{
    public class RegistroAsistenciaASJNegocio
    {

        string oConexion = string.Empty;
        private List<RPT_ASISTENCIASResult> listado;

        public List<RPT_ASISTENCIASResult> ObtenerListadoPersonalByPeriodo(string fechaDesde, string fechasHasta, string idcodigoGeneral)
        {

            List<RPT_ASISTENCIASResult> listado = new List<RPT_ASISTENCIASResult>();


            oConexion = ConfigurationManager.AppSettings["bd" + (DateTime.Now.Year.ToString() != null ? DateTime.Now.Year.ToString() : "2019")].ToString();
            using (AgricolaSanJoseDataContext Modelo = new AgricolaSanJoseDataContext(oConexion))
            {
                listado = Modelo.RPT_ASISTENCIAS(fechaDesde, fechasHasta, idcodigoGeneral).ToList();

            }

            return listado;
        }

        public string metodocreado()
        {

            return "";
        }




        public List<RPT_ASISTENCIASResult> AgruparListadoPersonalByPeriodoByPersonal(List<RPT_ASISTENCIASResult> listadoOrigen)
        {
            try
            {
                listado = new List<RPT_ASISTENCIASResult>();

                /*Agrupo por fecha*/
                var dias = (from item in listadoOrigen
                            where item.FECHA != null
                            group item by new { item.FECHA } into j
                            select new
                            {
                                dia = j.Key.FECHA,
                            }
                                ).ToList();


                foreach (var itemDia in dias)
                {
                    /* Agrupo por persona */
                    var personas = (from item in listadoOrigen.Where(x => x.FECHA.Value == itemDia.dia).ToList()
                                    where item.FECHA != null
                                    group item by new { item.IDCODIGOGENERAL } into j
                                    select new
                                    {
                                        dni = j.Key.IDCODIGOGENERAL,
                                    }
                                ).ToList();

                    foreach (var itemPersona in personas)
                    {
                        var resultadoByPersona = listadoOrigen.Where(x => x.FECHA.Value == itemDia.dia && x.IDCODIGOGENERAL == itemPersona.dni).ToList();

                        RPT_ASISTENCIASResult oAsistencia = new RPT_ASISTENCIASResult();
                        oAsistencia.FECHA = itemDia.dia;
                        oAsistencia.IDCODIGOGENERAL = itemPersona.dni;
                        oAsistencia.NOMBRES = resultadoByPersona.FirstOrDefault().NOMBRES != null ? resultadoByPersona.FirstOrDefault().NOMBRES.Trim() : string.Empty;
                        oAsistencia.Estado = resultadoByPersona.FirstOrDefault().Estado != null ? resultadoByPersona.FirstOrDefault().Estado.Trim() : string.Empty;
                        oAsistencia.ControlAsistencia = resultadoByPersona.Sum(x => Convert.ToDecimal(x.ControlAsistencia));
                        oAsistencia.ControlTareo = resultadoByPersona.Sum(x => Convert.ToDecimal(x.ControlTareo));
                        oAsistencia.NISIRA = resultadoByPersona.Sum(x => Convert.ToDecimal(x.NISIRA));
                        oAsistencia.TotalMarcaciones = oAsistencia.ControlAsistencia + oAsistencia.ControlTareo + oAsistencia.NISIRA;
                        listado.Add(oAsistencia);
                    }
                }

                return listado;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}
