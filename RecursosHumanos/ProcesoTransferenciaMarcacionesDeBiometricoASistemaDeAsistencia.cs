using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;
using System.Configuration;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.IO;
using System.Threading.Tasks;
using Telerik.WinControls.UI.Localization;
using RecursosHumanos.Datos;
using System.Threading;
using CrystalDecisions.CrystalReports.Engine;
using RecursosHumanos.Negocios;
using RecursosHumanos.Negocios;
using System.Globalization;


namespace RecursosHumanos
{
    public partial class ProcesoTransferenciaMarcacionesDeBiometricoASistemaDeAsistencia : Form
    {
        private string codigoUnicoAccesoSistema = string.Empty;

        private string fechaDesde = string.Empty;
        private string fechaHasta = string.Empty;
        private string periodo = string.Empty;
        private string codigoUnicoTransferencia = string.Empty;
        private int numeroRegistrosnuevos = 0;
        private MesNegocios oMesesNegogcio;
        private UserInfoNegocio userInfoNegocio;
        private UserInfo userInfo;
        private CheckInOutNegocio checkInOutNegocio;
        private List<CheckInOut> checkInOuts;
        private CheckInOut checkInOut;
        private List<string> listadoNroDNI;
        private List<UserInfo> usersInfoBaseAccess;
        private List<UserInfo> usersInfoBaseAccessDepurados;
        private List<UserInfo> usersInfoBaseAccessDepurados2;
        private List<UserInfo> usersInfoBaseDatosSQL;
        private List<UserInfo> usersInfoBaseAccessPorVerificar;
        private int contadorDeTransferenciaDeMarcacion;
        private List<CheckInOut> marcacionesByDia;

        public ProcesoTransferenciaMarcacionesDeBiometricoASistemaDeAsistencia()
        {
            InitializeComponent();
        }

        public ProcesoTransferenciaMarcacionesDeBiometricoASistemaDeAsistencia(string codigoUnicoAccesoSistema, string codigoUsuario)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.codigoUnicoAccesoSistema = codigoUnicoAccesoSistema;
            Program.ClaseCompartida.CodigoUnicoAccesoSistema = codigoUnicoAccesoSistema;
            Program.ClaseCompartida.codigoUsuario = codigoUsuario;

            Inicio();
            CargarMeses();
            ObtenerFechasIniciales();
        }

        private void ObtenerFechasIniciales()
        {
            fechaDesde = this.txtFechaDesde.Text.Trim();
            fechaHasta = this.txtFechaHasta.Text.Trim();
            periodo = this.txtPeriodo.Value + this.txtFechaHasta.Text.Trim().Substring(3, 2);
        }

        private void CargarMeses()
        {
            oMesesNegogcio = new MesNegocios();
            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = MesesNeg.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = oMesesNegogcio.ListarDoceMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }

        public void Inicio()
        {
            try
            {
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + DateTime.Now.Year.ToString()].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "Exotics Producers Packers SAC";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Erick Aurazo";

                this.txtPeriodo.Value = Convert.ToDecimal(DateTime.Now.Year);

                this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
                this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();
                this.txtPeriodo.Value = Convert.ToDecimal(DateTime.Now.Year);





            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void ProcesoTransferenciaMarcacionesDeBiometricoASistemaDeAsistencia_Load(object sender, EventArgs e)
        {

        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboMes.SelectedIndex >= 0)
            {
                ObtenerFechasMes();
            }
        }

        private void ObtenerFechasMes()
        {
            DateTime fecha1;
            DateTime fecha2;

            if (cboMes.SelectedValue.ToString() != "00")
            {
                #region
                //this.txtFechaDesde.Enabled = false;
                //this.txtFechaHasta.Enabled = false;
                if (cboMes.SelectedValue.ToString() == "12")
                {
                    #region Si es mes diciembre
                    fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString() + "/" + this.txtPeriodo.Value.ToString()));// 
                    fecha2 = Convert.ToDateTime("31/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Value.ToString());// 
                    this.txtFechaDesde.Text = fecha1.ToShortDateString();
                    this.txtFechaHasta.Text = fecha2.ToShortDateString();
                    #endregion

                }
                else
                {
                    #region Si es mes 13 habilitar controles de fecha, caso contrario es un mes de enero a noviembre.
                    if (cboMes.SelectedValue.ToString() == "13")
                    {
                        //this.txtFechaDesde.Enabled = true;
                        //this.txtFechaHasta.Enabled = true;


                    }
                    else
                    {
                        fecha2 = Convert.ToDateTime("01/" + (Convert.ToInt32(cboMes.SelectedValue) + 1) + "/" + this.txtPeriodo.Value.ToString()).AddDays(-1);// 
                        fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Value.ToString());// 
                        this.txtFechaDesde.Text = fecha1.ToShortDateString();
                        this.txtFechaHasta.Text = fecha2.ToShortDateString();


                    }
                    #endregion
                }
                #endregion
            }
            else
            {
                if (cboMes.SelectedValue.ToString() == "00")
                {
                    fecha2 = Convert.ToDateTime("31/12/" + this.txtPeriodo.Value.ToString());// 
                    fecha1 = Convert.ToDateTime("01/01/" + this.txtPeriodo.Value.ToString());//
                    this.txtFechaDesde.Text = fecha1.ToShortDateString();
                    this.txtFechaHasta.Text = fecha2.ToShortDateString();

                }

            }
        }

        private void txtAño_ValueChanged(object sender, EventArgs e)
        {
            if (cboMes.SelectedIndex >= 0)
            {
                ObtenerFechasMes();
            }
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            periodo = this.txtPeriodo.Value.ToString();
            gbTransferencia.Enabled = !true;
            pbTransferenciaInformacion.Visible = true;
            bgwHiloTransferenciaUsuarios.RunWorkerAsync();
            btnTransferirMarcaciones.Enabled = false;
            btnTransferirUsuarios.Enabled = false;
        }

        private void bgwHiloTransferenciaUsuarios_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                userInfoNegocio = new UserInfoNegocio();
                usersInfoBaseAccess = new List<UserInfo>();
                usersInfoBaseDatosSQL = new List<UserInfo>();
                usersInfoBaseAccessDepurados = new List<UserInfo>();
                usersInfoBaseAccessDepurados2 = new List<UserInfo>();
                userInfo = new UserInfo();

                usersInfoBaseAccess = userInfoNegocio.ObtenerListadoDeUsuariosDelSistemaBiometrico();
                usersInfoBaseAccessDepurados = usersInfoBaseAccess;
                usersInfoBaseAccessDepurados2 = usersInfoBaseAccess;
                usersInfoBaseDatosSQL = userInfoNegocio.ObtenerListadoDeUsuariosMigradoAlSistemaDeAsistencia(periodo);



                listadoNroDNI = new List<string>();

                /* obtengo todos los dni de la base de sql server */
                foreach (var item in usersInfoBaseDatosSQL)
                {
                    try
                    {
                        if (item != null && item.Badgenumber != null)
                        {
                            listadoNroDNI.Add(item.Badgenumber.Trim());
                        }

                    }
                    catch (Exception Ex)
                    {

                        throw Ex;
                    }

                }


                /* Comparo en esta lista de los dni del acces con los que ya tengo en sql
                 * sólo obtengo los diferentes */
                usersInfoBaseAccessDepurados = (from items in usersInfoBaseAccess.ToList()
                                                where !(listadoNroDNI.Contains(items.Badgenumber.ToString()))
                                                select items).ToList();


                usersInfoBaseAccessPorVerificar = (from items in usersInfoBaseAccess.ToList()
                                                   where (listadoNroDNI.Contains(items.Badgenumber.ToString()))
                                                   select items).ToList();




                usersInfoBaseAccess = usersInfoBaseAccessDepurados;

                /* Actualizar codigo del personal */




                /* Agregar nuevos usuarios */
                if (usersInfoBaseAccess.ToList().Count > 0)
                {
                    userInfoNegocio = new UserInfoNegocio();
                    //numeroRegistrosnuevos = userInfoNegocio.RegistrarUsuarioNuevosDelLectorBiometricoAlSistemaDeAsistencia(usersInfoBaseAccess, periodo);
                    numeroRegistrosnuevos = userInfoNegocio.RegistrarUsuarioNuevosDelLectorBiometricoAlSistemaDeAsistencia(usersInfoBaseAccess, periodo, usersInfoBaseAccessPorVerificar);
                }

                //UserInfo userInfoFormulario = new UserInfo();
                //userInfoFormulario.USERID = 4;
                //userInfo = userInfoNegocio.ObtenerUsuarioDelSistemaBiometrico(userInfoFormulario);

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                numeroRegistrosnuevos = 0;
                return;
            }
        }

        private void bgwHiloTransferenciaUsuarios_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (usersInfo != null && usersInfo.ToList().Count > 0)
            //{
            //    foreach (var item in usersInfo)
            //    {
            //        MessageBox.Show(item.Name.ToString());
            //    }
            //}

            // MessageBox.Show( userInfo.Name.ToString());
            MessageBox.Show("Se han transferido " + numeroRegistrosnuevos.ToString() + " nuevos registros", "Mensaje del sistema");

            btnTransferirMarcaciones.Enabled = !false;
            btnTransferirUsuarios.Enabled = !false;
            gbTransferencia.Enabled = true;
            pbTransferenciaInformacion.Visible = !true;

        }

        private void btnTransferirMarcaciones_Click(object sender, EventArgs e)
        {
            fechaDesde = this.txtFechaDesde.Text + " 00:00:00";
            fechaHasta = this.txtFechaHasta.Text + " 23:59:59";
            periodo = this.txtPeriodo.Value.ToString();
            gbTransferencia.Enabled = !true;
            pbTransferenciaInformacion.Visible = true;
            bgwHiloTransferenciaMarcaciones.RunWorkerAsync();
            btnTransferirMarcaciones.Enabled = false;
            btnTransferirUsuarios.Enabled = false;
        }

        private void bgwHiloTransferenciaMarcaciones_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                checkInOutNegocio = new CheckInOutNegocio();
                checkInOuts = new List<CheckInOut>();
                checkInOut = new CheckInOut();

                checkInOuts = checkInOutNegocio.ObtenerListadoDeMarcacionesDelSistemaBiometricoSinTransferir();
                checkInOuts = checkInOuts.Where(x => x.fechaAsistencia.Value >= Convert.ToDateTime(fechaDesde) && x.fechaAsistencia.Value <= Convert.ToDateTime(fechaHasta)).ToList();

                if (checkInOuts.ToList().Count > 0)
                {
                    var listadoFechas = (from item in checkInOuts
                                         group item by new { item.fechaAsistencia }
                                             into j
                                             select new
                                             {
                                                 fechaAsistencia = j.Key.fechaAsistencia
                                             }
                                            ).ToList();

                    contadorDeTransferenciaDeMarcacion = 0;
                    /* Genere un codigo único por fecha */
                    foreach (var itemFecha in listadoFechas)
                    {

                        checkInOutNegocio = new CheckInOutNegocio();

                        /* Obtener codigoUnico de transferencia por dia */

                        var codigoRegistroByDia = checkInOutNegocio.ObtenerCodigoUnicoTransferenciaByDia(Convert.ToDateTime(itemFecha.fechaAsistencia), periodo).ToList();

                        if (codigoRegistroByDia.ToList().Count > 0)
                        {
                            codigoUnicoTransferencia = codigoRegistroByDia.FirstOrDefault().codigoTransferencia.ToString();
                        }
                        else
                        {
                            codigoUnicoTransferencia = checkInOutNegocio.ObtenerCodigoUnicoTransferencia(periodo);
                        }



                        marcacionesByDia = new List<CheckInOut>();
                        marcacionesByDia = checkInOuts.Where(x => x.fechaAsistencia == itemFecha.fechaAsistencia).ToList();

                        checkInOutNegocio = new CheckInOutNegocio();
                        numeroRegistrosnuevos = checkInOutNegocio.RegistrarMarcacionesNuevosDelLectorBiometricoAlSistemaDeAsistencia(marcacionesByDia, periodo, Program.ClaseCompartida.codigoUsuario, codigoUnicoTransferencia);
                        contadorDeTransferenciaDeMarcacion = contadorDeTransferenciaDeMarcacion + numeroRegistrosnuevos;
                    }

                }

                //UserInfo userInfoFormulario = new UserInfo();
                //userInfoFormulario.USERID = 4;
                //userInfo = userInfoNegocio.ObtenerUsuarioDelSistemaBiometrico(userInfoFormulario);

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHiloTransferenciaMarcaciones_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Se han transferido " + contadorDeTransferenciaDeMarcacion.ToString() + " nuevas marcaciones", "Mensaje del sistema");


            gbTransferencia.Enabled = true;
            pbTransferenciaInformacion.Visible = !true;
        }

        private void btnGenerarTareosDiarios_Click(object sender, EventArgs e)
        {
            if (codigoUnicoTransferencia != string.Empty)
            {
                periodo = this.txtPeriodo.Value.ToString();
                gbTransferencia.Enabled = !true;
                pbTransferenciaInformacion.Visible = true;
                bgwGenerarTareosDiarios.RunWorkerAsync();
            }
        }

        private void bgwGenerarTareosDiarios_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bgwGenerarTareosDiarios_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Se han transferido " + numeroRegistrosnuevos.ToString() + " nuevas marcaciones", "Mensaje del sistema");


            gbTransferencia.Enabled = true;
            pbTransferenciaInformacion.Visible = !true;
        }

    }
}
