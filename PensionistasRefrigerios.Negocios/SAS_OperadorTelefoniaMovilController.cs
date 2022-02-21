using Asistencia.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Transactions;


namespace Asistencia.Negocios
{
  public  class SAS_OperadorTelefoniaMovilController
    {
        public List<SAS_OperadorTelefoniaMovilListado> MobilePhoneOperators(string conection)
        {
            List<SAS_OperadorTelefoniaMovilListado> list = new List<SAS_OperadorTelefoniaMovilListado>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                list = model.SAS_OperadorTelefoniaMovilListado.ToList();
            }
            return list.OrderBy(x => x.descripcion).ToList();
        }

        public int ToRegister(string conection, SAS_OperadorTelefoniaMovil item)
        {
            //SAS_DispositivoTipoSoftware oregistro = new SAS_DispositivoTipoSoftware();
            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();

            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    var resultado = model.SAS_OperadorTelefoniaMovil.Where(x => x.id == item.id).ToList();
                    if (resultado != null)
                    {
                        #region Registro | Actualizacion()  
                        if (resultado.ToList().Count == 0)
                        {
                            //int ObtenerUltimoItem = model.AREAS.ToList().Count > 0 ? Convert.ToInt32(model.AREAS.ToList().Max(x => x.IDAREA)) + 1 : 0;
                            #region Nuevo() 
                            SAS_OperadorTelefoniaMovil oregistro = new SAS_OperadorTelefoniaMovil();                                                        
                            oregistro.descripcion = item.descripcion != null ? item.descripcion.Trim() : string.Empty;                            
                            oregistro.estado = item.estado != null ? item.estado : 1;
                            oregistro.nota = item.nota != null ? item.nota.Trim() : string.Empty;
                            oregistro.idclieprov = item.idclieprov != null ? item.idclieprov.Trim() : string.Empty;
                            oregistro.abreviatura = item.abreviatura != null ? item.abreviatura.Trim() : string.Empty;
                            oregistro.esServicioMovil = item.esServicioMovil != null ? item.esServicioMovil : 0;
                            oregistro.esCableSatelital = item.esCableSatelital != null ? item.esCableSatelital : 0;
                            oregistro.esCableFijo = item.esCableFijo != null ? item.esCableFijo : 0;
                            oregistro.esProveedorDeInternet = item.esProveedorDeInternet != null ? item.esProveedorDeInternet : 0;


                            model.SAS_OperadorTelefoniaMovil.InsertOnSubmit(oregistro);
                            model.SubmitChanges();
                            tipoResultadoOperacion = 0; // registrar
                            #endregion
                        }
                        else if (resultado.ToList().Count == 1)
                        {
                            #region Actualizar() 
                            SAS_OperadorTelefoniaMovil oregistro = new SAS_OperadorTelefoniaMovil();
                            oregistro = resultado.Single();
                            oregistro.descripcion = item.descripcion != null ? item.descripcion.Trim() : string.Empty;
                            oregistro.estado = item.estado != null ? item.estado : 1;
                            oregistro.nota = item.nota != null ? item.nota.Trim() : string.Empty;
                            oregistro.idclieprov = item.idclieprov != null ? item.idclieprov.Trim() : string.Empty;
                            oregistro.abreviatura = item.abreviatura != null ? item.abreviatura.Trim() : string.Empty;
                            oregistro.esServicioMovil = item.esServicioMovil != null ? item.esServicioMovil : 0;
                            oregistro.esCableSatelital = item.esCableSatelital != null ? item.esCableSatelital : 0;
                            oregistro.esCableFijo = item.esCableFijo != null ? item.esCableFijo : 0;
                            oregistro.esProveedorDeInternet = item.esProveedorDeInternet != null ? item.esProveedorDeInternet : 0;
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

        public int ChangeState(string conection, SAS_OperadorTelefoniaMovil item)
        {
            SAS_OperadorTelefoniaMovil oregistro = new SAS_OperadorTelefoniaMovil();
            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                var resultado = model.SAS_OperadorTelefoniaMovil.Where(x => x.id == item.id).ToList();
                if (resultado != null)
                {
                    if (resultado.ToList().Count == 1)
                    {
                        #region Cambiar de estado() 
                        oregistro = new SAS_OperadorTelefoniaMovil();
                        oregistro = resultado.Single();

                        if (oregistro.estado == 1)
                        {
                            oregistro.estado = 0;
                            tipoResultadoOperacion = 2; // desactivar
                        }
                        else
                        {
                            oregistro.estado = 1;
                            tipoResultadoOperacion = 3; // Activar
                        }
                        model.SubmitChanges();
                        #endregion                       
                    }
                }
            }
            return tipoResultadoOperacion;
        }

        public int Remove(string conection, SAS_OperadorTelefoniaMovil item)
        {
            SAS_OperadorTelefoniaMovil oregistro = new SAS_OperadorTelefoniaMovil();
            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                var resultado = model.SAS_OperadorTelefoniaMovil.Where(x => x.id == item.id).ToList();
                if (resultado != null)
                {
                    if (resultado.ToList().Count == 1)
                    {
                        #region Cambiar de estado() 
                        oregistro = new SAS_OperadorTelefoniaMovil();
                        oregistro = resultado.Single();                        
                        model.SAS_OperadorTelefoniaMovil.DeleteOnSubmit(oregistro);
                        model.SubmitChanges();
                        tipoResultadoOperacion = 4;
                        #endregion
                    }
                }
            }
            return tipoResultadoOperacion;
        }

    }
}
