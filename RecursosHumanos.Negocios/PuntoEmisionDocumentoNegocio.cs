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


    public class PuntoEmisionDocumentoNegocio
    {

        private string oConexion;


        public PuntoEmisionDocumento ObtenerNumeroSerieByDocumento(string periodoConsulta, PuntoEmisionDocumento Documento)
        {            
            PuntoEmisionDocumento oDocumento = new PuntoEmisionDocumento();
            oDocumento.codigoDocumento = string.Empty;
            oDocumento.serie = "0000";
            oDocumento.numero = "0000000";

            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0,4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                var resultadoConsulta = Modelo.PuntoEmisionDocumento.Where(x => x.codigoDocumento == Documento.codigoDocumento && x.serie == Documento.serie).ToList();
                if (resultadoConsulta.ToList().Count  == 1)
                {
                    oDocumento = resultadoConsulta.Single();
                }
            }

            return oDocumento;
        }

        public List<PuntoEmisionDocumento> ObtenerNumeroSerieByCodigoDocumento(string periodoConsulta, PuntoEmisionDocumento Documento)
        {
            List<PuntoEmisionDocumento> oDocumentos = new List<PuntoEmisionDocumento>();
            PuntoEmisionDocumento oDocumento = new PuntoEmisionDocumento();
            oDocumento.codigoDocumento = string.Empty;
            oDocumento.serie = "0000";
            oDocumento.numero = "0000000";
            oDocumentos.Add(oDocumento);

            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                var resultadoConsulta = Modelo.PuntoEmisionDocumento.Where(x => x.codigoDocumento == Documento.codigoDocumento).ToList();
                if (resultadoConsulta.ToList().Count == 1)
                {
                    oDocumentos = new List<PuntoEmisionDocumento>();
                    oDocumentos = resultadoConsulta.ToList();
                }
            }

            return oDocumentos;
        }

        public string ActualizarNumeroDocumentoBySerie(string periodoConsulta, PuntoEmisionDocumento Documento)
        {
            PuntoEmisionDocumento oDocumento = new PuntoEmisionDocumento();
            oDocumento.codigoDocumento = string.Empty;
            oDocumento.serie = "0000";
            oDocumento.numero = "0000000";
            string estadoResultado = string.Empty;

            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                var resultadoConsulta = Modelo.PuntoEmisionDocumento.Where(x => x.codigoDocumento == Documento.codigoDocumento && x.serie == Documento.serie).ToList();
                if (resultadoConsulta.ToList().Count == 1)
                {
                    int numeroDocumento = 0;
                    oDocumento = resultadoConsulta.Single();
                    numeroDocumento = Convert.ToInt32(oDocumento.numero) + 1;
                    estadoResultado = numeroDocumento.ToString().PadLeft(7, '0');
                    oDocumento.numero = estadoResultado;
                    Modelo.SubmitChanges();

                }
            }

            return estadoResultado;
        }

    }
}
