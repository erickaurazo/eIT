using Asistencia.Datos;
using Asistencia.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;


namespace Asistencia.Helper
{
    public class ComboBoxHelper
    {

        public List<Grupo> GetComboBoxStatus()
        {
            List<Grupo> result = new List<Grupo>();
            result.Add(new Grupo { Code = 1, Descripcion = "Activo" });
            result.Add(new Grupo { Code = 0, Descripcion = "ANULADO" });
            return result;
        }

        public List<Grupo> GetComboBoxModule(string periodo)
        {
            ModuloSistemaController model = new ModuloSistemaController();
            var modules = new List<ModuleSystem>();
            modules = model.GetListAll(periodo);
            var result = (from item in modules
                          where item.moduloCodigo != null && item.moduloCodigo.Trim() != string.Empty
                          group item by new { item.moduloCodigo } into j
                          select new Grupo
                          {
                              Codigo = j.Key.moduloCodigo.Trim(),
                              Descripcion = j.FirstOrDefault().descripcion != null ? j.FirstOrDefault().descripcion.Trim() : string.Empty
                          }
                          ).ToList();

            return result;
        }

        public List<Grupo> GetComboBoxHierarchy(List<FormularioSistema> forms)
        {
            var result = new List<Grupo>();
            if (forms != null && forms.ToList().Count > 0)
            {
                result = (from item in forms
                          where item.Jerarquia != null && item.Jerarquia.Trim() != string.Empty
                          group item by new { item.Jerarquia } into j
                          select new Grupo
                          {
                              Codigo = j.Key.Jerarquia.Trim(),
                              Descripcion = j.FirstOrDefault().descripcion != null ? j.FirstOrDefault().descripcion.Trim() : string.Empty
                          }
                         ).ToList();
            }


            return result;
        }

        public List<Grupo> GetComboBoxTypeForm(List<FormularioSistema> forms)
        {
            var result = new List<Grupo>();
            if (forms != null && forms.ToList().Count > 0)
            {
                result = (from item in forms
                          where item.formulario != null && item.formulario.Trim() != string.Empty
                          group item by new { item.formulario } into j
                          select new Grupo
                          {
                              Codigo = j.Key.formulario.Trim(),
                              Descripcion = j.Key.formulario.Trim()
                          }
                         ).ToList();
            }


            return result;
        }

        public List<Grupo> GetComboBoxParentForm(List<FormularioSistema> forms)
        {
            var result = new List<Grupo>();
            var formModul = forms;

            if (forms != null && forms.ToList().Count > 0)
            {
                result = (from item in forms
                          where item.barraPadre != null && item.barraPadre.Trim() != string.Empty
                          group item by new { item.barraPadre } into j
                          select new Grupo
                          {
                              Codigo = j.Key.barraPadre.Trim(),
                              Descripcion = formModul.Where(
                                  x => x.moduloCodigo.Trim() == j.Key.barraPadre.Trim()) != null ? 
                                  formModul.Where(x => x.Jerarquia.Trim() == j.Key.barraPadre.Trim()).Single().descripcion : 
                                  string.Empty
                          }
                         ).ToList();
            }

            return result;
        }


    }
}
