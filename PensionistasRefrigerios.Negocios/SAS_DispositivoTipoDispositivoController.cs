﻿using Asistencia.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Asistencia.Negocios
{
    public class SAS_DispositivoTipoDispositivoController
    {


        public List<SAS_DispositivoTipoDispositivoListadoResult> GetLIstadoTipoDispositivo(string conection)
        {

            List<SAS_DispositivoTipoDispositivoListadoResult> resultado = new List<SAS_DispositivoTipoDispositivoListadoResult>();

            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {

                resultado = model.SAS_DispositivoTipoDispositivoListado().ToList();
            }

            return resultado;
        }

        public int Register(string conection, SAS_DispositivoTipoDispositivo oTipoDispositivo)
        {
            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                var resultado = model.SAS_DispositivoTipoDispositivo.Where(x => x.id == oTipoDispositivo.id).ToList();
                if (resultado != null)
                {
                    if (resultado.ToList().Count == 0)
                    {
                        #region Nuevo();
                        SAS_DispositivoTipoDispositivo oregistro = new SAS_DispositivoTipoDispositivo();
                        oregistro.id = oTipoDispositivo.id;
                        oregistro.descripcion = oTipoDispositivo.descripcion;
                        oregistro.nombreCorto = oTipoDispositivo.nombreCorto;
                        oregistro.estado = oTipoDispositivo.estado;
                        oregistro.enFormatoSolicitud = oTipoDispositivo.enFormatoSolicitud;
                        oregistro.observaciones = oTipoDispositivo.observaciones;
                        model.SAS_DispositivoTipoDispositivo.InsertOnSubmit(oregistro);
                        model.SubmitChanges();
                        tipoResultadoOperacion = 0;
                        #endregion
                    }
                    else if (resultado.ToList().Count == 1)
                    {
                        #region Actualizar()
                        SAS_DispositivoTipoDispositivo oregistro = new SAS_DispositivoTipoDispositivo();
                        oregistro = resultado.Single();
                        oregistro.descripcion = oTipoDispositivo.descripcion;
                        oregistro.nombreCorto = oTipoDispositivo.nombreCorto;
                        oregistro.estado = oTipoDispositivo.estado;
                        oregistro.enFormatoSolicitud = oTipoDispositivo.enFormatoSolicitud;
                        oregistro.observaciones = oTipoDispositivo.observaciones;
                        model.SubmitChanges();
                        #endregion
                        tipoResultadoOperacion = 1;
                    }
                }
            }

            return tipoResultadoOperacion;
        }

        public int ChangeState(string conection, SAS_DispositivoTipoDispositivo oTipoDispositivo)
        {
            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                var resultado = model.SAS_DispositivoTipoDispositivo.Where(x => x.id == oTipoDispositivo.id).ToList();
                if (resultado != null)
                {
                    if (resultado.ToList().Count == 1)
                    {
                        #region Actualizar()
                        SAS_DispositivoTipoDispositivo oregistro = new SAS_DispositivoTipoDispositivo();
                        oregistro = resultado.Single();

                        if (oregistro.estado == 1)
                        {
                            oregistro.estado = 0;
                            tipoResultadoOperacion = 2; // anular
                        }
                        else
                        {
                            oregistro.estado = 1;
                            tipoResultadoOperacion = 1; // activar
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
