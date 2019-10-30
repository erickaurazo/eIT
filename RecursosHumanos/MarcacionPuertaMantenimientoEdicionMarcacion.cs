using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using RecursosHumanos.Negocios;
using System.Configuration;
using DevSoftSolutionsControls;
using DevSoftSolutionsDataAccess;
using DevSoftSolutionsExtensions;
using System.Linq;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;
using System.Collections;
using MyControlsDataBinding.Controles;
namespace RecursosHumanos
{
    public partial class MarcacionPuertaMantenimientoEdicionMarcacion : Form
    {
        private int CorrelativoEditar;
        private List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIByCorrelativoResult> listado;
        private CheckInOutNegocio modelo;
        private List<GrupoH> listadoTipoMarcacion;
        private CheckInOut oCheckInOut;
        private string nombres;
        private string dni;
        private string codigoBiometricoPersona;
        private string AsistenciaCodigoMovimiento;
        private string fecha;
        private string codigoTransferencia;


        public MarcacionPuertaMantenimientoEdicionMarcacion()
        {
            InitializeComponent();
        }

        public void Inicio()
        {
            try
            {
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + Program.ClaseCompartida.periodoElegido.Substring(0, 4)].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EXOTIC'S PRODUCER PACKERS";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Erick Aurazo";
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public MarcacionPuertaMantenimientoEdicionMarcacion(string nombres, string dni, string codigoBiometricoPersona, string AsistenciaCodigoMovimiento, string fecha, int CorrelativoEditar, string codigoTransferencia)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.nombres = nombres;
            this.dni = dni;
            this.codigoBiometricoPersona = codigoBiometricoPersona;
            this.AsistenciaCodigoMovimiento = AsistenciaCodigoMovimiento;
            this.fecha = fecha;
            this.CorrelativoEditar = CorrelativoEditar;
            this.codigoTransferencia = codigoTransferencia;
            progressBarF.Visible = true;
            gbEdicion.Enabled = false;
            listadoTipoMarcacion = new List<GrupoH>();
            Inicio();
            bwgHilo.RunWorkerAsync();
        }


        public MarcacionPuertaMantenimientoEdicionMarcacion(int CorrelativoEditar)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.CorrelativoEditar = CorrelativoEditar;
            progressBarF.Visible = true;
            gbEdicion.Enabled = false;
            listadoTipoMarcacion = new List<GrupoH>();

            bwgHilo.RunWorkerAsync();

        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            listado = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIByCorrelativoResult>();
            ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIByCorrelativoResult oresultado = new ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIByCorrelativoResult();
            oresultado.codigoUsuarioMarcacion = Convert.ToInt32(this.codigoBiometricoPersona);
            listado.Add(oresultado);

            if (this.CorrelativoEditar > 0)
            {

                modelo = new CheckInOutNegocio();
                listado = modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIByCorrelativo(Program.ClaseCompartida.periodoElegido, this.CorrelativoEditar);
            }

            modelo = new CheckInOutNegocio();
            listadoTipoMarcacion = new List<GrupoH>();
            listadoTipoMarcacion = modelo.ListarTipoMarcacion();
        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.txtCodigoTransferencia.Clear();
            this.txtCorrelativo.Clear();
            this.txtDNI.Clear();
            this.txtFecha.Clear();
            this.txtMarcacion.Clear();
            this.txtMovimientoAsistencia.Clear();
            this.txtNombres.Clear();

            cboTipoMarcacion.DisplayMember = "Descripcion";
            cboTipoMarcacion.ValueMember = "Codigo";
            cboTipoMarcacion.DataSource = listadoTipoMarcacion.ToList();

            if (this.CorrelativoEditar > 0)
            {
                if (listado.Count > 0)
                {
                    this.txtCodigoTransferencia.Text = listado.FirstOrDefault().codigoTransferencia != null ? listado.FirstOrDefault().codigoTransferencia.Trim() : string.Empty;
                    this.txtCorrelativo.Text = listado.FirstOrDefault().correlativo != null ? listado.FirstOrDefault().correlativo.ToString() : string.Empty;
                    this.txtDNI.Text = listado.FirstOrDefault().dni != null ? listado.FirstOrDefault().dni.Trim() : string.Empty;
                    this.txtFecha.Text = listado.FirstOrDefault().fechaAsistencia != null ? listado.FirstOrDefault().fechaAsistencia.ToPresentationDate().Trim() : string.Empty;
                    this.txtMarcacion.Text = listado.FirstOrDefault().horaMarcacion != null ? listado.FirstOrDefault().horaMarcacion.Trim() : string.Empty;
                    this.txtMovimientoAsistencia.Text = listado.FirstOrDefault().codigoMovimientoAsistencia != null ? listado.FirstOrDefault().codigoMovimientoAsistencia.Trim() : string.Empty;
                    this.txtNombres.Text = listado.FirstOrDefault().Nombres != null ? listado.FirstOrDefault().Nombres.Trim() : string.Empty;
                    cboTipoMarcacion.SelectedValue = listado.FirstOrDefault().tipoMarcacion != null ? listado.FirstOrDefault().tipoMarcacion.Trim() : "I";
                }
            }
            else
            {
                this.txtCodigoTransferencia.Text = this.AsistenciaCodigoMovimiento;
                this.txtCorrelativo.Text = this.CorrelativoEditar.ToString();
                this.txtDNI.Text = this.dni;
                this.txtNombres.Text = this.nombres;
                this.txtFecha.Text = this.fecha;
                this.txtCodigoBiometrico.Text = this.codigoBiometricoPersona;
                this.txtMarcacion.Text = DateTime.Now.ToPresentationDateTime();
            }


            progressBarF.Visible = !true;
            gbEdicion.Enabled = !false;
        }



        private void MarcacionPuertaMantenimientoTransferirMarcacion_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            if (this.txtMovimientoAsistencia.Text == string.Empty)
            {
                oCheckInOut = new CheckInOut();
                oCheckInOut.USERID = listado.FirstOrDefault().codigoUsuarioMarcacion;
                oCheckInOut.CHECKTIME = this.txtMarcacion.Text;
                oCheckInOut.CHECKTYPE = cboTipoMarcacion.SelectedValue.ToString();
                oCheckInOut.VERIFYCODE = 1;
                oCheckInOut.SENSORID = "102";
                oCheckInOut.Memoinfo = string.Empty;
                oCheckInOut.WorkCode = "1";
                oCheckInOut.sn = "OPE7050497042100144";
                oCheckInOut.UserExtFmt = 1;
                oCheckInOut.codigoTransferencia = this.txtCodigoTransferencia.Text;
                oCheckInOut.fechaTransferencia = DateTime.Now;
                oCheckInOut.fechaAsistencia = Convert.ToDateTime(this.txtFecha.Text);
                oCheckInOut.usuarioTransferencia = Environment.MachineName;
                oCheckInOut.hostTransferencia = Environment.MachineName;
                oCheckInOut.codigoMarcacionBiometrico = string.Empty;
                oCheckInOut.CodigoMovimientoAsistencia = string.Empty;
                oCheckInOut.correlativo = Convert.ToInt32(this.txtCorrelativo.Text);
                modelo.GrabarMarcacionBiometrico(Program.ClaseCompartida.periodoElegido, oCheckInOut, this.txtCodigoTransferencia.Text);
                MessageBox.Show("Registrado correctamente", "CONFIRMACION DEL SISTEMA");
                btnRegistar.Enabled = false;
                gbEdicion.Enabled = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
