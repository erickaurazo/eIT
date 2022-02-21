using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Asistencia.Datos;

namespace Asistencia.Negocios
{
    public class RegistroAbastecimientoController
    {


        public List<ListadoAcopioByTiktesResult> ObtenerListadoRecepcionEntrePeriodos(string conection, string desde, string hasta)
        {
            List<ListadoAcopioByTiktesResult> listado = new List<ListadoAcopioByTiktesResult>();

            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                listado = Modelo.ListadoAcopioByTiktes(desde, hasta).ToList();
            }

            return listado;
        }


        public RegistroAbastecimiento RegistrarTicket(string conection, RegistroAbastecimiento oRegistroAbastecimiento, List<RegistroAbastecimientoDetalle> listadoDetalle)
        {
            RegistroAbastecimiento oRegistro = new RegistroAbastecimiento();

            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {

                if (listadoDetalle != null && listadoDetalle.ToList().Count > 0)
                {
                    #region Grabar() 

                    if (oRegistroAbastecimiento != null)
                    {
                        if (oRegistroAbastecimiento.Idingresosalidaacopio != null && oRegistroAbastecimiento.item != null)
                        {
                            var oAbastecimiento = Modelo.RegistroAbastecimiento.Where(x =>
                            x.Idingresosalidaacopio == oRegistroAbastecimiento.Idingresosalidaacopio &&
                            x.item == oRegistroAbastecimiento.item &&
                            x.correlativo == oRegistroAbastecimiento.correlativo).ToList();

                            if (oAbastecimiento.Count == 0)
                            {
                                #region Nuevo()
                                RegistroAbastecimiento registro = new RegistroAbastecimiento();
                                //oAbastecimiento.correlativo = 0;
                                registro.Idingresosalidaacopio = oRegistroAbastecimiento.Idingresosalidaacopio.Trim();
                                registro.item = oRegistroAbastecimiento.item.Trim();
                                registro.fechaRegistro = oRegistroAbastecimiento.fechaRegistro;
                                registro.cantidad = oRegistroAbastecimiento.cantidad;
                                registro.hora = oRegistroAbastecimiento.hora;
                                registro.tipoRegistro = oRegistroAbastecimiento.tipoRegistro;
                                Modelo.RegistroAbastecimiento.InsertOnSubmit(registro);
                                Modelo.SubmitChanges();

                                oRegistro = registro;

                                foreach (var item in listadoDetalle)
                                {
                                    #region Registrar detalle()
                                    var detalleAsistencia = Modelo.RegistroAbastecimientoDetalle.Where(x => x.itemDetalle == item.itemDetalle).ToList();
                                    if (oAbastecimiento.Count == 0)
                                    {
                                        RegistroAbastecimientoDetalle det = new RegistroAbastecimientoDetalle();
                                        //det.itemDetalle = item.itemDetalle;
                                        det.correlativo = registro.correlativo;
                                        det.Idingresosalidaacopio = item.Idingresosalidaacopio;
                                        det.item = item.item;
                                        det.fechaRegistro = item.fechaRegistro;
                                        det.cantidad = item.cantidad;
                                        det.impreso = item.impreso;
                                        Modelo.RegistroAbastecimientoDetalle.InsertOnSubmit(det);
                                        Modelo.SubmitChanges();
                                    }
                                    else if (oAbastecimiento.Count == 1)
                                    {
                                        RegistroAbastecimientoDetalle det = new RegistroAbastecimientoDetalle();
                                        det = detalleAsistencia.Single();
                                        det.fechaRegistro = item.fechaRegistro;
                                        det.cantidad = item.cantidad;
                                        det.impreso = item.impreso;
                                        Modelo.SubmitChanges();
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                            else if (oAbastecimiento.Count == 1)
                            {
                                #region Modificar()
                                RegistroAbastecimiento registro = new RegistroAbastecimiento();
                                registro = oAbastecimiento.Single();
                                registro.fechaRegistro = oRegistroAbastecimiento.fechaRegistro;
                                registro.cantidad = oRegistroAbastecimiento.cantidad;
                                Modelo.SubmitChanges();

                                oRegistro = registro;

                                foreach (var item in listadoDetalle)
                                {
                                    #region Registrar detalle()
                                    var detalleAsistencia = Modelo.RegistroAbastecimientoDetalle.Where(x => x.itemDetalle == item.itemDetalle).ToList();
                                    if (detalleAsistencia.Count == 0)
                                    {
                                        RegistroAbastecimientoDetalle det = new RegistroAbastecimientoDetalle();
                                        //det.itemDetalle = item.itemDetalle;
                                        det.correlativo = item.correlativo;
                                        det.Idingresosalidaacopio = item.Idingresosalidaacopio;
                                        det.item = item.item;
                                        det.fechaRegistro = item.fechaRegistro;
                                        det.cantidad = item.cantidad;
                                        det.impreso = item.impreso;
                                        Modelo.RegistroAbastecimientoDetalle.InsertOnSubmit(det);
                                        Modelo.SubmitChanges();
                                    }
                                    else if (detalleAsistencia.Count == 1)
                                    {
                                        RegistroAbastecimientoDetalle det = new RegistroAbastecimientoDetalle();
                                        det = detalleAsistencia.Single();
                                        det.fechaRegistro = item.fechaRegistro;
                                        det.cantidad = item.cantidad;
                                        det.impreso = item.impreso;
                                        Modelo.SubmitChanges();
                                    }
                                    #endregion
                                }

                                #endregion
                            }

                        }
                    }
                    #endregion
                }
            }

            return oRegistro;
        }


        public int ObtenerCorrelativoDesdeIngresoAcopioPorItem(string conection, ListadoAcopioByTiktesResult oRegistroAbastecimiento)
        {            
            int CorrelativoTicketAbastecimiento = 0;

            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                if (oRegistroAbastecimiento != null)
                {
                    if (oRegistroAbastecimiento.IDINGRESOSALIDAACOPIOCAMPO != null)
                    {
                        if (oRegistroAbastecimiento.IDINGRESOSALIDAACOPIOCAMPO != "")
                        {
                            if (oRegistroAbastecimiento.item != null)
                            {
                                if (oRegistroAbastecimiento.item != string.Empty)
                                {
                                    var obtenerResultado = Modelo.RegistroAbastecimiento.Where(x => x.Idingresosalidaacopio == oRegistroAbastecimiento.IDINGRESOSALIDAACOPIOCAMPO && x.item == oRegistroAbastecimiento.item).ToList();
                                    if (obtenerResultado != null)
                                    {
                                        if (obtenerResultado.ToList().Count() == 1)
                                        {
                                            CorrelativoTicketAbastecimiento = obtenerResultado.FirstOrDefault().correlativo;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                


            }

            return CorrelativoTicketAbastecimiento;
        }


        public List<RegistroAbastecimientoDetalle> ObtenerDetalleTicketByCorrelativo(string conection, int correlativo)
        {

            List<RegistroAbastecimientoDetalle> listado = new List<RegistroAbastecimientoDetalle>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                listado = Modelo.RegistroAbastecimientoDetalle.Where(x => x.correlativo == correlativo).ToList();

            }

            return listado;
        }

    }
}
