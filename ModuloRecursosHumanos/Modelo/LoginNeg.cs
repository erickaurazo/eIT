using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModuloRecursosHumanos.Controller;
using System.Configuration;
using System.Data.SqlClient;
using RecursosHumanos.Datos;
using RRHH.Controller;

namespace ModuloRecursosHumanos.Modelo
{
    public class LoginNeg
    {
        private Boolean Validado;
        private RRHH.Controller.SJ_Usuario usuario;
        private List<Grupo> listadoBaseDatos;
        private List<Grupo> listadoEmpresa;
        private Grupo Empresa;
        private Grupo BaseDatos;


        public Boolean VerificarSesion(string user, string clave)
        {
            Validado = false;
            string cnx = string.Empty;
            try
            {
                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

                using (ModeloRecursosHumanosEASJDataContext contexto = new ModeloRecursosHumanosEASJDataContext(cnx))
                {
                    #region
                    if (contexto.SJ_Usuario.Where(x => x.IdUsuario == user && x.Password == clave && x.Estado == 1).ToList().Count == 1)
                    {
                        usuario = new RRHH.Controller.SJ_Usuario();
                        usuario = contexto.SJ_Usuario.Where(x => x.IdUsuario == user && x.Password == clave && x.Estado == 1).Single();
                        Validado = true;
                    }
                    else
                    {
                        usuario = new RRHH.Controller.SJ_Usuario();
                        usuario.IdUsuario = "";
                        usuario.Password = "";
                        usuario.NivelAcceso = 'N';
                        usuario.Estado = 0;
                        Validado = false;
                    }
                    #endregion
                }
            }

            catch (SqlException Ex)
            {
                throw Ex;
            }

            catch (Exception Ex)
            {

                throw Ex;
            }



            return Validado;
        }

        public RRHH.Controller.SJ_Usuario ObtenerUsuario(string user, string clave)
        {
            Validado = false;
            string cnx = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (ModeloRecursosHumanosEASJDataContext contexto = new ModeloRecursosHumanosEASJDataContext(cnx))
            {
                if (contexto.SJ_Usuario.Where(x => x.IdUsuario == user && x.Password == clave && x.Estado == 1).ToList().Count == 1)
                {
                    usuario = new RRHH.Controller.SJ_Usuario();
                    usuario = contexto.SJ_Usuario.Where(x => x.IdUsuario == user && x.Password == clave && x.Estado == 1).Single();
                    Validado = true;
                }
                else
                {
                    usuario = new RRHH.Controller.SJ_Usuario();
                    usuario.IdUsuario = "";
                    usuario.Password = "";
                    usuario.NivelAcceso = 'N';
                    usuario.Estado = 0;
                    Validado = false;
                }
            }

            return usuario;
        }

        public List<Grupo> ListarBasesDatos()
        {
            listadoBaseDatos = new List<Grupo>();
            BaseDatos = new Grupo();
            BaseDatos.Id = "01";
            BaseDatos.Descripcion = "agricolasanjuan2014".ToString().ToUpper();
            listadoBaseDatos.Add(BaseDatos);

            return listadoBaseDatos;
        }

        public List<Grupo> ListarEmpresa()
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            try
            {
                using (ModeloRecursosHumanosEASJDataContext contexto = new ModeloRecursosHumanosEASJDataContext(cnx))
                {
                    listadoEmpresa = new List<Grupo>();
                    Empresa = new Grupo();
                    Empresa.Id = contexto.EMPRESAS.FirstOrDefault().IDEMPRESA.ToString().Trim().ToUpper();
                    Empresa.Descripcion = contexto.EMPRESAS.FirstOrDefault().RAZON_SOCIAL.ToString().Trim().ToUpper();
                    listadoEmpresa.Add(Empresa);
                }
            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }



            return listadoEmpresa;

        }






    }
}
