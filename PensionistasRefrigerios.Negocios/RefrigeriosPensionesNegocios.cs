using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Transactions;
using System.IO;

using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista.Negocios
{
    public class RefrigeriosPensionesNegocios
    {

        private List<SJM_RefrigerioPensionesPersonalListaAsistenciaResult> ListaAsistencias;
        private List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult> ListaDescanzoMedico;
        private List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult> ListaLicenciaPermiso;
        private List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult> ListaSuspencion;
        private List<SJM_RefrigerioPensionesPersonalListaVacacionesResult> ListaVacaciones;
        private List<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult> listadoAsistenciaCampoxHoras;
        private decimal? TotalDistribuido;
        private decimal? ImportexPersonaListadoDesayuno = 0;
        private decimal? ImportexPersonaListadoAlmuerzo = 0;
        private decimal? ImportexPersonaListadoCena = 0;
        private List<string> detalleTrabajadoresSinAsistencia = new List<string>();
        private List<string> listaCodigoTrabajadoresSinAsistenciaDesayuno;
        private List<string> listaCodigoTrabajadoresSinAsistenciaAlmuerzo;
        private List<string> listaCodigoTrabajadoresSinAsistenciaCena;
        private decimal? ImportexPersonaxFactura = 0;
        private decimal? ImportexPersonaxFacturaDesayuno = 0;
        private decimal? ImportexPersonaxFacturaAlmuerzo = 0;
        private decimal? ImportexPersonaxFacturaCena = 0;

        private List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult> Lista;

        public List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult> ListarRefriferioPensionistasGeneral(string Desde, string Hasta, string codigoProveedor)
        {
            List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult> Listado = new List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year];
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                try
                {
                    Modelo.CommandTimeout = 9899900;
                    Listado = Modelo.SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacion(Desde, Hasta, codigoProveedor).ToList();
                    Modelo.Connection.Close();
                    Modelo.Dispose();
                }
                catch (Exception Exeption)
                {
                    throw Exeption;
                }

            }
            return Listado;
        }

        public List<RefrigerioAgrupado> ListadoRefriferioPensionistasGeneralAgrupado(string Desde, string Hasta, string codigoProveedor)
        {
            List<RefrigerioAgrupado> ListadoRefrigerios = new List<RefrigerioAgrupado>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1899900;
                try
                {
                    Lista = new List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult>();
                    var ListaResultadoConsulta = Modelo.SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacion(Desde, Hasta, codigoProveedor).ToList();

                    /* OBTENGO EL CODIGO POR TRANSFERENCIA GENERALMENTE ASOCIADO A MAS DE UN DETALLE DE LA LISTA OBTENIDA */
                    var AgruparResultadoPorCodigoTransferencia = (from item in ListaResultadoConsulta
                                                                  where item.IdPension != null
                                                                  group item by new { item.IdPension } into j
                                                                  select new
                                                                  {
                                                                      codigoTransferencia = j.Key.IdPension,
                                                                  }
                                                                      ).ToList();


                    if (AgruparResultadoPorCodigoTransferencia != null && AgruparResultadoPorCodigoTransferencia.ToList().Count > 0)
                    {
                        #region Realizar agrupamientos()
                        foreach (var itemCodigoTransferencia in AgruparResultadoPorCodigoTransferencia)
                        {
                            #region
                            var resultadoByItem = ListaResultadoConsulta.Where(x => x.IdPension == itemCodigoTransferencia.codigoTransferencia).ToList();

                            if (resultadoByItem != null && resultadoByItem.ToList().Count > 0)
                            {
                                #region Asignar nuevo objeto()

                                try
                                {
                                    SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult registroTransferencia = new SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult();
                                    registroTransferencia.IdPension = itemCodigoTransferencia.codigoTransferencia;
                                    registroTransferencia.DniPension = resultadoByItem.LastOrDefault().DniPension != null ? resultadoByItem.LastOrDefault().DniPension.Trim() : "";
                                    registroTransferencia.NombresPension = resultadoByItem.LastOrDefault().NombresPension != null ? resultadoByItem.LastOrDefault().NombresPension.ToString().Trim() : "";
                                    registroTransferencia.DniTrabajador = resultadoByItem.LastOrDefault().DniTrabajador != null ? resultadoByItem.LastOrDefault().DniTrabajador.ToString().Trim() : "";
                                    registroTransferencia.CodigoPersonal = resultadoByItem.LastOrDefault().CodigoPersonal != null ? resultadoByItem.LastOrDefault().CodigoPersonal.ToString().Trim() : "";
                                    registroTransferencia.NombresTrabajador = resultadoByItem.LastOrDefault().NombresTrabajador != null ? resultadoByItem.LastOrDefault().NombresTrabajador.ToString().Trim() : "";
                                    registroTransferencia.TipoRefrigerio = resultadoByItem.LastOrDefault().TipoRefrigerio != null ? resultadoByItem.LastOrDefault().TipoRefrigerio : 3;
                                    registroTransferencia.Refrigerio = resultadoByItem.LastOrDefault().DniPension != null ? resultadoByItem.LastOrDefault().DniPension.ToString().Trim() : "";
                                    registroTransferencia.Importe = resultadoByItem.LastOrDefault().Importe != null ? resultadoByItem.LastOrDefault().Importe : 0;
                                    registroTransferencia.FechaRefrigerio = resultadoByItem.LastOrDefault().FechaRefrigerio != null ? resultadoByItem.LastOrDefault().FechaRefrigerio : DateTime.Now.ToShortDateString();
                                    registroTransferencia.FechaRegistro = resultadoByItem.LastOrDefault().FechaRegistro != null ? resultadoByItem.LastOrDefault().FechaRegistro.Value : (DateTime?)null;

                                    DateTime fechaIngreso;
                                    fechaIngreso = resultadoByItem.LastOrDefault().FechaIngreso != null ? resultadoByItem.Max(x => x.FechaIngreso != (DateTime?)null ? x.FechaIngreso : DateTime.Now) : DateTime.Now;
                                    registroTransferencia.FechaIngreso = fechaIngreso;
                                    registroTransferencia.FechaCese = resultadoByItem.LastOrDefault().FechaCese != null ? resultadoByItem.Max(x => x.FechaCese.Value) : (DateTime?)null;


                                    var listaSubPlanillasByLista = (from itemSubPlanilla in resultadoByItem
                                                                    where itemSubPlanilla.SubPlanilla != null
                                                                    group itemSubPlanilla by new { itemSubPlanilla.SubPlanilla } into j
                                                                    select new
                                                                    {
                                                                        iSubplanilla = j.Key.SubPlanilla.ToString().Trim(),
                                                                    }).ToList();

                                    string subPlanilla = "";
                                    foreach (var itemBylistaSubPlanillasByLista in listaSubPlanillasByLista)
                                    {
                                        subPlanilla += itemBylistaSubPlanillasByLista.iSubplanilla + " ";
                                    }
                                    registroTransferencia.SubPlanilla = subPlanilla != null ? subPlanilla.ToString().Trim() : "";

                                    var ultimoRegistro = resultadoByItem.Where(x => x.FechaIngreso >= fechaIngreso).ToList();

                                    registroTransferencia.Condicion = (ultimoRegistro != null && ultimoRegistro.ToList().Count > 0 && ultimoRegistro.LastOrDefault().Condicion != null) ? ultimoRegistro.LastOrDefault().Condicion.ToString().Trim() : "";
                                    registroTransferencia.idPlanilla = (ultimoRegistro != null && ultimoRegistro.ToList().Count > 0 && ultimoRegistro.LastOrDefault().idPlanilla != null) ? ultimoRegistro.LastOrDefault().idPlanilla.ToString().Trim() : "";
                                    registroTransferencia.esActivoEnPlanilla = (ultimoRegistro != null && ultimoRegistro.ToList().Count > 0 && ultimoRegistro.LastOrDefault().esActivoEnPlanilla != null) ? ultimoRegistro.LastOrDefault().esActivoEnPlanilla : 0;
                                    registroTransferencia.idSituacion = (ultimoRegistro != null && ultimoRegistro.ToList().Count > 0 && ultimoRegistro.LastOrDefault().idSituacion != null) ? ultimoRegistro.LastOrDefault().idSituacion.ToString().Trim() : "";
                                    registroTransferencia.idHospedaje = resultadoByItem.LastOrDefault().idHospedaje != null ? resultadoByItem.LastOrDefault().idHospedaje.ToString().Trim() : "";
                                    registroTransferencia.hospedaje = resultadoByItem.LastOrDefault().hospedaje != null ? resultadoByItem.LastOrDefault().hospedaje.ToString().Trim() : "";

                                    Lista.Add(registroTransferencia);
                                }
                                catch (Exception Ex)
                                {
                                    throw Ex;
                                }

                                #endregion
                            }

                            #endregion
                        }
                        #endregion
                    }



                    ListaAsistencias = new List<SJM_RefrigerioPensionesPersonalListaAsistenciaResult>();
                    //ListaAsistencias = ObtenerListaInasistencias(Desde, Hasta).ToList();

                    ListaDescanzoMedico = new List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult>();
                    ListaDescanzoMedico = ObtenerListaDescanzoMedico(Desde, Hasta).ToList();

                    ListaLicenciaPermiso = new List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult>();
                    ListaLicenciaPermiso = ObtenerListaLicenciaPermiso(Desde, Hasta).ToList();

                    ListaSuspencion = new List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult>();
                    ListaSuspencion = ObtenerListaSuspencion(Desde, Hasta).ToList();

                    ListaVacaciones = new List<SJM_RefrigerioPensionesPersonalListaVacacionesResult>();
                    ListaVacaciones = ObtenerListaVacaciones(Desde, Hasta).ToList();

                    if (Lista != null)
                    {
                        #region Lista de Fechas()
                        //Obtener listas Fechas
                        var ListaFechas = (from item in Lista
                                           where item.DniPension != null
                                           group item by new { item.FechaRefrigerio } into j
                                           select new
                                           {
                                               Id = j.Key.FechaRefrigerio.ToString().Trim(),
                                               Valor = j.Key.FechaRefrigerio.ToString().Trim(),
                                           }).OrderBy(x => x.Id).ToList();

                        foreach (var fecha in ListaFechas)
                        {
                            #region Lista Trabajador

                            if (ListaFechas != null)
                            {
                                //Obtener Trabajador por dia
                                var ListaTrabajador = (from per in Lista.Where(x => x.FechaRefrigerio.ToString().Trim() == fecha.Id)
                                                       where per.DniPension != null && per.DniTrabajador != null
                                                       group per by new { per.DniTrabajador } into j
                                                       select new
                                                       {
                                                           Id = j.Key.DniTrabajador.ToString().Trim(),
                                                           Valor = j.FirstOrDefault().NombresTrabajador != null ? j.FirstOrDefault().NombresTrabajador.ToString().Trim() : "DESCONOCIDO",
                                                           //NroComidas = Lista.Where(x => x.FechaRefrigerio.ToString().Trim() == fecha.Id && x.DniTrabajador == j.FirstOrDefault().DniTrabajador) != null ? Lista.Where(x => x.FechaRefrigerio.ToString().Trim() == fecha.Id && x.DniTrabajador == j.FirstOrDefault().DniTrabajador).ToList().Count : 0,
                                                       }).OrderBy(x => x.Id).ToList();

                                if (ListaTrabajador != null)
                                {
                                    foreach (var trabajador in ListaTrabajador)
                                    {
                                        #region Lista Pension()
                                        //Obtener Pensión por pENSION

                                        var listaabc = Lista.Where(x => x.FechaRefrigerio == fecha.Id && x.DniTrabajador == trabajador.Id).ToList();

                                        var ListaPensión = (from per in Lista.Where(x =>
                                            x.FechaRefrigerio.ToString().Trim() == fecha.Id &&
                                            x.DniTrabajador.ToString().Trim() == trabajador.Id)
                                                            where per.DniPension != null
                                                            group per by new { per.DniPension } into j
                                                            select new
                                                            {
                                                                Id = j.Key.DniPension.ToString().Trim(),
                                                                Valor = j.FirstOrDefault().NombresPension.ToString().Trim(),
                                                            }).OrderBy(x => x.Id).ToList();

                                        if (ListaPensión != null)
                                        {
                                            foreach (var pension in ListaPensión)
                                            {
                                                var ListaRefrigerios = Lista.Where(x =>
                                                    x.FechaRefrigerio.ToString().Trim() == fecha.Id &&
                                                    x.DniTrabajador.ToString().Trim() == trabajador.Id &&
                                                    x.DniPension.ToString().Trim() == pension.Id
                                                    ).ToList();

                                                if (ListaRefrigerios != null)
                                                {
                                                    RefrigerioAgrupado Obj = new RefrigerioAgrupado();
                                                    Obj.Fecha = ListaRefrigerios != null ? Convert.ToDateTime(ListaRefrigerios.FirstOrDefault().FechaRefrigerio.ToString().Trim()) : (DateTime?)null;
                                                    Obj.CodPension = ListaRefrigerios != null ? ListaRefrigerios.FirstOrDefault().DniPension.ToString().Trim() : "";
                                                    Obj.Pension = ListaRefrigerios != null ? ListaRefrigerios.FirstOrDefault().NombresPension.ToString().Trim() : "";
                                                    Obj.DNITrabajador = ListaRefrigerios != null ? ListaRefrigerios.FirstOrDefault().DniTrabajador.ToString().Trim() : "";
                                                    Obj.Trabajador = ListaRefrigerios.FirstOrDefault().NombresTrabajador != null ? ListaRefrigerios.FirstOrDefault().NombresTrabajador.ToString().Trim() : "DESCONOCIDO";
                                                    Obj.Desayuno = ListaRefrigerios.Where(x => x.TipoRefrigerio == 0).ToList().Count > 0 ? true : false;
                                                    Obj.Almuerzo = ListaRefrigerios.Where(x => x.TipoRefrigerio == 1).ToList().Count > 0 ? true : false;
                                                    Obj.Cena = ListaRefrigerios.Where(x => x.TipoRefrigerio == 2).ToList().Count > 0 ? true : false;
                                                    Obj.nroDesayuno = ListaRefrigerios.Where(x => x.TipoRefrigerio == 0) != null ? ListaRefrigerios.Where(x => x.TipoRefrigerio == 0).ToList().Count : 0;
                                                    Obj.nroAlmuerzo = ListaRefrigerios.Where(x => x.TipoRefrigerio == 1) != null ? ListaRefrigerios.Where(x => x.TipoRefrigerio == 1).ToList().Count : 0;
                                                    Obj.nroCena = ListaRefrigerios.Where(x => x.TipoRefrigerio == 2) != null ? ListaRefrigerios.Where(x => x.TipoRefrigerio == 2).ToList().Count : 0;

                                                    //Obj.ImporteDesayuno = Obj.nroDesayuno * Convert.ToDecimal(2.5);
                                                    //Obj.ImporteAlmuerzo = Obj.nroAlmuerzo * Convert.ToDecimal(3.5);
                                                    //Obj.ImporteCena = Obj.nroCena * Convert.ToDecimal(2.5);

                                                    Obj.nroRefrigeriosxPension = ListaPensión.ToList().Count;
                                                    Obj.SubPlanilla = ListaRefrigerios != null ? ListaRefrigerios.FirstOrDefault().SubPlanilla.ToString().Trim() : "";
                                                    Obj.Condicion = ListaRefrigerios != null ? ListaRefrigerios.FirstOrDefault().Condicion.ToString().Trim() : "";
                                                    Obj.CodigoPersonal = ListaRefrigerios != null ? ListaRefrigerios.FirstOrDefault().CodigoPersonal.ToString().Trim() : "";

                                                    if (ListaAsistencias.Where(x =>
                                                        x.DniTrabajador == (ListaRefrigerios != null ? ListaRefrigerios.FirstOrDefault().DniTrabajador.ToString().Trim() : "")
                                                        && Convert.ToDateTime(x.Fecha) == Obj.Fecha.Value).ToList().Count > 0)
                                                    {
                                                        #region
                                                        Obj.Inasistencia = "SI";
                                                        //var resultadoCoincidenciaPension = Modelo.SJM_Pensiones.Where(x => x.DniPension == Obj.CodPension && x.FechaPension.Value == Obj.Fecha.Value && x.DniTrabajador == ListaRefrigerios.FirstOrDefault().DniTrabajador.ToString().Trim()).ToList();
                                                        //if (resultadoCoincidenciaPension != null && resultadoCoincidenciaPension.ToList().Count > 0)
                                                        //{
                                                        //    foreach (var item in resultadoCoincidenciaPension)
                                                        //    {
                                                        //        SJM_Pensiones obPension = new SJM_Pensiones();
                                                        //        obPension.IdPension = item.IdPension;
                                                        //        obPension.fechaBaja = DateTime.Now;
                                                        //        obPension.estado = 2;
                                                        //        Modelo.SubmitChanges();
                                                        //    }
                                                        //}
                                                        #endregion
                                                    }
                                                    else
                                                    {
                                                        Obj.Inasistencia = "NO";
                                                    }

                                                    //Obj.Inasistencia = "NO";

                                                    if (ListaDescanzoMedico.Where(x => x.CODIGOPERSONA == (ListaRefrigerios != null ? ListaRefrigerios.FirstOrDefault().CodigoPersonal.ToString().Trim() : "")).ToList().Count > 0)
                                                    {
                                                        Obj.DescanzoMedico = "SI";
                                                    }
                                                    else
                                                    {
                                                        Obj.DescanzoMedico = "NO";
                                                    }


                                                    if (ListaLicenciaPermiso.Where(x => x.CODIGOPERSONA == (ListaRefrigerios != null ? ListaRefrigerios.FirstOrDefault().CodigoPersonal.ToString().Trim() : "")).ToList().Count > 0)
                                                    {
                                                        Obj.LicenciaPermiso = "SI";
                                                    }
                                                    else
                                                    {
                                                        Obj.LicenciaPermiso = "NO";
                                                    }


                                                    if (ListaSuspencion.Where(x => x.CODIGOPERSONA == (ListaRefrigerios != null ? ListaRefrigerios.FirstOrDefault().CodigoPersonal.ToString().Trim() : "")).ToList().Count > 0)
                                                    {
                                                        Obj.Suspencion = "SI";
                                                    }
                                                    else
                                                    {
                                                        Obj.Suspencion = "NO";
                                                    }


                                                    if (ListaVacaciones.Where(x => x.idcodigogeneral == (ListaRefrigerios != null ? ListaRefrigerios.FirstOrDefault().DniTrabajador.ToString().Trim() : "")).ToList().Count > 0)
                                                    {
                                                        Obj.Vacaciones = "SI";
                                                    }
                                                    else
                                                    {
                                                        Obj.Vacaciones = "NO";
                                                    }


                                                    Obj.idHospedaje = ListaRefrigerios != null ? ListaRefrigerios.FirstOrDefault().idHospedaje.ToString().Trim() : "";
                                                    Obj.hospedaje = ListaRefrigerios != null ? ListaRefrigerios.FirstOrDefault().hospedaje.ToString().Trim() : "";


                                                    ListadoRefrigerios.Add(Obj);
                                                }
                                                else
                                                {
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
                Modelo.Connection.Close();
            }
            return ListadoRefrigerios;
        }

        public List<SJM_RefrigerioPensionesPersonalListaAsistenciaResult> ObtenerListaAsistenciaPlanillaRRHHLaboresCampo(string Desde, string Hasta)
        {
            List<SJM_RefrigerioPensionesPersonalListaAsistenciaResult> Lista = new List<SJM_RefrigerioPensionesPersonalListaAsistenciaResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800;
                Lista = Modelo.SJM_RefrigerioPensionesPersonalListaAsistencia(Desde, Hasta).ToList();
                Modelo.Connection.Close();
            }
            return Lista;
        }

        public List<SJ_RHPensionAsistenciaLaboresCampoBySemanaByColaboradorResult> ObtenerListaLaboresCampoBySemanaByTrabajador(string codigoTrabajador, int numeroSemana)
        {
            List<SJ_RHPensionAsistenciaLaboresCampoBySemanaByColaboradorResult> Lista = new List<SJ_RHPensionAsistenciaLaboresCampoBySemanaByColaboradorResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800;
                Lista = Modelo.SJ_RHPensionAsistenciaLaboresCampoBySemanaByColaborador(codigoTrabajador, numeroSemana).ToList();
                Modelo.Connection.Close();
            }
            return Lista;
        }

        public List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult> ObtenerListaDescanzoMedico(string Desde, string Hasta)
        {
            List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult> Lista = new List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800;
                var listado = Modelo.SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencion(Desde, Hasta).Where(x => x.IDDOCUMENTO == "DSM").ToList();
                Lista = listado.ToList();
                Modelo.Connection.Close();
            }
            return Lista;
        }

        public List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult> ObtenerListaLicenciaPermiso(string Desde, string Hasta)
        {
            List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult> Lista = new List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800;
                var listado = Modelo.SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencion(Desde, Hasta).Where(x => x.IDDOCUMENTO == "PER").ToList();
                Lista = listado.ToList();
                Modelo.Connection.Close();
            }
            return Lista;
        }

        public List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult> ObtenerListaSuspencion(string Desde, string Hasta)
        {

            List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult> Lista = new List<SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencionResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800;
                var listado = Modelo.SJM_RefrigerioPensionesPersonalListaDescanzoMLicenciaSuspencion(Desde, Hasta).Where(x => x.IDDOCUMENTO == "MEM" && x.IDMOTIVOMEMO == "11").ToList();

                Lista = listado.ToList();

                Modelo.Connection.Close();
            }
            return Lista;
        }

        public List<SJM_RefrigerioPensionesPersonalListaVacacionesResult> ObtenerListaVacaciones(string Desde, string Hasta)
        {
            List<SJM_RefrigerioPensionesPersonalListaVacacionesResult> Lista = new List<SJM_RefrigerioPensionesPersonalListaVacacionesResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800;
                Lista = Modelo.SJM_RefrigerioPensionesPersonalListaVacaciones(Desde, Hasta).ToList();
                Modelo.Connection.Close();
            }
            return Lista;
        }

        /* Método para obtener las asistencias del personal de Ica de un periodo deternimado por rendimiento */
        public List<IndicadorAsistencia> ObtenerListaAsistenciaPersonalGeneralxPeriodoxRendimientoxConsumidor(string periodo, string idPlanilla, string fechaDesde, string fechaHasta, string periodo2, string idEmpresa, List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult> ListadoGeneralPensionistas)
        {
            #region
            string fechaDesdeAsistencia = Convert.ToDateTime(fechaDesde).Year.ToString() + Convert.ToDateTime(fechaDesde).Month.ToString().PadLeft(2, '0') + Convert.ToDateTime(fechaDesde).Day.ToString().PadLeft(2, '0');
            string fechaHastaAsistencia = Convert.ToDateTime(fechaHasta).Year.ToString() + Convert.ToDateTime(fechaHasta).Month.ToString().PadLeft(2, '0') + Convert.ToDateTime(fechaHasta).Day.ToString().PadLeft(2, '0');
            string periodoFinal = Convert.ToDateTime(fechaHasta).Year.ToString() + Convert.ToDateTime(fechaHasta).Month.ToString().PadLeft(2, '0');

            List<SJ_ListarAsistenciasByRendimientoByPeriodosResult> lista = new List<SJ_ListarAsistenciasByRendimientoByPeriodosResult>();
            List<IndicadorAsistencia> listadoAsistenciasPersonalIca = new List<IndicadorAsistencia>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 988800;

                /* Obtener la asistencia del personal que realizo trabajos en campo relacionado a trabajo con racimos */

                /* PARA EL CASO SOLO DESEE CONSULTAR EL DIA DOMINGO */
                if (fechaDesde == fechaHasta)
                {
                    #region
                    CultureInfo ci = new CultureInfo("Es-Es");
                    string diaDeLaSemana = (ci.DateTimeFormat.GetDayName(Convert.ToDateTime(fechaDesde).DayOfWeek)).ToString().Trim().ToUpper();
                    if (diaDeLaSemana == "DOMINGO")
                    {

                        /* SI VOY A CONSULTAR UN DIA Y ESTE ES DOMINGO, CONSULTO UN DIA ANTERIOR DE SUS ASISTENCIAS*/
                        #region
                        listaAsistenciaPersonal = new List<SJ_ListarAsistenciasByRendimientoByPeriodosResult>();
                        var listaAsistenciaDiaDomingo = Modelo.SJ_ListarAsistenciasByRendimientoByPeriodos("", periodo, "PAM", Convert.ToDateTime(fechaDesde).AddDays(-1), Convert.ToDateTime(fechaHasta).AddDays(-1), periodoFinal, "001", "").ToList();


                        listaAsistenciaPersonal = (from itemDomingo in listaAsistenciaDiaDomingo
                                                   where itemDomingo.RowNumber > 0 && itemDomingo.RowNumber != null
                                                   group itemDomingo by new { itemDomingo.RowNumber } into j
                                                   select new SJ_ListarAsistenciasByRendimientoByPeriodosResult
                                                   {
                                                       RowNumber = j.Key.RowNumber.Value,
                                                       periodo = j.FirstOrDefault().periodo != null ? j.FirstOrDefault().periodo.ToString().Trim() : "",
                                                       fecha = Convert.ToDateTime(fechaDesde),
                                                       idcodigogeneral = j.FirstOrDefault().idcodigogeneral != null ? j.FirstOrDefault().idcodigogeneral.ToString().Trim() : "",
                                                       Nombres = j.FirstOrDefault().Nombres != null ? j.FirstOrDefault().Nombres.ToString().Trim() : "",
                                                       idactividad = j.FirstOrDefault().idactividad != null ? j.FirstOrDefault().idactividad.ToString().Trim() : "",
                                                       Dsc_Actividad = j.FirstOrDefault().Dsc_Actividad != null ? j.FirstOrDefault().Dsc_Actividad.ToString().Trim() : "",
                                                       idlabor = j.FirstOrDefault().idlabor != null ? j.FirstOrDefault().idlabor.ToString().Trim() : "",
                                                       Dsc_Labor = j.FirstOrDefault().Dsc_Labor != null ? j.FirstOrDefault().Dsc_Labor.ToString().Trim() : "",
                                                       medida = j.FirstOrDefault().medida != null ? j.FirstOrDefault().medida.ToString().Trim() : "",
                                                       cantidad = j.FirstOrDefault().cantidad != null ? j.FirstOrDefault().cantidad : 0,
                                                       idconsumidor = j.FirstOrDefault().idconsumidor != null ? j.FirstOrDefault().idconsumidor.ToString().Trim() : "",
                                                       consumidor = j.FirstOrDefault().consumidor != null ? j.FirstOrDefault().consumidor.ToString().Trim() : ""
                                                   }).ToList();
                        #endregion

                    }
                    /* CASO CONTRARIO CONSULTO EL DIA DE LA SEMANA*/
                    else
                    {
                        listaAsistenciaPersonal = new List<SJ_ListarAsistenciasByRendimientoByPeriodosResult>();
                        listaAsistenciaPersonal = Modelo.SJ_ListarAsistenciasByRendimientoByPeriodos("", periodo, "PAM", Convert.ToDateTime(fechaDesde), Convert.ToDateTime(fechaHasta), periodoFinal, "001", "").ToList();
                    }
                    #endregion
                }
                else
                {
                    #region
                    listaAsistenciaPersonal = new List<SJ_ListarAsistenciasByRendimientoByPeriodosResult>();
                    listaAsistenciaPersonal = Modelo.SJ_ListarAsistenciasByRendimientoByPeriodos("", periodo, "PAM", Convert.ToDateTime(fechaDesde), Convert.ToDateTime(fechaHasta), periodoFinal, "001", "").ToList();

                    TimeSpan dias = (Convert.ToDateTime(fechaHasta) - Convert.ToDateTime(fechaDesde));
                    int numeroDiasConsulta = (dias.Days);

                    for (int i = 0; i <= numeroDiasConsulta; i++)
                    {
                        /*obtengo el numero y nombre de dia del intervalo de la consulta*/
                        DateTime DiaConsultado = Convert.ToDateTime(fechaDesde).AddDays(i);
                        CultureInfo ci = new CultureInfo("Es-Es");
                        string diaDeLaSemana = (ci.DateTimeFormat.GetDayName(DiaConsultado.DayOfWeek)).ToString().Trim().ToUpper();
                        string periodoNuevaConsulta = DiaConsultado.Year.ToString() + DiaConsultado.Month.ToString().PadLeft(2, '0');
                        if (diaDeLaSemana == "DOMINGO")
                        {
                            #region
                            var listaAsistenciaDiaDomingo = Modelo.SJ_ListarAsistenciasByRendimientoByPeriodos("", periodoNuevaConsulta, "PAM", DiaConsultado.AddDays(-1), DiaConsultado.AddDays(-1), periodoNuevaConsulta, "001", "").ToList();

                            if (listaAsistenciaDiaDomingo != null && listaAsistenciaDiaDomingo.ToList().Count > 0)
                            {
                                listaAsistenciaPersonal = (from itemDomingo in listaAsistenciaDiaDomingo
                                                           where itemDomingo.RowNumber > 0 && itemDomingo.RowNumber != null
                                                           group itemDomingo by new { itemDomingo.RowNumber } into j
                                                           select new SJ_ListarAsistenciasByRendimientoByPeriodosResult
                                                           {
                                                               RowNumber = j.Key.RowNumber.Value,
                                                               periodo = j.FirstOrDefault().periodo != null ? j.FirstOrDefault().periodo.ToString().Trim() : "",
                                                               fecha = DiaConsultado,
                                                               idcodigogeneral = j.FirstOrDefault().idcodigogeneral != null ? j.FirstOrDefault().idcodigogeneral.ToString().Trim() : "",
                                                               Nombres = j.FirstOrDefault().Nombres != null ? j.FirstOrDefault().Nombres.ToString().Trim() : "",
                                                               idactividad = j.FirstOrDefault().idactividad != null ? j.FirstOrDefault().idactividad.ToString().Trim() : "",
                                                               Dsc_Actividad = j.FirstOrDefault().Dsc_Actividad != null ? j.FirstOrDefault().Dsc_Actividad.ToString().Trim() : "",
                                                               idlabor = j.FirstOrDefault().idlabor != null ? j.FirstOrDefault().idlabor.ToString().Trim() : "",
                                                               Dsc_Labor = j.FirstOrDefault().Dsc_Labor != null ? j.FirstOrDefault().Dsc_Labor.ToString().Trim() : "",
                                                               medida = j.FirstOrDefault().medida != null ? j.FirstOrDefault().medida.ToString().Trim() : "",
                                                               cantidad = j.FirstOrDefault().cantidad != null ? j.FirstOrDefault().cantidad : 0,
                                                               idconsumidor = j.FirstOrDefault().idconsumidor != null ? j.FirstOrDefault().idconsumidor.ToString().Trim() : "",
                                                               consumidor = j.FirstOrDefault().consumidor != null ? j.FirstOrDefault().consumidor.ToString().Trim() : ""
                                                           }).ToList();
                            }
                        }
                            #endregion
                    }


                    #endregion
                }

                /* Verifico los días domingos para hacerlos pasar como días sábado */

                /* Agrupar solamente por numero de DNI o codigoTrabajador */
                #region Separar lista por SubPlanillas relacionadas con Ica()
                List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult> ListadoAsistenciaGeneralPersonalSubPlanillasIcas = new List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult>();
                //var ListadoAsistenciaPersonalSubPlanillaIca1 = ListadoGeneralPensionistas.Where(x => x.SubPlanilla.ToString().Trim().ToUpper() == "OBR-ICA").ToList();
                //var ListadoAsistenciaPersonalSubPlanillaIca2 = ListadoGeneralPensionistas.Where(x => x.SubPlanilla.ToString().Trim().ToUpper() == "OBR-ICA II").ToList();

                //if (ListadoAsistenciaPersonalSubPlanillaIca1 != null && ListadoAsistenciaPersonalSubPlanillaIca1.ToList().Count > 0)
                //{
                //    ListadoAsistenciaGeneralPersonalSubPlanillasIcas.AddRange(ListadoAsistenciaPersonalSubPlanillaIca1);
                //}

                //if (ListadoAsistenciaPersonalSubPlanillaIca2 != null && ListadoAsistenciaPersonalSubPlanillaIca2.ToList().Count > 0)
                //{
                //    ListadoAsistenciaGeneralPersonalSubPlanillasIcas.AddRange(ListadoAsistenciaPersonalSubPlanillaIca2);
                //}
                //#endregion

                ListadoAsistenciaGeneralPersonalSubPlanillasIcas = ListadoGeneralPensionistas.Where(x => x.SubPlanilla.ToString().Trim().ToUpper().Contains("ICA")).ToList();

                var listadoTrabajadores = (from item in ListadoAsistenciaGeneralPersonalSubPlanillasIcas
                                           where item.CodigoPersonal != null && item.CodigoPersonal != ""
                                           group item by new { item.CodigoPersonal } into j
                                           select new
                                           {
                                               codigoTrabajador = j.Key.CodigoPersonal.ToString().Trim(),
                                               nombresTrabajador = j.FirstOrDefault().NombresTrabajador != null ? j.FirstOrDefault().NombresTrabajador.ToString().Trim() : "",
                                           }).ToList();

                /* En este forEach recorro cada codigo del personal para buscarlo en la lista del personal que asistio a laborar */
                foreach (var item in listadoTrabajadores)
                {
                    /*Obtengo la lista del personal que asistio a laborar en campo con el codigo del trabajo que obtuvo el refrigerio */
                    var AsistenciaxPersonal = listaAsistenciaPersonal.Where(x => x.idcodigogeneral.ToString().Trim() == item.codigoTrabajador.ToString().Trim()).ToList();

                    /*Si el personal tiene movimiento agregar a la lista*/
                    if (AsistenciaxPersonal != null && AsistenciaxPersonal.ToList().Count > 0)
                    {
                        lista.AddRange(AsistenciaxPersonal);
                    }

                }

                /*Genero la lista que deseo presentar */
                if (lista != null && lista.ToList().Count > 0)
                {
                    #region
                    foreach (var item in lista)
                    {
                        IndicadorAsistencia asist = new IndicadorAsistencia();
                        asist.fecha = item.fecha.Value;
                        asist.codigoTrabajador = item.idcodigogeneral.ToString().Trim();
                        asist.NombresTrabajador = item.Nombres.ToString().Trim();
                        asist.horasTrabajadas = 0;
                        asist.minutosTrabajadas = 0;
                        asist.racimosTrabajador = item.cantidad.Value;
                        asist.codigoConsumidor = item.idconsumidor.ToString().Trim();
                        asist.consumidor = item.consumidor.ToString().Trim();
                        listadoAsistenciasPersonalIca.Add(asist);
                    }
                    #endregion
                }
                Modelo.Connection.Close();
                Modelo.Dispose();
            }

            return listadoAsistenciasPersonalIca;
                #endregion
            #endregion
        }

        /* Método para obtener las asistencias del personal de Ica de un periodo deternimado por rendimiento - PARA EL REPORTE DE ASISTENCIA POR RENDIMIENTO */
        public List<IndicadorAsistencia> ObtenerListaAsistenciaPersonalGeneraByRendimiento(string periodo, string idPlanilla, string fechaDesde, string fechaHasta, string periodo2, string idEmpresa, string codigoGeneral)
        {
            string periodoFinal = Convert.ToDateTime(fechaHasta).Year.ToString() + Convert.ToDateTime(fechaHasta).Month.ToString().PadLeft(2, '0');
            List<IndicadorAsistencia> listadoAsistenciasPersonalIca = new List<IndicadorAsistencia>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 988800;
                /* Obtener la asistencia del personal que realizo trabajos en campo relacionado a trabajo con racimos */
                if (codigoGeneral != "")
                {

                }
                else
                {
                    var listaAsisenciaPersonal = Modelo.SJ_ListarAsistenciasByRendimientoByPeriodos("", periodo, "PAM", Convert.ToDateTime(fechaDesde), Convert.ToDateTime(fechaHasta), periodoFinal, "001", codigoGeneral).ToList();
                    /*Genero la lista que deseo presentar */
                    if (listaAsisenciaPersonal != null && listaAsisenciaPersonal.ToList().Count > 0)
                    {
                        foreach (var item in listaAsisenciaPersonal)
                        {
                            IndicadorAsistencia asist = new IndicadorAsistencia();
                            asist.fecha = item.fecha.Value;
                            asist.codigoTrabajador = item.idcodigogeneral != null ? item.idcodigogeneral.ToString().Trim() : "";
                            asist.NombresTrabajador = item.Nombres != null ? item.Nombres.ToString().Trim() : "";
                            asist.horasTrabajadas = 0;
                            asist.minutosTrabajadas = 0;
                            asist.racimosTrabajador = item.cantidad != null ? item.cantidad.Value : 0;
                            asist.codigoConsumidor = item.idconsumidor != null ? item.idconsumidor.ToString().Trim() : "";
                            asist.consumidor = item.consumidor != null ? item.consumidor.ToString().Trim() : "";
                            asist.actividad = item.Dsc_Actividad != null ? item.Dsc_Actividad.ToString().Trim() : "";
                            asist.labor = item.Dsc_Labor != null ? item.Dsc_Labor.ToString().Trim() : "";
                            listadoAsistenciasPersonalIca.Add(asist);
                        }
                    }
                }


                Modelo.Connection.Close();
                Modelo.Dispose();
            }

            return listadoAsistenciasPersonalIca;
        }

        /* Método para obtener las asistencias del personal de en general de un periodo deternimado por horas trabajas por consumidor */
        public List<IndicadorAsistencia> ObtenerListaAsistenciaPersonalGeneralxPeriodoxHorasxConsumidor(string fechaDesde, string fechaHasta, List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult> ListadoGeneralPensionistas)
        {
            string fechaDesdeAsistencia = Convert.ToDateTime(fechaDesde).Year.ToString() + Convert.ToDateTime(fechaDesde).Month.ToString().PadLeft(2, '0') + Convert.ToDateTime(fechaDesde).Day.ToString().PadLeft(2, '0');
            string fechaHastaAsistencia = Convert.ToDateTime(fechaHasta).Year.ToString() + Convert.ToDateTime(fechaHasta).Month.ToString().PadLeft(2, '0') + Convert.ToDateTime(fechaHasta).Day.ToString().PadLeft(2, '0');

            List<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult> lista = new List<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult>();
            List<IndicadorAsistencia> listadoAsistenciasPersonal = new List<IndicadorAsistencia>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9989000;
                /* Obtener la asistencia del personal que realizo trabajos en campo relacionado a trabajo con racimos */
                //var listadoAsistenciaCampo = Modelo.SJ_AsistenciaxHorasTrabajadasxConsumidor("001", Convert.ToDateTime(fechaDesde), Convert.ToDateTime(fechaHasta), "PAM", 1, 'A', "", "", 1, 0, "XX", 0, 0, 0).ToList();

                if (fechaDesde == fechaHasta)
                {
                    #region
                    CultureInfo ci = new CultureInfo("Es-Es");
                    string diaDeLaSemana = (ci.DateTimeFormat.GetDayName(Convert.ToDateTime(fechaDesde).DayOfWeek)).ToString().Trim().ToUpper();
                    if (diaDeLaSemana == "DOMINGO")
                    {
                        /* SI VOY A CONSULTAR UN DIA Y ESTE ES DOMINGO, CONSULTO UN DIA ANTERIOR DE SUS ASISTENCIAS*/
                        listadoAsistenciaCampoxHoras = new List<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult>();
                        var resultadoConsultaAsistenciaCampoxHoras = Modelo.SJ_ListarAsistenciasByHorasTrabajadasByPeriodos(Convert.ToDateTime(fechaDesde).AddDays(-1).ToShortDateString(), Convert.ToDateTime(fechaHasta).AddDays(-1).ToShortDateString(), "").ToList();

                        listadoAsistenciaCampoxHoras = (from item in resultadoConsultaAsistenciaCampoxHoras
                                                        group item by new { item.item } into j
                                                        select new SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult
                                                        {
                                                            item = j.Key.item,
                                                            fecha = j.FirstOrDefault().fecha != (DateTime?)null ? j.FirstOrDefault().fecha : DateTime.Now,
                                                            actividad = j.FirstOrDefault().actividad != null ? j.FirstOrDefault().actividad.ToString().Trim() : "",
                                                            descr_activ = j.FirstOrDefault().descr_activ != null ? j.FirstOrDefault().descr_activ.ToString().Trim() : "",
                                                            consumidor = j.FirstOrDefault().consumidor != null ? j.FirstOrDefault().consumidor.ToString().Trim() : "",
                                                            descr_consum = j.FirstOrDefault().descr_consum != null ? j.FirstOrDefault().descr_consum.ToString().Trim() : "",
                                                            labor = j.FirstOrDefault().labor != null ? j.FirstOrDefault().labor.ToString().Trim() : "",
                                                            descr_labor = j.FirstOrDefault().descr_labor != null ? j.FirstOrDefault().descr_labor.ToString().Trim() : "",
                                                            codigo = j.FirstOrDefault().codigo != null ? j.FirstOrDefault().codigo.ToString().Trim() : "",
                                                            apenom = j.FirstOrDefault().apenom != null ? j.FirstOrDefault().apenom.ToString().Trim() : "",
                                                            tipo_hora = j.FirstOrDefault().tipo_hora != null ? j.FirstOrDefault().tipo_hora.ToString().Trim() : "",
                                                            horas = j.FirstOrDefault().horas != (decimal?)null ? j.FirstOrDefault().horas.Value : (decimal?)null,
                                                        }
                                                        ).ToList();
                        if (listadoAsistenciaCampoxHoras != null && listadoAsistenciaCampoxHoras.ToList().Count > 0)
                        {
                            listadoAsistenciaCampoxHoras.AddRange(listadoAsistenciaCampoxHoras);
                        }

                    }
                    /* CASO CONTRARIO CONSULTO EL DIA DE LA SEMANA*/
                    else
                    {
                        listadoAsistenciaCampoxHoras = new List<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult>();
                        listadoAsistenciaCampoxHoras = Modelo.SJ_ListarAsistenciasByHorasTrabajadasByPeriodos(fechaDesde, fechaHasta, "").ToList();
                    }
                    #endregion
                }
                else
                {
                    #region
                    listadoAsistenciaCampoxHoras = new List<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult>();
                    listadoAsistenciaCampoxHoras = Modelo.SJ_ListarAsistenciasByHorasTrabajadasByPeriodos((fechaDesde), (fechaHasta), "").ToList();

                    TimeSpan dias = (Convert.ToDateTime(fechaHasta) - Convert.ToDateTime(fechaDesde));
                    int numeroDiasConsulta = (dias.Days);

                    for (int i = 0; i <= numeroDiasConsulta; i++)
                    {
                        /*obtengo el numero y nombre de dia del intervalo de la consulta*/
                        DateTime DiaConsultado = Convert.ToDateTime(fechaDesde).AddDays(i);
                        CultureInfo ci = new CultureInfo("Es-Es");
                        string diaDeLaSemana = (ci.DateTimeFormat.GetDayName(DiaConsultado.DayOfWeek)).ToString().Trim().ToUpper();

                        if (diaDeLaSemana == "DOMINGO")
                        {
                            #region Si es día domingo()

                            var resultadoConsultaAsistenciaCampoxHoras = Modelo.SJ_ListarAsistenciasByHorasTrabajadasByPeriodos(DiaConsultado.AddDays(-1).ToShortDateString(), DiaConsultado.AddDays(-1).ToShortDateString(), "").ToList();

                            listadoAsistenciaCampoxHoras = (from item in resultadoConsultaAsistenciaCampoxHoras
                                                            group item by new { item.item } into j
                                                            select new SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult
                                                            {
                                                                item = j.Key.item,
                                                                fecha = DiaConsultado,
                                                                actividad = j.FirstOrDefault().actividad != null ? j.FirstOrDefault().actividad.Trim() : "",
                                                                descr_activ = j.FirstOrDefault().descr_activ != null ? j.FirstOrDefault().descr_activ.Trim() : "",
                                                                consumidor = j.FirstOrDefault().consumidor != null ? j.FirstOrDefault().consumidor.Trim() : "",
                                                                descr_consum = j.FirstOrDefault().descr_consum != null ? j.FirstOrDefault().descr_consum.Trim() : "",
                                                                labor = j.FirstOrDefault().labor != null ? j.FirstOrDefault().labor.Trim() : "",
                                                                descr_labor = j.FirstOrDefault().descr_labor != null ? j.FirstOrDefault().descr_labor.Trim() : "",
                                                                codigo = j.FirstOrDefault().codigo != null ? j.FirstOrDefault().codigo.Trim() : "",
                                                                apenom = j.FirstOrDefault().apenom != null ? j.FirstOrDefault().apenom.Trim() : "",
                                                                tipo_hora = j.FirstOrDefault().tipo_hora != null ? j.FirstOrDefault().tipo_hora.Trim() : "",
                                                                horas = j.FirstOrDefault().horas != (decimal?)null ? j.FirstOrDefault().horas.Value : (decimal?)null,
                                                            }
                                                            ).ToList();
                            if (listadoAsistenciaCampoxHoras != null && listadoAsistenciaCampoxHoras.ToList().Count > 0)
                            {
                                listadoAsistenciaCampoxHoras.AddRange(listadoAsistenciaCampoxHoras);
                            }

                            #endregion
                        }
                    }

                    #endregion
                }


                /* Agrupar solamente por numero de DNI o codigoTrabajador */
                var listadoTrabajadores = (from item in ListadoGeneralPensionistas.Where(x => !x.SubPlanilla.ToString().Trim().ToUpper().Contains("ICA")).ToList()
                                           where item.CodigoPersonal != null && item.CodigoPersonal != "" && item.SubPlanilla.ToString().Trim().ToUpper().Contains("ICA")
                                           group item by new { item.CodigoPersonal } into j
                                           select new
                                           {
                                               codigoTrabajador = j.Key.CodigoPersonal.ToString().Trim(),
                                               nombresTrabajador = j.FirstOrDefault().NombresTrabajador != null ? j.FirstOrDefault().NombresTrabajador.ToString().Trim() : "",
                                           }).ToList();

                /* En este forEach recorro cada codigo del personal para buscarlo en la lista del personal que asistio a laborar */
                foreach (var item in listadoTrabajadores)
                {
                    /*Obtengo la lista del personal que asistio a laborar en campo con el codigo del trabajo que obtuvo el refrigerio */
                    var AsistenciaxPersonal = listadoAsistenciaCampoxHoras.Where(x => x.codigo.ToString().Trim() == item.codigoTrabajador.ToString().Trim()).ToList();

                    /*Si el personal tiene movimiento agregar a la lista*/
                    if (AsistenciaxPersonal != null && AsistenciaxPersonal.ToList().Count > 0)
                    {
                        lista.AddRange(AsistenciaxPersonal);
                    }
                }


                /*Genero la lista que deseo presentar */
                if (lista != null && lista.ToList().Count > 0)
                {
                    foreach (var item in lista)
                    {
                        IndicadorAsistencia asist = new IndicadorAsistencia();
                        asist.fecha = item.fecha;
                        asist.codigoTrabajador = item.codigo.ToString().Trim();
                        asist.NombresTrabajador = item.apenom.ToString().Trim();
                        asist.horasTrabajadas = item.horas;
                        asist.minutosTrabajadas = (item.horas * 60);
                        asist.racimosTrabajador = 0;
                        asist.codigoConsumidor = item.consumidor.ToString().Trim();
                        asist.consumidor = item.descr_consum.ToString().Trim();
                        listadoAsistenciasPersonal.Add(asist);
                    }
                }


                Modelo.Connection.Close();
                Modelo.Dispose();
            }

            return listadoAsistenciasPersonal;
        }

        /* Método para obtener las asistencias del personal de en general de un periodo deternimado por horas trabajas por consumidor -- REPORTE DE ASISTENCIA POR CAMPO */
        public List<IndicadorAsistencia> ObtenerListaAsistenciaPersonalGeneralByHoras(string fechaDesde, string fechaHasta, string idPlanilla, string codigoGeneral)
        {
            List<IndicadorAsistencia> listadoAsistenciasPersonal = new List<IndicadorAsistencia>();
            try
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()];
                using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
                {

                    Modelo.CommandTimeout = 9989000;
                    /* Obtener la asistencia del personal que realizo trabajos en campo relacionado a trabajo con racimos */
                    var listadoAsistenciaCampo = Modelo.SJ_ListarAsistenciasByHorasTrabajadasByPeriodos((fechaDesde), (fechaHasta), codigoGeneral).ToList();

                    /*Genero la lista que deseo presentar */
                    if (listadoAsistenciaCampo != null && listadoAsistenciaCampo.ToList().Count > 0)
                    {
                        foreach (var item in listadoAsistenciaCampo)
                        {
                            IndicadorAsistencia asist = new IndicadorAsistencia();
                            asist.fecha = item.fecha;
                            asist.codigoTrabajador = item.codigo != null ? item.codigo.ToString().Trim() : "";
                            asist.NombresTrabajador = item.apenom != null ? item.apenom.ToString().Trim() : "";
                            asist.horasTrabajadas = item.horas != null ? item.horas : 0;
                            asist.minutosTrabajadas = ((item.horas != null ? item.horas : 0) * 60);
                            asist.racimosTrabajador = 0;
                            asist.codigoConsumidor = item.consumidor != null ? item.consumidor.ToString().Trim() : "";
                            asist.consumidor = item.descr_consum != null ? item.descr_consum.ToString().Trim() : "";
                            asist.actividad = item.descr_activ != null ? item.descr_activ.ToString().Trim() : "";
                            asist.labor = item.descr_labor != null ? item.descr_labor.ToString().Trim() : "";
                            asist.idProyecto = item.idProyecto != null ? item.idProyecto.ToString().Trim() : "";
                            asist.proyecto = item.proyecto != null ? item.proyecto.ToString().Trim() : "";
                            listadoAsistenciasPersonal.Add(asist);
                        }
                    }


                    Modelo.Connection.Close();
                    Modelo.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }


            return listadoAsistenciasPersonal;
        }

        /* Método para obtener las asistencias del personal de en general de un periodo deternimado por horas trabajas por consumidor */
        public List<IndicadorAsistencia> ObtenerListaAsistenciaPersonalGeneralxPeriodoxHorasxConsumidorICA(string fechaDesde, string fechaHasta, string idPlanilla, List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult> ListadoGeneralPensionistas)
        {
            string fechaDesdeAsistencia = Convert.ToDateTime(fechaDesde).Year.ToString() + Convert.ToDateTime(fechaDesde).Month.ToString().PadLeft(2, '0') + Convert.ToDateTime(fechaDesde).Day.ToString().PadLeft(2, '0');
            string fechaHastaAsistencia = Convert.ToDateTime(fechaHasta).Year.ToString() + Convert.ToDateTime(fechaHasta).Month.ToString().PadLeft(2, '0') + Convert.ToDateTime(fechaHasta).Day.ToString().PadLeft(2, '0');
            List<SJ_RHTemporalAsistenciaPersonal> lista = new List<SJ_RHTemporalAsistenciaPersonal>();
            List<IndicadorAsistencia> listadoAsistenciasPersonal = new List<IndicadorAsistencia>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9989000;
                /* Obtener la asistencia del personal que realizo trabajos en campo relacionado a trabajo con racimos */
                //var listadoAsistenciaCampo = Modelo.SJ_ListarAsistenciasxHorasTrabajadasxConsumidorxPeridos("001", Convert.ToDateTime(fechaDesde), Convert.ToDateTime(fechaHasta), "PAM", 1, 'A', "", "", 1, 0, "XX", 0, 0, 0).ToList();

                /**/
                if (fechaDesde == fechaHasta)
                {
                    #region
                    CultureInfo ci = new CultureInfo("Es-Es");
                    string diaDeLaSemana = (ci.DateTimeFormat.GetDayName(Convert.ToDateTime(fechaDesde).DayOfWeek)).ToString().Trim().ToUpper();
                    if (diaDeLaSemana == "DOMINGO")
                    {
                        #region
                        /* SI VOY A CONSULTAR UN DIA Y ESTE ES DOMINGO, CONSULTO UN DIA ANTERIOR DE SUS ASISTENCIAS*/
                        listadoAsistenciaCampoxHoras = new List<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult>();
                        var resultadoConsultaAsistenciaCampoxHoras = Modelo.SJ_ListarAsistenciasByHorasTrabajadasByPeriodos(Convert.ToDateTime(fechaDesde).AddDays(-1).ToShortDateString(), Convert.ToDateTime(fechaHasta).AddDays(-1).ToShortDateString(), "").ToList();

                        listadoAsistenciaCampoxHoras = (from item in resultadoConsultaAsistenciaCampoxHoras
                                                        group item by new { item.item } into j
                                                        select new SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult
                                                        {
                                                            item = j.Key.item,
                                                            fecha = Convert.ToDateTime(fechaDesde),
                                                            actividad = j.FirstOrDefault().actividad != null ? j.FirstOrDefault().actividad.ToString().Trim() : "",
                                                            descr_activ = j.FirstOrDefault().descr_activ != null ? j.FirstOrDefault().descr_activ.ToString().Trim() : "",
                                                            consumidor = j.FirstOrDefault().consumidor != null ? j.FirstOrDefault().consumidor.ToString().Trim() : "",
                                                            descr_consum = j.FirstOrDefault().descr_consum != null ? j.FirstOrDefault().descr_consum.ToString().Trim() : "",
                                                            labor = j.FirstOrDefault().labor != null ? j.FirstOrDefault().labor.ToString().Trim() : "",
                                                            descr_labor = j.FirstOrDefault().descr_labor != null ? j.FirstOrDefault().descr_labor.ToString().Trim() : "",
                                                            codigo = j.FirstOrDefault().codigo != null ? j.FirstOrDefault().codigo.ToString().Trim() : "",
                                                            apenom = j.FirstOrDefault().apenom != null ? j.FirstOrDefault().apenom.ToString().Trim() : "",
                                                            tipo_hora = j.FirstOrDefault().tipo_hora != null ? j.FirstOrDefault().tipo_hora.ToString().Trim() : "",
                                                            horas = j.FirstOrDefault().horas != (decimal?)null ? j.FirstOrDefault().horas.Value : (decimal?)null,
                                                        }
                                                        ).ToList();
                        #endregion
                    }
                    /* CASO CONTRARIO CONSULTO EL DIA DE LA SEMANA*/
                    else
                    {
                        #region
                        listadoAsistenciaCampoxHoras = new List<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult>();
                        listadoAsistenciaCampoxHoras = Modelo.SJ_ListarAsistenciasByHorasTrabajadasByPeriodos(fechaDesde, fechaHasta, "").ToList();
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    #region
                    listadoAsistenciaCampoxHoras = new List<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult>();
                    listadoAsistenciaCampoxHoras = Modelo.SJ_ListarAsistenciasByHorasTrabajadasByPeriodos((fechaDesde), (fechaHasta), "").ToList();
                    //var listadoAsistenciaCampo = Modelo.SJ_ListarAsistenciasxHorasTrabajadasxConsumidorxPeridos("001", Convert.ToDateTime(fechaDesde), Convert.ToDateTime(fechaHasta), "PAM", 1, 'A', "", "", 1, 0, "XX", 0, 0, 0).ToList();

                    TimeSpan dias = (Convert.ToDateTime(fechaHasta) - Convert.ToDateTime(fechaDesde));
                    int numeroDiasConsulta = (dias.Days);

                    for (int i = 0; i <= numeroDiasConsulta; i++)
                    {
                        /*obtengo el numero y nombre de dia del intervalo de la consulta*/
                        DateTime DiaConsultado = Convert.ToDateTime(fechaDesde).AddDays(i);
                        CultureInfo ci = new CultureInfo("Es-Es");
                        string diaDeLaSemana = (ci.DateTimeFormat.GetDayName(DiaConsultado.DayOfWeek)).ToString().Trim().ToUpper();

                        if (diaDeLaSemana == "DOMINGO")
                        {
                            #region Si es día domingo()

                            var resultadoConsultaAsistenciaCampoxHoras = Modelo.SJ_ListarAsistenciasByHorasTrabajadasByPeriodos(DiaConsultado.AddDays(-1).ToShortDateString(), DiaConsultado.AddDays(-1).ToShortDateString(), "").ToList();

                            var nuevalistadoAsistenciaCampoxHoras = (from item in resultadoConsultaAsistenciaCampoxHoras
                                                                     group item by new { item.item } into j
                                                                     select new SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult
                                                                     {
                                                                         item = j.Key.item,
                                                                         fecha = DiaConsultado,
                                                                         actividad = j.FirstOrDefault().actividad != null ? j.FirstOrDefault().actividad.ToString().Trim() : "",
                                                                         descr_activ = j.FirstOrDefault().descr_activ != null ? j.FirstOrDefault().descr_activ.ToString().Trim() : "",
                                                                         consumidor = j.FirstOrDefault().consumidor != null ? j.FirstOrDefault().consumidor.ToString().Trim() : "",
                                                                         descr_consum = j.FirstOrDefault().descr_consum != null ? j.FirstOrDefault().descr_consum.ToString().Trim() : "",
                                                                         labor = j.FirstOrDefault().labor != null ? j.FirstOrDefault().labor.ToString().Trim() : "",
                                                                         descr_labor = j.FirstOrDefault().descr_labor != null ? j.FirstOrDefault().descr_labor.ToString().Trim() : "",
                                                                         codigo = j.FirstOrDefault().codigo != null ? j.FirstOrDefault().codigo.ToString().Trim() : "",
                                                                         apenom = j.FirstOrDefault().apenom != null ? j.FirstOrDefault().apenom.ToString().Trim() : "",
                                                                         tipo_hora = j.FirstOrDefault().tipo_hora != null ? j.FirstOrDefault().tipo_hora.ToString().Trim() : "",
                                                                         horas = j.FirstOrDefault().horas != (decimal?)null ? j.FirstOrDefault().horas.Value : (decimal?)null,
                                                                     }
                                                            ).ToList();

                            if (nuevalistadoAsistenciaCampoxHoras != null && nuevalistadoAsistenciaCampoxHoras.ToList().Count > 0)
                            {
                                listadoAsistenciaCampoxHoras.AddRange(nuevalistadoAsistenciaCampoxHoras);
                            }

                            #endregion
                        }
                    }

                    #endregion
                }
                /**/

                var ListaPlanillas = (from item in ListadoGeneralPensionistas.ToList()
                                      where item.CodigoPersonal != null && item.CodigoPersonal != ""
                                      group item by new { item.SubPlanilla } into j
                                      select new
                                      {
                                          subPlanilla = j.Key.SubPlanilla.ToString().Trim()
                                      }).ToList();

                foreach (var itemPlanilla in ListaPlanillas)
                {
                    #region
                    var listadoPersonalxPlanilla = ListadoGeneralPensionistas.Where(x => x.SubPlanilla.ToString().Trim().ToUpper() == itemPlanilla.subPlanilla).ToList();
                    /* Agrupar solamente por numero de DNI o codigoTrabajador */
                    var listadoTrabajadores = (from item in listadoPersonalxPlanilla.ToList()
                                               where item.CodigoPersonal != null && item.CodigoPersonal != ""
                                               group item by new { item.CodigoPersonal } into j
                                               select new
                                               {
                                                   codigoTrabajador = j.Key.CodigoPersonal.ToString().Trim(),
                                                   nombresTrabajador = j.FirstOrDefault().NombresTrabajador != null ? j.FirstOrDefault().NombresTrabajador.ToString().Trim() : "",
                                               }).ToList();

                    /* En este forEach recorro cada codigo del personal para buscarlo en la lista del personal que asistio a laborar */
                    foreach (var itemTrabajador in listadoTrabajadores)
                    {
                        /*Obtengo la lista del personal que asistio a laborar en campo con el codigo del trabajo que obtuvo el refrigerio */
                        var AsistenciaxPersonal = listadoAsistenciaCampoxHoras.Where(x => x.codigo.ToString().Trim() == itemTrabajador.codigoTrabajador.ToString().Trim()).ToList();
                        /*Si el personal tiene movimiento agregar a la lista*/
                        if (AsistenciaxPersonal != null && AsistenciaxPersonal.ToList().Count > 0)
                        {
                            foreach (var itemAsistenciaxPersonal in AsistenciaxPersonal)
                            {
                                IndicadorAsistencia asist = new IndicadorAsistencia();
                                asist.fecha = itemAsistenciaxPersonal.fecha;
                                asist.codigoTrabajador = itemAsistenciaxPersonal.codigo.ToString().Trim();
                                asist.NombresTrabajador = itemAsistenciaxPersonal.apenom.ToString().Trim();
                                asist.horasTrabajadas = itemAsistenciaxPersonal.horas;
                                asist.minutosTrabajadas = (itemAsistenciaxPersonal.horas * 60);
                                asist.racimosTrabajador = 0;
                                asist.codigoConsumidor = itemAsistenciaxPersonal.consumidor.ToString().Trim();
                                asist.consumidor = itemAsistenciaxPersonal.descr_consum.ToString().Trim();
                                asist.subPlanilla = itemPlanilla.subPlanilla.ToString().Trim().ToUpper();
                                listadoAsistenciasPersonal.Add(asist);
                            }
                            //lista.AddRange(AsistenciaxPersonal);
                        }
                    }
                    #endregion
                }
                #region
                /*Genero la lista que deseo presentar */
                //if (lista != null && lista.ToList().Count > 0)
                //{
                //    foreach (var item in lista)
                //    {
                //        IndicadorAsistencia asist = new IndicadorAsistencia();
                //        asist.fecha = item.fecha.Value;
                //        asist.codigoTrabajador = item.codigo.ToString().Trim();
                //        asist.NombresTrabajador = item.apenom.ToString().Trim();
                //        asist.horasTrabajadas = item.horas;
                //        asist.minutosTrabajadas = (item.horas * 60);
                //        asist.racimosTrabajador = 0;
                //        asist.codigoConsumidor = item.consumidor.ToString().Trim();
                //        asist.consumidor = item.descr_consum.ToString().Trim();
                //        //asist.subPlanilla = item.sub
                //        listadoAsistenciasPersonal.Add(asist);
                //    }
                //}
                #endregion
                Modelo.Connection.Close();
                Modelo.Dispose();
            }

            return listadoAsistenciasPersonal;
        }

        /* Este método me devuelve la lista resumen de las asistencias a refrigerios x periodo por pensionista, discriminando la subPlanilla deIca con el Resto de Planillas */
        public List<RefrigerioAgrupado> ObtenerListaResumenAsistenciaRefrigerios(List<RefrigerioAgrupado> ListadoDetalladoAsistenciaRefrigerio)
        {
            List<RefrigerioAgrupado> listado = new List<RefrigerioAgrupado>();
            List<RefrigerioAgrupado> listadoResumen = new List<RefrigerioAgrupado>();

            RefrigerioAgrupado asistenciaRefrigerio = new RefrigerioAgrupado();
            /* Obtengo la lista de pensiones en la lista (Agrupación por dniPension )*/
            var listaPension = (from pension in ListadoDetalladoAsistenciaRefrigerio
                                where pension.CodPension != null
                                group pension by new { pension.CodPension } into j
                                select new
                                {
                                    //idpensinon = j.FirstOrDefault().CodPension != null ? j.FirstOrDefault().CodPension.ToString().Trim().ToUpper() : "0",
                                    dniPension = j.Key.CodPension.ToString().Trim(),
                                    razonSocialProveedor = j.FirstOrDefault().Pension != null ? j.FirstOrDefault().Pension.ToString().Trim().ToUpper() : "",
                                }).ToList();


            foreach (var itemPension in listaPension)
            {
                #region
                /* Obtengo la lista de subplanilas en la lista filtrada por pension (Agrupación por subplanilla )*/
                var listaSubPlanillas = (from pension in ListadoDetalladoAsistenciaRefrigerio.Where(x => x.CodPension == itemPension.dniPension).ToList()
                                         where pension.SubPlanilla != null
                                         group pension by new { pension.SubPlanilla } into j
                                         select new
                                         {
                                             subPlanilla = j.Key.SubPlanilla.ToString().Trim(),
                                         }
                                    ).ToList();

                foreach (var itemSubPlanillas in listaSubPlanillas)
                {
                    #region
                    /*Obtener lista de refrigerios discrimidados por código de pension (dnipensionista) y Subplanilla */
                    var listaAsistenciasxPensionxSubPlanilla = ListadoDetalladoAsistenciaRefrigerio.Where(x => x.CodPension.ToString().Trim() == itemPension.dniPension.Trim() && x.SubPlanilla.ToString().Trim() == itemSubPlanillas.subPlanilla).ToList();
                    if (itemSubPlanillas.subPlanilla.ToString().Trim().ToUpper().Contains("ICA"))
                    {

                        var listaFechas = (from oPension in listaAsistenciasxPensionxSubPlanilla.ToList()
                                           where oPension.Fecha != null
                                           group oPension by new { oPension.Fecha } into j
                                           select new
                                           {
                                               subPlanilla = j.Key.Fecha.ToString().Trim(),
                                           }
                                     ).ToList();

                        foreach (var oFecha in listaFechas)
                        {
                            var listaAsistenciasxPensionxSubPlanillaxFecha = listaAsistenciasxPensionxSubPlanilla.Where(x => x.Fecha.Value == Convert.ToDateTime(oFecha.subPlanilla)).ToList();

                            asistenciaRefrigerio = new RefrigerioAgrupado();
                            asistenciaRefrigerio.Fecha = Convert.ToDateTime(oFecha.subPlanilla);
                            asistenciaRefrigerio.CodPension = (itemPension.dniPension);
                            asistenciaRefrigerio.Pension = itemPension.razonSocialProveedor;
                            asistenciaRefrigerio.SubPlanilla = itemSubPlanillas.subPlanilla;

                            int numeroDesayuno = 0;
                            numeroDesayuno = listaAsistenciasxPensionxSubPlanillaxFecha.Sum(x => x.nroDesayuno != null ? x.nroDesayuno : 0);
                            decimal CostoDesayunos = numeroDesayuno * Convert.ToDecimal(2.5);
                            asistenciaRefrigerio.nroDesayuno = numeroDesayuno;

                            int numeroAlmuerzos = 0;
                            numeroAlmuerzos = listaAsistenciasxPensionxSubPlanillaxFecha.Sum(x => x.nroAlmuerzo != null ? x.nroAlmuerzo : 0);
                            decimal CostoAlmuerzo = numeroAlmuerzos * Convert.ToDecimal(3.5);
                            asistenciaRefrigerio.nroAlmuerzo = numeroAlmuerzos;

                            int numeroCena = 0;
                            numeroCena = listaAsistenciasxPensionxSubPlanillaxFecha.Sum(x => x.nroCena != null ? x.nroCena : 0);
                            decimal CostoCena = numeroCena * Convert.ToDecimal(2.5);
                            asistenciaRefrigerio.nroCena = numeroCena;

                            asistenciaRefrigerio.ImporteDesayuno = CostoDesayunos;
                            asistenciaRefrigerio.ImporteAlmuerzo = CostoAlmuerzo;
                            asistenciaRefrigerio.ImporteCena = CostoCena;


                            asistenciaRefrigerio.nroRefrigeriosxPension = numeroDesayuno + numeroAlmuerzos + numeroCena;
                            asistenciaRefrigerio.Importe = CostoAlmuerzo + CostoCena + CostoDesayunos;
                            listado.Add(asistenciaRefrigerio);

                        }
                    }
                    else
                    {

                        var listaFechas = (from oPension in listaAsistenciasxPensionxSubPlanilla.ToList()
                                           where oPension.Fecha != null
                                           group oPension by new { oPension.Fecha } into j
                                           select new
                                           {
                                               subPlanilla = j.Key.Fecha.ToString().Trim(),
                                           }
                                                             ).ToList();

                        foreach (var oFecha in listaFechas)
                        {
                            var listaAsistenciasxPensionxSubPlanillaxFecha = listaAsistenciasxPensionxSubPlanilla.Where(x => x.Fecha.Value == Convert.ToDateTime(oFecha.subPlanilla)).ToList();



                            asistenciaRefrigerio = new RefrigerioAgrupado();
                            asistenciaRefrigerio.Fecha = Convert.ToDateTime(oFecha.subPlanilla);
                            asistenciaRefrigerio.CodPension = (itemPension.dniPension);
                            asistenciaRefrigerio.Pension = itemPension.razonSocialProveedor;
                            asistenciaRefrigerio.SubPlanilla = "TODAS";

                            int numeroDesayuno = 0;
                            numeroDesayuno = listaAsistenciasxPensionxSubPlanillaxFecha.Sum(x => x.nroDesayuno != null ? x.nroDesayuno : 0);
                            decimal CostoDesayunos = numeroDesayuno * Convert.ToDecimal(2.5);
                            asistenciaRefrigerio.nroDesayuno = numeroDesayuno;

                            int numeroAlmuerzos = 0;
                            numeroAlmuerzos = listaAsistenciasxPensionxSubPlanillaxFecha.Sum(x => x.nroAlmuerzo != null ? x.nroAlmuerzo : 0);
                            decimal CostoAlmuerzo = numeroAlmuerzos * Convert.ToDecimal(3.5);
                            asistenciaRefrigerio.nroAlmuerzo = numeroAlmuerzos;

                            int numeroCena = 0;
                            numeroCena = listaAsistenciasxPensionxSubPlanillaxFecha.Sum(x => x.nroCena != null ? x.nroCena : 0);
                            decimal CostoCena = numeroCena * Convert.ToDecimal(2.5);
                            asistenciaRefrigerio.nroCena = numeroCena;

                            asistenciaRefrigerio.ImporteDesayuno = CostoDesayunos;
                            asistenciaRefrigerio.ImporteAlmuerzo = CostoAlmuerzo;
                            asistenciaRefrigerio.ImporteCena = CostoCena;

                            asistenciaRefrigerio.nroRefrigeriosxPension = numeroDesayuno + numeroAlmuerzos + numeroCena;
                            asistenciaRefrigerio.Importe = CostoAlmuerzo + CostoCena + CostoDesayunos;
                            listado.Add(asistenciaRefrigerio);
                        }
                    }
                    #endregion
                }
                #endregion
            }

            /* Volver agrupar la lista con subplanilla Ica y el Todas las otras subPlanillas */
            foreach (var pension in listaPension)
            {
                #region
                /* Obtengo la lista de subplanilas en la lista generada anterior */
                var listaSubPlanillasFiltradas = (from oPension in listado.ToList()
                                                  where oPension.SubPlanilla != null
                                                  group oPension by new { oPension.SubPlanilla } into j
                                                  select new
                                                  {
                                                      subPlanilla = j.Key.SubPlanilla.ToString().Trim(),
                                                  }
                                    ).ToList();



                foreach (var itemSubPlanillas in listaSubPlanillasFiltradas)
                {
                    #region
                    /*Obtener lista de refrigerios discrimidados por código de pension (dnipensionista) y Subplanilla */
                    var listaAsistenciasxPensionxSubPlanilla = listado.Where(x => x.CodPension.ToString().Trim() == pension.dniPension.Trim() && x.SubPlanilla.ToString().Trim() == itemSubPlanillas.subPlanilla).ToList();

                    if (itemSubPlanillas.subPlanilla.ToString().Trim().ToUpper().Contains("ICA"))
                    {
                        #region
                        var listaFechas = (from oPension in listado.ToList()
                                           where oPension.Fecha != null
                                           group oPension by new { oPension.Fecha } into j
                                           select new
                                           {
                                               subPlanilla = j.Key.Fecha.ToString().Trim(),
                                           }
                                     ).ToList();

                        foreach (var oFecha in listaFechas)
                        {
                            var listaAsistenciasxPensionxSubPlanillaxFecha = listaAsistenciasxPensionxSubPlanilla.Where(x => x.Fecha == Convert.ToDateTime(oFecha.subPlanilla)).ToList();
                            #region SubPlanilla Ica()
                            asistenciaRefrigerio = new RefrigerioAgrupado();
                            asistenciaRefrigerio.Fecha = Convert.ToDateTime(oFecha.subPlanilla);
                            asistenciaRefrigerio.CodPension = (pension.dniPension);
                            asistenciaRefrigerio.Pension = pension.razonSocialProveedor;
                            asistenciaRefrigerio.SubPlanilla = itemSubPlanillas.subPlanilla;

                            int numeroDesayuno = 0;
                            numeroDesayuno = listaAsistenciasxPensionxSubPlanillaxFecha.Sum(x => x.nroDesayuno != null ? x.nroDesayuno : 0);
                            decimal CostoDesayunos = numeroDesayuno * Convert.ToDecimal(2.5);
                            asistenciaRefrigerio.nroDesayuno = numeroDesayuno;

                            int numeroAlmuerzos = 0;
                            numeroAlmuerzos = listaAsistenciasxPensionxSubPlanillaxFecha.Sum(x => x.nroAlmuerzo != null ? x.nroAlmuerzo : 0);
                            decimal CostoAlmuerzo = numeroAlmuerzos * Convert.ToDecimal(3.5);
                            asistenciaRefrigerio.nroAlmuerzo = numeroAlmuerzos;

                            int numeroCena = 0;
                            numeroCena = listaAsistenciasxPensionxSubPlanillaxFecha.Sum(x => x.nroCena != null ? x.nroCena : 0);
                            decimal CostoCena = numeroCena * Convert.ToDecimal(2.5);
                            asistenciaRefrigerio.nroCena = numeroCena;

                            asistenciaRefrigerio.ImporteDesayuno = CostoDesayunos;
                            asistenciaRefrigerio.ImporteAlmuerzo = CostoAlmuerzo;
                            asistenciaRefrigerio.ImporteCena = CostoCena;


                            asistenciaRefrigerio.nroRefrigeriosxPension = numeroDesayuno + numeroAlmuerzos + numeroCena;
                            asistenciaRefrigerio.Importe = CostoAlmuerzo + CostoCena + CostoDesayunos;
                            listadoResumen.Add(asistenciaRefrigerio);
                            #endregion
                        }


                        #endregion
                    }
                    else
                    {
                        #region
                        var listaFechas = (from oPension in listado.ToList()
                                           where oPension.Fecha != null
                                           group oPension by new { oPension.Fecha } into j
                                           select new
                                           {
                                               subPlanilla = j.Key.Fecha.ToString().Trim(),
                                           }
                                     ).ToList();

                        foreach (var oFecha in listaFechas)
                        {
                            var listaAsistenciasxPensionxSubPlanillaxFecha = listaAsistenciasxPensionxSubPlanilla.Where(x => x.Fecha == Convert.ToDateTime(oFecha.subPlanilla)).ToList();
                            #region SubPlanilla Ica()
                            asistenciaRefrigerio = new RefrigerioAgrupado();
                            asistenciaRefrigerio.Fecha = Convert.ToDateTime(oFecha.subPlanilla);
                            asistenciaRefrigerio.CodPension = (pension.dniPension);
                            asistenciaRefrigerio.Pension = pension.razonSocialProveedor;
                            asistenciaRefrigerio.SubPlanilla = "TODAS";

                            int numeroDesayuno = 0;
                            numeroDesayuno = listaAsistenciasxPensionxSubPlanillaxFecha.Sum(x => x.nroDesayuno != null ? x.nroDesayuno : 0);
                            decimal CostoDesayunos = numeroDesayuno * Convert.ToDecimal(2.5);
                            asistenciaRefrigerio.nroDesayuno = numeroDesayuno;

                            int numeroAlmuerzos = 0;
                            numeroAlmuerzos = listaAsistenciasxPensionxSubPlanillaxFecha.Sum(x => x.nroAlmuerzo != null ? x.nroAlmuerzo : 0);
                            decimal CostoAlmuerzo = numeroAlmuerzos * Convert.ToDecimal(3.5);
                            asistenciaRefrigerio.nroAlmuerzo = numeroAlmuerzos;

                            int numeroCena = 0;
                            numeroCena = listaAsistenciasxPensionxSubPlanillaxFecha.Sum(x => x.nroCena != null ? x.nroCena : 0);
                            decimal CostoCena = numeroCena * Convert.ToDecimal(2.5);
                            asistenciaRefrigerio.nroCena = numeroCena;


                            asistenciaRefrigerio.ImporteDesayuno = CostoDesayunos;
                            asistenciaRefrigerio.ImporteAlmuerzo = CostoAlmuerzo;
                            asistenciaRefrigerio.ImporteCena = CostoCena;

                            asistenciaRefrigerio.nroRefrigeriosxPension = numeroDesayuno + numeroAlmuerzos + numeroCena;
                            asistenciaRefrigerio.Importe = CostoAlmuerzo + CostoCena + CostoDesayunos;
                            listadoResumen.Add(asistenciaRefrigerio);
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion
            }

            return listadoResumen.OrderBy(x => x.Fecha.Value).ToList(); ;
        }

        /* Este método me devuelve la lista resumen de las asistencias a refrigerios pero totalizado por las dos subPlanillas */
        public List<RefrigerioAgrupado> ObtenerAgruparListaResumenAsistenciaRefrigeriosxSubPlanillas(List<RefrigerioAgrupado> ListadoDetalladoAsistenciaRefrigerio)
        {
            List<RefrigerioAgrupado> listado = new List<RefrigerioAgrupado>();
            List<RefrigerioAgrupado> listadoResumen = new List<RefrigerioAgrupado>();

            RefrigerioAgrupado asistenciaRefrigerio = new RefrigerioAgrupado();
            /* Obtengo la lista de pensiones en la lista (Agrupación por dniPension )*/
            var listaPension = (from pension in ListadoDetalladoAsistenciaRefrigerio
                                where pension.CodPension != null
                                group pension by new { pension.CodPension } into j
                                select new
                                {
                                    //idpensinon = j.FirstOrDefault().CodPension != null ? j.FirstOrDefault().CodPension.ToString().Trim().ToUpper() : "0",
                                    dniPension = j.Key.CodPension.ToString().Trim(),
                                    razonSocialProveedor = j.FirstOrDefault().Pension != null ? j.FirstOrDefault().Pension.ToString().Trim().ToUpper() : "",
                                }
                                    ).ToList();


            foreach (var itemPension in listaPension)
            {
                #region
                /* Obtengo la lista de subplanilas en la lista filtrada por pension (Agrupación por subplanilla )*/
                var listaSubPlanillas = (from pension in ListadoDetalladoAsistenciaRefrigerio.Where(x => x.CodPension == itemPension.dniPension).ToList()
                                         where pension.SubPlanilla != null
                                         group pension by new { pension.SubPlanilla } into j
                                         select new
                                         {
                                             id = j.Key.SubPlanilla.Trim(),
                                         }
                                    ).ToList();

                foreach (var itemSubPlanillas in listaSubPlanillas)
                {
                    #region
                    /*Obtener lista de refrigerios discrimidados por código de pension (dnipensionista) y Subplanilla */
                    var listaAsistenciasxPensionxSubPlanilla = ListadoDetalladoAsistenciaRefrigerio.Where(x => x.CodPension.Trim() == itemPension.dniPension.Trim() && x.SubPlanilla.ToString().Trim() == itemSubPlanillas.id).ToList();

                    if (itemSubPlanillas.id.ToString().Trim().Contains("ICA"))
                    {
                        asistenciaRefrigerio = new RefrigerioAgrupado();
                        asistenciaRefrigerio.CodPension = (itemPension.dniPension);
                        asistenciaRefrigerio.Pension = itemPension.razonSocialProveedor;
                        asistenciaRefrigerio.SubPlanilla = itemSubPlanillas.id;

                        int numeroDesayuno = 0;
                        numeroDesayuno = listaAsistenciasxPensionxSubPlanilla.Sum(x => x.nroDesayuno != null ? x.nroDesayuno : 0);
                        decimal CostoDesayunos = numeroDesayuno * Convert.ToDecimal(2.5);
                        asistenciaRefrigerio.nroDesayuno = numeroDesayuno;

                        int numeroAlmuerzos = 0;
                        numeroAlmuerzos = listaAsistenciasxPensionxSubPlanilla.Sum(x => x.nroAlmuerzo != null ? x.nroAlmuerzo : 0);
                        decimal CostoAlmuerzo = numeroAlmuerzos * Convert.ToDecimal(3.5);
                        asistenciaRefrigerio.nroAlmuerzo = numeroAlmuerzos;

                        int numeroCena = 0;
                        numeroCena = listaAsistenciasxPensionxSubPlanilla.Sum(x => x.nroCena != null ? x.nroCena : 0);
                        decimal CostoCena = numeroCena * Convert.ToDecimal(2.5);
                        asistenciaRefrigerio.nroCena = numeroCena;

                        asistenciaRefrigerio.nroRefrigeriosxPension = numeroDesayuno + numeroAlmuerzos + numeroCena;
                        asistenciaRefrigerio.Importe = CostoAlmuerzo + CostoCena + CostoDesayunos;
                        listado.Add(asistenciaRefrigerio);


                    }
                    else
                    {
                        asistenciaRefrigerio = new RefrigerioAgrupado();
                        asistenciaRefrigerio.CodPension = (itemPension.dniPension);
                        asistenciaRefrigerio.Pension = itemPension.razonSocialProveedor;
                        asistenciaRefrigerio.SubPlanilla = "TODAS";

                        int numeroDesayuno = 0;
                        numeroDesayuno = listaAsistenciasxPensionxSubPlanilla.Sum(x => x.nroDesayuno != null ? x.nroDesayuno : 0);
                        decimal CostoDesayunos = numeroDesayuno * Convert.ToDecimal(2.5);
                        asistenciaRefrigerio.nroDesayuno = numeroDesayuno;

                        int numeroAlmuerzos = 0;
                        numeroAlmuerzos = listaAsistenciasxPensionxSubPlanilla.Sum(x => x.nroAlmuerzo != null ? x.nroAlmuerzo : 0);
                        decimal CostoAlmuerzo = numeroAlmuerzos * Convert.ToDecimal(3.5);
                        asistenciaRefrigerio.nroAlmuerzo = numeroAlmuerzos;

                        int numeroCena = 0;
                        numeroCena = listaAsistenciasxPensionxSubPlanilla.Sum(x => x.nroCena != null ? x.nroCena : 0);
                        decimal CostoCena = numeroCena * Convert.ToDecimal(2.5);
                        asistenciaRefrigerio.nroCena = numeroCena;

                        asistenciaRefrigerio.nroRefrigeriosxPension = numeroDesayuno + numeroAlmuerzos + numeroCena;
                        asistenciaRefrigerio.Importe = CostoAlmuerzo + CostoCena + CostoDesayunos;
                        listado.Add(asistenciaRefrigerio);
                    }
                    #endregion
                }
                #endregion
            }


            /* Volver agrupar la lista con subplanilla Ica y el Todas las otras subPlanillas */
            foreach (var pension in listaPension)
            {
                #region
                /* Obtengo la lista de subplanilas en la lista generada anterior */
                var listaSubPlanillasFiltradas = (from oPension in listado.ToList()
                                                  where oPension.SubPlanilla != null
                                                  group oPension by new { oPension.SubPlanilla } into j
                                                  select new
                                                  {
                                                      id = j.Key.SubPlanilla.ToString().Trim(),
                                                  }
                                    ).ToList();



                foreach (var itemSubPlanillas in listaSubPlanillasFiltradas)
                {
                    #region
                    /*Obtener lista de refrigerios discrimidados por código de pension (dnipensionista) y Subplanilla */
                    var listaAsistenciasxPensionxSubPlanilla = listado.Where(x => x.CodPension.ToString().Trim() == pension.dniPension.Trim() && x.SubPlanilla.ToString().Trim() == itemSubPlanillas.id).ToList();

                    if (itemSubPlanillas.id.ToString().Trim().ToUpper().Contains("ICA"))
                    {
                        #region SubPlanilla Ica()
                        asistenciaRefrigerio = new RefrigerioAgrupado();
                        asistenciaRefrigerio.CodPension = (pension.dniPension);
                        asistenciaRefrigerio.Pension = pension.razonSocialProveedor;
                        asistenciaRefrigerio.SubPlanilla = itemSubPlanillas.id;

                        int numeroDesayuno = 0;
                        numeroDesayuno = listaAsistenciasxPensionxSubPlanilla.Sum(x => x.nroDesayuno != null ? x.nroDesayuno : 0);
                        decimal CostoDesayunos = numeroDesayuno * Convert.ToDecimal(2.5);
                        asistenciaRefrigerio.nroDesayuno = numeroDesayuno;

                        int numeroAlmuerzos = 0;
                        numeroAlmuerzos = listaAsistenciasxPensionxSubPlanilla.Sum(x => x.nroAlmuerzo != null ? x.nroAlmuerzo : 0);
                        decimal CostoAlmuerzo = numeroAlmuerzos * Convert.ToDecimal(3.5);
                        asistenciaRefrigerio.nroAlmuerzo = numeroAlmuerzos;

                        int numeroCena = 0;
                        numeroCena = listaAsistenciasxPensionxSubPlanilla.Sum(x => x.nroCena != null ? x.nroCena : 0);
                        decimal CostoCena = numeroCena * Convert.ToDecimal(2.5);
                        asistenciaRefrigerio.nroCena = numeroCena;

                        asistenciaRefrigerio.nroRefrigeriosxPension = numeroDesayuno + numeroAlmuerzos + numeroCena;
                        asistenciaRefrigerio.Importe = CostoAlmuerzo + CostoCena + CostoDesayunos;
                        listadoResumen.Add(asistenciaRefrigerio);
                        #endregion

                    }
                    else
                    {
                        #region Todas las SubPlanillas();
                        asistenciaRefrigerio = new RefrigerioAgrupado();
                        asistenciaRefrigerio.CodPension = (pension.dniPension);
                        asistenciaRefrigerio.Pension = pension.razonSocialProveedor;
                        asistenciaRefrigerio.SubPlanilla = "TODAS";

                        int numeroDesayuno = 0;
                        numeroDesayuno = listaAsistenciasxPensionxSubPlanilla.Sum(x => x.nroDesayuno != null ? x.nroDesayuno : 0);
                        decimal CostoDesayunos = numeroDesayuno * Convert.ToDecimal(2.5);
                        asistenciaRefrigerio.nroDesayuno = numeroDesayuno;

                        int numeroAlmuerzos = 0;
                        numeroAlmuerzos = listaAsistenciasxPensionxSubPlanilla.Sum(x => x.nroAlmuerzo != null ? x.nroAlmuerzo : 0);
                        decimal CostoAlmuerzo = numeroAlmuerzos * Convert.ToDecimal(3.5);
                        asistenciaRefrigerio.nroAlmuerzo = numeroAlmuerzos;

                        int numeroCena = 0;
                        numeroCena = listaAsistenciasxPensionxSubPlanilla.Sum(x => x.nroCena != null ? x.nroCena : 0);
                        decimal CostoCena = numeroCena * Convert.ToDecimal(2.5);
                        asistenciaRefrigerio.nroCena = numeroCena;

                        asistenciaRefrigerio.nroRefrigeriosxPension = numeroDesayuno + numeroAlmuerzos + numeroCena;
                        asistenciaRefrigerio.Importe = CostoAlmuerzo + CostoCena + CostoDesayunos;
                        listadoResumen.Add(asistenciaRefrigerio);
                        #endregion
                    }
                    #endregion
                }
                #endregion
            }






            return listadoResumen;
        }

        /*Metodo para sumar horas en base de 60 minutos */
        public decimal SumarHoras(List<decimal> lista)
        {
            decimal? diferencialDecimales = 0;
            decimal? diferencialEnteros = 0;

            decimal resultado = 0;
            if (lista != null)
            {
                foreach (var item in lista)
                {
                    if (item > 0)
                    {
                        decimal numeralHoraTermino = Math.Floor(item);
                        decimal decimalHoraTermino = item - numeralHoraTermino;

                        decimal numeralHoraInicio = Math.Floor(resultado);
                        decimal decimalHoraInicio = resultado - numeralHoraInicio;

                        if (decimalHoraTermino > decimalHoraInicio)
                        {
                            diferencialDecimales = decimalHoraTermino + decimalHoraInicio;
                        }
                        else
                        {
                            diferencialDecimales = decimalHoraInicio + decimalHoraTermino;
                        }

                        diferencialEnteros = numeralHoraTermino + numeralHoraInicio;



                        if (diferencialDecimales >= Convert.ToDecimal(0.6))
                        {
                            diferencialDecimales = diferencialDecimales - Convert.ToDecimal(0.60);
                            diferencialEnteros = diferencialEnteros + 1;
                        }

                        resultado = diferencialEnteros.Value + diferencialDecimales.Value;
                    }
                }
            }
            else
            {
                resultado = 0;
            }
            return resultado;
        }

        /* Metodo para la distribucion de las pensiones por dia por centro de costos dentro de un periodo de facturacion */
        /* Para realizar este metodo necesitamos conocer las asistencias del personal en cuanto a horas trabajadas y consumidor en que realizo la actividad o labor */
        /* de igual manera para los trabajador que están dentro de la planilla de Ica necesitamos conocer las asistencias del personal en cuanto racimos */
        public List<SJ_RHDistribucionFacturacion> GenerarDistribucionMovimientoFacturacionPensionesAnterior(List<IndicadorAsistencia> AsistenciaIcaRacimos, List<IndicadorAsistencia> AsistenciaIcaHoras, List<IndicadorAsistencia> AsistenciaPersonalSinIca, List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult> ListadoAsistenciaPension, string desde, string hasta, string idProveedor)
        {
            string listaErrores = string.Empty;
            List<SJ_RHDistribucionFacturacion> listaDistribuidaPensionistas = new List<SJ_RHDistribucionFacturacion>();
            string codigoMovimientoFacturacion = "";
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            decimal? importeDistribuir, totalMinutosTrabajador, totalRacimosTrabajador = 0;

            /* Asigno un codigo al movimiento */
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                #region
                Modelo.CommandTimeout = 9998999;
                codigoMovimientoFacturacion = Modelo.ObtenerId().FirstOrDefault().Codigo.ToString();
                Modelo.Connection.Close();
                #endregion
            }

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9998999;
                Modelo.SJ_RHDistribucionFacturacionEliminarxCodigoxPeriodo(desde, hasta, idProveedor);

                /* Distribuir para SubPlanilla-Ica */
                List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult> ListadoAsistenciaSubPlanullaIcaIyII = new List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult>();
                ListadoAsistenciaSubPlanullaIcaIyII = ListadoAsistenciaPension.Where(x => x.SubPlanilla.ToString().Trim().ToUpper().Contains("ICA")).ToList();

                if (ListadoAsistenciaSubPlanullaIcaIyII.ToList().Count > 0)
                {
                    #region Planilla ICA()
                    /* obtengo toda la lista de la planillas de ican sin importar la pension fecha, etc*/
                    var Personal = ListadoAsistenciaSubPlanullaIcaIyII.ToList();

                    /*Obtener lista de planillas */
                    var listadoPlanillas = (from item in Personal
                                            where item.CodigoPersonal != null && item.CodigoPersonal.ToString().Trim() != ""
                                            group item by new { item.SubPlanilla } into j
                                            select new
                                            {
                                                subPlanilla = j.Key.SubPlanilla.ToString().Trim(),
                                            }
                                            ).ToList();

                    foreach (var itemSubPlanilla in listadoPlanillas)
                    {
                        #region
                        /*Obtener lista de Pensionistras */
                        var listadoPensionista = (from itemPension in Personal.Where(x => x.SubPlanilla.ToString().Trim() == itemSubPlanilla.subPlanilla)
                                                  where itemPension.DniPension != null && itemPension.DniPension.ToString().Trim() != ""
                                                  group itemPension by new { itemPension.DniPension } into j
                                                  select new
                                                  {
                                                      dniPension = j.Key.DniPension.ToString().Trim(),
                                                      codigoPension = j.FirstOrDefault().IdPension,
                                                      nombrePension = j.FirstOrDefault().NombresPension.ToString().Trim(),
                                                  }
                                           ).ToList();


                        foreach (var itemPension in listadoPensionista)
                        {
                            #region Lista Fechas
                            var listadoAsistenciaFechas = Personal.Where(x =>
                                x.SubPlanilla.ToString().Trim() == itemSubPlanilla.subPlanilla &&
                                x.DniPension.ToString().Trim() == itemPension.dniPension).ToList();


                            /*Obtener lista de Trabajadores que Asistieron a la Pensión */
                            var listadoFechas = (from itemFechaRefrigerio in listadoAsistenciaFechas
                                                 where itemFechaRefrigerio.FechaRefrigerio != null
                                                 group itemFechaRefrigerio by new { itemFechaRefrigerio.FechaRefrigerio } into j
                                                 select new
                                                 {
                                                     fechaRefrigerio = Convert.ToDateTime(j.Key.FechaRefrigerio),
                                                     periodo = Convert.ToDateTime(j.Key.FechaRefrigerio).Year.ToString() + Convert.ToDateTime(j.Key.FechaRefrigerio).Month.ToString().Trim().PadLeft(2, '0'),
                                                     //semana =
                                                 }
                                           ).OrderBy(x => x.fechaRefrigerio).ToList();

                            foreach (var itemFechaRefrigerio in listadoFechas)
                            {
                                #region Listado Personal()

                                var listadoAsistenciaPensionistas = Personal.Where(x => x.SubPlanilla.ToString().Trim() == itemSubPlanilla.subPlanilla
                                                    && x.DniPension.ToString().Trim() == itemPension.dniPension
                                                    && Convert.ToDateTime(x.FechaRefrigerio) == itemFechaRefrigerio.fechaRefrigerio).ToList();

                                /*Obtener lista de Trabajadores que Asistieron a la Pensión */
                                var listadoPersonal = (from itemPersonal in listadoAsistenciaPensionistas
                                                       where itemPersonal.CodigoPersonal != null && itemPersonal.CodigoPersonal.Trim() != ""
                                                       group itemPersonal by new { itemPersonal.CodigoPersonal } into j
                                                       select new
                                                       {
                                                           codigoPersonal = j.Key.CodigoPersonal.ToString().Trim(),
                                                           nombresPersonal = j.FirstOrDefault().NombresTrabajador.ToString().Trim(),
                                                           dniPersonal = j.FirstOrDefault().DniTrabajador.ToString().Trim(),
                                                       }).ToList();

                                //decimal? TotalImporteFacturaxFecha = listadoAsistenciaPensionistas.Sum(x => x.Importe != (decimal?)null ? x.Importe : 0);
                                ImportexPersonaxFacturaDesayuno = 0;
                                ImportexPersonaxFacturaAlmuerzo = 0;
                                ImportexPersonaxFacturaCena = 0;
                                ImportexPersonaxFactura = 0;
                                List<String> listaCodigoTrabajadoresSinAsistenciaDesayuno = new List<String>();
                                List<String> listaCodigoTrabajadoresSinAsistenciaAlmuerzo = new List<String>();
                                List<String> listaCodigoTrabajadoresSinAsistenciaCena = new List<String>();

                                foreach (var itemTrabajadores in listadoPersonal)
                                {
                                    #region lista Trabajadores()

                                    //var listadoFechaAsistencia = AsistenciaIca.Where(x => x.fecha == itemFechaRefrigerio.fechaRefrigerio && x.codigoTrabajador == itemTrabajadores.codigoPersonal.ToString().Trim()).ToList();
                                    var ObtenerListaAsistenciaPersonalxFechaRefrigerio = listadoAsistenciaPensionistas.Where(x =>
                                        x.CodigoPersonal.ToString().Trim() == itemTrabajadores.codigoPersonal.ToString().Trim()).ToList();

                                    decimal? ImportexPersona = ObtenerListaAsistenciaPersonalxFechaRefrigerio.Sum(x => x.Importe != (decimal?)null ? x.Importe : 0);
                                    if (ObtenerListaAsistenciaPersonalxFechaRefrigerio != null && ObtenerListaAsistenciaPersonalxFechaRefrigerio.ToList().Count > 0)
                                    {
                                        #region Asistencia del personal tanto a refrigerios como a labores en campo()
                                        /* Este es el importe que tengo que distribuir */
                                        importeDistribuir = ObtenerListaAsistenciaPersonalxFechaRefrigerio.Sum(x => x.Importe != (decimal?)null ? x.Importe : 0);

                                        /* esta es la lista de Asistencia Personal Campo a la fecha del Refrigerio X rACIMOS */
                                        var listadoFechaAsistencia = AsistenciaIcaRacimos.Where(x => x.fecha == itemFechaRefrigerio.fechaRefrigerio && x.codigoTrabajador == itemTrabajadores.codigoPersonal.ToString().Trim()).ToList();

                                        if (listadoFechaAsistencia != null && listadoFechaAsistencia.ToList().Count > 0)
                                        {
                                            #region Asistencia del personal tanto a refrigerios como a labores en campo()
                                            totalRacimosTrabajador = listadoFechaAsistencia.Sum(x => x.racimosTrabajador != (decimal?)null ? x.racimosTrabajador : 0);

                                            foreach (var itemDistribucion in listadoFechaAsistencia)
                                            {
                                                try
                                                {
                                                    SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                                    //oDistribuir.item = "";
                                                    oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                                    oDistribuir.codigoPersonal = itemTrabajadores.codigoPersonal;
                                                    oDistribuir.cantidad = itemDistribucion.racimosTrabajador;
                                                    oDistribuir.horasTrabajadas = Math.Round((Convert.ToDecimal(itemDistribucion.racimosTrabajador) / 90), 2);
                                                    oDistribuir.minutos = (oDistribuir.horasTrabajadas * 60);
                                                    oDistribuir.idConsumidor = itemDistribucion.codigoConsumidor;
                                                    oDistribuir.costoxMinuto = itemDistribucion.racimosTrabajador;
                                                    oDistribuir.costoDistribuido = ((oDistribuir.cantidad * importeDistribuir) / totalRacimosTrabajador);
                                                    oDistribuir.dniProveedor = itemPension.dniPension;
                                                    oDistribuir.codigoPension = itemPension.codigoPension;
                                                    oDistribuir.SubPlanilla = itemSubPlanilla.subPlanilla;
                                                    oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                                    oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                                    oDistribuir.nombresPersonal = itemTrabajadores.nombresPersonal;
                                                    oDistribuir.dniPersonal = itemTrabajadores.dniPersonal;
                                                    oDistribuir.consumidor = itemDistribucion.consumidor;
                                                    oDistribuir.fechaRegistro = DateTime.Now;
                                                    oDistribuir.Proveedor = itemPension.nombrePension;
                                                    oDistribuir.tipoMovimiento = 'P';
                                                    oDistribuir.estado = 1;
                                                    oDistribuir.glosa = "Se ha generado la distribución por el importe de " + oDistribuir.costoDistribuido.Value.ToString("N2") + " del personal " + oDistribuir.codigoPersonal + " - " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado " + oDistribuir.cantidad + " racimos trabajados en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                                    Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                                    Modelo.SubmitChanges();
                                                }
                                                catch (Exception Ex)
                                                {
                                                    throw Ex;
                                                }

                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            /* HAY OPORTUNIDADES DONDE SE DA EL CASO; QUE HAY PERSONAL DE ICA QUE NO ESTA CONSIDERADO POR RENDIMIENTO SINO QUE TAMBIEN POR HORAS, POR ESO ES BUEN CONSULTAR EN LAS ASISTENCIAS POR HORAS */
                                            var listadoFechaAsistenciaPorHoras = AsistenciaIcaHoras != null ? AsistenciaIcaHoras.Where(x => x.fecha == itemFechaRefrigerio.fechaRefrigerio && x.codigoTrabajador == itemTrabajadores.codigoPersonal.ToString().Trim()).ToList() : null;
                                            if (listadoFechaAsistenciaPorHoras != null && listadoFechaAsistenciaPorHoras.ToList().Count > 0)
                                            {
                                                #region Distribuir Por horas Personal de Ica();
                                                totalMinutosTrabajador = listadoFechaAsistenciaPorHoras.Sum(x => x.minutosTrabajadas != (decimal?)null ? x.minutosTrabajadas : 0);

                                                foreach (var itemDistribucion in listadoFechaAsistenciaPorHoras)
                                                {
                                                    #region Distribuir Por horas()
                                                    try
                                                    {
                                                        if (totalMinutosTrabajador > 0)
                                                        {
                                                            #region MyRegion
                                                            SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                                            //oDistribuir.item = "";
                                                            oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                                            oDistribuir.codigoPersonal = itemTrabajadores.codigoPersonal;
                                                            oDistribuir.cantidad = itemDistribucion.horasTrabajadas;
                                                            oDistribuir.horasTrabajadas = itemDistribucion.horasTrabajadas;
                                                            oDistribuir.minutos = itemDistribucion.minutosTrabajadas;
                                                            oDistribuir.idConsumidor = itemDistribucion.codigoConsumidor;
                                                            oDistribuir.costoxMinuto = (itemDistribucion.minutosTrabajadas * importeDistribuir);
                                                            oDistribuir.costoDistribuido = (oDistribuir.costoxMinuto / totalMinutosTrabajador);
                                                            oDistribuir.dniProveedor = itemPension.dniPension;
                                                            oDistribuir.codigoPension = itemPension.codigoPension;
                                                            oDistribuir.SubPlanilla = itemSubPlanilla.subPlanilla;
                                                            oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                                            oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                                            oDistribuir.nombresPersonal = itemTrabajadores.nombresPersonal;
                                                            oDistribuir.dniPersonal = itemTrabajadores.dniPersonal;
                                                            oDistribuir.consumidor = itemDistribucion.consumidor;
                                                            oDistribuir.fechaRegistro = DateTime.Now;
                                                            oDistribuir.Proveedor = itemPension.nombrePension;
                                                            oDistribuir.tipoMovimiento = 'P';
                                                            oDistribuir.estado = 1;
                                                            oDistribuir.glosa = "Se ha generado la distribución por el importe de " + Math.Round(oDistribuir.costoDistribuido.Value, 2) + " del personal " + oDistribuir.codigoPersonal + " - " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado " + oDistribuir.cantidad + " horas de trabajado en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                                            Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                                            Modelo.SubmitChanges();
                                                            #endregion
                                                        }
                                                        else
                                                        {
                                                            ImportexPersonaxFactura += importeDistribuir;
                                                            listaErrores += "SUB PLANILLA:" + itemDistribucion.subPlanilla + " / PENSION: " + itemPension.dniPension + " - " + itemPension.nombrePension + " / FECHA: " + itemFechaRefrigerio.fechaRefrigerio.ToShortDateString() + " / TRABAJADOR: " + itemTrabajadores.codigoPersonal + " - " + itemTrabajadores.nombresPersonal + " NO REGISTRO ASISTENCIA\r\n";
                                                            detalleTrabajadoresSinAsistencia.Add(itemTrabajadores.codigoPersonal.ToString().Trim());
                                                        }


                                                    }
                                                    catch (Exception Ex)
                                                    {

                                                        throw Ex;
                                                    }
                                                    #endregion
                                                }
                                                #endregion
                                            }
                                            else
                                            {
                                                #region Generar listado de Inasistencias del personal()
                                                ImportexPersonaxFactura += ImportexPersona;
                                                listaErrores += "SUB PLANILLA:" + itemSubPlanilla.subPlanilla + " / PENSION: " + itemPension.dniPension + " - " + itemPension.nombrePension + " / FECHA: " + itemFechaRefrigerio.fechaRefrigerio.ToShortDateString() + " / TRABAJADOR: " + itemTrabajadores.codigoPersonal + " - " + itemTrabajadores.nombresPersonal + " NO REGISTRO ASISTENCIA\r\n";
                                                detalleTrabajadoresSinAsistencia.Add(itemTrabajadores.codigoPersonal.ToString().Trim());
                                                #endregion
                                            }
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }
                                /*Prorratear el importe acumulado por no asistencia del personal a labores de campo*/
                                if (ImportexPersonaxFactura > 0)
                                {
                                    #region Distribuir el Importe entre todos los consumidores()
                                    var personasQueAsistieronASuRefrigerio = (from itemA in AsistenciaIcaRacimos.Where(x => x.fecha == itemFechaRefrigerio.fechaRefrigerio).ToList()
                                                                              where !(detalleTrabajadoresSinAsistencia.Contains(itemA.codigoTrabajador.ToUpper()))
                                                                              select itemA).ToList();

                                    decimal? totalPersonasAsistentesRefrigeriosxDia = personasQueAsistieronASuRefrigerio != null ? personasQueAsistieronASuRefrigerio.Count : 1;
                                    if (totalPersonasAsistentesRefrigeriosxDia > 0)
                                    {
                                        #region
                                        decimal? CostoDistribuir = (Convert.ToDecimal(ImportexPersonaxFactura / totalPersonasAsistentesRefrigeriosxDia));
                                        foreach (var itemTrabajadores in personasQueAsistieronASuRefrigerio)
                                        {
                                            #region Registrar Prorrateo()
                                            try
                                            {
                                                SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                                oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                                oDistribuir.codigoPersonal = itemTrabajadores.codigoTrabajador;
                                                oDistribuir.cantidad = 0;
                                                oDistribuir.horasTrabajadas = 0;
                                                oDistribuir.minutos = 0;
                                                oDistribuir.idConsumidor = itemTrabajadores.codigoConsumidor;
                                                oDistribuir.costoxMinuto = 0;
                                                oDistribuir.costoDistribuido = CostoDistribuir;
                                                oDistribuir.dniProveedor = itemPension.dniPension;
                                                oDistribuir.codigoPension = itemPension.codigoPension;
                                                oDistribuir.SubPlanilla = itemSubPlanilla.subPlanilla;
                                                oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                                oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                                oDistribuir.nombresPersonal = itemTrabajadores.NombresTrabajador;
                                                oDistribuir.dniPersonal = itemTrabajadores.codigoTrabajador;
                                                oDistribuir.consumidor = itemTrabajadores.consumidor;
                                                oDistribuir.fechaRegistro = DateTime.Now;
                                                oDistribuir.Proveedor = itemPension.nombrePension;
                                                oDistribuir.tipoMovimiento = 'P';
                                                oDistribuir.estado = 1;
                                                oDistribuir.glosa = "Se ha generado la distribución de Prorrateo por el importe de " + Math.Round(oDistribuir.costoDistribuido.Value, 2) + " del personal " + oDistribuir.codigoPersonal + " - " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado " + oDistribuir.cantidad + " racimos trabajados en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                                Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                                Modelo.SubmitChanges();
                                            }
                                            catch (Exception Ex)
                                            {
                                                throw Ex;
                                            }

                                            #endregion
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        #region
                                        listaErrores += "HAY UN IMPORTE DE " + ImportexPersonaxFactura.Value.ToString("N2") + " EN LA SUB PLANILLA:" + itemSubPlanilla.subPlanilla + " / PENSION: " + itemPension.dniPension + " - " + itemPension.nombrePension + " / FECHA: " + itemFechaRefrigerio.fechaRefrigerio.ToShortDateString() + " QUE NO SE PUEDE DISTRIBUIR POR QUE NO EXISTE REGISTRO DE ASISTENCIA A LA FECHA\r\n";
                                        #endregion
                                    }

                                    #endregion
                                }
                                #endregion
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }

                /* Distribuir para todas las planillas menos para la SubPlanilla-Ica */
                if (ListadoAsistenciaPension.Where(x => !x.SubPlanilla.ToString().Trim().ToUpper().Contains("ICA")).ToList().Count > 0)
                {
                    #region Sub Planillas menos Ica()
                    var ListadoAsistenciaPensionSinIca = ListadoAsistenciaPension.Where(x => !x.SubPlanilla.ToString().Trim().ToUpper().Contains("ICA")).ToList();
                    if (ListadoAsistenciaPensionSinIca != null && ListadoAsistenciaPensionSinIca.ToList().Count > 0)
                    {

                        #region Todas las planilla  menos las que sean de ICA()
                        /* obtengo toda la lista de la planillas de ican sin importar la pension fecha, etc*/
                        var Personal = ListadoAsistenciaPensionSinIca.ToList();

                        /*Obtener lista de planillas */
                        var listadoPlanillas = (from item in Personal
                                                where item.CodigoPersonal != null && item.CodigoPersonal.ToString().Trim() != ""
                                                group item by new { item.SubPlanilla } into j
                                                select new
                                                {
                                                    subPlanilla = j.Key.SubPlanilla.ToString().Trim(),
                                                }
                                                ).ToList();

                        foreach (var itemSubPlanilla in listadoPlanillas)
                        {
                            #region SubPlanillas()
                            /*Obtener lista de Pensionistras */
                            var listadoPensionista = (from itemPension in Personal.Where(x => x.SubPlanilla.ToString().Trim() == itemSubPlanilla.subPlanilla)
                                                      where itemPension.DniPension != null && itemPension.DniPension.ToString().Trim() != ""
                                                      group itemPension by new { itemPension.DniPension } into j
                                                      select new
                                                      {
                                                          dniPension = j.Key.DniPension.ToString().Trim(),
                                                          codigoPension = j.FirstOrDefault().IdPension,
                                                          nombrePension = j.FirstOrDefault().NombresPension.ToString().Trim(),
                                                      }
                                               ).ToList();


                            foreach (var itemPension in listadoPensionista)
                            {
                                #region Lista Fechas
                                var listadoAsistenciaFechas = Personal.Where(x =>
                                    x.SubPlanilla.ToString().Trim() == itemSubPlanilla.subPlanilla &&
                                    x.DniPension.ToString().Trim() == itemPension.dniPension).ToList();


                                /*Obtener lista de Trabajadores que Asistieron a la Pensión */
                                var listadoFechas = (from itemFechaRefrigerio in listadoAsistenciaFechas
                                                     where itemFechaRefrigerio.FechaRefrigerio != null
                                                     group itemFechaRefrigerio by new { itemFechaRefrigerio.FechaRefrigerio } into j
                                                     select new
                                                     {
                                                         fechaRefrigerio = Convert.ToDateTime(j.Key.FechaRefrigerio),
                                                         periodo = Convert.ToDateTime(j.Key.FechaRefrigerio).Year.ToString() + Convert.ToDateTime(j.Key.FechaRefrigerio).Month.ToString().Trim().PadLeft(2, '0'),
                                                         //semana =
                                                     }
                                               ).ToList();

                                foreach (var itemFechaRefrigerio in listadoFechas)
                                {
                                    #region Listado Personal()

                                    var listadoAsistenciaPensionistas = Personal.Where(x =>
                                        x.SubPlanilla.ToString().Trim() == itemSubPlanilla.subPlanilla &&
                                        x.DniPension.ToString().Trim() == itemPension.dniPension &&
                                        Convert.ToDateTime(x.FechaRefrigerio) == itemFechaRefrigerio.fechaRefrigerio).ToList();

                                    /*Obtener lista de Trabajadores que Asistieron a la Pensión */
                                    var listadoPersonal = (from itemPersonal in listadoAsistenciaPensionistas
                                                           where itemPersonal.CodigoPersonal != null && itemPersonal.CodigoPersonal.ToString().Trim() != ""
                                                           group itemPersonal by new { itemPersonal.CodigoPersonal } into j
                                                           select new
                                                           {
                                                               codigoPersonal = j.Key.CodigoPersonal.ToString().Trim(),
                                                               nombresPersonal = j.FirstOrDefault().NombresTrabajador.ToString().Trim(),
                                                               dniPersonal = j.FirstOrDefault().DniTrabajador.ToString().Trim(),
                                                           }
                                                   ).ToList();

                                    decimal? ImportexPersonaxFactura = 0;
                                    List<String> listaCodigoTrabajadoresSinAsistencia = new List<String>();

                                    foreach (var itemTrabajadores in listadoPersonal)
                                    {
                                        #region lista Trabajadores()

                                        //var listadoFechaAsistencia = AsistenciaIca.Where(x => x.fecha == itemFechaRefrigerio.fechaRefrigerio && x.codigoTrabajador == itemTrabajadores.codigoPersonal.ToString().Trim()).ToList();
                                        var ObtenerListaAsistenciaPersonalxFechaRefrigerio = listadoAsistenciaPensionistas.Where(x =>
                                            x.CodigoPersonal.ToString().Trim() == itemTrabajadores.codigoPersonal.ToString().Trim()).ToList();

                                        decimal? ImportexPersona = ObtenerListaAsistenciaPersonalxFechaRefrigerio.Sum(x => x.Importe != (decimal?)null ? x.Importe : 0);


                                        foreach (var item in ObtenerListaAsistenciaPersonalxFechaRefrigerio)
                                        {
                                            string refrigerio = item.Refrigerio.ToString().Trim();

                                        }

                                        if (ObtenerListaAsistenciaPersonalxFechaRefrigerio != null && ObtenerListaAsistenciaPersonalxFechaRefrigerio.ToList().Count > 0)
                                        {
                                            #region Asistencia del personal tanto a refrigerios como a labores en campo()
                                            /* Este es el importe que tengo que distribuir */
                                            importeDistribuir = ObtenerListaAsistenciaPersonalxFechaRefrigerio.Sum(x => x.Importe != (decimal?)null ? x.Importe : 0);

                                            /* esta es la lista de Asistencia Personal Campo a la fecha del Refrigerio */
                                            var listadoFechaAsistencia = AsistenciaPersonalSinIca.Where(x => x.fecha == itemFechaRefrigerio.fechaRefrigerio && x.codigoTrabajador == itemTrabajadores.codigoPersonal.ToString().Trim()).ToList();

                                            if (listadoFechaAsistencia != null && listadoFechaAsistencia.ToList().Count > 0)
                                            {
                                                #region
                                                totalMinutosTrabajador = listadoFechaAsistencia.Sum(x => x.minutosTrabajadas != (decimal?)null ? x.minutosTrabajadas : 0);

                                                foreach (var itemDistribucion in listadoFechaAsistencia)
                                                {
                                                    #region Distribuir Por horas()
                                                    try
                                                    {
                                                        SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                                        //oDistribuir.item = "";
                                                        oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                                        oDistribuir.codigoPersonal = itemTrabajadores.codigoPersonal;
                                                        oDistribuir.cantidad = itemDistribucion.horasTrabajadas;
                                                        oDistribuir.horasTrabajadas = itemDistribucion.horasTrabajadas;
                                                        oDistribuir.minutos = itemDistribucion.minutosTrabajadas;
                                                        oDistribuir.idConsumidor = itemDistribucion.codigoConsumidor;
                                                        oDistribuir.costoxMinuto = (itemDistribucion.minutosTrabajadas * importeDistribuir);
                                                        oDistribuir.costoDistribuido = (oDistribuir.costoxMinuto / (totalMinutosTrabajador > 0 ? totalMinutosTrabajador : 480));
                                                        oDistribuir.dniProveedor = itemPension.dniPension;
                                                        oDistribuir.codigoPension = itemPension.codigoPension;
                                                        oDistribuir.SubPlanilla = itemSubPlanilla.subPlanilla;
                                                        oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                                        oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                                        oDistribuir.nombresPersonal = itemTrabajadores.nombresPersonal;
                                                        oDistribuir.dniPersonal = itemTrabajadores.dniPersonal;
                                                        oDistribuir.consumidor = itemDistribucion.consumidor;
                                                        oDistribuir.fechaRegistro = DateTime.Now;
                                                        oDistribuir.Proveedor = itemPension.nombrePension;
                                                        oDistribuir.tipoMovimiento = 'P';
                                                        oDistribuir.estado = 1;
                                                        oDistribuir.glosa = "Se ha generado la distribución por el importe de " + Math.Round(oDistribuir.costoDistribuido.Value, 2) + " del personal " + oDistribuir.codigoPersonal + " - " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado " + oDistribuir.cantidad + " horas de trabajado en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                                        Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                                        Modelo.SubmitChanges();
                                                    }
                                                    catch (Exception Ex)
                                                    {

                                                        throw Ex;
                                                    }
                                                    #endregion
                                                }
                                                #endregion
                                            }
                                            else
                                            {
                                                #region Generar listado de Inasistencias del personal()
                                                ImportexPersonaxFactura += ImportexPersona;
                                                //listaErrores += "SUBPLANILLA: ICA / PENSION: DOS ANGELITOS FECHA: 13/07/2015 / TRABAJADOR CON CODIGO 1234678 NO REGISTRO ASISTENCIA";
                                                listaErrores += "SUB PLANILLA:" + itemSubPlanilla.subPlanilla + " / PENSION: " + itemPension.dniPension + " - " + itemPension.nombrePension + " / FECHA: " + itemFechaRefrigerio.fechaRefrigerio.ToShortDateString() + " / TRABAJADOR: " + itemTrabajadores.codigoPersonal + " - " + itemTrabajadores.nombresPersonal + " NO REGISTRO ASISTENCIA\r\n";
                                                listaCodigoTrabajadoresSinAsistencia.Add(itemTrabajadores.codigoPersonal.ToString().Trim());
                                                #endregion
                                            }
                                            #endregion
                                        }

                                        #endregion
                                    }
                                    /*Prorratear el importe acumulado por no asistencia del personal a labores de campo*/
                                    if (ImportexPersonaxFactura > 0)
                                    {
                                        #region Distribuir el Importe entre todos los consumidores()
                                        var personasQueAsistieronASuRefrigerio = (from itemA in AsistenciaPersonalSinIca.Where(x => x.fecha == itemFechaRefrigerio.fechaRefrigerio).ToList()
                                                                                  where !(listaCodigoTrabajadoresSinAsistencia.Contains(itemA.codigoTrabajador.ToUpper()))
                                                                                  select itemA
                                                                                      ).ToList();


                                        //var listadoPersonalSinAsistenciaRef = (from itemB in listadoPersonal
                                        //                                       where !(listaCodigoTrabajadoresSinAsistencia.Contains(itemB.codigoPersonal.ToUpper()))
                                        //                                       select itemB
                                        //                                           ).ToList();

                                        decimal? totalPersonasAsistentesRefrigeriosxDia = personasQueAsistieronASuRefrigerio != null ? personasQueAsistieronASuRefrigerio.Count : 1;

                                        if (totalPersonasAsistentesRefrigeriosxDia > 0)
                                        {
                                            decimal? CostoDistribuir = (Convert.ToDecimal(ImportexPersonaxFactura / totalPersonasAsistentesRefrigeriosxDia));
                                            foreach (var itemTrabajadores in personasQueAsistieronASuRefrigerio)
                                            {
                                                #region Prorratear()
                                                //var listadoFechaAsistencia = personasQueAsistieronASuRefrigerio.ToList();
                                                //if (listadoFechaAsistencia != null && listadoFechaAsistencia.ToList().Count > 0)
                                                //{
                                                //foreach (var itemDistribucion in listadoFechaAsistencia)
                                                //{
                                                #region Registrar Prorrateo()
                                                try
                                                {
                                                    SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                                    //oDistribuir.item = "";
                                                    oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                                    oDistribuir.codigoPersonal = itemTrabajadores.codigoTrabajador;
                                                    oDistribuir.cantidad = 0;
                                                    oDistribuir.horasTrabajadas = 0;
                                                    oDistribuir.minutos = 0;
                                                    oDistribuir.idConsumidor = itemTrabajadores.codigoConsumidor;
                                                    oDistribuir.costoxMinuto = 0;
                                                    oDistribuir.costoDistribuido = CostoDistribuir;
                                                    oDistribuir.dniProveedor = itemPension.dniPension;
                                                    oDistribuir.codigoPension = itemPension.codigoPension;
                                                    oDistribuir.SubPlanilla = itemSubPlanilla.subPlanilla;
                                                    oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                                    oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                                    oDistribuir.nombresPersonal = itemTrabajadores.NombresTrabajador;
                                                    oDistribuir.dniPersonal = itemTrabajadores.codigoTrabajador;
                                                    oDistribuir.consumidor = itemTrabajadores.consumidor;
                                                    oDistribuir.fechaRegistro = DateTime.Now;
                                                    oDistribuir.Proveedor = itemPension.nombrePension;
                                                    oDistribuir.tipoMovimiento = 'P';
                                                    oDistribuir.estado = 1;
                                                    oDistribuir.glosa = "Se ha generado la distribución de Prorrateo por el importe de " + Math.Round(oDistribuir.costoDistribuido.Value, 2) + " del personal " + oDistribuir.codigoPersonal + " - " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado " + oDistribuir.cantidad + " racimos trabajados en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                                    Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                                    Modelo.SubmitChanges();
                                                }
                                                catch (Exception Ex)
                                                {
                                                    throw Ex;
                                                }

                                                #endregion
                                                //}
                                                //}
                                                #endregion
                                            }
                                        }
                                        else
                                        {
                                            listaErrores += "HAY UN IMPORTE DE " + ImportexPersonaxFactura.Value.ToString("N2") + " EN LA SUB PLANILLA:" + itemSubPlanilla.subPlanilla + " / PENSION: " + itemPension.dniPension + " - " + itemPension.nombrePension + " / FECHA: " + itemFechaRefrigerio.fechaRefrigerio.ToShortDateString() + " QUE NO SE PUEDE DISTRIBUIR POR QUE NO EXISTE REGISTRO DE ASISTENCIA A LA FECHA\r\n";
                                        }



                                        #endregion
                                    }


                                    #endregion
                                }
                                #endregion
                            }
                            #endregion
                        }

                        #endregion


                    }
                    #endregion
                }

                #region Ajutar Resultados a la lista que deseo presentar()
                var listadoResultado = Modelo.SJ_RHObtenerDistribucionFacturacionxProveedor(desde, hasta, 'P', idProveedor).ToList();

                listaDistribuidaPensionistas = (from distribucion in listadoResultado
                                                select new SJ_RHDistribucionFacturacion
                                                {
                                                    item = distribucion.item,
                                                    fecha = distribucion.fecha,
                                                    codigoPersonal = distribucion.codigoPersonal,
                                                    cantidad = distribucion.cantidad != (decimal?)null ? distribucion.cantidad : 0,
                                                    horasTrabajadas = distribucion.horasTrabajadas != (decimal?)null ? distribucion.horasTrabajadas : 0,
                                                    minutos = distribucion.minutos != (decimal?)null ? distribucion.minutos : 0,
                                                    idConsumidor = distribucion.idConsumidor,
                                                    costoxMinuto = distribucion.costoxMinuto,
                                                    costoDistribuido = distribucion.costoDistribuido,
                                                    dniProveedor = distribucion.dniProveedor,
                                                    codigoPension = distribucion.codigoPension,
                                                    SubPlanilla = distribucion.SubPlanilla,
                                                    periodo = distribucion.periodo,
                                                    codigoMovimientoFacturacion = distribucion.codigoMovimientoFacturacion,
                                                    nombresPersonal = distribucion.nombresPersonal,
                                                    dniPersonal = distribucion.dniPersonal,
                                                    consumidor = distribucion.consumidor,
                                                    fechaRegistro = distribucion.fechaRegistro,
                                                    Proveedor = distribucion.Proveedor,
                                                    glosa = distribucion.glosa,
                                                    tipoMovimiento = distribucion.tipoMovimiento,
                                                    estado = distribucion.estado
                                                }
                                                    ).ToList();
                #endregion

                //GenerarNotificacionTXT(listaErrores);
                Modelo.Connection.Close();
                Modelo.Dispose();
            }

            return listaDistribuidaPensionistas;
        }

        private void GenerarNotificacionTXT(string listaErrores)
        {
            string Notificacion = string.Empty;
            var archivo = "D:\\ficheroDistribucionPensiones.txt";

            if (listaErrores.ToString().Trim().Length > 0)
            {
                /*Si tiene errores solo quedaria armar el formato */
                Notificacion += "NOTIFICACION DEL SISTEMA - DISTRIBUCION FACTURACION PENSIONES. \r\nEl proceso de distribucion de Facturación para centros de costos ha generado los siguientes errores:";
                Notificacion += " \r\n";
                Notificacion += (listaErrores);
                Notificacion += " \r\n";
                Notificacion += "POR TANTO EL IMPORTE GENERADO POR EL PERSONAL INASISTENTE SERA PRORRATEADO POR EL PERSONAL QUE SI ASISTIO \r\n";
                Notificacion += "FECHA_PROCESO :" + DateTime.Now.ToString() + " \r\n";
                Notificacion += "PROCESADO POR :" + Environment.MachineName + " - " + Environment.UserName + "\r\n";
                if (File.Exists(archivo))
                    File.Delete(archivo);

                // crear el fichero                    
            }

            using (var fileStream = File.Create(archivo))
            {
                //string texto = ("Aqui va el texto que desean volvar\r\nal fichero\r\nEn serio ya cambia");
                var textoNotificacion = new UTF8Encoding(true).GetBytes(Notificacion);

                fileStream.Write(textoNotificacion, 0, textoNotificacion.Length);
                fileStream.Flush();
            }
        }

        public List<SJ_ListarAsistenciasByRendimientoByPeriodosResult> listaAsistenciaPersonal { get; set; }

        public string GenerarCodigoMovimiento()
        {
            string codigo = string.Empty;
            try
            {

                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
                using (SJ_RHFacturacionTransportistaDataContext Contexto = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    Contexto.CommandTimeout = 98000;
                    codigo = Contexto.ObtenerId().FirstOrDefault().Codigo.ToString().Trim();
                    Contexto.Connection.Close();
                    Contexto.Dispose();


                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }


            return codigo;


        }

        public void RegistrarResultadosConsultaRefrigeriosAgrupados(List<RefrigerioAgrupado> listadoVistaAgrupadoSubPlanillasIcaOtros, string codigoReporte)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext())
            {
                try
                {
                    foreach (var item in listadoVistaAgrupadoSubPlanillasIcaOtros)
                    {
                        SJ_RHPensionesReporteAgrupadoPension obj = new SJ_RHPensionesReporteAgrupadoPension();
                        obj.codigo = codigoReporte;
                        obj.Fecha = item.Fecha;
                        obj.nroDesayuno = item.nroDesayuno;
                        obj.nroAlmuerzo = item.nroAlmuerzo;
                        obj.nroCena = item.nroCena;
                        obj.ImporteDesayuno = item.ImporteDesayuno;
                        obj.ImporteAlmuerzo = item.ImporteAlmuerzo;
                        obj.ImporteCena = item.ImporteCena;
                        obj.nroRefrigeriosxPension = item.nroRefrigeriosxPension;
                        obj.Importe = item.Importe;
                        obj.SubPlanilla = item.SubPlanilla;
                        obj.Pension = item.Pension;
                        obj.CodPension = item.CodPension;
                        Contexto.SJ_RHPensionesReporteAgrupadoPension.InsertOnSubmit(obj);
                        Contexto.SubmitChanges();
                    }
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
                Contexto.Connection.Close();
                Contexto.Dispose();

            }
        }

        public void GenerarReporteParaFacturacionDetalladoPorRefrigeriosPorDia(string fechaDesde, string fechaHasta, string codigoProveedor, string codigoReporte)
        {
            try
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
                {
                    Contexto.CommandTimeout = 988880;
                    int resultadoConsulta = Contexto.SJ_RHGenerarReporteParaFacturacionDetalladoxRefrigeriosxDia(fechaDesde, fechaHasta, codigoProveedor, codigoReporte);
                    Contexto.Connection.Close();
                    Contexto.Dispose();
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<SJ_RHDistribucionFacturacion> GenerarDistribucionMovimientoFacturacionPensionesxImporteDocumentoVenta(List<IndicadorAsistencia> listaAsistenciaxRendimiento, List<IndicadorAsistencia> listaAsistenciaxHorasTrabajadasIca, List<IndicadorAsistencia> listaAsistenciaxHorasTrabajadas, List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult> ListadoGeneralPensionistas, string fechaDesde, string fechaHasta, string codigoProveedor)
        {
            List<SJ_RHDistribucionFacturacion> listado = new List<SJ_RHDistribucionFacturacion>();
            string codigoMovimientoFacturacion = "";
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();


            /* Asigno un codigo al movimiento */
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                #region
                Modelo.CommandTimeout = 9998999;
                codigoMovimientoFacturacion = Modelo.ObtenerId().FirstOrDefault().Codigo.ToString();
                Modelo.Connection.Close();
                Modelo.Dispose();
                #endregion
            }


            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9998999;
                Modelo.SJ_RHDistribucionFacturacionEliminarxCodigoxPeriodo(fechaDesde, fechaHasta, codigoProveedor);

                var ListadoAsistenciaSubPlanullaIca = ListadoGeneralPensionistas.Where(x => x.SubPlanilla.ToString().Trim().ToUpper().Contains("ICA")).ToList();
                var ListadoAsistenciaSubPlanullaNoIca = ListadoGeneralPensionistas.Where(x => !x.SubPlanilla.ToString().Trim().ToUpper().Contains("ICA")).ToList();

                if (ListadoAsistenciaSubPlanullaIca != null && ListadoAsistenciaSubPlanullaIca.ToList().Count > 0)
                {
                    #region
                    /*Listado fechas que se asistio al refrigerio */
                    var listadoFechas = (from itemFechaRefrigerio in ListadoAsistenciaSubPlanullaIca
                                         where itemFechaRefrigerio.FechaRefrigerio != null
                                         group itemFechaRefrigerio by new { itemFechaRefrigerio.FechaRefrigerio } into j
                                         select new
                                         {
                                             fechaRefrigerio = Convert.ToDateTime(j.Key.FechaRefrigerio),
                                             periodo = Convert.ToDateTime(j.Key.FechaRefrigerio).Year.ToString() + Convert.ToDateTime(j.Key.FechaRefrigerio).Month.ToString().Trim().PadLeft(2, '0'),
                                             //semana =
                                         }
                                                               ).OrderBy(x => x.fechaRefrigerio).ToList();

                    foreach (var itemFechaRefrigerio in listadoFechas)
                    {
                        #region
                        var listadoAsistenciaxFecha = ListadoAsistenciaSubPlanullaIca.Where(x => Convert.ToDateTime(x.FechaRefrigerio) == itemFechaRefrigerio.fechaRefrigerio).ToList();
                        /* listado de refrigerios por fecha */
                        var listadoRefigerios = (from item in listadoAsistenciaxFecha
                                                 where
                                                 item.CodigoPersonal != null &&
                                                 item.CodigoPersonal.ToString().Trim() != "" &&
                                                 item.Refrigerio != null &&
                                                 item.Refrigerio.ToString().Trim() != ""
                                                 group item by new { item.Refrigerio } into j
                                                 select new
                                                 {
                                                     refrigerioBrindado = j.Key.Refrigerio.ToString().Trim().ToUpper(),
                                                 }).ToList();

                        foreach (var itemRefrigerio in listadoRefigerios)
                        {
                            #region
                            var listadeAsistenciaRefrigerioFecha = listadoAsistenciaxFecha.Where(x => x.Refrigerio.ToString().Trim() == itemRefrigerio.refrigerioBrindado.ToString().Trim()).ToList();
                            int cantidadRefrigeriosAsistidos = (listadeAsistenciaRefrigerioFecha != null && listadeAsistenciaRefrigerioFecha.ToList().Count > 0) ? listadeAsistenciaRefrigerioFecha.Count : 0;
                            decimal? precioUnitarioxRefrigerio = Convert.ToDecimal(2.5);

                            switch (itemRefrigerio.refrigerioBrindado)
                            {
                                case "DESAYUNO":
                                    precioUnitarioxRefrigerio = Convert.ToDecimal(2.5);
                                    break;
                                case "ALMUERZO":
                                    precioUnitarioxRefrigerio = Convert.ToDecimal(3.5);
                                    break;
                                case "CENA":
                                    precioUnitarioxRefrigerio = Convert.ToDecimal(2.5);
                                    break;
                                default:
                                    precioUnitarioxRefrigerio = Convert.ToDecimal(0);
                                    break;
                            }

                            decimal? costoxRefrigerio = (cantidadRefrigeriosAsistidos * precioUnitarioxRefrigerio);

                            if (listadeAsistenciaRefrigerioFecha != null && listadeAsistenciaRefrigerioFecha.ToList().Count > 0)
                            {
                                #region Registrar Distribucion de movimiento()
                                SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                //oDistribuir.item = "";
                                oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                oDistribuir.codigoPersonal = "";
                                oDistribuir.cantidad = cantidadRefrigeriosAsistidos;
                                oDistribuir.horasTrabajadas = 0;
                                oDistribuir.minutos = 0;
                                oDistribuir.idConsumidor = "CVSJ";
                                oDistribuir.costoxMinuto = 0;
                                oDistribuir.costoDistribuido = costoxRefrigerio;
                                oDistribuir.dniProveedor = listadeAsistenciaRefrigerioFecha.FirstOrDefault().DniPension != null ? listadeAsistenciaRefrigerioFecha.FirstOrDefault().DniPension.ToString().Trim() : "";
                                oDistribuir.codigoPension = listadeAsistenciaRefrigerioFecha.FirstOrDefault().IdPension != null ? listadeAsistenciaRefrigerioFecha.FirstOrDefault().IdPension : (int?)null;
                                oDistribuir.SubPlanilla = "ICA";
                                oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                oDistribuir.nombresPersonal = "Personal Varios";
                                oDistribuir.dniPersonal = "";
                                oDistribuir.consumidor = "CAMPOS DE UVA - SAN JUAN";
                                oDistribuir.fechaRegistro = DateTime.Now;
                                oDistribuir.Proveedor = listadeAsistenciaRefrigerioFecha.FirstOrDefault().NombresPension != null ? listadeAsistenciaRefrigerioFecha.FirstOrDefault().NombresPension : "";
                                oDistribuir.tipoMovimiento = 'C'; /* SI ES P ES POR HORAS PENSION SI ES C POR CONSUMIDOR ES POR EL TOTAL DEL IMPORTE DEL DOCUMENTO DE VENTA SI ES T ES POR TRANSPORTE */
                                oDistribuir.estado = 1;
                                oDistribuir.glosa = "Se ha generado la distribución por el importe de " + Math.Round(oDistribuir.costoDistribuido.Value, 2) + " del personal " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio " + itemRefrigerio.refrigerioBrindado + "en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado trabajos en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                Modelo.SubmitChanges();
                                #endregion
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }

                /* TODAS MENOS ICA */
                if (ListadoAsistenciaSubPlanullaNoIca != null && ListadoAsistenciaSubPlanullaNoIca.ToList().Count > 0)
                {
                    #region
                    /*Listado fechas que se asistio al refrigerio */
                    var listadoFechas = (from itemFechaRefrigerio in ListadoAsistenciaSubPlanullaNoIca
                                         where itemFechaRefrigerio.FechaRefrigerio != null
                                         group itemFechaRefrigerio by new { itemFechaRefrigerio.FechaRefrigerio } into j
                                         select new
                                         {
                                             fechaRefrigerio = Convert.ToDateTime(j.Key.FechaRefrigerio),
                                             periodo = Convert.ToDateTime(j.Key.FechaRefrigerio).Year.ToString() + Convert.ToDateTime(j.Key.FechaRefrigerio).Month.ToString().Trim().PadLeft(2, '0'),
                                             //semana =
                                         }
                                                               ).OrderBy(x => x.fechaRefrigerio).ToList();

                    foreach (var itemFechaRefrigerio in listadoFechas)
                    {
                        #region
                        var listadoAsistenciaxFecha = ListadoAsistenciaSubPlanullaNoIca.Where(x => Convert.ToDateTime(x.FechaRefrigerio) == itemFechaRefrigerio.fechaRefrigerio).ToList();
                        /* listado de refrigerios por fecha */
                        var listadoRefigerios = (from item in listadoAsistenciaxFecha
                                                 where
                                                 item.CodigoPersonal != null &&
                                                 item.CodigoPersonal.ToString().Trim() != "" &&
                                                 item.Refrigerio != null &&
                                                 item.Refrigerio.ToString().Trim() != ""
                                                 group item by new { item.Refrigerio } into j
                                                 select new
                                                 {
                                                     refrigerioBrindado = j.Key.Refrigerio.ToString().Trim().ToUpper(),
                                                 }).ToList();

                        foreach (var itemRefrigerio in listadoRefigerios)
                        {
                            #region
                            var listadeAsistenciaRefrigerioFecha = listadoAsistenciaxFecha.Where(x => x.Refrigerio.ToString().Trim() == itemRefrigerio.refrigerioBrindado.ToString().Trim()).ToList();
                            int cantidadRefrigeriosAsistidos = (listadeAsistenciaRefrigerioFecha != null && listadeAsistenciaRefrigerioFecha.ToList().Count > 0) ? listadeAsistenciaRefrigerioFecha.Count : 0;
                            decimal? precioUnitarioxRefrigerio = Convert.ToDecimal(2.5);

                            switch (itemRefrigerio.refrigerioBrindado)
                            {
                                case "DESAYUNO":
                                    precioUnitarioxRefrigerio = Convert.ToDecimal(2.5);
                                    break;
                                case "ALMUERZO":
                                    precioUnitarioxRefrigerio = Convert.ToDecimal(3.5);
                                    break;
                                case "CENA":
                                    precioUnitarioxRefrigerio = Convert.ToDecimal(2.5);
                                    break;
                                default:
                                    precioUnitarioxRefrigerio = Convert.ToDecimal(0);
                                    break;
                            }

                            decimal? costoxRefrigerio = (cantidadRefrigeriosAsistidos * precioUnitarioxRefrigerio);

                            if (listadeAsistenciaRefrigerioFecha != null && listadeAsistenciaRefrigerioFecha.ToList().Count > 0)
                            {
                                #region Registrar Distribucion de movimiento()
                                SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                //oDistribuir.item = "";
                                oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                oDistribuir.codigoPersonal = "";
                                oDistribuir.cantidad = cantidadRefrigeriosAsistidos;
                                oDistribuir.horasTrabajadas = 0;
                                oDistribuir.minutos = 0;
                                oDistribuir.idConsumidor = "CVSJ";
                                oDistribuir.costoxMinuto = 0;
                                oDistribuir.costoDistribuido = costoxRefrigerio;
                                oDistribuir.dniProveedor = listadeAsistenciaRefrigerioFecha.FirstOrDefault().DniPension != null ? listadeAsistenciaRefrigerioFecha.FirstOrDefault().DniPension.ToString().Trim() : "";
                                oDistribuir.codigoPension = listadeAsistenciaRefrigerioFecha.FirstOrDefault().IdPension != null ? listadeAsistenciaRefrigerioFecha.FirstOrDefault().IdPension : (int?)null;
                                oDistribuir.SubPlanilla = "TODAS";
                                oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                oDistribuir.nombresPersonal = "Personal Varios";
                                oDistribuir.dniPersonal = "";
                                oDistribuir.consumidor = "CAMPOS DE UVA - SAN JUAN";
                                oDistribuir.fechaRegistro = DateTime.Now;
                                oDistribuir.Proveedor = listadeAsistenciaRefrigerioFecha.FirstOrDefault().NombresPension != null ? listadeAsistenciaRefrigerioFecha.FirstOrDefault().NombresPension : "";
                                oDistribuir.tipoMovimiento = 'C'; /* SI ES P ES POR HORAS PENSION SI ES C POR CONSUMIDOR ES POR EL TOTAL DEL IMPORTE DEL DOCUMENTO DE VENTA SI ES T ES POR TRANSPORTE */
                                oDistribuir.estado = 1;
                                oDistribuir.glosa = "Se ha generado la distribución por el importe de " + Math.Round(oDistribuir.costoDistribuido.Value, 2) + " del personal " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio " + itemRefrigerio.refrigerioBrindado + "en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado trabajos en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                Modelo.SubmitChanges();
                                #endregion
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion

                }

                var listadoResultado = Modelo.SJ_RHObtenerDistribucionFacturacionxProveedor(fechaDesde, fechaHasta, 'C', codigoProveedor).ToList();
                listado = (from distribucion in listadoResultado
                           select new SJ_RHDistribucionFacturacion
                           {
                               item = distribucion.item,
                               fecha = distribucion.fecha,
                               codigoPersonal = distribucion.codigoPersonal,
                               cantidad = distribucion.cantidad != (decimal?)null ? distribucion.cantidad : 0,
                               horasTrabajadas = distribucion.horasTrabajadas != (decimal?)null ? distribucion.horasTrabajadas : 0,
                               minutos = distribucion.minutos != (decimal?)null ? distribucion.minutos : 0,
                               idConsumidor = distribucion.idConsumidor,
                               costoxMinuto = distribucion.costoxMinuto,
                               costoDistribuido = distribucion.costoDistribuido,
                               dniProveedor = distribucion.dniProveedor,
                               codigoPension = distribucion.codigoPension,
                               SubPlanilla = distribucion.SubPlanilla,
                               periodo = distribucion.periodo,
                               codigoMovimientoFacturacion = distribucion.codigoMovimientoFacturacion,
                               nombresPersonal = distribucion.nombresPersonal,
                               dniPersonal = distribucion.dniPersonal,
                               consumidor = distribucion.consumidor,
                               fechaRegistro = distribucion.fechaRegistro,
                               Proveedor = distribucion.Proveedor,
                               glosa = distribucion.glosa,
                               tipoMovimiento = distribucion.tipoMovimiento,
                               estado = distribucion.estado
                           }).ToList();

                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return listado;
        }

        public List<SJ_RHDistribucionFacturacion> GenerarDistribucionMovimientoFacturacionPensiones(List<IndicadorAsistencia> AsistenciaIcaRacimos, List<IndicadorAsistencia> AsistenciaIcaHoras, List<IndicadorAsistencia> AsistenciaPersonalSinIca, List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult> ListadoAsistenciaPension, string desde, string hasta, string idProveedor)
        {
            string listaErrores = string.Empty;
            List<SJ_RHDistribucionFacturacion> listaDistribuidaPensionistas = new List<SJ_RHDistribucionFacturacion>();
            string codigoMovimientoFacturacion = "";
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            decimal? importeDistribuir, totalMinutosTrabajador, totalRacimosTrabajador = 0;

            /* Asigno un codigo al movimiento */
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                #region
                Modelo.CommandTimeout = 9998999;
                codigoMovimientoFacturacion = Modelo.ObtenerId().FirstOrDefault().Codigo.ToString();
                Modelo.Connection.Close();
                Modelo.Dispose();
                #endregion
            }

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                #region
                Modelo.CommandTimeout = 9998999;
                Modelo.SJ_RHDistribucionFacturacionEliminarxCodigoxPeriodo(desde, hasta, idProveedor);

                /* Distribuir para SubPlanilla-Ica */
                List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult> ListadoAsistenciaSubPlanullaIcaIyII = new List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult>();
                ListadoAsistenciaSubPlanullaIcaIyII = ListadoAsistenciaPension.Where(x => x.SubPlanilla.ToString().Trim().ToUpper().Contains("ICA")).ToList();

                if (ListadoAsistenciaSubPlanullaIcaIyII.ToList().Count > 0)
                {
                    #region Planilla ICA()
                    /* obtengo toda la lista de la planillas de ican sin importar la pension fecha, etc*/
                    var Personal = ListadoAsistenciaSubPlanullaIcaIyII.ToList();

                    /*Obtener lista de planillas */
                    var listadoPlanillas = (from item in Personal
                                            where item.CodigoPersonal != null && item.CodigoPersonal.ToString().Trim() != ""
                                            group item by new { item.SubPlanilla } into j
                                            select new
                                            {
                                                subPlanilla = j.Key.SubPlanilla.ToString().Trim(),
                                            }
                                            ).ToList();

                    foreach (var itemSubPlanilla in listadoPlanillas)
                    {
                        #region
                        /*Obtener lista de Pensionistras */
                        var listadoPensionista = (from itemPension in Personal.Where(x => x.SubPlanilla.ToString().Trim() == itemSubPlanilla.subPlanilla)
                                                  where itemPension.DniPension != null && itemPension.DniPension.ToString().Trim() != ""
                                                  group itemPension by new { itemPension.DniPension } into j
                                                  select new
                                                  {
                                                      dniPension = j.Key.DniPension.ToString().Trim(),
                                                      codigoPension = j.FirstOrDefault().IdPension,
                                                      nombrePension = j.FirstOrDefault().NombresPension.ToString().Trim(),
                                                  }
                                           ).ToList();

                        foreach (var itemPension in listadoPensionista)
                        {
                            #region Listado Fechas con Asistencia()
                            var listadoAsistenciaFechas = Personal.Where(x =>
                                x.SubPlanilla.ToString().Trim() == itemSubPlanilla.subPlanilla &&
                                x.DniPension.ToString().Trim() == itemPension.dniPension).ToList();

                            /*Obtener lista de Trabajadores que Asistieron a la Pensión */
                            var listadoFechas = (from itemFechaRefrigerio in listadoAsistenciaFechas
                                                 where itemFechaRefrigerio.FechaRefrigerio != null
                                                 group itemFechaRefrigerio by new { itemFechaRefrigerio.FechaRefrigerio } into j
                                                 select new
                                                 {
                                                     fechaRefrigerio = Convert.ToDateTime(j.Key.FechaRefrigerio),
                                                     periodo = Convert.ToDateTime(j.Key.FechaRefrigerio).Year.ToString() + Convert.ToDateTime(j.Key.FechaRefrigerio).Month.ToString().Trim().PadLeft(2, '0'),
                                                     //semana =
                                                 }
                                           ).OrderBy(x => x.fechaRefrigerio).ToList();

                            List<SJ_RHDistribucionFacturacion> ListadoRegisrtosAgregadosBaseDatos = new List<SJ_RHDistribucionFacturacion>();
                            foreach (var itemFechaRefrigerio in listadoFechas)
                            {
                                #region Listado Personal()
                                #region Agrupar por personal y generar listas para el prorratero
                                var listadoAsistenciaPensionistas = Personal.Where(x => x.SubPlanilla.ToString().Trim() == itemSubPlanilla.subPlanilla
                                                    && x.DniPension.ToString().Trim() == itemPension.dniPension
                                                    && Convert.ToDateTime(x.FechaRefrigerio) == itemFechaRefrigerio.fechaRefrigerio).ToList();

                                /*Obtener lista de Trabajadores que Asistieron a la Pensión */
                                var listadoPersonal = (from itemPersonal in listadoAsistenciaPensionistas
                                                       where itemPersonal.CodigoPersonal != null && itemPersonal.CodigoPersonal.ToString().Trim() != ""
                                                       group itemPersonal by new { itemPersonal.CodigoPersonal } into j
                                                       select new
                                                       {
                                                           codigoPersonal = j.Key.CodigoPersonal.ToString().Trim(),
                                                           nombresPersonal = j.FirstOrDefault().NombresTrabajador.ToString().Trim(),
                                                           dniPersonal = j.FirstOrDefault().DniTrabajador.ToString().Trim(),
                                                       }).ToList();

                                //decimal? TotalImporteFacturaxFecha = listadoAsistenciaPensionistas.Sum(x => x.Importe != (decimal?)null ? x.Importe : 0);                                
                                ImportexPersonaxFacturaDesayuno = 0;
                                ImportexPersonaxFacturaAlmuerzo = 0;
                                ImportexPersonaxFacturaCena = 0;
                                List<String> listaCodigoTrabajadoresSinAsistencia = new List<String>();
                                List<String> listaCodigoTrabajadoresSinAsistenciaDesayuno = new List<String>();
                                List<String> listaCodigoTrabajadoresSinAsistenciaAlmuerzo = new List<String>();
                                List<String> listaCodigoTrabajadoresSinAsistenciaCena = new List<String>();
                                #endregion

                                foreach (var itemTrabajadores in listadoPersonal)
                                {
                                    #region lista Trabajadores()

                                    //var listadoFechaAsistencia = AsistenciaIca.Where(x => x.fecha == itemFechaRefrigerio.fechaRefrigerio && x.codigoTrabajador == itemTrabajadores.codigoPersonal.ToString().Trim()).ToList();
                                    var ObtenerListaAsistenciaPersonalxFechaRefrigerio = listadoAsistenciaPensionistas.Where(x => x.CodigoPersonal.ToString().Trim() == itemTrabajadores.codigoPersonal.ToString().Trim()).ToList();
                                    decimal? ImportexPersona = ObtenerListaAsistenciaPersonalxFechaRefrigerio.Sum(x => x.Importe != (decimal?)null ? x.Importe : 0);
                                    var listadoRefrigerios = (from itemRefri in ObtenerListaAsistenciaPersonalxFechaRefrigerio
                                                              group itemRefri by new { itemRefri.Refrigerio } into j
                                                              select new
                                                              {
                                                                  refrigerio = j.Key.Refrigerio.ToString()
                                                              }).ToList();

                                    foreach (var oRefrigerio in listadoRefrigerios)
                                    {
                                        #region listado por refrigerios()
                                        var listadoAsistenciaxRefrigerio = ObtenerListaAsistenciaPersonalxFechaRefrigerio.Where(x => x.Refrigerio == oRefrigerio.refrigerio).ToList();

                                        if (listadoAsistenciaxRefrigerio != null && listadoAsistenciaxRefrigerio.ToList().Count > 0)
                                        {
                                            #region Asistencia del personal tanto a refrigerios como a labores en campo()
                                            /* Este es el importe que tengo que distribuir */
                                            importeDistribuir = listadoAsistenciaxRefrigerio.Sum(x => x.Importe != (decimal?)null ? x.Importe : 0);

                                            /* esta es la lista de Asistencia Personal Campo a la fecha del Refrigerio X rACIMOS */
                                            var listadoFechaAsistencia = AsistenciaIcaRacimos.Where(x => x.fecha == itemFechaRefrigerio.fechaRefrigerio && x.codigoTrabajador == itemTrabajadores.codigoPersonal.ToString().Trim()).ToList();

                                            if (listadoFechaAsistencia != null && listadoFechaAsistencia.ToList().Count > 0)
                                            {
                                                #region Asistencia del personal tanto a refrigerios como a labores en campo()

                                                totalRacimosTrabajador = listadoFechaAsistencia.Sum(x => x.racimosTrabajador != (decimal?)null ? x.racimosTrabajador : 0);

                                                foreach (var itemDistribucion in listadoFechaAsistencia)
                                                {
                                                    try
                                                    {
                                                        SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                                        //oDistribuir.item = "";
                                                        oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                                        oDistribuir.codigoPersonal = itemTrabajadores.codigoPersonal;
                                                        oDistribuir.cantidad = itemDistribucion.racimosTrabajador;
                                                        oDistribuir.horasTrabajadas = Math.Round((Convert.ToDecimal(itemDistribucion.racimosTrabajador) / 90), 2);
                                                        oDistribuir.minutos = Math.Round(Convert.ToDecimal(oDistribuir.horasTrabajadas * 60), 2);
                                                        oDistribuir.idConsumidor = itemDistribucion.codigoConsumidor;
                                                        oDistribuir.costoxMinuto = itemDistribucion.racimosTrabajador;
                                                        oDistribuir.costoDistribuido = Math.Round(Convert.ToDecimal((oDistribuir.cantidad * importeDistribuir) / totalRacimosTrabajador), 2);
                                                        oDistribuir.dniProveedor = itemPension.dniPension;
                                                        oDistribuir.codigoPension = itemPension.codigoPension;
                                                        oDistribuir.SubPlanilla = itemSubPlanilla.subPlanilla;
                                                        oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                                        oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                                        oDistribuir.nombresPersonal = itemTrabajadores.nombresPersonal;
                                                        oDistribuir.dniPersonal = itemTrabajadores.dniPersonal;
                                                        oDistribuir.consumidor = itemDistribucion.consumidor;
                                                        oDistribuir.fechaRegistro = DateTime.Now;
                                                        oDistribuir.Proveedor = itemPension.nombrePension;
                                                        oDistribuir.tipoMovimiento = 'P';
                                                        oDistribuir.estado = 1;
                                                        oDistribuir.glosa = "Distribución por el importe de " + oDistribuir.costoDistribuido.Value.ToString("N2") + " del personal " + oDistribuir.codigoPersonal + " - " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio " + oRefrigerio.refrigerio + " en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado " + oDistribuir.cantidad + " racimos trabajados en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                                        ListadoRegisrtosAgregadosBaseDatos.Add(oDistribuir);
                                                        Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                                        Modelo.SubmitChanges();
                                                    }
                                                    catch (Exception Ex)
                                                    {
                                                        throw Ex;
                                                    }

                                                }
                                                #endregion
                                            }
                                            else
                                            {
                                                #region
                                                /* HAY OPORTUNIDADES DONDE SE DA EL CASO; QUE HAY PERSONAL DE ICA QUE NO ESTA CONSIDERADO POR RENDIMIENTO SINO QUE TAMBIEN POR HORAS, POR ESO ES BUEN CONSULTAR EN LAS ASISTENCIAS POR HORAS */
                                                var listadoFechaAsistenciaPorHoras = AsistenciaIcaHoras != null ? AsistenciaIcaHoras.Where(x => x.fecha == itemFechaRefrigerio.fechaRefrigerio && x.codigoTrabajador == itemTrabajadores.codigoPersonal.ToString().Trim()).ToList() : null;
                                                if (listadoFechaAsistenciaPorHoras != null && listadoFechaAsistenciaPorHoras.ToList().Count > 0)
                                                {
                                                    #region Distribuir Por horas Personal de Ica();
                                                    totalMinutosTrabajador = listadoFechaAsistenciaPorHoras.Sum(x => x.minutosTrabajadas != (decimal?)null ? x.minutosTrabajadas : 0);

                                                    foreach (var itemDistribucion in listadoFechaAsistenciaPorHoras)
                                                    {
                                                        #region Distribuir Por horas()
                                                        try
                                                        {
                                                            if (totalMinutosTrabajador > 0)
                                                            {
                                                                #region Registrar Distribucion()
                                                                SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                                                //oDistribuir.item = "";
                                                                oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                                                oDistribuir.codigoPersonal = itemTrabajadores.codigoPersonal;
                                                                oDistribuir.cantidad = itemDistribucion.horasTrabajadas;
                                                                oDistribuir.horasTrabajadas = itemDistribucion.horasTrabajadas;
                                                                oDistribuir.minutos = itemDistribucion.minutosTrabajadas;
                                                                oDistribuir.idConsumidor = itemDistribucion.codigoConsumidor;
                                                                oDistribuir.costoxMinuto = (itemDistribucion.minutosTrabajadas * importeDistribuir);
                                                                oDistribuir.costoDistribuido = (oDistribuir.costoxMinuto / totalMinutosTrabajador);
                                                                oDistribuir.dniProveedor = itemPension.dniPension;
                                                                oDistribuir.codigoPension = itemPension.codigoPension;
                                                                oDistribuir.SubPlanilla = itemSubPlanilla.subPlanilla;
                                                                oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                                                oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                                                oDistribuir.nombresPersonal = itemTrabajadores.nombresPersonal;
                                                                oDistribuir.dniPersonal = itemTrabajadores.dniPersonal;
                                                                oDistribuir.consumidor = itemDistribucion.consumidor;
                                                                oDistribuir.fechaRegistro = DateTime.Now;
                                                                oDistribuir.Proveedor = itemPension.nombrePension;
                                                                oDistribuir.tipoMovimiento = 'P';
                                                                oDistribuir.estado = 1;
                                                                oDistribuir.glosa = "Distribución por el importe de " + Math.Round(oDistribuir.costoDistribuido.Value, 2) + " del personal " + oDistribuir.codigoPersonal + " - " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio " + oRefrigerio.refrigerio + " en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado " + oDistribuir.cantidad + " horas de trabajado en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                                                Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                                                Modelo.SubmitChanges();
                                                                #endregion
                                                            }
                                                            else
                                                            {
                                                                #region  agregar a listar de personal que no registrar asistencia ni por rendimiendo ni por horas()
                                                                switch (oRefrigerio.refrigerio)
                                                                {
                                                                    case "DESAYUNO":
                                                                        ImportexPersonaxFacturaDesayuno += importeDistribuir;
                                                                        listaCodigoTrabajadoresSinAsistenciaDesayuno.Add(itemTrabajadores.codigoPersonal.ToString().Trim());
                                                                        break;

                                                                    case "ALMUERZO":
                                                                        ImportexPersonaxFacturaAlmuerzo += importeDistribuir;
                                                                        listaCodigoTrabajadoresSinAsistenciaAlmuerzo.Add(itemTrabajadores.codigoPersonal.ToString().Trim());
                                                                        break;

                                                                    case "CENA":
                                                                        ImportexPersonaxFacturaCena += importeDistribuir;
                                                                        listaCodigoTrabajadoresSinAsistenciaCena.Add(itemTrabajadores.codigoPersonal.ToString().Trim());

                                                                        break;
                                                                    default:
                                                                        break;
                                                                }

                                                                listaErrores += "SUB PLANILLA:" + itemDistribucion.subPlanilla + " / PENSION: " + itemPension.dniPension + " - " + itemPension.nombrePension + " / FECHA: " + itemFechaRefrigerio.fechaRefrigerio.ToShortDateString() + " / TRABAJADOR: " + itemTrabajadores.codigoPersonal + " - " + itemTrabajadores.nombresPersonal + " NO REGISTRO ASISTENCIA\r\n";
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
                                                }
                                                else
                                                {
                                                    #region Generar listado de Inasistencias del personal()

                                                    //ImportexPersonaxFactura += ImportexPersona;                                                    
                                                    //listaCodigoTrabajadoresSinAsistencia.Add(itemTrabajadores.codigoPersonal.ToString().Trim());
                                                    switch (oRefrigerio.refrigerio)
                                                    {
                                                        case "DESAYUNO":
                                                            ImportexPersonaxFacturaDesayuno += ImportexPersona;
                                                            listaCodigoTrabajadoresSinAsistenciaDesayuno.Add(itemTrabajadores.codigoPersonal.ToString().Trim());
                                                            break;

                                                        case "ALMUERZO":
                                                            ImportexPersonaxFacturaAlmuerzo += ImportexPersona;
                                                            listaCodigoTrabajadoresSinAsistenciaAlmuerzo.Add(itemTrabajadores.codigoPersonal.ToString().Trim());
                                                            break;

                                                        case "CENA":
                                                            ImportexPersonaxFacturaCena += ImportexPersona;
                                                            listaCodigoTrabajadoresSinAsistenciaCena.Add(itemTrabajadores.codigoPersonal.ToString().Trim());

                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    listaErrores += "SUB PLANILLA:" + itemSubPlanilla.subPlanilla + " / PENSION: " + itemPension.dniPension + " - " + itemPension.nombrePension + " / FECHA: " + itemFechaRefrigerio.fechaRefrigerio.ToShortDateString() + " / TRABAJADOR: " + itemTrabajadores.codigoPersonal + " - " + itemTrabajadores.nombresPersonal + " NO REGISTRO ASISTENCIA\r\n";

                                                    #endregion
                                                }
                                                #endregion
                                            }
                                            #endregion
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }

                                /*Prorratear el importe acumulado por no asistencia del personal a labores de campo*/
                                if ((ImportexPersonaxFacturaDesayuno + ImportexPersonaxFacturaAlmuerzo + ImportexPersonaxFacturaCena) > 0)
                                {
                                    #region
                                    if (ImportexPersonaxFacturaDesayuno > 0)
                                    {
                                        #region Prorratear los desayuno no tomados en cuenta()
                                        var listadoConsumidores = (from itemDia in ListadoRegisrtosAgregadosBaseDatos
                                                                   where itemDia.idConsumidor != null
                                                                   group itemDia by new { itemDia.idConsumidor } into j
                                                                   select new
                                                                   {
                                                                       idConsumidor = j.Key.idConsumidor.Trim().ToUpper(),
                                                                       consumidor = j.FirstOrDefault().consumidor != null ? j.FirstOrDefault().consumidor.Trim() : "",
                                                                   }).ToList();
                                        int ContadorResultado = listadoConsumidores != null ? listadoConsumidores.Count : 0;

                                        if (ContadorResultado > 0)
                                        {
                                            #region
                                            decimal? ImportePorConsumidorADistribuir = Math.Round(Convert.ToDecimal(ImportexPersonaxFacturaDesayuno / ContadorResultado), 2);
                                            {
                                                foreach (var itemCampo in listadoConsumidores)
                                                {
                                                    var listaAgrupadaxConsumidor = ListadoRegisrtosAgregadosBaseDatos.Where(x => x.idConsumidor == itemCampo.idConsumidor).ToList();
                                                    try
                                                    {
                                                        SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                                        //oDistribuir.item = "";
                                                        oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                                        oDistribuir.codigoPersonal = "";
                                                        oDistribuir.cantidad = 0;
                                                        oDistribuir.horasTrabajadas = 8;
                                                        oDistribuir.minutos = 480;
                                                        oDistribuir.idConsumidor = itemCampo.idConsumidor;
                                                        oDistribuir.costoxMinuto = 0;
                                                        oDistribuir.costoDistribuido = ImportePorConsumidorADistribuir;
                                                        oDistribuir.dniProveedor = itemPension.dniPension;
                                                        oDistribuir.codigoPension = itemPension.codigoPension;
                                                        oDistribuir.SubPlanilla = itemSubPlanilla.subPlanilla;
                                                        oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                                        oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                                        oDistribuir.nombresPersonal = "VARIOS";
                                                        oDistribuir.dniPersonal = "";
                                                        oDistribuir.consumidor = itemCampo.consumidor;
                                                        oDistribuir.fechaRegistro = DateTime.Now;
                                                        oDistribuir.Proveedor = itemPension.nombrePension;
                                                        oDistribuir.tipoMovimiento = 'P';
                                                        oDistribuir.estado = 1;
                                                        oDistribuir.glosa = "Prorratero por el importe de " + oDistribuir.costoDistribuido.Value.ToString("N2") + " del personal " + oDistribuir.codigoPersonal + " - " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio DESAYUNO en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado " + oDistribuir.cantidad + " racimos trabajados en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                                        //ListadoRegisrtosAgregadosBaseDatos.Add(oDistribuir);
                                                        Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                                        Modelo.SubmitChanges();
                                                    }
                                                    catch (Exception Ex)
                                                    {
                                                        throw Ex;
                                                    }

                                                }
                                            }
                                            #endregion
                                        }
                                        #region Distribuir el Importe entre todos los consumidores()

                                        #endregion
                                        #endregion

                                    }

                                    if (ImportexPersonaxFacturaAlmuerzo > 0)
                                    {
                                        #region Prorratear los Almuerzo no tomados en cuenta()
                                        var listadoConsumidores = (from itemDia in ListadoRegisrtosAgregadosBaseDatos
                                                                   where itemDia.idConsumidor != null
                                                                   group itemDia by new { itemDia.idConsumidor } into j
                                                                   select new
                                                                   {
                                                                       idConsumidor = j.Key.idConsumidor.Trim().ToUpper(),
                                                                       consumidor = j.FirstOrDefault().consumidor != null ? j.FirstOrDefault().consumidor.Trim() : "",
                                                                   }).ToList();
                                        int ContadorResultado = listadoConsumidores != null ? listadoConsumidores.Count : 0;

                                        if (ContadorResultado > 0)
                                        {
                                            #region
                                            decimal? ImportePorConsumidorADistribuir = Math.Round(Convert.ToDecimal(ImportexPersonaxFacturaAlmuerzo / ContadorResultado), 2);
                                            {
                                                foreach (var itemCampo in listadoConsumidores)
                                                {
                                                    var listaAgrupadaxConsumidor = ListadoRegisrtosAgregadosBaseDatos.Where(x => x.idConsumidor == itemCampo.idConsumidor).ToList();
                                                    try
                                                    {
                                                        SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                                        //oDistribuir.item = "";
                                                        oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                                        oDistribuir.codigoPersonal = "";
                                                        oDistribuir.cantidad = 0;
                                                        oDistribuir.horasTrabajadas = 8;
                                                        oDistribuir.minutos = 480;
                                                        oDistribuir.idConsumidor = itemCampo.idConsumidor;
                                                        oDistribuir.costoxMinuto = 0;
                                                        oDistribuir.costoDistribuido = ImportePorConsumidorADistribuir;
                                                        oDistribuir.dniProveedor = itemPension.dniPension;
                                                        oDistribuir.codigoPension = itemPension.codigoPension;
                                                        oDistribuir.SubPlanilla = itemSubPlanilla.subPlanilla;
                                                        oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                                        oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                                        oDistribuir.nombresPersonal = "VARIOS";
                                                        oDistribuir.dniPersonal = "";
                                                        oDistribuir.consumidor = itemCampo.consumidor;
                                                        oDistribuir.fechaRegistro = DateTime.Now;
                                                        oDistribuir.Proveedor = itemPension.nombrePension;
                                                        oDistribuir.tipoMovimiento = 'P';
                                                        oDistribuir.estado = 1;
                                                        oDistribuir.glosa = "Prorratero por el importe de " + oDistribuir.costoDistribuido.Value.ToString("N2") + " del personal " + oDistribuir.codigoPersonal + " - " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio ALMUERZO en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado " + oDistribuir.cantidad + " racimos trabajados en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                                        //ListadoRegisrtosAgregadosBaseDatos.Add(oDistribuir);
                                                        Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                                        Modelo.SubmitChanges();
                                                    }
                                                    catch (Exception Ex)
                                                    {
                                                        throw Ex;
                                                    }

                                                }
                                            }
                                            #endregion
                                        }
                                        #region Distribuir el Importe entre todos los consumidores()

                                        #endregion
                                        #endregion
                                    }


                                    if (ImportexPersonaxFacturaCena > 0)
                                    {
                                        #region Prorratear los Almuerzo no tomados en cuenta()
                                        var listadoConsumidores = (from itemDia in ListadoRegisrtosAgregadosBaseDatos
                                                                   where itemDia.idConsumidor != null
                                                                   group itemDia by new { itemDia.idConsumidor } into j
                                                                   select new
                                                                   {
                                                                       idConsumidor = j.Key.idConsumidor.Trim().ToUpper(),
                                                                       consumidor = j.FirstOrDefault().consumidor != null ? j.FirstOrDefault().consumidor.Trim() : "",
                                                                   }).ToList();
                                        int ContadorResultado = listadoConsumidores != null ? listadoConsumidores.Count : 0;

                                        if (ContadorResultado > 0)
                                        {
                                            #region
                                            decimal? ImportePorConsumidorADistribuir = Math.Round(Convert.ToDecimal(ImportexPersonaxFacturaCena / ContadorResultado), 2);
                                            {
                                                foreach (var itemCampo in listadoConsumidores)
                                                {
                                                    var listaAgrupadaxConsumidor = ListadoRegisrtosAgregadosBaseDatos.Where(x => x.idConsumidor == itemCampo.idConsumidor).ToList();
                                                    try
                                                    {
                                                        SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                                        //oDistribuir.item = "";
                                                        oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                                        oDistribuir.codigoPersonal = "";
                                                        oDistribuir.cantidad = 0;
                                                        oDistribuir.horasTrabajadas = 8;
                                                        oDistribuir.minutos = 480;
                                                        oDistribuir.idConsumidor = itemCampo.idConsumidor;
                                                        oDistribuir.costoxMinuto = 0;
                                                        oDistribuir.costoDistribuido = ImportePorConsumidorADistribuir;
                                                        oDistribuir.dniProveedor = itemPension.dniPension;
                                                        oDistribuir.codigoPension = itemPension.codigoPension;
                                                        oDistribuir.SubPlanilla = itemSubPlanilla.subPlanilla;
                                                        oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                                        oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                                        oDistribuir.nombresPersonal = "VARIOS";
                                                        oDistribuir.dniPersonal = "";
                                                        oDistribuir.consumidor = itemCampo.consumidor;
                                                        oDistribuir.fechaRegistro = DateTime.Now;
                                                        oDistribuir.Proveedor = itemPension.nombrePension;
                                                        oDistribuir.tipoMovimiento = 'P';
                                                        oDistribuir.estado = 1;
                                                        oDistribuir.glosa = "Prorratero por el importe de " + oDistribuir.costoDistribuido.Value.ToString("N2") + " del personal " + oDistribuir.codigoPersonal + " - " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio CENA en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado " + oDistribuir.cantidad + " racimos trabajados en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                                        //ListadoRegisrtosAgregadosBaseDatos.Add(oDistribuir);
                                                        Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                                        Modelo.SubmitChanges();
                                                    }
                                                    catch (Exception Ex)
                                                    {
                                                        throw Ex;
                                                    }

                                                }
                                            }
                                            #endregion
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }

                /* Distribuir para todas las planillas menos para la SubPlanilla-Ica */
                if (ListadoAsistenciaPension.Where(x => !x.SubPlanilla.ToString().Trim().ToUpper().Contains("ICA")).ToList().Count > 0)
                {
                    #region Sub Planillas menos Ica()
                    var ListadoAsistenciaPensionSinIca = ListadoAsistenciaPension.Where(x => !x.SubPlanilla.ToString().Trim().ToUpper().Contains("ICA")).ToList();
                    if (ListadoAsistenciaPensionSinIca != null && ListadoAsistenciaPensionSinIca.ToList().Count > 0)
                    {
                        #region Todas las planilla  menos las que sean de ICA()
                        /* obtengo toda la lista de la planillas de ican sin importar la pension fecha, etc*/
                        var Personal = ListadoAsistenciaPensionSinIca.ToList();

                        /*Obtener lista de planillas */
                        var listadoPlanillas = (from item in Personal
                                                where item.CodigoPersonal != null && item.CodigoPersonal.ToString().Trim() != ""
                                                group item by new { item.SubPlanilla } into j
                                                select new
                                                {
                                                    subPlanilla = j.Key.SubPlanilla.ToString().Trim(),
                                                }
                                                ).ToList();

                        foreach (var itemSubPlanilla in listadoPlanillas)
                        {
                            #region SubPlanillas()
                            /*Obtener lista de Pensionistras */
                            var listadoPensionista = (from itemPension in Personal.Where(x => x.SubPlanilla.ToString().Trim() == itemSubPlanilla.subPlanilla)
                                                      where itemPension.DniPension != null && itemPension.DniPension.ToString().Trim() != ""
                                                      group itemPension by new { itemPension.DniPension } into j
                                                      select new
                                                      {
                                                          dniPension = j.Key.DniPension.ToString().Trim(),
                                                          codigoPension = j.FirstOrDefault().IdPension,
                                                          nombrePension = j.FirstOrDefault().NombresPension.ToString().Trim(),
                                                      }
                                               ).ToList();


                            foreach (var itemPension in listadoPensionista)
                            {
                                #region Lista Fechas

                                #region agrupacion de Fechas()
                                var listadoAsistenciaFechas = Personal.Where(x =>
                                    x.SubPlanilla.ToString().Trim() == itemSubPlanilla.subPlanilla &&
                                    x.DniPension.ToString().Trim() == itemPension.dniPension).ToList();


                                /*Obtener lista de Trabajadores que Asistieron a la Pensión */
                                var listadoFechas = (from itemFechaRefrigerio in listadoAsistenciaFechas
                                                     where itemFechaRefrigerio.FechaRefrigerio != null
                                                     group itemFechaRefrigerio by new { itemFechaRefrigerio.FechaRefrigerio } into j
                                                     select new
                                                     {
                                                         fechaRefrigerio = Convert.ToDateTime(j.Key.FechaRefrigerio),
                                                         periodo = Convert.ToDateTime(j.Key.FechaRefrigerio).Year.ToString() + Convert.ToDateTime(j.Key.FechaRefrigerio).Month.ToString().Trim().PadLeft(2, '0'),
                                                         //semana =
                                                     }
                                               ).ToList();
                                #endregion

                                List<SJ_RHDistribucionFacturacion> ListadoRegisrtosAgregadosBaseDatos = new List<SJ_RHDistribucionFacturacion>();
                                foreach (var itemFechaRefrigerio in listadoFechas)
                                {
                                    #region Listado Personal()
                                    var listadoAsistenciaPensionistas = Personal.Where(x => x.SubPlanilla.ToString().Trim() == itemSubPlanilla.subPlanilla && x.DniPension.ToString().Trim() == itemPension.dniPension && Convert.ToDateTime(x.FechaRefrigerio) == itemFechaRefrigerio.fechaRefrigerio).ToList();

                                    /*Obtener lista de Trabajadores que Asistieron a la Pensión */
                                    var listadoPersonal = (from itemPersonal in listadoAsistenciaPensionistas
                                                           where itemPersonal.CodigoPersonal != null && itemPersonal.CodigoPersonal.ToString().Trim() != ""
                                                           group itemPersonal by new { itemPersonal.CodigoPersonal } into j
                                                           select new
                                                           {
                                                               codigoPersonal = j.Key.CodigoPersonal.ToString().Trim(),
                                                               nombresPersonal = j.FirstOrDefault().NombresTrabajador.ToString().Trim(),
                                                               dniPersonal = j.FirstOrDefault().DniTrabajador.ToString().Trim(),
                                                           }
                                                   ).ToList();

                                    ImportexPersonaxFactura = listadoAsistenciaPensionistas.Sum(x => x.Importe != null ? x.Importe.Value : 0);

                                    ImportexPersonaListadoDesayuno = 0;
                                    ImportexPersonaListadoAlmuerzo = 0;
                                    ImportexPersonaListadoCena = 0;
                                    TotalDistribuido = 0;
                                    List<String> listaCodigoTrabajadoresSinAsistencia = new List<String>();
                                    listaCodigoTrabajadoresSinAsistenciaDesayuno = new List<string>();
                                    listaCodigoTrabajadoresSinAsistenciaAlmuerzo = new List<string>();
                                    listaCodigoTrabajadoresSinAsistenciaCena = new List<string>();

                                    foreach (var itemTrabajadores in listadoPersonal)
                                    {
                                        #region lista Trabajadores()
                                        //var listadoFechaAsistencia = AsistenciaIca.Where(x => x.fecha == itemFechaRefrigerio.fechaRefrigerio && x.codigoTrabajador == itemTrabajadores.codigoPersonal.ToString().Trim()).ToList();
                                        var ObtenerListaAsistenciaPersonalxFechaRefrigerio = listadoAsistenciaPensionistas.Where(x => x.CodigoPersonal.ToString().Trim() == itemTrabajadores.codigoPersonal.ToString().Trim()).ToList();

                                        decimal? ImportexPersona = ObtenerListaAsistenciaPersonalxFechaRefrigerio.Sum(x => x.Importe != (decimal?)null ? x.Importe : 0);

                                        var listaRefrigeriosxPersona = (from iRefrigerio in ObtenerListaAsistenciaPersonalxFechaRefrigerio
                                                                        group iRefrigerio by new { iRefrigerio.Refrigerio } into j
                                                                        select new
                                                                        {
                                                                            refrigerio = j.Key.Refrigerio.ToString().Trim(),
                                                                        }).ToList();


                                        if (listaRefrigeriosxPersona != null && listaRefrigeriosxPersona.ToList().Count > 0)
                                        {
                                            foreach (var oRefrigerio in listaRefrigeriosxPersona)
                                            {
                                                var listadoxRefrigerioxPersona = ObtenerListaAsistenciaPersonalxFechaRefrigerio.Where(x => x.Refrigerio.Trim() == oRefrigerio.refrigerio.Trim()).ToList();

                                                #region Asistencia del personal tanto a refrigerios como a labores en campo()
                                                /* Este es el importe que tengo que distribuir */
                                                //importeDistribuir = listadoxRefrigerioxPersona.Sum(x => x.Importe != (decimal?)null ? x.Importe : 0);
                                                importeDistribuir = listadoxRefrigerioxPersona.Sum(x => x.Importe != (decimal?)null ? x.Importe : 0);

                                                /* esta es la lista de Asistencia Personal Campo a la fecha del Refrigerio */
                                                var listadoFechaAsistencia = AsistenciaPersonalSinIca.Where(x => x.fecha == itemFechaRefrigerio.fechaRefrigerio && x.codigoTrabajador == itemTrabajadores.codigoPersonal.ToString().Trim()).ToList();

                                                var listadoFechaAsistenciaConMinutosValidos = listadoFechaAsistencia.Where(x => x.minutosTrabajadas > 0).ToList();

                                                if (listadoFechaAsistenciaConMinutosValidos != null && listadoFechaAsistenciaConMinutosValidos.ToList().Count > 0)
                                                {
                                                    #region
                                                    totalMinutosTrabajador = listadoFechaAsistenciaConMinutosValidos.Sum(x => x.minutosTrabajadas != (decimal?)null ? x.minutosTrabajadas : 0);
                                                    foreach (var itemDistribucion in listadoFechaAsistenciaConMinutosValidos)
                                                    {
                                                        #region Distribuir Por horas()
                                                        try
                                                        {
                                                            SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                                            //oDistribuir.item = "";
                                                            oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                                            oDistribuir.codigoPersonal = itemTrabajadores.codigoPersonal;
                                                            oDistribuir.cantidad = itemDistribucion.horasTrabajadas;
                                                            oDistribuir.horasTrabajadas = itemDistribucion.horasTrabajadas;
                                                            oDistribuir.minutos = itemDistribucion.minutosTrabajadas;
                                                            oDistribuir.idConsumidor = itemDistribucion.codigoConsumidor;
                                                            oDistribuir.costoxMinuto = Math.Round(Convert.ToDecimal(itemDistribucion.minutosTrabajadas * importeDistribuir), 2);
                                                            oDistribuir.costoDistribuido = Math.Round(Convert.ToDecimal(oDistribuir.costoxMinuto / totalMinutosTrabajador), 2);
                                                            TotalDistribuido += oDistribuir.costoDistribuido;
                                                            oDistribuir.dniProveedor = itemPension.dniPension;
                                                            oDistribuir.codigoPension = itemPension.codigoPension;
                                                            oDistribuir.SubPlanilla = itemSubPlanilla.subPlanilla;
                                                            oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                                            oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                                            oDistribuir.nombresPersonal = itemTrabajadores.nombresPersonal;
                                                            oDistribuir.dniPersonal = itemTrabajadores.dniPersonal;
                                                            oDistribuir.consumidor = itemDistribucion.consumidor;
                                                            oDistribuir.fechaRegistro = DateTime.Now;
                                                            oDistribuir.Proveedor = itemPension.nombrePension;
                                                            oDistribuir.tipoMovimiento = 'P';
                                                            oDistribuir.estado = 1;
                                                            oDistribuir.glosa = "Distribución por el importe de " + Math.Round(oDistribuir.costoDistribuido.Value, 2) + " del personal " + oDistribuir.codigoPersonal + " - " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio " + oRefrigerio.refrigerio + " en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado " + oDistribuir.cantidad + " horas de trabajado en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                                            ListadoRegisrtosAgregadosBaseDatos.Add(oDistribuir);
                                                            Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                                            Modelo.SubmitChanges();
                                                        }
                                                        catch (Exception Ex)
                                                        {

                                                            throw Ex;
                                                        }
                                                        #endregion
                                                    }
                                                    #endregion
                                                }
                                                else
                                                {
                                                    #region Generar listado de Inasistencias del personal()

                                                    switch (oRefrigerio.refrigerio)
                                                    {
                                                        case "DESAYUNO":
                                                            ImportexPersonaListadoDesayuno += importeDistribuir;
                                                            listaCodigoTrabajadoresSinAsistenciaDesayuno.Add(itemTrabajadores.codigoPersonal.ToString().Trim());
                                                            break;

                                                        case "ALMUERZO":
                                                            ImportexPersonaListadoAlmuerzo += importeDistribuir;
                                                            listaCodigoTrabajadoresSinAsistenciaAlmuerzo.Add(itemTrabajadores.codigoPersonal.ToString().Trim());
                                                            break;

                                                        case "CENA":
                                                            ImportexPersonaListadoCena += importeDistribuir;
                                                            listaCodigoTrabajadoresSinAsistenciaCena.Add(itemTrabajadores.codigoPersonal.ToString().Trim());
                                                            break;
                                                        default:
                                                            break;
                                                    }


                                                    //listaErrores += "SUBPLANILLA: ICA / PENSION: DOS ANGELITOS FECHA: 13/07/2015 / TRABAJADOR CON CODIGO 1234678 NO REGISTRO ASISTENCIA";
                                                    listaErrores += "SUB PLANILLA:" + itemSubPlanilla.subPlanilla + " / PENSION: " + itemPension.dniPension + " - " + itemPension.nombrePension + " / FECHA: " + itemFechaRefrigerio.fechaRefrigerio.ToShortDateString() + " / TRABAJADOR: " + itemTrabajadores.codigoPersonal + " - " + itemTrabajadores.nombresPersonal + " NO REGISTRO ASISTENCIA\r\n";

                                                    #endregion
                                                }
                                                #endregion
                                            }

                                        }

                                        #endregion
                                    }


                                    /*Prorratear el importe acumulado por no asistencia del personal a labores de campo*/
                                    if ((ImportexPersonaListadoDesayuno + ImportexPersonaListadoAlmuerzo + ImportexPersonaListadoCena) > 0)
                                    {
                                        #region Prorratero()
                                        if (ImportexPersonaListadoDesayuno > 0)
                                        {
                                            #region Prorratear por Desayunos()
                                            /* Distribuir los importes no distribuidos entres los consumidores que si se han distribuido  10/08/2015 */
                                            var listadoConsumidores = (from itemDia in ListadoRegisrtosAgregadosBaseDatos
                                                                       where itemDia.idConsumidor != null
                                                                       group itemDia by new { itemDia.idConsumidor } into j
                                                                       select new
                                                                       {
                                                                           idConsumidor = j.Key.idConsumidor.Trim().ToUpper(),
                                                                           consumidor = j.FirstOrDefault().consumidor != null ? j.FirstOrDefault().consumidor.Trim() : "",
                                                                       }).ToList();
                                            int ContadorResultado = listadoConsumidores != null ? listadoConsumidores.Count : 0;

                                            if (ContadorResultado > 0)
                                            {
                                                decimal? ImporteDistribuir = Math.Round((Convert.ToDecimal(ImportexPersonaListadoDesayuno / ContadorResultado)), 2);
                                                foreach (var itemConsumidor in listadoConsumidores)
                                                {
                                                    var listaConsumidorAgrupado = ListadoRegisrtosAgregadosBaseDatos.Where(x => x.idConsumidor == itemConsumidor.idConsumidor).ToList();

                                                    #region Distribuir Por horas()
                                                    try
                                                    {
                                                        SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                                        //oDistribuir.item = "";
                                                        oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                                        oDistribuir.codigoPersonal = "";
                                                        oDistribuir.cantidad = 0;
                                                        oDistribuir.horasTrabajadas = 0;
                                                        oDistribuir.minutos = 0;
                                                        oDistribuir.idConsumidor = itemConsumidor.idConsumidor;
                                                        oDistribuir.costoxMinuto = 0;
                                                        oDistribuir.costoDistribuido = ImporteDistribuir;
                                                        oDistribuir.dniProveedor = itemPension.dniPension;
                                                        oDistribuir.codigoPension = itemPension.codigoPension;
                                                        oDistribuir.SubPlanilla = itemSubPlanilla.subPlanilla;
                                                        oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                                        oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                                        oDistribuir.nombresPersonal = "";
                                                        oDistribuir.dniPersonal = "";
                                                        oDistribuir.consumidor = itemConsumidor.consumidor;
                                                        oDistribuir.fechaRegistro = DateTime.Now;
                                                        oDistribuir.Proveedor = itemPension.nombrePension;
                                                        oDistribuir.tipoMovimiento = 'P';
                                                        oDistribuir.estado = 1;
                                                        oDistribuir.glosa = "Prorrateo por el importe de " + Math.Round(oDistribuir.costoDistribuido.Value, 2) + " del personal " + oDistribuir.codigoPersonal + " - " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio DESAYUNO en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado " + oDistribuir.cantidad + " horas de trabajado en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                                        ListadoRegisrtosAgregadosBaseDatos.Add(oDistribuir);
                                                        Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                                        Modelo.SubmitChanges();
                                                    }
                                                    catch (Exception Ex)
                                                    {

                                                        throw Ex;
                                                    }
                                                    #endregion
                                                }
                                            }
                                            #endregion
                                        }

                                        if (ImportexPersonaListadoAlmuerzo > 0)
                                        {
                                            #region Prorratear por Almuerzos()
                                            /* Distribuir los importes no distribuidos entres los consumidores que si se han distribuido  10/08/2015 */
                                            var listadoConsumidores = (from itemDia in ListadoRegisrtosAgregadosBaseDatos
                                                                       where itemDia.idConsumidor != null
                                                                       group itemDia by new { itemDia.idConsumidor } into j
                                                                       select new
                                                                       {
                                                                           idConsumidor = j.Key.idConsumidor.Trim().ToUpper(),
                                                                           consumidor = j.FirstOrDefault().consumidor != null ? j.FirstOrDefault().consumidor.Trim() : "",
                                                                       }).ToList();
                                            int ContadorResultado = listadoConsumidores != null ? listadoConsumidores.Count : 0;

                                            if (ContadorResultado > 0)
                                            {
                                                decimal? ImporteDistribuir = Math.Round((Convert.ToDecimal(ImportexPersonaListadoAlmuerzo / ContadorResultado)), 2);
                                                foreach (var itemConsumidor in listadoConsumidores)
                                                {
                                                    var listaConsumidorAgrupado = ListadoRegisrtosAgregadosBaseDatos.Where(x => x.idConsumidor == itemConsumidor.idConsumidor).ToList();

                                                    #region Distribuir Por horas()
                                                    try
                                                    {
                                                        SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                                        //oDistribuir.item = "";
                                                        oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                                        oDistribuir.codigoPersonal = "";
                                                        oDistribuir.cantidad = 0;
                                                        oDistribuir.horasTrabajadas = 0;
                                                        oDistribuir.minutos = 0;
                                                        oDistribuir.idConsumidor = itemConsumidor.idConsumidor;
                                                        oDistribuir.costoxMinuto = 0;
                                                        oDistribuir.costoDistribuido = ImporteDistribuir;
                                                        oDistribuir.dniProveedor = itemPension.dniPension;
                                                        oDistribuir.codigoPension = itemPension.codigoPension;
                                                        oDistribuir.SubPlanilla = itemSubPlanilla.subPlanilla;
                                                        oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                                        oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                                        oDistribuir.nombresPersonal = "";
                                                        oDistribuir.dniPersonal = "";
                                                        oDistribuir.consumidor = itemConsumidor.consumidor;
                                                        oDistribuir.fechaRegistro = DateTime.Now;
                                                        oDistribuir.Proveedor = itemPension.nombrePension;
                                                        oDistribuir.tipoMovimiento = 'P';
                                                        oDistribuir.estado = 1;
                                                        oDistribuir.glosa = "Prorrateo por el importe de " + Math.Round(oDistribuir.costoDistribuido.Value, 2) + " del personal " + oDistribuir.codigoPersonal + " - " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio ALMUERZO en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado " + oDistribuir.cantidad + " horas de trabajado en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                                        ListadoRegisrtosAgregadosBaseDatos.Add(oDistribuir);
                                                        Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                                        Modelo.SubmitChanges();
                                                    }
                                                    catch (Exception Ex)
                                                    {

                                                        throw Ex;
                                                    }
                                                    #endregion
                                                }
                                            }
                                            #endregion
                                        }

                                        if (ImportexPersonaListadoCena > 0)
                                        {
                                            #region Prorratear por Cena()
                                            /* Distribuir los importes no distribuidos entres los consumidores que si se han distribuido  10/08/2015 */
                                            var listadoConsumidores = (from itemDia in ListadoRegisrtosAgregadosBaseDatos
                                                                       where itemDia.idConsumidor != null
                                                                       group itemDia by new { itemDia.idConsumidor } into j
                                                                       select new
                                                                       {
                                                                           idConsumidor = j.Key.idConsumidor.Trim().ToUpper(),
                                                                           consumidor = j.FirstOrDefault().consumidor != null ? j.FirstOrDefault().consumidor.Trim() : "",
                                                                       }).ToList();
                                            int ContadorResultado = listadoConsumidores != null ? listadoConsumidores.Count : 0;

                                            if (ContadorResultado > 0)
                                            {
                                                decimal? ImporteDistribuir = Math.Round((Convert.ToDecimal(ImportexPersonaListadoCena / ContadorResultado)), 2);
                                                foreach (var itemConsumidor in listadoConsumidores)
                                                {
                                                    var listaConsumidorAgrupado = ListadoRegisrtosAgregadosBaseDatos.Where(x => x.idConsumidor == itemConsumidor.idConsumidor).ToList();

                                                    #region Distribuir Por horas()
                                                    try
                                                    {
                                                        SJ_RHDistribucionFacturacion oDistribuir = new SJ_RHDistribucionFacturacion();
                                                        //oDistribuir.item = "";
                                                        oDistribuir.fecha = itemFechaRefrigerio.fechaRefrigerio;
                                                        oDistribuir.codigoPersonal = "";
                                                        oDistribuir.cantidad = 0;
                                                        oDistribuir.horasTrabajadas = 0;
                                                        oDistribuir.minutos = 0;
                                                        oDistribuir.idConsumidor = itemConsumidor.idConsumidor;
                                                        oDistribuir.costoxMinuto = 0;
                                                        oDistribuir.costoDistribuido = ImporteDistribuir;
                                                        oDistribuir.dniProveedor = itemPension.dniPension;
                                                        oDistribuir.codigoPension = itemPension.codigoPension;
                                                        oDistribuir.SubPlanilla = itemSubPlanilla.subPlanilla;
                                                        oDistribuir.periodo = itemFechaRefrigerio.periodo;
                                                        oDistribuir.codigoMovimientoFacturacion = codigoMovimientoFacturacion;
                                                        oDistribuir.nombresPersonal = "";
                                                        oDistribuir.dniPersonal = "";
                                                        oDistribuir.consumidor = itemConsumidor.consumidor;
                                                        oDistribuir.fechaRegistro = DateTime.Now;
                                                        oDistribuir.Proveedor = itemPension.nombrePension;
                                                        oDistribuir.tipoMovimiento = 'P';
                                                        oDistribuir.estado = 1;
                                                        oDistribuir.glosa = "Prorrateo por el importe de " + Math.Round(oDistribuir.costoDistribuido.Value, 2) + " del personal " + oDistribuir.codigoPersonal + " - " + oDistribuir.nombresPersonal + " de la subPlanilla " + oDistribuir.SubPlanilla + " por el servicio de refrigerio CENA en la pensión " + oDistribuir.Proveedor + " con fecha " + oDistribuir.fecha.Value + " por haber realizado " + oDistribuir.cantidad + " horas de trabajado en el consumidor " + oDistribuir.idConsumidor + " - " + oDistribuir.consumidor;
                                                        ListadoRegisrtosAgregadosBaseDatos.Add(oDistribuir);
                                                        Modelo.SJ_RHDistribucionFacturacion.InsertOnSubmit(oDistribuir);
                                                        Modelo.SubmitChanges();
                                                    }
                                                    catch (Exception Ex)
                                                    {

                                                        throw Ex;
                                                    }
                                                    #endregion
                                                }
                                            }
                                            #endregion
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }
                                #endregion
                            }

                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }

                #region Ajutar Resultados a la lista que deseo presentar()
                var listadoResultado = Modelo.SJ_RHObtenerDistribucionFacturacionxProveedor(desde, hasta, 'P', idProveedor).ToList();

                listaDistribuidaPensionistas = (from distribucion in listadoResultado
                                                select new SJ_RHDistribucionFacturacion
                                                {
                                                    item = distribucion.item,
                                                    fecha = distribucion.fecha,
                                                    codigoPersonal = distribucion.codigoPersonal,
                                                    cantidad = distribucion.cantidad != (decimal?)null ? distribucion.cantidad : 0,
                                                    horasTrabajadas = distribucion.horasTrabajadas != (decimal?)null ? distribucion.horasTrabajadas : 0,
                                                    minutos = distribucion.minutos != (decimal?)null ? distribucion.minutos : 0,
                                                    idConsumidor = distribucion.idConsumidor,
                                                    costoxMinuto = distribucion.costoxMinuto,
                                                    costoDistribuido = distribucion.costoDistribuido,
                                                    dniProveedor = distribucion.dniProveedor,
                                                    codigoPension = distribucion.codigoPension,
                                                    SubPlanilla = distribucion.SubPlanilla,
                                                    periodo = distribucion.periodo,
                                                    codigoMovimientoFacturacion = distribucion.codigoMovimientoFacturacion,
                                                    nombresPersonal = distribucion.nombresPersonal,
                                                    dniPersonal = distribucion.dniPersonal,
                                                    consumidor = distribucion.consumidor,
                                                    fechaRegistro = distribucion.fechaRegistro,
                                                    Proveedor = distribucion.Proveedor,
                                                    glosa = distribucion.glosa,
                                                    tipoMovimiento = distribucion.tipoMovimiento,
                                                    estado = distribucion.estado
                                                }
                                                    ).ToList();
                #endregion

                //GenerarNotificacionTXT(listaErrores);
                Modelo.Connection.Close();
                Modelo.Dispose();
                return listaDistribuidaPensionistas;
                #endregion
            }

        }

        /* LISTADO DE INASISTENCIA A LOS REFRIGERIOS para el descuento por planilla*/
        public List<DescuentoByInasistenciaRefrigerio> AgruparListaInasistenciaRefrigerios(List<RefrigerioAgrupado> ListadoGeneralPensionistasAgrupado)
        {
            List<DescuentoByInasistenciaRefrigerio> listado = new List<DescuentoByInasistenciaRefrigerio>();

            if (ListadoGeneralPensionistasAgrupado != null && ListadoGeneralPensionistasAgrupado.ToList().Count > 0)
            {

                var listadoPersonalInasistente = (from item in ListadoGeneralPensionistasAgrupado
                                                  where item.Trabajador != null && item.Inasistencia.ToUpper().Trim() == "NO"
                                                  group item by new { item.CodigoPersonal } into j
                                                  select new
                                                  {
                                                      codigoPersonal = j.Key.CodigoPersonal,
                                                      dniPersonal = j.FirstOrDefault().DNITrabajador != null ? j.FirstOrDefault().DNITrabajador.ToString().Trim() : "",
                                                      nombres = j.FirstOrDefault().Trabajador != null ? j.FirstOrDefault().Trabajador.ToString().Trim() : "",
                                                  }).ToList();

                if (listadoPersonalInasistente != null && listadoPersonalInasistente.ToList().Count > 0)
                {
                    foreach (var trabajador in listadoPersonalInasistente)
                    {
                        var obtenerListadoInasistenciaByPersonal = ListadoGeneralPensionistasAgrupado.Where(x => x.CodigoPersonal.ToString().Trim() == trabajador.codigoPersonal.ToString().Trim() && x.Inasistencia.ToUpper().Trim() == "NO").ToList();
                        if (obtenerListadoInasistenciaByPersonal != null && obtenerListadoInasistenciaByPersonal.ToList().Count > 0)
                        {


                            var listadoPersonalInasistentebyDia = (from item in obtenerListadoInasistenciaByPersonal
                                                                   where item.Trabajador != null
                                                                   group item by new { item.Fecha } into j
                                                                   select new
                                                                   {
                                                                       fecha = j.Key.Fecha,

                                                                   }).ToList();

                            int? numerodiasInasistidos = listadoPersonalInasistentebyDia.Count;


                            decimal? numeroAlmuerzos = 0;
                            decimal? numeroDesayunos = 0;
                            decimal? numeroCenas = 0;
                            decimal? totalDescuento = 0;


                            foreach (var fecha in listadoPersonalInasistentebyDia)
                            {

                                var ObtenerTotalRefrigeriosxDia = obtenerListadoInasistenciaByPersonal.Where(x => x.Fecha.Value == fecha.fecha.Value).ToList();
                                numeroAlmuerzos += ObtenerTotalRefrigeriosxDia.Where(x => x.Almuerzo.Value == true).ToList() != null ? ObtenerTotalRefrigeriosxDia.Where(x => x.Almuerzo.Value == true).ToList().Count : 0;
                                numeroDesayunos += ObtenerTotalRefrigeriosxDia.Where(x => x.Desayuno.Value == true).ToList() != null ? ObtenerTotalRefrigeriosxDia.Where(x => x.Desayuno.Value == true).ToList().Count : 0;
                                numeroCenas += ObtenerTotalRefrigeriosxDia.Where(x => x.Cena.Value == true).ToList() != null ? ObtenerTotalRefrigeriosxDia.Where(x => x.Cena.Value == true).ToList().Count : 0;

                            }

                            totalDescuento = (numeroAlmuerzos * Convert.ToDecimal(3.5)) + (numeroDesayunos * Convert.ToDecimal(2.5)) + (numeroCenas * Convert.ToDecimal(2.5));

                            DescuentoByInasistenciaRefrigerio descuentoPersonal = new DescuentoByInasistenciaRefrigerio();
                            descuentoPersonal.codigoPersonal = trabajador.codigoPersonal;
                            descuentoPersonal.dniPersonal = trabajador.dniPersonal;
                            descuentoPersonal.nombres = trabajador.nombres;
                            descuentoPersonal.diasAusentes = numerodiasInasistidos;
                            descuentoPersonal.importeDescuento = totalDescuento;
                            listado.Add(descuentoPersonal);
                        }
                    }
                }
            }
            return listado;
        }

        /*LISTADO DE ASISTENCIAS PENDIENTES POR PROVEEDOR Y PERIODO SE USA GENERALMENTE PARA REALIZAR LA ACTUALIZACION MASIVA DE LA FECHA DE PENSION*/
        public List<SJ_RRHHListarAsistenciasPendientesProcesoByProveedorByPeriodoResult> ObtenerAsistenciasPendientesProcesoByProveedorByPeriodo(string dniPension, string desde, string hasta)
        {
            List<SJ_RRHHListarAsistenciasPendientesProcesoByProveedorByPeriodoResult> listadoAsistencia = new List<SJ_RRHHListarAsistenciasPendientesProcesoByProveedorByPeriodoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 999990;
                listadoAsistencia = Modelo.SJ_RRHHListarAsistenciasPendientesProcesoByProveedorByPeriodo(dniPension, desde, hasta).ToList();
                Modelo.Connection.Close();
                Modelo.Dispose();
            }

            return listadoAsistencia;
        }

        public void ActualizarAsistenciaRefrigerioByProveedorByPeriodo(string periodo, SJM_Pensione movimientoAsistenciaPension, string fecha)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 999990;
                var resultadoConsulta = Modelo.SJM_Pensiones.Where(x => x.IdPension == movimientoAsistenciaPension.IdPension).ToList();

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                {
                    SJM_Pensione movimientoAsistencia = new SJM_Pensione();
                    movimientoAsistencia = resultadoConsulta.Single();
                    movimientoAsistencia.FechaPension = Convert.ToDateTime(fecha);
                    movimientoAsistencia.estado = 1;
                    Modelo.SubmitChanges();
                }
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
        }

        public List<IndicadorAsistencia> ObtenerListaAsistenciaPersonalGeneralByHorasByPlanillaMovilesVID(string fechaDesde, string fechaHasta, string idPlanilla, string codigoGeneral)
        {
            List<IndicadorAsistencia> listado = new List<IndicadorAsistencia>();

            return listado;
        }
    }
}

