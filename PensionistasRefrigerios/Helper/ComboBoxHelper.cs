using Asistencia.Datos;
using Asistencia.Negocios;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System;

namespace Asistencia.Helper
{
    public class ComboBoxHelper
    {
        private CompaniesController companyModel;

        public List<Grupo> GetComboBoxStatus()
        {
            List<Grupo> result = new List<Grupo>();
            result.Add(new Grupo { Code = 1, Descripcion = "Activo" });
            result.Add(new Grupo { Code = 0, Descripcion = "Anulado" });
            return result;
        }

        public List<Grupo> GetComboBoxStatusUser()
        {
            List<Grupo> result = new List<Grupo>();
            result.Add(new Grupo { Codigo = "1", Descripcion = "Activo" });
            result.Add(new Grupo { Codigo = "0", Descripcion = "Anulado" });
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

        internal List<Grupo> GetDocumentSeriesForForm(string conection, string formulario)
        {
            List<Grupo> result = new List<Grupo>();
            if (formulario == "Equipamiento tecnologico")
            {
                result.Add(new Grupo { Codigo = "0001", Descripcion = "0001" });
            }
            
            return result;
        }

        internal List<Grupo> GetDocumentTypeForForm(string conection, string formulario)
        {
            List<Grupo> result = new List<Grupo>();
            if (formulario == "Equipamiento tecnologico")
            {
                result.Add(new Grupo { Codigo = "SOL", Descripcion = "SOL" });
            }

            return result;
        }

        internal List<Grupo> GetRequestTypes(string conection, string formulario)
        {
            List<Grupo> result = new List<Grupo>();
            if (formulario == "Equipamiento tecnologico")
            {
                result.Add(new Grupo { Codigo = "1", Descripcion = "Alta" });
                result.Add(new Grupo { Codigo = "2", Descripcion = "Modificación" });
                result.Add(new Grupo { Codigo = "3", Descripcion = "Baja" });
            }

            return result;
        }

        internal List<Grupo> GetComboBoxTypeOfSoftware(string conection)
        {
            List<Grupo> result = new List<Grupo>();
            List<SAS_DispositivoClasificacionDeSoftware> resultado = new List<SAS_DispositivoClasificacionDeSoftware>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                resultado = Modelo.SAS_DispositivoClasificacionDeSoftware.Where(x => x.estado == 1).ToList();
                foreach (var item in resultado)
                {
                    result.Add(new Grupo { Valor = item.ID.Trim(), Descripcion = item.descripcion.Trim(), Codigo = item.ID.Trim() });
                }
            }

            return result.OrderBy(x => x.Id).ToList();
        }

        public List<Grupo> GetComboBoxHierarchy(List<SAS_FormularioSistema> forms)
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

        public List<Grupo> GetComboBoxTypeForm(List<SAS_FormularioSistema> forms)
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

        public List<Grupo> GetComboBoxParentForm(List<SAS_FormularioSistema> forms)
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

        public List<Grupo> GetComboBoxLocal()
        {
            List<Grupo> result = new List<Grupo>();
            result.Add(new Grupo { Codigo = "000", Descripcion = "-- Seleccionar item --" });

            string cnx = ConfigurationManager.AppSettings["SAS"].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                // SELECT * FROM SAS_SegmentoRed WHERE ESSEDETRABAJO = 1
                
                var LugarDeTrabajo = Modelo.SAS_SegmentoRed.Where(x => x.esSedeTrabajo == 1).ToList();
                if (LugarDeTrabajo != null )
                {
                    if (LugarDeTrabajo.ToList().Count > 0)
                    {
                        foreach (var item in LugarDeTrabajo)
                        {
                            result.Add(new Grupo { Codigo =item.id.ToString(), Descripcion = item.descripcion });
                        }
                    }
                }
            }
            //result.Add(new Grupo { Codigo = "BALSA", Descripcion = "BALSA" });
            //result.Add(new Grupo { Codigo = "IMP", Descripcion = "IMP" });
            //result.Add(new Grupo { Codigo = "SAN JOSE", Descripcion = "SAN JOSE" });
            //result.Add(new Grupo { Codigo = "SANTA MARIA", Descripcion = "SANTA MARIA" });
            //result.Add(new Grupo { Codigo = "TABLAZO", Descripcion = "TABLAZO" });
            return result;
            
        }

        public List<Grupo> GetComboBoxAccessLevel()
        {
            List<Grupo> result = new List<Grupo>();
            result.Add(new Grupo { Codigo = "1", Descripcion = "Sin Acceso" });
            result.Add(new Grupo { Codigo = "2", Descripcion = "Administrador".ToUpper() });
            result.Add(new Grupo { Codigo = "3", Descripcion = "Usuario".ToUpper() });
            result.Add(new Grupo { Codigo = "4", Descripcion = "Soporte".ToUpper() });
            return result;
        }

        public List<Grupo> GetComboBoxBranchOffice()
        {
            List<Grupo> result = new List<Grupo>();
            //result.Add(new Grupo { Codigo = "0", Descripcion = "-- Seleccionar item --" });
            string cnx = ConfigurationManager.AppSettings["SAS"].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                var LugarDeTrabajo = Modelo.SUCURSALES.Where(x => x.ESTADO == 1).ToList();
                if (LugarDeTrabajo != null)
                {
                    if (LugarDeTrabajo.ToList().Count > 0)
                    {
                        foreach (var item in LugarDeTrabajo)
                        {
                            result.Add(new Grupo { Codigo = item.IDSUCURSAL, Descripcion = item.DESCRIPCION.Trim() });
                        }
                    }
                }
            }
            //result.Add(new Grupo { Codigo = "001", Descripcion = "Piura".ToUpper() });
            //result.Add(new Grupo { Codigo = "002", Descripcion = "Sullana".ToUpper() });
            //result.Add(new Grupo { Codigo = "003", Descripcion = "Catacaos".ToUpper() });
            return result;
            
        }

        public List<Grupo> GetComboBoxDoorAccess()
        {
            List<Grupo> result = new List<Grupo>();
            //result.Add(new Grupo { Codigo = "1", Descripcion = "-- Sin asignar --" });
            string cnx = ConfigurationManager.AppSettings["SAS"].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                var resultadoConsulta = Modelo.SAS_PuertaDeIngreso.Where(x => x.estado == 1).ToList();
                if (resultadoConsulta != null)
                {
                    if (resultadoConsulta.ToList().Count > 0)
                    {
                        foreach (var item in resultadoConsulta)
                        {
                            result.Add(new Grupo { Codigo = (item.id).ToString(), Descripcion = item.nombres });
                        }
                    }
                }
            }
                //result.Add(new Grupo { Codigo = "1", Descripcion = "BOTA" });
                //result.Add(new Grupo { Codigo = "2", Descripcion = "BALSA" });
                //result.Add(new Grupo { Codigo = "3", Descripcion = "TABLAZO" });
                //result.Add(new Grupo { Codigo = "4", Descripcion = "SANTA MARIA" });
                //result.Add(new Grupo { Codigo = "5", Descripcion = "IMP" });
                //result.Add(new Grupo { Codigo = "6", Descripcion = "PCK VID ASJ" });
                //result.Add(new Grupo { Codigo = "7", Descripcion = "PCK VID ASR" });
                //result.Add(new Grupo { Codigo = "8", Descripcion = "PCK BANANO" });
                //result.Add(new Grupo { Codigo = "9", Descripcion = "COMEDOR ASJ" });
                //result.Add(new Grupo { Codigo = "10", Descripcion = "COMEDOR PCK VID ASJ" });
                //result.Add(new Grupo { Codigo = "11", Descripcion = "COMEDOR PCK VID ASS" });
                return result;

        }
        public List<Grupo> GetComboBoxAreaAccess()
        {
            List<Grupo> result = new List<Grupo>();
            result.Add(new Grupo { Codigo = "000", Descripcion = "-- Seleccionar item --" });
            string cnx = ConfigurationManager.AppSettings["SAS"].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                var areasDeTrabajo = Modelo.AREAS.Where(x => x.ESTADO == 1).ToList();
                if (areasDeTrabajo != null)
                {
                    if (areasDeTrabajo.ToList().Count > 0)
                    {
                        foreach (var item in areasDeTrabajo)
                        {
                            result.Add(new Grupo { Codigo = item.IDAREA.Trim(), Descripcion = item.DESCRIPCION.Trim() });
                        }
                    }
                }
            }
            //result.Add(new Grupo { Codigo = "balsa".ToUpper(), Descripcion = "balsa".ToUpper() });
            //result.Add(new Grupo { Codigo = "Bota".ToUpper(), Descripcion = "Bota".ToUpper() });
            //result.Add(new Grupo { Codigo = "Imp".ToUpper(), Descripcion = "Imp".ToUpper() });
            //result.Add(new Grupo { Codigo = "RRHH".ToUpper(), Descripcion = "RRHH".ToUpper() });
            //result.Add(new Grupo { Codigo = "Sistemas".ToUpper(), Descripcion = "Sistemas".ToUpper() });
            //result.Add(new Grupo { Codigo = "Tablazo".ToUpper(), Descripcion = "Tablazo".ToUpper() });
            //result.Add(new Grupo { Codigo = "Transporte".ToUpper(), Descripcion = "Transporte".ToUpper() });
            //result.Add(new Grupo { Codigo = "VIGILANCIA".ToUpper(), Descripcion = "VIGILANCIA".ToUpper() });
            //result.Add(new Grupo { Codigo = "PCK ASJ".ToUpper(), Descripcion = "PCK ASJ".ToUpper() });
            //result.Add(new Grupo { Codigo = "PCK ASR".ToUpper(), Descripcion = "PCK ASR".ToUpper() });

            return result;
        }


        public List<Grupo> GetComboBoxDBsByLogin()
        {
            string cnx = string.Empty;
            var dbs = new List<Grupo>();
            dbs.Add(new Grupo { Codigo = "000", Descripcion = "Seleccionar item" });
            string path = Path.Combine(@"C:\SOLUTION\AsistenciaConfig.txt");
            path = Path.GetFullPath(path);
            string[] lines = System.IO.File.ReadAllLines(path);
            int count = 0;
            foreach (string line in lines)
            {
                count += 1;
                switch (count)
                {
                    case 1:
                        // dejalo pasar
                        break;

                    case 2:
                        // usuario que se conecta a la base de datos
                        break;

                    case 3:
                        // clave del usuario que se conecta a la base de datos
                        break;

                    case 4:
                        //Instancia local
                        break;

                    case 5:
                        //Instancia publica
                        break;

                    case 6:
                        //Base de datos 1
                        string[] db01 = line.Split(':');
                        dbs.Add(new Grupo { Codigo = "001", Descripcion = db01[1].Trim() });
                        break;

                    case 7:
                        //Base de datos 1
                        string[] db02 = line.Split(':');
                        dbs.Add(new Grupo { Codigo = "002", Descripcion = db02[1].Trim() });
                        break;

                    //case 8:
                    //    //Base de datos 1
                    //    string[] db03 = line.Split(':');
                    //    dbs.Add(new Grupo { Codigo = "003", Descripcion = db03[1].Trim() });
                    //    break;

                    //case 9:
                    //    //Base de datos 1
                    //    string[] db04 = line.Split(':');
                    //    dbs.Add(new Grupo { Codigo = "004", Descripcion = db04[1].Trim() });
                    //    break;

                    default:
                        break;
                }
                // Use a tab to indent each line of the file.               
            }

            return dbs.ToList();
        }

        public List<Grupo> GetComboBoxCompanysByLogin(string cnx)
        {
            var companies = new List<Grupo>();
            companyModel = new CompaniesController();
            companies = companyModel.ObtenerListadoDeEmpresas(cnx);
            return companies;
        }

        public List<Grupo> GetComboBoxCompanysById(string db, string idCompany)
        {
            string cnx = string.Empty;
            var companies = new List<Grupo>();
            companyModel = new CompaniesController();
            companies = companyModel.BuscarEmpresaPorId(db, idCompany);
            return companies;

        }


        public List<Grupo> GetComboBoxSedes(string db)
        {
            string cnx = string.Empty;
            var skils = new List<Grupo>();
            SedesController model = new SedesController();
            skils = model.FindSilks(db);
            return skils;

        }

        public List<Grupo> GetComboBoxTerms(string db)
        {
            string cnx = string.Empty;
            var tems = new List<Grupo>();
            TermController model = new TermController();
            tems = model.FindTerms(db);
            return tems;

        }


        public List<Grupo> GetComboBoxTypeOfDevices(string db)
        {
            string cnx = string.Empty;
            var TypeOfDevice = new List<Grupo>();
            DeviceTypeController model = new DeviceTypeController();
            TypeOfDevice = model.FindDeviceType(db);
            return TypeOfDevice;

        }


        public List<Grupo> TypeOfWorkAreas(string db)
        {
            List<Grupo> listado = new List<Grupo>();
            string cnx = ConfigurationManager.AppSettings[db].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                listado = (
                        from item in model.AREAS.Where(x => x.ESTADO == 1).ToList()
                        where item.IDAREA.Trim() != string.Empty
                        group item by new { item.IDAREA } into j
                        select new Grupo
                        {
                            Codigo = j.Key.IDAREA.Trim(),
                            Descripcion = j.FirstOrDefault().DESCRIPCION != null ? j.FirstOrDefault().DESCRIPCION.Trim() : string.Empty,
                        }
                        ).ToList();
            }
            return listado;

        }








        public List<Grupo> GetComboTypeWhereabouts()
        {
            List<Grupo> result = new List<Grupo>();
            result.Add(new Grupo { Codigo = "", Descripcion = "Seleccionar item" });
            result.Add(new Grupo { Codigo = "P", Descripcion = "PRINCIPAL" });
            result.Add(new Grupo { Codigo = "I", Descripcion = "INTERMEDIO" });

            return result.OrderBy(x => x.Codigo).ToList(); ;
        }


        public List<Grupo> GetComboMonthOfYear()
        {
            List<Grupo> result = new List<Grupo>();
            result.Add(new Grupo { Valor = "01", Descripcion = "ENERO" });
            result.Add(new Grupo { Valor = "02", Descripcion = "FEBRERO" });
            result.Add(new Grupo { Valor = "03", Descripcion = "MARZO" });
            result.Add(new Grupo { Valor = "04", Descripcion = "ABRIL" });
            result.Add(new Grupo { Valor = "05", Descripcion = "MAYO" });
            result.Add(new Grupo { Valor = "06", Descripcion = "JUNIO" });
            result.Add(new Grupo { Valor = "07", Descripcion = "JULIO" });
            result.Add(new Grupo { Valor = "08", Descripcion = "AGOSTO" });
            result.Add(new Grupo { Valor = "09", Descripcion = "SETIEMBRE" });
            result.Add(new Grupo { Valor = "10", Descripcion = "OCTUBRE" });
            result.Add(new Grupo { Valor = "11", Descripcion = "NOVIEMBRE" });
            result.Add(new Grupo { Valor = "12", Descripcion = "DICIEMBRE" });
            return result;
        }

        public List<Grupo> GetComboMonth()
        {
            List<Grupo> result = new List<Grupo>();
            result.Add(new Grupo { Valor = "00", Descripcion = "TODOS" });
            result.Add(new Grupo { Valor = "01", Descripcion = "ENERO" });
            result.Add(new Grupo { Valor = "02", Descripcion = "FEBRERO" });
            result.Add(new Grupo { Valor = "03", Descripcion = "MARZO" });
            result.Add(new Grupo { Valor = "04", Descripcion = "ABRIL" });
            result.Add(new Grupo { Valor = "05", Descripcion = "MAYO" });
            result.Add(new Grupo { Valor = "06", Descripcion = "JUNIO" });
            result.Add(new Grupo { Valor = "07", Descripcion = "JULIO" });
            result.Add(new Grupo { Valor = "08", Descripcion = "AGOSTO" });
            result.Add(new Grupo { Valor = "09", Descripcion = "SETIEMBRE" });
            result.Add(new Grupo { Valor = "10", Descripcion = "OCTUBRE" });
            result.Add(new Grupo { Valor = "11", Descripcion = "NOVIEMBRE" });
            result.Add(new Grupo { Valor = "12", Descripcion = "DICIEMBRE" });
            result.Add(new Grupo { Valor = "13", Descripcion = "PERSONALIZADO" });
            return result;
        }



        public List<Grupo> GetComboCultivosActivos(string conection)
        {
            List<Grupo> result = new List<Grupo>();
            List<CULTIVOS> resultado = new List<CULTIVOS>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Modelo = new SATURNODataContext(cnx))
            {
                resultado = Modelo.CULTIVOS.Where(x => x.ESTADO == 1).ToList();
                foreach (var item in resultado)
                {
                    result.Add(new Grupo { Valor = item.IDCULTIVO.Trim(), Descripcion = item.DESCRIPCION.Trim() });
                }
            }

            return result;
        }

    }
}

