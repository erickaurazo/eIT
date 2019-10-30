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
    public class AsistenciaNegocio
    {
        private string oConexion = string.Empty;

        public MovimientoAsistencia ObtenerMovimientoAsistenciaByCodigoAsistencia(string periodoConsulta, MovimientoAsistencia oMovimientoAsistencia)
        {
            MovimientoAsistencia movimientoAsistencia = new MovimientoAsistencia();
            using (TransactionScope Scope = new TransactionScope())
            {
                oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
                using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
                {
                    var buscarMovimientoPlanilla = Modelo.MovimientoAsistencia.Where(x => x.codigoAsistencia == oMovimientoAsistencia.codigoAsistencia).ToList();
                    if (buscarMovimientoPlanilla.ToList().Count == 1)
                    {
                        movimientoAsistencia = buscarMovimientoPlanilla.Single();
                    }

                }
                Scope.Complete();
            }

            return movimientoAsistencia;

        }

        public List<MovimientoAsistencia> ObtenerMovimientosAsistenciaByPeriodos(string periodoConsulta, DateTime fechaDesde, DateTime fechaFin)
        {
            List<MovimientoAsistencia> movimientosAsistencia = new List<MovimientoAsistencia>();

            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                movimientosAsistencia = Modelo.MovimientoAsistencia.Where(x => x.fecha >= fechaDesde && x.fecha >= fechaFin).ToList();
            }

            return movimientosAsistencia;

        }

        public List<MovimientoAsistencia> ObtenerMovimientosAsistenciaByPeriodosByPlanilla(string periodoConsulta, DateTime fechaDesde, DateTime fechaFin, string codigoPlanilla)
        {
            List<MovimientoAsistencia> movimientosAsistencia = new List<MovimientoAsistencia>();

            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                movimientosAsistencia = Modelo.MovimientoAsistencia.Where(x => x.fecha >= fechaDesde && x.fecha >= fechaFin && x.codigoPlanilla == codigoPlanilla).ToList();
            }

            return movimientosAsistencia;

        }

        public List<ObtenerListadoAsistenciaByCodigoResult> ObtenerMovimientoAsistenciaByCodigoAsistencia(string periodoConsulta, string CodigoAsistencia)
        {

            List<ObtenerListadoAsistenciaByCodigoResult> listado = new List<ObtenerListadoAsistenciaByCodigoResult>();
            #region
            ObtenerListadoAsistenciaByCodigoResult registro = new ObtenerListadoAsistenciaByCodigoResult();
            registro.codigoEmpresa = string.Empty;
            registro.codigoAsistencia = string.Empty;
            registro.fecha = DateTime.Now;
            registro.codigoPuntoEmisor = string.Empty;
            registro.PuntoEmision = string.Empty;
            registro.codigoPlanilla = string.Empty;
            registro.planilla = string.Empty;
            registro.codigoSucursal = string.Empty;
            registro.sucursal = string.Empty;
            registro.codigoDocumento = string.Empty;
            registro.codigoTurnoTrabajo = string.Empty;
            registro.turno = string.Empty;
            registro.codigoResponsable = string.Empty;
            registro.nombresCompletos = string.Empty;
            registro.codigoEstado = string.Empty;
            registro.estado = string.Empty;
            registro.codigoOperacion = string.Empty;
            registro.operacion = string.Empty;
            registro.serieDocumento = string.Empty;
            registro.numeroRegistroAsistencia = string.Empty;
            registro.numeroOperacion = string.Empty;
            registro.periodo = string.Empty;
            registro.periodoPlanilla = string.Empty;
            registro.semana = string.Empty;
            registro.fechaCreacion = DateTime.Now;
            registro.rendimiento = '0';
            registro.EsResultadoImportacion = 0;
            registro.totalHorasRefrigerio = 0;
            registro.HorasByPlanilla = 0;
            registro.codigoReferencia = string.Empty;
            registro.comentario = string.Empty;
            registro.ventanaReferencia = string.Empty;
            registro.numeroManual = string.Empty;
            registro.procesado = 0;
            registro.fechaInicioAsistencia = DateTime.Now;
            registro.fechaTerminoAsistencia = DateTime.Now;
            registro.estaSincronizado = '0';
            registro.codigoEmpresa = string.Empty;
            registro.codigoAsistencia = string.Empty;
            registro.item = string.Empty;
            registro.codigoConsumidor = string.Empty;
            registro.consumidor = string.Empty;
            registro.codigoActividad = string.Empty;
            registro.actividad = string.Empty;
            registro.codigoLabor = string.Empty;
            registro.labor = string.Empty;
            registro.puntoTomaAsistencia = string.Empty;
            registro.numeroRegistroAsistencia = string.Empty;
            registro.porcentajeAvance = 0;
            registro.tipoAsistencia = 'N';
            registro.horasDobles = 0;
            registro.HorasExtras25 = 0;
            registro.HorasExtras35 = 0;
            registro.totalHorasExtras = 0;
            registro.TotalHoras = 0;
            registro.fechaCreacion = DateTime.Now;
            registro.horasNocturnas = 0;
            registro.horasNocturnasExtras25 = 0;
            registro.horasNocturnasExtras35 = 0;
            listado.Add(registro);
            #endregion

            using (TransactionScope Scope = new TransactionScope())
            {
                oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
                using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
                {
                    listado = Modelo.ObtenerListadoAsistenciaByCodigo(CodigoAsistencia).ToList();

                }
                Scope.Complete();
            }

            return listado;
        }

        public List<ObtenerListadoAsistenciaByPeriodoResult> ObtenerMovimientosAsistenciaByPeriodos(string periodoConsulta, string fechaDesde, string fechaHasta)
        {

            List<ObtenerListadoAsistenciaByPeriodoResult> listado = new List<ObtenerListadoAsistenciaByPeriodoResult>();
            using (TransactionScope Scope = new TransactionScope())
            {
                oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
                using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
                {
                    listado = Modelo.ObtenerListadoAsistenciaByPeriodo(fechaDesde, fechaHasta).ToList();

                }
                Scope.Complete();
            }

            return listado;
        }

        public List<ObtenerListadoAsistenciaByPlanillaBySemanaResult> ObtenerMovimientosAsistenciaByPeriodosByPlanilla(string periodoConsulta, string codigoPlanilla, string semanaPlanilla)
        {
            oConexion = string.Empty;
            List<ObtenerListadoAsistenciaByPlanillaBySemanaResult> listado = new List<ObtenerListadoAsistenciaByPlanillaBySemanaResult>();
            using (TransactionScope Scope = new TransactionScope())
            {
                oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
                using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
                {
                    listado = new List<ObtenerListadoAsistenciaByPlanillaBySemanaResult>();
                    var resultado = Modelo.ObtenerListadoAsistenciaByPlanillaBySemana(codigoPlanilla, semanaPlanilla, periodoConsulta).ToList();

                    listado = resultado;

                }
                Scope.Complete();
            }

            return listado;
        }

        public string GrabarAsistencia(string periodoConsulta, MovimientoAsistencia oMovimientoAsistencia, List<MovimientoAsistenciaDetalle> oDetalleAsistencia, List<MovimientoAsistenciaDetalle> oDetallesEliminar)
        {
            string estadoTransaccion = "Ok";
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                var ObtenerResultadoAsistencia = Modelo.MovimientoAsistencia.Where(x => x.codigoAsistencia == oMovimientoAsistencia.codigoAsistencia).ToList();
                if (ObtenerResultadoAsistencia != null)
                {
                    #region Editar()
                    #region Cabecera
                    if (ObtenerResultadoAsistencia.ToList().Count == 1)
                    {
                        #region
                        MovimientoAsistencia cabecera = new MovimientoAsistencia();
                        cabecera = ObtenerResultadoAsistencia.Single();
                        //cabecera.codigoEmpresa = oMovimientoAsistencia.codigoEmpresa;
                        //cabecera.codigoAsistencia = oMovimientoAsistencia.codigoAsistencia;
                        cabecera.fecha = oMovimientoAsistencia.fecha;
                        //cabecera.codigoPuntoEmisor = oMovimientoAsistencia.codigoPuntoEmisor;
                        cabecera.codigoPlanilla = oMovimientoAsistencia.codigoPlanilla;
                        cabecera.codigoSucursal = oMovimientoAsistencia.codigoSucursal;
                        cabecera.codigoDocumento = oMovimientoAsistencia.codigoDocumento;
                        cabecera.codigoTurnoTrabajo = oMovimientoAsistencia.codigoTurnoTrabajo;
                        cabecera.codigoResponsable = oMovimientoAsistencia.codigoResponsable;
                        cabecera.codigoEstado = oMovimientoAsistencia.codigoEstado;
                        cabecera.codigoOperacion = oMovimientoAsistencia.codigoOperacion;
                        //cabecera.serieDocumento = oMovimientoAsistencia.serieDocumento;
                        //cabecera.numeroRegistroAsistencia = oMovimientoAsistencia.numeroRegistroAsistencia;
                        //cabecera.numeroOperacion = oMovimientoAsistencia.numeroOperacion;
                        cabecera.periodo = oMovimientoAsistencia.periodo;
                        cabecera.periodoPlanilla = oMovimientoAsistencia.periodoPlanilla;
                        cabecera.semana = oMovimientoAsistencia.semana;
                        //cabecera.fechaCreacion = oMovimientoAsistencia.fechaCreacion;
                        // cabecera.rendimiento = oMovimientoAsistencia.rendimiento;
                        //cabecera.esResultadoImportacion = oMovimientoAsistencia.esResultadoImportacion;
                        //cabecera.totalHorasRefrigerio = oMovimientoAsistencia.totalHorasRefrigerio;
                        cabecera.totalHoras = oMovimientoAsistencia.totalHoras;
                        //cabecera.codigoReferencia = oMovimientoAsistencia.codigoReferencia;
                        //cabecera.comentario = oMovimientoAsistencia.comentario;
                        //cabecera.ventanaReferencia = oMovimientoAsistencia.ventanaReferencia;
                        cabecera.numeroManual = oMovimientoAsistencia.numeroManual;
                        //cabecera.procesado = oMovimientoAsistencia.procesado;
                        cabecera.fechaInicioAsistencia = oMovimientoAsistencia.fechaInicioAsistencia;
                        cabecera.fechaTerminoAsistencia = oMovimientoAsistencia.fechaTerminoAsistencia;
                        //cabecera.estaSincronizado = oMovimientoAsistencia.estaSincronizado;

                        #region Eliminar Detalles()
                        foreach (var itemEliminar in oDetallesEliminar)
                        {
                            #region
                            var obteberCoincidenciasDetalleEliminar = Modelo.MovimientoAsistenciaDetalles.Where(x =>
                                   x.codigoAsistencia == itemEliminar.codigoAsistencia
                                && x.codigoEmpresa == itemEliminar.codigoEmpresa
                                && x.item == itemEliminar.item
                                && x.codigoPersona == itemEliminar.codigoPersona
                                && x.codigoActividad == itemEliminar.codigoActividad
                                && x.codigoLabor == itemEliminar.codigoLabor
                                && x.codigoConsumidor == itemEliminar.codigoConsumidor
                                // && x.TotalHoras > 0

                                ).ToList();

                            if (obteberCoincidenciasDetalleEliminar.ToList().Count == 1)
                            {
                                #region Editar()
                                MovimientoAsistenciaDetalle oAsistencia = new MovimientoAsistenciaDetalle();
                                oAsistencia = obteberCoincidenciasDetalleEliminar.Single();
                                Modelo.MovimientoAsistenciaDetalles.DeleteOnSubmit(oAsistencia);
                                Modelo.SubmitChanges();
                                #endregion
                            }
                            #endregion
                        }
                        #endregion

                        #region Registrar Detalle()
                        foreach (var item in oDetalleAsistencia)
                        {
                            #region
                            var obteberCoincidenciasDetalle = Modelo.MovimientoAsistenciaDetalles.Where(x =>
                                   x.codigoAsistencia == item.codigoAsistencia
                                && x.codigoEmpresa == item.codigoEmpresa
                                && x.item == item.item
                                && x.codigoPersona == item.codigoPersona
                                && x.codigoActividad == item.codigoActividad
                                && x.codigoLabor == item.codigoLabor
                                && x.codigoConsumidor == item.codigoConsumidor
                                //&& x.TotalHoras > 0

                                ).ToList();

                            if (obteberCoincidenciasDetalle.ToList().Count == 1)
                            {
                                #region Editar()
                                MovimientoAsistenciaDetalle oAsistencia = new MovimientoAsistenciaDetalle();
                                oAsistencia = obteberCoincidenciasDetalle.Single();
                                //oAsistencia.codigoEmpresa = item.codigoEmpresa;
                                //oAsistencia.codigoAsistencia = item.codigoEmpresa;
                                //oAsistencia.item = item.codigoEmpresa;
                                //oAsistencia.codigoPersona = item.codigoPersona;
                                //oAsistencia.codigoConsumidor = item.codigoConsumidor;
                                //oAsistencia.codigoActividad = item.codigoActividad;
                                //oAsistencia.codigoLabor = item.codigoLabor;
                                //oAsistencia.puntoTomaAsistencia = item.codigoEmpresa;
                                oAsistencia.numeroRegistroAsistencia = item.numeroRegistroAsistencia;
                                oAsistencia.porcentajeAvance = item.porcentajeAvance;
                                oAsistencia.tipoAsistencia = item.tipoAsistencia;
                                oAsistencia.horasDobles = item.horasDobles;
                                oAsistencia.HorasExtras25 = item.HorasExtras25;
                                oAsistencia.HorasExtras35 = item.HorasExtras35;
                                oAsistencia.totalHorasExtras = item.totalHorasExtras;
                                oAsistencia.TotalHoras = item.TotalHoras;
                                oAsistencia.fechaCreacion = item.fechaCreacion;
                                oAsistencia.horasNocturnas = item.horasNocturnas;
                                oAsistencia.horasNocturnasExtras25 = item.horasNocturnasExtras25;
                                oAsistencia.horasNocturnasExtras35 = item.horasNocturnasExtras35;
                                oAsistencia.procesado = item.procesado;
                                oAsistencia.observacion = item.observacion;
                                #endregion
                            }
                            else if (obteberCoincidenciasDetalle.ToList().Count == 0)
                            {
                                #region
                                MovimientoAsistenciaDetalle oAsistencia = new MovimientoAsistenciaDetalle();
                                oAsistencia.codigoEmpresa = item.codigoEmpresa;
                                oAsistencia.codigoAsistencia = item.codigoAsistencia;
                                oAsistencia.item = item.item;
                                oAsistencia.codigoPersona = item.codigoPersona;
                                oAsistencia.codigoConsumidor = item.codigoConsumidor;
                                oAsistencia.codigoActividad = item.codigoActividad;
                                oAsistencia.codigoLabor = item.codigoLabor;
                                oAsistencia.puntoTomaAsistencia = item.puntoTomaAsistencia;
                                oAsistencia.numeroRegistroAsistencia = item.numeroRegistroAsistencia;
                                oAsistencia.porcentajeAvance = item.porcentajeAvance;
                                oAsistencia.tipoAsistencia = item.tipoAsistencia;
                                oAsistencia.horasDobles = item.horasDobles;
                                oAsistencia.HorasExtras25 = item.HorasExtras25;
                                oAsistencia.HorasExtras35 = item.HorasExtras35;
                                oAsistencia.totalHorasExtras = item.totalHorasExtras;
                                oAsistencia.TotalHoras = item.TotalHoras;
                                oAsistencia.fechaCreacion = item.fechaCreacion;
                                oAsistencia.horasNocturnas = item.horasNocturnas;
                                oAsistencia.horasNocturnasExtras25 = item.horasNocturnasExtras25;
                                oAsistencia.horasNocturnasExtras35 = item.horasNocturnasExtras35;
                                oAsistencia.procesado = item.procesado;
                                oAsistencia.observacion = item.observacion;
                                Modelo.MovimientoAsistenciaDetalles.InsertOnSubmit(oAsistencia);
                                #endregion
                            }

                            #endregion
                        }
                        Modelo.SubmitChanges();
                        #endregion
                        #endregion
                    }
                    else
                    {
                        #region Nuevo()
                        #region Nuevo()
                        // Cabecera
                        MovimientoAsistencia cabecera = new MovimientoAsistencia();
                        cabecera.codigoEmpresa = oMovimientoAsistencia.codigoEmpresa;
                        cabecera.codigoAsistencia = oMovimientoAsistencia.codigoAsistencia;
                        cabecera.fecha = oMovimientoAsistencia.fecha;
                        cabecera.codigoPuntoEmisor = oMovimientoAsistencia.codigoPuntoEmisor;
                        cabecera.codigoPlanilla = oMovimientoAsistencia.codigoPlanilla;
                        cabecera.codigoSucursal = oMovimientoAsistencia.codigoSucursal;
                        cabecera.codigoDocumento = oMovimientoAsistencia.codigoDocumento;
                        cabecera.codigoTurnoTrabajo = oMovimientoAsistencia.codigoTurnoTrabajo;
                        cabecera.codigoResponsable = oMovimientoAsistencia.codigoResponsable;
                        cabecera.codigoEstado = oMovimientoAsistencia.codigoEstado;
                        cabecera.codigoOperacion = oMovimientoAsistencia.codigoOperacion;
                        cabecera.serieDocumento = oMovimientoAsistencia.serieDocumento;
                        cabecera.numeroRegistroAsistencia = oMovimientoAsistencia.numeroRegistroAsistencia;
                        cabecera.numeroOperacion = oMovimientoAsistencia.numeroOperacion;
                        cabecera.periodo = oMovimientoAsistencia.periodo;
                        cabecera.periodoPlanilla = oMovimientoAsistencia.periodoPlanilla;
                        cabecera.semana = oMovimientoAsistencia.semana;
                        cabecera.fechaCreacion = oMovimientoAsistencia.fechaCreacion;
                        cabecera.rendimiento = oMovimientoAsistencia.rendimiento;
                        cabecera.esResultadoImportacion = oMovimientoAsistencia.esResultadoImportacion;
                        cabecera.totalHorasRefrigerio = oMovimientoAsistencia.totalHorasRefrigerio;
                        cabecera.totalHoras = oMovimientoAsistencia.totalHoras;
                        cabecera.codigoReferencia = oMovimientoAsistencia.codigoReferencia;
                        cabecera.comentario = oMovimientoAsistencia.comentario;
                        cabecera.ventanaReferencia = oMovimientoAsistencia.ventanaReferencia;
                        cabecera.numeroManual = oMovimientoAsistencia.numeroManual;
                        cabecera.procesado = oMovimientoAsistencia.procesado;
                        cabecera.fechaInicioAsistencia = oMovimientoAsistencia.fechaInicioAsistencia;
                        cabecera.fechaTerminoAsistencia = oMovimientoAsistencia.fechaTerminoAsistencia;
                        cabecera.estaSincronizado = oMovimientoAsistencia.estaSincronizado;
                        Modelo.MovimientoAsistencia.InsertOnSubmit(cabecera);
                        //Modelo.SubmitChanges();


                        // Detalle
                        foreach (var item in oDetalleAsistencia)
                        {
                            if (Modelo.Personas.Where(x => x.codigoPersona == item.codigoPersona).ToList().Count == 0)
                            {

                                var obtenerDatos = Modelo.UserInfo.Where(x => x.Badgenumber == item.codigoPersona).ToList();

                                if (obtenerDatos.ToList().Count == 1)
                                {
                                    Persona oPersona = new Persona();
                                    oPersona.codigoPersona = item.codigoPersona.Trim();
                                    oPersona.nombres = obtenerDatos.FirstOrDefault().Name.ToString().Trim();
                                    //oPersona.sexo = Convert.ToChar(obtenerDatos.FirstOrDefault().Gender.Trim());
                                    oPersona.sincronizado = '1';
                                    oPersona.estado = 1;
                                    //oPersona.fechaNacimiento = Convert.ToDateTime(obtenerDatos.FirstOrDefault().BIRTHDAY);
                                    oPersona.numeroDocumento = item.codigoPersona.Trim();
                                    oPersona.fechaCreacion = DateTime.Now;
                                    Modelo.Personas.InsertOnSubmit(oPersona);
                                    Modelo.SubmitChanges();

                                    MovimientoAsistenciaDetalle oAsistencia = new MovimientoAsistenciaDetalle();
                                    oAsistencia.codigoEmpresa = item.codigoEmpresa;
                                    oAsistencia.codigoAsistencia = item.codigoAsistencia;
                                    oAsistencia.item = item.item;
                                    oAsistencia.codigoPersona = item.codigoPersona.Trim();
                                    oAsistencia.codigoConsumidor = item.codigoConsumidor;
                                    oAsistencia.codigoActividad = item.codigoActividad;
                                    oAsistencia.codigoLabor = item.codigoLabor;
                                    oAsistencia.puntoTomaAsistencia = item.puntoTomaAsistencia;
                                    oAsistencia.numeroRegistroAsistencia = item.numeroRegistroAsistencia;
                                    oAsistencia.porcentajeAvance = item.porcentajeAvance;
                                    oAsistencia.tipoAsistencia = item.tipoAsistencia;
                                    oAsistencia.horasDobles = item.horasDobles;
                                    oAsistencia.HorasExtras25 = item.HorasExtras25;
                                    oAsistencia.HorasExtras35 = item.HorasExtras35;
                                    oAsistencia.totalHorasExtras = item.totalHorasExtras;
                                    oAsistencia.TotalHoras = item.TotalHoras;
                                    oAsistencia.fechaCreacion = item.fechaCreacion;
                                    oAsistencia.horasNocturnas = item.horasNocturnas;
                                    oAsistencia.horasNocturnasExtras25 = item.horasNocturnasExtras25;
                                    oAsistencia.horasNocturnasExtras35 = item.horasNocturnasExtras35;
                                    oAsistencia.procesado = item.procesado;
                                    oAsistencia.observacion = item.observacion;
                                    Modelo.MovimientoAsistenciaDetalles.InsertOnSubmit(oAsistencia);
                                }                                

                            }
                            else
                            {
                                MovimientoAsistenciaDetalle oAsistencia = new MovimientoAsistenciaDetalle();
                                oAsistencia.codigoEmpresa = item.codigoEmpresa;
                                oAsistencia.codigoAsistencia = item.codigoAsistencia;
                                oAsistencia.item = item.item;
                                oAsistencia.codigoPersona = item.codigoPersona;
                                oAsistencia.codigoConsumidor = item.codigoConsumidor;
                                oAsistencia.codigoActividad = item.codigoActividad;
                                oAsistencia.codigoLabor = item.codigoLabor;
                                oAsistencia.puntoTomaAsistencia = item.puntoTomaAsistencia;
                                oAsistencia.numeroRegistroAsistencia = item.numeroRegistroAsistencia;
                                oAsistencia.porcentajeAvance = item.porcentajeAvance;
                                oAsistencia.tipoAsistencia = item.tipoAsistencia;
                                oAsistencia.horasDobles = item.horasDobles;
                                oAsistencia.HorasExtras25 = item.HorasExtras25;
                                oAsistencia.HorasExtras35 = item.HorasExtras35;
                                oAsistencia.totalHorasExtras = item.totalHorasExtras;
                                oAsistencia.TotalHoras = item.TotalHoras;
                                oAsistencia.fechaCreacion = item.fechaCreacion;
                                oAsistencia.horasNocturnas = item.horasNocturnas;
                                oAsistencia.horasNocturnasExtras25 = item.horasNocturnasExtras25;
                                oAsistencia.horasNocturnasExtras35 = item.horasNocturnasExtras35;
                                oAsistencia.procesado = item.procesado;
                                oAsistencia.observacion = item.observacion;
                                Modelo.MovimientoAsistenciaDetalles.InsertOnSubmit(oAsistencia);
                            }


                            //Modelo.SubmitChanges();
                        }

                        #endregion
                        #endregion
                    }
                    #endregion
                    #endregion
                }
                Modelo.SubmitChanges();
            }
            return estadoTransaccion;
        }

        internal MovimientoAsistencia ObtenerUltimoRegistroAsistencia(string periodoConsulta)
        {
            MovimientoAsistencia ultimoMovimiento = new MovimientoAsistencia();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                var resultadoConsulta = Modelo.MovimientoAsistencia.OrderByDescending(x => x.numeroRegistroAsistencia).ToList();

                if (resultadoConsulta.ToList().Count > 0)
                {
                    ultimoMovimiento = resultadoConsulta.ToList().ElementAt(0);
                    ultimoMovimiento.numeroRegistroAsistencia = (Convert.ToInt32(ultimoMovimiento.numeroRegistroAsistencia) + 1).ToString().PadLeft(7, '0');
                    ultimoMovimiento.numeroOperacion = (Convert.ToInt32(ultimoMovimiento.numeroOperacion) + 1).ToString().PadLeft(10, '0');
                }
                else
                {
                    ultimoMovimiento.codigoDocumento = "ASI";
                    ultimoMovimiento.numeroRegistroAsistencia = "0000001";
                    ultimoMovimiento.numeroOperacion = "0000000001";
                    ultimoMovimiento.codigoDocumento = "ASI";
                    ultimoMovimiento.serieDocumento = "0001";
                }


            }

            return ultimoMovimiento;
        }

        public List<ext_ListadoAsistenciaSinceMovimientoPlanillaResult> ObtenerDetalleAsistenciaByPeriodo(string periodoConsulta, string fechaDesde, string fechaHasta)
        {
            List<ext_ListadoAsistenciaSinceMovimientoPlanillaResult> listado = new List<ext_ListadoAsistenciaSinceMovimientoPlanillaResult>();

            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                listado = Modelo.ext_ListadoAsistenciaSinceMovimientoPlanilla(fechaDesde, fechaHasta).ToList();

            }

            return listado;
        }

        public void EliminarDocumento(string periodoConsulta, string codigoMovimiento, string codigoTransferencia)
        {
            string estadoTransaccion = "Ok";
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                var ObtenerResultadoAsistencia = Modelo.MovimientoAsistencia.Where(x => x.codigoAsistencia == codigoMovimiento).ToList();
                if (ObtenerResultadoAsistencia != null)
                {

                    if (ObtenerResultadoAsistencia.ToList().Count == 1)
                    {
                        Modelo.ext_EliminarDocumentoAsistencia(codigoMovimiento, codigoTransferencia);
                    }
                }
            }
        }

        public void AnularDocumento(string periodoConsulta, string codigoMovimiento, string codigoTransferencia)
        {
            string estadoTransaccion = "Ok";
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                var ObtenerResultadoAsistencia = Modelo.MovimientoAsistencia.Where(x => x.codigoAsistencia == codigoMovimiento).ToList();
                if (ObtenerResultadoAsistencia != null)
                {

                    if (ObtenerResultadoAsistencia.ToList().Count == 1)
                    {
                        Modelo.ext_AnularDocumentoAsistencia(codigoMovimiento, codigoTransferencia);
                    }
                }
            }
        }


        public List<ext_ObtenerListadoAsistenciaSemanalResult> ObtenerListadoAsistenciaSemanal(string periodoConsulta, string codigoPlanilla, string semanaDesde, string semanaHasta, string periodoDesde, string periodoHasta)
        {
            List<ext_ObtenerListadoAsistenciaSemanalResult> listado = new List<ext_ObtenerListadoAsistenciaSemanalResult>();

            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                listado = Modelo.ext_ObtenerListadoAsistenciaSemanal(codigoPlanilla, semanaDesde, semanaHasta, periodoDesde, periodoHasta).ToList();
            }

            return listado;
        }





        public List<ext_ObtenerListadoAsistenciaMensualResult> ObtenerListadoAsistenciaMensual(string periodoConsulta, string codigoPlanilla, string semanaDesde, string semanaHasta, string periodoDesde, string periodoHasta, string fechaDesde, string fechaHasta)
        {
            List<ext_ObtenerListadoAsistenciaMensualResult> listado = new List<ext_ObtenerListadoAsistenciaMensualResult>();

            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                listado = Modelo.ext_ObtenerListadoAsistenciaMensual(codigoPlanilla, semanaDesde, semanaHasta, periodoDesde, periodoHasta, fechaDesde, fechaHasta).ToList();
            }

            return listado;
        }

    }
}