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
    public class DocumentoNegocio
    {
        private string oConexion = string.Empty;

        public List<Documento> ObtenerListaDocumentoByCodigoDocumento(string periodoConsulta, string codigoDocumento)
        {
            List<Documento> oDocumentos = new List<Documento>();

            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0,4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                oDocumentos = Modelo.Documento.Where(x => x.codigoDocumento == codigoDocumento).ToList();
            }

            return oDocumentos;

        }

    }
}
