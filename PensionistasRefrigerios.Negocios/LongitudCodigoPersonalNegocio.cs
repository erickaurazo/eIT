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
    public class LongitudCodigoPersonalNegocio
    {

        public PEMPRESA ObtenerPEmpresa(string nombreCampo)
        {
            PEMPRESA ObtenerPEmpresa = new PEMPRESA();

            string cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9998888;

                var ResultadoConsulta = Modelo.PEMPRESAs.Where(x => x.PARAMETRO.ToString().Trim().ToUpper() == nombreCampo.Trim().ToUpper()).ToList();

                if (ResultadoConsulta != null && ResultadoConsulta.ToList().Count == 1)
                {
                    ObtenerPEmpresa = new PEMPRESA();
                    ObtenerPEmpresa = ResultadoConsulta.Single();
                }

                Modelo.Connection.Close();
                Modelo.Dispose();

            }
            return ObtenerPEmpresa;
        }


        public void RegistrarPEmpresa(PEMPRESA parametroEmpresa)
        {
            PEMPRESA ObtenerPEmpresa = new PEMPRESA();

            string cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9998888;

                var ResultadoConsulta = Modelo.PEMPRESAs.Where(x => x.PARAMETRO.ToString().Trim().ToUpper() == parametroEmpresa.PARAMETRO.Trim().ToUpper()).ToList();

                if (ResultadoConsulta != null && ResultadoConsulta.ToList().Count == 1)
                {
                    ObtenerPEmpresa = new PEMPRESA();
                    ObtenerPEmpresa = ResultadoConsulta.Single();
                    ObtenerPEmpresa.VALOR = parametroEmpresa.VALOR;
                    Modelo.SubmitChanges();
                }

                Modelo.Connection.Close();
                Modelo.Dispose();

            }

        }

    }
}
