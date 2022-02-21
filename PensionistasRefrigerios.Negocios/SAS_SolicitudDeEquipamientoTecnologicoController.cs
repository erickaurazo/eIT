using Asistencia.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Transactions;
using MyControlsDataBinding.Busquedas;

namespace Asistencia.Negocios
{
    public class SAS_SolicitudDeEquipamientoTecnologicoController
    {

        public List<SAS_SolicitudDeEquipamientoTecnologicoListado> ListRequests(string conection)
        {
            List<SAS_SolicitudDeEquipamientoTecnologicoListado> list = new List<SAS_SolicitudDeEquipamientoTecnologicoListado>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                list = model.SAS_SolicitudDeEquipamientoTecnologicoListado.ToList();
            }
            return list.OrderByDescending(x=> x.id).ToList(); 
        }

        public int ToRegister(string conection, SAS_SolicitudDeEquipamientoTecnologico item)
        {
            //SAS_DispositivoTipoSoftware oregistro = new SAS_DispositivoTipoSoftware();
            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();

            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    var resultado = model.SAS_SolicitudDeEquipamientoTecnologico.Where(x => x.id == item.id).ToList();
                    if (resultado != null)
                    {
                        #region Registro | Actualizacion()  
                        if (resultado.ToList().Count == 0)
                        {
                            //int ObtenerUltimoItem = model.SAS_LicenciaCorreo.ToList().Count > 0 ? Convert.ToInt32(model.AREAS.ToList().Max(x => x.IDAREA)) + 1 : 0;
                            #region Nuevo() 
                            SAS_SolicitudDeEquipamientoTecnologico oregistro = new SAS_SolicitudDeEquipamientoTecnologico();
                            //oregistro.id =  item.id;
                            oregistro.idCodigoGeneral = item.idCodigoGeneral;
                            oregistro.nombresCompletos = item.nombresCompletos;
                            oregistro.esExterno = item.esExterno;
                            oregistro.fecha = item.fecha;
                            oregistro.fechaDeVencimiento = item.fechaDeVencimiento;
                            oregistro.esTemporal = item.esTemporal;
                            oregistro.vencimientoContrato = item.vencimientoContrato;
                            oregistro.itemInicioContrato = item.itemInicioContrato;
                            oregistro.tipoContrato = item.tipoContrato;

                            oregistro.justificacion = item.justificacion;
                            oregistro.estadoCodigo = item.estadoCodigo;
                            oregistro.usuarioEnAtencion = item.usuarioEnAtencion;
                            oregistro.tipoSolicitud = item.tipoSolicitud;
                            model.SAS_SolicitudDeEquipamientoTecnologico.InsertOnSubmit(oregistro);
                            model.SubmitChanges();
                            tipoResultadoOperacion = 0; // registrar
                            #endregion
                        }
                        else if (resultado.ToList().Count == 1)
                        {
                            #region Actualizar() 
                            SAS_SolicitudDeEquipamientoTecnologico oregistro = new SAS_SolicitudDeEquipamientoTecnologico();
                            oregistro = resultado.Single();
                            oregistro.idCodigoGeneral = item.idCodigoGeneral;
                            oregistro.nombresCompletos = item.nombresCompletos;
                            oregistro.esExterno = item.esExterno;
                            oregistro.fecha = item.fecha;
                            oregistro.fechaDeVencimiento = item.fechaDeVencimiento;
                            oregistro.esTemporal = item.esTemporal;
                            oregistro.justificacion = item.justificacion;
                            oregistro.estadoCodigo = item.estadoCodigo;
                            oregistro.usuarioEnAtencion = item.usuarioEnAtencion;
                            oregistro.tipoSolicitud = item.tipoSolicitud;
                            oregistro.vencimientoContrato = item.vencimientoContrato;
                            oregistro.itemInicioContrato = item.itemInicioContrato;
                            oregistro.tipoContrato = item.tipoContrato;

                            model.SubmitChanges();
                            #endregion
                            tipoResultadoOperacion = 1; // modificar
                        }
                        #endregion
                    }
                    Scope.Complete();
                }
            }

            return tipoResultadoOperacion;

        }

        public int ChangeState(string conection, SAS_SolicitudDeEquipamientoTecnologico item)
        {
            SAS_SolicitudDeEquipamientoTecnologico oregistro = new SAS_SolicitudDeEquipamientoTecnologico();
            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                var resultado = model.SAS_SolicitudDeEquipamientoTecnologico.Where(x => x.id == item.id).ToList();
                if (resultado != null)
                {
                    if (resultado.ToList().Count == 1)
                    {
                        #region Cambiar de estado()                         
                        oregistro = resultado.Single();

                        if (oregistro.estadoCodigo == "PE" || oregistro.estadoCodigo == "AN")
                        {
                            if (oregistro.estadoCodigo == "PE")
                            {
                                oregistro.estadoCodigo = "AN";
                                tipoResultadoOperacion = 2; // desactivar
                            }
                            else
                            {
                                oregistro.estadoCodigo = "PE";
                                tipoResultadoOperacion = 3; // Activar
                            }
                        }
                        model.SubmitChanges();
                        #endregion                       
                    }
                }
            }
            return tipoResultadoOperacion;
        }

        // Obtener Consulta completo de una solicitud por Id
        public SAS_SolicitudDeEquipamientoTecnologicoListadoByIdResult ListRequestsById(string conection, SAS_SolicitudDeEquipamientoTecnologico item)
        {
            SAS_SolicitudDeEquipamientoTecnologicoListadoByIdResult oItem = new SAS_SolicitudDeEquipamientoTecnologicoListadoByIdResult();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                var result = model.SAS_SolicitudDeEquipamientoTecnologicoListadoById(item.id).ToList();
                if (result.ToList().Count == 0)
                {
                    oItem = new SAS_SolicitudDeEquipamientoTecnologicoListadoByIdResult();
                    oItem.id = item.id;
                    oItem.idCodigoGeneral = string.Empty;
                    oItem.nombresCompletos = string.Empty;
                    oItem.esExterno = 0;
                    oItem.fecha = DateTime.Now;
                    oItem.fechaDeVencimiento = (DateTime?)null;
                    oItem.esTemporal = 0;
                    oItem.justificacion = string.Empty;
                    oItem.estadoCodigo = "PE";
                    oItem.estado = "PENDIENTE";
                    oItem.usuarioEnAtencion = string.Empty;
                    oItem.estadoEnPlanilla = string.Empty;
                    oItem.planillaCodigo = string.Empty;
                    oItem.numeroDocumento = string.Empty;
                    oItem.planilla = string.Empty;
                    oItem.cargo = string.Empty;
                    oItem.documento = "SOL-0001-0000000";
                    oItem.idTipoSolicitud = 1;
                    oItem.tipoSolicitud = "Alta";
                    oItem.idGerencia = 0;
                    oItem.gerencia = string.Empty;
                    oItem.idArea = string.Empty;
                    oItem.area = string.Empty;
                    oItem.vencimientoContrato = (DateTime?)null;
                    oItem.itemInicioContrato = string.Empty;
                    oItem.fecha_Ingreso = (DateTime?)null;
                    oItem.tipoContrato = (decimal?)null;
                    oItem.tipoContratoDescripcion = string.Empty;

                }
                else if (result.ToList().Count == 1)
                {
                    oItem = result.Single();
                }
                else if (result.ToList().Count > 1)
                {
                    oItem = result.ElementAt(0);
                }


            }
            return oItem;
        }

        #region Cargar listado en blanco para la solicitus (sedes, hardware, Software) 
        // Generar Sedes en blanco con Id en blanco pasará como 0
        public List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSedesResult> ObtainABlankListOfTheDetailsOfTheVenues(string conection, SAS_SolicitudDeEquipamientoTecnologico item)
        {
            List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSedesResult> list = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSedesResult>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                list = model.SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSedes(item.id).ToList();

            }
            return list.OrderBy(x => x.item).ToList();
        }

        // Generar Hardware en blanco con Id en blanco pasará como 0
        public List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoHardwareResult> GetHardwareDetailBlanklistingForRequest(string conection, SAS_SolicitudDeEquipamientoTecnologico item)
        {
            List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoHardwareResult> list = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoHardwareResult>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                list = model.SAS_SolicitudDeEquipamientoTecnologicoEnBlancoHardware(item.id).ToList();

            }
            return list.OrderBy(x => x.id).ToList();
        }

        // Obtener Software completo de una solicitud por Id
        public List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSoftwareResult> GetSoftwareDetailBlanklistingForRequest(string conection, SAS_SolicitudDeEquipamientoTecnologico item)
        {
            List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSoftwareResult> list = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSoftwareResult>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                list = model.SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSoftware(item.id).ToList();

            }
            return list.OrderByDescending(x => x.id).ToList();
        }
        #endregion

        #region Obtener listado detalles para la solicitud (sedes, hardware, Software) 
        // Generar Sedes en blanco con Id en blanco pasará como 0
        public List<SAS_SolicitudDeEquipamientoTecnologicoSedesByIdResult> GetDetailedListOfVenuesByRequestId(string conection, SAS_SolicitudDeEquipamientoTecnologico item)
        {
            List<SAS_SolicitudDeEquipamientoTecnologicoSedesByIdResult> list = new List<SAS_SolicitudDeEquipamientoTecnologicoSedesByIdResult>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                list = model.SAS_SolicitudDeEquipamientoTecnologicoSedesById(item.id).ToList();

            }
            return list.OrderBy(x => x.item).ToList();
        }

        // Generar Hardware en blanco con Id en blanco pasará como 0
        public List<SAS_SolicitudDeEquipamientoTecnologicoHardwareByIdResult> GetListOfHardwareDetailByRequestId(string conection, SAS_SolicitudDeEquipamientoTecnologico item)
        {
            List<SAS_SolicitudDeEquipamientoTecnologicoHardwareByIdResult> list = new List<SAS_SolicitudDeEquipamientoTecnologicoHardwareByIdResult>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                list = model.SAS_SolicitudDeEquipamientoTecnologicoHardwareById(item.id).ToList();

            }
            return list.OrderBy(x => x.item).ToList();
        }

        // Obtener Software completo de una solicitud por Id
        public List<SAS_SolicitudDeEquipamientoTecnologicoSoftwareByIdResult> GetListOfSoftwareDetailByRequestId(string conection, SAS_SolicitudDeEquipamientoTecnologico item)
        {
            List<SAS_SolicitudDeEquipamientoTecnologicoSoftwareByIdResult> list = new List<SAS_SolicitudDeEquipamientoTecnologicoSoftwareByIdResult>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                list = model.SAS_SolicitudDeEquipamientoTecnologicoSoftwareById(item.id).ToList();

            }
            return list.OrderBy(x => x.item).ToList();
        }

        public List<DFormatoSimple> GetListOfProfiles(string conection)
        {
            //1.- Si esta activado el check de elegido se puede elegir un perfil

            List<DFormatoSimple> listado = new List<DFormatoSimple>();
            List<SAS_SegmentoRed> typeOfInterfaces = new List<SAS_SegmentoRed>();
            string cnx;
            cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Contexto = new SATURNODataContext(cnx))
            {
                listado.Add(new DFormatoSimple { Codigo = "1", Descripcion = "Usuario" });
                listado.Add(new DFormatoSimple { Codigo = "2", Descripcion = "Soporte" });
                listado.Add(new DFormatoSimple { Codigo = "3", Descripcion = "Administrador" });
            }
            return listado;
        }
        #endregion





    }
}
