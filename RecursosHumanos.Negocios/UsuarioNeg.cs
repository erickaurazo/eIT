using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;

namespace RecursosHumanos.Negocios
{
    public class UsuarioNeg
    {

        public List<SJ_PrivilegiosListaUsuarioSistemaResult> ObtenerListaUsuarioSistema(string periodo)
        {
            List<SJ_PrivilegiosListaUsuarioSistemaResult> Listado = new List<SJ_PrivilegiosListaUsuarioSistemaResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString()].ToString();

            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800000;
                try
                {
                    Listado = Modelo.SJ_PrivilegiosListaUsuarioSistema().ToList();
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
            return Listado;
        }

        public SJ_PrivilegiosListaUsuarioSistemaxCodigoResult ObtenerUsuarioSistema(string periodo, string idUsuario)
        {
            SJ_PrivilegiosListaUsuarioSistemaxCodigoResult user = new SJ_PrivilegiosListaUsuarioSistemaxCodigoResult();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();
            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800000;
                try
                {
                    user = Modelo.SJ_PrivilegiosListaUsuarioSistemaxCodigo(idUsuario).Single();
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
            return user;
        }

        public void Registrar(string periodo, USUARIO usuario)
        {
            //USUARIO oUsuario = new USUARIO();
            System.IO.StringWriter writer = new System.IO.StringWriter();

            try
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    #region Transaccion()
                    string cnx = string.Empty;
                    cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString()].ToString();
                    using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
                    {
                        #region
                        Modelo.CommandTimeout = 1800000;

                        if (Modelo.SJ_PrivilegiosListaUsuarioSistemaxCodigo(usuario.IDUSUARIO.ToString().Trim()).ToList().Count == 1)
                        {
                            #region Actualizar
                            try
                            {
                                USUARIO oUsuario = new USUARIO();
                                oUsuario = Modelo.USUARIO.Where(x => x.IDUSUARIO.ToString().Trim() == usuario.IDUSUARIO.ToString().Trim()).Single();
                                oUsuario.USR_NOMBRES = usuario.USR_NOMBRES;
                                oUsuario.USR_INICIALES = usuario.USR_INICIALES;
                                oUsuario.EMAIL = usuario.EMAIL;
                                oUsuario.idCodigoGeneral = usuario.idCodigoGeneral;
                                oUsuario.IDCARGO = usuario.IDCARGO;
                                oUsuario.CARGO = usuario.CARGO;
                                oUsuario.IDAREA = usuario.IDAREA;
                                oUsuario.AREA = usuario.AREA;
                                Modelo.SubmitChanges();
                            }
                            catch (Exception Ex)
                            {
                                throw Ex;
                            }
                            #endregion
                        }

                        #endregion
                        Modelo.Connection.Close();
                    }
                    #endregion
                    Scope.Complete();

                }
            }
            catch (TransactionAbortedException ex)
            {
                writer.WriteLine("TransactionAbortedException Message: {0}", ex.Message);
            }
            catch (ApplicationException ex)
            {
                writer.WriteLine("ApplicationException Message: {0}", ex.Message);
            }
        }

        public void CambioEstadoUsuario(string periodo, USUARIO usuario)
        {
            System.IO.StringWriter writer = new System.IO.StringWriter();
            //USUARIO oUsuario = new USUARIO();
            try
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    #region Transaccion()
                    string cnx = string.Empty;
                    cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                    using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
                    {
                        #region
                        Modelo.CommandTimeout = 1800000;
                        try
                        {
                            #region
                            if (Modelo.SJ_PrivilegiosListaUsuarioSistemaxCodigo(usuario.IDUSUARIO.ToString().Trim()).ToList().Count == 1)
                            {

                                USUARIO oUsuario = new USUARIO();
                                oUsuario = Modelo.USUARIO.Where(x => x.IDUSUARIO == usuario.IDUSUARIO.ToString().Trim()).Single();

                                int? estadoUsuario = oUsuario.ESTADO;

                                if (estadoUsuario == 1)
                                {
                                    // baja
                                    oUsuario.ESTADO = 0;
                                    int result = Modelo.SJ_PrivilegiosNotificarBajaUsuarioSistema(usuario.idCodigoGeneral, periodo, usuario.IDUSUARIO);
                                }

                                if (estadoUsuario == 0)
                                {
                                    // alta
                                    oUsuario.ESTADO = 1;
                                    int result = Modelo.SJ_PrivilegiosNotificarAltaUsuarioSistema(usuario.idCodigoGeneral, periodo, usuario.IDUSUARIO);
                                }

                                Modelo.SubmitChanges();
                            #endregion
                            }
                        }
                        catch (Exception Ex)
                        {
                            throw Ex;
                        }
                        #endregion
                    }
                    #endregion
                    Scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                writer.WriteLine("TransactionAbortedException Message: {0}", ex.Message);
            }
            catch (ApplicationException ex)
            {
                writer.WriteLine("ApplicationException Message: {0}", ex.Message);
            }
        }

        public List<SJ_PrivilegiosVerificarFinalizacionContratoTrabajadorResult> VerificarFinalizacionContratoTrabajador(string periodo, string idCodigoGeneral)
        {
            List<SJ_PrivilegiosVerificarFinalizacionContratoTrabajadorResult> listado = new List<SJ_PrivilegiosVerificarFinalizacionContratoTrabajadorResult>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString()].ToString();
            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800000;
                try
                {
                    listado = Modelo.SJ_PrivilegiosVerificarFinalizacionContratoTrabajador(idCodigoGeneral, periodo).ToList();
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }

            return listado;
        }

        public List<SJ_PrivilegiosVerificarAperturaContratoTrabajadorResult> VerificarFinalizacionAperturaTrabajador(string periodo, string idCodigoGeneral)
        {
            List<SJ_PrivilegiosVerificarAperturaContratoTrabajadorResult> listado = new List<SJ_PrivilegiosVerificarAperturaContratoTrabajadorResult>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString()].ToString();
            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800000;
                try
                {
                    listado = Modelo.SJ_PrivilegiosVerificarAperturaContratoTrabajador(idCodigoGeneral, periodo).ToList();
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }

            return listado;
        }

        public List<SJ_PrivilegiosObtenerCargoAreaUsuarioSistemaResult> ObtenerCargoAreaUsuarioSistema(string idCodigoGeneral, string periodo)
        {
            List<SJ_PrivilegiosObtenerCargoAreaUsuarioSistemaResult> listado = new List<SJ_PrivilegiosObtenerCargoAreaUsuarioSistemaResult>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString()].ToString();
            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800000;
                try
                {
                    listado = Modelo.SJ_PrivilegiosObtenerCargoAreaUsuarioSistema(idCodigoGeneral, periodo).ToList();
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }

            return listado;
        }

    }

}
