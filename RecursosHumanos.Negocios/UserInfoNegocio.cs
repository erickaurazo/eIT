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

namespace RecursosHumanos.Negocios
{
    public class UserInfoNegocio
    {
        private string oConexion;
        private string[] peopleList;

        public UserInfo ObtenerUsuarioDelSistemaBiometrico(UserInfo userInfoFormulario)
        {
            UserInfo userInfo = new UserInfo();

            try
            {
                #region Realizar consulta a base de Access()


                //OleDbConnection MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=X:\\att.mdb ;Persist Security Info=False");
                OleDbConnection MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=D:\\att2000.mdb ;Persist Security Info=False");
                OleDbDataAdapter MyAdapter = new OleDbDataAdapter("select * from UserInfo where USERID = " + userInfoFormulario.USERID + "", MyConnection);
                DataSet MyDataSet = new DataSet();
                MyConnection.Open();
                MyAdapter.Fill(MyDataSet);
                if (MyDataSet.Tables[0].Rows.Count > 0)
                {
                    peopleList = new string[MyDataSet.Tables[0].Rows.Count];

                    for (int i = 0; i < MyDataSet.Tables[0].Rows.Count; i++)
                    {
                        DataRow campo = MyDataSet.Tables[0].Rows[i];
                        userInfo = new UserInfo();
                        userInfo.USERID = Convert.ToInt32(campo["USERID"]);
                        userInfo.Badgenumber = (campo["Badgenumber"].ToString());
                        userInfo.SSN = (campo["SSN"].ToString());
                        userInfo.Name = (campo["Name"].ToString());
                        userInfo.Gender = (campo["Gender"].ToString());
                        userInfo.TITLE = (campo["TITLE"].ToString());
                        userInfo.PAGER = (campo["PAGER"].ToString());
                        userInfo.BIRTHDAY = (campo["BIRTHDAY"].ToString());
                        userInfo.HIREDDAY = (campo["HIREDDAY"].ToString());
                        userInfo.street = (campo["street"].ToString());
                        userInfo.CITY = (campo["CITY"].ToString());
                        userInfo.STATE = (campo["STATE"].ToString());
                        userInfo.ZIP = (campo["ZIP"].ToString());
                        userInfo.OPHONE = (campo["OPHONE"].ToString());
                        userInfo.FPHONE = (campo["FPHONE"].ToString());
                        userInfo.VERIFICATIONMETHOD = String.IsNullOrEmpty(campo["VERIFICATIONMETHOD"].ToString()) ? (Byte?)null : Byte.Parse(campo["VERIFICATIONMETHOD"].ToString());
                        userInfo.DEFAULTDEPTID = String.IsNullOrEmpty(campo["DEFAULTDEPTID"].ToString()) ? (Byte?)null : Byte.Parse(campo["DEFAULTDEPTID"].ToString());
                        userInfo.SECURITYFLAGS = String.IsNullOrEmpty(campo["SECURITYFLAGS"].ToString()) ? (Byte?)null : Byte.Parse(campo["SECURITYFLAGS"].ToString());
                        userInfo.ATT = String.IsNullOrEmpty(campo["ATT"].ToString()) ? (Byte?)null : Byte.Parse(campo["ATT"].ToString());
                        userInfo.INLATE = String.IsNullOrEmpty(campo["INLATE"].ToString()) ? (Byte?)null : Byte.Parse(campo["INLATE"].ToString());
                        userInfo.OUTEARLY = String.IsNullOrEmpty(campo["OUTEARLY"].ToString()) ? (Byte?)null : Byte.Parse(campo["OUTEARLY"].ToString());
                        userInfo.OVERTIME = String.IsNullOrEmpty(campo["OVERTIME"].ToString()) ? (Byte?)null : Byte.Parse(campo["OVERTIME"].ToString());
                        userInfo.SEP = String.IsNullOrEmpty(campo["SEP"].ToString()) ? (Byte?)null : Byte.Parse(campo["SEP"].ToString());
                        userInfo.HOLIDAY = (campo["HOLIDAY"].ToString());
                        userInfo.MINZU = (campo["MINZU"].ToString());
                        userInfo.PASSWORD = (campo["PASSWORD"].ToString());
                        userInfo.LUNCHDURATION = String.IsNullOrEmpty(campo["LUNCHDURATION"].ToString()) ? (Byte?)null : Byte.Parse(campo["LUNCHDURATION"].ToString());
                        userInfo.PHOTO = (campo["PHOTO"].ToString());
                        userInfo.mverifypass = (campo["mverifypass"].ToString());
                        userInfo.Notes = (campo["Notes"].ToString());
                        userInfo.privilege = String.IsNullOrEmpty(campo["privilege"].ToString()) ? (Byte?)null : Byte.Parse(campo["privilege"].ToString());
                        userInfo.InheritDeptSch = String.IsNullOrEmpty(campo["InheritDeptSch"].ToString()) ? (Byte?)null : Byte.Parse(campo["InheritDeptSch"].ToString());
                        userInfo.InheritDeptSchClass = String.IsNullOrEmpty(campo["InheritDeptSchClass"].ToString()) ? (Byte?)null : Byte.Parse(campo["InheritDeptSchClass"].ToString());
                        userInfo.AutoSchPlan = String.IsNullOrEmpty(campo["AutoSchPlan"].ToString()) ? (Byte?)null : Byte.Parse(campo["AutoSchPlan"].ToString());
                        userInfo.MinAutoSchInterval = String.IsNullOrEmpty(campo["MinAutoSchInterval"].ToString()) ? (Byte?)null : Byte.Parse(campo["MinAutoSchInterval"].ToString());
                        userInfo.RegisterOT = String.IsNullOrEmpty(campo["RegisterOT"].ToString()) ? (Byte?)null : Byte.Parse(campo["RegisterOT"].ToString());
                        userInfo.InheritDeptRule = String.IsNullOrEmpty(campo["InheritDeptRule"].ToString()) ? (Byte?)null : Byte.Parse(campo["InheritDeptRule"].ToString());
                        userInfo.EMPRIVILEGE = String.IsNullOrEmpty(campo["EMPRIVILEGE"].ToString()) ? (Byte?)null : Byte.Parse(campo["EMPRIVILEGE"].ToString());
                        userInfo.CardNo = (campo["CardNo"].ToString());
                        userInfo.FaceGroup = String.IsNullOrEmpty(campo["FaceGroup"].ToString()) ? (Byte?)null : Byte.Parse(campo["FaceGroup"].ToString());
                        userInfo.AccGroup = String.IsNullOrEmpty(campo["AccGroup"].ToString()) ? (Byte?)null : Byte.Parse(campo["AccGroup"].ToString());
                        userInfo.UseAccGroupTZ = String.IsNullOrEmpty(campo["UseAccGroupTZ"].ToString()) ? (Byte?)null : Byte.Parse(campo["UseAccGroupTZ"].ToString());
                        userInfo.VerifyCode = String.IsNullOrEmpty(campo["VerifyCode"].ToString()) ? (Byte?)null : Byte.Parse(campo["VerifyCode"].ToString());
                        userInfo.Expires = String.IsNullOrEmpty(campo["Expires"].ToString()) ? (Byte?)null : Byte.Parse(campo["Expires"].ToString());
                        userInfo.ValidCount = String.IsNullOrEmpty(campo["ValidCount"].ToString()) ? (Byte?)null : Byte.Parse(campo["ValidCount"].ToString());
                        userInfo.ValidTimeBegin = String.IsNullOrEmpty(campo["ValidTimeBegin"].ToString()) ? (DateTime?)null : DateTime.Parse(campo["ValidTimeBegin"].ToString());
                        userInfo.ValidTimeEnd = String.IsNullOrEmpty(campo["ValidTimeEnd"].ToString()) ? (DateTime?)null : DateTime.Parse(campo["ValidTimeEnd"].ToString());
                        userInfo.TimeZone1 = String.IsNullOrEmpty(campo["TimeZone1"].ToString()) ? (Byte?)null : Byte.Parse(campo["TimeZone1"].ToString());
                        userInfo.TimeZone2 = String.IsNullOrEmpty(campo["TimeZone2"].ToString()) ? (Byte?)null : Byte.Parse(campo["TimeZone2"].ToString());
                        userInfo.TimeZone3 = String.IsNullOrEmpty(campo["TimeZone3"].ToString()) ? (Byte?)null : Byte.Parse(campo["TimeZone3"].ToString());
                    }
                }
                MyConnection.Close();
                #endregion
            }
            catch
            {
                peopleList = null;
            }

            return userInfo;
        }

        public List<UserInfo> ObtenerListadoDeUsuariosDelSistemaBiometrico()
        {
            List<UserInfo> usersInfo = new List<UserInfo>();


            try
            {
                #region Realizar consulta a base de Access()


                //OleDbConnection MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=X:\\att.mdb ;Persist Security Info=False");
                OleDbConnection MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=D:\\att2000.mdb ;Persist Security Info=False");
                OleDbDataAdapter MyAdapter = new OleDbDataAdapter(@"select * from UserInfo where RTRIM(Cardno) IS NULL union all select * from UserInfo where RTRIM(Cardno) = '' union all select * from UserInfo where RTRIM(Cardno) = '0'   ", MyConnection);
                DataSet MyDataSet = new DataSet();

                MyConnection.Open();
                MyAdapter.Fill(MyDataSet);
                if (MyDataSet.Tables[0].Rows.Count > 0)
                {
                    peopleList = new string[MyDataSet.Tables[0].Rows.Count];

                    for (int i = 0; i < MyDataSet.Tables[0].Rows.Count; i++)
                    {
                        DataRow campo = MyDataSet.Tables[0].Rows[i];
                        UserInfo obj = new UserInfo();
                        obj.USERID = Convert.ToInt32(campo["USERID"]);
                        obj.Badgenumber = (campo["Badgenumber"].ToString());
                        obj.SSN = (campo["SSN"].ToString());
                        obj.Name = (campo["Name"].ToString());
                        obj.Gender = (campo["Gender"].ToString());
                        obj.TITLE = (campo["TITLE"].ToString());
                        obj.PAGER = (campo["PAGER"].ToString());
                        obj.BIRTHDAY = (campo["BIRTHDAY"].ToString());
                        obj.HIREDDAY = (campo["HIREDDAY"].ToString());
                        obj.street = (campo["street"].ToString());
                        obj.CITY = (campo["CITY"].ToString());
                        obj.STATE = (campo["STATE"].ToString());
                        obj.ZIP = (campo["ZIP"].ToString());
                        obj.OPHONE = (campo["OPHONE"].ToString());
                        obj.FPHONE = (campo["FPHONE"].ToString());
                        obj.VERIFICATIONMETHOD = String.IsNullOrEmpty(campo["VERIFICATIONMETHOD"].ToString()) ? (Byte?)null : Byte.Parse(campo["VERIFICATIONMETHOD"].ToString());
                        obj.DEFAULTDEPTID = String.IsNullOrEmpty(campo["DEFAULTDEPTID"].ToString()) ? (Byte?)null : Byte.Parse(campo["DEFAULTDEPTID"].ToString());
                        obj.SECURITYFLAGS = String.IsNullOrEmpty(campo["SECURITYFLAGS"].ToString()) ? (Byte?)null : Byte.Parse(campo["SECURITYFLAGS"].ToString());
                        obj.ATT = String.IsNullOrEmpty(campo["ATT"].ToString()) ? (Byte?)null : Byte.Parse(campo["ATT"].ToString());
                        obj.INLATE = String.IsNullOrEmpty(campo["INLATE"].ToString()) ? (Byte?)null : Byte.Parse(campo["INLATE"].ToString());
                        obj.OUTEARLY = String.IsNullOrEmpty(campo["OUTEARLY"].ToString()) ? (Byte?)null : Byte.Parse(campo["OUTEARLY"].ToString());
                        obj.OVERTIME = String.IsNullOrEmpty(campo["OVERTIME"].ToString()) ? (Byte?)null : Byte.Parse(campo["OVERTIME"].ToString());
                        obj.SEP = String.IsNullOrEmpty(campo["SEP"].ToString()) ? (Byte?)null : Byte.Parse(campo["SEP"].ToString());
                        obj.HOLIDAY = (campo["HOLIDAY"].ToString());
                        obj.MINZU = (campo["MINZU"].ToString());
                        obj.PASSWORD = (campo["PASSWORD"].ToString());
                        obj.LUNCHDURATION = String.IsNullOrEmpty(campo["LUNCHDURATION"].ToString()) ? (Byte?)null : Byte.Parse(campo["LUNCHDURATION"].ToString());
                        obj.PHOTO = (campo["PHOTO"].ToString());
                        obj.mverifypass = (campo["mverifypass"].ToString());
                        obj.Notes = (campo["Notes"].ToString());
                        obj.privilege = String.IsNullOrEmpty(campo["privilege"].ToString()) ? (Byte?)null : Byte.Parse(campo["privilege"].ToString());
                        obj.InheritDeptSch = String.IsNullOrEmpty(campo["InheritDeptSch"].ToString()) ? (Byte?)null : Byte.Parse(campo["InheritDeptSch"].ToString());
                        obj.InheritDeptSchClass = String.IsNullOrEmpty(campo["InheritDeptSchClass"].ToString()) ? (Byte?)null : Byte.Parse(campo["InheritDeptSchClass"].ToString());
                        obj.AutoSchPlan = String.IsNullOrEmpty(campo["AutoSchPlan"].ToString()) ? (Byte?)null : Byte.Parse(campo["AutoSchPlan"].ToString());
                        obj.MinAutoSchInterval = String.IsNullOrEmpty(campo["MinAutoSchInterval"].ToString()) ? (Byte?)null : Byte.Parse(campo["MinAutoSchInterval"].ToString());
                        obj.RegisterOT = String.IsNullOrEmpty(campo["RegisterOT"].ToString()) ? (Byte?)null : Byte.Parse(campo["RegisterOT"].ToString());
                        obj.InheritDeptRule = String.IsNullOrEmpty(campo["InheritDeptRule"].ToString()) ? (Byte?)null : Byte.Parse(campo["InheritDeptRule"].ToString());
                        obj.EMPRIVILEGE = String.IsNullOrEmpty(campo["EMPRIVILEGE"].ToString()) ? (Byte?)null : Byte.Parse(campo["EMPRIVILEGE"].ToString());
                        obj.CardNo = (campo["CardNo"].ToString());
                        obj.FaceGroup = String.IsNullOrEmpty(campo["FaceGroup"].ToString()) ? (Byte?)null : Byte.Parse(campo["FaceGroup"].ToString());
                        obj.AccGroup = String.IsNullOrEmpty(campo["AccGroup"].ToString()) ? (Byte?)null : Byte.Parse(campo["AccGroup"].ToString());
                        obj.UseAccGroupTZ = String.IsNullOrEmpty(campo["UseAccGroupTZ"].ToString()) ? (Byte?)null : Byte.Parse(campo["UseAccGroupTZ"].ToString());
                        obj.VerifyCode = String.IsNullOrEmpty(campo["VerifyCode"].ToString()) ? (Byte?)null : Byte.Parse(campo["VerifyCode"].ToString());
                        obj.Expires = String.IsNullOrEmpty(campo["Expires"].ToString()) ? (Byte?)null : Byte.Parse(campo["Expires"].ToString());
                        obj.ValidCount = String.IsNullOrEmpty(campo["ValidCount"].ToString()) ? (Byte?)null : Byte.Parse(campo["ValidCount"].ToString());
                        obj.ValidTimeBegin = String.IsNullOrEmpty(campo["ValidTimeBegin"].ToString()) ? (DateTime?)null : DateTime.Parse(campo["ValidTimeBegin"].ToString());
                        obj.ValidTimeEnd = String.IsNullOrEmpty(campo["ValidTimeEnd"].ToString()) ? (DateTime?)null : DateTime.Parse(campo["ValidTimeEnd"].ToString());
                        obj.TimeZone1 = String.IsNullOrEmpty(campo["TimeZone1"].ToString()) ? (Byte?)null : Byte.Parse(campo["TimeZone1"].ToString());
                        obj.TimeZone2 = String.IsNullOrEmpty(campo["TimeZone2"].ToString()) ? (Byte?)null : Byte.Parse(campo["TimeZone2"].ToString());
                        obj.TimeZone3 = String.IsNullOrEmpty(campo["TimeZone3"].ToString()) ? (Byte?)null : Byte.Parse(campo["TimeZone3"].ToString());
                        usersInfo.Add(obj);
                    }
                }
                MyConnection.Close();
                #endregion
            }
            catch (Exception ex)
            {
                string mesaggeError = ex.Message.ToString();
            }
            return usersInfo;
        }

        public UserInfo ObtenerUsuarioMigradoAlSistemaDeAsistencia(string periodoConsulta, UserInfo userInfoFormulario)
        {
            UserInfo userInfo = new UserInfo();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                var resultadoConsulta = Modelo.UserInfo.Where(x => x.USERID == userInfoFormulario.USERID).ToList();
                if (resultadoConsulta.ToList().Count == 1)
                {
                    userInfo = resultadoConsulta.Single();
                }
            }

            return userInfo;
        }

        public List<UserInfo> ObtenerListadoDeUsuariosMigradoAlSistemaDeAsistencia(string periodoConsulta)
        {
            List<UserInfo> usersInfo = new List<UserInfo>();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                usersInfo = Modelo.UserInfo.ToList();
            }
            return usersInfo;
        }

        public int RegistrarUsuarioNuevosDelLectorBiometricoAlSistemaDeAsistencia(List<UserInfo> listadoPersonalNuevoBaseAccess, string periodoConsulta)
        {
            int NumeroRegistroTransferidos = 0;
            //using (TransactionScope Scope = new TransactionScope())
            //{
                oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta : "2018")].ToString();
                using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
                {



                    if (listadoPersonalNuevoBaseAccess != null && listadoPersonalNuevoBaseAccess.Where(x => x.Notes.ToString().Trim() != "T").ToList().Count > 0)
                    {
                        #region 
                        foreach (var objeto in listadoPersonalNuevoBaseAccess)
                        {
                            var buscarDNIEnSistemaUsuario = Modelo.UserInfo.Where(x => x.Badgenumber == (String.IsNullOrEmpty(objeto.Badgenumber.ToString()) ? string.Empty : (objeto.Badgenumber.ToString().Trim()))).ToList();
                            if (buscarDNIEnSistemaUsuario.ToList().Count == 0)
                            {
                                #region Registrar en tabla espejo de la base de datos de Asistencia en SQL()
                                /* Transfiero registro a tabla de personal */
                                UserInfo userInfo = new UserInfo();

                                var buscarDNIEnSistemaUsuarioCodigo = Modelo.UserInfo.Where(x => x.USERID == objeto.USERID).ToList();
                                if (buscarDNIEnSistemaUsuarioCodigo.ToList().Count > 0)
                                {
                                    userInfo.USERID = Modelo.UserInfo.ToList().Max(x => x.USERID) + 1;
                                }
                                else
                                {
                                    userInfo.USERID = Convert.ToInt32(objeto.USERID);
                                }
                                
                                
                                userInfo.Badgenumber = String.IsNullOrEmpty(objeto.Badgenumber.ToString()) ? string.Empty : (objeto.Badgenumber.ToString().Trim());
                                userInfo.SSN = String.IsNullOrEmpty(objeto.SSN.ToString()) ? string.Empty : (objeto.SSN.ToString().Trim());
                                userInfo.Name = String.IsNullOrEmpty(objeto.Name.ToString()) ? string.Empty : (objeto.Name.ToString().Trim());
                                userInfo.Gender = String.IsNullOrEmpty(objeto.Gender.ToString()) ? string.Empty : (objeto.Gender.ToString().Trim());
                                userInfo.TITLE = String.IsNullOrEmpty(objeto.TITLE.ToString()) ? string.Empty : (objeto.TITLE.ToString().Trim());
                                userInfo.PAGER = String.IsNullOrEmpty(objeto.PAGER.ToString()) ? string.Empty : (objeto.PAGER.ToString().Trim());
                                userInfo.BIRTHDAY = String.IsNullOrEmpty(objeto.BIRTHDAY.ToString()) ? string.Empty : (objeto.BIRTHDAY.ToString().Trim());
                                userInfo.HIREDDAY = String.IsNullOrEmpty(objeto.HIREDDAY.ToString()) ? string.Empty : (objeto.HIREDDAY.ToString().Trim());
                                userInfo.street = String.IsNullOrEmpty(objeto.street.ToString()) ? string.Empty : (objeto.street.ToString().Trim());
                                userInfo.CITY = String.IsNullOrEmpty(objeto.CITY.ToString()) ? string.Empty : (objeto.CITY.ToString().Trim());
                                userInfo.STATE = String.IsNullOrEmpty(objeto.STATE.ToString()) ? string.Empty : (objeto.STATE.ToString().Trim());
                                userInfo.ZIP = String.IsNullOrEmpty(objeto.ZIP.ToString()) ? string.Empty : (objeto.ZIP.ToString().Trim());
                                userInfo.OPHONE = String.IsNullOrEmpty(objeto.OPHONE.ToString()) ? string.Empty : (objeto.OPHONE.ToString().Trim());
                                userInfo.FPHONE = String.IsNullOrEmpty(objeto.FPHONE.ToString()) ? string.Empty : (objeto.FPHONE.ToString().Trim());
                                userInfo.VERIFICATIONMETHOD = String.IsNullOrEmpty(objeto.VERIFICATIONMETHOD.ToString()) ? (Byte?)null : Byte.Parse(objeto.VERIFICATIONMETHOD.ToString());
                                userInfo.DEFAULTDEPTID = String.IsNullOrEmpty(objeto.DEFAULTDEPTID.ToString()) ? (Byte?)null : Byte.Parse(objeto.DEFAULTDEPTID.ToString());
                                userInfo.SECURITYFLAGS = String.IsNullOrEmpty(objeto.SECURITYFLAGS.ToString()) ? (Byte?)null : Byte.Parse(objeto.SECURITYFLAGS.ToString());
                                userInfo.ATT = String.IsNullOrEmpty(objeto.ATT.ToString()) ? (Byte?)null : Byte.Parse(objeto.ATT.ToString());
                                userInfo.INLATE = String.IsNullOrEmpty(objeto.INLATE.ToString()) ? (Byte?)null : Byte.Parse(objeto.INLATE.ToString());
                                userInfo.OUTEARLY = String.IsNullOrEmpty(objeto.OUTEARLY.ToString()) ? (Byte?)null : Byte.Parse(objeto.OUTEARLY.ToString());
                                userInfo.OVERTIME = String.IsNullOrEmpty(objeto.OVERTIME.ToString()) ? (Byte?)null : Byte.Parse(objeto.OVERTIME.ToString());
                                userInfo.SEP = String.IsNullOrEmpty(objeto.SEP.ToString()) ? (Byte?)null : Byte.Parse(objeto.SEP.ToString());
                                userInfo.HOLIDAY = String.IsNullOrEmpty(objeto.HOLIDAY.ToString()) ? string.Empty : (objeto.HOLIDAY.ToString().Trim());
                                userInfo.MINZU = String.IsNullOrEmpty(objeto.MINZU.ToString()) ? string.Empty : (objeto.MINZU.ToString().Trim());
                                userInfo.PASSWORD = String.IsNullOrEmpty(objeto.PASSWORD.ToString()) ? string.Empty : (objeto.PASSWORD.ToString().Trim());
                                userInfo.LUNCHDURATION = String.IsNullOrEmpty(objeto.LUNCHDURATION.ToString()) ? (Byte?)null : Byte.Parse(objeto.LUNCHDURATION.ToString());
                                userInfo.PHOTO = String.IsNullOrEmpty(objeto.PHOTO.ToString()) ? string.Empty : (objeto.PHOTO.ToString().Trim());
                                userInfo.mverifypass = String.IsNullOrEmpty(objeto.mverifypass.ToString()) ? string.Empty : (objeto.mverifypass.ToString().Trim());
                                //userInfo.Notes = String.IsNullOrEmpty(objeto.Notes.ToString()) ? string.Empty : (objeto.Notes.ToString().Trim());
                                // Registrar como transfernido
                                userInfo.Notes = "T";
                                userInfo.privilege = String.IsNullOrEmpty(objeto.privilege.ToString()) ? (Byte?)null : Byte.Parse(objeto.privilege.ToString());
                                userInfo.InheritDeptSch = String.IsNullOrEmpty(objeto.InheritDeptSch.ToString()) ? (Byte?)null : Byte.Parse(objeto.InheritDeptSch.ToString());
                                userInfo.InheritDeptSchClass = String.IsNullOrEmpty(objeto.InheritDeptSchClass.ToString()) ? (Byte?)null : Byte.Parse(objeto.InheritDeptSchClass.ToString());
                                userInfo.AutoSchPlan = String.IsNullOrEmpty(objeto.AutoSchPlan.ToString()) ? (Byte?)null : Byte.Parse(objeto.AutoSchPlan.ToString());
                                userInfo.MinAutoSchInterval = String.IsNullOrEmpty(objeto.MinAutoSchInterval.ToString()) ? (Byte?)null : Byte.Parse(objeto.MinAutoSchInterval.ToString());
                                userInfo.RegisterOT = String.IsNullOrEmpty(objeto.RegisterOT.ToString()) ? (Byte?)null : Byte.Parse(objeto.RegisterOT.ToString());
                                userInfo.InheritDeptRule = String.IsNullOrEmpty(objeto.InheritDeptRule.ToString()) ? (Byte?)null : Byte.Parse(objeto.InheritDeptRule.ToString());
                                userInfo.EMPRIVILEGE = String.IsNullOrEmpty(objeto.EMPRIVILEGE.ToString()) ? (Byte?)null : Byte.Parse(objeto.EMPRIVILEGE.ToString());
                                userInfo.CardNo = String.IsNullOrEmpty(objeto.CardNo.ToString()) ? string.Empty : (objeto.CardNo.ToString().Trim());
                                userInfo.FaceGroup = String.IsNullOrEmpty(objeto.FaceGroup.ToString()) ? (Byte?)null : Byte.Parse(objeto.FaceGroup.ToString());
                                userInfo.AccGroup = String.IsNullOrEmpty(objeto.AccGroup.ToString()) ? (Byte?)null : Byte.Parse(objeto.AccGroup.ToString());
                                userInfo.UseAccGroupTZ = String.IsNullOrEmpty(objeto.UseAccGroupTZ.ToString()) ? (Byte?)null : Byte.Parse(objeto.UseAccGroupTZ.ToString());
                                userInfo.VerifyCode = String.IsNullOrEmpty(objeto.VerifyCode.ToString()) ? (Byte?)null : Byte.Parse(objeto.VerifyCode.ToString());
                                userInfo.Expires = String.IsNullOrEmpty(objeto.Expires.ToString()) ? (Byte?)null : Byte.Parse(objeto.Expires.ToString());
                                userInfo.ValidCount = String.IsNullOrEmpty(objeto.ValidCount.ToString()) ? (Byte?)null : Byte.Parse(objeto.ValidCount.ToString());
                                userInfo.ValidTimeBegin = String.IsNullOrEmpty(objeto.ValidTimeBegin.ToString()) ? (DateTime?)null : DateTime.Parse(objeto.ValidTimeBegin.ToString());
                                //userInfo.ValidTimeEnd = String.IsNullOrEmpty(objeto.ValidTimeEnd.ToString()) ? (DateTime?)null : DateTime.Parse(objeto.ValidTimeEnd.ToString());
                                //Fecha de transferencia
                                userInfo.ValidTimeEnd = DateTime.Now;
                                userInfo.TimeZone1 = String.IsNullOrEmpty(objeto.TimeZone1.ToString()) ? (Byte?)null : Byte.Parse(objeto.TimeZone1.ToString());
                                userInfo.TimeZone2 = String.IsNullOrEmpty(objeto.TimeZone2.ToString()) ? (Byte?)null : Byte.Parse(objeto.TimeZone2.ToString());
                                userInfo.TimeZone3 = String.IsNullOrEmpty(objeto.TimeZone3.ToString()) ? (Byte?)null : Byte.Parse(objeto.TimeZone3.ToString());
                                Modelo.UserInfo.InsertOnSubmit(userInfo);
                                Modelo.SubmitChanges();

                                /* Actualizo el estado a transferido en la tabla del access */
                                #region Actualizo el estado a transferido en la tabla del access

                                if (buscarDNIEnSistemaUsuarioCodigo.ToList().Count > 0)
                                {
                                    #region Actualizo codigo de usuario y estado de transferido()
                                    OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=D:\\att2000.mdb ;Persist Security Info=False");
                                    OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                                    string sql = null;
                                    //sql = "update UserInfo set cardNO = '1' where Badgenumber = " + Convert.ToInt32(objeto.USERID) + " ";
                                    sql = "update UserInfo set cardNO = '1' , USERID = " + userInfo.USERID + " where Badgenumber = '" + Convert.ToString(userInfo.Badgenumber) + "' ";
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

                                    #region Actualizo las marcaciones tambien()
                                    
                                    //
                                    OleDbConnection connection2 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=D:\\att2000.mdb ;Persist Security Info=False");
                                    OleDbDataAdapter oledbAdapter2 = new OleDbDataAdapter();
                                    string sql2 = null;
                                    //sql = "update UserInfo set cardNO = '1' where Badgenumber = " + Convert.ToInt32(objeto.USERID) + " ";
                                    sql2 = "UPDATE  CHECKINOUT  inner join USERINFO  ON CHECKINOUT.USERID=USERINFO.USERID SET CHECKINOUT.USERID = " + userInfo.USERID + " WHERE USERINFO.Badgenumber = '" + Convert.ToString(objeto.Badgenumber) + "' ";                                    
                                    try
                                    {
                                        connection2.Open();
                                        oledbAdapter2.UpdateCommand = connection2.CreateCommand();
                                        oledbAdapter2.UpdateCommand.CommandText = sql2;
                                        oledbAdapter2.UpdateCommand.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        string mesaggeError = ex.Message.ToString();
                                    }

                                    #endregion
                                }
                                else if (buscarDNIEnSistemaUsuarioCodigo.ToList().Count == 0)
                                {
                                    #region Actualizo sólo el estado de transferido()
                                    OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=D:\\att2000.mdb ;Persist Security Info=False");
                                    OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                                    string sql = null;
                                    //sql = "update UserInfo set cardNO = '1' where Badgenumber = " + Convert.ToInt32(objeto.USERID) + " ";
                                    sql = "update UserInfo set cardNO = '1' where Badgenumber = " + Convert.ToString(objeto.Badgenumber) + " ";
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

                               
                                #endregion

                                #endregion
                            }


                            /* Registro en el catálogo de personal */

                            #region Registro en el catálogo de personal();
                            var buscarDNIEnSistema = Modelo.Personas.Where(x => x.codigoPersona == (String.IsNullOrEmpty(objeto.Badgenumber.ToString()) ? string.Empty : (objeto.Badgenumber.ToString().Trim()))).ToList();
                            if (buscarDNIEnSistema.ToList().Count == 0)
                            {
                                #region #registrar personal nuevo ()
                                Persona oPersona = new Persona();
                                oPersona.codigoPersona = String.IsNullOrEmpty(objeto.Badgenumber.ToString()) ? string.Empty : (objeto.Badgenumber.ToString().Trim());
                                oPersona.estado = 1;
                                oPersona.apellidoMaterno = "";
                                oPersona.apellidoPaterno = "";
                                oPersona.nombres = String.IsNullOrEmpty(objeto.Name.ToString()) ? string.Empty : (objeto.Name.ToString().Trim());
                                oPersona.codigoControlTareo = "";
                                oPersona.observacion = "";
                                oPersona.rutaFoto = "";
                                oPersona.rutaFirma = "";
                                oPersona.sexo = String.IsNullOrEmpty(objeto.Gender.ToString()) ? (char?)null : char.Parse(objeto.Gender.ToString().Trim());
                                oPersona.sincronizado = '1';
                                oPersona.tipoCuentaBanco = (char?)null;
                                oPersona.codigoAutogeneradoAFP = "";
                                oPersona.numeroCuentaBanco = "";
                                oPersona.numeroCuentaCTS = "";
                                oPersona.numeroDireccion = (decimal?)null; ;
                                oPersona.referenciaDeDireccion = "";
                                oPersona.fechaNacimiento = String.IsNullOrEmpty(objeto.BIRTHDAY.ToString()) ? (DateTime?)null : DateTime.Parse(objeto.BIRTHDAY.ToString());
                                oPersona.InicioFechaAFP = (DateTime?)null;
                                oPersona.InicioFechaONP = (DateTime?)null;
                                oPersona.codigoAutogeneradoIPSS = "";
                                oPersona.numeroDocumento = String.IsNullOrEmpty(objeto.Badgenumber.ToString()) ? string.Empty : (objeto.Badgenumber.ToString().Trim());
                                oPersona.codigoRegimenPensionario = (char?)null;
                                oPersona.telefono = "";
                                oPersona.telefonoSecundario = "";
                                oPersona.TelefonoCelular = "";
                                oPersona.email = "";
                                oPersona.viaDeDireccion = "";
                                oPersona.ZonaDeDireccion = "";
                                oPersona.fechaCreacion = DateTime.Now;
                                oPersona.codigoAFP = "";
                                oPersona.codigoNacionalidad = "";
                                oPersona.codigoLugarDeNacimiento = "";
                                oPersona.codigoDocumentoIdentidad = "";
                                oPersona.codigoZona = "";
                                oPersona.codigoEstadoCivil = "";
                                oPersona.codigoEPS = "";
                                oPersona.CodigoVia = "";
                                oPersona.codigoBancoCTS = "";
                                oPersona.codigoBanco = "";
                                oPersona.codigoUbigeo = "";
                                oPersona.codigoMonedaBanco = "";
                                oPersona.CodigoMonedaCTS = "";
                                oPersona.ESSALUDVida = "";
                                oPersona.estaEnListaNegra = "";
                                oPersona.codigoCategoria = (char?)null;
                                oPersona.ssPensionista = (decimal?)null;
                                oPersona.codigoTipoPension = (char?)null;
                                oPersona.codigoClienteProveedor = "";
                                oPersona.RegimenLaboral = (char?)null;
                                oPersona.CodigoSituacionEPS = "";
                                oPersona.CodigoRegimen = "";
                                oPersona.EsDiscapacitado = (decimal?)null;
                                oPersona.TipoRemuneracion = (char?)null;
                                oPersona.PerteneceSindicato = (decimal?)null;
                                Modelo.Personas.InsertOnSubmit(oPersona);
                                Modelo.SubmitChanges();
                                NumeroRegistroTransferidos = NumeroRegistroTransferidos + 1;
                                #endregion
                            }

                            #endregion

                        }
                        #endregion
                    }
                }
            //    Scope.Complete();
            //}
            return NumeroRegistroTransferidos;
        }


        public int RegistrarUsuarioNuevosDelLectorBiometricoAlSistemaDeAsistencia(List<UserInfo> listadoPersonalNuevoBaseAccess, string periodoConsulta, List<UserInfo> listadoPersonalBaseSQL)
        {
            int NumeroRegistroTransferidos = 0;
            //using (TransactionScope Scope = new TransactionScope())
            //{
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {

                foreach (var personalBaseSQL in listadoPersonalBaseSQL)
                {
                    var buscarDNIEnBaseSQL = Modelo.UserInfo.Where(x => x.Badgenumber == (String.IsNullOrEmpty(personalBaseSQL.Badgenumber.ToString()) ? string.Empty : (personalBaseSQL.Badgenumber.ToString().Trim()))).ToList();
                    if (buscarDNIEnBaseSQL.ToList().Count == 1)
                    {
                        #region Actualizar codigo de personal()

                        var buscarDNIEnSistemaUsuarioCodigo = buscarDNIEnBaseSQL.Where(x => x.USERID == personalBaseSQL.USERID).ToList();
                        if (buscarDNIEnSistemaUsuarioCodigo.ToList().Count == 0)
                        {
                            #region Actualizo codigo de usuario y estado de transferido()
                            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=D:\\att2000.mdb ;Persist Security Info=False");
                            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                            string sql = null;
                            //sql = "update UserInfo set cardNO = '1' where USERID = " + Convert.ToInt32(objeto.USERID) + " ";
                            sql = "update UserInfo set cardNO = '1' , USERID = " + buscarDNIEnBaseSQL.FirstOrDefault().USERID + " where Badgenumber = '" + Convert.ToString(personalBaseSQL.Badgenumber) + "' ";
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

                            #region Actualizo las marcaciones tambien()

                            //
                            OleDbConnection connection2 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=D:\\att2000.mdb ;Persist Security Info=False");
                            OleDbDataAdapter oledbAdapter2 = new OleDbDataAdapter();
                            string sql2 = null;
                            //sql = "update UserInfo set cardNO = '1' where Badgenumber = " + Convert.ToInt32(objeto.USERID) + " ";
                            sql2 = "UPDATE  CHECKINOUT  inner join USERINFO  ON CHECKINOUT.USERID=USERINFO.USERID SET CHECKINOUT.USERID = " + buscarDNIEnBaseSQL.FirstOrDefault().USERID + " WHERE USERINFO.Badgenumber = '" + Convert.ToString(personalBaseSQL.Badgenumber) + "' ";
                            try
                            {
                                connection2.Open();
                                oledbAdapter2.UpdateCommand = connection2.CreateCommand();
                                oledbAdapter2.UpdateCommand.CommandText = sql2;
                                oledbAdapter2.UpdateCommand.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                string mesaggeError = ex.Message.ToString();
                            }

                            #endregion
                        }
                        

                        #endregion
                    }
                }

                if (listadoPersonalNuevoBaseAccess != null && listadoPersonalNuevoBaseAccess.Where(x => x.Notes.ToString().Trim() != "T").ToList().Count > 0)
                {
                    #region
                    foreach (var objeto in listadoPersonalNuevoBaseAccess)
                    {
                        var buscarDNIEnSistemaUsuario = Modelo.UserInfo.Where(x => x.Badgenumber == (String.IsNullOrEmpty(objeto.Badgenumber.ToString()) ? string.Empty : (objeto.Badgenumber.ToString().Trim()))).ToList();
                        if (buscarDNIEnSistemaUsuario.ToList().Count == 0)
                        {
                            #region Registrar en tabla espejo de la base de datos de Asistencia en SQL()
                            /* Transfiero registro a tabla de personal */
                            UserInfo userInfo = new UserInfo();

                            var buscarDNIEnSistemaUsuarioCodigo = Modelo.UserInfo.Where(x => x.USERID == objeto.USERID).ToList();
                            if (buscarDNIEnSistemaUsuarioCodigo.ToList().Count > 0)
                            {
                                userInfo.USERID = Modelo.UserInfo.ToList().Max(x => x.USERID) + 1;
                            }
                            else
                            {
                                userInfo.USERID = Convert.ToInt32(objeto.USERID);
                            }


                            userInfo.Badgenumber = String.IsNullOrEmpty(objeto.Badgenumber.ToString()) ? string.Empty : (objeto.Badgenumber.ToString().Trim());
                            userInfo.SSN = String.IsNullOrEmpty(objeto.SSN.ToString()) ? string.Empty : (objeto.SSN.ToString().Trim());
                            userInfo.Name = String.IsNullOrEmpty(objeto.Name.ToString()) ? string.Empty : (objeto.Name.ToString().Trim());
                            userInfo.Gender = String.IsNullOrEmpty(objeto.Gender.ToString()) ? string.Empty : (objeto.Gender.ToString().Trim());
                            userInfo.TITLE = String.IsNullOrEmpty(objeto.TITLE.ToString()) ? string.Empty : (objeto.TITLE.ToString().Trim());
                            userInfo.PAGER = String.IsNullOrEmpty(objeto.PAGER.ToString()) ? string.Empty : (objeto.PAGER.ToString().Trim());
                            userInfo.BIRTHDAY = String.IsNullOrEmpty(objeto.BIRTHDAY.ToString()) ? string.Empty : (objeto.BIRTHDAY.ToString().Trim());
                            userInfo.HIREDDAY = String.IsNullOrEmpty(objeto.HIREDDAY.ToString()) ? string.Empty : (objeto.HIREDDAY.ToString().Trim());
                            userInfo.street = String.IsNullOrEmpty(objeto.street.ToString()) ? string.Empty : (objeto.street.ToString().Trim());
                            userInfo.CITY = String.IsNullOrEmpty(objeto.CITY.ToString()) ? string.Empty : (objeto.CITY.ToString().Trim());
                            userInfo.STATE = String.IsNullOrEmpty(objeto.STATE.ToString()) ? string.Empty : (objeto.STATE.ToString().Trim());
                            userInfo.ZIP = String.IsNullOrEmpty(objeto.ZIP.ToString()) ? string.Empty : (objeto.ZIP.ToString().Trim());
                            userInfo.OPHONE = String.IsNullOrEmpty(objeto.OPHONE.ToString()) ? string.Empty : (objeto.OPHONE.ToString().Trim());
                            userInfo.FPHONE = String.IsNullOrEmpty(objeto.FPHONE.ToString()) ? string.Empty : (objeto.FPHONE.ToString().Trim());
                            userInfo.VERIFICATIONMETHOD = String.IsNullOrEmpty(objeto.VERIFICATIONMETHOD.ToString()) ? (Byte?)null : Byte.Parse(objeto.VERIFICATIONMETHOD.ToString());
                            userInfo.DEFAULTDEPTID = String.IsNullOrEmpty(objeto.DEFAULTDEPTID.ToString()) ? (Byte?)null : Byte.Parse(objeto.DEFAULTDEPTID.ToString());
                            userInfo.SECURITYFLAGS = String.IsNullOrEmpty(objeto.SECURITYFLAGS.ToString()) ? (Byte?)null : Byte.Parse(objeto.SECURITYFLAGS.ToString());
                            userInfo.ATT = String.IsNullOrEmpty(objeto.ATT.ToString()) ? (Byte?)null : Byte.Parse(objeto.ATT.ToString());
                            userInfo.INLATE = String.IsNullOrEmpty(objeto.INLATE.ToString()) ? (Byte?)null : Byte.Parse(objeto.INLATE.ToString());
                            userInfo.OUTEARLY = String.IsNullOrEmpty(objeto.OUTEARLY.ToString()) ? (Byte?)null : Byte.Parse(objeto.OUTEARLY.ToString());
                            userInfo.OVERTIME = String.IsNullOrEmpty(objeto.OVERTIME.ToString()) ? (Byte?)null : Byte.Parse(objeto.OVERTIME.ToString());
                            userInfo.SEP = String.IsNullOrEmpty(objeto.SEP.ToString()) ? (Byte?)null : Byte.Parse(objeto.SEP.ToString());
                            userInfo.HOLIDAY = String.IsNullOrEmpty(objeto.HOLIDAY.ToString()) ? string.Empty : (objeto.HOLIDAY.ToString().Trim());
                            userInfo.MINZU = String.IsNullOrEmpty(objeto.MINZU.ToString()) ? string.Empty : (objeto.MINZU.ToString().Trim());
                            userInfo.PASSWORD = String.IsNullOrEmpty(objeto.PASSWORD.ToString()) ? string.Empty : (objeto.PASSWORD.ToString().Trim());
                            userInfo.LUNCHDURATION = String.IsNullOrEmpty(objeto.LUNCHDURATION.ToString()) ? (Byte?)null : Byte.Parse(objeto.LUNCHDURATION.ToString());
                            userInfo.PHOTO = String.IsNullOrEmpty(objeto.PHOTO.ToString()) ? string.Empty : (objeto.PHOTO.ToString().Trim());
                            userInfo.mverifypass = String.IsNullOrEmpty(objeto.mverifypass.ToString()) ? string.Empty : (objeto.mverifypass.ToString().Trim());
                            //userInfo.Notes = String.IsNullOrEmpty(objeto.Notes.ToString()) ? string.Empty : (objeto.Notes.ToString().Trim());
                            // Registrar como transfernido
                            userInfo.Notes = "T";
                            userInfo.privilege = String.IsNullOrEmpty(objeto.privilege.ToString()) ? (Byte?)null : Byte.Parse(objeto.privilege.ToString());
                            userInfo.InheritDeptSch = String.IsNullOrEmpty(objeto.InheritDeptSch.ToString()) ? (Byte?)null : Byte.Parse(objeto.InheritDeptSch.ToString());
                            userInfo.InheritDeptSchClass = String.IsNullOrEmpty(objeto.InheritDeptSchClass.ToString()) ? (Byte?)null : Byte.Parse(objeto.InheritDeptSchClass.ToString());
                            userInfo.AutoSchPlan = String.IsNullOrEmpty(objeto.AutoSchPlan.ToString()) ? (Byte?)null : Byte.Parse(objeto.AutoSchPlan.ToString());
                            userInfo.MinAutoSchInterval = String.IsNullOrEmpty(objeto.MinAutoSchInterval.ToString()) ? (Byte?)null : Byte.Parse(objeto.MinAutoSchInterval.ToString());
                            userInfo.RegisterOT = String.IsNullOrEmpty(objeto.RegisterOT.ToString()) ? (Byte?)null : Byte.Parse(objeto.RegisterOT.ToString());
                            userInfo.InheritDeptRule = String.IsNullOrEmpty(objeto.InheritDeptRule.ToString()) ? (Byte?)null : Byte.Parse(objeto.InheritDeptRule.ToString());
                            userInfo.EMPRIVILEGE = String.IsNullOrEmpty(objeto.EMPRIVILEGE.ToString()) ? (Byte?)null : Byte.Parse(objeto.EMPRIVILEGE.ToString());
                            userInfo.CardNo = String.IsNullOrEmpty(objeto.CardNo.ToString()) ? string.Empty : (objeto.CardNo.ToString().Trim());
                            userInfo.FaceGroup = String.IsNullOrEmpty(objeto.FaceGroup.ToString()) ? (Byte?)null : Byte.Parse(objeto.FaceGroup.ToString());
                            userInfo.AccGroup = String.IsNullOrEmpty(objeto.AccGroup.ToString()) ? (Byte?)null : Byte.Parse(objeto.AccGroup.ToString());
                            userInfo.UseAccGroupTZ = String.IsNullOrEmpty(objeto.UseAccGroupTZ.ToString()) ? (Byte?)null : Byte.Parse(objeto.UseAccGroupTZ.ToString());
                            userInfo.VerifyCode = String.IsNullOrEmpty(objeto.VerifyCode.ToString()) ? (Byte?)null : Byte.Parse(objeto.VerifyCode.ToString());
                            userInfo.Expires = String.IsNullOrEmpty(objeto.Expires.ToString()) ? (Byte?)null : Byte.Parse(objeto.Expires.ToString());
                            userInfo.ValidCount = String.IsNullOrEmpty(objeto.ValidCount.ToString()) ? (Byte?)null : Byte.Parse(objeto.ValidCount.ToString());
                            userInfo.ValidTimeBegin = String.IsNullOrEmpty(objeto.ValidTimeBegin.ToString()) ? (DateTime?)null : DateTime.Parse(objeto.ValidTimeBegin.ToString());
                            //userInfo.ValidTimeEnd = String.IsNullOrEmpty(objeto.ValidTimeEnd.ToString()) ? (DateTime?)null : DateTime.Parse(objeto.ValidTimeEnd.ToString());
                            //Fecha de transferencia
                            userInfo.ValidTimeEnd = DateTime.Now;
                            userInfo.TimeZone1 = String.IsNullOrEmpty(objeto.TimeZone1.ToString()) ? (Byte?)null : Byte.Parse(objeto.TimeZone1.ToString());
                            userInfo.TimeZone2 = String.IsNullOrEmpty(objeto.TimeZone2.ToString()) ? (Byte?)null : Byte.Parse(objeto.TimeZone2.ToString());
                            userInfo.TimeZone3 = String.IsNullOrEmpty(objeto.TimeZone3.ToString()) ? (Byte?)null : Byte.Parse(objeto.TimeZone3.ToString());
                            Modelo.UserInfo.InsertOnSubmit(userInfo);
                            Modelo.SubmitChanges();
                            #endregion

                            /* Actualizo el estado a transferido en la tabla del access */
                            #region Actualizo el estado a transferido en la tabla del access

                            if (buscarDNIEnSistemaUsuarioCodigo.ToList().Count > 0)
                            {
                                #region Actualizo codigo de usuario y estado de transferido()
                                OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=D:\\att2000.mdb ;Persist Security Info=False");
                                OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                                string sql = null;
                                //sql = "update UserInfo set cardNO = '1' where Badgenumber = " + Convert.ToInt32(objeto.USERID) + " ";
                                sql = "update UserInfo set cardNO = '1' , USERID = " + userInfo.USERID + " where Badgenumber = '" + Convert.ToString(userInfo.Badgenumber) + "' ";
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

                                #region Actualizo las marcaciones tambien()

                                //
                                OleDbConnection connection2 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=D:\\att2000.mdb ;Persist Security Info=False");
                                OleDbDataAdapter oledbAdapter2 = new OleDbDataAdapter();
                                string sql2 = null;
                                //sql = "update UserInfo set cardNO = '1' where Badgenumber = " + Convert.ToInt32(objeto.USERID) + " ";
                                sql2 = "UPDATE  CHECKINOUT  inner join USERINFO  ON CHECKINOUT.USERID=USERINFO.USERID SET CHECKINOUT.USERID = " + userInfo.USERID + " WHERE USERINFO.Badgenumber = '" + Convert.ToString(objeto.Badgenumber) + "' ";
                                try
                                {
                                    connection2.Open();
                                    oledbAdapter2.UpdateCommand = connection2.CreateCommand();
                                    oledbAdapter2.UpdateCommand.CommandText = sql2;
                                    oledbAdapter2.UpdateCommand.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    string mesaggeError = ex.Message.ToString();
                                }

                                #endregion
                            }
                            else if (buscarDNIEnSistemaUsuarioCodigo.ToList().Count == 0)
                            {
                                #region Actualizo sólo el estado de transferido()
                                OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User ID=;Password=; Data Source=D:\\att2000.mdb ;Persist Security Info=False");
                                OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                                string sql = null;
                                //sql = "update UserInfo set cardNO = '1' where Badgenumber = " + Convert.ToInt32(objeto.USERID) + " ";
                                sql = "update UserInfo set cardNO = '1' where Badgenumber = " + Convert.ToString(objeto.Badgenumber) + " ";
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


                            #endregion

                            
                        }


                        /* Registro en el catálogo de personal */

                        #region Registro en el catálogo de personal();
                        var buscarDNIEnSistema = Modelo.Personas.Where(x => x.codigoPersona == (String.IsNullOrEmpty(objeto.Badgenumber.ToString()) ? string.Empty : (objeto.Badgenumber.ToString().Trim()))).ToList();
                        if (buscarDNIEnSistema.ToList().Count == 0)
                        {
                            #region #registrar personal nuevo ()
                            Persona oPersona = new Persona();
                            oPersona.codigoPersona = String.IsNullOrEmpty(objeto.Badgenumber.ToString()) ? string.Empty : (objeto.Badgenumber.ToString().Trim());
                            oPersona.estado = 1;
                            oPersona.apellidoMaterno = "";
                            oPersona.apellidoPaterno = "";
                            oPersona.nombres = String.IsNullOrEmpty(objeto.Name.ToString()) ? string.Empty : (objeto.Name.ToString().Trim());
                            oPersona.codigoControlTareo = "";
                            oPersona.observacion = "";
                            oPersona.rutaFoto = "";
                            oPersona.rutaFirma = "";
                            oPersona.sexo = String.IsNullOrEmpty(objeto.Gender.ToString()) ? (char?)null : char.Parse(objeto.Gender.ToString().Trim());
                            oPersona.sincronizado = '1';
                            oPersona.tipoCuentaBanco = (char?)null;
                            oPersona.codigoAutogeneradoAFP = "";
                            oPersona.numeroCuentaBanco = "";
                            oPersona.numeroCuentaCTS = "";
                            oPersona.numeroDireccion = (decimal?)null; ;
                            oPersona.referenciaDeDireccion = "";
                            oPersona.fechaNacimiento = String.IsNullOrEmpty(objeto.BIRTHDAY.ToString()) ? (DateTime?)null : DateTime.Parse(objeto.BIRTHDAY.ToString());
                            oPersona.InicioFechaAFP = (DateTime?)null;
                            oPersona.InicioFechaONP = (DateTime?)null;
                            oPersona.codigoAutogeneradoIPSS = "";
                            oPersona.numeroDocumento = String.IsNullOrEmpty(objeto.Badgenumber.ToString()) ? string.Empty : (objeto.Badgenumber.ToString().Trim());
                            oPersona.codigoRegimenPensionario = (char?)null;
                            oPersona.telefono = "";
                            oPersona.telefonoSecundario = "";
                            oPersona.TelefonoCelular = "";
                            oPersona.email = "";
                            oPersona.viaDeDireccion = "";
                            oPersona.ZonaDeDireccion = "";
                            oPersona.fechaCreacion = DateTime.Now;
                            oPersona.codigoAFP = "";
                            oPersona.codigoNacionalidad = "";
                            oPersona.codigoLugarDeNacimiento = "";
                            oPersona.codigoDocumentoIdentidad = "";
                            oPersona.codigoZona = "";
                            oPersona.codigoEstadoCivil = "";
                            oPersona.codigoEPS = "";
                            oPersona.CodigoVia = "";
                            oPersona.codigoBancoCTS = "";
                            oPersona.codigoBanco = "";
                            oPersona.codigoUbigeo = "";
                            oPersona.codigoMonedaBanco = "";
                            oPersona.CodigoMonedaCTS = "";
                            oPersona.ESSALUDVida = "";
                            oPersona.estaEnListaNegra = "";
                            oPersona.codigoCategoria = (char?)null;
                            oPersona.ssPensionista = (decimal?)null;
                            oPersona.codigoTipoPension = (char?)null;
                            oPersona.codigoClienteProveedor = "";
                            oPersona.RegimenLaboral = (char?)null;
                            oPersona.CodigoSituacionEPS = "";
                            oPersona.CodigoRegimen = "";
                            oPersona.EsDiscapacitado = (decimal?)null;
                            oPersona.TipoRemuneracion = (char?)null;
                            oPersona.PerteneceSindicato = (decimal?)null;
                            Modelo.Personas.InsertOnSubmit(oPersona);
                            Modelo.SubmitChanges();
                            NumeroRegistroTransferidos = NumeroRegistroTransferidos + 1;
                            #endregion
                        }

                        #endregion

                    }
                    #endregion
                }
            }
            //    Scope.Complete();
            //}
            return NumeroRegistroTransferidos;
        }

    }
}
