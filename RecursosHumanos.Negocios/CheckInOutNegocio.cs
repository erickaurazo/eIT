using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
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
using RecursosHumanos.Negocios;

namespace RecursosHumanos.Negocios
{
    public class CheckInOutNegocio
    {
        private string oConexion;
        private string[] peopleList;
        private GrupoH oGrupo;
        private AsistenciaNegocio movimientoAsistenciaNegocio;

        public List<CheckInOut> ObtenerTodadasMarcacionesDelSistemaBiometrico()
        {
            CheckInOut oCheckInOut = new CheckInOut();
            List<CheckInOut> checkInOuts = new List<CheckInOut>();
            try
            {
                #region Realizar consulta a base de Access()


                //OleDbConnection MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=X:\\att.mdb ;Persist Security Info=False");
                OleDbConnection MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=D:\\att2000.mdb ;Persist Security Info=False");
                OleDbDataAdapter MyAdapter = new OleDbDataAdapter("select * from CheckInOut ", MyConnection);
                DataSet MyDataSet = new DataSet();
                MyConnection.Open();
                MyAdapter.Fill(MyDataSet);
                if (MyDataSet.Tables[0].Rows.Count > 0)
                {
                    peopleList = new string[MyDataSet.Tables[0].Rows.Count];

                    for (int i = 0; i < MyDataSet.Tables[0].Rows.Count; i++)
                    {
                        DataRow campo = MyDataSet.Tables[0].Rows[i];
                        oCheckInOut.USERID = Convert.ToInt32(campo["USERID"]);
                        oCheckInOut.CHECKTIME = (campo["CHECKTIME"].ToString());
                        oCheckInOut.CHECKTYPE = (campo["CHECKTYPE"].ToString());
                        oCheckInOut.VERIFYCODE = String.IsNullOrEmpty(campo["VERIFYCODE"].ToString()) ? (Int32?)null : Int32.Parse(campo["VERIFYCODE"].ToString());
                        oCheckInOut.SENSORID = (campo["SENSORID"].ToString());
                        oCheckInOut.Memoinfo = (campo["Memoinfo"].ToString());
                        oCheckInOut.WorkCode = (campo["WorkCode"].ToString());
                        oCheckInOut.sn = (campo["sn"].ToString());
                        oCheckInOut.UserExtFmt = String.IsNullOrEmpty(campo["UserExtFmt"].ToString()) ? (Int32?)null : Int32.Parse(campo["UserExtFmt"].ToString());
                        checkInOuts.Add(oCheckInOut);
                    }
                }
                MyConnection.Close();
                #endregion
            }
            catch
            {
                peopleList = null;
            }

            return checkInOuts;
        }

        public List<CheckInOut> ObtenerListadoDeMarcacionesDelSistemaBiometricoSinTransferir()
        {
            List<CheckInOut> checkInOuts = new List<CheckInOut>();
            CheckInOut oCheckInOut = new CheckInOut();
            try
            {
                #region Realizar consulta a base de Access()


                //OleDbConnection MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=X:\\att.mdb ;Persist Security Info=False");
                OleDbConnection MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=D:\\att2000.mdb ;Persist Security Info=False");
                OleDbDataAdapter MyAdapter = new OleDbDataAdapter("select  * from CheckInOut where memoinfo is null union all select * from CheckInOut where RTRIM(memoinfo) = ''", MyConnection);
                DataSet MyDataSet = new DataSet();
                MyConnection.Open();
                MyAdapter.Fill(MyDataSet);
                if (MyDataSet.Tables[0].Rows.Count > 0)
                {
                    peopleList = new string[MyDataSet.Tables[0].Rows.Count];

                    for (int i = 0; i < MyDataSet.Tables[0].Rows.Count; i++)
                    {
                        DataRow campo = MyDataSet.Tables[0].Rows[i];
                        oCheckInOut = new CheckInOut();
                        oCheckInOut.USERID = Convert.ToInt32(campo["USERID"]);
                        oCheckInOut.CHECKTIME = (campo["CHECKTIME"].ToString());
                        oCheckInOut.CHECKTYPE = (campo["CHECKTYPE"].ToString());
                        oCheckInOut.VERIFYCODE = String.IsNullOrEmpty(campo["VERIFYCODE"].ToString()) ? (Int32?)null : Int32.Parse(campo["VERIFYCODE"].ToString());
                        oCheckInOut.SENSORID = (campo["SENSORID"].ToString());
                        oCheckInOut.Memoinfo = (campo["Memoinfo"].ToString());
                        oCheckInOut.WorkCode = (campo["WorkCode"].ToString());
                        oCheckInOut.sn = (campo["sn"].ToString());
                        oCheckInOut.UserExtFmt = String.IsNullOrEmpty(campo["UserExtFmt"].ToString()) ? (Int32?)null : Int32.Parse(campo["UserExtFmt"].ToString());
                        oCheckInOut.fechaAsistencia = Convert.ToDateTime(DateTime.Parse(Convert.ToDateTime(campo["CHECKTIME"].ToString()).ToShortDateString()));
                        checkInOuts.Add(oCheckInOut);
                    }
                }
                MyConnection.Close();
                #endregion
            }
            catch
            {
                peopleList = null;
            }

            return checkInOuts;
        }

        public List<CheckInOut> ObtenerMarcacionMigradoAlSistemaDeAsistenciaByFechas(string periodoConsulta, string desde, string hasta)
        {
            List<CheckInOut> checkInOuts = new List<CheckInOut>();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                checkInOuts = Modelo.CheckInOut.Where(x => Convert.ToDateTime(x.CHECKTIME) >= Convert.ToDateTime(desde) && Convert.ToDateTime(x.CHECKTIME) <= Convert.ToDateTime(hasta)).ToList();
            }

            return checkInOuts;
        }

        public CheckInOut ObtenerMarcacionesDeAsistenciaByCodigoRegistro(string periodoConsulta, CheckInOut checkInOut)
        {
            CheckInOut oCheckInOut = new CheckInOut();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                var resultadoConsutla = Modelo.CheckInOut.Where(x => x.USERID == checkInOut.USERID && x.CHECKTIME == checkInOut.CHECKTIME).ToList();
                if (resultadoConsutla.ToList().Count == 1)
                {
                    oCheckInOut = resultadoConsutla.Single();
                }
            }
            return oCheckInOut;
        }

        public List<CheckInOut> ObtenerMarcacionesDeAsistenciaByCodigoUsuarioByFechas(string periodoConsulta, string desde, string hasta, CheckInOut checkInOut)
        {
            List<CheckInOut> checkInOuts = new List<CheckInOut>();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                checkInOuts = Modelo.CheckInOut.Where(x => Convert.ToDateTime(x.CHECKTIME) >= Convert.ToDateTime(desde) && Convert.ToDateTime(x.CHECKTIME) <= Convert.ToDateTime(hasta) && x.USERID == checkInOut.USERID).ToList();
            }

            return checkInOuts;
        }

        public int RegistrarMarcacionesNuevosDelLectorBiometricoAlSistemaDeAsistencia(List<CheckInOut> listado, string periodoConsulta, string codigoUsuario, string codigoOperacion)
        {
            int NumeroRegistroTransferidos = 0;
            //using (TransactionScope Scope = new TransactionScope())
            //{
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {

                if (listado != null && listado.Where(x => x.Memoinfo.ToString().Trim() != "T").ToList().Count > 0)
                {
                    foreach (var oMarcacion in listado)
                    {
                        var buscarMarcacuibEnSistemaUsuario = Modelo.CheckInOut.Where(x => x.USERID == Convert.ToInt32(oMarcacion.USERID) &&
                                                                                        x.CHECKTIME == (String.IsNullOrEmpty(oMarcacion.CHECKTIME.ToString()) ? string.Empty : (oMarcacion.CHECKTIME.ToString().Trim())) &&
                                                                                        x.CHECKTYPE == (String.IsNullOrEmpty(oMarcacion.CHECKTYPE.ToString()) ? string.Empty : (oMarcacion.CHECKTYPE.ToString().Trim()))
                                                                                        ).ToList();
                        if (buscarMarcacuibEnSistemaUsuario.ToList().Count == 0)
                        {
                            #region Registrar en tabla espejo de la base de datos de Asistencia en SQL()
                            /* Transfiero registro a tabla de personal */
                            CheckInOut oCheckInOut = new CheckInOut();
                            oCheckInOut.USERID = Convert.ToInt32(oMarcacion.USERID);
                            oCheckInOut.CHECKTIME = String.IsNullOrEmpty(oMarcacion.CHECKTIME.ToString()) ? string.Empty : (oMarcacion.CHECKTIME.ToString().Trim());
                            oCheckInOut.CHECKTYPE = String.IsNullOrEmpty(oMarcacion.CHECKTYPE.ToString()) ? string.Empty : (oMarcacion.CHECKTYPE.ToString().Trim());
                            oCheckInOut.VERIFYCODE = String.IsNullOrEmpty(oMarcacion.VERIFYCODE.ToString()) ? (Int32?)null : Int32.Parse(oMarcacion.VERIFYCODE.ToString());
                            oCheckInOut.SENSORID = String.IsNullOrEmpty(oMarcacion.SENSORID.ToString()) ? string.Empty : (oMarcacion.SENSORID.ToString().Trim());
                            oCheckInOut.Memoinfo = String.IsNullOrEmpty(oMarcacion.Memoinfo.ToString()) ? string.Empty : (oMarcacion.Memoinfo.ToString().Trim());
                            oCheckInOut.WorkCode = String.IsNullOrEmpty(oMarcacion.WorkCode.ToString()) ? string.Empty : (oMarcacion.WorkCode.ToString().Trim());
                            oCheckInOut.sn = String.IsNullOrEmpty(oMarcacion.sn.ToString()) ? string.Empty : (oMarcacion.sn.ToString().Trim());
                            oCheckInOut.UserExtFmt = String.IsNullOrEmpty(oMarcacion.UserExtFmt.ToString()) ? (Int32?)null : Int32.Parse(oMarcacion.UserExtFmt.ToString());
                            oCheckInOut.hostTransferencia = Environment.MachineName.ToString();
                            oCheckInOut.fechaTransferencia = DateTime.Now;
                            oCheckInOut.fechaAsistencia = String.IsNullOrEmpty(oMarcacion.CHECKTIME.ToString()) ? (DateTime?)null : DateTime.Parse(Convert.ToDateTime(oMarcacion.CHECKTIME).ToShortDateString());
                            oCheckInOut.usuarioTransferencia = codigoUsuario;
                            oCheckInOut.codigoTransferencia = codigoOperacion;
                            Modelo.CheckInOut.InsertOnSubmit(oCheckInOut);
                            Modelo.SubmitChanges();
                            NumeroRegistroTransferidos = NumeroRegistroTransferidos + 1;
                            #endregion

                            /* Actualizo el estado a transferido en la tabla del access - CheckInOut, el estado T en el atributo menoinfo me asegura que se transfirio  */
                            #region
                            string oConexionAccess = string.Empty;
                            OleDbConnection connection = new OleDbConnection();
                            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                            string sql = null;
                            oConexionAccess = (@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=D:\\att2000.mdb ;Persist Security Info=False");
                            connection = new OleDbConnection(oConexionAccess);
                            //sql = "update CheckInOut set Memoinfo = 'T' where USERID = " + Convert.ToInt32(oMarcacion.USERID) + " and CHECKTIME = #" + (String.IsNullOrEmpty(oMarcacion.CHECKTIME.ToString()) ? string.Empty : (oMarcacion.CHECKTIME.ToString().Trim())) + "# and CHECKTYPE = '" + (String.IsNullOrEmpty(oMarcacion.CHECKTYPE.ToString()) ? string.Empty : (oMarcacion.CHECKTYPE.ToString().Trim())) + "'";
                            sql = "update CheckInOut set Memoinfo = 'T' where USERID = " + Convert.ToInt32(oMarcacion.USERID) + " and CHECKTIME = #" + (String.IsNullOrEmpty(oMarcacion.CHECKTIME.ToString()) ? string.Empty : (oMarcacion.CHECKTIME.ToString().Trim())) + "# and CHECKTYPE = '" + (String.IsNullOrEmpty(oMarcacion.CHECKTYPE.ToString()) ? string.Empty : (oMarcacion.CHECKTYPE.ToString().Trim())) + "'";
                            try
                            {
                                connection.Open();
                                oledbAdapter.UpdateCommand = connection.CreateCommand();
                                oledbAdapter.UpdateCommand.CommandText = sql;
                                oledbAdapter.UpdateCommand.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                string mesaggeError = ex.Message.ToString();
                            }
                            #endregion

                        }



                    }
                }
            }
            //    Scope.Complete();
            //}
            return NumeroRegistroTransferidos;
        }

        public string ObtenerCodigoUnicoTransferencia(string periodoConsulta)
        {
            string codigoOperacion = string.Empty;
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta.Substring(0, 4) != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                codigoOperacion = Modelo.GenerarCodigoUnico().FirstOrDefault().Codigo;
            }
            return codigoOperacion;
        }

        public List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekResult> ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeek(string periodoConsulta, string desde, string hasta, string codigoPlanilla)
        {
            List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekResult> listado = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekResult>();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                listado = Modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeek(desde, hasta, codigoPlanilla).ToList();
            }
            return listado;
        }

        public List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekAgrupadoResult> ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekAgrupado(string periodoConsulta, string desde, string hasta, string codigoPlanilla)
        {
            List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekAgrupadoResult> listado = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekAgrupadoResult>();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                listado = Modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekAgrupado(desde, hasta, codigoPlanilla).ToList();

                listado = listado.Where(x => x.fechaAsistencia >= Convert.ToDateTime(desde) && x.fechaAsistencia <= Convert.ToDateTime(hasta)).ToList();
            }
            return listado;
        }

        public List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult> ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFecha(string periodoConsulta, string fecha, string codigoPlanilla, string codigoTransferencia)
        {
            List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult> listado = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                listado = Modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFecha(fecha, codigoPlanilla, codigoTransferencia).ToList();
            }
            return listado;
        }

        public List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult> ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaDesconocidos(string periodoConsulta, string fecha, string codigoPlanilla, string codigoTransferencia)
        {
            List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult> listado = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                listado = Modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFecha(fecha, codigoPlanilla, codigoTransferencia).Where(x=> x.Nombres.Trim() == string.Empty).ToList();
            }
            return listado;
        }

        public List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult> ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaAgrupadoByMarcacionByPersona(List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult> listadoMarcaciones)
        {
            List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult> listado = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();

            listado = (from item in listadoMarcaciones
                       group item by item.dni into j
                       select new ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult
                           {
                               dni = j.Key,
                               Nombres = j.FirstOrDefault().Nombres,
                               numeroMarcacion = j.Max(x => x.numeroMarcacion),
                               codigoUsuarioMarcacion = j.Max(x => x.codigoUsuarioMarcacion),
                               horasAcumuladas = j.Max(x => x.horasAcumuladas),
                               horasAcumuladas1 = j.Max(x => x.horasAcumuladas1),
                               fechaAsistencia = j.Max(x => x.fechaAsistencia),
                           }).ToList();

            return listado;
        }

        public List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIResult> ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNI(string periodoConsulta, string desde, string codigoPlanilla, string codigoTransferencia, string nroDni)
        {
            List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIResult> listado = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIResult>();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                listado = Modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNI(desde, codigoPlanilla, codigoTransferencia, nroDni).ToList();
            }
            return listado;
        }

        public string ActualizarNumeroMarcacionesTransferenciaAsistenciaByFecha(string periodoConsulta, string desde, string codigoTransferencia)
        {
            string proceso = string.Empty;
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                Modelo.ext_GenerarOrdenListadoMarcacionDactilarByFecha(desde);


                LogTablas oHistorial = new LogTablas();
                oHistorial.IDEMPRESA = "001";
                oHistorial.IDLOG = "001" + codigoTransferencia;
                oHistorial.ITEM = AsignarNumeroItemHistorial(periodoConsulta.Substring(0, 4), oHistorial.IDLOG);
                oHistorial.TABLA = "CheckInOut";
                oHistorial.IDCAMPO = "codigoTransferencia";
                oHistorial.CAMPOCLAVE = "codigoTransferencia";
                oHistorial.IDTABLA = "";
                oHistorial.EVENTO = "MODIFICA";
                oHistorial.VALORANTERIOR = "";
                oHistorial.VALORACTUAL = "ACT. MARCA";
                oHistorial.IDUSUARIO = Environment.UserName;
                oHistorial.MAQUINA = Environment.UserName;
                oHistorial.FECHACREACION = DateTime.Now;
                oHistorial.VENTANA = "ASISTENCIA BIOMETRICO";
                Modelo.LogTablas.InsertOnSubmit(oHistorial);
                Modelo.SubmitChanges();


            }
            return proceso;
        }

        public string ActualizarNumeroMarcacionesTransferenciaAsistencia(string periodoConsulta)
        {
            string proceso = string.Empty;
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                Modelo.ext_GenerarOrdenListadoMarcacionDactilar();
                proceso = "OK";

            }
           return proceso ;
        }

        public void EliminarMarcacionBiometricoByCorrelativo(string periodoConsulta, CheckInOut detalleEliminar)
        {
            string proceso = string.Empty;
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                CheckInOut oCheckInOut = new CheckInOut();
                var resultadoCoincidencia = Modelo.CheckInOut.Where(x => x.correlativo == detalleEliminar.correlativo).ToList();
                if (resultadoCoincidencia.ToList().Count == 1)
                {
                    oCheckInOut = Modelo.CheckInOut.Where(x => x.correlativo == detalleEliminar.correlativo).Single();
                    Modelo.CheckInOut.DeleteOnSubmit(oCheckInOut);
                    Modelo.SubmitChanges();
                }
            }
        }

        public List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIByCorrelativoResult> ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIByCorrelativo(string periodoConsulta, int correlativo)
        {
            List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIByCorrelativoResult> listado = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIByCorrelativoResult>();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                listado = Modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIByCorrelativo(correlativo).ToList();
            }
            return listado;
        }

        public List<GrupoH> ListarTipoMarcacion()
        {
            List<GrupoH> listadoTipoMarcacion = new List<GrupoH>();

            oGrupo = new GrupoH();
            oGrupo.Codigo = "I";
            oGrupo.Descripcion = "INGRESO";
            listadoTipoMarcacion.Add(oGrupo);

            oGrupo = new GrupoH();
            oGrupo.Codigo = "O";
            oGrupo.Descripcion = "SALIDA";
            listadoTipoMarcacion.Add(oGrupo);


            return listadoTipoMarcacion;
        }

        public List<CheckInOut> ObtenerMarcacionBiometricoByNumeroCorrelativo(string periodoConsulta, int correlativo)
        {
            List<CheckInOut> listado = new List<CheckInOut>();
            string oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                var ObtenerCoincidencia = Modelo.CheckInOut.Where(x => x.correlativo == correlativo).ToList();
                if (ObtenerCoincidencia.Count == 1)
                {
                    listado = ObtenerCoincidencia.ToList();
                }

            }
            return listado;
        }

        public CheckInOut ObtenerMarcacionBiometricoByCorrelativo(string periodoConsulta, int correlativo)
        {
            CheckInOut oMarcacion = new CheckInOut();
            string oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                var ObtenerCoincidencia = Modelo.CheckInOut.Where(x => x.correlativo == correlativo).ToList();
                if (ObtenerCoincidencia.Count == 1)
                {
                    oMarcacion = ObtenerCoincidencia.Single();
                }

            }
            return oMarcacion;
        }

        public void GrabarMarcacionBiometrico(string periodoConsulta, CheckInOut checkInOut, string codigoTransferencia)
        {
            try
            {
                CheckInOut oCheckInOut = new CheckInOut();
                oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
                using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
                {
                    var ObtenerCoincidencia = Modelo.CheckInOut.Where(x => x.correlativo == checkInOut.correlativo).ToList();

                    string obtenerCodigoTransferenciaMarcacionDestino = Modelo.CheckInOut.Where(x => x.fechaAsistencia == checkInOut.fechaAsistencia).FirstOrDefault().codigoTransferencia;

                    if (ObtenerCoincidencia.Count == 0)
                    {
                        if (codigoTransferencia != string.Empty)
                        {
                            #region Nuevo
                            oCheckInOut.USERID = checkInOut.USERID;
                            oCheckInOut.CHECKTIME = checkInOut.CHECKTIME;
                            oCheckInOut.CHECKTYPE = checkInOut.CHECKTYPE;
                            oCheckInOut.VERIFYCODE = checkInOut.VERIFYCODE;
                            oCheckInOut.SENSORID = checkInOut.SENSORID;
                            oCheckInOut.Memoinfo = checkInOut.Memoinfo;
                            oCheckInOut.WorkCode = checkInOut.WorkCode;
                            oCheckInOut.sn = checkInOut.sn;
                            oCheckInOut.UserExtFmt = checkInOut.UserExtFmt;
                            oCheckInOut.codigoTransferencia = obtenerCodigoTransferenciaMarcacionDestino;
                            oCheckInOut.fechaTransferencia = checkInOut.fechaTransferencia;
                            oCheckInOut.fechaAsistencia = checkInOut.fechaAsistencia;
                            oCheckInOut.usuarioTransferencia = Environment.MachineName;
                            oCheckInOut.hostTransferencia = Environment.MachineName;
                            oCheckInOut.codigoMarcacionBiometrico = checkInOut.codigoMarcacionBiometrico;
                            oCheckInOut.CodigoMovimientoAsistencia = checkInOut.CodigoMovimientoAsistencia;
                            Modelo.CheckInOut.InsertOnSubmit(oCheckInOut);
                            Modelo.SubmitChanges();
                            //oCheckInOut.correlativo = checkInOut.correlativo;

                            LogTablas oHistorial = new LogTablas();
                            oHistorial.IDEMPRESA = "001";
                            oHistorial.IDLOG = "001" + checkInOut.codigoTransferencia;
                            oHistorial.ITEM = AsignarNumeroItemHistorial(periodoConsulta.Substring(0, 4), oHistorial.IDLOG);
                            oHistorial.TABLA = "CheckInOut";
                            oHistorial.IDCAMPO = "codigoTransferencia";
                            oHistorial.CAMPOCLAVE = "codigoTransferencia";
                            oHistorial.IDTABLA = "";
                            oHistorial.EVENTO = "NUEVO";
                            oHistorial.VALORANTERIOR = "";
                            oHistorial.VALORACTUAL = "";
                            oHistorial.IDUSUARIO = Environment.UserName;
                            oHistorial.MAQUINA = Environment.UserName;
                            oHistorial.FECHACREACION = DateTime.Now;
                            oHistorial.VENTANA = "ASISTENCIA BIOMETRICO";
                            Modelo.LogTablas.InsertOnSubmit(oHistorial);
                            Modelo.SubmitChanges();
                            #endregion
                        }

                    }

                    if (ObtenerCoincidencia.Count == 1)
                    {
                        #region Editar
                        oCheckInOut = ObtenerCoincidencia.Single();
                        oCheckInOut.CHECKTIME = checkInOut.CHECKTIME;
                        oCheckInOut.codigoTransferencia = codigoTransferencia;
                        oCheckInOut.CHECKTYPE = checkInOut.CHECKTYPE;
                        oCheckInOut.fechaAsistencia = checkInOut.fechaAsistencia;
                        Modelo.SubmitChanges();

                        LogTablas oHistorial = new LogTablas();
                        oHistorial.IDEMPRESA = "001";
                        oHistorial.IDLOG = "001" + checkInOut.codigoTransferencia;
                        oHistorial.ITEM = AsignarNumeroItemHistorial(periodoConsulta.Substring(0, 4), oHistorial.IDLOG);
                        oHistorial.TABLA = "CheckInOut";
                        oHistorial.IDCAMPO = "codigoTransferencia";
                        oHistorial.CAMPOCLAVE = "codigoTransferencia";
                        oHistorial.IDTABLA = "";
                        oHistorial.EVENTO = "MODIFICA";
                        oHistorial.VALORANTERIOR = "";
                        oHistorial.VALORACTUAL = "ACT. MARCA";
                        oHistorial.IDUSUARIO = Environment.UserName;
                        oHistorial.MAQUINA = Environment.UserName;
                        oHistorial.FECHACREACION = DateTime.Now;
                        oHistorial.VENTANA = "ASISTENCIA BIOMETRICO";
                        Modelo.LogTablas.InsertOnSubmit(oHistorial);
                        Modelo.SubmitChanges();

                        #endregion
                    }



                }
            }
            catch (Exception Ex)
            {
                
                throw Ex;
            }



        }

        public void TransferirAsistenciaDesdeCorrelativoAFecha(string periodoConsulta, string fechaRegistro, int CorrelativoTransferir, string codigoTransferencia)
        {
            CheckInOut marcado = new CheckInOut();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : DateTime.Now.Year.ToString())].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                var ObtenerCoincidencia = Modelo.CheckInOut.Where(x => x.correlativo == CorrelativoTransferir).ToList();
                if (ObtenerCoincidencia.Count == 1)
                {
                    marcado = ObtenerCoincidencia.Single();
                    marcado.fechaAsistencia = Convert.ToDateTime(fechaRegistro);
                    //marcado.codigoTransferencia = codigoTransferencia;
                    Modelo.SubmitChanges();

                }
            }

        }

        public void TransferirAsistenciaDesdeCorrelativoByCodigoTransferencia(string periodoConsulta, string fechaRegistro, int CorrelativoTransferir, string codigoTransferencia)
        {
            CheckInOut marcado = new CheckInOut();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                var ObtenerCoincidencia = Modelo.CheckInOut.Where(x => x.correlativo == CorrelativoTransferir).ToList();
                if (ObtenerCoincidencia.Count == 1)
                {
                    marcado = ObtenerCoincidencia.ElementAt(0);
                    marcado.fechaAsistencia = Convert.ToDateTime(fechaRegistro);
                    //marcado.codigoTransferencia = codigoTransferencia;
                    Modelo.SubmitChanges();

                }
            }

        }


        public void GenerarMovimientoAsistenciaDesdeMarcaciondeBiometricoByDia(string periodo, string codigoPlanilla, string semanaPlanilla, DateTime? desde, DateTime? hasta, string fecha, List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult> listadoPersonalAgrupado, string codigoUnicoMovimiento, string codigoTransferencia)
        {
            oConexion = ConfigurationManager.AppSettings["bd" + (periodo != null ? periodo.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {

                try
                {
                    movimientoAsistenciaNegocio = new AsistenciaNegocio();

                    MovimientoAsistencia obtenerUltimaAsistencia = new MovimientoAsistencia();
                    obtenerUltimaAsistencia = movimientoAsistenciaNegocio.ObtenerUltimoRegistroAsistencia(periodo);
                    List<MovimientoAsistenciaDetalle> oDetalleAsistencia = new List<MovimientoAsistenciaDetalle>();
                    List<MovimientoAsistenciaDetalle> oDetallesEliminar = new List<MovimientoAsistenciaDetalle>();

                    #region
                    MovimientoAsistencia oMovimientoAsistencia = new MovimientoAsistencia();
                    oMovimientoAsistencia.codigoEmpresa = "001";
                    oMovimientoAsistencia.codigoAsistencia = codigoUnicoMovimiento;
                    oMovimientoAsistencia.fecha = listadoPersonalAgrupado.FirstOrDefault().fechaAsistencia.Value;
                    oMovimientoAsistencia.codigoPuntoEmisor = "001";
                    oMovimientoAsistencia.codigoPlanilla = codigoPlanilla;
                    oMovimientoAsistencia.codigoSucursal = "001";
                    oMovimientoAsistencia.codigoDocumento = "ASI";
                    oMovimientoAsistencia.codigoTurnoTrabajo = "01";
                    oMovimientoAsistencia.codigoResponsable = "000147";
                    oMovimientoAsistencia.codigoEstado = "PE";
                    oMovimientoAsistencia.codigoOperacion = "ASIS";
                    oMovimientoAsistencia.serieDocumento = obtenerUltimaAsistencia.serieDocumento;
                    oMovimientoAsistencia.numeroRegistroAsistencia = obtenerUltimaAsistencia.numeroRegistroAsistencia;
                    oMovimientoAsistencia.numeroOperacion = obtenerUltimaAsistencia.numeroOperacion;
                    oMovimientoAsistencia.periodo = periodo;
                    oMovimientoAsistencia.periodoPlanilla = periodo;
                    oMovimientoAsistencia.semana = semanaPlanilla;
                    oMovimientoAsistencia.fechaCreacion = DateTime.Now;
                    oMovimientoAsistencia.rendimiento = '0';
                    oMovimientoAsistencia.esResultadoImportacion = 1;
                    oMovimientoAsistencia.totalHorasRefrigerio = 0;
                    oMovimientoAsistencia.totalHoras = listadoPersonalAgrupado.Sum(x => x.horasAcumuladas).Value;
                    oMovimientoAsistencia.codigoReferencia = codigoTransferencia;
                    oMovimientoAsistencia.comentario = "ASISTENCIA GENERADA DESDE LAS MARCACIONES DEL BIOMETRICO DEL DIA " + listadoPersonalAgrupado.FirstOrDefault().fechaAsistencia.Value.ToLongDateString().ToUpper();
                    oMovimientoAsistencia.ventanaReferencia = "MANTENIMIENTO BIOMETRICO";
                    oMovimientoAsistencia.numeroManual = "";
                    oMovimientoAsistencia.procesado = 0;
                    oMovimientoAsistencia.fechaInicioAsistencia = desde;
                    oMovimientoAsistencia.fechaTerminoAsistencia = hasta;
                    oMovimientoAsistencia.estaSincronizado = '1';

                    var agruparByPersona = (from item in listadoPersonalAgrupado
                                            group item by new { item.dni } into j
                                            select new
                                            {
                                                codigoPersona = j.Key.dni.Trim(),
                                            }
                                                ).ToList();
                    int itemRegistroDetalle = 1;
                    foreach (var item in agruparByPersona)
                    {
                        var resultadoConsulta = listadoPersonalAgrupado.Where(x => x.dni == item.codigoPersona).ToList();
                        MovimientoAsistenciaDetalle oAsistencia = new MovimientoAsistenciaDetalle();
                        oAsistencia.codigoEmpresa = oMovimientoAsistencia.codigoEmpresa;
                        oAsistencia.codigoAsistencia = oMovimientoAsistencia.codigoAsistencia;
                        oAsistencia.item = itemRegistroDetalle.ToString().PadLeft(3, '0');
                        oAsistencia.codigoPersona = item.codigoPersona;
                        oAsistencia.codigoConsumidor = "CFUNDOS";
                        oAsistencia.codigoActividad = "OAN";
                        oAsistencia.codigoLabor = "024";
                        oAsistencia.puntoTomaAsistencia = "001";
                        oAsistencia.numeroRegistroAsistencia = "1";
                        oAsistencia.porcentajeAvance = 0;
                        oAsistencia.tipoAsistencia = 'N';
                        oAsistencia.horasDobles = 0;
                        oAsistencia.HorasExtras25 = 0;
                        oAsistencia.HorasExtras35 = 0;
                        oAsistencia.totalHorasExtras = 0;
                        oAsistencia.TotalHoras = resultadoConsulta.Sum(x => x.horasAcumuladas1);
                        oAsistencia.fechaCreacion = DateTime.Now;
                        oAsistencia.horasNocturnas = 0;
                        oAsistencia.horasNocturnasExtras25 = 0;
                        oAsistencia.horasNocturnasExtras35 = 0;
                        oAsistencia.procesado = 0;
                        oDetalleAsistencia.Add(oAsistencia);
                    }

                    #endregion

                    string registro = movimientoAsistenciaNegocio.GrabarAsistencia(periodo, oMovimientoAsistencia, oDetalleAsistencia, oDetallesEliminar);

                    LogTablas oHistorial = new LogTablas();
                    oHistorial.IDEMPRESA = "001";
                    oHistorial.IDLOG = "001" + codigoTransferencia;
                    oHistorial.ITEM = AsignarNumeroItemHistorial(periodo.Substring(0, 4), oHistorial.IDLOG);
                    oHistorial.TABLA = "CheckInOut";
                    oHistorial.IDCAMPO = "codigoTransferencia";
                    oHistorial.CAMPOCLAVE = "codigoTransferencia";
                    oHistorial.IDTABLA = "";
                    oHistorial.EVENTO = "MODIFICA";
                    oHistorial.VALORANTERIOR = "";
                    oHistorial.VALORACTUAL = "ACT. MARCA";
                    oHistorial.IDUSUARIO = Environment.UserName;
                    oHistorial.MAQUINA = Environment.UserName;
                    oHistorial.FECHACREACION = DateTime.Now;
                    oHistorial.VENTANA = "GEN. ASIST";
                    Modelo.LogTablas.InsertOnSubmit(oHistorial);
                    Modelo.SubmitChanges();


                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }
        }

        public void ActualizarMarcacionesBiometroConMovimientoAsistencia(string periodoConsulta, string fecha, string codigoMovimientoPlanilla)
        {
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                Modelo.ext_ActualizarMarcacionesBiometroConMovimientoAsistencia(fecha, codigoMovimientoPlanilla);

                LogTablas oHistorial = new LogTablas();
                oHistorial.IDEMPRESA = "001";
                oHistorial.IDLOG = "001" + codigoMovimientoPlanilla;
                oHistorial.ITEM = AsignarNumeroItemHistorial(periodoConsulta.Substring(0, 4), oHistorial.IDLOG);
                oHistorial.TABLA = "CheckInOut";
                oHistorial.IDCAMPO = "codigoTransferencia";
                oHistorial.CAMPOCLAVE = "codigoTransferencia";
                oHistorial.IDTABLA = "";
                oHistorial.EVENTO = "MODIFICA";
                oHistorial.VALORANTERIOR = "";
                oHistorial.VALORACTUAL = "ACT. MARCA";
                oHistorial.IDUSUARIO = Environment.UserName;
                oHistorial.MAQUINA = Environment.UserName;
                oHistorial.FECHACREACION = DateTime.Now;
                oHistorial.VENTANA = "ASISTENCIA_BIO";
                Modelo.LogTablas.InsertOnSubmit(oHistorial);
                Modelo.SubmitChanges();

            }
        }

        public void LiberarMarcacionesBiometroConMovimientoAsistenciaBlanco(string periodoConsulta, string fecha, string codigoMovimientoPlanilla)
        {
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                Modelo.ext_ActualizarMarcacionesBiometroConMovimientoAsistenciaEnBlanco(fecha, codigoMovimientoPlanilla);
                LogTablas oHistorial = new LogTablas();
                oHistorial.IDEMPRESA = "001";
                oHistorial.IDLOG = "001" + codigoMovimientoPlanilla;
                oHistorial.ITEM = AsignarNumeroItemHistorial(periodoConsulta.Substring(0, 4), oHistorial.IDLOG);
                oHistorial.TABLA = "CheckInOut";
                oHistorial.IDCAMPO = "codigoTransferencia";
                oHistorial.CAMPOCLAVE = "codigoTransferencia";
                oHistorial.IDTABLA = "";
                oHistorial.EVENTO = "MODIFICA";
                oHistorial.VALORANTERIOR = "";
                oHistorial.VALORACTUAL = "LIB. MARCA";
                oHistorial.IDUSUARIO = Environment.UserName;
                oHistorial.MAQUINA = Environment.UserName;
                oHistorial.FECHACREACION = DateTime.Now;
                oHistorial.VENTANA = "ASISTENCIA_BIO";
                Modelo.LogTablas.InsertOnSubmit(oHistorial);
                Modelo.SubmitChanges();
            }
        }


        public List<ext_ListadoAsistenciaMensualizadoResult> ObtenerListadoMensualizadoByFechas(string periodoConsulta, string desde, string hasta)
        {
            List<ext_ListadoAsistenciaMensualizadoResult> listado = new List<ext_ListadoAsistenciaMensualizadoResult>();

            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                listado = Modelo.ext_ListadoAsistenciaMensualizado(desde, hasta).ToList();

            }


            return listado;
        }


        public string AsignarNumeroItemHistorial(string periodo, string idLog)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            string correlativo = "0001";
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(cnx))
            {
                Modelo.CommandTimeout = 980000;

                int? numeroItem = Modelo.LogTableObtenerNumeroItem(idLog).FirstOrDefault().item;
                Modelo.Connection.Close();
                correlativo = (numeroItem + 1).Value.ToString().PadLeft(4, '0');

            }

            return correlativo;
        }


        public List<CheckInOut> ObtenerCodigoUnicoTransferenciaByDia(DateTime fechaAsistencia, string periodo)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();

            List<CheckInOut> listado = new List<CheckInOut>();

            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(cnx))
            {
                Modelo.CommandTimeout = 980000;

                listado = Modelo.CheckInOut.Where(x => x.fechaAsistencia >= fechaAsistencia && x.fechaAsistencia <= fechaAsistencia).ToList();


            }
            return listado;
        }

        public void ActualizarFechaTransferenciaByFechas(string periodoElegido, string desde, string hasta, string codigoTipoPlanilla)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoElegido.Substring(0,4)].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(cnx))
            {
                Modelo.CommandTimeout = 980000;

                Modelo.ext_ActualizarFechaTransferenciaByFechas(desde, hasta);


            }
        }
    }
}
