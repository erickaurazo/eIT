using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RecursosHumanos.Negocios;
using Telerik.WinControls.UI;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Diagnostics;
using MyControlsDataBinding.Extensions;
using CrystalDecisions.Shared;
using RecursosHumanos;
using RecursosHumanos.Datos;



namespace RecursosHumanos
{
    public partial class ImprimirIngresosSalidasPersonalVistaPrevia : Form
    {
        private RadGridView dgvListado;
        public ReportDocument oRpt = new ReportDocument();
        private string nombreAlmacen;
        private string nombreSucursal;
        private ImprimirIngresoSalidaPersonalDS ds;


        private ImprimirIngresoSalidaPersonalDSTableAdapters.ST_RepoteMarcacionPersonalByCodigoPersonalListadoTableAdapter adaptador2;
        
        private string codigo;
        private DataTable dta;
        private ReportDocument ReporteCR;

        public ImprimirIngresosSalidasPersonalVistaPrevia()
        {
            InitializeComponent();
            this.crIngresoSalidaPersonal.PrintReport();
        }

        public ImprimirIngresosSalidasPersonalVistaPrevia(string codigo)
        {
            InitializeComponent();
            ReporteCR = new ReportDocument();
            //this.crIngresoSalidaPersonal.PrintReport();
            this.codigo = codigo;

            ImprimirDocumento();
        }


        private void ImprimirDocumento()
        {
            try
            {
                this.crIngresoSalidaPersonal.PrintReport();
                try
                {
                    ds = new ImprimirIngresoSalidaPersonalDS();
                    ds.EnforceConstraints = false;
                    adaptador2 = new ImprimirIngresoSalidaPersonalDSTableAdapters.ST_RepoteMarcacionPersonalByCodigoPersonalListadoTableAdapter();                    
                    adaptador2.Fill(ds.ST_RepoteMarcacionPersonalByCodigoPersonalListado, this.codigo);
                    dta = new DataTable();
                    if (ds.ST_RepoteMarcacionPersonalByCodigoPersonalListado.Rows.Count <= 0)
                    {
                        MessageBox.Show("No se encontró información para imprimir !");
                    }
                    oRpt = new ReportDocument();
                    //oRpt.Load(@"X:\Reportes 2015\ImprimirIngresosSalidasPersonalRPT.rpt");
                    //oRpt.Load(@"D:\Aplicaciones\Recursos Humanos\RecursosHumanos\ImprimirIngresosSalidasPersonalRPT.rpt");

                    oRpt.Load(@"D:\SANJOSE\REPORTES\ImprimirIngresosSalidasPersonalRPT.rpt");

                    //oRpt.Load(@"C:\Users\erick.aurazo\Dropbox\Agricola SJ\Desarrollo\Aplicaciones\Modulo a Rendir\ModuloGastosRendir\ModuloCajaBancosEASJ\RPTImprimirTicketMovimientoCaja.rpt");
                    dta = ds.ST_RepoteMarcacionPersonalByCodigoPersonalListado;
                    oRpt.SetDataSource(dta);
                    crIngresoSalidaPersonal.ReportSource = oRpt;
                }
                catch (Exception Ex)
                {
                    Ex.Message.ToString();

                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void ImprimirIngresosSalidasPersonalVistaPrevia_Load(object sender, EventArgs e)
        {

        }





        #region Metodos de Impresion

        private void ConfigurarReporte(ReportDocument cr, string pServidor, string pBaseDatos, string pUsuario, string pClave)
        {
            LoginCR(cr, pServidor, pBaseDatos, pUsuario, pClave);
        }

        private bool LoginCR(ReportDocument cr, string pServidor, string pBaseDatos, string pUsuario, string pClave)
        {
            ConnectionInfo oInfo = new ConnectionInfo();
            SubreportObject subObj;
            //ReportObject obj ;

            oInfo.ServerName = pServidor;
            oInfo.DatabaseName = pBaseDatos;
            oInfo.UserID = pUsuario;
            oInfo.Password = pClave;

            if (!AplicarCR2010(cr, oInfo))
            {
                return false;
            }

            foreach (ReportObject obj in cr.ReportDefinition.ReportObjects)
            {
                if (obj.Kind == ReportObjectKind.SubreportObject)
                {
                    subObj = (SubreportObject)obj;
                    if (!AplicarCR2010(cr.OpenSubreport(subObj.SubreportName), oInfo))
                    {
                        return false;
                    }

                }
            }
            return true;

        }

        private bool AplicarCR2010(ReportDocument cr, ConnectionInfo oInfo)
        {
            TableLogOnInfo tInfo;
            Tables crTables;
            Database crDatabase;

            crDatabase = cr.Database;
            crTables = crDatabase.Tables;

            //A cada tabla se le aplica logon info
            foreach (CrystalDecisions.CrystalReports.Engine.Table tbl in crTables)
            {
                tInfo = tbl.LogOnInfo;
                tInfo.ConnectionInfo = oInfo;
                tbl.ApplyLogOnInfo(tInfo);
                //Verificar si el LOGIN fue correcto
                if (tbl.TestConnectivity())
                {
                    //Cambiar Ubicación
                    if (tbl.Location.IndexOf(".") > 0)
                    {
                        tbl.Location = tbl.Location.Substring(tbl.Location.LastIndexOf(".") + 1);
                    }
                    else
                    {
                        tbl.Location = tbl.Location;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public void AgregarParametroCadena(string sNomCampo, string xValCampo)
        {
            CrystalDecisions.Shared.ParameterValues xGrupoValor;
            CrystalDecisions.Shared.ParameterDiscreteValue xValor;

            xGrupoValor = new CrystalDecisions.Shared.ParameterValues();

            xValor = new CrystalDecisions.Shared.ParameterDiscreteValue();
            xValor.Value = xValCampo;
            xGrupoValor.Add(xValor);
            //------------------------------------------------------------------------------------------
            //AQUI AGREGAMOS EL PARAMETRO A LA VARIABLE GLOBAL
            //------------------------------------------------------------------------------------------
            oRpt.DataDefinition.ParameterFields[sNomCampo].ApplyCurrentValues(xGrupoValor);


        }

        public void AgregarParametroDecimal(string sNomCampo, decimal xValCampo)
        {
            CrystalDecisions.Shared.ParameterValues xGrupoValor;
            CrystalDecisions.Shared.ParameterDiscreteValue xValor;

            xGrupoValor = new CrystalDecisions.Shared.ParameterValues();

            xValor = new CrystalDecisions.Shared.ParameterDiscreteValue();
            xValor.Value = xValCampo;
            xGrupoValor.Add(xValor);
            //------------------------------------------------------------------------------------------
            //AQUI AGREGAMOS EL PARAMETRO A LA VARIABLE GLOBAL
            //------------------------------------------------------------------------------------------
            oRpt.DataDefinition.ParameterFields[sNomCampo].ApplyCurrentValues(xGrupoValor);

        }

        #endregion

        #region Exportacion de Datos

        private void tsbExportarExcel_Click(object sender, EventArgs e)
        {
            string vFileName = Path.GetTempFileName();
            string rutaArchivo = Path.GetTempFileName().Replace("tmp", "xls");
            File.Delete(rutaArchivo);

            oRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, rutaArchivo);
            Process.Start(rutaArchivo, "excel.exe");
        }

        private void tsbExportarPdf_Click(object sender, EventArgs e)
        {
            string vFileName = Path.GetTempFileName();
            string rutaArchivo = Path.GetTempFileName().Replace("tmp", "pdf");
            File.Delete(rutaArchivo);

            oRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, rutaArchivo);
            Process.Start(rutaArchivo, "AcroRd32.exe");
        }



        private void tsbExportarWord_Click(object sender, EventArgs e)
        {
            string vFileName = Path.GetTempFileName();
            string rutaArchivo = Path.GetTempFileName().Replace("tmp", "doc");
            File.Delete(rutaArchivo);

            oRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, rutaArchivo);
            Process.Start(rutaArchivo, "winword.exe");
        }

        #endregion

        #region Buscar Paginas

        private void txtNumeroPagina_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //{
            //    if (this.txtNumeroPagina.Text.Trim() != string.Empty)
            //    {
            //        MostrarPagina(int.Parse(this.txtNumeroPagina.Text.Trim()));
            //    }

            //}
        }

        private void tsbIrAPagina_Click(object sender, EventArgs e)
        {
            //    if (this.txtNumeroPagina.Text.Trim() != string.Empty)
            //    {
            //        MostrarPagina(int.Parse(this.txtNumeroPagina.Text.Trim()));
            //    }

        }

        public void MostrarPagina(int nroPagina)
        {
            this.crIngresoSalidaPersonal.ShowNthPage(nroPagina);
        }

        private void txtNumeroPagina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }


        #endregion

        #region Buscar Cadenas de Textos

        private void txtBuscarTexto_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //{
            //    if (this.txtBuscarTexto.Text.Trim() != string.Empty)
            //    {
            //        BuscarTexto(this.txtBuscarTexto.Text.Trim());
            //    }

            //}
        }

        public void BuscarTexto(string texto)
        {
            //this.crvVisorReportes.SearchForText(texto);
        }

        private void tsbBuscarTexto_Click(object sender, EventArgs e)
        {
            //if (this.txtBuscarTexto.Text.Trim() != string.Empty)
            //{
            //    BuscarTexto(this.txtBuscarTexto.Text.Trim());
            //}

        }

        #endregion

        #region Navegar entre Paginas

        private void tsbPaginaAnterior_Click(object sender, EventArgs e)
        {
            this.crIngresoSalidaPersonal.ShowPreviousPage();
        }

        private void tsbPrimeraPagina_Click(object sender, EventArgs e)
        {
            this.crIngresoSalidaPersonal.ShowFirstPage();
        }

        private void tsbPaginaSiguiente_Click(object sender, EventArgs e)
        {
            this.crIngresoSalidaPersonal.ShowNextPage();
        }

        private void tsbUltimaPagina_Click(object sender, EventArgs e)
        {
            this.crIngresoSalidaPersonal.ShowLastPage();
        }

        #endregion

        #region Aplicar Zoom a las paginas

        private void mnuZoomAnchoPagina_Click(object sender, EventArgs e)
        {
            this.crIngresoSalidaPersonal.Zoom(1);
        }

        private void mnuZoomTodaPagina_Click(object sender, EventArgs e)
        {
            this.crIngresoSalidaPersonal.Zoom(2);
        }

        private void mnuZoom400_Click(object sender, EventArgs e)
        {
            this.crIngresoSalidaPersonal.Zoom(400);
        }

        private void mnuZoom300_Click(object sender, EventArgs e)
        {
            this.crIngresoSalidaPersonal.Zoom(300);
        }

        private void mnuZoom200_Click(object sender, EventArgs e)
        {
            this.crIngresoSalidaPersonal.Zoom(200);
        }

        private void mnuZoom150_Click(object sender, EventArgs e)
        {
            this.crIngresoSalidaPersonal.Zoom(150);
        }

        private void mnuZoom100_Click(object sender, EventArgs e)
        {
            this.crIngresoSalidaPersonal.Zoom(100);
        }

        private void mnuZoom75_Click(object sender, EventArgs e)
        {
            this.crIngresoSalidaPersonal.Zoom(75);
        }

        private void mnuZoom50_Click(object sender, EventArgs e)
        {
            this.crIngresoSalidaPersonal.Zoom(50);
        }

        private void mnuZoom25_Click(object sender, EventArgs e)
        {
            this.crIngresoSalidaPersonal.Zoom(25);
        }

        #endregion



    }
}
