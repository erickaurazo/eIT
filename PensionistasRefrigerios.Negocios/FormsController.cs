using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Asistencia.Datos;
using System.Configuration;

namespace Asistencia.Negocios
{
    public class FormsController
    {
        public List<FormularioSistema> GetListForms(string periodo)
        {
            var result = new List<FormularioSistema>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo];
            using (BDAsistenciaDataContext contexto = new BDAsistenciaDataContext(cnx))
            {
                return contexto.FormularioSistema.ToList();
            }
            return result;
        }


        public bool Add(string periodo, FormularioSistema form)
        {
            bool status = false;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo];
            using (BDAsistenciaDataContext contexto = new BDAsistenciaDataContext(cnx))
            {
                var result = contexto.FormularioSistema.Where(x => x.formularioCodigo.Trim() == form.formularioCodigo.Trim()).ToList();

                if (result != null && result.ToList().Count == 0)
                {
                    int maxResult = (
                        contexto.FormularioSistema.ToList().Count > 0 ?
                        Convert.ToInt32(contexto.FormularioSistema.ToList().Max(x => x.formularioCodigo.Trim()))
                        : 0
                        ) + 1;
                    #region Add() 
                    FormularioSistema oForm = new FormularioSistema();
                    oForm.formularioCodigo = maxResult.ToString().PadLeft(3, '0');
                    oForm.moduloCodigo = form.Jerarquia.Substring(0, 3);
                    oForm.descripcion = form.descripcion != null ? form.descripcion.Trim() : string.Empty;
                    oForm.nombreEnSistema = form.nombreEnSistema != null ? form.nombreEnSistema.Trim() : string.Empty;
                    oForm.estado = 1;
                    oForm.EsModuloPrincipal = 0;
                    oForm.Jerarquia = ObtenerJerarquía(periodo, form.Jerarquia);
                    oForm.formulario = form.formulario != null ? form.formulario.Trim() : string.Empty;
                    oForm.barraPadre = form.Jerarquia != null ? form.Jerarquia.Trim() : string.Empty;

                    contexto.FormularioSistema.InsertOnSubmit(oForm);
                    contexto.SubmitChanges();
                    status = true;
                    #endregion
                }
                else if (result != null && result.ToList().Count == 1)
                {
                    #region Update() 
                    FormularioSistema oForm = new FormularioSistema();
                    oForm = result.Single();
                    oForm.descripcion = form.descripcion.Trim();
                    oForm.nombreEnSistema = form.nombreEnSistema.Trim();
                    contexto.SubmitChanges();
                    status = true;
                    #endregion
                }
            }

            return status;
        }

        private string ObtenerJerarquía(string periodo, string jerarquia)
        {
            string cnx, hierarchy = string.Empty;            
            cnx = ConfigurationManager.AppSettings["bd" + periodo];
            using (BDAsistenciaDataContext contexto = new BDAsistenciaDataContext(cnx))
            {
                //maxResult = (
                //    contexto.FormularioSistema.ToList().Count > 0 ? 
                //    Convert.ToInt32(contexto.FormularioSistema.Where(x => x.Jerarquia.Trim() == jerarquia).Max(x => x.formularioCodigo.Substring(1,jerarquia.Length))) 
                //    : 0) 
                //    + 1;
                var result = contexto.FormularioSistema.Where(x => x.barraPadre.Trim() == jerarquia.Trim()).ToList();
                if (result.Count == 0)
                {
                    hierarchy = jerarquia.Trim() + "." + "001";
                }
                else if (result.Count > 0)
                {
                    var aa = result.Max(x => x.Jerarquia.Trim()).Trim();
                    int lenHasta = aa.Length;
                    int lenDesde = jerarquia.Trim().Length;
                    int lenDif = lenHasta - lenDesde;
                    var NewString = aa.Substring(lenDesde, lenDif).TrimStart('.');
                    int ff = Convert.ToInt32(NewString) + 1;
                    hierarchy = jerarquia.Trim() + "." + ff.ToString().PadLeft(3, '0');
                }

            }


            return hierarchy;
        }

        public bool Remove(string periodo, FormularioSistema form)
        {
            bool status = false;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo];
            using (BDAsistenciaDataContext contexto = new BDAsistenciaDataContext(cnx))
            {
                var result = contexto.FormularioSistema.Where(x => x.formularioCodigo.Trim() == form.formularioCodigo.Trim()).ToList();

                if (result != null && result.ToList().Count == 1)
                {
                    #region Update() 
                    FormularioSistema oForm = new FormularioSistema();
                    oForm = result.Single();
                    if (oForm.formulario.Trim() != "SubMenu" && (oForm.formulario.Trim() != "Menu"))
                    {
                        var privilegesByUser = contexto.PrivilegioFormulario.Where(x => x.formularioCodigo.Trim() == form.formularioCodigo.Trim()).ToList();
                        contexto.PrivilegioFormulario.DeleteAllOnSubmit(privilegesByUser);
                        contexto.FormularioSistema.DeleteOnSubmit(oForm);
                        contexto.SubmitChanges();
                        status = true;
                    }

                    #endregion
                }
            }

            return status;
        }

        public bool ChangeStatus(string periodo, FormularioSistema form)
        {
            bool status = false;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo];
            using (BDAsistenciaDataContext contexto = new BDAsistenciaDataContext(cnx))
            {
                var result = contexto.FormularioSistema.Where(x => x.formularioCodigo.Trim() == form.formularioCodigo.Trim()).ToList();

                if (result != null && result.ToList().Count == 1)
                {
                    #region Update() 
                    FormularioSistema oForm = new FormularioSistema();
                    oForm = result.Single();
                    
                    if (oForm.estado == 1)
                    {
                        oForm.estado = 0;
                    }
                    else
                    {
                        oForm.estado = 1;
                    }

                    contexto.SubmitChanges();
                    status = true;
                    #endregion
                }
            }

            return status;
        }
    }
}
