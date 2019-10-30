using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;
using System.Collections;
using System.Configuration;
using Transportista.Negocios;
using TransportistaMto.Datos;


namespace Transportista
{
    public partial class Acceso : Form
    {
        private int cont;
        private LoginNegocio negocio;
        private List<Grupo> bases;
        private List<Grupo> empresas;
        public string usuario;
        public ASJ_USUARIOS userSistema;

        public Acceso()
        {
            InitializeComponent();
            Inicio();
            CrearCombos();
            this.txtUsuario.Focus();

        }

        private void MostrarCombos()
        {
            #region Empresas()
            this.cboEmpresa.DataSource = empresas;
            this.cboEmpresa.DisplayMember = "Descripcion";
            this.cboEmpresa.ValueMember = "Id";
            this.cboEmpresa.SelectedIndex = 0;
            this.cboEmpresa.Enabled = false;


            #endregion
            this.cboBasesDatos.DataSource = bases;
            this.cboBasesDatos.DisplayMember = "Descripcion";
            this.cboBasesDatos.ValueMember = "Id";
            this.cboBasesDatos.SelectedIndex = 0;
            this.cboBasesDatos.Enabled = false;
            #region Bases de Datos()

            #endregion

        }

        private void CrearCombos()
        {
            empresas = new List<Grupo>();
            bases = new List<Grupo>();
            negocio = new LoginNegocio();
            empresas = negocio.ListarEmpresa();
            bases = negocio.ListarBasesDatos();
            MostrarCombos();
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
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "erick.aurazo";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Erick Aurazo";
                this.txtUsuario.Focus();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private bool ValidarControles()
        {
            bool estado = true;
            string msg = string.Empty;
            TextBox control = new TextBox();

            if (this.txtUsuario.Text == "")
            {
                control = txtUsuario;
                msg += "Falta ingresar el usuario \n";
                lblErrorUsuario.Visible = true;
                estado = false;
            }
            else
            {
                lblErrorUsuario.Visible = false;
            }

            if (this.txtContraseña.Text == "")
            {
                control = txtUsuario;
                msg += "Falta ingresar la Contraseña  \n";
                lblErrorContraseña.Visible = true;
                estado = false;
            }
            else
            {
                lblErrorContraseña.Visible = false;
            }


            if (estado == false)
            {
                //MessageBox.Show(msg, "Atención");
                lblMensajeUsuario.Text = msg;
                lblMensajeUsuario.Visible = true;
                control.Focus();
            }
            else
            {
                lblMensajeUsuario.Text = "";
                lblMensajeUsuario.Visible = false;
            }

            return estado;

        }

        private bool ValidarControlesEnter()
        {
            bool estado = true;
            string msg = string.Empty;
            TextBox control = new TextBox();

            if (this.txtContraseña.Text == "")
            {
                control = txtUsuario;
                msg += "Falta ingresar la Contraseña  \n";
                lblErrorContraseña.Visible = true;
                estado = false;
            }
            else
            {
                lblErrorContraseña.Visible = false;
            }


            if (estado == false)
            {
                //MessageBox.Show(msg, "Atención");
                lblMensajeUsuario.Text = msg;
                lblMensajeUsuario.Visible = true;
                control.Focus();
            }
            else
            {
                lblMensajeUsuario.Text = "";
                lblMensajeUsuario.Visible = false;
            }

            return estado;

        }

        private bool IniciarSesion(string usuario, string clave)
        {
            Boolean resultado = false;
            negocio = new LoginNegocio();

            if (negocio.VerificarSesion(usuario, clave) == true)
            {
                userSistema = negocio.ObtenerUsuario(usuario, clave);
                resultado = true;
            }
            else
            {
                resultado = false;
            }


            return resultado;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtUsuario.Focus();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (ValidarControles() == true)
            {
                #region VerificarSession()
                if (IniciarSesion(this.txtUsuario.Text.ToString().Trim().ToUpper(), this.txtContraseña.Text.ToString().Trim()) == true)
                {
                    usuario = this.txtUsuario.Text.ToString().Trim();
                    this.btnOK.PerformClick();
                }
                else
                {
                    if (cont < 4)
                    {
                        cont += 1;

                        if (cont == 3)
                        {
                            usuario = string.Empty;
                            MessageBox.Show("Ha intentado " + cont.ToString() + " veces \nSu contraseña y/o el sistema se cerrara ");
                            this.txtContraseña.Clear();
                            this.Dispose();
                            this.Close();
                        }
                        else
                        {
                            usuario = string.Empty;
                            MessageBox.Show(cont.ToString() + " intentos fallidos ");
                            this.txtContraseña.Clear();
                            this.txtUsuario.Focus();
                        }
                    }
                    else
                    {
                    }
                }
                #endregion
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {            
            
          
            
        }

        private void txtContraseña_AcceptsTabChanged(object sender, EventArgs e)
        {
            
        }

        private void txtContraseña_TabIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void txtContraseña_KeyUp(object sender, KeyEventArgs e)
       {
           
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtContraseña.Text.ToString().Trim() != "")
                {
                    #region VerificarSession()
                    if (IniciarSesion(this.txtUsuario.Text.ToString().Trim().ToUpper(), this.txtContraseña.Text.ToString().Trim()) == true)
                    {
                        usuario = this.txtUsuario.Text.ToString().Trim();
                        this.btnOK.PerformClick();
                    }
                    else
                    {
                        if (cont < 4)
                        {
                            cont += 1;

                            if (cont == 3)
                            {
                                usuario = string.Empty;
                                MessageBox.Show("Ha intentado " + cont.ToString() + " veces \nSu contraseña y/o el sistema se cerrara ");
                                this.Dispose();
                                this.Close();
                            }
                            else
                            {
                                usuario = string.Empty;
                                MessageBox.Show(cont.ToString() + " intentos fallidos ");
                                this.txtUsuario.Focus();
                            }
                        }
                        else
                        {
                        }
                    }
                    #endregion
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                // Lo que hará al presionar Escape 
            }
            else
            {
                // Lo que hará en cualquier otro caso 
            } 
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtContraseña_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
           
        }





    }
}
