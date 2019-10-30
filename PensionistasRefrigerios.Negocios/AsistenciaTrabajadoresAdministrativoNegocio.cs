using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransportistaMto.Datos;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using System.Data.OleDb;
using System.Data;

using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using System.Globalization;
using System.Data.Odbc;


namespace Transportista.Negocios
{
    public class AsistenciaTrabajadoresAdministrativoNegocio
    {
        private List<PersonalAdministrativo> listadoMarcacionAsistenciaDiaria;
        private string[] peopleList;
        private List<PersonalAdministrativo> listadoPersonal;
        private List<PersonalAdministrativo> ListadoObj;
        private TransportistaMto.Datos.PersonalAdministrativo objPersonalAdministrativo;
        private List<TransportistaMto.Datos.PersonalAdministrativo> listadoConsolidadMensualAsistencia;
        private List<TransportistaMto.Datos.oFechaAsistencia> listaFechaAsistencia;
        private TransportistaMto.Datos.PersonalAdministrativo consolidadMensualAsistencia;
        private List<TransportistaMto.Datos.PersonalAdministrativo> listadoPersonalAdm;
        private List<TransportistaMto.Datos.PersonalAdministrativo> listadoPersonalVid;
        private List<TransportistaMto.Datos.PersonalAdministrativo> listadoPersonalTaller;
        private List<TransportistaMto.Datos.PersonalAdministrativo> listadoPersonalPlanta;
        private List<TransportistaMto.Datos.PersonalAdministrativo> listadoPersonalEASJ;

        public List<PersonalAdministrativo> ObtenerListado(string desde, string hasta)
        {
            List<PersonalAdministrativo> listado = new List<PersonalAdministrativo>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            return listado;
        }

        /* distribucion del dia a día de las 6 marcaciones definidas */
        public List<PersonalAdministrativo> ObtenerListaMarcacionesTrabajadoresxDia(string desde, string hasta, int esAdministracion, int esVid, int esTaller, int esPlanta)
        {
            ListadoObj = new List<PersonalAdministrativo>();

            #region ObtenerTodasMarcacionesdelPersonal()

            try
            {
                //OleDbConnection MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=X:\\att.mdb ;Persist Security Info=False");
                OleDbConnection MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=Z:\\att.mdb ;Persist Security Info=False");
                OleDbDataAdapter MyAdapter = new OleDbDataAdapter("select USERID,  CHECKTIME from CHECKINOUT WHERE RTRIM(Memoinfo) IS NULL ", MyConnection);
                DataSet MyDataSet = new DataSet();

                MyConnection.Open();
                MyAdapter.Fill(MyDataSet);

                listadoMarcacionAsistenciaDiaria = new List<PersonalAdministrativo>();
                if (MyDataSet.Tables[0].Rows.Count > 0)
                {
                    peopleList = new string[MyDataSet.Tables[0].Rows.Count];

                    for (int i = 0; i < MyDataSet.Tables[0].Rows.Count; i++)
                    {
                        DataRow campo = MyDataSet.Tables[0].Rows[i];
                        PersonalAdministrativo obj = new PersonalAdministrativo();
                        obj.fecha = Convert.ToDateTime(campo["CHECKTIME"].ToString());
                        obj.codigoPersonal = (campo["USERID"].ToString());
                        listadoMarcacionAsistenciaDiaria.Add(obj);
                    }
                }
                MyConnection.Close();
            }
            catch
            {
                peopleList = null;
            }

            #endregion

            #region Obtener todos los trabajadores asignados para realizar Marcación diaría de trabajo()
            try
            {
                //OleDbConnection MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=X:\\att.mdb ;Persist Security Info=False");

                OleDbConnection MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=Z:\\att.mdb ;Persist Security Info=False");
                //\\192.168.30.99\BDAsistencia
                OleDbDataAdapter MyAdapter = new OleDbDataAdapter("select USERID, SSN, NAME , Street, Title from USERINFO", MyConnection);
                DataSet MyDataSet = new DataSet();

                MyConnection.Open();
                MyAdapter.Fill(MyDataSet);

                listadoPersonal = new List<PersonalAdministrativo>();
                listadoPersonalEASJ = new List<PersonalAdministrativo>();
                listadoPersonalAdm = new List<PersonalAdministrativo>();
                listadoPersonalVid = new List<PersonalAdministrativo>();
                listadoPersonalTaller = new List<PersonalAdministrativo>();
                listadoPersonalPlanta = new List<PersonalAdministrativo>();

                if (MyDataSet.Tables[0].Rows.Count > 0)
                {
                    peopleList = new string[MyDataSet.Tables[0].Rows.Count];

                    for (int i = 0; i < MyDataSet.Tables[0].Rows.Count; i++)
                    {
                        DataRow campo = MyDataSet.Tables[0].Rows[i];
                        PersonalAdministrativo obj = new PersonalAdministrativo();
                        obj.codigoPersonal = (campo["USERID"].ToString());
                        obj.personal = (campo["NAME"].ToString().Trim().ToUpper());
                        obj.areaTrabajo = (campo["Street"].ToString().Trim().ToUpper());
                        obj.cargo = (campo["Title"].ToString().Trim().ToUpper());
                        obj.nroDocumento = (campo["SSN"].ToString().Trim());
                        listadoPersonal.Add(obj);
                    }
                }
                MyConnection.Close();
            }
            catch { peopleList = null; }


            #region Obtener Personal (Sólo área consultadas)
            if (esAdministracion == 1)
            {
                listadoPersonalAdm = listadoPersonal.Where(x => x.areaTrabajo.ToString().Trim().ToUpper() == "ADMINISTRACION").ToList();
            }
            else
            {
                listadoPersonalAdm = new List<PersonalAdministrativo>();
            }


            if (esVid == 1)
            {
                listadoPersonalVid = listadoPersonal.Where(x => x.areaTrabajo.ToString().Trim().ToUpper() == "VID").ToList();
            }
            else
            {
                listadoPersonalVid = new List<PersonalAdministrativo>();
            }

            if (esTaller == 1)
            {
                listadoPersonalTaller = listadoPersonal.Where(x => x.areaTrabajo.ToString().Trim().ToUpper() == "TALLER").ToList();
            }
            else
            {
                listadoPersonalTaller = new List<PersonalAdministrativo>();
            }

            if (esPlanta == 1)
            {
                listadoPersonalPlanta = listadoPersonal.Where(x => x.areaTrabajo.ToString().Trim().ToUpper() == "PLANTA").ToList();
            }
            else
            {
                listadoPersonalPlanta = new List<PersonalAdministrativo>();
            }
            #endregion

            listadoPersonalEASJ.AddRange(listadoPersonalAdm);
            listadoPersonalEASJ.AddRange(listadoPersonalVid);
            listadoPersonalEASJ.AddRange(listadoPersonalTaller);
            listadoPersonalEASJ.AddRange(listadoPersonalPlanta);



            #endregion


            #region Cruzar listas Trabajadores vs Asistencias()

            try
            {
                var listadoMarcacionAsistenciaDiariaxPeriodo = listadoMarcacionAsistenciaDiaria.Where(x => x.fecha.Value >= Convert.ToDateTime(desde + " 00:00:00") && x.fecha.Value <= Convert.ToDateTime(hasta + " 23:59:59")).ToList();

                if (listadoMarcacionAsistenciaDiariaxPeriodo != null && listadoMarcacionAsistenciaDiariaxPeriodo.ToList().Count > 0)
                {
                    #region Obtener la lista de fechas de marcacion()
                    var filtrado = (from item in listadoMarcacionAsistenciaDiariaxPeriodo
                                    group item by new { item.fecha } into j
                                    select new
                                    {
                                        fecha = j.Key.fecha.Value.ToShortDateString()
                                    }).ToList();

                    /*Si se tiene una lista de fechas */
                    if (filtrado != null && filtrado.ToList().Count > 0)
                    {
                        #region
                        /*Obtener fechas en formato dd/mm/aaaa */
                        var filtradoFecha = (from item in filtrado
                                             group item by new { item.fecha } into j
                                             select new
                                             {
                                                 fecha = j.Key.fecha.ToString()
                                             }).ToList().OrderBy(x => x.fecha).ToList();

                        /* Si la nueva lista de fechas agrupadas con el formato dd/mm/aaaa */
                        if (filtradoFecha != null)
                        {
                            #region
                            foreach (var item in filtradoFecha)
                            {
                                #region MyRegion


                                /* Listado todas las asistencia de un día */
                                var listadoAsistenciaxFecha = listadoMarcacionAsistenciaDiariaxPeriodo.Where(x => x.fecha >= Convert.ToDateTime(item.fecha + " 00:00:00") && x.fecha <= Convert.ToDateTime(item.fecha + " 23:59:59")).OrderBy(x => x.fecha).ToList();

                                /*Obtengo la lista del personal administrativo, campo, taller y planta*/
                                var listaAsistenciaxPersonal = (from items in listadoPersonalEASJ
                                                                group items by new { items.codigoPersonal } into j
                                                                select new
                                                                {
                                                                    codigo = j.Key.codigoPersonal.ToString(),
                                                                    areaTrabajo = j.FirstOrDefault().areaTrabajo != null ? j.FirstOrDefault().areaTrabajo.ToString().Trim().ToUpper() : "",
                                                                }).ToList().OrderBy(x => x.codigo).ToList();


                                foreach (var personal in listaAsistenciaxPersonal)
                                {
                                    #region Asignar marcaciones por Personal()

                                    var MarcacionesPorPersonal = listadoAsistenciaxFecha.Where(x => x.codigoPersonal == personal.codigo).ToList();


                                    var PersonalxCodigo = listadoPersonalEASJ.Where(x => x.codigoPersonal == personal.codigo).ToList();
                                    DateTime? horaIngreso;
                                    if (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 0)
                                    {
                                        #region Registrar Marcaciones según horarios Administrativos()

                                        string condition;
                                        if (PersonalxCodigo.FirstOrDefault().personal != null)
                                            condition = PersonalxCodigo.FirstOrDefault().personal.ToString().Trim().ToUpper();
                                        else
                                            condition = "";
                                        objPersonalAdministrativo = new PersonalAdministrativo() { fecha = Convert.ToDateTime(item.fecha), diaSemana = Convert.ToDateTime(item.fecha).ToString("dddd", CultureInfo.CreateSpecificCulture("es-ES")).ToUpper().Trim(), codigoPersonal = personal.codigo, personal = condition, areaTrabajo = PersonalxCodigo.FirstOrDefault().areaTrabajo != null ? PersonalxCodigo.FirstOrDefault().areaTrabajo.ToString().Trim().ToUpper() : "", cargo = PersonalxCodigo.FirstOrDefault().cargo != null ? PersonalxCodigo.FirstOrDefault().cargo.ToString().Trim().ToUpper() : "", nroDocumento = PersonalxCodigo.FirstOrDefault().nroDocumento != null ? PersonalxCodigo.FirstOrDefault().nroDocumento.ToString().Trim().ToUpper() : "" };
                                        horaIngreso = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 0 && MarcacionesPorPersonal.FirstOrDefault().fecha != null) ? MarcacionesPorPersonal.ElementAt(0).fecha : (DateTime?)null;

                                        if (MarcacionesPorPersonal.ToList().Count >= 6 && MarcacionesPorPersonal.FirstOrDefault().fecha != null)
                                        {
                                            #region Marcacion Ideal(6 marcaciones)
                                            /* Cuando se marcan Ingreso, salidaDesayuno, regresoDesayuno salidaAlmuerzo, regresoAlmuerzo, salida */
                                            objPersonalAdministrativo.ingreso = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 0) ? MarcacionesPorPersonal.ElementAt(0).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.horaSalidaRefrigerioDesayuno = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 1) ? MarcacionesPorPersonal.ElementAt(1).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.horaRetornoRefrigerioDesayuno = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 2) ? MarcacionesPorPersonal.ElementAt(2).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.horaSalidaRefrigerio = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 3) ? MarcacionesPorPersonal.ElementAt(3).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.horaRetornoRefrigerio = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 4) ? MarcacionesPorPersonal.ElementAt(4).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.salida = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 5 ? MarcacionesPorPersonal.ElementAt(5).fecha : (DateTime?)null);

                                            #region Cacular horas trabajadas()
                                            TimeSpan tiempoAcumulado = MarcacionesPorPersonal.ElementAt(5).fecha.Value - MarcacionesPorPersonal.ElementAt(0).fecha.Value;
                                            TimeSpan tiempoAcumuladoDesayuno = MarcacionesPorPersonal.ElementAt(2).fecha.Value - MarcacionesPorPersonal.ElementAt(1).fecha.Value;
                                            TimeSpan tiempoAcumuladoAlmuerzo = MarcacionesPorPersonal.ElementAt(4).fecha.Value - MarcacionesPorPersonal.ElementAt(3).fecha.Value;
                                            TimeSpan tiempoRresultado = tiempoAcumulado - (tiempoAcumuladoDesayuno + tiempoAcumuladoAlmuerzo);
                                            //decimal? TiempoTrabajado = (tiempoAcumulado.Minutes - (tiempoAcumuladoDesayuno.Minutes + tiempoAcumuladoAlmuerzo.Minutes));
                                            #endregion
                                            objPersonalAdministrativo.HorasTrabajadas = Convert.ToDecimal((tiempoRresultado.Hours).ToString() + "." + tiempoRresultado.Minutes.ToString());

                                            #endregion
                                        }

                                        if (MarcacionesPorPersonal.ToList().Count == 5)
                                        {
                                            #region Cinco Marcaciones
                                            /* Generalmente cuando olvidan marcan alguna salida a refrigerio */
                                            objPersonalAdministrativo.ingreso = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 0 && MarcacionesPorPersonal.FirstOrDefault().fecha != null) ? MarcacionesPorPersonal.ElementAt(0).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.horaSalidaRefrigerioDesayuno = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 1 && MarcacionesPorPersonal.FirstOrDefault().fecha != null) ? MarcacionesPorPersonal.ElementAt(1).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.horaRetornoRefrigerioDesayuno = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 2 && MarcacionesPorPersonal.FirstOrDefault().fecha != null) ? MarcacionesPorPersonal.ElementAt(2).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.horaSalidaRefrigerio = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 3) ? MarcacionesPorPersonal.ElementAt(3).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.horaRetornoRefrigerio = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 4) ? MarcacionesPorPersonal.ElementAt(4).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.salida = (DateTime?)null;


                                            #region Cacular horas trabajadas()
                                            TimeSpan tiempoAcumulado = MarcacionesPorPersonal.ElementAt(4).fecha.Value - MarcacionesPorPersonal.ElementAt(0).fecha.Value;
                                            TimeSpan tiempoAcumuladoAlmuerzo = MarcacionesPorPersonal.ElementAt(3).fecha.Value - MarcacionesPorPersonal.ElementAt(2).fecha.Value;
                                            TimeSpan tiempoRresultado = tiempoAcumulado - tiempoAcumuladoAlmuerzo;

                                            #endregion
                                            objPersonalAdministrativo.HorasTrabajadas = Convert.ToDecimal((tiempoRresultado.Hours).ToString() + "." + tiempoRresultado.Minutes.ToString());

                                            #endregion
                                        }


                                        if (MarcacionesPorPersonal.ToList().Count == 4)
                                        {
                                            #region Cuatro Marcaciones
                                            objPersonalAdministrativo.ingreso = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 0 && MarcacionesPorPersonal.FirstOrDefault().fecha != null) ? MarcacionesPorPersonal.ElementAt(0).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.horaSalidaRefrigerioDesayuno = (DateTime?)null;
                                            objPersonalAdministrativo.horaRetornoRefrigerioDesayuno = (DateTime?)null;
                                            objPersonalAdministrativo.horaSalidaRefrigerio = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 1) ? MarcacionesPorPersonal.ElementAt(1).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.horaRetornoRefrigerio = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 2) ? MarcacionesPorPersonal.ElementAt(2).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.salida = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 3) ? MarcacionesPorPersonal.ElementAt(3).fecha : (DateTime?)null;

                                            #region Cacular horas trabajadas()
                                            TimeSpan tiempoAcumulado = MarcacionesPorPersonal.ElementAt(3).fecha.Value - MarcacionesPorPersonal.ElementAt(0).fecha.Value;
                                            TimeSpan tiempoAcumuladoAlmuerzo = MarcacionesPorPersonal.ElementAt(2).fecha.Value - MarcacionesPorPersonal.ElementAt(1).fecha.Value;
                                            TimeSpan tiempoRresultado = tiempoAcumulado - tiempoAcumuladoAlmuerzo;

                                            #endregion
                                            objPersonalAdministrativo.HorasTrabajadas = Convert.ToDecimal((tiempoRresultado.Hours).ToString() + "." + tiempoRresultado.Minutes.ToString());



                                            #endregion
                                        }



                                        if (MarcacionesPorPersonal.ToList().Count == 3)
                                        {
                                            #region Tres Marcaciones
                                            objPersonalAdministrativo.ingreso = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 0 && MarcacionesPorPersonal.FirstOrDefault().fecha != null) ? MarcacionesPorPersonal.ElementAt(0).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.horaSalidaRefrigerioDesayuno = (DateTime?)null;
                                            objPersonalAdministrativo.horaRetornoRefrigerioDesayuno = (DateTime?)null;
                                            objPersonalAdministrativo.horaSalidaRefrigerio = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 1) ? MarcacionesPorPersonal.ElementAt(1).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.horaRetornoRefrigerio = (DateTime?)null;
                                            objPersonalAdministrativo.salida = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 2) ? MarcacionesPorPersonal.ElementAt(2).fecha : (DateTime?)null;
                                            //objPersonalAdministrativo.HorasTrabajadas = (decimal?)null;

                                            #region Cacular horas trabajadas()
                                            TimeSpan tiempoAcumulado = MarcacionesPorPersonal.ElementAt(2).fecha.Value - MarcacionesPorPersonal.ElementAt(0).fecha.Value;
                                            //TimeSpan tiempoAcumuladoDesayuno = MarcacionesPorPersonal.ElementAt(2).fecha.Value - MarcacionesPorPersonal.ElementAt(1).fecha.Value;
                                            //TimeSpan tiempoAcumuladoAlmuerzo = MarcacionesPorPersonal.ElementAt(2).fecha.Value - MarcacionesPorPersonal.ElementAt(1).fecha.Value;
                                            TimeSpan tiempoRresultado = tiempoAcumulado;
                                            #endregion
                                            //objPersonalAdministrativo.HorasTrabajadas = Convert.ToDecimal((tiempoRresultado.Hours - 1).ToString() + "." + tiempoRresultado.Minutes.ToString()); /*camcio antes del 23 02 2015*/
                                            objPersonalAdministrativo.HorasTrabajadas = Convert.ToDecimal((tiempoRresultado.Hours + 0).ToString() + "." + tiempoRresultado.Minutes.ToString()); /*cambio solicitado por fio peña 23 02 2016*/



                                            #endregion
                                        }

                                        if (MarcacionesPorPersonal.ToList().Count == 2)
                                        {
                                            #region Dos Marcaciones
                                            objPersonalAdministrativo.ingreso = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 0 && MarcacionesPorPersonal.FirstOrDefault().fecha != null) ? MarcacionesPorPersonal.ElementAt(0).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.horaSalidaRefrigerioDesayuno = (DateTime?)null;
                                            objPersonalAdministrativo.horaRetornoRefrigerioDesayuno = (DateTime?)null;
                                            objPersonalAdministrativo.horaSalidaRefrigerio = (DateTime?)null;
                                            objPersonalAdministrativo.horaRetornoRefrigerio = (DateTime?)null;
                                            objPersonalAdministrativo.salida = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 1) ? MarcacionesPorPersonal.ElementAt(1).fecha : (DateTime?)null;

                                            #region Cacular horas trabajadas()
                                            TimeSpan tiempoAcumulado = MarcacionesPorPersonal.ElementAt(1).fecha.Value - MarcacionesPorPersonal.ElementAt(0).fecha.Value;
                                            //TimeSpan tiempoAcumuladoDesayuno = MarcacionesPorPersonal.ElementAt(2).fecha.Value - MarcacionesPorPersonal.ElementAt(1).fecha.Value;
                                            //TimeSpan tiempoAcumuladoAlmuerzo = MarcacionesPorPersonal.ElementAt(2).fecha.Value - MarcacionesPorPersonal.ElementAt(1).fecha.Value;
                                            TimeSpan tiempoRresultado = tiempoAcumulado;
                                            #endregion
                                            //objPersonalAdministrativo.HorasTrabajadas = Convert.ToDecimal((tiempoRresultado.Hours - 1).ToString() + "." + tiempoRresultado.Minutes.ToString()); /*camcio antes del 23 02 2015*/
                                            objPersonalAdministrativo.HorasTrabajadas = Convert.ToDecimal((tiempoRresultado.Hours + 0).ToString() + "." + tiempoRresultado.Minutes.ToString()); /*cambio solicitado por fio peña 23 02 2016*/


                                            #endregion
                                        }


                                        if (MarcacionesPorPersonal.ToList().Count == 1)
                                        {
                                            #region Una Marcaciones
                                            objPersonalAdministrativo.ingreso = (MarcacionesPorPersonal != null && MarcacionesPorPersonal.ToList().Count > 0 && MarcacionesPorPersonal.FirstOrDefault().fecha != null) ? MarcacionesPorPersonal.ElementAt(0).fecha : (DateTime?)null;
                                            objPersonalAdministrativo.horaSalidaRefrigerioDesayuno = (DateTime?)null;
                                            objPersonalAdministrativo.horaRetornoRefrigerioDesayuno = (DateTime?)null;
                                            objPersonalAdministrativo.horaSalidaRefrigerio = (DateTime?)null;
                                            objPersonalAdministrativo.horaRetornoRefrigerio = (DateTime?)null;
                                            objPersonalAdministrativo.salida = (DateTime?)null;
                                            objPersonalAdministrativo.HorasTrabajadas = (decimal?)null;
                                            #endregion
                                        }

                                        ListadoObj.Add(objPersonalAdministrativo);
                                        #endregion
                                    }
                                    else
                                    {
                                        #region
                                        objPersonalAdministrativo = new PersonalAdministrativo();
                                        objPersonalAdministrativo.fecha = Convert.ToDateTime(item.fecha);
                                        objPersonalAdministrativo.diaSemana = Convert.ToDateTime(item.fecha).ToString("dddd", CultureInfo.CreateSpecificCulture("es-ES")).ToUpper().Trim();
                                        objPersonalAdministrativo.codigoPersonal = personal.codigo;
                                        objPersonalAdministrativo.personal = PersonalxCodigo.FirstOrDefault().personal != null ? PersonalxCodigo.FirstOrDefault().personal.ToString().Trim().ToUpper() : "";
                                        objPersonalAdministrativo.areaTrabajo = PersonalxCodigo.FirstOrDefault().areaTrabajo != null ? PersonalxCodigo.FirstOrDefault().areaTrabajo.ToString().Trim().ToUpper() : "";
                                        objPersonalAdministrativo.cargo = PersonalxCodigo.FirstOrDefault().cargo != null ? PersonalxCodigo.FirstOrDefault().cargo.ToString().Trim().ToUpper() : "";
                                        objPersonalAdministrativo.nroDocumento = PersonalxCodigo.FirstOrDefault().nroDocumento != null ? PersonalxCodigo.FirstOrDefault().nroDocumento.ToString().Trim().ToUpper() : "";
                                        objPersonalAdministrativo.ingreso = (DateTime?)null;
                                        objPersonalAdministrativo.horaSalidaRefrigerio = (DateTime?)null;
                                        objPersonalAdministrativo.horaRetornoRefrigerio = (DateTime?)null;
                                        objPersonalAdministrativo.salida = (DateTime?)null;
                                        objPersonalAdministrativo.horaSalidaRefrigerioDesayuno = (DateTime?)null;
                                        objPersonalAdministrativo.horaRetornoRefrigerioDesayuno = (DateTime?)null;
                                        ListadoObj.Add(objPersonalAdministrativo);
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
                    #endregion
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }





            #endregion

            return ListadoObj;
        }

        /* consolidado mensual de las marcaciones para verificar solo la asistencia del personal*/
        public List<PersonalAdministrativo> ObtenerListaMarcacionesTrabajadoresxMes(List<PersonalAdministrativo> ListadoObj)
        {
            #region Distribucion de Asistencia Durante un mes()

            listadoConsolidadMensualAsistencia = new List<PersonalAdministrativo>();
            if (ListadoObj != null && ListadoObj.ToList().Count > 0)
            {
                #region
                /* Obtener el formato es decir si la fecha es 01/01/205 09:03:49 obtenerla como  01/01/205 00:00:00 */
                var filtradoxFechas = (from item in ListadoObj
                                       group item by new { item.fecha } into j
                                       select new
                                       {
                                           fecha = j.Key.fecha.Value.ToShortDateString()
                                       }).ToList();

                /* Obtener Fecha que se registra Asistencia */
                if (filtradoxFechas != null && filtradoxFechas.ToList().Count > 0)
                {
                    listaFechaAsistencia = new List<oFechaAsistencia>();

                    listaFechaAsistencia = (from item in filtradoxFechas
                                            group item by new { item.fecha } into j
                                            select new oFechaAsistencia
                                            {
                                                fecha = Convert.ToDateTime(j.Key.fecha.ToString())
                                            }).ToList().OrderBy(x => x.fecha).ToList();
                }

                /* Obtener la lista del personal general, para cruzarlo con los días trabajados */
                var listaPersonalMarcacion = (from items in listadoPersonalEASJ
                                              group items by new { items.codigoPersonal, items.personal } into j
                                              select new
                                              {
                                                  codigo = j.Key.codigoPersonal.ToString().ToUpper().Trim(),
                                                  nombres = j.Key.personal != null ? j.Key.personal.ToUpper().Trim() : ""
                                              }).ToList().OrderBy(x => x.nombres).ToList();


                foreach (var trabajador in listaPersonalMarcacion)
                {

                    foreach (var diaAsistido in listaFechaAsistencia)
                    {

                        var listaPersonalxAsistenciaxNroMarcaciones = ListadoObj.Where(x =>
                                x.codigoPersonal.ToString().Trim() == trabajador.codigo.ToString().Trim()
                                && x.fecha.Value >= diaAsistido.fecha.Value &&
                                x.fecha.Value <= Convert.ToDateTime(diaAsistido.fecha.Value.ToPresentationDate() + " 23:59:59")
                            //x.ingreso.Value.ToString().Trim() != ""
                            //x.salida.Value != (DateTime?)null 
                            //x.horaSalidaRefrigerio.Value != (DateTime?)null &&
                            //x.horaSalidaRefrigerioDesayuno != (DateTime?)null &&
                            //x.horaRetornoRefrigerio != (DateTime?)null && 
                            //x.horaRetornoRefrigerioDesayuno != (DateTime?)null
                                ).ToList();

                        var listaPersonalxAsistenciaxNroMarcacionesFiltrado = listaPersonalxAsistenciaxNroMarcaciones.Where(x =>
                            x.ingreso != (DateTime?)null ||
                            x.salida != (DateTime?)null ||
                            x.horaSalidaRefrigerio != (DateTime?)null ||
                            x.horaRetornoRefrigerio != (DateTime?)null ||
                            x.horaRetornoRefrigerioDesayuno != (DateTime?)null ||
                            x.horaSalidaRefrigerioDesayuno != (DateTime?)null
                            ).ToList();
                        var datosTrabajador = listadoPersonalEASJ.Where(x => x.codigoPersonal.ToString().Trim() == trabajador.codigo).ToList();


                        if (listaPersonalxAsistenciaxNroMarcacionesFiltrado != null && listaPersonalxAsistenciaxNroMarcacionesFiltrado.ToList().Count > 0)
                        {
                            consolidadMensualAsistencia = new PersonalAdministrativo();
                            consolidadMensualAsistencia.fecha = diaAsistido.fecha != null ? diaAsistido.fecha.Value : (DateTime?)null;
                            consolidadMensualAsistencia.diaSemana = diaAsistido.fecha.Value.ToString("dddd", new CultureInfo("es-ES"));
                            consolidadMensualAsistencia.codigoPersonal = trabajador.codigo;
                            consolidadMensualAsistencia.personal = trabajador.nombres.ToString().Trim().ToUpper();
                            consolidadMensualAsistencia.areaTrabajo = datosTrabajador.FirstOrDefault().areaTrabajo != null ? datosTrabajador.FirstOrDefault().areaTrabajo.ToString().Trim().ToUpper() : "";
                            consolidadMensualAsistencia.cargo = datosTrabajador.FirstOrDefault().cargo != null ? datosTrabajador.FirstOrDefault().cargo.ToString().Trim().ToUpper() : "";
                            consolidadMensualAsistencia.Asistio = 1;
                            consolidadMensualAsistencia.HorasTrabajadas = (listaPersonalxAsistenciaxNroMarcacionesFiltrado.FirstOrDefault().HorasTrabajadas != null && listaPersonalxAsistenciaxNroMarcacionesFiltrado.FirstOrDefault().HorasTrabajadas > 0 ) ? listaPersonalxAsistenciaxNroMarcacionesFiltrado.FirstOrDefault().HorasTrabajadas : (decimal?)null;
                            listadoConsolidadMensualAsistencia.Add(consolidadMensualAsistencia);
                        }
                        else
                        {
                            consolidadMensualAsistencia = new PersonalAdministrativo();
                            consolidadMensualAsistencia.fecha = diaAsistido.fecha != null ? diaAsistido.fecha.Value : (DateTime?)null;
                            consolidadMensualAsistencia.diaSemana = diaAsistido.fecha.Value.ToString("dddd", new CultureInfo("es-ES"));
                            consolidadMensualAsistencia.codigoPersonal = trabajador.codigo;
                            consolidadMensualAsistencia.personal = trabajador.nombres.ToString().Trim().ToUpper();
                            consolidadMensualAsistencia.areaTrabajo = datosTrabajador.FirstOrDefault().areaTrabajo != null ? datosTrabajador.FirstOrDefault().areaTrabajo.ToString().Trim().ToUpper() : "";
                            consolidadMensualAsistencia.cargo = datosTrabajador.FirstOrDefault().cargo != null ? datosTrabajador.FirstOrDefault().cargo.ToString().Trim().ToUpper() : "";
                            consolidadMensualAsistencia.Asistio = 0;
                            consolidadMensualAsistencia.HorasTrabajadas = (decimal?)null;
                            listadoConsolidadMensualAsistencia.Add(consolidadMensualAsistencia);
                        }

                    }
                }
                #endregion
            }

            return listadoConsolidadMensualAsistencia;

            #endregion
        }

        /* consolidado mensual de las marcaciones para verificar las horas trabajadas acumuladas por dia del personal durante el mes*/
        public void ObtenerListaHorasTrabajadasxPesonalxMes(List<PersonalAdministrativo> ListadoObj)
        {

        }

        public List<PersonalAdministrativo> ObtenerListaTrabajadoresMarcanAsistencia()
        {
            listadoPersonal = new List<PersonalAdministrativo>();
            #region Obtener todos los trabajadores asignados para realizar Marcación diaría de trabajo()
            try
            {
                //OleDbConnection MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=X:\\att.mdb ;Persist Security Info=False");

                OleDbConnection MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=Z:\\att.mdb ;Persist Security Info=False");
                //\\192.168.30.99\BDAsistencia
                OleDbDataAdapter MyAdapter = new OleDbDataAdapter("select USERID, SSN, NAME , Street, Title from USERINFO", MyConnection);
                DataSet MyDataSet = new DataSet();
                MyConnection.Open();
                MyAdapter.Fill(MyDataSet);
               
                if (MyDataSet.Tables[0].Rows.Count > 0)
                {
                    peopleList = new string[MyDataSet.Tables[0].Rows.Count];

                    for (int i = 0; i < MyDataSet.Tables[0].Rows.Count; i++)
                    {
                        DataRow campo = MyDataSet.Tables[0].Rows[i];
                        PersonalAdministrativo obj = new PersonalAdministrativo();
                        obj.codigoPersonal = (campo["USERID"].ToString());
                        obj.personal = (campo["NAME"].ToString().Trim().ToUpper());
                        obj.areaTrabajo = (campo["Street"].ToString().Trim().ToUpper());
                        obj.cargo = (campo["Title"].ToString().Trim().ToUpper());
                        obj.nroDocumento = (campo["SSN"].ToString().Trim());
                        listadoPersonal.Add(obj);
                    }
                }
                MyConnection.Close();
            }
            catch { peopleList = null; }




            return listadoPersonal;



            #endregion
        }

        public List<PersonalAdministrativo> ObtenerAsistenciasPersonalxDiaxCodigo(string desde, string hasta, string idPersonalMarcacion, List<PersonalAdministrativo> personalRegistradoParaMarcarAsistencia)
        {

            //Realizamos una conexion odbc (base de datos access)
            OdbcConnection MyConnection = new OdbcConnection();
            //Cadena de conexion. Esto es lo que hay que poner para acceder
            //a una base de datos en access. Si teneis una base de datos en
            //oracle o alguna otra plataforma solo tendreis que cambiar esto.
            String cadenaConexion = "Driver={Microsoft Access Driver (*.mdb)};Dbq=" + "Z:\\" + "att.mdb;Uid=;Pwd=;";
            MyConnection.ConnectionString = cadenaConexion;

            DateTime FechaDesde = Convert.ToDateTime(desde.ToString().Trim().Substring(0, 10));
            DateTime FechaHasta = Convert.ToDateTime(hasta.ToString().Trim().Substring(0, 10)).AddDays(1);

            String consulta = "select USERID,  CHECKTIME ,  RTRIM(Memoinfo)  AS estado from CHECKINOUT";

            //Creamos un dataadapter donde depositaremos los resultados.
            OdbcDataAdapter adaptador = new OdbcDataAdapter(consulta, MyConnection);
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            dataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            //Incluimos en el datatable lo que hemos obtenido de la consulta
            adaptador.Fill(dataTable);

            List<PersonalAdministrativo> listadoMarcacionAsistencia = new List<PersonalAdministrativo>();
            int NumeroRegistros = dataTable.Rows.Count;


            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow campo = dataTable.Rows[i];
                PersonalAdministrativo obj = new PersonalAdministrativo();
                obj.fecha = Convert.ToDateTime(campo["CHECKTIME"].ToString());
                obj.codigoPersonal = (campo["USERID"].ToString().Trim());
                obj.estado = (campo["estado"].ToString().Trim());
                listadoMarcacionAsistencia.Add(obj);
            }

            var listaPresentacion = listadoMarcacionAsistencia.Where(x =>
                x.codigoPersonal.ToString().Trim() == idPersonalMarcacion
                && x.fecha >= FechaDesde
                && x.fecha < FechaHasta
                ).ToList();

            listadoMarcacionAsistencia = new List<PersonalAdministrativo>();
            foreach (var item in listaPresentacion)
            {
                var datosTrabajador = personalRegistradoParaMarcarAsistencia.Where(x => x.codigoPersonal == item.codigoPersonal.ToString().Trim()).Single();
                PersonalAdministrativo obj = new PersonalAdministrativo();
                obj.fecha = item.fecha;
                obj.codigoPersonal = item.codigoPersonal;
                obj.nroDocumento = datosTrabajador.nroDocumento != null ? datosTrabajador.nroDocumento.ToString().Trim() : "";
                obj.personal = datosTrabajador.personal != null ? datosTrabajador.personal.ToString().Trim() : "";
                obj.areaTrabajo = datosTrabajador.areaTrabajo != null ? datosTrabajador.areaTrabajo.ToString().Trim() : "";
                obj.estado = (item.estado != null && item.estado.ToString().Trim() != "") ? "ANULADO" : "ACTIVO";
                listadoMarcacionAsistencia.Add(obj);
            }


            return listadoMarcacionAsistencia;
        }

    }
}
