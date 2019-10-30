using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;

namespace RecursosHumanos.Negocios
{
    public class PrivilegiosNegocios
    {
        //private PRIVILEGIOS Obj;

        public List<SJ_RHPrivilegiosAccesosSistemasResult> ObtenerListaPrivilegios(string periodo)
        {
            List<SJ_RHPrivilegiosAccesosSistemasResult> Listado = new List<SJ_RHPrivilegiosAccesosSistemasResult>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800000;

                try
                {
                    Listado = Modelo.SJ_RHPrivilegiosAccesosSistemas().ToList();
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }

            return Listado;
        }


        public List<SJ_RHPrivilegioxUsuarioxFormularioResult> ObtenerPrivilegiosUsuarioxFormulario(string codFormulario, string codUsuario, string periodo)
        {
            List<SJ_RHPrivilegioxUsuarioxFormularioResult> Listado = new List<SJ_RHPrivilegioxUsuarioxFormularioResult>();

            string cnx = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim()].ToString();

            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                Listado = Modelo.SJ_RHPrivilegioxUsuarioxFormulario(codFormulario, codUsuario).ToList();
            }

            return Listado;
        }


        public void RegistrarPrivilegios(string idusuario, string clave, int NINGUNO, int CONSULTA, int EXPORTA_IMPRIME, int NUEVO, int MODIFICA, int ANULA, int ELIMINA, int VER_LOGS, string Periodo)
        {
            string Codigo = string.Empty;
            using (TransactionScope Scope = new TransactionScope())
            {
                #region Transacción()
                string cnx = string.Empty;

                cnx = ConfigurationManager.AppSettings["bd" + Periodo.ToString().Trim()].ToString();
                using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
                {
                    #region
                    if (clave.ToString().Trim() != "" && idusuario.ToString().Trim() != "")
                    {

                        if (Modelo.PRIVILEGIOS.Where(x => x.IDUSUARIO.ToString().Trim() == idusuario.ToString().Trim() && x.CLAVE.ToString().Trim() == clave.ToString().Trim()).ToList().Count == 1)
                        {
                            #region Actualizar();
                            try
                            {
                                Modelo.SJ_PrivilegiosActualizar(idusuario.ToString().Trim(), clave.ToString().Trim(), NINGUNO, CONSULTA, EXPORTA_IMPRIME, NUEVO, MODIFICA, ANULA, ELIMINA, VER_LOGS);
                                Modelo.SubmitChanges();
                            }
                            catch (Exception Ex)
                            {

                                throw Ex;
                            }


                            #endregion
                        }
                        else
                        {
                            #region Registrar()

                            Modelo.SJ_PrivilegiosRegistrar(idusuario.ToString().Trim(), clave.ToString().Trim(), NINGUNO, CONSULTA, EXPORTA_IMPRIME, NUEVO, MODIFICA, ANULA, ELIMINA, VER_LOGS);
                            Modelo.SubmitChanges();
                            #endregion
                        }
                    }
                    #endregion


                    Modelo.Connection.Close();
                }
                #endregion
                Scope.Complete();
            }
        }

        public int ObtenerNroPrivilegiosxUsuario(string idusuario, string clave, string Periodo)
        {
            int existencia = 0;

            List<SJ_RHPrivilegioxUsuarioxFormularioResult> Listado = new List<SJ_RHPrivilegioxUsuarioxFormularioResult>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + Periodo.ToString()].ToString();

            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800000;

                try
                {
                    Listado = Modelo.SJ_RHPrivilegioxUsuarioxFormulario(idusuario,clave).ToList();

                    if (Listado != null)
                    {
                        existencia = Listado.Count;
                    }
                    else
                    {
                        existencia = 0;
                    }
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }

            return existencia;
        }


        public void EliminarElemetosDuplicados()
        {
            List<SJ_PrivilegiosDuplicadosResult> ListadoDuplicados = new List<SJ_PrivilegiosDuplicadosResult>();

            string cnx = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString().Trim()].ToString();


            //using (TransactionScope Scope = new TransactionScope())
            //{
                using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
                {
                    ListadoDuplicados = Modelo.SJ_PrivilegiosDuplicados().ToList();

                    if (ListadoDuplicados != null)
                    {
                        foreach (var item in ListadoDuplicados)
                        {
                            //Modelo.SJ_PrivilegiosEliminar(item.idusuario.ToString().Trim(), item.clave.ToString().Trim());
                        }
                    }
                }
            //    Scope.Complete();
            //}
        }

    }
}
