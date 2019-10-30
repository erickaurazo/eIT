using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using Transportista.Datos;

namespace Transportista.Negocios
{
    public class DocumentoNeg
    {
        private Grupo Doc;
        public List<Grupo> ObtenerIdDocumento(string TipoDoc)
        {
            List<Grupo> Lista = new List<Grupo>();

            switch (TipoDoc)
            {
                case "INTERNO":
                    Doc = new Grupo();
                    Doc.Codigo = "MTL";
                    Lista.Add(Doc);
                    break;
                case "INTERLOCALIDAD":
                    Doc = new Grupo();
                    Doc.Codigo = "MTI";
                    Lista.Add(Doc);
                    break;
                default:

                    break;
            }
            return Lista;
        }


        public List<Grupo> ObtenerNumeroSerie(string TipoDoc)
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
                        if (Modelo.SJ_RHMovimientoMovilidad.Where(x => x.IdDocumento == "MTL").ToList() != null)
                        {
                            if (Modelo.SJ_RHMovimientoMovilidad.Where(x => x.IdDocumento == "MTL").ToList().Count > 0)
                            {
                                NumeroSerie = Modelo.SJ_RHMovimientoMovilidad.Where(x => x.IdDocumento == "MTL").OrderByDescending(x => x.Serie).FirstOrDefault().Serie;
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
                        if (Modelo.SJ_RHMovimientoMovilidad.Where(x => x.IdDocumento == "MTI").ToList() != null)
                        {
                            if (Modelo.SJ_RHMovimientoMovilidad.Where(x => x.IdDocumento == "MTI").ToList().Count > 0)
                            {
                                NumeroSerie = Modelo.SJ_RHMovimientoMovilidad.Where(x => x.IdDocumento == "MTI").OrderByDescending(x => x.Serie).FirstOrDefault().Serie;
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

        public string ObtenerNumeroDocumento(string TipoDoc, string Serie)
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
                        if (Modelo.SJ_RHMovimientoMovilidad.Where(x => x.IdDocumento == "MTL" && x.Serie == Serie).ToList() != null)
                        {
                            if (Modelo.SJ_RHMovimientoMovilidad.Where(x => x.IdDocumento == "MTL" && x.Serie == Serie).ToList().Count > 0)
                            {
                                NumeroSerie = Modelo.SJ_RHMovimientoMovilidad.Where(x => x.IdDocumento == "MTL" && x.Serie == Serie).OrderByDescending(x => x.Serie).FirstOrDefault().Numero;
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
                    
                        if (Modelo.SJ_RHMovimientoMovilidad.Where(x => x.IdDocumento == "MTI" && x.Serie == Serie).ToList() != null)
                        {
                            if (Modelo.SJ_RHMovimientoMovilidad.Where(x => x.IdDocumento == "MTI" && x.Serie == Serie).ToList().Count > 0)
                            {
                                NumeroSerie = Modelo.SJ_RHMovimientoMovilidad.Where(x => x.IdDocumento == "MTI" && x.Serie == Serie).OrderByDescending(x => x.Serie).FirstOrDefault().Numero;
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


    }

}
