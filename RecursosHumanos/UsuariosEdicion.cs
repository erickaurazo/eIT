using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;
using RecursosHumanos.reporte;
using System.Configuration;

namespace RecursosHumanos
{
    public partial class UsuariosEdicion : Form
    {
        private string periodo;
        private string idusuario;
        private UsuarioNeg negocio;
        private SJ_PrivilegiosListaUsuarioSistemaxCodigoResult user;

        public UsuariosEdicion()
        {
            InitializeComponent();
            this.periodo = DateTime.Now.Year.ToString();
            this.idusuario = "";
            Inicio();
        }

        public UsuariosEdicion(string periodo, string idusuario)
        {
            // TODO: Complete member initialization
            try
            {
                InitializeComponent();

                this.periodo = periodo;
                this.idusuario = idusuario;
                Inicio();
                btnAceptar.Enabled = false;
                btnCancelar.Enabled = false;
                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }


        }


        public void Inicio()
        {
            try
            {
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + this.periodo].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Erick Aurazo";
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }




        private void UsuariosEdicion_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void Registrar()
        {
            try
            {
                #region Obtener Objeto Usuario()
                USUARIO oUsuario = new USUARIO();
                oUsuario.IDUSUARIO = txtIdUsuario.Text.ToString().Trim();
                oUsuario.USR_NOMBRES = this.txtUsuario.Text.ToString().Trim().ToUpper();
                oUsuario.USR_INICIALES = this.txtIniciales.Text.ToString().Trim().ToUpper();
                oUsuario.EMAIL = this.txtEmail.Text.ToString().Trim().ToLower();
                oUsuario.idCodigoGeneral = txtCodigoGeneral.Text.ToString().Trim();
                oUsuario.IDAREA = this.txtAreaCodigo.Text.Trim();
                oUsuario.AREA = this.txtArea.Text.Trim();
                oUsuario.IDCARGO = this.txtCargoCodigo.Text.Trim();
                oUsuario.CARGO = this.txtCargo.Text.Trim();

                // Registrar();
                if (oUsuario.IDUSUARIO != "")
                {
                    negocio = new UsuarioNeg();
                    negocio.Registrar(this.periodo, oUsuario);
                    MessageBox.Show("Se ha registrado correctamente", "Mensaje de Sistema");

                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    bgwHilo.RunWorkerAsync();
                }

                #endregion
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }


        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                user = new SJ_PrivilegiosListaUsuarioSistemaxCodigoResult();
                negocio = new UsuarioNeg();
                user = negocio.ObtenerUsuarioSistema(this.periodo, this.idusuario);

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarDatos();
        }

        private void PresentarDatos()
        {
            try
            {
                this.txtPeriodo.Text = this.periodo;
                this.txtIdUsuario.Text = user.IDUSUARIO != null ? user.IDUSUARIO.ToString().Trim() : "";
                this.txtUsuario.Text = user.USR_NOMBRES != null ? user.USR_NOMBRES.ToString().Trim() : "";
                this.txtIniciales.Text = user.USR_INICIALES != null ? user.USR_INICIALES.ToString().Trim() : "";
                this.txtEmail.Text = user.EMAIL != null ? user.EMAIL.ToString().Trim() : "";
                this.txtCodigoGeneral.Text = user.idCodigoGeneral != null ? user.idCodigoGeneral.ToString().Trim() : "";
                this.txtIdEstado.Text = user.ESTADO != null ? user.ESTADO.ToString().Trim() : "";

                this.txtAreaCodigo.Text = user.IDAREA != null ? user.IDAREA.ToString().Trim() : "";
                this.txtArea.Text = user.AREA != null ? user.AREA.ToString().Trim() : "";
                this.txtCargoCodigo.Text = user.IDCARGO != null ? user.IDCARGO.ToString().Trim() : "";
                this.txtCargo.Text = user.CARGO != null ? user.CARGO.ToString().Trim() : "";
                txtNombresPersonal.Text = user.COLABORADOR != null ? user.COLABORADOR.ToString().Trim() : "";

                if (this.txtIdEstado.Text.ToString().Trim() == "1")
                {
                    this.txtEstado.Text = "ACTIVO";
                }
                if (this.txtIdEstado.Text.ToString().Trim() == "0")
                {
                    this.txtEstado.Text = "INACTIVO";
                }
                this.txtFechaRegistro.Value = user.FECHACREACION != null ? user.FECHACREACION.Value.ToShortDateString() : "";


                btnAceptar.Enabled = true;
                btnCancelar.Enabled = true;

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }



        private void txtCodigoGeneral_Leave(object sender, EventArgs e)
        {
            if (this.txtCodigoGeneral.Text.Trim() != "")
            {
                negocio = new UsuarioNeg();
                var cargoArea = negocio.ObtenerCargoAreaUsuarioSistema(this.txtCodigoGeneral.Text.Trim(), this.periodo);
                if (cargoArea.ToList().Count > 0)
                {
                    this.txtAreaCodigo.Text = cargoArea.FirstOrDefault().codigoArea != null ? cargoArea.FirstOrDefault().codigoArea.ToString().Trim() : "";
                    this.txtArea.Text = cargoArea.FirstOrDefault().AREA != null ? cargoArea.FirstOrDefault().AREA.ToString().Trim() : "";
                    this.txtCargoCodigo.Text = cargoArea.FirstOrDefault().IDCARGO != null ? cargoArea.FirstOrDefault().IDCARGO.ToString().Trim() : "";
                    this.txtCargo.Text = cargoArea.FirstOrDefault().CARGO != null ? cargoArea.FirstOrDefault().CARGO.ToString().Trim() : "";
                }


            }
            else
            {
                txtCodigoGeneral.Clear();
                this.txtAreaCodigo.Clear();
                this.txtArea.Clear();
                this.txtCargoCodigo.Clear();
                this.txtCargo.Clear();
            }
        }
    }
}
