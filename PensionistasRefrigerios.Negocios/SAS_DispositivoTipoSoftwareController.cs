﻿using Asistencia.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Asistencia.Negocios
{
    public class SAS_DispositivoTipoSoftwareController
    {

        public List<SAS_DispositivoTipoSoftwareListado> GetTypeDevices(string conection)
        {
            List<SAS_DispositivoTipoSoftwareListado> listado = new List<SAS_DispositivoTipoSoftwareListado>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                listado = model.SAS_DispositivoTipoSoftwareListado.ToList();
            }
            return listado;
        }


        public int Register(string conection, SAS_DispositivoTipoSoftware item)
        {
            //SAS_DispositivoTipoSoftware oregistro = new SAS_DispositivoTipoSoftware();
            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();

            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    var resultado = model.SAS_DispositivoTipoSoftware.Where(x => x.id == item.id).ToList();
                    if (resultado != null)
                    {
                        #region Registro | Actualizacion() 
                        if (resultado.ToList().Count == 0)
                        {
                            #region Nuevo();
                            SAS_DispositivoTipoSoftware oregistro = new SAS_DispositivoTipoSoftware();
                            oregistro.id = item.id;
                            oregistro.descripcion = item.descripcion;
                            oregistro.nombreCorto = item.nombreCorto;
                            oregistro.estado = item.estado;
                            oregistro.observación = item.observación != string.Empty ? item.observación : string.Empty;
                            oregistro.enFormatoSolicitud = item.enFormatoSolicitud != null ? item.enFormatoSolicitud : 0;
                            oregistro.tipoSoftware = item.tipoSoftware != string.Empty ? item.tipoSoftware : "001";
                            model.SAS_DispositivoTipoSoftware.InsertOnSubmit(oregistro);
                            model.SubmitChanges();
                            tipoResultadoOperacion = 0; // registrar
                            #endregion
                        }
                        else if (resultado.ToList().Count == 1)
                        {
                            #region Actualizar()
                            SAS_DispositivoTipoSoftware oregistro = new SAS_DispositivoTipoSoftware();
                            oregistro = resultado.Single();
                            oregistro.descripcion = item.descripcion;
                            oregistro.nombreCorto = item.nombreCorto;
                            oregistro.estado = item.estado;
                            oregistro.observación = item.observación != string.Empty ? item.observación.Trim() : string.Empty;
                            oregistro.enFormatoSolicitud = item.enFormatoSolicitud != null ? item.enFormatoSolicitud : 0;
                            oregistro.tipoSoftware = item.tipoSoftware != string.Empty ? item.tipoSoftware : "001";
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

        public int ChangeState(string conection, SAS_DispositivoTipoSoftware tipoSoftware)
        {
            SAS_DispositivoTipoSoftware oregistro = new SAS_DispositivoTipoSoftware();
            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                var resultado = model.SAS_DispositivoTipoSoftware.Where(x => x.id == tipoSoftware.id).ToList();
                if (resultado != null)
                {
                    if (resultado.ToList().Count == 1)
                    {
                        #region Cambiar de estado()
                        oregistro = new SAS_DispositivoTipoSoftware();
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

    }
}
