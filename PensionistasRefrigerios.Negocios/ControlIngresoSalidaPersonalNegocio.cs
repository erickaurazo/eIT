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
    public class ControlIngresoSalidaPersonalNegocio
    {
        private string cnx;



        public void TransferirAsistenciaObservada(string periodo, ASJ_ReporteAsistenciaObservadosResult registroObservado)
        {

            try
            {

                ASJ_DCONTROLINGRESOSALIDA_PERSONAL registroObservadoT = new ASJ_DCONTROLINGRESOSALIDA_PERSONAL();
                ASJ_DCONTROLINGRESOSALIDA_PERSONAL registroObservadoU = new ASJ_DCONTROLINGRESOSALIDA_PERSONAL();
                ASJ_RegistroTransferenciaTransportes registroAsistenciaBusT = new ASJ_RegistroTransferenciaTransportes();

                cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
                using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    Modelo.CommandTimeout = 9999900;
                    using (TransactionScope scope = new TransactionScope())
                    {
                        if (registroObservado != null)
                        {
                            if (registroObservado.IDCONTROLINGRESO != null && registroObservado.ITEM != null)
                            {
                                #region 
                                if (registroObservado.IDCONTROLINGRESO.ToString().Trim() != string.Empty && registroObservado.ITEM.ToString().Trim() != string.Empty)
                                {
                                    // verifico que el registro exista y que no se haya transferido antes.
                                    var listadoRegistroObservado = Modelo.ASJ_DCONTROLINGRESOSALIDA_PERSONAL.Where(x => x.IDCONTROLINGRESO.ToString().Trim() == registroObservado.IDCONTROLINGRESO.ToString().Trim() && x.ITEM.ToString().Trim() == registroObservado.ITEM.ToString().Trim() && x.esimportado == 0).ToList();

                                    if (listadoRegistroObservado.ToList().Count == 1)
                                    {
                                        registroObservadoT = listadoRegistroObservado.ElementAt(0);


                                        // busco que exista asistencia con el código de la cabecera
                                        var listadoRegistroAsistenciaByFecha = Modelo.DCONTROLINGRESOSALIDA_PERSONAL.Where(x => x.IDCONTROLINGRESO == registroObservado.IDCONTROLINGRESO).ToList();
                                        int ultimoCorrelativo = listadoRegistroAsistenciaByFecha.Max(x => x.CORRELATIVO) + 1;
                                        string itemUltimoCorrelativo = Modelo.ASJ_ITEMS_NUEVOS.Where(x => x.numero == ultimoCorrelativo).FirstOrDefault().item.ToString().Trim();

                                        if (listadoRegistroAsistenciaByFecha != null && listadoRegistroAsistenciaByFecha.ToList().Count > 0)
                                        {
                                            // Verifico que no tenga un codigo el item de transferido de la tabla bloqueos en el detalle de ingreso en puerta
                                            var verificarREsultadoTranferido = listadoRegistroAsistenciaByFecha.Where(x => (x.idactividad != null ? x.idactividad.ToString().Trim() : string.Empty) == registroObservadoT.ITEM).ToList();
                                            if (verificarREsultadoTranferido != null && verificarREsultadoTranferido.ToList().Count == 0)
                                            {
                                                #region Registro Nuevo
                                                DCONTROLINGRESOSALIDA_PERSONAL detalleAsistenciaByGarita = new DCONTROLINGRESOSALIDA_PERSONAL();
                                                detalleAsistenciaByGarita.IDEMPRESA = registroObservadoT.IDEMPRESA;
                                                detalleAsistenciaByGarita.IDCONTROLINGRESO = registroObservadoT.IDCONTROLINGRESO;
                                                detalleAsistenciaByGarita.ITEM = itemUltimoCorrelativo;
                                                detalleAsistenciaByGarita.CORRELATIVO = ultimoCorrelativo;
                                                detalleAsistenciaByGarita.IDPERSONAL = registroObservadoT.IDPERSONAL != null ? registroObservadoT.IDPERSONAL.ToString().Trim() : string.Empty;
                                                detalleAsistenciaByGarita.IDPLANILLA = registroObservadoT.IDPLANILLA != null ? registroObservadoT.IDPLANILLA.ToString().Trim() : string.Empty;
                                                detalleAsistenciaByGarita.MARCACION = registroObservadoT.MARCACION != null ? registroObservadoT.MARCACION.ToString().Trim() : string.Empty;
                                                detalleAsistenciaByGarita.FECHA = Convert.ToDateTime(registroObservadoT.FECHA.Value);
                                                detalleAsistenciaByGarita.TIPO = registroObservadoT.TIPO;
                                                detalleAsistenciaByGarita.FECHACREACION = registroObservadoT.FECHACREACION;
                                                detalleAsistenciaByGarita.idgrupo_trabajo = registroObservadoT.idgrupo_trabajo != null ? registroObservadoT.idgrupo_trabajo.ToString().Trim() : string.Empty;
                                                detalleAsistenciaByGarita.idusuario = registroObservadoT.idusuario;
                                                //detalleAsistenciaByGarita.soloctrl_ingresosalida = registroObservadoT.soloctrl_ingresosalida;
                                                detalleAsistenciaByGarita.origen = registroObservadoT.origen != null ? registroObservadoT.origen.ToString().Trim() : string.Empty;
                                                detalleAsistenciaByGarita.esimportado = 1;
                                                //detalleAsistenciaByGarita.garita = registroObservadoT.garita != null ? registroObservadoT.garita.ToString().Trim() : string.Empty;
                                                //detalleAsistenciaByGarita.idmaquina = registroObservadoT.idmaquina != null ? registroObservadoT.idmaquina.ToString().Trim() : string.Empty;
                                                detalleAsistenciaByGarita.regularizacion_tareo = 0;
                                                //detalleAsistenciaByGarita.CODIGO_CONTROL = registroObservadoT.CODIGO_CONTROL;
                                                //detalleAsistenciaByGarita.IDSUBPLANILLA = registroObservadoT.ITEM != null ? registroObservadoT.ITEM.ToString().Trim() : string.Empty;
                                                //detalleAsistenciaByGarita.TIPOMARCACION = registroObservadoT.TIPOMARCACION;
                                                //detalleAsistenciaByGarita.IDHORARIOTRABAJO = registroObservadoT.IDHORARIOTRABAJO;
                                                detalleAsistenciaByGarita.idactividad = registroObservadoT.ITEM != null ? registroObservadoT.ITEM.ToString().Trim() : string.Empty;
                                                detalleAsistenciaByGarita.idlabor = registroObservadoT.idlabor != null ? registroObservadoT.idlabor.ToString().Trim() : string.Empty;
                                                Modelo.DCONTROLINGRESOSALIDA_PERSONAL.InsertOnSubmit(detalleAsistenciaByGarita);
                                                Modelo.SubmitChanges();



                                                if (registroObservadoT.garita != null && registroObservadoT.garita.ToString().Trim() != string.Empty && registroObservadoT.origen.ToString().Trim() == "1")
                                                {
                                                    var listadoAsistenciaByPlacaBusByFecha = Modelo.ASJ_RegistroTransferenciaTransportes.Where(x => x.placa == registroObservadoT.garita.ToString().Trim()
                                                    && x.fecha.Year == registroObservadoT.FECHA.Value.Year
                                                    && x.fecha.Month == registroObservadoT.FECHA.Value.Month
                                                    && x.fecha.Day == registroObservadoT.FECHA.Value.Day
                                                    ).ToList();
                                                    if (listadoAsistenciaByPlacaBusByFecha != null && listadoAsistenciaByPlacaBusByFecha.ToList().Count > 0)
                                                    {
                                                        registroAsistenciaBusT = listadoAsistenciaByPlacaBusByFecha.ElementAt(0);
                                                    }

                                                    //Validar o ingresar también la asistencia en transportes
                                                    ASJ_RegistroTransferenciaTransportes registroAsistenciaBus = new ASJ_RegistroTransferenciaTransportes();
                                                    //registroAsistenciaBus.idRegistroMovil = registroAsistenciaBus.idRegistroMovil;
                                                    registroAsistenciaBus.placa = registroObservadoT.garita.Trim();
                                                    registroAsistenciaBus.idRutaOrigen = registroAsistenciaBusT.idRutaOrigen;
                                                    registroAsistenciaBus.idCodigoGeneral = registroObservadoT.IDPERSONAL.Trim();
                                                    registroAsistenciaBus.fecha = Convert.ToDateTime(registroAsistenciaBusT.fecha);
                                                    registroAsistenciaBus.imei = Environment.UserName;
                                                    registroAsistenciaBus.dniConductor = registroAsistenciaBusT.dniConductor;
                                                    registroAsistenciaBus.estado = 1;
                                                    registroAsistenciaBus.codigoTransferencia = string.Empty;
                                                    registroAsistenciaBus.idpuerta = 1;

                                                    switch (registroObservadoT.idusuario.Trim())
                                                    {
                                                        case "bota":
                                                            registroAsistenciaBus.idpuerta = 1;
                                                            break;
                                                        case "jjara":
                                                            registroAsistenciaBus.idpuerta = 1;
                                                            break;
                                                        case "pkguvabota":
                                                            registroAsistenciaBus.idpuerta = 1;
                                                            break;

                                                        case "balsa":
                                                            registroAsistenciaBus.idpuerta = 2;
                                                            break;

                                                        case "imp":
                                                            registroAsistenciaBus.idpuerta = 5;
                                                            break;

                                                        case "tablazo":
                                                            registroAsistenciaBus.idpuerta = 3;
                                                            break;
                                                        case "eanastacio":
                                                            registroAsistenciaBus.idpuerta = 4;
                                                            break;
                                                        default:
                                                            registroAsistenciaBus.idpuerta = 1;
                                                            break;
                                                    }
                                                    registroAsistenciaBus.longitud = string.Empty;
                                                    registroAsistenciaBus.codigo_proceso = string.Empty;
                                                    registroAsistenciaBus.latitud = string.Empty;
                                                    //registroAsistenciaBus.tipoAsistencia = registroAsistenciaBus.tipoAsistencia;
                                                    registroAsistenciaBus.TIPO = registroObservadoT.TIPO != (char?)null ? Convert.ToChar(registroObservadoT.TIPO) : Convert.ToChar("I");
                                                    registroAsistenciaBus.IDCONTROLINGRESO = registroObservadoT.IDCONTROLINGRESO.Trim();
                                                    registroAsistenciaBus.item = registroObservadoT.ITEM.Trim();
                                                    registroAsistenciaBus.fechaTransferencia = DateTime.Now;
                                                    registroAsistenciaBus.usuarioTransferencia = Environment.UserName.Trim();
                                                    Modelo.ASJ_RegistroTransferenciaTransportes.InsertOnSubmit(registroAsistenciaBus);
                                                    Modelo.SubmitChanges();
                                                }

                                                Modelo.ASJ_ActualizarAsistenciaObservada(registroObservado.IDCONTROLINGRESO.ToString().Trim(), registroObservado.ITEM.ToString().Trim());
                                                #endregion
                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                        }
                        scope.Complete();
                    }

                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }


        }


        public void TransferirAsistenciasObservadaByPersona(string periodo, ASJ_ReporteAsistenciaObservadosResult registroObservado)
        {

            try
            {

                ASJ_DCONTROLINGRESOSALIDA_PERSONAL registroObservadoT = new ASJ_DCONTROLINGRESOSALIDA_PERSONAL();
                ASJ_DCONTROLINGRESOSALIDA_PERSONAL registroObservadoU = new ASJ_DCONTROLINGRESOSALIDA_PERSONAL();
                ASJ_RegistroTransferenciaTransportes registroAsistenciaBusT = new ASJ_RegistroTransferenciaTransportes();

                cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
                using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    Modelo.CommandTimeout = 9999900;
                    using (TransactionScope scope = new TransactionScope())
                    {
                        if (registroObservado != null)
                        {
                            if (registroObservado.IDCONTROLINGRESO != null && registroObservado.ITEM != null)
                            {
                                #region 
                                if (registroObservado.IDCONTROLINGRESO.ToString().Trim() != string.Empty && registroObservado.ITEM.ToString().Trim() != string.Empty)
                                {
                                    // verifico que el registro exista y que no se haya transferido antes.
                                    var listadoRegistroObservado = Modelo.ASJ_DCONTROLINGRESOSALIDA_PERSONAL.Where(x => x.IDCONTROLINGRESO.ToString().Trim() == registroObservado.IDCONTROLINGRESO.ToString().Trim() && x.ITEM.ToString().Trim() == registroObservado.ITEM.ToString().Trim() && x.esimportado == 0).ToList();

                                    if (listadoRegistroObservado.ToList().Count == 1)
                                    {
                                        registroObservadoT = listadoRegistroObservado.ElementAt(0);


                                        // busco que exista asistencia con el código de la cabecera
                                        var listadoRegistroAsistenciaByFecha = Modelo.DCONTROLINGRESOSALIDA_PERSONAL.Where(x => x.IDCONTROLINGRESO == registroObservado.IDCONTROLINGRESO).ToList();
                                        int ultimoCorrelativo = listadoRegistroAsistenciaByFecha.Max(x => x.CORRELATIVO) + 1;
                                        string itemUltimoCorrelativo = Modelo.ASJ_ITEMS_NUEVOS.Where(x => x.numero == ultimoCorrelativo).FirstOrDefault().item.ToString().Trim();

                                        if (listadoRegistroAsistenciaByFecha != null && listadoRegistroAsistenciaByFecha.ToList().Count > 0)
                                        {
                                            // Verifico que no tenga un codigo el item de transferido de la tabla bloqueos en el detalle de ingreso en puerta
                                            var verificarREsultadoTranferido = listadoRegistroAsistenciaByFecha.Where(x => (x.idactividad != null ? x.idactividad.ToString().Trim() : string.Empty) == registroObservadoT.ITEM).ToList();
                                            if (verificarREsultadoTranferido != null && verificarREsultadoTranferido.ToList().Count == 0)
                                            {
                                                #region Registro Nuevo
                                                DCONTROLINGRESOSALIDA_PERSONAL detalleAsistenciaByGarita = new DCONTROLINGRESOSALIDA_PERSONAL();
                                                detalleAsistenciaByGarita.IDEMPRESA = registroObservadoT.IDEMPRESA;
                                                detalleAsistenciaByGarita.IDCONTROLINGRESO = registroObservadoT.IDCONTROLINGRESO;
                                                detalleAsistenciaByGarita.ITEM = itemUltimoCorrelativo;
                                                detalleAsistenciaByGarita.CORRELATIVO = ultimoCorrelativo;
                                                detalleAsistenciaByGarita.IDPERSONAL = registroObservadoT.IDPERSONAL != null ? registroObservadoT.IDPERSONAL.ToString().Trim() : string.Empty;
                                                detalleAsistenciaByGarita.IDPLANILLA = registroObservadoT.IDPLANILLA != null ? registroObservadoT.IDPLANILLA.ToString().Trim() : string.Empty;
                                                detalleAsistenciaByGarita.MARCACION = registroObservadoT.MARCACION != null ? registroObservadoT.MARCACION.ToString().Trim() : string.Empty;
                                                detalleAsistenciaByGarita.FECHA = Convert.ToDateTime(registroObservadoT.FECHA.Value);
                                                detalleAsistenciaByGarita.TIPO = registroObservadoT.TIPO;
                                                detalleAsistenciaByGarita.FECHACREACION = registroObservadoT.FECHACREACION;
                                                detalleAsistenciaByGarita.idgrupo_trabajo = registroObservadoT.idgrupo_trabajo != null ? registroObservadoT.idgrupo_trabajo.ToString().Trim() : string.Empty;
                                                detalleAsistenciaByGarita.idusuario = registroObservadoT.idusuario;
                                                //detalleAsistenciaByGarita.soloctrl_ingresosalida = registroObservadoT.soloctrl_ingresosalida;
                                                detalleAsistenciaByGarita.origen = registroObservadoT.origen != null ? registroObservadoT.origen.ToString().Trim() : string.Empty;
                                                detalleAsistenciaByGarita.esimportado = 1;
                                                //detalleAsistenciaByGarita.garita = registroObservadoT.garita != null ? registroObservadoT.garita.ToString().Trim() : string.Empty;
                                                //detalleAsistenciaByGarita.idmaquina = registroObservadoT.idmaquina != null ? registroObservadoT.idmaquina.ToString().Trim() : string.Empty;
                                                detalleAsistenciaByGarita.regularizacion_tareo = 0;
                                                //detalleAsistenciaByGarita.CODIGO_CONTROL = registroObservadoT.CODIGO_CONTROL;
                                                //detalleAsistenciaByGarita.IDSUBPLANILLA = registroObservadoT.ITEM != null ? registroObservadoT.ITEM.ToString().Trim() : string.Empty;
                                                //detalleAsistenciaByGarita.TIPOMARCACION = registroObservadoT.TIPOMARCACION;
                                                //detalleAsistenciaByGarita.IDHORARIOTRABAJO = registroObservadoT.IDHORARIOTRABAJO;
                                                detalleAsistenciaByGarita.idactividad = registroObservadoT.ITEM != null ? registroObservadoT.ITEM.ToString().Trim() : string.Empty;
                                                detalleAsistenciaByGarita.idlabor = registroObservadoT.idlabor != null ? registroObservadoT.idlabor.ToString().Trim() : string.Empty;
                                                Modelo.DCONTROLINGRESOSALIDA_PERSONAL.InsertOnSubmit(detalleAsistenciaByGarita);
                                                Modelo.SubmitChanges();



                                                if (registroObservadoT.garita != null && registroObservadoT.garita.ToString().Trim() != string.Empty && registroObservadoT.origen.ToString().Trim() == "1")
                                                {
                                                    var listadoAsistenciaByPlacaBusByFecha = Modelo.ASJ_RegistroTransferenciaTransportes.Where(x => x.placa == registroObservadoT.garita.ToString().Trim()
                                                    && x.fecha.Year == registroObservadoT.FECHA.Value.Year
                                                    && x.fecha.Month == registroObservadoT.FECHA.Value.Month
                                                    && x.fecha.Day == registroObservadoT.FECHA.Value.Day
                                                    ).ToList();
                                                    if (listadoAsistenciaByPlacaBusByFecha != null && listadoAsistenciaByPlacaBusByFecha.ToList().Count > 0)
                                                    {
                                                        registroAsistenciaBusT = listadoAsistenciaByPlacaBusByFecha.ElementAt(0);
                                                    }

                                                    //Validar o ingresar también la asistencia en transportes
                                                    ASJ_RegistroTransferenciaTransportes registroAsistenciaBus = new ASJ_RegistroTransferenciaTransportes();
                                                    //registroAsistenciaBus.idRegistroMovil = registroAsistenciaBus.idRegistroMovil;
                                                    registroAsistenciaBus.placa = registroObservadoT.garita.Trim();
                                                    registroAsistenciaBus.idRutaOrigen = registroAsistenciaBusT.idRutaOrigen;
                                                    registroAsistenciaBus.idCodigoGeneral = registroObservadoT.IDPERSONAL.Trim();
                                                    registroAsistenciaBus.fecha = Convert.ToDateTime(registroObservadoT.FECHA);
                                                    registroAsistenciaBus.imei = Environment.UserName;
                                                    registroAsistenciaBus.dniConductor = registroAsistenciaBusT.dniConductor != null ? registroAsistenciaBusT.dniConductor.Trim() : string.Empty;
                                                    registroAsistenciaBus.estado = 1;
                                                    registroAsistenciaBus.codigoTransferencia = string.Empty;
                                                    registroAsistenciaBus.idpuerta = 1;

                                                    switch (registroObservadoT.idusuario.Trim())
                                                    {
                                                        case "bota":
                                                            registroAsistenciaBus.idpuerta = 1;
                                                            break;
                                                        case "jjara":
                                                            registroAsistenciaBus.idpuerta = 1;
                                                            break;
                                                        case "pkguvabota":
                                                            registroAsistenciaBus.idpuerta = 1;
                                                            break;

                                                        case "balsa":
                                                            registroAsistenciaBus.idpuerta = 2;
                                                            break;

                                                        case "imp":
                                                            registroAsistenciaBus.idpuerta = 5;
                                                            break;

                                                        case "tablazo":
                                                            registroAsistenciaBus.idpuerta = 3;
                                                            break;
                                                        case "eanastacio":
                                                            registroAsistenciaBus.idpuerta = 4;
                                                            break;
                                                        default:
                                                            registroAsistenciaBus.idpuerta = 1;
                                                            break;
                                                    }
                                                    registroAsistenciaBus.longitud = string.Empty;
                                                    registroAsistenciaBus.codigo_proceso = string.Empty;
                                                    registroAsistenciaBus.latitud = string.Empty;
                                                    //registroAsistenciaBus.tipoAsistencia = registroAsistenciaBus.tipoAsistencia;
                                                    registroAsistenciaBus.TIPO = registroObservadoT.TIPO != (char?)null ? Convert.ToChar(registroObservadoT.TIPO) : Convert.ToChar("I");
                                                    registroAsistenciaBus.IDCONTROLINGRESO = registroObservadoT.IDCONTROLINGRESO.Trim();
                                                    registroAsistenciaBus.item = registroObservadoT.ITEM.Trim();
                                                    registroAsistenciaBus.fechaTransferencia = DateTime.Now;
                                                    registroAsistenciaBus.usuarioTransferencia = Environment.UserName.Trim();
                                                    Modelo.ASJ_RegistroTransferenciaTransportes.InsertOnSubmit(registroAsistenciaBus);
                                                    Modelo.SubmitChanges();
                                                }

                                                Modelo.ASJ_ActualizarAsistenciaObservada(registroObservado.IDCONTROLINGRESO.ToString().Trim(), registroObservado.ITEM.ToString().Trim());
                                                #endregion
                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                        }
                        scope.Complete();
                    }

                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }


        public void ActualizarDNIAsistenciaObservada(string periodo, string codigo, string item, string dni)
        {
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Modelo.CommandTimeout = 9999900;
                using (TransactionScope scope = new TransactionScope())
                {
                    Modelo.ASJ_ActualizarDNIAsistenciaObservada(codigo, item, dni);
                    scope.Complete();
                }
            }

        }


    }
}
