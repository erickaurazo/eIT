﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using TransportistaMto.Datos;
using System.Configuration;

namespace TransportistaMto.Negocios
{
    public class ASJ_PersonalBloqueoNegocio
    {
        string cnx = string.Empty;
        public string Grabar(string periodo, ASJ_PersonalBloqueo personalBloqueado)
        {
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            List<ASJ_PersonalBloqueo> resultadoConsulta = new List<ASJ_PersonalBloqueo>();
            ASJ_PersonalBloqueo oPersonalBloqueado = new ASJ_PersonalBloqueo();

            using (SJ_RHFacturacionTransportistaDataContext modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                modelo.CommandTimeout = 9999900;
                resultadoConsulta = modelo.ASJ_PersonalBloqueo.Where(x => x.codigoPersonalBloqueo == personalBloqueado.codigoPersonalBloqueo).ToList();
                

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                {
                    #region Editar()
                    oPersonalBloqueado = resultadoConsulta.Single();
                    oPersonalBloqueado.codigoPersonalGeneral = personalBloqueado.codigoPersonalGeneral != null ? personalBloqueado.codigoPersonalGeneral.Trim() : string.Empty;
                    //oPersonalBloqueado.codigoPersonalBloqueo = personalBloqueado.codigoPersonalBloqueo != (int?)null ? Convert.ToInt32(personalBloqueado.codigoPersonalBloqueo) : 0;                    
                    oPersonalBloqueado.codigoBloqueo = personalBloqueado.codigoBloqueo != null ? personalBloqueado.codigoBloqueo.Trim() : string.Empty;
                    oPersonalBloqueado.esPeriodo = personalBloqueado.esPeriodo != (char?)null ? Convert.ToChar(personalBloqueado.esPeriodo) : Convert.ToChar("1");
                    //oPersonalBloqueado.fechaRegistro = personalBloqueado.fechaRegistro != null ? personalBloqueado.fechaRegistro : DateTime.Now;
                    oPersonalBloqueado.inicioBloqueo = personalBloqueado.inicioBloqueo != (DateTime?)null ? personalBloqueado.inicioBloqueo : DateTime.Now;
                    oPersonalBloqueado.terminoBloqueo = personalBloqueado.terminoBloqueo != (DateTime?)null ? personalBloqueado.terminoBloqueo : DateTime.Now;
                    oPersonalBloqueado.observaciones = personalBloqueado.observaciones != null ? personalBloqueado.observaciones.Trim() : string.Empty;
                    oPersonalBloqueado.estado = personalBloqueado.estado;
                    modelo.SubmitChanges();
                    resultado = "Transacción de actualización satisfactorio";
                    modelo.sp_ASJ_LISTA_PERSONAL_ASISTENCIA();
                    #endregion
                }
                else if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 0)
                {
                    #region Registrar()
                    oPersonalBloqueado = new ASJ_PersonalBloqueo();
                    oPersonalBloqueado.codigoPersonalGeneral = personalBloqueado.codigoPersonalGeneral != null ? personalBloqueado.codigoPersonalGeneral.Trim() : string.Empty;
                    //oPersonalBloqueado.codigoPersonalBloqueo = personalBloqueado.codigoPersonalBloqueo != (int?)null ? Convert.ToInt32(personalBloqueado.codigoPersonalBloqueo) : 0;                    
                    oPersonalBloqueado.codigoBloqueo = personalBloqueado.codigoBloqueo != null ? personalBloqueado.codigoBloqueo.Trim() : string.Empty;
                    oPersonalBloqueado.esPeriodo = personalBloqueado.esPeriodo != (char?)null ? Convert.ToChar(personalBloqueado.esPeriodo) : Convert.ToChar("1");
                    oPersonalBloqueado.fechaRegistro = personalBloqueado.fechaRegistro != null ? personalBloqueado.fechaRegistro : DateTime.Now;
                    oPersonalBloqueado.inicioBloqueo = personalBloqueado.inicioBloqueo != (DateTime?)null ? personalBloqueado.inicioBloqueo : DateTime.Now;
                    oPersonalBloqueado.terminoBloqueo = personalBloqueado.terminoBloqueo != (DateTime?)null ? personalBloqueado.terminoBloqueo : DateTime.Now;
                    oPersonalBloqueado.observaciones = personalBloqueado.observaciones != null ? personalBloqueado.observaciones.Trim() : string.Empty;
                    oPersonalBloqueado.estado = personalBloqueado.estado;
                    modelo.ASJ_PersonalBloqueo.InsertOnSubmit(oPersonalBloqueado);
                    modelo.SubmitChanges();
                    resultado = "Transacción satisfactorio";
                    modelo.sp_ASJ_LISTA_PERSONAL_ASISTENCIA();
                    #endregion
                }
            }

            return resultado;
        }

        public string GrabarListadoPersonalBloqueado(string periodo, List<ASJ_PersonalBloqueo> listadoPersonalBloqueo)
        {
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            List<ASJ_PersonalTipoBloqueo> resultadoConsulta = new List<ASJ_PersonalTipoBloqueo>();
            ASJ_PersonalTipoBloqueo oTipoBloqueo = new ASJ_PersonalTipoBloqueo();

            if (listadoPersonalBloqueo != null && listadoPersonalBloqueo.ToList().Count > 0)
            {

            }


            

                return resultado;
        }

        public string Anular(string periodo, ASJ_PersonalBloqueo personalBloqueo)
        {
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            List<ASJ_PersonalBloqueo> resultadoConsulta = new List<ASJ_PersonalBloqueo>();
            ASJ_PersonalBloqueo oTipoBloqueo = new ASJ_PersonalBloqueo();

            using (SJ_RHFacturacionTransportistaDataContext modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                modelo.CommandTimeout = 9999900;
                resultadoConsulta = modelo.ASJ_PersonalBloqueo.Where(x => x.codigoPersonalBloqueo == personalBloqueo.codigoPersonalBloqueo).ToList();
                

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                {
                    #region Activar o Anular()
                    oTipoBloqueo = resultadoConsulta.Single();


                    if (oTipoBloqueo.estado == 1)
                    {
                        oTipoBloqueo.estado = 0;
                        resultado = "Registro Anulado";
                    }
                    else if (oTipoBloqueo.estado == 0)
                    {
                        oTipoBloqueo.estado = 1;
                        resultado = "Registro Activado";
                    }

                    modelo.SubmitChanges();
                    
                    #endregion
                }

            }

            return resultado;
        }

        public string Eliminar(string periodo, ASJ_PersonalBloqueo personalBloqueo)
        {
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            List<ASJ_PersonalBloqueo> resultadoConsulta = new List<ASJ_PersonalBloqueo>();
            ASJ_PersonalBloqueo oTipoBloqueo = new ASJ_PersonalBloqueo();

            using (SJ_RHFacturacionTransportistaDataContext modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                modelo.CommandTimeout = 9999900;
                resultadoConsulta = modelo.ASJ_PersonalBloqueo.Where(x => x.codigoPersonalBloqueo == personalBloqueo.codigoPersonalBloqueo).ToList();                

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                {
                    #region Activar o Anular()
                    oTipoBloqueo = resultadoConsulta.Single();


                    if (oTipoBloqueo.estado == 1)
                    {
                        modelo.ASJ_PersonalBloqueo.DeleteOnSubmit(oTipoBloqueo);
                        resultado = "Registro Eliminado";
                    }
                    else if (oTipoBloqueo.estado == 0)
                    {                        
                        resultado = "No se puede eliminar registro anulado";
                    }

                    modelo.SubmitChanges();

                    #endregion
                }

            }

            return resultado;
        }

        public List<ASJ_ObtenerListadoDePersonalbloqueadoResult> ObtenerListado(string periodo)
        {
            List<ASJ_ObtenerListadoDePersonalbloqueadoResult> listado = new List<ASJ_ObtenerListadoDePersonalbloqueadoResult>();

            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Modelo.CommandTimeout = 9999900;
                listado = Modelo.ASJ_ObtenerListadoDePersonalbloqueado().ToList();
            }

            return listado;
        }

    }
}
