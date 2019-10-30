using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using System.Globalization;
using System.Threading.Tasks;
using TransportistaMto.Datos;


namespace Transportista.Negocios
{
    public class SJ_RHPensionRefrigerioPersonaNegocio
    {
        private SJ_RHPensionRefrigerioPersonaNegocio modelo;
        private SJM_PersonaParadero oHospedaje;

        public void Registrar(string periodoConsulta, List<ProgramacionRefrigerioMultiples> listadoProgramacion, string nuevoCodigoRegistro)
        {
            int nroRegistros = 0;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoConsulta.ToString().Trim()].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                contexto.CommandTimeout = 9888989;
                oHospedaje = new SJM_PersonaParadero();
                /*1.- Valido que la lista para grabar contengan datos */
                if (listadoProgramacion != null && listadoProgramacion.ToList().Count > 0)
                {
                    /*2.- Sólo voy agregar a la lista los codigos pendientes por general, es decir los que tengan nuevo con código 0 */
                    if (listadoProgramacion.Where(x => x.codigo == 0).ToList().Count > 0)
                    {
                        nroRegistros = listadoProgramacion.Where(x => x.codigo == 0).ToList().Count;
                        /*3.- Realizar registro por cada item de mis lista*/
                        foreach (var oProgramacion in listadoProgramacion)
                        {
                            /* 3.1  Registro o actualizo el colaborador asociado a su hospedaje */
                            #region Registro o actualizo el colaborador asociado a su hospedaje()
                            try
                            {
                                var listadoCoincidenciaHospedaje = contexto.SJM_PersonaParadero.Where(x => x.dniTrabajador.ToString().Trim() == oProgramacion.dniTrabajador.ToString().Trim() && x.estado == 1).ToList();
                                if (listadoCoincidenciaHospedaje.ToList().Count == 1)
                                {
                                    oHospedaje = new SJM_PersonaParadero();
                                    oHospedaje = listadoCoincidenciaHospedaje.Single();

                                    if (oHospedaje.IdParadero.ToString().Trim() != oProgramacion.hospedajeCodigo.ToString().Trim())
                                    {
                                        oHospedaje.estado = 0;
                                        contexto.SubmitChanges();
                                        oHospedaje = new SJM_PersonaParadero();
                                        //oHospedaje.Id = 0;
                                        oHospedaje.idCodigoPersonalGeneral = oProgramacion.codigoPersonalGeneral != null ? oProgramacion.codigoPersonalGeneral : "";
                                        oHospedaje.dniTrabajador = oProgramacion.dniTrabajador != null ? oProgramacion.dniTrabajador : "";
                                        oHospedaje.NombresTrabajador = oProgramacion.nombresTrabajador != null ? oProgramacion.nombresTrabajador : "";
                                        oHospedaje.Fecha = DateTime.Now;
                                        oHospedaje.FechaTransferencia = DateTime.Now;
                                        oHospedaje.IdParadero = oProgramacion.hospedajeCodigo != null ? oProgramacion.hospedajeCodigo : "";
                                        oHospedaje.estado = 1;
                                        oHospedaje.paradero = oProgramacion.hospedajeDescripcion != null ? oProgramacion.hospedajeDescripcion : "";
                                        oHospedaje.direccion = "";
                                        contexto.SJM_PersonaParadero.InsertOnSubmit(oHospedaje);
                                        contexto.SubmitChanges();
                                    }
                                }
                                else if (listadoCoincidenciaHospedaje.ToList().Count == 0)
                                {
                                    oHospedaje = new SJM_PersonaParadero();
                                    //oHospedaje.Id = 0;
                                    oHospedaje.idCodigoPersonalGeneral = oProgramacion.codigoPersonalGeneral != null ? oProgramacion.codigoPersonalGeneral : "";
                                    oHospedaje.dniTrabajador = oProgramacion.dniTrabajador != null ? oProgramacion.dniTrabajador : "";
                                    oHospedaje.NombresTrabajador = oProgramacion.nombresTrabajador != null ? oProgramacion.nombresTrabajador : "";
                                    oHospedaje.Fecha = DateTime.Now;
                                    oHospedaje.FechaTransferencia = DateTime.Now;
                                    oHospedaje.IdParadero = oProgramacion.hospedajeCodigo != null ? oProgramacion.hospedajeCodigo : "";
                                    oHospedaje.estado = 1;
                                    oHospedaje.paradero = oProgramacion.hospedajeDescripcion != null ? oProgramacion.hospedajeDescripcion : "";
                                    oHospedaje.direccion = "";
                                    contexto.SJM_PersonaParadero.InsertOnSubmit(oHospedaje);
                                    contexto.SubmitChanges();
                                }
                            }
                            catch (Exception Ex)
                            {
                                throw Ex;
                            }
                            #endregion

                            /*3.2   Registro la programación de los refrigerios por pensión */
                            #region Registro la programación de los refrigerios por pensión()
                            try
                            {
                                var resultadoProgramacionRefrigerio = contexto.SJ_RHPensionRefrigerioPersonas.Where(x => x.NroDocumento.ToString().Trim() == (oProgramacion.dniTrabajador != null ? oProgramacion.dniTrabajador : "") && x.IdPension.Value == (oProgramacion.pensionCodigo != null ? Convert.ToInt32(oProgramacion.pensionCodigo) : 0) && x.IdEstado.Trim() == "AC" ).ToList();
                                /* 3.2.1 */
                                if (resultadoProgramacionRefrigerio.ToList().Count == 0)
                                {
                                    #region Grabar()
                                    SJ_RHPensionRefrigerioPersona oProgramacionRefrigerio = new SJ_RHPensionRefrigerioPersona();
                                    //oProgramacionRefrigerio.Id = 0;
                                    oProgramacionRefrigerio.idParaderoPersonal = oHospedaje.Id;
                                    oProgramacionRefrigerio.IdCodigoPersonal = oProgramacion.codigoPersonalGeneral != null ? oProgramacion.codigoPersonalGeneral : "";
                                    oProgramacionRefrigerio.NroDocumento = oProgramacion.dniTrabajador != null ? oProgramacion.dniTrabajador : "";
                                    oProgramacionRefrigerio.NombresCompletos = oProgramacion.nombresTrabajador != null ? oProgramacion.nombresTrabajador : "";
                                    oProgramacionRefrigerio.IdSubPlanilla = oProgramacion.codigoSubPlanilla != null ? oProgramacion.codigoSubPlanilla : "";
                                    oProgramacionRefrigerio.SubPlanilla = oProgramacion.subPlanilla != null ? oProgramacion.subPlanilla : "";
                                    oProgramacionRefrigerio.IdPension = oProgramacion.pensionCodigo != null ? oProgramacion.pensionCodigo : 0; /**/

                                    modelo = new SJ_RHPensionRefrigerioPersonaNegocio();
                                    oProgramacionRefrigerio.NroDNIPension = modelo.ObtenerDNIResponsablePension(oProgramacion.pensionCodigo);

                                    oProgramacionRefrigerio.Pension = oProgramacion.pensionDescripcion != null ? oProgramacion.pensionDescripcion : "";
                                    oProgramacionRefrigerio.Condicion = "ACTIVO";
                                    oProgramacionRefrigerio.Desayuno = oProgramacion.desayuno != null ? Convert.ToByte(oProgramacion.desayuno) : Convert.ToByte(0);
                                    oProgramacionRefrigerio.Almuerzo = oProgramacion.almuerzo != null ? Convert.ToByte(oProgramacion.almuerzo) : Convert.ToByte(0);
                                    oProgramacionRefrigerio.Cena = oProgramacion.cena != null ? Convert.ToByte(oProgramacion.cena) : Convert.ToByte(0);
                                    oProgramacionRefrigerio.Otro = Convert.ToByte(0);
                                    oProgramacionRefrigerio.ValidoDesde = oProgramacion.validoDesde;
                                    oProgramacionRefrigerio.ValidoHasta = oProgramacion.validoHasta;
                                    oProgramacionRefrigerio.IdEstado = "AC";
                                    oProgramacionRefrigerio.impreso = 0;
                                    oProgramacionRefrigerio.codigoRegistrado = nuevoCodigoRegistro.ToString().Trim();
                                    oProgramacionRefrigerio.fechaRegistro = DateTime.Now;
                                    oProgramacionRefrigerio.registradoPor = Environment.UserName;

                                    oProgramacionRefrigerio.SJ_RHPensionRefrigerioPersonaDetalles.Add(new SJ_RHPensionRefrigerioPersonaDetalle
                                    {
                                        Id = oProgramacionRefrigerio.Id,
                                        Item = "001",
                                        ValidoDesde = oProgramacion.validoDesde,
                                        ValidoHasta = oProgramacion.validoHasta,
                                        Observacion = "Generado desde registro masivo de programacion de beneficio de refrigrio",
                                        IdEstado = "AC"
                                    });

                                    contexto.SJ_RHPensionRefrigerioPersonas.InsertOnSubmit(oProgramacionRefrigerio);
                                    contexto.SubmitChanges();

                                    SJ_LogTablasPension logTablas = new SJ_LogTablasPension();
                                    logTablas.IDEMPRESA = "001";
                                    logTablas.IDLOG = oProgramacionRefrigerio.Id.ToString().PadLeft(16, '0');
                                    logTablas.ITEM = ObtenerNumeroItemLogTabla(periodoConsulta, oProgramacionRefrigerio.Id.ToString().PadLeft(16, '0'), "SJ_RHPensionRefrigerioPersona");
                                    logTablas.TABLA = "SJ_RHPensionRefrigerioPersona";
                                    logTablas.IDCAMPO = "";
                                    logTablas.CAMPOCLAVE = "";
                                    logTablas.IDTABLA = "Id";
                                    logTablas.EVENTO = "NUEVO";
                                    logTablas.VALORANTERIOR = oProgramacionRefrigerio.NroDocumento + " / " + oProgramacionRefrigerio.Pension;
                                    logTablas.VALORACTUAL = oProgramacionRefrigerio.SubPlanilla;
                                    logTablas.IDUSUARIO = Environment.UserName;
                                    logTablas.MAQUINA = Environment.MachineName;
                                    logTablas.FECHACREACION = DateTime.Now;
                                    logTablas.VENTANA = "ProgramacionRefrigerioxPersonalMantenimiento";
                                    contexto.SJ_LogTablasPension.InsertOnSubmit(logTablas);
                                    contexto.SubmitChanges();

                                    #endregion
                                }
                                /* 3.2.2 */
                                if (resultadoProgramacionRefrigerio.ToList().Count == 1)
                                {
                                    if (resultadoProgramacionRefrigerio.FirstOrDefault().IdEstado != "AN")
                                    {
                                        #region Actualizar()
                                        SJ_RHPensionRefrigerioPersona oProgramacionRefrigerio = new SJ_RHPensionRefrigerioPersona();
                                        //oProgramacionRefrigerio.Id = 0;
                                        oProgramacionRefrigerio = resultadoProgramacionRefrigerio.Single();
                                        oProgramacionRefrigerio.idParaderoPersonal = oHospedaje.Id;
                                        oProgramacionRefrigerio.impreso = 0;
                                        oProgramacionRefrigerio.codigoRegistrado = nuevoCodigoRegistro.ToString().Trim();
                                        //oProgramacionRefrigerio.IdCodigoPersonal = oProgramacion.codigoPersonalGeneral != null ? oProgramacion.codigoPersonalGeneral : "";
                                        //oProgramacionRefrigerio.NroDocumento = oProgramacion.dniTrabajador != null ? oProgramacion.dniTrabajador : "";
                                        //oProgramacionRefrigerio.NombresCompletos = oProgramacion.nombresTrabajador != null ? oProgramacion.nombresTrabajador : "";
                                        //oProgramacionRefrigerio.IdSubPlanilla = oProgramacion.codigoSubPlanilla != null ? oProgramacion.codigoSubPlanilla : "";
                                        //oProgramacionRefrigerio.SubPlanilla = oProgramacion.subPlanilla != null ? oProgramacion.subPlanilla : "";
                                        //oProgramacionRefrigerio.IdPension = oProgramacion.pensionCodigo != null ? oProgramacion.pensionCodigo : 0; /**/

                                        //modelo = new SJ_RHPensionRefrigerioPersonaNegocio();
                                        //oProgramacionRefrigerio.NroDNIPension = modelo.ObtenerDNIResponsablePension(oProgramacion.pensionCodigo);

                                        //oProgramacionRefrigerio.Pension = oProgramacion.pensionDescripcion != null ? oProgramacion.pensionDescripcion : "";
                                        //oProgramacionRefrigerio.Condicion = "ACTIVO";

                                        byte desayuno, almuerzo, cena = 0;
                                        desayuno = oProgramacion.desayuno != null ? Convert.ToByte(oProgramacion.desayuno) : Convert.ToByte(0);
                                        almuerzo = oProgramacion.almuerzo != null ? Convert.ToByte(oProgramacion.almuerzo) : Convert.ToByte(0);
                                        cena = oProgramacion.cena != null ? Convert.ToByte(oProgramacion.cena) : Convert.ToByte(0);


                                        if (desayuno == 1)
                                        {
                                            oProgramacionRefrigerio.Desayuno = 1;
                                        }
                                        if (almuerzo == 1)
                                        {
                                            oProgramacionRefrigerio.Almuerzo = 1;
                                        }

                                        if (cena == 1)
                                        {
                                            oProgramacionRefrigerio.Cena = 1;
                                        }

                                        //oProgramacionRefrigerio.Desayuno = oProgramacion.desayuno != null ? Convert.ToByte(oProgramacion.desayuno) : Convert.ToByte(0);
                                        //oProgramacionRefrigerio.Almuerzo = oProgramacion.almuerzo != null ? Convert.ToByte(oProgramacion.almuerzo) : Convert.ToByte(0);
                                        //oProgramacionRefrigerio.Cena = oProgramacion.cena != null ? Convert.ToByte(oProgramacion.cena) : Convert.ToByte(0);
                                        //oProgramacionRefrigerio.Otro = Convert.ToByte(0);
                                        oProgramacionRefrigerio.ValidoDesde = oProgramacion.validoDesde;
                                        oProgramacionRefrigerio.ValidoHasta = oProgramacion.validoHasta;
                                        //oProgramacionRefrigerio.IdEstado = "AC";
                                        oProgramacionRefrigerio.fechaRegistro = DateTime.Now;
                                        oProgramacionRefrigerio.registradoPor = Environment.UserName;
                                        /* Obtengo la lista de la tabla detalle que estén con un estado activo, con la intensión de cambiarle de estado  */
                                        var detalleAsistenciaRefigerio = oProgramacionRefrigerio.SJ_RHPensionRefrigerioPersonaDetalles.Where(x => x.Id == oProgramacionRefrigerio.Id && x.IdEstado.ToString().Trim() == "AC").ToList();
                                        if (detalleAsistenciaRefigerio != null && detalleAsistenciaRefigerio.ToList().Count > 0)
                                        {
                                            foreach (var itemDetalleRefigerios in detalleAsistenciaRefigerio)
                                            {
                                                SJ_RHPensionRefrigerioPersonaDetalle oDetalleProgramacion = new SJ_RHPensionRefrigerioPersonaDetalle();
                                                oDetalleProgramacion = itemDetalleRefigerios;
                                                oDetalleProgramacion.IdEstado = "CR";
                                                contexto.SubmitChanges();
                                            }
                                        }

                                        modelo = new SJ_RHPensionRefrigerioPersonaNegocio();
                                        string item = modelo.ObtenerUltimoItem(oProgramacionRefrigerio.Id);

                                        /* Asocio un nuevo detalle a la tabla detalle de programación de refrigerios */
                                        oProgramacionRefrigerio.SJ_RHPensionRefrigerioPersonaDetalles.Add(new SJ_RHPensionRefrigerioPersonaDetalle
                                        {
                                            Id = oProgramacionRefrigerio.Id,
                                            Item = modelo.ObtenerUltimoItem(oProgramacionRefrigerio.Id),
                                            ValidoDesde = oProgramacion.validoDesde,
                                            ValidoHasta = oProgramacion.validoHasta,
                                            Observacion = string.Format("Generado desde registro masivo de programacion de beneficio de refrigrio por :{0}", Environment.UserName),
                                            IdEstado = "AC"
                                        });

                                        //contexto.SJ_RHPensionRefrigerioPersonas.InsertOnSubmit(oProgramacionRefrigerio);
                                        contexto.SubmitChanges();

                                        SJ_LogTablasPension logTablas = new SJ_LogTablasPension();
                                        logTablas.IDEMPRESA = "001";
                                        logTablas.IDLOG = oProgramacionRefrigerio.Id.ToString().PadLeft(16, '0');
                                        logTablas.ITEM = ObtenerNumeroItemLogTabla(periodoConsulta, oProgramacionRefrigerio.Id.ToString().PadLeft(16, '0'), "SJ_RHPensionRefrigerioPersona");
                                        logTablas.TABLA = "SJ_RHPensionRefrigerioPersona";
                                        logTablas.IDCAMPO = "";
                                        logTablas.CAMPOCLAVE = "";
                                        logTablas.IDTABLA = "Id";
                                        logTablas.EVENTO = "NUEVO";
                                        logTablas.VALORANTERIOR = oProgramacionRefrigerio.NroDocumento + " / " + oProgramacionRefrigerio.Pension;
                                        logTablas.VALORACTUAL = oProgramacionRefrigerio.SubPlanilla;
                                        logTablas.IDUSUARIO = Environment.UserName;
                                        logTablas.MAQUINA = Environment.MachineName;
                                        logTablas.FECHACREACION = DateTime.Now;
                                        logTablas.VENTANA = "ProgramacionRefrigerioxPersonalMantenimiento";
                                        contexto.SJ_LogTablasPension.InsertOnSubmit(logTablas);
                                        contexto.SubmitChanges();
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Grabar()
                                        SJ_RHPensionRefrigerioPersona oProgramacionRefrigerio = new SJ_RHPensionRefrigerioPersona();
                                        //oProgramacionRefrigerio.Id = 0;
                                        oProgramacionRefrigerio.idParaderoPersonal = oHospedaje.Id;
                                        oProgramacionRefrigerio.IdCodigoPersonal = oProgramacion.codigoPersonalGeneral != null ? oProgramacion.codigoPersonalGeneral : "";
                                        oProgramacionRefrigerio.NroDocumento = oProgramacion.dniTrabajador != null ? oProgramacion.dniTrabajador : "";
                                        oProgramacionRefrigerio.NombresCompletos = oProgramacion.nombresTrabajador != null ? oProgramacion.nombresTrabajador : "";
                                        oProgramacionRefrigerio.IdSubPlanilla = oProgramacion.codigoSubPlanilla != null ? oProgramacion.codigoSubPlanilla : "";
                                        oProgramacionRefrigerio.SubPlanilla = oProgramacion.subPlanilla != null ? oProgramacion.subPlanilla : "";
                                        oProgramacionRefrigerio.IdPension = oProgramacion.pensionCodigo != null ? oProgramacion.pensionCodigo : 0; /**/
                                        modelo = new SJ_RHPensionRefrigerioPersonaNegocio();
                                        oProgramacionRefrigerio.NroDNIPension = modelo.ObtenerDNIResponsablePension(oProgramacion.pensionCodigo);
                                        oProgramacionRefrigerio.Pension = oProgramacion.pensionDescripcion != null ? oProgramacion.pensionDescripcion : "";
                                        oProgramacionRefrigerio.Condicion = "ACTIVO";
                                        oProgramacionRefrigerio.Desayuno = oProgramacion.desayuno != null ? Convert.ToByte(oProgramacion.desayuno) : Convert.ToByte(0);
                                        oProgramacionRefrigerio.Almuerzo = oProgramacion.almuerzo != null ? Convert.ToByte(oProgramacion.almuerzo) : Convert.ToByte(0);
                                        oProgramacionRefrigerio.Cena = oProgramacion.cena != null ? Convert.ToByte(oProgramacion.cena) : Convert.ToByte(0);
                                        oProgramacionRefrigerio.Otro = Convert.ToByte(0);
                                        oProgramacionRefrigerio.ValidoDesde = oProgramacion.validoDesde;
                                        oProgramacionRefrigerio.ValidoHasta = oProgramacion.validoHasta;
                                        oProgramacionRefrigerio.IdEstado = "AC";
                                        oProgramacionRefrigerio.impreso = 0;
                                        oProgramacionRefrigerio.codigoRegistrado = nuevoCodigoRegistro.ToString().Trim();
                                        oProgramacionRefrigerio.fechaRegistro = DateTime.Now;
                                        oProgramacionRefrigerio.registradoPor = Environment.UserName;
                                        oProgramacionRefrigerio.SJ_RHPensionRefrigerioPersonaDetalles.Add(new SJ_RHPensionRefrigerioPersonaDetalle
                                        {
                                            Id = oProgramacionRefrigerio.Id,
                                            Item = "001",
                                            ValidoDesde = oProgramacion.validoDesde,
                                            ValidoHasta = oProgramacion.validoHasta,
                                            Observacion = "Generado desde registro masivo de programacion de beneficio de refrigrio",
                                            IdEstado = "AC"
                                        });
                                        contexto.SJ_RHPensionRefrigerioPersonas.InsertOnSubmit(oProgramacionRefrigerio);
                                        contexto.SubmitChanges();
                                        SJ_LogTablasPension logTablas = new SJ_LogTablasPension();
                                        logTablas.IDEMPRESA = "001";
                                        logTablas.IDLOG = oProgramacionRefrigerio.Id.ToString().PadLeft(16, '0');
                                        logTablas.ITEM = ObtenerNumeroItemLogTabla(periodoConsulta, oProgramacionRefrigerio.Id.ToString().PadLeft(16, '0'), "SJ_RHPensionRefrigerioPersona");
                                        logTablas.TABLA = "SJ_RHPensionRefrigerioPersona";
                                        logTablas.IDCAMPO = "";
                                        logTablas.CAMPOCLAVE = "";
                                        logTablas.IDTABLA = "Id";
                                        logTablas.EVENTO = "NUEVO";
                                        logTablas.VALORANTERIOR = oProgramacionRefrigerio.NroDocumento + " / " + oProgramacionRefrigerio.Pension;
                                        logTablas.VALORACTUAL = oProgramacionRefrigerio.SubPlanilla;
                                        logTablas.IDUSUARIO = Environment.UserName;
                                        logTablas.MAQUINA = Environment.MachineName;
                                        logTablas.FECHACREACION = DateTime.Now;
                                        logTablas.VENTANA = "ProgramacionRefrigerioxPersonalMantenimiento";
                                        contexto.SJ_LogTablasPension.InsertOnSubmit(logTablas);
                                        contexto.SubmitChanges();
                                        #endregion
                                    }                                   
                                }
                                //SJ_RHPensionRefrigerioPersonaDetalle ooProgramacionRefrigerioDetalle = new SJ_RHPensionRefrigerioPersonaDetalle();
                            }
                            catch (Exception Ex)
                            {
                                throw Ex;
                            }
                            #endregion
                        }
                    }
                }
                contexto.Connection.Close();
                contexto.Dispose();
            }
        }

        private string ObtenerUltimoItem(int codigoRegistro)
        {
            string serie = "001";

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                contexto.CommandTimeout = 9888989;
                var resultadoConsulta = contexto.SJ_RHPensionRefrigerioPersonaDetalle.Where(x => x.Id == codigoRegistro).ToList();

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count > 1)
                {
                    int maximoItem = Convert.ToInt32(resultadoConsulta.Max(x => x.Item)) + 1;
                    serie = maximoItem.ToString().PadLeft(3, '0');
                }

                contexto.Connection.Close();
                contexto.Dispose();
            }

            return serie;
        }

        public string ObtenerNumeroItemLogTabla(string periodoConsulta, string codigoRegistro, string nombreTabla)
        {
            string serie = "001";

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

            using (SJ_RHFacturacionTransportistaDataContext contexto = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                contexto.CommandTimeout = 9888989;
                if (contexto.SJ_LogTableObtenerNumeroItemxTablaxCodigo(codigoRegistro.ToString(), nombreTabla).FirstOrDefault().serie != null)
                    serie = contexto.SJ_LogTableObtenerNumeroItemxTablaxCodigo(codigoRegistro.ToString(), nombreTabla).FirstOrDefault().serie;
                else
                    serie = "001";
                contexto.Connection.Close();
                contexto.Dispose();
            }

            return serie;
        }

        private string ObtenerDNIResponsablePension(int codigoPension)
        {
            string dniResponsablePension = string.Empty;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                contexto.CommandTimeout = 9888989;

                var t = Task<List<SJ_RHPension>>.Factory.StartNew(() =>
                {
                    return contexto.SJ_RHPensions.Where(x => x.IdPension == codigoPension).ToList();
                });
                if (t.Result.FirstOrDefault().NroDNI != null)
                    dniResponsablePension = t.Result.FirstOrDefault().NroDNI;
                else
                    dniResponsablePension = "";
                contexto.Connection.Close();
                contexto.Dispose();
            }

            return dniResponsablePension;

        }

        public List<ProgramacionRefrigerioMultiples> ListarItemGuardados(string periodoConsulta, List<ProgramacionRefrigerioMultiples> listadoProgramacion)
        {
            List<ProgramacionRefrigerioMultiples> listado = new List<ProgramacionRefrigerioMultiples>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            int nroRegistros = 0;

            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                contexto.CommandTimeout = 9888989;

                if (listadoProgramacion != null && listadoProgramacion.ToList().Count > 0)
                {
                    /*2.- Sólo voy agregar a la lista los codigos pendientes por general, es decir los que tengan nuevo con código 0 */
                    if (listadoProgramacion.Where(x => x.codigo == 0).ToList().Count > 0)
                    {
                        nroRegistros = listadoProgramacion.Where(x => x.codigo == 0).ToList().Count;
                        /*3.- Realizar registro por cada item de mis lista*/
                        foreach (var oProgramacion in listadoProgramacion)
                        {
                            var resultadoConsulta = contexto.SJ_RHPensionesObtenerProgramaRefrigeriosByHospedajeByNroDocumento(oProgramacion.dniTrabajador.ToString().Trim()).Where(x => x.pensionCodigo == oProgramacion.pensionCodigo ).ToList();

                            if (resultadoConsulta != null && resultadoConsulta.ToList().Count > 0)
                            {
                                foreach (var item in resultadoConsulta)
                                {
                                    ProgramacionRefrigerioMultiples oNuevaProgramacionRefrigerio = new ProgramacionRefrigerioMultiples();
                                    oNuevaProgramacionRefrigerio.codigo = item.codigo;
                                    oNuevaProgramacionRefrigerio.dniTrabajador = item.dniTrabajador != null ? item.dniTrabajador.ToString().Trim() : "";
                                    oNuevaProgramacionRefrigerio.nombresTrabajador = item.nombresTrabajador != null ? item.nombresTrabajador.ToString().Trim() : "";
                                    oNuevaProgramacionRefrigerio.hospedajeCodigo = item.hospedajeCodigo != null ? item.hospedajeCodigo.ToString().Trim() : "";
                                    oNuevaProgramacionRefrigerio.hospedajeDescripcion = item.hospedajeDescripcion != null ? item.hospedajeDescripcion.ToString().Trim() : "";
                                    oNuevaProgramacionRefrigerio.pensionCodigo = item.pensionCodigo != null ? item.pensionCodigo.Value : 0;
                                    oNuevaProgramacionRefrigerio.pensionDescripcion = item.pensionDescripcion != null ? item.pensionDescripcion.ToString().Trim() : "";
                                    oNuevaProgramacionRefrigerio.almuerzo = item.almuerzo != null ? item.almuerzo.Value : 0;
                                    oNuevaProgramacionRefrigerio.desayuno = item.desayuno != null ? item.desayuno.Value : 0;
                                    oNuevaProgramacionRefrigerio.cena = item.cena != null ? item.cena.Value : 0;
                                    oNuevaProgramacionRefrigerio.validoDesde = item.validoDesde != null ? Convert.ToDateTime(item.validoDesde.Value) : DateTime.Now;
                                    oNuevaProgramacionRefrigerio.validoHasta = item.validoHasta != null ? item.validoHasta.Value : DateTime.Now;
                                    oNuevaProgramacionRefrigerio.codigoSubPlanilla = item.codigoSubPlanilla != null ? item.codigoSubPlanilla.ToString().Trim() : "";
                                    oNuevaProgramacionRefrigerio.subPlanilla = item.subPlanilla != null ? item.subPlanilla.ToString().Trim() : "";
                                    oNuevaProgramacionRefrigerio.codigoPersonalGeneral = item.codigoPersonalGeneral != null ? item.codigoPersonalGeneral.ToString().Trim() : "";
                                    listado.Add(oNuevaProgramacionRefrigerio);
                                }
                            }
                        }
                    }
                }

                contexto.Connection.Close();
                contexto.Dispose();
            }

            return listado;
        }

        public string ObtenerCodigoRegistro()
        {
            string cnx, codigoRegistro = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

            using (SJ_RHFacturacionTransportistaDataContext contexto = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                contexto.CommandTimeout = 9888989;

                var resultadoConsulta = contexto.ObtenerId().FirstOrDefault().Codigo;
                codigoRegistro = contexto.ObtenerId().FirstOrDefault().Codigo != null ? contexto.ObtenerId().FirstOrDefault().Codigo : "";
                contexto.Connection.Close();
                contexto.Dispose();
            }

            return codigoRegistro;
        }

        /* Obtener vista agrupada de los registros para imprimir */
        public List<SJ_RHPensionRefrigerioPersonaByAgrupadoCodigoRegistradoResult> ObtenerListaProgramacionAGrupadaByCodigoRegistro()
        {
            List<SJ_RHPensionRefrigerioPersonaByAgrupadoCodigoRegistradoResult> listado = new List<SJ_RHPensionRefrigerioPersonaByAgrupadoCodigoRegistradoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                contexto.CommandTimeout = 9888989;
                 var resultadoConsulta = contexto.SJ_RHPensionRefrigerioPersonaByAgrupadoCodigoRegistrado().ToList();
                listado = resultadoConsulta;
                contexto.Connection.Close();
                contexto.Dispose();
            }

            return listado;
        }

        /* Obtener lista detallada por codigoDeREgistro de la vista agrupada de los registros para imprimir */
        public List<SJ_RHPensionRefrigerioPersonasByDetalleCodigoRegistradoResult> ObtenerDetalleProgramacionByCodigoRegistro(string codigoRegistro)
        {
            List<SJ_RHPensionRefrigerioPersonasByDetalleCodigoRegistradoResult> listado = new List<SJ_RHPensionRefrigerioPersonasByDetalleCodigoRegistradoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                contexto.CommandTimeout = 9888989;
                var resultadoConsulta = contexto.SJ_RHPensionRefrigerioPersonasByDetalleCodigoRegistrado(codigoRegistro).ToList();
                listado = resultadoConsulta;
                contexto.Connection.Close();
                contexto.Dispose();
            }

            return listado;
        }

        /* 23.06.16 proceso anular estado del detalle de la programacion de refrigerios - llamado inconsistencia de programacion de inconsistencia */
        public void ActualizarInconsistenciaProgramacionRefrigerio(string desde, string hasta)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                contexto.CommandTimeout = 9998000;
                contexto.SJ_RHProgramacionRefrigerioActualizarInconsistencias(desde, hasta);
                contexto.Connection.Close();
                contexto.Dispose();
            }
        }

    }
}
