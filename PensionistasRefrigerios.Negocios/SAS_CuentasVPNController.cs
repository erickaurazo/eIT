using Asistencia.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Asistencia.Negocios
{
    public class SAS_CuentasVPNController
    {


        public List<SAS_CuentasVPN> GetVPNaccounts(string conection)
        {
            List<SAS_CuentasVPN> listado = new List<SAS_CuentasVPN>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                listado = model.SAS_CuentasVPN.ToList();
            }
            return listado;
        }


        public int Register(string conection, SAS_CuentasVPN item)
        {
            //SAS_DispositivoTipoSoftware oregistro = new SAS_DispositivoTipoSoftware();
            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();

            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    var resultado = model.SAS_CuentasVPN.Where(x => x.id == item.id).ToList();
                    if (resultado != null)
                    {
                        #region Registro | Actualizacion() 
                        if (resultado.ToList().Count == 0)
                        {
                            #region Nuevo();
                            SAS_CuentasVPN oregistro = new SAS_CuentasVPN();
                            oregistro.id = item.id;
                            oregistro.idcodigoGeneral = item.idcodigoGeneral;
                            oregistro.NombresCompletos = item.NombresCompletos;
                            oregistro.cuenta = item.cuenta;
                            oregistro.empresa = item.empresa;
                            oregistro.clave = item.clave;
                            oregistro.observacion = item.observacion;
                            oregistro.instruccion = item.instruccion;
                            oregistro.glosa = item.glosa;
                            oregistro.estado = item.estado;
                            oregistro.fechaCreacion = DateTime.Now;
                            oregistro.creadoPor = Environment.UserName;                            
                            model.SAS_CuentasVPN.InsertOnSubmit(oregistro);
                            model.SubmitChanges();
                            tipoResultadoOperacion = 0; // registrar
                            #endregion
                        }
                        else if (resultado.ToList().Count == 1)
                        {
                            #region Actualizar()
                            SAS_CuentasVPN oregistro = new SAS_CuentasVPN();
                            oregistro = resultado.Single();
                            oregistro.idcodigoGeneral = item.idcodigoGeneral;
                            oregistro.NombresCompletos = item.NombresCompletos;
                            oregistro.cuenta = item.cuenta;
                            oregistro.empresa = item.empresa;
                            oregistro.clave = item.clave;
                            oregistro.observacion = item.observacion;
                            oregistro.instruccion = item.instruccion;
                            oregistro.glosa = item.glosa;
                            oregistro.estado = item.estado;
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

        public int ChangeState(string conection, SAS_CuentasVPN item)
        {

            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                var resultado = model.SAS_CuentasVPN.Where(x => x.id == item.id).ToList();
                if (resultado != null)
                {
                    if (resultado.ToList().Count == 1)
                    {
                        #region Cambiar de estado()
                        SAS_CuentasVPN oregistro = new SAS_CuentasVPN();
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
