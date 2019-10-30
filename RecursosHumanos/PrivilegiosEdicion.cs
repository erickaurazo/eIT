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
    public partial class PrivilegiosEdicion : Telerik.WinControls.UI.RadForm
    {
        private string codFormulario;
        private string descpFormuario;
        private string codUsuario;
        private string periodo;
        private PrivilegiosNegocios negocios;
        private List<SJ_RHPrivilegioxUsuarioxFormularioResult> listadoPrivilegios;
        private int BANDERA;

        public PrivilegiosEdicion()
        {
            InitializeComponent();
        }

        public PrivilegiosEdicion(string periodo)
        {
            BANDERA = 1;
            InitializeComponent();
            this.periodo = periodo;
            Inicio();
            gbPerfiles.Enabled = false;
            this.gbPrivilegios.Enabled = false;
            this.btnAceptar.Enabled = false;
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


        public PrivilegiosEdicion(string codFormulario, string descpFormuario, string codUsuario, string periodo)
        {
            BANDERA = 2;
            // TODO: Complete member initialization
            InitializeComponent();
            try
            {
                this.codFormulario = codFormulario;
                this.descpFormuario = descpFormuario;
                this.codUsuario = codUsuario;
                this.periodo = periodo;
                this.txtFormularioCodigo.Text = this.codFormulario;
                this.txtFormularioDescripcion.Text = this.descpFormuario;
                this.txtUsuarioCodigo.Text = this.codUsuario;
                CargarPrivilegios(this.codFormulario, this.codUsuario, this.periodo);
                this.btnFormularioBuscar.Enabled = false;
                this.btnUsuarioBuscar.Enabled = false;
                this.txtFormularioCodigo.ReadOnly = true;
                this.txtUsuarioCodigo.ReadOnly = true;

            }
            catch (Exception Ex)
            {

                throw Ex;
            }


        }

        private void CargarPrivilegios(string codFormulario, string codUsuario, string periodo)
        {
            try
            {
                negocios = new PrivilegiosNegocios();
                listadoPrivilegios = new List<SJ_RHPrivilegioxUsuarioxFormularioResult>();

                listadoPrivilegios = negocios.ObtenerPrivilegiosUsuarioxFormulario(codFormulario, codUsuario, periodo);

                if (listadoPrivilegios != null)
                {
                    if (listadoPrivilegios.ToList().Count == 1)
                    {
                        PresentarPrivilegios();
                    }
                    else
                    {
                        #region Desabilitar()
                        chkNinguno.Checked = false;
                        chkConsulta.Checked = false;
                        chkExportaImprime.Checked = false;
                        chkNuevo.Checked = false;
                        chkModificar.Checked = false;
                        chkAnular.Checked = false;
                        chkEliminar.Checked = false;
                        chkLogs.Checked = false;
                        this.btnAceptar.Enabled = false;
                        #endregion

                    }
                }
                else
                {
                    #region Desabilitar()
                    chkNinguno.Checked = false;
                    chkConsulta.Checked = false;
                    chkExportaImprime.Checked = false;
                    chkNuevo.Checked = false;
                    chkModificar.Checked = false;
                    chkAnular.Checked = false;
                    chkEliminar.Checked = false;
                    chkLogs.Checked = false;
                    this.btnAceptar.Enabled = false;
                    #endregion

                }

            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        private void PresentarPrivilegios()
        {
            foreach (var item in listadoPrivilegios)
            {
                if (item.NINGUNO.Value == 1)
                {
                    chkNinguno.Checked = true;
                }
                else
                {
                    chkNinguno.Checked = false;
                }


                if (item.CONSULTA.Value == 1)
                {
                    chkConsulta.Checked = true;
                }
                else
                {
                    chkConsulta.Checked = false;
                }


                if (item.EXPORTA_IMPRIME.Value == 1)
                {
                    chkExportaImprime.Checked = true;
                }
                else
                {
                    chkExportaImprime.Checked = false;
                }


                if (item.NUEVO.Value == 1)
                {
                    chkNuevo.Checked = true;
                }
                else
                {
                    chkNuevo.Checked = false;
                }



                if (item.MODIFICA.Value == 1)
                {
                    chkModificar.Checked = true;
                }
                else
                {
                    chkModificar.Checked = false;
                }


                if (item.ANULA.Value == 1)
                {
                    chkAnular.Checked = true;
                }
                else
                {
                    chkAnular.Checked = false;
                }




                if (item.ELIMINA.Value == 1)
                {
                    chkEliminar.Checked = true;
                }
                else
                {
                    chkEliminar.Checked = false;
                }



                if (item.VER_LOGS.Value == 1)
                {
                    chkLogs.Checked = true;
                }
                else
                {
                    chkLogs.Checked = false;
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Registar();
        }

        private void Registar()
        {

            try
            {
                #region Obtener Objeto Privilegios()

                PRIVILEGIOS privilegio = new PRIVILEGIOS();
                privilegio.IDUSUARIO = this.txtUsuarioCodigo.Text.ToString().Trim();
                privilegio.CLAVE = this.txtFormularioCodigo.Text.ToString().Trim();

                if (chkNinguno.Checked == true)
                {
                    privilegio.NINGUNO = 1;
                }
                else
                {
                    privilegio.NINGUNO = 0;
                }


                if (chkConsulta.Checked == true)
                {
                    privilegio.CONSULTA = 1;
                }
                else
                {
                    privilegio.CONSULTA = 0;
                }



                if (chkExportaImprime.Checked == true)
                {
                    privilegio.EXPORTA_IMPRIME = 1;
                }
                else
                {
                    privilegio.EXPORTA_IMPRIME = 0;
                }


                if (chkNuevo.Checked == true)
                {
                    privilegio.NUEVO = 1;
                }
                else
                {
                    privilegio.NUEVO = 0;
                }


                if (chkModificar.Checked == true)
                {
                    privilegio.MODIFICA = 1;
                }
                else
                {
                    privilegio.MODIFICA = 0;
                }


                if (chkAnular.Checked == true)
                {
                    privilegio.ANULA = 1;
                }
                else
                {
                    privilegio.ANULA = 0;
                }


                if (chkEliminar.Checked == true)
                {
                    privilegio.ELIMINA = 1;
                }
                else
                {
                    privilegio.ELIMINA = 0;
                }



                if (chkLogs.Checked == true)
                {
                    privilegio.VER_LOGS = 1;
                }
                else
                {
                    privilegio.VER_LOGS = 0;
                }

                #endregion


                negocios = new PrivilegiosNegocios();
                negocios.RegistrarPrivilegios(privilegio.IDUSUARIO, privilegio.CLAVE, Convert.ToInt32(privilegio.NINGUNO.Value), Convert.ToInt32(privilegio.CONSULTA.Value), Convert.ToInt32(privilegio.EXPORTA_IMPRIME.Value), Convert.ToInt32(privilegio.NUEVO.Value), Convert.ToInt32(privilegio.MODIFICA.Value), Convert.ToInt32(privilegio.ANULA), Convert.ToInt32(privilegio.ELIMINA.Value), Convert.ToInt32(privilegio.VER_LOGS.Value), periodo);

                RadMessageBox.Show("Se registro correctamente los privilegios", "Mensaje Sistema");
                this.btnFormularioBuscar.Enabled = false;
                this.btnUsuarioBuscar.Enabled = false;
                this.txtFormularioCodigo.ReadOnly = true;
                this.txtUsuarioCodigo.ReadOnly = true;
                //this.Dispose();
                //this.Close();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        private void rbtNegarAcceso_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            chkNinguno.Checked = false;
            chkConsulta.Checked = false;
            chkExportaImprime.Checked = false;
            chkNuevo.Checked = false;
            chkModificar.Checked = false;
            chkAnular.Checked = false;
            chkEliminar.Checked = false;
            chkLogs.Checked = false;
        }

        private void rbtConsulta_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            chkNinguno.Checked = false;
            chkConsulta.Checked = true;
            chkExportaImprime.Checked = true;
            chkNuevo.Checked = false;
            chkModificar.Checked = false;
            chkAnular.Checked = false;
            chkEliminar.Checked = false;
            chkLogs.Checked = false;
        }

        private void rbtRegistro_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            chkNinguno.Checked = false;
            chkConsulta.Checked = true;
            chkExportaImprime.Checked = true;
            chkNuevo.Checked = true;
            chkModificar.Checked = true;
            chkAnular.Checked = false;
            chkEliminar.Checked = false;
            chkLogs.Checked = true;
        }

        private void rbtAccesoTotal_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            chkNinguno.Checked = true;
            chkConsulta.Checked = true;
            chkExportaImprime.Checked = true;
            chkNuevo.Checked = true;
            chkModificar.Checked = true;
            chkAnular.Checked = true;
            chkEliminar.Checked = true;
            chkLogs.Checked = true;
        }

        private void rbtNinguno_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            CargarPrivilegios(this.codFormulario, this.codUsuario, this.periodo);
        }

        private void PrivilegiosEdicion_Load(object sender, EventArgs e)
        {

        }

        private void txtFormularioCodigo_Leave(object sender, EventArgs e)
        {
            ActivarPerfilesUsuario();
        }

        private void ActivarPerfilesUsuario()
        {

            if (BANDERA == 1)
            {
                if (this.txtUsuarioCodigo.Text.ToString().Trim() != "" && this.txtUsuarioNombres.Text.ToString().Trim() != ""
                && this.txtFormularioCodigo.Text.ToString().Trim() != "" && this.txtFormularioDescripcion.Text.ToString().Trim() != "")
                {

                    negocios = new PrivilegiosNegocios();

                    int ExistenciaPrivilegio = negocios.ObtenerNroPrivilegiosxUsuario(this.txtFormularioCodigo.Text.ToString().Trim(), this.txtUsuarioCodigo.Text.ToString().Trim(), periodo);

                    if (ExistenciaPrivilegio == 0)
                    {
                        gbPerfiles.Enabled = true;
                        this.gbPrivilegios.Enabled = true;
                        this.btnAceptar.Enabled = true;
                    }
                    else
                    {
                        RadMessageBox.Show("Ya existe un registro en el sistema con el usuario y la clave ingresada. \nVerifique ingreso ", "Mensaje Sistema");
                        gbPerfiles.Enabled = false;
                        this.gbPrivilegios.Enabled = false;
                        this.btnAceptar.Enabled = false;
                    }


                }
                else
                {
                    gbPerfiles.Enabled = false;
                    this.gbPrivilegios.Enabled = false;
                    this.btnAceptar.Enabled = false;
                }
            }
            else
            {

            }

            
        }

        private void txtUsuarioCodigo_Leave(object sender, EventArgs e)
        {
            ActivarPerfilesUsuario();
        }


    }
}
