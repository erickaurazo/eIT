using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding.Busquedas;
using Asistencia.Datos;

namespace Asistencia.Negocios
{
    public class PersonaParaderoController
    {

        public List<SJM_PersonaParadero> ObtenerListadoPersonalParadero(string periodoConsulta)
        {
            List<SJM_PersonaParadero> listado = new List<SJM_PersonaParadero>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoConsulta.ToString()].ToString();
            using (BDAsistenciaDataContext Contexto = new BDAsistenciaDataContext(cnx))
            {
                Contexto.CommandTimeout = 99999;

                var listaPersonalParadero = Contexto.SJM_PersonaParadero.OrderBy(x => x.Id).ToList().ToList();
                var listaParaderos = Contexto.SJ_Paraderos.ToList();

                var resultado =
                    from per in listaPersonalParadero
                    join par in listaParaderos
                    on per.IdParadero.ToString().Trim() equals par.IdParadero.ToString().Trim()
                    select new SJM_PersonaParadero
                    {
                        Id = per.Id,
                        idCodigoPersonalGeneral = per.idCodigoPersonalGeneral != null ? per.idCodigoPersonalGeneral.ToString().Trim() : "",
                        dniTrabajador = per.dniTrabajador != null ? per.dniTrabajador.ToString().Trim() : "",
                        NombresTrabajador = per.NombresTrabajador.ToString().Trim(),
                        Fecha = per.Fecha.Value,
                        FechaTransferencia = per.FechaTransferencia != null ? per.FechaTransferencia.Value : DateTime.Now,
                        IdParadero = per.IdParadero.ToString().Trim() + " - " + par.DescripcionParadero.ToString().Trim(),
                        direccion = per.direccion != null ? per.direccion.ToString().Trim() : "",
                        paradero = per.paradero != null ? per.paradero.ToString().Trim() : "",
                        estado = per.estado,
                        contacto = per.contacto != null ? per.contacto.Trim() : "",
                        nroContacto = per.nroContacto != null ? per.nroContacto.Trim() : "",
                    };

                foreach (var item in resultado)
                {

                    try
                    {
                        listado.Add(item);
                    }
                    catch (Exception Ex)
                    {
                        string mensage = item.idCodigoPersonalGeneral.Trim();
                        throw Ex;
                    }

                }

                //listado = innerJoinQuery.ToList();

                Contexto.Connection.Close();
            }
            return listado;
        }

        public SJM_PersonaParadero ObtenerPersonalParadero(string periodoConsulta, SJM_PersonaParadero oSJ_PersonaParadero)
        {
            SJM_PersonaParadero oParaderoPersona = new SJM_PersonaParadero();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoConsulta.ToString()].ToString();
            using (BDAsistenciaDataContext Contexto = new BDAsistenciaDataContext(cnx))
            {
                Contexto.CommandTimeout = 99999;
                var listado = Contexto.SJM_PersonaParadero.Where(x => x.IdParadero.ToString().Trim() == oSJ_PersonaParadero.IdParadero.ToString().Trim()).ToList().OrderBy(x => x.IdParadero).ToList();

                if (listado != null && listado.ToList().Count == 1)
                {
                    oParaderoPersona = listado.Single();
                }
                Contexto.Connection.Close();
            }
            return oParaderoPersona;
        }

        public void Registrar(string periodoRegistro, SJM_PersonaParadero oSJ_PersonaParadero)
        {
            SJM_PersonaParadero oPersonaParadero = new SJM_PersonaParadero();
            //using (TransactionScope Scope = new TransactionScope())
            //{
            #region Transaccion
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoRegistro.ToString()].ToString();
            using (BDAsistenciaDataContext Contexto = new BDAsistenciaDataContext(cnx))
            {
                #region
                Contexto.CommandTimeout = 99999;

                var resultadoSubConsulta = Contexto.SJM_PersonaParadero.Where(x => x.Id == oSJ_PersonaParadero.Id).ToList();

                if (resultadoSubConsulta != null && resultadoSubConsulta.ToList().Count == 1)
                {
                    #region Actualizar
                    oPersonaParadero = resultadoSubConsulta.Single();
                    //oParadero.Id = oSJ_PersonaParadero.Id;
                    oPersonaParadero.idCodigoPersonalGeneral = oSJ_PersonaParadero.idCodigoPersonalGeneral != null ? oSJ_PersonaParadero.idCodigoPersonalGeneral.ToString().Trim() : "";
                    oPersonaParadero.dniTrabajador = oSJ_PersonaParadero.dniTrabajador != null ? oSJ_PersonaParadero.dniTrabajador.ToString().Trim() : "";
                    oPersonaParadero.NombresTrabajador = oSJ_PersonaParadero.NombresTrabajador != null ? oSJ_PersonaParadero.NombresTrabajador.ToString().Trim() : "";
                    //oParadero.Fecha = oSJ_PersonaParadero.Fecha;
                    //oParadero.FechaTransferencia = oSJ_PersonaParadero.FechaTransferencia;
                    oPersonaParadero.IdParadero = oSJ_PersonaParadero.IdParadero != null ? oSJ_PersonaParadero.IdParadero.ToString().Trim() : "";
                    oPersonaParadero.paradero = oSJ_PersonaParadero.paradero != null ? oSJ_PersonaParadero.paradero.ToString().Trim() : "";
                    oPersonaParadero.direccion = oSJ_PersonaParadero.direccion != null ? oSJ_PersonaParadero.direccion.ToString().Trim() : "";
                    oPersonaParadero.contacto = oSJ_PersonaParadero.contacto != null ? oSJ_PersonaParadero.contacto.ToString().Trim() : "";
                    oPersonaParadero.nroContacto = oSJ_PersonaParadero.nroContacto != null ? oSJ_PersonaParadero.nroContacto.ToString().Trim() : "";
                    //oParadero.estado = oSJ_PersonaParadero.estado;
                    Contexto.SubmitChanges();
                    #endregion
                }
                else
                {
                    if (oSJ_PersonaParadero.Id == 0)
                    {
                        #region Registro()
                        //oParadero.Id = oSJ_PersonaParadero.Id;
                        oPersonaParadero.idCodigoPersonalGeneral = oSJ_PersonaParadero.idCodigoPersonalGeneral != null ? oSJ_PersonaParadero.idCodigoPersonalGeneral.ToString().Trim() : "";
                        oPersonaParadero.dniTrabajador = oSJ_PersonaParadero.dniTrabajador != null ? oSJ_PersonaParadero.dniTrabajador.ToString().Trim() : "";
                        oPersonaParadero.NombresTrabajador = oSJ_PersonaParadero.NombresTrabajador != null ? oSJ_PersonaParadero.NombresTrabajador.ToString().Trim() : "";
                        oPersonaParadero.Fecha = oSJ_PersonaParadero.Fecha;
                        oPersonaParadero.FechaTransferencia = oSJ_PersonaParadero.FechaTransferencia;
                        oPersonaParadero.IdParadero = oSJ_PersonaParadero.IdParadero != null ? oSJ_PersonaParadero.IdParadero.ToString().Trim() : "";
                        oPersonaParadero.estado = oSJ_PersonaParadero.estado;
                        oPersonaParadero.paradero = oSJ_PersonaParadero.paradero != null ? oSJ_PersonaParadero.paradero.ToString().Trim() : "";
                        oPersonaParadero.direccion = oSJ_PersonaParadero.direccion != null ? oSJ_PersonaParadero.direccion.ToString().Trim() : "";
                        oPersonaParadero.contacto = oSJ_PersonaParadero.contacto != null ? oSJ_PersonaParadero.contacto.ToString().Trim() : "";
                        oPersonaParadero.nroContacto = oSJ_PersonaParadero.nroContacto != null ? oSJ_PersonaParadero.nroContacto.ToString().Trim() : "";
                        Contexto.SJM_PersonaParadero.InsertOnSubmit(oPersonaParadero);
                        Contexto.SubmitChanges();

                        #endregion
                    }
                }
                Contexto.Connection.Close();
                #endregion
            }
            #endregion
            //    Scope.Complete();
            //}

        }

        public void Eliminar(string periodoRegistro, SJM_PersonaParadero oSJ_PersonalParadero)
        {
            SJM_PersonaParadero oPersonaParadero = new SJM_PersonaParadero();

            #region Transaccion
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoRegistro.ToString()].ToString();
            using (BDAsistenciaDataContext Contexto = new BDAsistenciaDataContext(cnx))
            {
                #region
                Contexto.CommandTimeout = 99999;

                var resultadoSubConsulta = Contexto.SJM_PersonaParadero.Where(x => x.Id == oSJ_PersonalParadero.Id).ToList();

                if (resultadoSubConsulta != null && resultadoSubConsulta.ToList().Count == 1)
                {
                    #region Actualizar

                    oPersonaParadero = resultadoSubConsulta.Single();
                    Contexto.SJM_PersonaParadero.DeleteOnSubmit(oPersonaParadero);
                    Contexto.SubmitChanges();
                    #endregion
                }

                Contexto.Connection.Close();
                #endregion
            }
            #endregion
        }

        /* Se puede anular o activar el paradero */
        public void CambiarEstadoDocumento(string periodoRegistro, SJM_PersonaParadero oSJ_PersonalParadero)
        {
            SJM_PersonaParadero oPersonaParadero = new SJM_PersonaParadero();

            #region Transaccion
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoRegistro.ToString()].ToString();
            using (BDAsistenciaDataContext Contexto = new BDAsistenciaDataContext(cnx))
            {
                #region
                Contexto.CommandTimeout = 99999;

                var resultadoSubConsulta = Contexto.SJM_PersonaParadero.Where(x => x.Id == oSJ_PersonalParadero.Id).ToList();

                if (resultadoSubConsulta != null && resultadoSubConsulta.ToList().Count == 1)
                {
                    #region Actualizar

                    oPersonaParadero = resultadoSubConsulta.Single();
                    if (oPersonaParadero.estado == 1)
                    {
                        oPersonaParadero.estado = 0;
                    }
                    else
                    {
                        oPersonaParadero.estado = 1;
                    }
                    Contexto.SubmitChanges();
                    #endregion
                }

                Contexto.Connection.Close();
                #endregion
            }
            #endregion

        }


        public bool ValidarDuplicidadPersonal(string periodo, SJM_PersonaParadero oPersonaParadero)
        {
            bool estado = false;

            #region Transaccion
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Trim()];
            using (BDAsistenciaDataContext Contexto = new BDAsistenciaDataContext(cnx))
            {
                #region
                Contexto.CommandTimeout = 99999;

                var resultadoSubConsulta = Contexto.SJM_PersonaParadero.Where(x => x.dniTrabajador == oPersonaParadero.dniTrabajador).ToList();

                if (resultadoSubConsulta != null && resultadoSubConsulta.ToList().Count > 0)
                {
                    estado = true;
                }

                Contexto.Connection.Close();
                #endregion
            }
            #endregion

            return estado;
        }
    }
}
