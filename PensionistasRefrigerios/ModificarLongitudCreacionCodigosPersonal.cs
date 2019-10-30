using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using Transportista.Negocios;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ModificarLongitudCreacionCodigosPersonal : Telerik.WinControls.UI.RadForm
    {
        private string valor;
        private LongitudCodigoPersonalNegocio modelo;
        private PEMPRESA parametroEmpresa;
        public ModificarLongitudCreacionCodigosPersonal()
        {
            InitializeComponent();
            gbLongitudCreacionCodigos.Enabled = false;
            btnActualizar.Enabled = false;
            bgwHilo.RunWorkerAsync();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            gbLongitudCreacionCodigos.Enabled = false;

            modelo = new LongitudCodigoPersonalNegocio();
            parametroEmpresa = new PEMPRESA();
            parametroEmpresa.PARAMETRO = "LONCODTRAB";

            if (rbtCincoDigitos.IsChecked == true)
            {
                parametroEmpresa.VALOR = "5";
            }

            if (this.rbtOchoDigitos.IsChecked == true)
            {
                parametroEmpresa.VALOR = "8";
            }

            modelo.RegistrarPEmpresa(parametroEmpresa);
            MessageBox.Show("Se actualizo correctamente ", "MENSAJE DEL SISTEMA");
            bgwHilo.RunWorkerAsync();
        }

        private void ModificarLongitudCreacionCodigosPersonal_Load(object sender, EventArgs e)
        {

        }

        private void rbtCincoDigitos_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            valor = "5";
        }

        private void rbtOchoDigitos_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            valor = "8";
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            EjecutarConsulta();
        }

        private void EjecutarConsulta()
        {
            try
            {
                modelo = new LongitudCodigoPersonalNegocio();
                parametroEmpresa = new PEMPRESA();
                parametroEmpresa = modelo.ObtenerPEmpresa("LONCODTRAB");


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.ToString() + "\nEjecutar Consulta");
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarConsulta();
        }

        private void PresentarConsulta()
        {
            btnActualizar.Enabled = false;
            try
            {
                if (parametroEmpresa != null)
                {
                    if (parametroEmpresa.VALOR == "5")
                    {
                        rbtCincoDigitos.IsChecked = true;
                    }
                    else
                    {
                        rbtOchoDigitos.IsChecked = true;
                    }

                    btnActualizar.Enabled = true;
                    gbLongitudCreacionCodigos.Enabled = true;
                }


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.ToString() + "\nPresentar Información");
                btnActualizar.Enabled = false;
                return;
            }
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
