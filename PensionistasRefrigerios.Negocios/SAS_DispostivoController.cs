using Asistencia.Datos;
using Asistencia.Negocios;
using MyControlsDataBinding.Busquedas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Transactions;

namespace Asistencia.Negocios
{
    public class SAS_DispostivoController
    {
        public Int32 Register(string Connection, SAS_Dispostivo device)
        {
            int codigo = 0;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[Connection].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                var resultado = Modelo.SAS_Dispostivo.Where(x => x.id == device.id).ToList();
                using (TransactionScope Scope = new TransactionScope())
                {
                    if (resultado.ToList().Count == 0)
                    {
                        #region Registrar() 
                        SAS_Dispostivo oDevice = new SAS_Dispostivo();
                        oDevice.nombres = device.nombres != null ? device.nombres.Trim() : string.Empty;
                        oDevice.descripcion = device.descripcion != null ? device.descripcion.Trim() : string.Empty;
                        oDevice.sedeCodigo = device.sedeCodigo != null ? device.sedeCodigo.Trim() : string.Empty;
                        oDevice.numeroSerie = device.numeroSerie != null ? device.numeroSerie.Trim() : string.Empty;
                        oDevice.caracteristicas = device.caracteristicas != null ? device.caracteristicas.Trim() : string.Empty;
                        oDevice.estado = 1;
                        oDevice.fechacreacion = DateTime.Now;
                        oDevice.creadoPor = Environment.MachineName.ToString() + " | " + Environment.UserName;
                        oDevice.activoCodigoERP = device.activoCodigoERP != null ? device.activoCodigoERP.Trim() : string.Empty;
                        oDevice.tipoDispositivoCodigo = device.tipoDispositivoCodigo != null ? device.tipoDispositivoCodigo.Trim() : string.Empty;


                        oDevice.IdDispostivoColor = device.IdDispostivoColor != null ? device.IdDispostivoColor.Trim() : string.Empty;
                        oDevice.idModelo = device.idModelo != null ? device.idModelo.Trim() : string.Empty;
                        oDevice.idMarca = device.idMarca != null ? device.idMarca.Trim() : string.Empty;
                        oDevice.numeroParte = device.numeroParte != null ? device.numeroParte.Trim() : string.Empty;
                        oDevice.IdEstadoProducto = device.IdEstadoProducto != null ? Convert.ToChar(device.IdEstadoProducto.ToString().Trim()) : 'X';
                        oDevice.EsPropio = device.EsPropio != null ? Convert.ToByte(device.EsPropio.Value) : Convert.ToByte(1);
                        oDevice.idProducto = device.idProducto != null ? device.idProducto.Trim() : string.Empty;
                        oDevice.rutaImagen = device.rutaImagen != null ? device.rutaImagen.Trim() : string.Empty;
                        oDevice.funcionamiento = device.funcionamiento != null ? device.funcionamiento.Value : 0;
                        oDevice.idClieprov = device.idClieprov != null ? device.idClieprov.Trim() : string.Empty;
                        oDevice.coordenada = device.coordenada != null ? device.coordenada.Trim() : string.Empty;
                        oDevice.fechaActivacion = device.fechaActivacion != null ? device.fechaActivacion.Value : (DateTime?)null;
                        oDevice.idCobrarpagarDoc = device.idCobrarpagarDoc != null ? device.idCobrarpagarDoc.Trim() : string.Empty;
                        oDevice.fechaBaja = device.fechaBaja != null ? device.fechaBaja.Value : (DateTime?)null;
                        oDevice.fechaProduccion = device.fechaProduccion != null ? device.fechaProduccion.Value : (DateTime?)null;
                        oDevice.esFinal = device.esFinal != null ? device.esFinal.Value : 0;


                        Modelo.SAS_Dispostivo.InsertOnSubmit(oDevice);
                        Modelo.SubmitChanges();
                        codigo = oDevice.id;
                        #endregion
                    }
                    else if (resultado.ToList().Count == 1)
                    {
                        #region Editar() 
                        SAS_Dispostivo oDevice = new SAS_Dispostivo();
                        oDevice = resultado.Single();
                        oDevice.nombres = device.nombres != null ? device.nombres.Trim() : string.Empty;
                        oDevice.descripcion = device.descripcion != null ? device.descripcion.Trim() : string.Empty;
                        oDevice.sedeCodigo = device.sedeCodigo != null ? device.sedeCodigo.Trim() : string.Empty;
                        oDevice.numeroSerie = device.numeroSerie != null ? device.numeroSerie.Trim() : string.Empty;
                        oDevice.caracteristicas = device.caracteristicas != null ? device.caracteristicas.Trim() : string.Empty;
                        oDevice.activoCodigoERP = device.activoCodigoERP != null ? device.activoCodigoERP.Trim() : string.Empty;
                        oDevice.tipoDispositivoCodigo = device.tipoDispositivoCodigo != null ? device.tipoDispositivoCodigo.Trim() : string.Empty;
                        oDevice.IdDispostivoColor = device.IdDispostivoColor != null ? device.IdDispostivoColor.Trim() : string.Empty;
                        oDevice.idModelo = device.idModelo != null ? device.idModelo.Trim() : string.Empty;
                        oDevice.idMarca = device.idMarca != null ? device.idMarca.Trim() : string.Empty;
                        oDevice.numeroParte = device.numeroParte != null ? device.numeroParte.Trim() : string.Empty;
                        oDevice.IdEstadoProducto = device.IdEstadoProducto != null ? Convert.ToChar(device.IdEstadoProducto.ToString().Trim()) : 'X';
                        oDevice.EsPropio = device.EsPropio != null ? Convert.ToByte(device.EsPropio.Value) : Convert.ToByte(1);
                        oDevice.idProducto = device.idProducto != null ? device.idProducto.Trim() : string.Empty;
                        oDevice.rutaImagen = device.rutaImagen != null ? device.rutaImagen.Trim() : string.Empty;
                        oDevice.funcionamiento = device.funcionamiento != null ? device.funcionamiento.Value : 0;
                        oDevice.idClieprov = device.idClieprov != null ? device.idClieprov.Trim() : string.Empty;
                        oDevice.coordenada = device.coordenada != null ? device.coordenada.Trim() : string.Empty;
                        oDevice.fechaActivacion = device.fechaActivacion != null ? device.fechaActivacion.Value : (DateTime?)null;
                        oDevice.idCobrarpagarDoc = device.idCobrarpagarDoc != null ? device.idCobrarpagarDoc.Trim() : string.Empty;
                        oDevice.fechaBaja = device.fechaBaja != null ? device.fechaBaja.Value : (DateTime?)null;
                        oDevice.fechaProduccion = device.fechaProduccion != null ? device.fechaProduccion.Value : (DateTime?)null;
                        oDevice.esFinal = device.esFinal != null ? device.esFinal.Value : 0;


                        Modelo.SubmitChanges();
                        codigo = oDevice.id;
                        #endregion
                    }
                    Scope.Complete();
                }
            }
            return codigo;
        }


        // Registrar con listado detalle de ips eliminados y nuevos 
        public Int32 Register(string Connection, SAS_Dispostivo device, List<SAS_DispositivoIP> listOfDeletedIPs, List<SAS_DispositivoIP> listOfIPs)
        {
            int codigo = 0;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[Connection].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                var resultado = Modelo.SAS_Dispostivo.Where(x => x.id == device.id).ToList();
                using (TransactionScope Scope = new TransactionScope())
                {
                    if (resultado.ToList().Count == 0)
                    {
                        #region Registrar() 
                        SAS_Dispostivo oDevice = new SAS_Dispostivo();
                        oDevice.nombres = device.nombres != null ? device.nombres.Trim() : string.Empty;
                        oDevice.descripcion = device.descripcion != null ? device.descripcion.Trim() : string.Empty;
                        oDevice.sedeCodigo = device.sedeCodigo != null ? device.sedeCodigo.Trim() : string.Empty;
                        oDevice.numeroSerie = device.numeroSerie != null ? device.numeroSerie.Trim() : string.Empty;
                        oDevice.caracteristicas = device.caracteristicas != null ? device.caracteristicas.Trim() : string.Empty;
                        oDevice.estado = 1;
                        oDevice.fechacreacion = DateTime.Now;
                        oDevice.creadoPor = Environment.MachineName.ToString() + " | " + Environment.UserName;
                        oDevice.activoCodigoERP = device.activoCodigoERP != null ? device.activoCodigoERP.Trim() : string.Empty;
                        oDevice.tipoDispositivoCodigo = device.tipoDispositivoCodigo != null ? device.tipoDispositivoCodigo.Trim() : string.Empty;


                        oDevice.IdDispostivoColor = device.IdDispostivoColor != null ? device.IdDispostivoColor.Trim() : string.Empty;
                        oDevice.idModelo = device.idModelo != null ? device.idModelo.Trim() : string.Empty;
                        oDevice.idMarca = device.idMarca != null ? device.idMarca.Trim() : string.Empty;
                        oDevice.numeroParte = device.numeroParte != null ? device.numeroParte.Trim() : string.Empty;
                        oDevice.IdEstadoProducto = device.IdEstadoProducto != null ? Convert.ToChar(device.IdEstadoProducto.ToString().Trim()) : 'X';
                        oDevice.EsPropio = device.EsPropio != null ? Convert.ToByte(device.EsPropio.Value) : Convert.ToByte(1);
                        oDevice.idProducto = device.idProducto != null ? device.idProducto.Trim() : string.Empty;
                        oDevice.rutaImagen = device.rutaImagen != null ? device.rutaImagen.Trim() : string.Empty;
                        oDevice.funcionamiento = device.funcionamiento != null ? device.funcionamiento.Value : 0;
                        oDevice.idClieprov = device.idClieprov != null ? device.idClieprov.Trim() : string.Empty;
                        oDevice.coordenada = device.coordenada != null ? device.coordenada.Trim() : string.Empty;
                        oDevice.fechaActivacion = device.fechaActivacion != null ? device.fechaActivacion.Value : (DateTime?)null;
                        oDevice.idCobrarpagarDoc = device.idCobrarpagarDoc != null ? device.idCobrarpagarDoc.Trim() : string.Empty;
                        oDevice.fechaBaja = device.fechaBaja != null ? device.fechaBaja.Value : (DateTime?)null;
                        oDevice.fechaProduccion = device.fechaProduccion != null ? device.fechaProduccion.Value : (DateTime?)null;
                        oDevice.esFinal = device.esFinal != null ? device.esFinal.Value : 0;


                        Modelo.SAS_Dispostivo.InsertOnSubmit(oDevice);
                        Modelo.SubmitChanges();
                        codigo = oDevice.id;

                        if (listOfIPs != null)
                        {
                            if (listOfIPs.Count > 0)
                            {
                                #region Registrar listado detalle de IPs. 

                                foreach (var detalle in listOfIPs)
                                {
                                    var result1 = Modelo.SAS_DispositivoIP.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp.dispositivoCodigo = codigo;
                                            oIp.item = detalle.item;
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            oIp.fechaCreacion = DateTime.Now;
                                            oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SAS_DispositivoIP.InsertOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp = result1.Single();
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            //oIp.fechaCreacion = DateTime.Now;
                                            //oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                }

                                #endregion
                            }
                        }


                        #endregion
                    }
                    else if (resultado.ToList().Count == 1)
                    {
                        #region Editar() 
                        SAS_Dispostivo oDevice = new SAS_Dispostivo();
                        oDevice = resultado.Single();
                        oDevice.nombres = device.nombres != null ? device.nombres.Trim() : string.Empty;
                        oDevice.descripcion = device.descripcion != null ? device.descripcion.Trim() : string.Empty;
                        oDevice.sedeCodigo = device.sedeCodigo != null ? device.sedeCodigo.Trim() : string.Empty;
                        oDevice.numeroSerie = device.numeroSerie != null ? device.numeroSerie.Trim() : string.Empty;
                        oDevice.caracteristicas = device.caracteristicas != null ? device.caracteristicas.Trim() : string.Empty;
                        oDevice.activoCodigoERP = device.activoCodigoERP != null ? device.activoCodigoERP.Trim() : string.Empty;
                        oDevice.tipoDispositivoCodigo = device.tipoDispositivoCodigo != null ? device.tipoDispositivoCodigo.Trim() : string.Empty;
                        oDevice.IdDispostivoColor = device.IdDispostivoColor != null ? device.IdDispostivoColor.Trim() : string.Empty;
                        oDevice.idModelo = device.idModelo != null ? device.idModelo.Trim() : string.Empty;
                        oDevice.idMarca = device.idMarca != null ? device.idMarca.Trim() : string.Empty;
                        oDevice.numeroParte = device.numeroParte != null ? device.numeroParte.Trim() : string.Empty;
                        oDevice.IdEstadoProducto = device.IdEstadoProducto != null ? Convert.ToChar(device.IdEstadoProducto.ToString().Trim()) : Convert.ToChar('X');
                        oDevice.EsPropio = device.EsPropio != null ? Convert.ToByte(device.EsPropio.Value) : Convert.ToByte(1);
                        oDevice.idProducto = device.idProducto != null ? device.idProducto.Trim() : string.Empty;
                        oDevice.rutaImagen = device.rutaImagen != null ? device.rutaImagen.Trim() : string.Empty;
                        oDevice.funcionamiento = device.funcionamiento != null ? device.funcionamiento.Value : 0;
                        oDevice.idClieprov = device.idClieprov != null ? device.idClieprov.Trim() : string.Empty;
                        oDevice.coordenada = device.coordenada != null ? device.coordenada.Trim() : string.Empty;
                        oDevice.fechaActivacion = device.fechaActivacion != null ? device.fechaActivacion.Value : (DateTime?)null;
                        oDevice.idCobrarpagarDoc = device.idCobrarpagarDoc != null ? device.idCobrarpagarDoc.Trim() : string.Empty;
                        oDevice.fechaBaja = device.fechaBaja != null ? device.fechaBaja.Value : (DateTime?)null;
                        oDevice.fechaProduccion = device.fechaProduccion != null ? device.fechaProduccion.Value : (DateTime?)null;
                        oDevice.esFinal = device.esFinal != null ? device.esFinal.Value : 0;
                        Modelo.SubmitChanges();
                        codigo = oDevice.id;

                        // Eliminar lista de eliminados de los ips por device.
                        if (listOfDeletedIPs != null)
                        {
                            if (listOfDeletedIPs.Count > 0)
                            {
                                foreach (var detalle in listOfDeletedIPs)
                                {
                                    var result1 = Modelo.SAS_DispositivoIP.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 1)
                                        {
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp = result1.Single();
                                            Modelo.SAS_DispositivoIP.DeleteOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                            }
                        }

                        if (listOfIPs != null)
                        {
                            if (listOfIPs.Count > 0)
                            {
                                #region Registrar listado detalle de IPs. 
                                foreach (var detalle in listOfIPs)
                                {
                                    var result1 = Modelo.SAS_DispositivoIP.Where(x => x.dispositivoCodigo == codigo && x.item.Trim() == detalle.item.Trim()).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp.dispositivoCodigo = codigo;
                                            oIp.item = detalle.item;
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            oIp.fechaCreacion = DateTime.Now;
                                            oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SAS_DispositivoIP.InsertOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp = result1.Single();
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            //oIp.fechaCreacion = DateTime.Now;
                                            //oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                }

                                #endregion
                            }
                        }



                        #endregion
                    }
                    Scope.Complete();
                }
            }
            return codigo;
        }

        // Registrar con listado detalle de ips eliminados y nuevos 
        // Registrar con listado detalle de ips eliminados y nuevos , listado de usuarios nuevos y eliminados
        public int Register(string Connection, SAS_Dispostivo device, List<SAS_DispositivoIP> listOfDeletedIPs, List<SAS_DispositivoIP> listOfIPs, List<SAS_DispositivoUsuarios> listadoColaboradoresEliminados, List<SAS_DispositivoUsuarios> listadoColaboradores)
        {
            int codigo = 0;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[Connection].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                var resultado = Modelo.SAS_Dispostivo.Where(x => x.id == device.id).ToList();
                using (TransactionScope Scope = new TransactionScope())
                {
                    if (resultado.ToList().Count == 0)
                    {
                        #region Registrar() 
                        SAS_Dispostivo oDevice = new SAS_Dispostivo();
                        oDevice.nombres = device.nombres != null ? device.nombres.Trim() : string.Empty;
                        oDevice.descripcion = device.descripcion != null ? device.descripcion.Trim() : string.Empty;
                        oDevice.sedeCodigo = device.sedeCodigo != null ? device.sedeCodigo.Trim() : string.Empty;
                        oDevice.numeroSerie = device.numeroSerie != null ? device.numeroSerie.Trim() : string.Empty;
                        oDevice.caracteristicas = device.caracteristicas != null ? device.caracteristicas.Trim() : string.Empty;
                        oDevice.estado = 1;
                        oDevice.fechacreacion = DateTime.Now;
                        oDevice.creadoPor = Environment.MachineName.ToString() + " | " + Environment.UserName;
                        oDevice.activoCodigoERP = device.activoCodigoERP != null ? device.activoCodigoERP.Trim() : string.Empty;
                        oDevice.tipoDispositivoCodigo = device.tipoDispositivoCodigo != null ? device.tipoDispositivoCodigo.Trim() : string.Empty;
                        oDevice.IdDispostivoColor = device.IdDispostivoColor != null ? device.IdDispostivoColor.Trim() : string.Empty;
                        oDevice.idModelo = device.idModelo != null ? device.idModelo.Trim() : string.Empty;
                        oDevice.idMarca = device.idMarca != null ? device.idMarca.Trim() : string.Empty;
                        oDevice.numeroParte = device.numeroParte != null ? device.numeroParte.Trim() : string.Empty;
                        oDevice.IdEstadoProducto = device.IdEstadoProducto != null ? Convert.ToChar(device.IdEstadoProducto.ToString().Trim()) : 'X';
                        oDevice.EsPropio = device.EsPropio != null ? Convert.ToByte(device.EsPropio.Value) : Convert.ToByte(1);
                        oDevice.idProducto = device.idProducto != null ? device.idProducto.Trim() : string.Empty;
                        oDevice.rutaImagen = device.rutaImagen != null ? device.rutaImagen.Trim() : string.Empty;
                        oDevice.funcionamiento = device.funcionamiento != null ? device.funcionamiento.Value : 0;
                        oDevice.idClieprov = device.idClieprov != null ? device.idClieprov.Trim() : string.Empty;
                        oDevice.coordenada = device.coordenada != null ? device.coordenada.Trim() : string.Empty;
                        oDevice.fechaActivacion = device.fechaActivacion != null ? device.fechaActivacion.Value : (DateTime?)null;
                        oDevice.idCobrarpagarDoc = device.idCobrarpagarDoc != null ? device.idCobrarpagarDoc.Trim() : string.Empty;
                        oDevice.fechaBaja = device.fechaBaja != null ? device.fechaBaja.Value : (DateTime?)null;
                        oDevice.fechaProduccion = device.fechaProduccion != null ? device.fechaProduccion.Value : (DateTime?)null;
                        oDevice.esFinal = device.esFinal != null ? device.esFinal.Value : 0;

                        Modelo.SAS_Dispostivo.InsertOnSubmit(oDevice);
                        Modelo.SubmitChanges();
                        codigo = oDevice.id;

                        //registrar Número de IP
                        if (listOfIPs != null)
                        {
                            if (listOfIPs.Count > 0)
                            {
                                #region Registrar listado detalle de IPs. 

                                foreach (var detalle in listOfIPs)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoIP.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp.dispositivoCodigo = codigo;
                                            oIp.item = detalle.item;
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            oIp.fechaCreacion = DateTime.Now;
                                            oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SAS_DispositivoIP.InsertOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp = result1.Single();
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            //oIp.fechaCreacion = DateTime.Now;
                                            //oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }

                        //registrar Colaboradores
                        if (listadoColaboradores != null)
                        {
                            if (listadoColaboradores.Count > 0)
                            {
                                #region Registrar listado detalle de IPs. 

                                foreach (var detalle in listadoColaboradores)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoUsuarios.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoUsuarios oIp = new SAS_DispositivoUsuarios();
                                            oIp.dispositivoCodigo = codigo;
                                            oIp.item = detalle.item;
                                            oIp.estado = detalle.estado;
                                            oIp.idcodigoGeneral = detalle.idcodigoGeneral;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            oIp.fechaCreacion = DateTime.Now;
                                            oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            Modelo.SAS_DispositivoUsuarios.InsertOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoUsuarios oIp = new SAS_DispositivoUsuarios();
                                            oIp = result1.Single();
                                            oIp.estado = detalle.estado;
                                            oIp.idcodigoGeneral = detalle.idcodigoGeneral;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            //oIp.fechaCreacion = DateTime.Now;
                                            //oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }


                        #endregion
                    }
                    else if (resultado.ToList().Count == 1)
                    {
                        #region Editar() 
                        SAS_Dispostivo oDevice = new SAS_Dispostivo();
                        oDevice = resultado.Single();
                        oDevice.nombres = device.nombres != null ? device.nombres.Trim() : string.Empty;
                        oDevice.descripcion = device.descripcion != null ? device.descripcion.Trim() : string.Empty;
                        oDevice.sedeCodigo = device.sedeCodigo != null ? device.sedeCodigo.Trim() : string.Empty;
                        oDevice.numeroSerie = device.numeroSerie != null ? device.numeroSerie.Trim() : string.Empty;
                        oDevice.caracteristicas = device.caracteristicas != null ? device.caracteristicas.Trim() : string.Empty;
                        oDevice.activoCodigoERP = device.activoCodigoERP != null ? device.activoCodigoERP.Trim() : string.Empty;
                        oDevice.tipoDispositivoCodigo = device.tipoDispositivoCodigo != null ? device.tipoDispositivoCodigo.Trim() : string.Empty;
                        oDevice.IdDispostivoColor = device.IdDispostivoColor != null ? device.IdDispostivoColor.Trim() : string.Empty;
                        oDevice.idModelo = device.idModelo != null ? device.idModelo.Trim() : string.Empty;
                        oDevice.idMarca = device.idMarca != null ? device.idMarca.Trim() : string.Empty;
                        oDevice.numeroParte = device.numeroParte != null ? device.numeroParte.Trim() : string.Empty;
                        oDevice.IdEstadoProducto = device.IdEstadoProducto != null ? Convert.ToChar(device.IdEstadoProducto.ToString().Trim()) : Convert.ToChar('X');
                        oDevice.EsPropio = device.EsPropio != null ? Convert.ToByte(device.EsPropio.Value) : Convert.ToByte(1);
                        oDevice.idProducto = device.idProducto != null ? device.idProducto.Trim() : string.Empty;
                        oDevice.rutaImagen = device.rutaImagen != null ? device.rutaImagen.Trim() : string.Empty;
                        oDevice.funcionamiento = device.funcionamiento != null ? device.funcionamiento.Value : 0;
                        oDevice.idClieprov = device.idClieprov != null ? device.idClieprov.Trim() : string.Empty;
                        oDevice.coordenada = device.coordenada != null ? device.coordenada.Trim() : string.Empty;
                        oDevice.fechaActivacion = device.fechaActivacion != null ? device.fechaActivacion.Value : (DateTime?)null;
                        oDevice.idCobrarpagarDoc = device.idCobrarpagarDoc != null ? device.idCobrarpagarDoc.Trim() : string.Empty;
                        oDevice.fechaBaja = device.fechaBaja != null ? device.fechaBaja.Value : (DateTime?)null;
                        oDevice.fechaProduccion = device.fechaProduccion != null ? device.fechaProduccion.Value : (DateTime?)null;
                        oDevice.esFinal = device.esFinal != null ? device.esFinal.Value : 0;
                        Modelo.SubmitChanges();
                        codigo = oDevice.id;

                        // Eliminar lista de eliminados de los ips por device.
                        if (listOfDeletedIPs != null)
                        {
                            #region Eliminar lista de Ip para eliminar() 
                            if (listOfDeletedIPs.Count > 0)
                            {
                                foreach (var detalle in listOfDeletedIPs)
                                {
                                    var result1 = Modelo.SAS_DispositivoIP.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 1)
                                        {
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp = result1.Single();
                                            Modelo.SAS_DispositivoIP.DeleteOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                            }
                            #endregion
                        }


                        // Eliminar lista de eliminados de USER  POR device.
                        if (listadoColaboradoresEliminados != null)
                        {
                            #region Eliminar lista de Ip para eliminar() 
                            if (listadoColaboradoresEliminados.Count > 0)
                            {
                                foreach (var detalle in listadoColaboradoresEliminados)
                                {
                                    var result1 = Modelo.SAS_DispositivoUsuarios.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 1)
                                        {
                                            SAS_DispositivoUsuarios oDetalle = new SAS_DispositivoUsuarios();
                                            oDetalle = result1.Single();
                                            Modelo.SAS_DispositivoUsuarios.DeleteOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                            }
                            #endregion
                        }


                        // Modificar y registrar listado de Ip
                        if (listOfIPs != null)
                        {
                            #region Editar y registrar listado de IP                            
                            if (listOfIPs.Count > 0)
                            {
                                #region Registrar listado detalle de IPs. 
                                foreach (var detalle in listOfIPs)
                                {
                                    var result1 = Modelo.SAS_DispositivoIP.Where(x => x.dispositivoCodigo == codigo && x.item.Trim() == detalle.item.Trim()).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp.dispositivoCodigo = codigo;
                                            oIp.item = detalle.item;
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            oIp.fechaCreacion = DateTime.Now;
                                            oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SAS_DispositivoIP.InsertOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp = result1.Single();
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            //oIp.fechaCreacion = DateTime.Now;
                                            //oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                }

                                #endregion
                            }
                            #endregion
                        }

                        // Modificar y registrar listado de usuarios
                        if (listadoColaboradores != null)
                        {
                            if (listadoColaboradores.Count > 0)
                            {
                                #region Registrar listado detalle de IPs. 

                                foreach (var detalle in listadoColaboradores)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoUsuarios.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoUsuarios oIp = new SAS_DispositivoUsuarios();
                                            oIp.dispositivoCodigo = codigo;
                                            oIp.item = detalle.item;
                                            oIp.estado = detalle.estado;
                                            oIp.idcodigoGeneral = detalle.idcodigoGeneral;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            oIp.fechaCreacion = DateTime.Now;
                                            oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            Modelo.SAS_DispositivoUsuarios.InsertOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoUsuarios oIp = new SAS_DispositivoUsuarios();
                                            oIp = result1.Single();
                                            oIp.estado = detalle.estado;
                                            oIp.idcodigoGeneral = detalle.idcodigoGeneral;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            //oIp.fechaCreacion = DateTime.Now;
                                            //oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }





                        #endregion
                    }
                    Scope.Complete();
                }
            }
            return codigo;
        }

        public int Register(string Connection, SAS_Dispostivo device, List<SAS_DispositivoIP> listOfDeletedIPs, List<SAS_DispositivoIP> listOfIPs, List<SAS_DispositivoUsuarios> listadoColaboradoresEliminados, List<SAS_DispositivoUsuarios> listadoColaboradores, List<SAS_DispositivoHardware> listadoHardwareEliminados, List<SAS_DispositivoHardware> listadoHardware, List<SAS_DispositivoSoftware> listadoSoftwareEliminados, List<SAS_DispositivoSoftware> listadoSoftware)
        {
            int codigo = 0;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[Connection].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                var resultado = Modelo.SAS_Dispostivo.Where(x => x.id == device.id).ToList();
                using (TransactionScope Scope = new TransactionScope())
                {
                    if (resultado.ToList().Count == 0)
                    {
                        #region Registrar() 
                        SAS_Dispostivo oDevice = new SAS_Dispostivo();
                        oDevice.nombres = device.nombres != null ? device.nombres.Trim() : string.Empty;
                        oDevice.descripcion = device.descripcion != null ? device.descripcion.Trim() : string.Empty;
                        oDevice.sedeCodigo = device.sedeCodigo != null ? device.sedeCodigo.Trim() : string.Empty;
                        oDevice.numeroSerie = device.numeroSerie != null ? device.numeroSerie.Trim() : string.Empty;
                        oDevice.caracteristicas = device.caracteristicas != null ? device.caracteristicas.Trim() : string.Empty;
                        oDevice.estado = 1;
                        oDevice.fechacreacion = DateTime.Now;
                        oDevice.creadoPor = Environment.MachineName.ToString() + " | " + Environment.UserName;
                        oDevice.activoCodigoERP = device.activoCodigoERP != null ? device.activoCodigoERP.Trim() : string.Empty;
                        oDevice.tipoDispositivoCodigo = device.tipoDispositivoCodigo != null ? device.tipoDispositivoCodigo.Trim() : string.Empty;
                        oDevice.IdDispostivoColor = device.IdDispostivoColor != null ? device.IdDispostivoColor.Trim() : string.Empty;
                        oDevice.idModelo = device.idModelo != null ? device.idModelo.Trim() : string.Empty;
                        oDevice.idMarca = device.idMarca != null ? device.idMarca.Trim() : string.Empty;
                        oDevice.numeroParte = device.numeroParte != null ? device.numeroParte.Trim() : string.Empty;
                        oDevice.IdEstadoProducto = device.IdEstadoProducto != null ? Convert.ToChar(device.IdEstadoProducto.ToString().Trim()) : 'X';
                        oDevice.EsPropio = device.EsPropio != null ? Convert.ToByte(device.EsPropio.Value) : Convert.ToByte(1);
                        oDevice.idProducto = device.idProducto != null ? device.idProducto.Trim() : string.Empty;
                        oDevice.rutaImagen = device.rutaImagen != null ? device.rutaImagen.Trim() : string.Empty;
                        oDevice.funcionamiento = device.funcionamiento != null ? device.funcionamiento.Value : 0;
                        oDevice.idClieprov = device.idClieprov != null ? device.idClieprov.Trim() : string.Empty;
                        oDevice.coordenada = device.coordenada != null ? device.coordenada.Trim() : string.Empty;
                        oDevice.fechaActivacion = device.fechaActivacion != null ? device.fechaActivacion.Value : (DateTime?)null;
                        oDevice.idCobrarpagarDoc = device.idCobrarpagarDoc != null ? device.idCobrarpagarDoc.Trim() : string.Empty;
                        oDevice.fechaBaja = device.fechaBaja != null ? device.fechaBaja.Value : (DateTime?)null;
                        oDevice.fechaProduccion = device.fechaProduccion != null ? device.fechaProduccion.Value : (DateTime?)null;
                        oDevice.esFinal = device.esFinal != null ? device.esFinal.Value : 0;

                        Modelo.SAS_Dispostivo.InsertOnSubmit(oDevice);
                        Modelo.SubmitChanges();
                        codigo = oDevice.id;

                        //registrar Número de IP
                        if (listOfIPs != null)
                        {
                            if (listOfIPs.Count > 0)
                            {
                                #region Registrar listado detalle de IPs. 

                                foreach (var detalle in listOfIPs)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoIP.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp.dispositivoCodigo = codigo;
                                            oIp.item = detalle.item;
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            oIp.fechaCreacion = DateTime.Now;
                                            oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SAS_DispositivoIP.InsertOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp = result1.Single();
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            //oIp.fechaCreacion = DateTime.Now;
                                            //oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }

                        //registrar Colaboradores
                        if (listadoColaboradores != null)
                        {
                            if (listadoColaboradores.Count > 0)
                            {
                                #region Registrar listado detalle de IPs. 

                                foreach (var detalle in listadoColaboradores)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoUsuarios.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoUsuarios oIp = new SAS_DispositivoUsuarios();
                                            oIp.dispositivoCodigo = codigo;
                                            oIp.item = detalle.item;
                                            oIp.estado = detalle.estado;
                                            oIp.idcodigoGeneral = detalle.idcodigoGeneral;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            oIp.fechaCreacion = DateTime.Now;
                                            oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            Modelo.SAS_DispositivoUsuarios.InsertOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoUsuarios oIp = new SAS_DispositivoUsuarios();
                                            oIp = result1.Single();
                                            oIp.estado = detalle.estado;
                                            oIp.idcodigoGeneral = detalle.idcodigoGeneral;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            //oIp.fechaCreacion = DateTime.Now;
                                            //oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }


                        //registrar Hardware
                        if (listadoHardware != null)
                        {
                            if (listadoHardware.Count > 0)
                            {
                                #region Registrar listado detalle Hardware()  

                                foreach (var detalle in listadoHardware)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoHardware.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoHardware oDetalle = new SAS_DispositivoHardware();
                                            oDetalle.codigoDispositivo = codigo;
                                            oDetalle.item = detalle.item;
                                            oDetalle.codigoHardware = detalle.codigoHardware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.capacidad = detalle.capacidad;
                                            oDetalle.unidadMedidaCapacidad = detalle.unidadMedidaCapacidad;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            Modelo.SAS_DispositivoHardware.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoHardware oDetalle = new SAS_DispositivoHardware();
                                            oDetalle = result1.Single();
                                            oDetalle.codigoHardware = detalle.codigoHardware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.capacidad = detalle.capacidad;
                                            oDetalle.unidadMedidaCapacidad = detalle.unidadMedidaCapacidad;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }


                        //registrar Software
                        if (listadoSoftware != null)
                        {
                            if (listadoSoftware.Count > 0)
                            {
                                #region Registrar listado detalle de Software() 

                                foreach (var detalle in listadoSoftware)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoSoftware.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoSoftware oDetalle = new SAS_DispositivoSoftware();
                                            oDetalle.codigoDispositivo = codigo;
                                            oDetalle.item = detalle.item;
                                            oDetalle.codigoSoftware = detalle.codigoSoftware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.version = detalle.version;
                                            oDetalle.informacionAdicional = detalle.informacionAdicional;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            Modelo.SAS_DispositivoSoftware.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoSoftware oDetalle = new SAS_DispositivoSoftware();
                                            oDetalle = result1.Single();
                                            oDetalle.codigoSoftware = detalle.codigoSoftware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.version = detalle.version;
                                            oDetalle.informacionAdicional = detalle.informacionAdicional;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }


                        #endregion
                    }
                    else if (resultado.ToList().Count == 1)
                    {
                        #region Editar() 
                        SAS_Dispostivo oDevice = new SAS_Dispostivo();
                        oDevice = resultado.Single();
                        oDevice.nombres = device.nombres != null ? device.nombres.Trim() : string.Empty;
                        oDevice.descripcion = device.descripcion != null ? device.descripcion.Trim() : string.Empty;
                        oDevice.sedeCodigo = device.sedeCodigo != null ? device.sedeCodigo.Trim() : string.Empty;
                        oDevice.numeroSerie = device.numeroSerie != null ? device.numeroSerie.Trim() : string.Empty;
                        oDevice.caracteristicas = device.caracteristicas != null ? device.caracteristicas.Trim() : string.Empty;
                        oDevice.activoCodigoERP = device.activoCodigoERP != null ? device.activoCodigoERP.Trim() : string.Empty;
                        oDevice.tipoDispositivoCodigo = device.tipoDispositivoCodigo != null ? device.tipoDispositivoCodigo.Trim() : string.Empty;
                        oDevice.IdDispostivoColor = device.IdDispostivoColor != null ? device.IdDispostivoColor.Trim() : string.Empty;
                        oDevice.idModelo = device.idModelo != null ? device.idModelo.Trim() : string.Empty;
                        oDevice.idMarca = device.idMarca != null ? device.idMarca.Trim() : string.Empty;
                        oDevice.numeroParte = device.numeroParte != null ? device.numeroParte.Trim() : string.Empty;
                        oDevice.IdEstadoProducto = device.IdEstadoProducto != null ? Convert.ToChar(device.IdEstadoProducto.ToString().Trim()) : Convert.ToChar('X');
                        oDevice.EsPropio = device.EsPropio != null ? Convert.ToByte(device.EsPropio.Value) : Convert.ToByte(1);
                        oDevice.idProducto = device.idProducto != null ? device.idProducto.Trim() : string.Empty;
                        oDevice.rutaImagen = device.rutaImagen != null ? device.rutaImagen.Trim() : string.Empty;
                        oDevice.funcionamiento = device.funcionamiento != null ? device.funcionamiento.Value : 0;
                        oDevice.idClieprov = device.idClieprov != null ? device.idClieprov.Trim() : string.Empty;
                        oDevice.coordenada = device.coordenada != null ? device.coordenada.Trim() : string.Empty;
                        oDevice.fechaActivacion = device.fechaActivacion != null ? device.fechaActivacion.Value : (DateTime?)null;
                        oDevice.idCobrarpagarDoc = device.idCobrarpagarDoc != null ? device.idCobrarpagarDoc.Trim() : string.Empty;
                        oDevice.fechaBaja = device.fechaBaja != null ? device.fechaBaja.Value : (DateTime?)null;
                        oDevice.fechaProduccion = device.fechaProduccion != null ? device.fechaProduccion.Value : (DateTime?)null;
                        oDevice.esFinal = device.esFinal != null ? device.esFinal.Value : 0;
                        Modelo.SubmitChanges();
                        codigo = oDevice.id;

                        // Eliminar lista de eliminados de los ips por device.
                        if (listOfDeletedIPs != null)
                        {
                            #region Eliminar lista de Ip para eliminar() 
                            if (listOfDeletedIPs.Count > 0)
                            {
                                foreach (var detalle in listOfDeletedIPs)
                                {
                                    var result1 = Modelo.SAS_DispositivoIP.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 1)
                                        {
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp = result1.Single();
                                            Modelo.SAS_DispositivoIP.DeleteOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                            }
                            #endregion
                        }


                        // Eliminar lista de eliminados de USER  POR device.
                        if (listadoColaboradoresEliminados != null)
                        {
                            #region Eliminar lista de Ip para eliminar() 
                            if (listadoColaboradoresEliminados.Count > 0)
                            {
                                foreach (var detalle in listadoColaboradoresEliminados)
                                {
                                    var result1 = Modelo.SAS_DispositivoUsuarios.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 1)
                                        {
                                            SAS_DispositivoUsuarios oDetalle = new SAS_DispositivoUsuarios();
                                            oDetalle = result1.Single();
                                            Modelo.SAS_DispositivoUsuarios.DeleteOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                            }
                            #endregion
                        }

                        // Eliminar lista de eliminados de hardware.
                        if (listadoHardwareEliminados != null)
                        {
                            #region Eliminar lista de Ip para eliminar() 
                            if (listadoHardwareEliminados.Count > 0)
                            {
                                foreach (var detalle in listadoHardwareEliminados)
                                {
                                    var result1 = Modelo.SAS_DispositivoHardware.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 1)
                                        {
                                            SAS_DispositivoHardware oDetalle = new SAS_DispositivoHardware();
                                            oDetalle = result1.Single();
                                            Modelo.SAS_DispositivoHardware.DeleteOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                            }
                            #endregion
                        }

                        // Eliminar lista de eliminados de software.
                        if (listadoSoftwareEliminados != null)
                        {
                            #region Eliminar lista de Ip para eliminar() 
                            if (listadoSoftwareEliminados.Count > 0)
                            {
                                foreach (var detalle in listadoSoftwareEliminados)
                                {
                                    var result1 = Modelo.SAS_DispositivoSoftware.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 1)
                                        {
                                            SAS_DispositivoSoftware oDetalle = new SAS_DispositivoSoftware();
                                            oDetalle = result1.Single();
                                            Modelo.SAS_DispositivoSoftware.DeleteOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                            }
                            #endregion
                        }


                        // Modificar y registrar listado de Ip
                        if (listOfIPs != null)
                        {
                            #region Editar y registrar listado de IP                            
                            if (listOfIPs.Count > 0)
                            {
                                #region Registrar listado detalle de IPs. 
                                foreach (var detalle in listOfIPs)
                                {
                                    var result1 = Modelo.SAS_DispositivoIP.Where(x => x.dispositivoCodigo == codigo && x.item.Trim() == detalle.item.Trim()).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp.dispositivoCodigo = codigo;
                                            oIp.item = detalle.item;
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            oIp.fechaCreacion = DateTime.Now;
                                            oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SAS_DispositivoIP.InsertOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp = result1.Single();
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            //oIp.fechaCreacion = DateTime.Now;
                                            //oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                }

                                #endregion
                            }
                            #endregion
                        }

                        // Modificar y registrar listado de usuarios
                        if (listadoColaboradores != null)
                        {
                            if (listadoColaboradores.Count > 0)
                            {
                                #region Registrar listado detalle de IPs. 

                                foreach (var detalle in listadoColaboradores)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoUsuarios.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoUsuarios oIp = new SAS_DispositivoUsuarios();
                                            oIp.dispositivoCodigo = codigo;
                                            oIp.item = detalle.item;
                                            oIp.estado = detalle.estado;
                                            oIp.idcodigoGeneral = detalle.idcodigoGeneral;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            oIp.fechaCreacion = DateTime.Now;
                                            oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            Modelo.SAS_DispositivoUsuarios.InsertOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoUsuarios oIp = new SAS_DispositivoUsuarios();
                                            oIp = result1.Single();
                                            oIp.estado = detalle.estado;
                                            oIp.idcodigoGeneral = detalle.idcodigoGeneral;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            //oIp.fechaCreacion = DateTime.Now;
                                            //oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }


                        // Modificar y registrar Hardware
                        if (listadoHardware != null)
                        {
                            if (listadoHardware.Count > 0)
                            {
                                #region Registrar listado detalle Hardware()  

                                foreach (var detalle in listadoHardware)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoHardware.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoHardware oDetalle = new SAS_DispositivoHardware();
                                            oDetalle.codigoDispositivo = codigo;
                                            oDetalle.item = detalle.item;
                                            oDetalle.codigoHardware = detalle.codigoHardware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.capacidad = detalle.capacidad;
                                            oDetalle.unidadMedidaCapacidad = detalle.unidadMedidaCapacidad;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            Modelo.SAS_DispositivoHardware.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoHardware oDetalle = new SAS_DispositivoHardware();
                                            oDetalle = result1.Single();
                                            oDetalle.codigoHardware = detalle.codigoHardware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.capacidad = detalle.capacidad;
                                            oDetalle.unidadMedidaCapacidad = detalle.unidadMedidaCapacidad;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }


                        // Modificar y registrar Software
                        if (listadoSoftware != null)
                        {
                            if (listadoSoftware.Count > 0)
                            {
                                #region Registrar listado detalle de Software() 

                                foreach (var detalle in listadoSoftware)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoSoftware.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoSoftware oDetalle = new SAS_DispositivoSoftware();
                                            oDetalle.codigoDispositivo = codigo;
                                            oDetalle.item = detalle.item;
                                            oDetalle.codigoSoftware = detalle.codigoSoftware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.version = detalle.version;
                                            oDetalle.informacionAdicional = detalle.informacionAdicional;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            Modelo.SAS_DispositivoSoftware.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoSoftware oDetalle = new SAS_DispositivoSoftware();
                                            oDetalle = result1.Single();
                                            oDetalle.codigoSoftware = detalle.codigoSoftware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.version = detalle.version;
                                            oDetalle.informacionAdicional = detalle.informacionAdicional;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }




                        #endregion
                    }
                    Scope.Complete();
                }
            }
            return codigo;
        }

        public int Register(string Connection, SAS_Dispostivo device, List<SAS_DispositivoIP> listOfDeletedIPs, List<SAS_DispositivoIP> listOfIPs, List<SAS_DispositivoUsuarios> listadoColaboradoresEliminados, List<SAS_DispositivoUsuarios> listadoColaboradores, List<SAS_DispositivoHardware> listadoHardwareEliminados, List<SAS_DispositivoHardware> listadoHardware, List<SAS_DispositivoSoftware> listadoSoftwareEliminados, List<SAS_DispositivoSoftware> listadoSoftware, List<SAS_DispositivoComponentes> listadoComponentesEliminados, List<SAS_DispositivoComponentes> listadoComponentes, List<SAS_DispositivoCuentaUsuarios> listadoCuentasUsuariosEliminados, List<SAS_DispositivoCuentaUsuarios> listadoCuentasUsuarios, List<SAS_DispositivoDocumento> listadoDocumentosEliminados, List<SAS_DispositivoDocumento> listadoDocumentos)
        {
            int codigo = 0;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[Connection].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                var resultado = Modelo.SAS_Dispostivo.Where(x => x.id == device.id).ToList();
                using (TransactionScope Scope = new TransactionScope())
                {
                    if (resultado.ToList().Count == 0)
                    {
                        #region Registrar() 
                        SAS_Dispostivo oDevice = new SAS_Dispostivo();
                        oDevice.nombres = device.nombres != null ? device.nombres.Trim() : string.Empty;
                        oDevice.descripcion = device.descripcion != null ? device.descripcion.Trim() : string.Empty;
                        oDevice.sedeCodigo = device.sedeCodigo != null ? device.sedeCodigo.Trim() : string.Empty;
                        oDevice.numeroSerie = device.numeroSerie != null ? device.numeroSerie.Trim() : string.Empty;
                        oDevice.caracteristicas = device.caracteristicas != null ? device.caracteristicas.Trim() : string.Empty;
                        oDevice.latitud = device.latitud != null ? device.latitud.Trim() : string.Empty;
                        oDevice.longitud = device.longitud != null ? device.longitud.Trim() : string.Empty;
                        oDevice.estado = 1;
                        oDevice.fechacreacion = DateTime.Now;
                        oDevice.creadoPor = Environment.MachineName.ToString() + " | " + Environment.UserName;
                        oDevice.activoCodigoERP = device.activoCodigoERP != null ? device.activoCodigoERP.Trim() : string.Empty;
                        oDevice.tipoDispositivoCodigo = device.tipoDispositivoCodigo != null ? device.tipoDispositivoCodigo.Trim() : string.Empty;
                        oDevice.IdDispostivoColor = device.IdDispostivoColor != null ? device.IdDispostivoColor.Trim() : string.Empty;
                        oDevice.idArea = device.idArea != null ? device.idArea.Trim() : "010";
                        oDevice.imagen = device.imagen != null ? device.imagen : null;
                        oDevice.idModelo = device.idModelo != null ? device.idModelo.Trim() : string.Empty;
                        oDevice.idMarca = device.idMarca != null ? device.idMarca.Trim() : string.Empty;
                        oDevice.numeroParte = device.numeroParte != null ? device.numeroParte.Trim() : string.Empty;
                        oDevice.IdEstadoProducto = device.IdEstadoProducto != null ? Convert.ToChar(device.IdEstadoProducto.ToString().Trim()) : 'X';
                        oDevice.EsPropio = device.EsPropio != null ? Convert.ToByte(device.EsPropio.Value) : Convert.ToByte(1);
                        oDevice.idProducto = device.idProducto != null ? device.idProducto.Trim() : string.Empty;
                        oDevice.rutaImagen = device.rutaImagen != null ? device.rutaImagen.Trim() : string.Empty;
                        oDevice.funcionamiento = device.funcionamiento != null ? device.funcionamiento.Value : 0;
                        oDevice.idClieprov = device.idClieprov != null ? device.idClieprov.Trim() : string.Empty;
                        oDevice.coordenada = device.coordenada != null ? device.coordenada.Trim() : string.Empty;
                        oDevice.fechaActivacion = device.fechaActivacion != null ? device.fechaActivacion.Value : (DateTime?)null;
                        oDevice.idCobrarpagarDoc = device.idCobrarpagarDoc != null ? device.idCobrarpagarDoc.Trim() : string.Empty;
                        oDevice.fechaBaja = device.fechaBaja != null ? device.fechaBaja.Value : (DateTime?)null;
                        oDevice.fechaProduccion = device.fechaProduccion != null ? device.fechaProduccion.Value : (DateTime?)null;
                        oDevice.esFinal = device.esFinal != null ? device.esFinal.Value : 0;
                        Modelo.SAS_Dispostivo.InsertOnSubmit(oDevice);
                        Modelo.SubmitChanges();
                        codigo = oDevice.id;

                        //registrar Número de IP
                        if (listOfIPs != null)
                        {
                            if (listOfIPs.Count > 0)
                            {
                                #region Registrar listado detalle de IPs. 

                                foreach (var detalle in listOfIPs)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoIP.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp.dispositivoCodigo = codigo;
                                            oIp.item = detalle.item;
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            oIp.fechaCreacion = DateTime.Now;
                                            oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SAS_DispositivoIP.InsertOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp = result1.Single();
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            //oIp.fechaCreacion = DateTime.Now;
                                            //oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }

                        //registrar Colaboradores
                        if (listadoColaboradores != null)
                        {
                            if (listadoColaboradores.Count > 0)
                            {
                                #region Registrar listado detalle de IPs. 

                                foreach (var detalle in listadoColaboradores)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoUsuarios.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoUsuarios oIp = new SAS_DispositivoUsuarios();
                                            oIp.dispositivoCodigo = codigo;
                                            oIp.item = detalle.item;
                                            oIp.estado = detalle.estado;
                                            oIp.idcodigoGeneral = detalle.idcodigoGeneral;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            oIp.fechaCreacion = DateTime.Now;
                                            oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            Modelo.SAS_DispositivoUsuarios.InsertOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoUsuarios oIp = new SAS_DispositivoUsuarios();
                                            oIp = result1.Single();
                                            oIp.estado = detalle.estado;
                                            oIp.idcodigoGeneral = detalle.idcodigoGeneral;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            //oIp.fechaCreacion = DateTime.Now;
                                            //oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }


                        //registrar Hardware
                        if (listadoHardware != null)
                        {
                            if (listadoHardware.Count > 0)
                            {
                                #region Registrar listado detalle Hardware()  

                                foreach (var detalle in listadoHardware)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoHardware.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoHardware oDetalle = new SAS_DispositivoHardware();
                                            oDetalle.codigoDispositivo = codigo;
                                            oDetalle.item = detalle.item;
                                            oDetalle.codigoHardware = detalle.codigoHardware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.capacidad = detalle.capacidad;
                                            oDetalle.unidadMedidaCapacidad = detalle.unidadMedidaCapacidad;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            Modelo.SAS_DispositivoHardware.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoHardware oDetalle = new SAS_DispositivoHardware();
                                            oDetalle = result1.Single();
                                            oDetalle.codigoHardware = detalle.codigoHardware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.capacidad = detalle.capacidad;
                                            oDetalle.unidadMedidaCapacidad = detalle.unidadMedidaCapacidad;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }


                        //registrar Software
                        if (listadoSoftware != null)
                        {
                            if (listadoSoftware.Count > 0)
                            {
                                #region Registrar listado detalle de Software() 

                                foreach (var detalle in listadoSoftware)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoSoftware.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoSoftware oDetalle = new SAS_DispositivoSoftware();
                                            oDetalle.codigoDispositivo = codigo;
                                            oDetalle.item = detalle.item;
                                            oDetalle.codigoSoftware = detalle.codigoSoftware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.version = detalle.version;
                                            oDetalle.informacionAdicional = detalle.informacionAdicional;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            Modelo.SAS_DispositivoSoftware.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoSoftware oDetalle = new SAS_DispositivoSoftware();
                                            oDetalle = result1.Single();
                                            oDetalle.codigoSoftware = detalle.codigoSoftware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.version = detalle.version;
                                            oDetalle.informacionAdicional = detalle.informacionAdicional;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }

                        //registrar Componentes
                        if (listadoComponentes != null)
                        {
                            if (listadoComponentes.Count > 0)
                            {
                                #region Registrar listado detalle de listadoComponentes() 

                                foreach (var detalle in listadoComponentes)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoComponentes.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoComponentes oDetalle = new SAS_DispositivoComponentes();
                                            oDetalle.codigoDispositivo = codigo;
                                            oDetalle.item = detalle.item;
                                            oDetalle.codigoDispositivoComponente = detalle.codigoDispositivoComponente;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            oDetalle.seVisualizaEnReportes = detalle.seVisualizaEnReportes;
                                            Modelo.SAS_DispositivoComponentes.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoComponentes oDetalle = new SAS_DispositivoComponentes();
                                            oDetalle = result1.Single();
                                            oDetalle.codigoDispositivoComponente = detalle.codigoDispositivoComponente;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            oDetalle.seVisualizaEnReportes = detalle.seVisualizaEnReportes;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }

                        //registrar cuentas de usuario
                        if (listadoCuentasUsuarios != null)
                        {
                            if (listadoCuentasUsuarios.Count > 0)
                            {
                                #region Registrar listado detalle de cuentas de usuario() 

                                foreach (var detalle in listadoCuentasUsuarios)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoCuentaUsuarios.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoCuentaUsuarios oDetalle = new SAS_DispositivoCuentaUsuarios();
                                            oDetalle.codigoDispositivo = codigo;
                                            oDetalle.item = detalle.item;
                                            oDetalle.codigoTipoCuenta = detalle.codigoTipoCuenta;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            oDetalle.seVisualizaEnReportes = detalle.seVisualizaEnReportes;


                                            oDetalle.clave = detalle.clave;
                                            oDetalle.correoDeRecuperacion = detalle.correoDeRecuperacion;
                                            oDetalle.NumeroTelefonoRecuperacion = detalle.NumeroTelefonoRecuperacion;

                                            Modelo.SAS_DispositivoCuentaUsuarios.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoCuentaUsuarios oDetalle = new SAS_DispositivoCuentaUsuarios();
                                            oDetalle = result1.Single();
                                            oDetalle.codigoTipoCuenta = detalle.codigoTipoCuenta;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            oDetalle.seVisualizaEnReportes = detalle.seVisualizaEnReportes;
                                            oDetalle.clave = detalle.clave;
                                            oDetalle.correoDeRecuperacion = detalle.correoDeRecuperacion;
                                            oDetalle.NumeroTelefonoRecuperacion = detalle.NumeroTelefonoRecuperacion;


                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }

                        //registrar documentos
                        if (listadoDocumentos != null)
                        {
                            if (listadoDocumentos.Count > 0)
                            {
                                #region Registrar listado detalle de documentos() 

                                foreach (var detalle in listadoDocumentos)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoDocumento.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoDocumento oDetalle = new SAS_DispositivoDocumento();
                                            oDetalle.codigoDispositivo = codigo;
                                            oDetalle.item = detalle.item;
                                            oDetalle.codigoTipoDocumento = detalle.codigoTipoDocumento;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            oDetalle.link = detalle.link;

                                            Modelo.SAS_DispositivoDocumento.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoDocumento oDetalle = new SAS_DispositivoDocumento();
                                            oDetalle = result1.Single();
                                            oDetalle.codigoTipoDocumento = detalle.codigoTipoDocumento;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            oDetalle.link = detalle.link;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }

                        #endregion
                    }
                    else if (resultado.ToList().Count == 1)
                    {
                        #region Editar() 
                        SAS_Dispostivo oDevice = new SAS_Dispostivo();
                        oDevice = resultado.Single();
                        oDevice.nombres = device.nombres != null ? device.nombres.Trim() : string.Empty;
                        oDevice.descripcion = device.descripcion != null ? device.descripcion.Trim() : string.Empty;

                        oDevice.latitud = device.latitud != null ? device.latitud.Trim() : string.Empty;
                        oDevice.longitud = device.longitud != null ? device.longitud.Trim() : string.Empty;

                        oDevice.sedeCodigo = device.sedeCodigo != null ? device.sedeCodigo.Trim() : string.Empty;
                        oDevice.numeroSerie = device.numeroSerie != null ? device.numeroSerie.Trim() : string.Empty;
                        oDevice.caracteristicas = device.caracteristicas != null ? device.caracteristicas.Trim() : string.Empty;
                        oDevice.activoCodigoERP = device.activoCodigoERP != null ? device.activoCodigoERP.Trim() : string.Empty;
                        oDevice.tipoDispositivoCodigo = device.tipoDispositivoCodigo != null ? device.tipoDispositivoCodigo.Trim() : string.Empty;
                        oDevice.IdDispostivoColor = device.IdDispostivoColor != null ? device.IdDispostivoColor.Trim() : string.Empty;
                        oDevice.idModelo = device.idModelo != null ? device.idModelo.Trim() : string.Empty;
                        oDevice.idMarca = device.idMarca != null ? device.idMarca.Trim() : string.Empty;
                        oDevice.numeroParte = device.numeroParte != null ? device.numeroParte.Trim() : string.Empty;
                        oDevice.IdEstadoProducto = device.IdEstadoProducto != null ? Convert.ToChar(device.IdEstadoProducto.ToString().Trim()) : Convert.ToChar('X');
                        oDevice.EsPropio = device.EsPropio != null ? Convert.ToByte(device.EsPropio.Value) : Convert.ToByte(1);
                        oDevice.idProducto = device.idProducto != null ? device.idProducto.Trim() : string.Empty;
                        oDevice.rutaImagen = device.rutaImagen != null ? device.rutaImagen.Trim() : string.Empty;
                        oDevice.funcionamiento = device.funcionamiento != null ? device.funcionamiento.Value : 0;
                        oDevice.idClieprov = device.idClieprov != null ? device.idClieprov.Trim() : string.Empty;
                        oDevice.coordenada = device.coordenada != null ? device.coordenada.Trim() : string.Empty;
                        oDevice.fechaActivacion = device.fechaActivacion != null ? device.fechaActivacion.Value : (DateTime?)null;
                        oDevice.idCobrarpagarDoc = device.idCobrarpagarDoc != null ? device.idCobrarpagarDoc.Trim() : string.Empty;
                        oDevice.fechaBaja = device.fechaBaja != null ? device.fechaBaja.Value : (DateTime?)null;
                        oDevice.fechaProduccion = device.fechaProduccion != null ? device.fechaProduccion.Value : (DateTime?)null;
                        oDevice.esFinal = device.esFinal != null ? device.esFinal.Value : 0;
                        oDevice.idArea = device.idArea != null ? device.idArea.Trim() : "010";
                        oDevice.imagen = device.imagen != null ? device.imagen : null;

                        Modelo.SubmitChanges();
                        codigo = oDevice.id;

                        // Eliminar lista de eliminados de los ips por device.
                        if (listOfDeletedIPs != null)
                        {
                            #region Eliminar lista de Ip para eliminar() 
                            if (listOfDeletedIPs.Count > 0)
                            {
                                foreach (var detalle in listOfDeletedIPs)
                                {
                                    var result1 = Modelo.SAS_DispositivoIP.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 1)
                                        {
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp = result1.Single();
                                            Modelo.SAS_DispositivoIP.DeleteOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                            }
                            #endregion
                        }

                        // Eliminar lista de eliminados de USER  POR device.
                        if (listadoColaboradoresEliminados != null)
                        {
                            #region Eliminar lista de Ip para eliminar() 
                            if (listadoColaboradoresEliminados.Count > 0)
                            {
                                foreach (var detalle in listadoColaboradoresEliminados)
                                {
                                    var result1 = Modelo.SAS_DispositivoUsuarios.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 1)
                                        {
                                            SAS_DispositivoUsuarios oDetalle = new SAS_DispositivoUsuarios();
                                            oDetalle = result1.Single();
                                            Modelo.SAS_DispositivoUsuarios.DeleteOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                            }
                            #endregion
                        }

                        // Eliminar lista de eliminados de hardware.
                        if (listadoHardwareEliminados != null)
                        {
                            #region Eliminar lista de Ip para eliminar() 
                            if (listadoHardwareEliminados.Count > 0)
                            {
                                foreach (var detalle in listadoHardwareEliminados)
                                {
                                    var result1 = Modelo.SAS_DispositivoHardware.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 1)
                                        {
                                            SAS_DispositivoHardware oDetalle = new SAS_DispositivoHardware();
                                            oDetalle = result1.Single();
                                            Modelo.SAS_DispositivoHardware.DeleteOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                            }
                            #endregion
                        }

                        // Eliminar lista de eliminados de software.
                        if (listadoSoftwareEliminados != null)
                        {
                            #region Eliminar lista de Ip para eliminar() 
                            if (listadoSoftwareEliminados.Count > 0)
                            {
                                foreach (var detalle in listadoSoftwareEliminados)
                                {
                                    var result1 = Modelo.SAS_DispositivoSoftware.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 1)
                                        {
                                            SAS_DispositivoSoftware oDetalle = new SAS_DispositivoSoftware();
                                            oDetalle = result1.Single();
                                            Modelo.SAS_DispositivoSoftware.DeleteOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                            }
                            #endregion
                        }

                        // Eliminar lista de eliminados de componentes.
                        if (listadoComponentesEliminados != null)
                        {
                            #region Eliminar lista de Ip para eliminar() 
                            if (listadoComponentesEliminados.Count > 0)
                            {
                                foreach (var detalle in listadoComponentesEliminados)
                                {
                                    var result1 = Modelo.SAS_DispositivoComponentes.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 1)
                                        {
                                            SAS_DispositivoComponentes oDetalle = new SAS_DispositivoComponentes();
                                            oDetalle = result1.Single();
                                            Modelo.SAS_DispositivoComponentes.DeleteOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                            }
                            #endregion
                        }

                        // Eliminar lista de eliminados de cuentas de usuario.
                        if (listadoCuentasUsuariosEliminados != null)
                        {
                            #region Eliminar lista de Ip para eliminar() 
                            if (listadoCuentasUsuariosEliminados.Count > 0)
                            {
                                foreach (var detalle in listadoCuentasUsuariosEliminados)
                                {
                                    var result1 = Modelo.SAS_DispositivoCuentaUsuarios.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 1)
                                        {
                                            SAS_DispositivoCuentaUsuarios oDetalle = new SAS_DispositivoCuentaUsuarios();
                                            oDetalle = result1.Single();
                                            Modelo.SAS_DispositivoCuentaUsuarios.DeleteOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                            }
                            #endregion
                        }

                        // Eliminar lista de eliminados de documentos.
                        if (listadoDocumentosEliminados != null)
                        {
                            #region Eliminar lista de Ip para eliminar() 
                            if (listadoDocumentosEliminados.Count > 0)
                            {
                                foreach (var detalle in listadoDocumentosEliminados)
                                {
                                    var result1 = Modelo.SAS_DispositivoDocumento.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 1)
                                        {
                                            SAS_DispositivoDocumento oDetalle = new SAS_DispositivoDocumento();
                                            oDetalle = result1.Single();
                                            Modelo.SAS_DispositivoDocumento.DeleteOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                            }
                            #endregion
                        }

                        // Modificar y registrar listado de Ip
                        if (listOfIPs != null)
                        {
                            #region Editar y registrar listado de IP                            
                            if (listOfIPs.Count > 0)
                            {
                                #region Registrar listado detalle de IPs. 
                                foreach (var detalle in listOfIPs)
                                {
                                    var result1 = Modelo.SAS_DispositivoIP.Where(x => x.dispositivoCodigo == codigo && x.item.Trim() == detalle.item.Trim()).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp.dispositivoCodigo = codigo;
                                            oIp.item = detalle.item;
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            oIp.fechaCreacion = DateTime.Now;
                                            oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SAS_DispositivoIP.InsertOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoIP oIp = new SAS_DispositivoIP();
                                            oIp = result1.Single();
                                            oIp.estado = detalle.estado;
                                            oIp.direcionMAC = detalle.direcionMAC;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            //oIp.fechaCreacion = DateTime.Now;
                                            //oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            oIp.idIP = detalle.idIP;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                }

                                #endregion
                            }
                            #endregion
                        }

                        // Modificar y registrar listado de usuarios
                        if (listadoColaboradores != null)
                        {
                            if (listadoColaboradores.Count > 0)
                            {
                                #region Registrar listado detalle de IPs. 

                                foreach (var detalle in listadoColaboradores)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoUsuarios.Where(x => x.dispositivoCodigo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoUsuarios oIp = new SAS_DispositivoUsuarios();
                                            oIp.dispositivoCodigo = codigo;
                                            oIp.item = detalle.item;
                                            oIp.estado = detalle.estado;
                                            oIp.idcodigoGeneral = detalle.idcodigoGeneral;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            oIp.fechaCreacion = DateTime.Now;
                                            oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            Modelo.SAS_DispositivoUsuarios.InsertOnSubmit(oIp);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoUsuarios oIp = new SAS_DispositivoUsuarios();
                                            oIp = result1.Single();
                                            oIp.estado = detalle.estado;
                                            oIp.idcodigoGeneral = detalle.idcodigoGeneral;
                                            oIp.hasta = detalle.hasta;
                                            oIp.desde = detalle.desde;
                                            oIp.observacion = detalle.observacion;
                                            //oIp.fechaCreacion = DateTime.Now;
                                            //oIp.registradoPor = Environment.UserName;
                                            oIp.tipo = detalle.tipo;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }


                        // Modificar y registrar Hardware
                        if (listadoHardware != null)
                        {
                            if (listadoHardware.Count > 0)
                            {
                                #region Registrar listado detalle Hardware()  

                                foreach (var detalle in listadoHardware)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoHardware.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoHardware oDetalle = new SAS_DispositivoHardware();
                                            oDetalle.codigoDispositivo = codigo;
                                            oDetalle.item = detalle.item;
                                            oDetalle.codigoHardware = detalle.codigoHardware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.capacidad = detalle.capacidad;
                                            oDetalle.unidadMedidaCapacidad = detalle.unidadMedidaCapacidad;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            Modelo.SAS_DispositivoHardware.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoHardware oDetalle = new SAS_DispositivoHardware();
                                            oDetalle = result1.Single();
                                            oDetalle.codigoHardware = detalle.codigoHardware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.capacidad = detalle.capacidad;
                                            oDetalle.unidadMedidaCapacidad = detalle.unidadMedidaCapacidad;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }


                        // Modificar y registrar Software
                        if (listadoSoftware != null)
                        {
                            if (listadoSoftware.Count > 0)
                            {
                                #region Registrar listado detalle de Software() 

                                foreach (var detalle in listadoSoftware)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoSoftware.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoSoftware oDetalle = new SAS_DispositivoSoftware();
                                            oDetalle.codigoDispositivo = codigo;
                                            oDetalle.item = detalle.item;
                                            oDetalle.codigoSoftware = detalle.codigoSoftware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.version = detalle.version;
                                            oDetalle.informacionAdicional = detalle.informacionAdicional;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            Modelo.SAS_DispositivoSoftware.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoSoftware oDetalle = new SAS_DispositivoSoftware();
                                            oDetalle = result1.Single();
                                            oDetalle.codigoSoftware = detalle.codigoSoftware;
                                            oDetalle.serie = detalle.serie;
                                            oDetalle.version = detalle.version;
                                            oDetalle.informacionAdicional = detalle.informacionAdicional;
                                            oDetalle.numeroParte = detalle.numeroParte;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }

                        //registrar Componentes
                        if (listadoComponentes != null)
                        {
                            if (listadoComponentes.Count > 0)
                            {
                                #region Registrar listado detalle de listadoComponentes() 

                                foreach (var detalle in listadoComponentes)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoComponentes.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoComponentes oDetalle = new SAS_DispositivoComponentes();
                                            oDetalle.codigoDispositivo = codigo;
                                            oDetalle.item = detalle.item;
                                            oDetalle.codigoDispositivoComponente = detalle.codigoDispositivoComponente;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            oDetalle.seVisualizaEnReportes = detalle.seVisualizaEnReportes;
                                            Modelo.SAS_DispositivoComponentes.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoComponentes oDetalle = new SAS_DispositivoComponentes();
                                            oDetalle = result1.Single();
                                            oDetalle.codigoDispositivoComponente = detalle.codigoDispositivoComponente;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            oDetalle.seVisualizaEnReportes = detalle.seVisualizaEnReportes;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }

                        //registrar cuentas de usuario
                        if (listadoCuentasUsuarios != null)
                        {
                            if (listadoCuentasUsuarios.Count > 0)
                            {
                                #region Registrar listado detalle de cuentas de usuario() 

                                foreach (var detalle in listadoCuentasUsuarios)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoCuentaUsuarios.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoCuentaUsuarios oDetalle = new SAS_DispositivoCuentaUsuarios();
                                            oDetalle.codigoDispositivo = codigo;
                                            oDetalle.item = detalle.item;
                                            oDetalle.codigoTipoCuenta = detalle.codigoTipoCuenta;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            oDetalle.seVisualizaEnReportes = detalle.seVisualizaEnReportes;
                                            oDetalle.clave = detalle.clave;
                                            oDetalle.correoDeRecuperacion = detalle.correoDeRecuperacion;
                                            oDetalle.NumeroTelefonoRecuperacion = detalle.NumeroTelefonoRecuperacion;

                                            Modelo.SAS_DispositivoCuentaUsuarios.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoCuentaUsuarios oDetalle = new SAS_DispositivoCuentaUsuarios();
                                            oDetalle = result1.Single();
                                            oDetalle.codigoTipoCuenta = detalle.codigoTipoCuenta;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            oDetalle.seVisualizaEnReportes = detalle.seVisualizaEnReportes;
                                            oDetalle.clave = detalle.clave;
                                            oDetalle.correoDeRecuperacion = detalle.correoDeRecuperacion;
                                            oDetalle.NumeroTelefonoRecuperacion = detalle.NumeroTelefonoRecuperacion;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }

                        //registrar documentos
                        if (listadoDocumentos != null)
                        {
                            if (listadoDocumentos.Count > 0)
                            {
                                #region Registrar listado detalle de documentos() 

                                foreach (var detalle in listadoDocumentos)
                                {
                                    #region 
                                    var result1 = Modelo.SAS_DispositivoDocumento.Where(x => x.codigoDispositivo == codigo && x.item == detalle.item).ToList();
                                    if (result1 != null)
                                    {
                                        if (result1.ToList().Count == 0)
                                        {
                                            #region Nuevo()
                                            SAS_DispositivoDocumento oDetalle = new SAS_DispositivoDocumento();
                                            oDetalle.codigoDispositivo = codigo;
                                            oDetalle.item = detalle.item;
                                            oDetalle.codigoTipoDocumento = detalle.codigoTipoDocumento;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            oDetalle.link = detalle.link;

                                            Modelo.SAS_DispositivoDocumento.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else if (result1.ToList().Count == 1)
                                        {
                                            #region Editar()
                                            SAS_DispositivoDocumento oDetalle = new SAS_DispositivoDocumento();
                                            oDetalle = result1.Single();
                                            oDetalle.codigoTipoDocumento = detalle.codigoTipoDocumento;
                                            oDetalle.observacion = detalle.observacion;
                                            oDetalle.hasta = detalle.hasta;
                                            oDetalle.desde = detalle.desde;
                                            oDetalle.estado = detalle.estado;
                                            oDetalle.link = detalle.link;
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                        }




                        #endregion
                    }
                    Scope.Complete();
                }
            }
            return codigo;
        }

        public Int32 Unregister(string Connection, SAS_Dispostivo device)
        {
            int codigo = 0;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[Connection].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                var resultado = Modelo.SAS_Dispostivo.Where(x => x.id == device.id).ToList();
                using (TransactionScope Scope = new TransactionScope())
                {
                    if (resultado.ToList().Count == 1)
                    {
                        #region Editar() 
                        SAS_Dispostivo oDevice = new SAS_Dispostivo();
                        oDevice = resultado.Single();
                        if (oDevice.estado == 1)
                        {
                            oDevice.estado = 0;
                        }
                        else
                        {
                            oDevice.estado = 1;
                        }
                        Modelo.SubmitChanges();
                        codigo = Convert.ToInt32(oDevice.estado);
                        #endregion
                    }
                    Scope.Complete();
                }
            }
            return codigo;
        }



        public Int32 Delete(string Connection, SAS_Dispostivo device)
        {
            int codigo = 0;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[Connection].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                var resultado = Modelo.SAS_Dispostivo.Where(x => x.id == device.id).ToList();
                using (TransactionScope Scope = new TransactionScope())
                {
                    if (resultado.ToList().Count == 1)
                    {
                        #region Editar() 
                        SAS_Dispostivo oDevice = new SAS_Dispostivo();
                        oDevice = resultado.Single();
                        Modelo.SAS_Dispostivo.DeleteOnSubmit(oDevice);
                        Modelo.SubmitChanges();
                        codigo = oDevice.id;

                        codigo = Convert.ToInt32(device.id);
                        #endregion
                    }
                    Scope.Complete();
                }
            }
            return codigo;
        }


        // Obtener detalle de IP por código de dispositivo
        public List<SAS_DetalleDeDispositivosPorIPByCodigoDispositivoResult> DetalleDeDispositivosPorIPByCodigoDispositivo(string Connection, SAS_Dispostivo device)
        {
            List<SAS_DetalleDeDispositivosPorIPByCodigoDispositivoResult> resultado = new List<SAS_DetalleDeDispositivosPorIPByCodigoDispositivoResult>();

            if (device != null)
            {
                if (device.id != null)
                {
                    string cnx = string.Empty;
                    cnx = ConfigurationManager.AppSettings[Connection].ToString();
                    using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
                    {
                        resultado = Modelo.SAS_DetalleDeDispositivosPorIPByCodigoDispositivo(device.id).ToList();
                    }
                }
            }


            return resultado;
        }



        public List<DFormatoSimple> GetTypeOfSegments(string conection)
        {
            List<DFormatoSimple> listado = new List<DFormatoSimple>();
            List<SAS_SegmentoRed> typeOfSegments = new List<SAS_SegmentoRed>();
            string cnx;
            cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Contexto = new SATURNODataContext(cnx))
            {
                typeOfSegments = Contexto.SAS_SegmentoRed.Where(x => x.estado == 1).ToList();
                listado = (from segment in typeOfSegments

                           select new DFormatoSimple
                           {
                               Codigo = segment.id.ToString(),
                               //Descripcion = items.DistritoOrigen.ToString().Trim() + " / " + items.DistritoDestino.ToString().Trim()
                               Descripcion = segment.descripcion.ToString().Trim()
                           }).ToList();
            }
            return listado;
        }


        public List<DFormatoSimple> GetTypeInterface(string conection)
        {
            List<DFormatoSimple> listado = new List<DFormatoSimple>();
            List<SAS_SegmentoRed> typeOfInterfaces = new List<SAS_SegmentoRed>();
            string cnx;
            cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Contexto = new SATURNODataContext(cnx))
            {
                listado.Add(new DFormatoSimple { Codigo = "F", Descripcion = "FISICO" });
                listado.Add(new DFormatoSimple { Codigo = "W", Descripcion = "WIRELESS" });
            }
            return listado;
        }



        public List<DFormatoSimple> GetCollaborators(string conection)
        {
            List<DFormatoSimple> listado = new List<DFormatoSimple>();
            List<SAS_ListadoColaboradoresByDispositivo> Collaborators = new List<SAS_ListadoColaboradoresByDispositivo>();
            string cnx;
            cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Contexto = new SATURNODataContext(cnx))
            {

                Collaborators = Contexto.SAS_ListadoColaboradoresByDispositivo.ToList();
                listado = (from item in Collaborators
                           group item by new { item.idcodigogeneral, item.apenom }
                           into j
                           select new DFormatoSimple
                           {
                               Codigo = j.Key.idcodigogeneral.ToString(),
                               //Descripcion = items.DistritoOrigen.ToString().Trim() + " / " + items.DistritoDestino.ToString().Trim()
                               Descripcion = j.Key.apenom.ToString()
                           }).ToList();
            }
            return listado;
        }


        public List<DFormatoSimple> GetHardwares(string conection)
        {
            List<DFormatoSimple> listado = new List<DFormatoSimple>();
            List<SAS_DispositivoTipoHardware> items = new List<SAS_DispositivoTipoHardware>();
            string cnx;
            cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Contexto = new SATURNODataContext(cnx))
            {
                items = Contexto.SAS_DispositivoTipoHardware.ToList();
                listado = (from item in items

                           select new DFormatoSimple
                           {
                               Codigo = item.id.ToString(),
                               //Descripcion = items.DistritoOrigen.ToString().Trim() + " / " + items.DistritoDestino.ToString().Trim()
                               Descripcion = item.descripcion.ToString().Trim()
                           }).ToList();
            }
            return listado;
        }


        public List<DFormatoSimple> GetComponentesInternos(string conection)
        {
            List<DFormatoSimple> listado = new List<DFormatoSimple>();
            List<SAS_Dispostivo> items = new List<SAS_Dispostivo>();
            string cnx;
            cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Contexto = new SATURNODataContext(cnx))
            {
                items = Contexto.SAS_Dispostivo.Where(x => x.esFinal != 1).ToList();
                listado = (from item in items

                           select new DFormatoSimple
                           {
                               Codigo = item.id.ToString(),
                               //Descripcion = items.DistritoOrigen.ToString().Trim() + " / " + items.DistritoDestino.ToString().Trim()
                               Descripcion = item.descripcion.ToString().Trim() + " | S/N: " + item.numeroSerie.Trim()
                           }).ToList();
            }
            return listado;
        }

        public List<DFormatoSimple> GetTypeUserAccount(string conection)
        {
            List<DFormatoSimple> listado = new List<DFormatoSimple>();
            List<SAS_DispositivoTipoCuentaUsuario> items = new List<SAS_DispositivoTipoCuentaUsuario>();
            string cnx;
            cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Contexto = new SATURNODataContext(cnx))
            {
                items = Contexto.SAS_DispositivoTipoCuentaUsuario.ToList();
                listado = (from item in items

                           select new DFormatoSimple
                           {
                               Codigo = item.id.ToString(),
                               //Descripcion = items.DistritoOrigen.ToString().Trim() + " / " + items.DistritoDestino.ToString().Trim()
                               Descripcion = item.descripcion.ToString().Trim()
                           }).ToList();
            }
            return listado;
        }


        public List<DFormatoSimple> GetTypeDocumentByDevice(string conection)
        {
            List<DFormatoSimple> listado = new List<DFormatoSimple>();
            List<SAS_DispositivoTipoDocumento> items = new List<SAS_DispositivoTipoDocumento>();
            string cnx;
            cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Contexto = new SATURNODataContext(cnx))
            {
                items = Contexto.SAS_DispositivoTipoDocumento.ToList();
                listado = (from item in items

                           select new DFormatoSimple
                           {
                               Codigo = item.id.ToString(),
                               //Descripcion = items.DistritoOrigen.ToString().Trim() + " / " + items.DistritoDestino.ToString().Trim()
                               Descripcion = item.descripcion.ToString().Trim()
                           }).ToList();
            }
            return listado;
        }

        public List<DFormatoSimple> GetSoftwares(string conection)
        {
            List<DFormatoSimple> listado = new List<DFormatoSimple>();
            List<SAS_DispositivoTipoSoftware> items = new List<SAS_DispositivoTipoSoftware>();
            string cnx;
            cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Contexto = new SATURNODataContext(cnx))
            {

                items = Contexto.SAS_DispositivoTipoSoftware.ToList();
                listado = (from item in items

                           select new DFormatoSimple
                           {
                               Codigo = item.id.ToString(),
                               //Descripcion = items.DistritoOrigen.ToString().Trim() + " / " + items.DistritoDestino.ToString().Trim()
                               Descripcion = item.descripcion.ToString().Trim()
                           }).ToList();
            }
            return listado;
        }


        public List<DFormatoSimple> GetNumberOfIpsPerSegment(string conection, string segmentoCodigo)
        {
            List<DFormatoSimple> listado = new List<DFormatoSimple>();
            List<SAS_ListadoNumeroIPBySegmento> ipNumbersPerSegment = new List<SAS_ListadoNumeroIPBySegmento>();
            string cnx;
            cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Contexto = new SATURNODataContext(cnx))
            {
                ipNumbersPerSegment = Contexto.SAS_ListadoNumeroIPBySegmento.Where(x => x.segmentoCodigo == segmentoCodigo).ToList();
                listado = (from segment in ipNumbersPerSegment

                           select new DFormatoSimple
                           {
                               Codigo = segment.codigoIp.ToString(),
                               //Descripcion = items.DistritoOrigen.ToString().Trim() + " / " + items.DistritoDestino.ToString().Trim()
                               Descripcion = segment.numeroIP.ToString().Trim()
                           }).ToList();
            }
            return listado;
        }



        // Obtener detalle de usuarios.
        public List<SAS_ListadoColaboradoresByDispositivoByCodigoResult> ListadoColaboradoresByDispositivoByCodigo(string Connection, int codigo)
        {
            List<SAS_ListadoColaboradoresByDispositivoByCodigoResult> resultado = new List<SAS_ListadoColaboradoresByDispositivoByCodigoResult>();

            if (codigo > 0)
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings[Connection].ToString();
                using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
                {
                    resultado = Modelo.SAS_ListadoColaboradoresByDispositivoByCodigo(codigo).ToList();
                }

            }


            return resultado;
        }


        public SAS_ListadoDeDispositivosByIdDeviceResult GetDeviceByIdDevice(string conection, int idDispositivo)
        {
            List<SAS_ListadoDeDispositivosByIdDeviceResult> resultado = new List<SAS_ListadoDeDispositivosByIdDeviceResult>();
            SAS_ListadoDeDispositivosByIdDeviceResult resultado2 = new SAS_ListadoDeDispositivosByIdDeviceResult();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                resultado = Modelo.SAS_ListadoDeDispositivosByIdDevice(idDispositivo).ToList();
                if (resultado.ToList().Count() > 1)
                {
                    resultado2 = resultado.ElementAt(0);
                }
                else if (resultado.ToList().Count() == 1)
                {
                    resultado2 = resultado.Single();
                }

            }
            return resultado2;
        }

    }
}
