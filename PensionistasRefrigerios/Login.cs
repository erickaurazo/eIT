using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Security.Cryptography;
using Asistencia.Negocios;
using Asistencia.Datos;

namespace Asistencia
{
    public partial class Login : Form
    {
        private int cont;
        private LoginController negocio;
        private List<Grupo> bases;
        private List<Grupo> empresas;
        public string usuario;
        public ASJ_USUARIOS userSistema;

        public Login()
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
            negocio = new LoginController();
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
            negocio = new LoginController();

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


        public static string Encriptar(string texto)
        {
            try
            {

                string key = "qualityinfosolutions"; //llave para encriptar datos

                byte[] keyArray;

                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

                //Se utilizan las clases de encriptación MD5

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                //Algoritmo TripleDES
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();

                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

                tdes.Clear();

                //se regresa el resultado en forma de una cadena
                texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);

            }
            catch (Exception)
            {

            }
            return texto;
        }


        public static string Desencriptar(string textoEncriptado)
        {
            try
            {
                string key = "qualityinfosolutions";
                byte[] keyArray;
                byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

                //algoritmo MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();

                byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

                tdes.Clear();
                textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);

            }
            catch (Exception)
            {

            }
            return textoEncriptado;
        }

    }
}
