using Asistencia.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;

namespace Asistencia.Helper
{
    public class TreeviewHelper
    {
        public RadTreeView BuildTreeViewForms(RadTreeView myTreeview, List<FormularioSistema> forms)
        {
            myTreeview.Nodes.Clear();

            if (forms != null && forms.ToList().Count > 1)
            {
                // obtener sólo módulos y agregarlo

                var modules = (from item in forms
                               where item.EsModuloPrincipal == 1
                               group item by new { item.moduloCodigo } into j
                               select new
                               {
                                   Id = j.Key.moduloCodigo.Trim(),
                                   Description = j.FirstOrDefault().descripcion != null ? j.FirstOrDefault().descripcion.Trim() : string.Empty,
                                   idFormulario = j.FirstOrDefault().formularioCodigo != null ? j.FirstOrDefault().formularioCodigo.Trim() : string.Empty,
                               }
                           ).ToList();

                if (modules != null && modules.OrderBy(x => x.Id).ToList().Count > 1)
                {
                    #region 
                    foreach (var modul in modules)
                    {
                        #region 
                        RadTreeNode root = myTreeview.Nodes.Add(modul.idFormulario.Trim(), modul.Description.Trim(), 1);
                        // obtener si este módulo tiene hijos.
                        var resultList01 = forms.Where(x => x.moduloCodigo.Trim() == modul.Id.Trim() && x.EsModuloPrincipal == 0).ToList();
                        var itemsByModul = (from item in resultList01
                                            group item by new { item.formularioCodigo } into j
                                            select new
                                            {
                                                IdSubForm = j.Key.formularioCodigo.Trim(),
                                                Description = j.FirstOrDefault().descripcion != null ? j.FirstOrDefault().descripcion.Trim() : string.Empty,
                                                Jerarquia = j.FirstOrDefault().Jerarquia.Trim(),
                                            }).ToList();

                        List<FormularioSistema> listadoAgregados = new List<FormularioSistema>();
                        if (itemsByModul != null && itemsByModul.ToList().Count > 0)
                        {
                            #region 
                            foreach (var subForm in itemsByModul)
                            {
                                #region 
                                var itemsBySubModul = forms.Where(x => x.barraPadre.Trim() == subForm.Jerarquia.Trim()).ToList();
                                // por cada submenu verificar si tiene hijos, si no tiene hijos agrego una jerarquia
                                // caso contratio creo un nuevo submenu
                                if (itemsBySubModul != null && itemsBySubModul.ToList().Count == 0)
                                {
                                    if (listadoAgregados.Where(x => x.formularioCodigo.Trim() == (subForm.IdSubForm.Trim())).ToList().Count == 0)
                                    {
                                        root.Nodes.Add(subForm.IdSubForm.Trim(), subForm.Description.Trim(), 2);
                                        listadoAgregados.Add(new FormularioSistema { formularioCodigo = subForm.IdSubForm.Trim() });
                                    }

                                }
                                else if (itemsBySubModul != null && itemsBySubModul.ToList().Count > 0)
                                {
                                    #region MyRegion                                    
                                    //RadTreeNode folderSub01 = root.Nodes.Add(subForm.IdSubForm, subForm.Description, 2);

                                    if (listadoAgregados.Where(x => x.formularioCodigo.Trim() == (subForm.IdSubForm.Trim())).ToList().Count == 0)
                                    {

                                        RadTreeNode folderSub01 = root.Nodes.Add(subForm.IdSubForm.Trim(), subForm.Description.Trim(), 2);
                                        var itemsByForm = (from item in forms
                                                           where item.barraPadre.Trim() == subForm.Jerarquia.Trim() && item.EsModuloPrincipal == 0
                                                           group item by new { item.formularioCodigo } into j
                                                           select new
                                                           {
                                                               IdSubForm02 = j.Key.formularioCodigo,
                                                               Description02 = j.FirstOrDefault().descripcion != null ? j.FirstOrDefault().descripcion.Trim() : string.Empty,
                                                               Jerarquia02 = j.FirstOrDefault().Jerarquia != null ? j.FirstOrDefault().Jerarquia.Trim() : string.Empty,
                                                           }).ToList();
                                        foreach (var itemForm in itemsByForm)
                                        {
                                            #region
                                            var itemsByForm02 = (from item in forms
                                                                 where item.barraPadre.Trim() == itemForm.Jerarquia02.Trim() && item.EsModuloPrincipal == 0
                                                                 group item by new { item.formularioCodigo } into j
                                                                 select new
                                                                 {
                                                                     IdSubForm03 = j.Key.formularioCodigo,
                                                                     Description03 = j.FirstOrDefault().descripcion != null ? j.FirstOrDefault().descripcion.Trim() : string.Empty,
                                                                     Jerarquia03 = j.FirstOrDefault().Jerarquia != null ? j.FirstOrDefault().Jerarquia.Trim() : string.Empty,
                                                                 }).ToList();

                                            // el el subnivel tiene más subniveles entonces verifico
                                            if (itemsByForm02 != null && itemsByForm02.ToList().Count == 0)
                                            {
                                                if (listadoAgregados.Where(x => x.formularioCodigo.Trim() == (itemForm.IdSubForm02.Trim())).ToList().Count == 0)
                                                {
                                                    folderSub01.Nodes.Add(itemForm.IdSubForm02.Trim(), itemForm.Description02.Trim(), 3);
                                                    listadoAgregados.Add(new FormularioSistema { formularioCodigo = itemForm.IdSubForm02.Trim() });
                                                }

                                            }
                                            else if (itemsByForm02 != null && itemsByForm02.ToList().Count > 0)
                                            {
                                                #region
                                                if (listadoAgregados.Where(x => x.formularioCodigo.Trim() == (itemForm.IdSubForm02.Trim())).ToList().Count == 0)
                                                {
                                                    RadTreeNode folderSub02 = folderSub01.Nodes.Add(itemForm.IdSubForm02.Trim(), itemForm.Description02.Trim(), 2);
                                                    listadoAgregados.Add(new FormularioSistema { formularioCodigo = itemForm.IdSubForm02.Trim() });

                                                    var itemsByForm03 = (from item in forms
                                                                         where item.barraPadre.Trim() == itemForm.Jerarquia02.Trim() && item.EsModuloPrincipal == 0
                                                                         group item by new { item.formularioCodigo } into j
                                                                         select new
                                                                         {
                                                                             IdSubForm03 = j.Key.formularioCodigo,
                                                                             Description03 = j.FirstOrDefault().descripcion != null ? j.FirstOrDefault().descripcion.Trim() : string.Empty,
                                                                             Jerarquia03 = j.FirstOrDefault().Jerarquia != null ? j.FirstOrDefault().Jerarquia.Trim() : string.Empty,
                                                                         }).ToList();

                                                    foreach (var itemForm03 in itemsByForm03)
                                                    {
                                                        #region
                                                        var itemsByForm04 = (from item in forms
                                                                             where item.barraPadre.Trim() == itemForm03.Jerarquia03.Trim() && item.EsModuloPrincipal == 0
                                                                             group item by new { item.formularioCodigo } into j
                                                                             select new
                                                                             {
                                                                                 IdSubForm03 = j.Key.formularioCodigo,
                                                                                 Description03 = j.FirstOrDefault().descripcion != null ? j.FirstOrDefault().descripcion.Trim() : string.Empty,
                                                                                 Jerarquia03 = j.FirstOrDefault().Jerarquia != null ? j.FirstOrDefault().Jerarquia.Trim() : string.Empty,
                                                                             }).ToList();

                                                        if (itemsByForm04 != null && itemsByForm04.ToList().Count == 0)
                                                        {
                                                            if (listadoAgregados.Where(x => x.formularioCodigo.Trim() == (itemForm03.IdSubForm03.Trim())).ToList().Count == 0)
                                                            {
                                                                folderSub02.Nodes.Add(itemForm03.IdSubForm03, itemForm03.Description03, 3);
                                                                listadoAgregados.Add(new FormularioSistema { formularioCodigo = itemForm03.IdSubForm03.Trim() });
                                                            }

                                                        }
                                                        else if (itemsByForm04 != null && itemsByForm04.ToList().Count > 0)
                                                        {
                                                            if (listadoAgregados.Where(x => x.formularioCodigo.Trim() == (itemForm03.IdSubForm03.Trim())).ToList().Count == 0)
                                                            {
                                                                RadTreeNode folderSub03 = folderSub02.Nodes.Add(itemForm03.IdSubForm03, itemForm03.Description03, 2);
                                                                listadoAgregados.Add(new FormularioSistema { formularioCodigo = itemForm03.IdSubForm03.Trim() });
                                                            }

                                                        }
                                                        #endregion
                                                    }
                                                    #endregion
                                                }
                                            }
                                            #endregion
                                        }
                                    }


                                    #endregion
                                }
                                #endregion  
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }
            }
            return myTreeview;
        }
    }
}