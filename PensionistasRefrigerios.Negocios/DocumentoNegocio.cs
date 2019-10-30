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
    public class DocumentoNegocio
    {
        private Grupo Doc;

        public List<Grupo> ObtenerIdDocumentoMovimientoTransportista(string TipoDoc)
        {
            List<Grupo> Lista = new List<Grupo>();

            switch (TipoDoc)
            {
                case "INTERNO":
                    Doc = new Grupo();
                    Doc.Codigo = "MTL";
                    Doc.Descripcion = "MTL";
                    Doc.Valor = "MTL";
                    Lista.Add(Doc);
                    break;
                case "INTERLOCALIDAD":
                    Doc = new Grupo();
                    Doc.Codigo = "MTI";
                    Doc.Descripcion = "MTI";
                    Doc.Valor = "MTI";
                    Lista.Add(Doc);
                    break;
                default:

                    break;
            }
            return Lista;
        }

        public List<Grupo> ObtenerNumeroSerieMovimientoTransportista(string TipoDoc)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            List<Grupo> Lista = new List<Grupo>();
            string NumeroSerie = "0001";
            switch (TipoDoc)
            {
                case "INTERNO":
                    #region Local
                    using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                    {
                        if (Modelo.SJ_RHMovimientoMovilidads.Where(x => x.IdDocumento == "MTL").ToList() != null)
                        {
                            if (Modelo.SJ_RHMovimientoMovilidads.Where(x => x.IdDocumento == "MTL").ToList().Count > 0)
                            {
                                NumeroSerie = Modelo.SJ_RHMovimientoMovilidads.Where(x => x.IdDocumento == "MTL").OrderByDescending(x => x.Serie).FirstOrDefault().Serie;
                            }
                        }
                        Modelo.Connection.Close();
                    }
                    Doc = new Grupo();
                    Doc.Codigo = NumeroSerie;
                    Doc.Descripcion = NumeroSerie;
                    Lista.Add(Doc);
                    #endregion
                    break;
                case "INTERLOCALIDAD":
                    #region InterLocalidad
                    using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                    {
                        if (Modelo.SJ_RHMovimientoMovilidads.Where(x => x.IdDocumento == "MTI").ToList() != null)
                        {
                            if (Modelo.SJ_RHMovimientoMovilidads.Where(x => x.IdDocumento == "MTI").ToList().Count > 0)
                            {
                                NumeroSerie = Modelo.SJ_RHMovimientoMovilidads.Where(x => x.IdDocumento == "MTI").OrderByDescending(x => x.Serie).FirstOrDefault().Serie;
                            }
                        }

                        Modelo.Connection.Close();
                    }
                    Doc = new Grupo();
                    Doc.Codigo = NumeroSerie;
                    Doc.Descripcion = NumeroSerie;
                    Lista.Add(Doc);
                    #endregion
                    break;
                default:
                    #region
                    Doc = new Grupo();
                    Doc.Codigo = NumeroSerie;
                    Doc.Descripcion = NumeroSerie;
                    Lista.Add(Doc);
                    #endregion
                    break;
            }


            return Lista;
        }

        public string ObtenerNumeroDocumentoMovimientoTransportista(string TipoDoc, string Serie)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            List<Grupo> Lista = new List<Grupo>();
            string NumeroSerie = "0000001";
            switch (TipoDoc)
            {
                case "INTERNO":
                    #region Local
                    using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                    {
                        if (Modelo.SJ_RHMovimientoMovilidads.Where(x => x.IdDocumento == "MTL" && x.Serie == Serie).ToList() != null)
                        {
                            if (Modelo.SJ_RHMovimientoMovilidads.Where(x => x.IdDocumento == "MTL" && x.Serie == Serie).ToList().Count > 0)
                            {
                                NumeroSerie = Modelo.SJ_RHMovimientoMovilidads.Where(x => x.IdDocumento == "MTL" && x.Serie == Serie).OrderByDescending(x => x.Serie).FirstOrDefault().Numero;
                                int num = Convert.ToInt32(NumeroSerie) + 1;
                                NumeroSerie = AsignarFormatoNumeroDocumento(num);
                            }
                        }
                        Modelo.Connection.Close();
                    }
                    #endregion
                    break;
                case "INTERLOCALIDAD":
                    using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                    {

                        if (Modelo.SJ_RHMovimientoMovilidads.Where(x => x.IdDocumento == "MTI" && x.Serie == Serie).ToList() != null)
                        {
                            if (Modelo.SJ_RHMovimientoMovilidads.Where(x => x.IdDocumento == "MTI" && x.Serie == Serie).ToList().Count > 0)
                            {
                                NumeroSerie = Modelo.SJ_RHMovimientoMovilidads.Where(x => x.IdDocumento == "MTI" && x.Serie == Serie).OrderByDescending(x => x.Serie).FirstOrDefault().Numero;
                                int num = Convert.ToInt32(NumeroSerie) + 1;
                                NumeroSerie = AsignarFormatoNumeroDocumento(num);
                            }
                        }
                        Modelo.Connection.Close();
                    }
                    break;
                default:
                    #region
                    NumeroSerie = "0000001";
                    #endregion
                    break;
            }


            return NumeroSerie;
        }

        private string AsignarFormatoNumeroDocumento(int numero)
        {
            string nNumero = "";

            switch (numero.ToString().Length)
            {
                case 1:
                    nNumero = "000000" + numero.ToString();
                    break;

                case 2:
                    nNumero = "00000" + numero.ToString();
                    break;

                case 3:
                    nNumero = "0000" + numero.ToString();
                    break;

                case 4:
                    nNumero = "000" + numero.ToString();
                    break;


                case 5:
                    nNumero = "00" + numero.ToString();
                    break;


                case 6:
                    nNumero = "0" + numero.ToString();
                    break;

                case 7:
                    nNumero = numero.ToString();
                    break;

                default:
                    break;
            }

            return nNumero;
        }

        public List<Grupo> ObtenerIdDocumentoVentaProveedor()
        {
            List<Grupo> Lista = new List<Grupo>();
            Doc = new Grupo();
            Doc.Codigo = "BOL"; /*BOLETA DE VENTA*/
            Doc.Descripcion = "BOL"; /*BOLETA DE VENTA*/
            Lista.Add(Doc);

            Doc = new Grupo();
            Doc.Codigo = "FAC"; /*FACTURA*/
            Doc.Descripcion = "FAC"; /*FACTURA*/
            Lista.Add(Doc);

            return Lista;
        }

        public List<Grupo> ObtenerSeriesDocumentoVentaProveedor()
        {
            List<Grupo> Lista = new List<Grupo>();
            Doc = new Grupo();
            Doc.Codigo = "001";
            Doc.Descripcion = "001";
            Lista.Add(Doc);


            Doc = new Grupo();
            Doc.Codigo = "002";
            Doc.Descripcion = "002";
            Lista.Add(Doc);

            Doc = new Grupo();
            Doc.Codigo = "003";
            Doc.Descripcion = "003";
            Lista.Add(Doc);


            Doc = new Grupo();
            Doc.Codigo = "004";
            Doc.Descripcion = "004";
            Lista.Add(Doc);

            Doc = new Grupo();
            Doc.Codigo = "005";
            Doc.Descripcion = "005";
            Lista.Add(Doc);


            Doc = new Grupo();
            Doc.Codigo = "006";
            Doc.Descripcion = "006";
            Lista.Add(Doc);

            Doc = new Grupo();
            Doc.Codigo = "007";
            Doc.Descripcion = "007";
            Lista.Add(Doc);


            Doc = new Grupo();
            Doc.Codigo = "008";
            Doc.Descripcion = "008";
            Lista.Add(Doc);

            Doc = new Grupo();
            Doc.Codigo = "009";
            Doc.Descripcion = "009";
            Lista.Add(Doc);

            return Lista;
        }

        //public List<Grupo> ListaCamposAgricolas()
        public List<DFormatoSimple> ListaCamposAgricolas()
        {
            List<DFormatoSimple> Campos = new List<DFormatoSimple>();
            //List<Grupo> Campos = new List<Grupo>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {

                var listaConsumidor = Modelo.CONSUMIDOR.Where(x => x.ESTADO.Value == 1).ToList();
                Campos = (from item in listaConsumidor
                          where item.IDCONSUMIDOR != null && item.IDCONSUMIDOR.ToString().Trim() != ""
                          group item by new { item.IDCONSUMIDOR } into j
                          //select new Grupo
                          select new DFormatoSimple
                         {
                             Codigo = j.Key.IDCONSUMIDOR.ToString().Trim(),
                             Descripcion = j.FirstOrDefault().DESCRIPCION.ToString().Trim()
                         }).ToList();
            }

            return Campos;
        }

        public string ObtenerNombreCamposAgricola(string idConsumidor)
        {
            string descripcion = string.Empty;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {

                var listaConsumidor = Modelo.CONSUMIDOR.Where(x => x.ESTADO.Value == 1 && x.IDCONSUMIDOR.ToString().Trim() == idConsumidor.ToString().Trim()).ToList();
                descripcion = (listaConsumidor != null && listaConsumidor.ToList().Count > 0) ? listaConsumidor.FirstOrDefault().DESCRIPCION.ToString().Trim() : "";
            }

            return descripcion;
        }

        // REGISTRO ASISTENCIA REFRIGERIO RAR
        public List<Grupo> ObtenerIdDocumentoRegistroAsistenciaRefrigerio()
        {
            List<Grupo> Lista = new List<Grupo>();

            string cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
            {
                
            }

            Doc = new Grupo();
            Doc.Codigo = "RAR";
            Doc.Descripcion = "RAR";
            Doc.Valor = "RAR";
            Lista.Add(Doc);

            return Lista;
        }

        public List<Grupo> ObtenerSerieRegistroAsistenciaRefrigerio()
        {
            List<Grupo> Lista = new List<Grupo>();
            Doc = new Grupo();
            Doc.Codigo = "0001";
            Doc.Descripcion = "0001";
            Doc.Valor = "0001";
            Lista.Add(Doc);

            return Lista;
        }

        public string ObtenerNumeroDocumentoRegistroAsistenciaRefrigerio()
        {
            string Numero = string.Empty;
            string cnx = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Numero = "0000000";
            }

            return Numero;
        }


        public SJ_ObtenerDocumentoMovimientoResult ObtenerDocumentoMovimientoxCodDocumento(string codigoDocumento)
        {
            SJ_ObtenerDocumentoMovimientoResult oDoc = new SJ_ObtenerDocumentoMovimientoResult();
            oDoc.IDDOCUMENTO = "";
            oDoc.SERIE = "0000";
            oDoc.NUMERO = "0000000";

            try
            {
                string cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
                {
                    if (Modelo.SJ_ObtenerDocumentoMovimiento(codigoDocumento) != null && Modelo.SJ_ObtenerDocumentoMovimiento(codigoDocumento).ToList().Count > 0)
                    {
                        oDoc = new SJ_ObtenerDocumentoMovimientoResult();
                        oDoc = Modelo.SJ_ObtenerDocumentoMovimiento(codigoDocumento).Single();
                    }
                    
                }
            }
            catch (Exception Ex)
            {
                
                throw Ex;
            }

            return oDoc;
        }

        public string ObtenerCodigoMovimiento()
        {
            string codigo = "";
            try
            {
                string cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    if (Modelo.ObtenerId() != null && Modelo.ObtenerId().ToList().Count == 1)
                    {

                        codigo = Modelo.ObtenerId().FirstOrDefault().Codigo.Trim();
                    }

                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return codigo;
        }

        // obtener IDDOCUMENTO FACTURACION TRANSPORTISTAS
        public List<Grupo> ObtenerIdDocumentoFacturacionTransportista()
        {
            List<Grupo> Lista = new List<Grupo>();

            Doc = new Grupo();
            Doc.Codigo = "FCP";
            Doc.Descripcion = "FCP";
            Doc.Valor = "FCP";
            Lista.Add(Doc);

            return Lista;
        }

        public List<Grupo> ObtenerSerieFacturacionTransportista()
        {
            List<Grupo> Lista = new List<Grupo>();
            Doc = new Grupo();
            Doc.Codigo = "0001";
            Doc.Descripcion = "0001";
            Doc.Valor = "0001";
            Lista.Add(Doc);

            return Lista;
        }

        public string ObtenerNumeroDocumentoFacturacionTransportista()
        {
            string Numero = string.Empty;
            string cnx = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Numero = Modelo.SJ_RHPagarDocObtenerNumeroDocumento().FirstOrDefault().Numero != null ? Modelo.SJ_RHPagarDocObtenerNumeroDocumento().FirstOrDefault().Numero.ToString().Trim() : "0000001";
            }

            return Numero;
        }


        // obtener IDDOCUMENTO FACTURACION TRANSPORTISTAS
        public List<Grupo> ObtenerIdDocumentoProveedor()
        {
            List<Grupo> Lista = new List<Grupo>();

            Doc = new Grupo();
            Doc.Codigo = "FAC";
            Doc.Descripcion = "FAC";
            Doc.Valor = "FAC";
            Lista.Add(Doc);

            Doc = new Grupo();
            Doc.Codigo = "BOL";
            Doc.Descripcion = "BOL";
            Doc.Valor = "BOL";
            Lista.Add(Doc);

            return Lista;
        }

        public List<Grupo> ObtenerSerieProveedor()
        {
            List<Grupo> Lista = new List<Grupo>();
            Doc = new Grupo();
            Doc.Codigo = "0001";
            Doc.Descripcion = "0001";
            Doc.Valor = "0001";
            Lista.Add(Doc);

            return Lista;
        }

        public string ObtenerNumeroDocumentoProveedor()
        {
            string Numero = string.Empty;
            Numero = "0000000";
            return Numero;
        }

    }

}
