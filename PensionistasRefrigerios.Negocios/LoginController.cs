using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Asistencia.Datos;
using System.Net;

namespace Asistencia.Negocios
{
    public class LoginController
    {
        private Boolean Validado;
        private ASJ_USUARIOS oSJUsuario;
        private List<Grupo> listadoBaseDatos;
        private List<Grupo> listadoEmpresa;
        private Grupo Empresa;
        private Grupo oBaseDatos;

        public Boolean VerificarSesion(string user, string clave)
        {
            Validado = false;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year];
            using (BDAsistenciaDataContext contexto = new BDAsistenciaDataContext(cnx))
            {
                if (contexto.ASJ_USUARIOS.Where(x => x.IdUsuario == user && x.Password == clave && x.idestado == "1").ToList().Count == 1)
                {
                    oSJUsuario = new ASJ_USUARIOS();
                    oSJUsuario = contexto.ASJ_USUARIOS.Where(x => x.IdUsuario == user && x.Password == clave && x.idestado == "1").Single();
                    Validado = true;
                }
                else
                {
                    oSJUsuario = new ASJ_USUARIOS() { IdUsuario = "", Password = "", nivel = "1", idestado = "0" };
                    Validado = false;
                }
            }

            return Validado;
        }

        public ASJ_USUARIOS ObtenerUsuario(string user, string clave)
        {
            Validado = false;
            string cnx = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year];

            using (BDAsistenciaDataContext contexto = new BDAsistenciaDataContext(cnx))
            {
                if (contexto.ASJ_USUARIOS.Where(x => x.IdUsuario == user && x.Password == clave && x.idestado == "1").ToList().Count == 1)
                {
                    oSJUsuario = new ASJ_USUARIOS();
                    oSJUsuario = contexto.ASJ_USUARIOS.Where(x => x.IdUsuario == user && x.Password == clave && x.idestado == "1").Single();
                    Validado = true;
                }
                else
                {
                    oSJUsuario = new ASJ_USUARIOS() { IdUsuario = "", Password = "", nivel = "1", idestado = "0" };
                    Validado = false;
                }
            }

            return oSJUsuario;
        }

        public List<Grupo> ListarBasesDatos()
        {
            bool resultadoConexionInternet = false;
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://www.google.com"))
                {
                    resultadoConexionInternet = true;
                }
            }
            catch
            {
                resultadoConexionInternet = false; ;
            }

            listadoBaseDatos = new List<Grupo>();
            if (resultadoConexionInternet == true)
            {
                oBaseDatos = new Grupo() { Id = "10", Descripcion = "AGRICOLA2017 | Publica".ToUpper() };
                listadoBaseDatos.Add(oBaseDatos);
            }

            //listadoBaseDatos = new List<Grupo>();
            oBaseDatos = new Grupo() { Id = "01", Descripcion = "AGRICOLA2017 | Local".ToUpper() };
            listadoBaseDatos.Add(oBaseDatos);

            return listadoBaseDatos;
        }

        public List<Grupo> ListarEmpresa()
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year];

            using (BDAsistenciaDataContext contexto = new BDAsistenciaDataContext(cnx))
            {
                listadoEmpresa = new List<Grupo>();
                Empresa = new Grupo() { Id = contexto.EMPRESAS.FirstOrDefault().IDEMPRESA != null ? contexto.EMPRESAS.FirstOrDefault().IDEMPRESA.Trim().ToUpper() : string.Empty, Descripcion = contexto.EMPRESAS.FirstOrDefault().RAZON_SOCIAL != null ? contexto.EMPRESAS.FirstOrDefault().RAZON_SOCIAL.Trim().ToUpper() : string.Empty };
                listadoEmpresa.Add(Empresa);
            }

            return listadoEmpresa;

        }
    }
}
