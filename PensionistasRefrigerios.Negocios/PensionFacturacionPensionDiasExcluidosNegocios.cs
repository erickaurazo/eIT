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
    public class PensionFacturacionPensionDiasExcluidosNegocios
    {

        public void Registrar(SJ_RHPensionFacturacionPensionDiasExcluido DiaExcluido)
        {
            SJ_RHPensionFacturacionPensionDiasExcluido oDiaExcluido = new SJ_RHPensionFacturacionPensionDiasExcluido();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
            {
                #region Registro / Actualización()
                Contexto.CommandTimeout = 9999999;
                var resultadoConsulta = Contexto.SJ_RHPensionFacturacionPensionDiasExcluidos.Where(x => x.idFechaExcluida == (DiaExcluido.idFechaExcluida != null ? DiaExcluido.idFechaExcluida : 0)).ToList();
                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                {
                    #region Actualizar()
                    oDiaExcluido = resultadoConsulta.Single();
                    //oDiaExcluido.idFechaExcluida = DiaExcluido.idFechaExcluida;
                    //oDiaExcluido.item = DiaExcluido.item;
                    oDiaExcluido.fecha = DiaExcluido.fecha;
                    oDiaExcluido.observacion = DiaExcluido.observacion;
                    //oDiaExcluido.estado = DiaExcluido.estado;
                    oDiaExcluido.periodo = DiaExcluido.periodo;
                    //oDiaExcluido.machine = DiaExcluido.machine;
                    //oDiaExcluido.usuarioRegistro = DiaExcluido.usuarioRegistro;
                    //oDiaExcluido.fechaRegistro = DiaExcluido.fechaRegistro;
                    oDiaExcluido.aplicaPension = DiaExcluido.aplicaPension;
                    oDiaExcluido.aplicaTransporte = DiaExcluido.aplicaTransporte;
                    oDiaExcluido.aplicaOtros = DiaExcluido.aplicaOtros;
                    Contexto.SubmitChanges();
                    #endregion
                }
                else
                {
                    #region Registrar Uno nuevo()
                    if (DiaExcluido.idFechaExcluida == 0)
                    {
                        oDiaExcluido = new SJ_RHPensionFacturacionPensionDiasExcluido();
                        Contexto.SJ_RHPensionFacturacionPensionDiasExcluidos.DeleteOnSubmit(oDiaExcluido);
                        //oDiaExcluido.idFechaExcluida = DiaExcluido.idFechaExcluida;
                        oDiaExcluido.item = DiaExcluido.item;
                        oDiaExcluido.fecha = DiaExcluido.fecha;
                        oDiaExcluido.observacion = DiaExcluido.observacion;
                        oDiaExcluido.estado = DiaExcluido.estado;
                        oDiaExcluido.periodo = DiaExcluido.periodo;
                        oDiaExcluido.machine = DiaExcluido.machine;
                        oDiaExcluido.usuarioRegistro = DiaExcluido.usuarioRegistro;
                        oDiaExcluido.fechaRegistro = DiaExcluido.fechaRegistro;
                        oDiaExcluido.aplicaPension = DiaExcluido.aplicaPension;
                        oDiaExcluido.aplicaTransporte = DiaExcluido.aplicaTransporte;
                        oDiaExcluido.aplicaOtros = DiaExcluido.aplicaOtros;
                        Contexto.SubmitChanges();
                    }
                    #endregion
                }
                Contexto.Connection.Close();
                #endregion
            }
        }

        public void Registrar(List<SJ_RHPensionFacturacionPensionDiasExcluido> listadoGrillaRegistrar)
        {

            if (listadoGrillaRegistrar != null && listadoGrillaRegistrar.ToList().Count > 0)
            {
                foreach (var DiaExcluido in listadoGrillaRegistrar)
                {
                    #region Registrar()
                    SJ_RHPensionFacturacionPensionDiasExcluido oDiaExcluido = new SJ_RHPensionFacturacionPensionDiasExcluido();
                    string cnx = string.Empty;
                    cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                    using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
                    {
                        #region Registro / Actualización()
                        Contexto.CommandTimeout = 9999999;
                        var resultadoConsulta = Contexto.SJ_RHPensionFacturacionPensionDiasExcluidos.Where(x => x.idFechaExcluida == (DiaExcluido.idFechaExcluida != null ? DiaExcluido.idFechaExcluida : 0)).ToList();
                        if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                        {
                            #region Actualizar()
                            oDiaExcluido = resultadoConsulta.Single();
                            //oDiaExcluido.idFechaExcluida = DiaExcluido.idFechaExcluida;
                            //oDiaExcluido.item = DiaExcluido.item;
                            oDiaExcluido.fecha = DiaExcluido.fecha;
                            oDiaExcluido.observacion = DiaExcluido.observacion;
                            //oDiaExcluido.estado = DiaExcluido.estado;
                            oDiaExcluido.periodo = DiaExcluido.periodo;
                            //oDiaExcluido.machine = DiaExcluido.machine;
                            //oDiaExcluido.usuarioRegistro = DiaExcluido.usuarioRegistro;
                            //oDiaExcluido.fechaRegistro = DiaExcluido.fechaRegistro;
                            oDiaExcluido.aplicaPension = DiaExcluido.aplicaPension;
                            oDiaExcluido.aplicaTransporte = DiaExcluido.aplicaTransporte;
                            oDiaExcluido.aplicaOtros = DiaExcluido.aplicaOtros;
                            Contexto.SubmitChanges();
                            #endregion
                        }
                        else
                        {
                            #region Registrar Uno nuevo()
                            if (DiaExcluido.idFechaExcluida == 0)
                            {
                                oDiaExcluido = new SJ_RHPensionFacturacionPensionDiasExcluido();
                                //Contexto.SJ_RHPensionFacturacionPensionDiasExcluidos.DeleteOnSubmit(oDiaExcluido);
                                //oDiaExcluido.idFechaExcluida = DiaExcluido.idFechaExcluida;
                                oDiaExcluido.item = DiaExcluido.item;
                                oDiaExcluido.fecha = DiaExcluido.fecha;
                                oDiaExcluido.observacion = DiaExcluido.observacion;
                                oDiaExcluido.estado = DiaExcluido.estado;
                                oDiaExcluido.periodo = DiaExcluido.periodo;
                                oDiaExcluido.machine = DiaExcluido.machine;
                                oDiaExcluido.usuarioRegistro = DiaExcluido.usuarioRegistro;
                                oDiaExcluido.fechaRegistro = DiaExcluido.fechaRegistro;
                                oDiaExcluido.aplicaPension = DiaExcluido.aplicaPension;
                                oDiaExcluido.aplicaTransporte = DiaExcluido.aplicaTransporte;
                                oDiaExcluido.aplicaOtros = DiaExcluido.aplicaOtros;
                                Contexto.SJ_RHPensionFacturacionPensionDiasExcluidos.InsertOnSubmit(oDiaExcluido);
                                Contexto.SubmitChanges();
                            }
                            #endregion
                        }
                        Contexto.Connection.Close();
                        #endregion
                    }

                    #endregion
                }
            }


        }

        public void Registrar(List<SJ_RHPensionFacturacionPensionDiasExcluido> listadoGrillaRegistrar, List<SJ_RHPensionFacturacionPensionDiasExcluido> listaEliminados)
        {

            //Eliminar lista de eliminados del formulario()
            if (listaEliminados != null && listaEliminados.ToList().Count > 0)
            {
                foreach (var DiaExcluidoEliminados in listaEliminados)
                {
                    SJ_RHPensionFacturacionPensionDiasExcluido oDiaExcluido = new SJ_RHPensionFacturacionPensionDiasExcluido();
                    string cnx = string.Empty;
                    cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                    using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
                    {
                        var resultadoConsulta = Contexto.SJ_RHPensionFacturacionPensionDiasExcluidos.Where(x => x.idFechaExcluida == (DiaExcluidoEliminados.idFechaExcluida != null ? DiaExcluidoEliminados.idFechaExcluida : 0)).ToList();
                        if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                        {
                            Contexto.CommandTimeout = 98999990;
                            oDiaExcluido = resultadoConsulta.Single();
                            Contexto.SJ_RHPensionFacturacionPensionDiasExcluidos.DeleteOnSubmit(oDiaExcluido);
                            Contexto.SubmitChanges();
                            Contexto.Connection.Close();
                        }
                    }
                }
            }



            //Registrar()
            if (listadoGrillaRegistrar != null && listadoGrillaRegistrar.ToList().Count > 0)
            {
                foreach (var DiaExcluido in listadoGrillaRegistrar)
                {
                    #region Registrar()
                    SJ_RHPensionFacturacionPensionDiasExcluido oDiaExcluido = new SJ_RHPensionFacturacionPensionDiasExcluido();
                    string cnx = string.Empty;
                    cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                    using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
                    {
                        #region Registro / Actualización()
                        Contexto.CommandTimeout = 9999999;
                        var resultadoConsulta = Contexto.SJ_RHPensionFacturacionPensionDiasExcluidos.Where(x => x.idFechaExcluida == (DiaExcluido.idFechaExcluida != null ? DiaExcluido.idFechaExcluida : 0)).ToList();
                        if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                        {
                            #region Actualizar()
                            oDiaExcluido = resultadoConsulta.Single();
                            //oDiaExcluido.idFechaExcluida = DiaExcluido.idFechaExcluida;
                            //oDiaExcluido.item = DiaExcluido.item;
                            oDiaExcluido.fecha = DiaExcluido.fecha;
                            oDiaExcluido.observacion = DiaExcluido.observacion;
                            //oDiaExcluido.estado = DiaExcluido.estado;
                            oDiaExcluido.periodo = DiaExcluido.periodo;
                            //oDiaExcluido.machine = DiaExcluido.machine;
                            //oDiaExcluido.usuarioRegistro = DiaExcluido.usuarioRegistro;
                            //oDiaExcluido.fechaRegistro = DiaExcluido.fechaRegistro;
                            oDiaExcluido.aplicaPension = DiaExcluido.aplicaPension;
                            oDiaExcluido.aplicaTransporte = DiaExcluido.aplicaTransporte;
                            oDiaExcluido.aplicaOtros = DiaExcluido.aplicaOtros;
                            Contexto.SubmitChanges();
                            #endregion
                        }
                        else
                        {
                            #region Registrar Uno nuevo()
                            if (DiaExcluido.idFechaExcluida == 0)
                            {
                                oDiaExcluido = new SJ_RHPensionFacturacionPensionDiasExcluido();
                                // Contexto.SJ_RHPensionFacturacionPensionDiasExcluidos.DeleteOnSubmit(oDiaExcluido);
                                //oDiaExcluido.idFechaExcluida = DiaExcluido.idFechaExcluida;
                                oDiaExcluido.item = DiaExcluido.item;
                                oDiaExcluido.fecha = DiaExcluido.fecha;
                                oDiaExcluido.observacion = DiaExcluido.observacion;
                                oDiaExcluido.estado = DiaExcluido.estado;
                                oDiaExcluido.periodo = DiaExcluido.periodo;
                                oDiaExcluido.machine = DiaExcluido.machine;
                                oDiaExcluido.usuarioRegistro = DiaExcluido.usuarioRegistro;
                                oDiaExcluido.fechaRegistro = DiaExcluido.fechaRegistro;
                                oDiaExcluido.aplicaPension = DiaExcluido.aplicaPension;
                                oDiaExcluido.aplicaTransporte = DiaExcluido.aplicaTransporte;
                                oDiaExcluido.aplicaOtros = DiaExcluido.aplicaOtros;
                                Contexto.SJ_RHPensionFacturacionPensionDiasExcluidos.InsertOnSubmit(oDiaExcluido);
                                Contexto.SubmitChanges();
                            }
                            #endregion
                        }
                        Contexto.Connection.Close();
                        #endregion
                    }

                    #endregion
                }
            }
        }

        public void Anular(SJ_RHPensionFacturacionPensionDiasExcluido DiaExcluido)
        {
            SJ_RHPensionFacturacionPensionDiasExcluido oDiaExcluido = new SJ_RHPensionFacturacionPensionDiasExcluido();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
            {
                Contexto.CommandTimeout = 9999999;
                var resultadoConsulta = Contexto.SJ_RHPensionFacturacionPensionDiasExcluidos.Where(x => x.idFechaExcluida == DiaExcluido.idFechaExcluida).ToList();
                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                {
                    oDiaExcluido = resultadoConsulta.Single();
                    oDiaExcluido.estado = 0;
                    Contexto.SubmitChanges();
                }
                Contexto.Connection.Close();
            }
        }

        public void Eliminar(SJ_RHPensionFacturacionPensionDiasExcluido DiaExcluido)
        {
            SJ_RHPensionFacturacionPensionDiasExcluido oDiaExcluido = new SJ_RHPensionFacturacionPensionDiasExcluido();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
            {
                Contexto.CommandTimeout = 9999999;
                var resultadoConsulta = Contexto.SJ_RHPensionFacturacionPensionDiasExcluidos.Where(x => x.idFechaExcluida == DiaExcluido.idFechaExcluida).ToList();
                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                {
                    oDiaExcluido = resultadoConsulta.Single();
                    Contexto.SJ_RHPensionFacturacionPensionDiasExcluidos.DeleteOnSubmit(oDiaExcluido);
                    Contexto.SubmitChanges();
                }
                Contexto.Connection.Close();
            }
        }

        public List<SJ_RHListarDiasExcluidosParaFacturacionPensionResult> ObtenerListadoDiasExcluidoByFacturacion(string periodo)
        {
            List<SJ_RHListarDiasExcluidosParaFacturacionPensionResult> listado = new List<SJ_RHListarDiasExcluidosParaFacturacionPensionResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Substring(0, 4)].ToString();
            using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
            {
                Contexto.CommandTimeout = 9999999;
                listado = Contexto.SJ_RHListarDiasExcluidosParaFacturacionPension("").ToList();
                Contexto.Connection.Close();
            }
            return listado;
        }

        public SJ_RHListarDiasExcluidosParaFacturacionPensionResult ObtenerDiaExcluidoByFacturacion(string periodo, SJ_RHPensionFacturacionPensionDiasExcluido DiaExcluido)
        {
            SJ_RHListarDiasExcluidosParaFacturacionPensionResult oDiaExcluido = new SJ_RHListarDiasExcluidosParaFacturacionPensionResult();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
            {
                Contexto.CommandTimeout = 9999999;
                oDiaExcluido = Contexto.SJ_RHListarDiasExcluidosParaFacturacionPension("").Where(x => x.idFechaExcluida == DiaExcluido.idFechaExcluida).Single();
                Contexto.Connection.Close();
            }
            return oDiaExcluido;
        }

    }
}
