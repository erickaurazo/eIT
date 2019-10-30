using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Diagnostics;
using MyControlsDataBinding.Extensions;
using CrystalDecisions.Shared;
using System.Configuration;

namespace Transportista
{
    public partial class TicketsPrivilegiosRefrigerioImprimir : Form
    {

        public ReportDocument oRpt = new ReportDocument();
        private DataTable dta;

        private TicketsPrivilegiosRefrigerioImprimirDS dsReporte;


        private TicketsPrivilegiosRefrigerioImprimirDSTableAdapters.SJ_RHPensionRefrigerioPersonalRegistradoByCodigoRegistroTableAdapter adaptador;
        private string codigo;

        public TicketsPrivilegiosRefrigerioImprimir()
        {
            InitializeComponent();
        }


        public TicketsPrivilegiosRefrigerioImprimir(string codigo)
        {
            InitializeComponent();
            this.codigo = codigo;

            this.crvImprimir.PrintReport();
            try
            {
                dsReporte = new TicketsPrivilegiosRefrigerioImprimirDS();
                adaptador = new TicketsPrivilegiosRefrigerioImprimirDSTableAdapters.SJ_RHPensionRefrigerioPersonalRegistradoByCodigoRegistroTableAdapter();
                dsReporte.EnforceConstraints = false;
                adaptador.Fill(dsReporte.SJ_RHPensionRefrigerioPersonalRegistradoByCodigoRegistro, codigo);
                dta = new DataTable();
                if (dsReporte.SJ_RHPensionRefrigerioPersonalRegistradoByCodigoRegistro.Rows.Count <= 0)
                {
                    MessageBox.Show("No se encontró información para imprimir !", "MENSAJE DEL SISTEMA");
                    return;
                }
                else
                {
                    oRpt = new ReportDocument();
                    //oRpt.Load(@"C:\Users\erick.aurazo\Dropbox\Agricola SJ\Desarrollo\Aplicaciones\Recursos Humanos\RecursosHumanos\PensionistasRefrigerios\TicketsPrivilegiosRefrigerioImprimirRPT.rpt");
                    oRpt.Load(@"X:\Rpt_Solution\AplicacionesNet\rrhh\new\TicketsPrivilegiosRefrigerioImprimirRPT.rpt");
                    dta = dsReporte.SJ_RHPensionRefrigerioPersonalRegistradoByCodigoRegistro;
                    oRpt.SetDataSource(dta);
                    crvImprimir.ReportSource = oRpt;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString() + "\n Presentar reporte control de unidades de horarios de salida", "MENSAJE DEL SISTEMA");
                return;
            }
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
            try
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
            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }



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
            this.crvImprimir.ShowNthPage(nroPagina);
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
            this.crvImprimir.ShowPreviousPage();
        }

        private void tsbPrimeraPagina_Click(object sender, EventArgs e)
        {
            this.crvImprimir.ShowFirstPage();
        }

        private void tsbPaginaSiguiente_Click(object sender, EventArgs e)
        {
            this.crvImprimir.ShowNextPage();
        }

        private void tsbUltimaPagina_Click(object sender, EventArgs e)
        {
            this.crvImprimir.ShowLastPage();
        }

        #endregion

        #region Aplicar Zoom a las paginas

        private void mnuZoomAnchoPagina_Click(object sender, EventArgs e)
        {
            this.crvImprimir.Zoom(1);
        }

        private void mnuZoomTodaPagina_Click(object sender, EventArgs e)
        {
            this.crvImprimir.Zoom(2);
        }

        private void mnuZoom400_Click(object sender, EventArgs e)
        {
            this.crvImprimir.Zoom(400);
        }

        private void mnuZoom300_Click(object sender, EventArgs e)
        {
            this.crvImprimir.Zoom(300);
        }

        private void mnuZoom200_Click(object sender, EventArgs e)
        {
            this.crvImprimir.Zoom(200);
        }

        private void mnuZoom150_Click(object sender, EventArgs e)
        {
            this.crvImprimir.Zoom(150);
        }

        private void mnuZoom100_Click(object sender, EventArgs e)
        {
            this.crvImprimir.Zoom(100);
        }

        private void mnuZoom75_Click(object sender, EventArgs e)
        {
            this.crvImprimir.Zoom(75);
        }

        private void mnuZoom50_Click(object sender, EventArgs e)
        {
            this.crvImprimir.Zoom(50);
        }

        private void mnuZoom25_Click(object sender, EventArgs e)
        {
            this.crvImprimir.Zoom(25);
        }

        #endregion

        private void TicketsPrivilegiosRefrigerioImprimir_Load(object sender, EventArgs e)
        {

        }

    }
}
