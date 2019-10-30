using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;

namespace RecursosHumanos.Negocios
{
    public class GrupoNegocio
    {


        List<GrupoH> listaVistaReporte = new List<GrupoH>();
        GrupoH oVistaReporte = new GrupoH();

        public List<GrupoH> ListarVistaByReporte()
        {
            oVistaReporte = new GrupoH();
            oVistaReporte.Codigo = "HOR";
            oVistaReporte.Descripcion = "Por horas acumuladas";
            listaVistaReporte.Add(oVistaReporte);

            oVistaReporte = new GrupoH();
            oVistaReporte.Codigo = "PER";
            oVistaReporte.Descripcion = "Por nro personas";
            listaVistaReporte.Add(oVistaReporte);

            return listaVistaReporte;
        }

        public List<GrupoH> ObtenerCodigoAsistenciaGarita()
        {
            List<GrupoH> listado = new List<GrupoH>();
            listado.Add(new GrupoH { Id = "ASP", Descripcion = "CONTROL DE ASISTENCIA DE PERSONAL" });
            return listado;
        }

        public List<GrupoH> ObtenerNumeroSeriesAsistenciaGarita(string idDocumento)
        {
            List<GrupoH> listado = new List<GrupoH>();

            string cnx = string.Empty;
            cnx = System.Configuration.ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString().Trim().Substring(0, 4)].ToString().Trim();

            using (RecursosHumanosDataContext contexto = new RecursosHumanosDataContext(cnx))
            {
                var listadoSerieByDocumento = contexto.NUMEMISOR.Where(x => x.IDDOCUMENTO == idDocumento).ToList();

                if (listadoSerieByDocumento != null && listadoSerieByDocumento.ToList().Count > 0)
                {
                    foreach (var item in listadoSerieByDocumento)
                    {
                        listado.Add(new GrupoH { Id = item.SERIE, Descripcion = item.SERIE });
                    }
                }
            }

            return listado;
        }

        public List<GrupoH> ObtenerListadoDosDiasAnterioresDosDiasPosteriores(string fecha)
        {
            List<GrupoH> listado = new List<GrupoH>();
            DateTime fechaTransferir = Convert.ToDateTime(fecha);

            GrupoH oFecha = new GrupoH();
            /* Dias anteiores */
            for (int i = 1; i <= 2; i++)
            {
                oFecha = new GrupoH();
                oFecha.Valor = fechaTransferir.AddDays(i * -1).ToShortDateString();
                oFecha.Descripcion = fechaTransferir.AddDays(i*-1).ToLongDateString().ToUpper();
                listado.Add(oFecha);
            }

            /* Dias posteriores */
            for (int i = 1; i <= 2; i++)
            {
                oFecha = new GrupoH();
                oFecha.Valor = fechaTransferir.AddDays(i).ToShortDateString();
                oFecha.Descripcion = fechaTransferir.AddDays(i).ToLongDateString().ToUpper();
                listado.Add(oFecha);
            }

            return listado;
        }

    }
}
