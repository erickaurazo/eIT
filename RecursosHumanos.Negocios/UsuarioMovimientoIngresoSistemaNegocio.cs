using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Configuration;

namespace RecursosHumanos.Negocios
{
    public class UsuarioMovimientoIngresoSistemaNegocio
    {

        public void Registrar(UsuarioMovimientoIngresoSistema movimientoUsuario, string periodo)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim().Substring(0, 4)].ToString().Trim();

            using (ExoticsModelDataContext contexto = new ExoticsModelDataContext(cnx))
            {

                var BucarCoincidencia = contexto.UsuarioMovimientoIngresoSistema.Where(x => x.codigoAcceso == movimientoUsuario.codigoAcceso).ToList();
                if (BucarCoincidencia != null && BucarCoincidencia.ToList().Count > 0)
                {
                    #region Editar
                    UsuarioMovimientoIngresoSistema usuarioMovimientoIngresoSistema = new UsuarioMovimientoIngresoSistema();
                    usuarioMovimientoIngresoSistema = contexto.UsuarioMovimientoIngresoSistema.Where(x => x.codigoAcceso == movimientoUsuario.codigoAcceso).Single();
                    //usuarioMovimientoIngresoSistema.codigoAcceso = movimientoUsuario.codigoAcceso;
                    //usuarioMovimientoIngresoSistema.IdUsuario = movimientoUsuario.IdUsuario;
                    usuarioMovimientoIngresoSistema.periodoElegido = movimientoUsuario.periodoElegido;
                    usuarioMovimientoIngresoSistema.codigoPlanillaElegida = movimientoUsuario.codigoPlanillaElegida;
                    usuarioMovimientoIngresoSistema.semanaPlanillaElegida = movimientoUsuario.semanaPlanillaElegida;
                    usuarioMovimientoIngresoSistema.fechaAcceso = DateTime.Now;
                    //contexto.UsuarioMovimientoIngresoSistema.InsertOnSubmit(usuarioMovimientoIngresoSistema);
                    contexto.SubmitChanges();
                    #endregion
                }
                else
                {
                    #region Nuevo
                    UsuarioMovimientoIngresoSistema usuarioMovimientoIngresoSistema = new UsuarioMovimientoIngresoSistema();
                    usuarioMovimientoIngresoSistema.codigoAcceso = movimientoUsuario.codigoAcceso;
                    usuarioMovimientoIngresoSistema.IdUsuario = movimientoUsuario.IdUsuario;
                    usuarioMovimientoIngresoSistema.periodoElegido = movimientoUsuario.periodoElegido;
                    usuarioMovimientoIngresoSistema.codigoPlanillaElegida = movimientoUsuario.codigoPlanillaElegida;
                    usuarioMovimientoIngresoSistema.semanaPlanillaElegida = movimientoUsuario.semanaPlanillaElegida;
                    usuarioMovimientoIngresoSistema.fechaAcceso = DateTime.Now;
                    contexto.UsuarioMovimientoIngresoSistema.InsertOnSubmit(usuarioMovimientoIngresoSistema);
                    contexto.SubmitChanges();
                    #endregion

                }

                contexto.Dispose();


            }
        }

        public UsuarioMovimientoIngresoSistema ObtenerRegistroPorCodigo(UsuarioMovimientoIngresoSistema movimientoUsuario, string periodo)
        {
            UsuarioMovimientoIngresoSistema usuarioMovimientoIngresoSistema = new UsuarioMovimientoIngresoSistema();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim().Substring(0, 4)].ToString().Trim();

            using (ExoticsModelDataContext contexto = new ExoticsModelDataContext(cnx))
            {

                var BucarCoincidencia = contexto.UsuarioMovimientoIngresoSistema.Where(x => x.codigoAcceso == movimientoUsuario.codigoAcceso).ToList();
                if (BucarCoincidencia != null && BucarCoincidencia.ToList().Count == 1)
                {
                    #region Editar
                    usuarioMovimientoIngresoSistema = new UsuarioMovimientoIngresoSistema();
                    usuarioMovimientoIngresoSistema = contexto.UsuarioMovimientoIngresoSistema.Where(x => x.codigoAcceso == movimientoUsuario.codigoAcceso).Single();
                    //usuarioMovimientoIngresoSistema.codigoAcceso = movimientoUsuario.codigoAcceso;
                    //usuarioMovimientoIngresoSistema.IdUsuario = movimientoUsuario.IdUsuario;
                    usuarioMovimientoIngresoSistema.periodoElegido = movimientoUsuario.periodoElegido;
                    usuarioMovimientoIngresoSistema.codigoPlanillaElegida = movimientoUsuario.codigoPlanillaElegida;
                    usuarioMovimientoIngresoSistema.semanaPlanillaElegida = movimientoUsuario.semanaPlanillaElegida;
                    usuarioMovimientoIngresoSistema.fechaAcceso = DateTime.Now;
                    //contexto.UsuarioMovimientoIngresoSistema.InsertOnSubmit(usuarioMovimientoIngresoSistema);
                    contexto.SubmitChanges();
                    #endregion
                }

                return usuarioMovimientoIngresoSistema;

            }
        }

        public void ActualizarPeriodo(UsuarioMovimientoIngresoSistema movimientoUsuario, string periodo)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim().Substring(0, 4)].ToString().Trim();

            using (ExoticsModelDataContext contexto = new ExoticsModelDataContext(cnx))
            {

                var BucarCoincidencia = contexto.UsuarioMovimientoIngresoSistema.Where(x => x.codigoAcceso == movimientoUsuario.codigoAcceso).ToList();
                if (BucarCoincidencia != null && BucarCoincidencia.ToList().Count > 0)
                {
                    #region Editar
                    UsuarioMovimientoIngresoSistema usuarioMovimientoIngresoSistema = new UsuarioMovimientoIngresoSistema();
                    usuarioMovimientoIngresoSistema = contexto.UsuarioMovimientoIngresoSistema.Where(x => x.codigoAcceso == movimientoUsuario.codigoAcceso).Single();
                    //usuarioMovimientoIngresoSistema.codigoAcceso = movimientoUsuario.codigoAcceso;
                    //usuarioMovimientoIngresoSistema.IdUsuario = movimientoUsuario.IdUsuario;
                    usuarioMovimientoIngresoSistema.periodoElegido = movimientoUsuario.periodoElegido;
                    //usuarioMovimientoIngresoSistema.codigoPlanillaElegida = movimientoUsuario.codigoPlanillaElegida;
                    //usuarioMovimientoIngresoSistema.semanaPlanillaElegida = movimientoUsuario.semanaPlanillaElegida;
                    usuarioMovimientoIngresoSistema.fechaAcceso = DateTime.Now;
                    //contexto.UsuarioMovimientoIngresoSistema.InsertOnSubmit(usuarioMovimientoIngresoSistema);
                    contexto.SubmitChanges();
                    #endregion
                }


                contexto.Dispose();


            }
        }

        public void ActualizarPlanilla(UsuarioMovimientoIngresoSistema movimientoUsuario, string periodo)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim().Substring(0, 4)].ToString().Trim();

            using (ExoticsModelDataContext contexto = new ExoticsModelDataContext(cnx))
            {

                var BucarCoincidencia = contexto.UsuarioMovimientoIngresoSistema.Where(x => x.codigoAcceso == movimientoUsuario.codigoAcceso).ToList();
                if (BucarCoincidencia != null && BucarCoincidencia.ToList().Count > 0)
                {
                    #region Editar
                    UsuarioMovimientoIngresoSistema usuarioMovimientoIngresoSistema = new UsuarioMovimientoIngresoSistema();
                    usuarioMovimientoIngresoSistema = contexto.UsuarioMovimientoIngresoSistema.Where(x => x.codigoAcceso == movimientoUsuario.codigoAcceso).Single();
                    //usuarioMovimientoIngresoSistema.codigoAcceso = movimientoUsuario.codigoAcceso;
                    //usuarioMovimientoIngresoSistema.IdUsuario = movimientoUsuario.IdUsuario;
                    //usuarioMovimientoIngresoSistema.periodoElegido = movimientoUsuario.periodoElegido;
                    usuarioMovimientoIngresoSistema.codigoPlanillaElegida = movimientoUsuario.codigoPlanillaElegida;
                    usuarioMovimientoIngresoSistema.semanaPlanillaElegida = movimientoUsuario.semanaPlanillaElegida;
                    usuarioMovimientoIngresoSistema.fechaAcceso = DateTime.Now;
                    usuarioMovimientoIngresoSistema.desde = movimientoUsuario.desde;
                    usuarioMovimientoIngresoSistema.hasta = movimientoUsuario.hasta;

                    //contexto.UsuarioMovimientoIngresoSistema.InsertOnSubmit(usuarioMovimientoIngresoSistema);
                    contexto.SubmitChanges();
                    #endregion
                }

                contexto.Dispose();


            }
        }


        public UsuarioMovimientoIngresoSistema ObtenerMovimientoIngresoSistemaByCodigoMovimiento(UsuarioMovimientoIngresoSistema oUsuario)
        {
            UsuarioMovimientoIngresoSistema usuario = new UsuarioMovimientoIngresoSistema();
            string cnx = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (ExoticsModelDataContext contexto = new ExoticsModelDataContext(cnx))
            {
                var resultadoConsulta = contexto.UsuarioMovimientoIngresoSistema.Where(x => x.codigoAcceso == oUsuario.codigoAcceso).ToList();

                if (resultadoConsulta.ToList().Count == 1)
                {
                    usuario = resultadoConsulta.Single();
                }

            }
            return usuario;
        }





    }
}
