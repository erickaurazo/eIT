using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Diagnostics;
using CrystalDecisions.Shared;

namespace Transportista
{
    public partial class TicketPrivilegioRefrigerioImprimir : Form
    {

        public ReportDocument oRpt = new ReportDocument();
        private DataTable dta;

        private TicketPrivilegioRefrigerioImprimirDS dsReporte;
        private TicketPrivilegioRefrigerioImprimirDSTableAdapters.SJ_RHPensionRefrigerioPersonalRegistradoByUsuarioTableAdapter adaptador;
        private string codigo;



        public TicketPrivilegioRefrigerioImprimir()
        {
            InitializeComponent();
        }

        public TicketPrivilegioRefrigerioImprimir(string codigo)
        {
            InitializeComponent();
            this.codigo = codigo;
            
            this.crvImprimir.PrintReport();
            try
            {
                dsReporte = new TicketPrivilegioRefrigerioImprimirDS();
                adaptador = new TicketPrivilegioRefrigerioImprimirDSTableAdapters.SJ_RHPensionRefrigerioPersonalRegistradoByUsuarioTableAdapter();
                dsReporte.EnforceConstraints = false;
                adaptador.Fill(dsReporte.SJ_RHPensionRefrigerioPersonalRegistradoByUsuario, Convert.ToInt32(this.codigo));
                dta = new DataTable();
                if (dsReporte.SJ_RHPensionRefrigerioPersonalRegistradoByUsuario.Rows.Count <= 0)
                {
                    MessageBox.Show("No se encontró información para imprimir !");
                    return;
                }
                oRpt = new ReportDocument();
                //oRpt.Load(@"X:\Rpt_Solution\AplicacionesNet\rrhh\new\TicketPrivilegioRefrigerioImprimirRPT.rpt");

                oRpt.Load(@"D:\SANJOSE\REPORTES\FacturacionMovilidadesImprimirResumenRPT.rpt");


                //oRpt.Load(@"X:\Rpt_Solution\AplicacionesNet\rrhh\new\FacturacionMovilidadesImprimirDetalleByTipoTransporteRPT.rpt");
                //oRpt.Load(@"C:\Users\Erick\Dropbox\Agricola SJ\Desarrollo\Aplicaciones\Recursos Humanos\RecursosHumanos\PensionistasRefrigerios\TicketPrivilegioRefrigerioImprimirRPT.rpt");
                //oRpt.Load(@"C:\Users\erick.aurazo\Dropbox\Agricola SJ\Desarrollo\Aplicaciones\Recursos Humanos\RecursosHumanos\PensionistasRefrigerios\TicketPrivilegioRefrigerioImprimirRPT.rpt");
                dta = dsReporte.SJ_RHPensionRefrigerioPersonalRegistradoByUsuario;
                oRpt.SetDataSource(dta);
                crvImprimir.ReportSource = oRpt;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n Presentar reporte control de unidades de horarios de salida", "MENSAJE DEL SISTEMA");
                return;
            }
        }

        #region Metodos de Impresion

        public void AgregarParametroCadena(string sNomCampo, string xValCampo)
        {
            try
            {
                ParameterValues xGrupoValor = new ParameterValues();
                ParameterDiscreteValue xValor = new ParameterDiscreteValue() { Value = xValCampo };
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
            ParameterValues xGrupoValor = new ParameterValues();
            ParameterDiscreteValue xValor = new ParameterDiscreteValue() { Value = xValCampo };
            xGrupoValor.Add(xValor);
            //------------------------------------------------------------------------------------------
            //AQUI AGREGAMOS EL PARAMETRO A LA VARIABLE GLOBAL
            //------------------------------------------------------------------------------------------
            oRpt.DataDefinition.ParameterFields[sNomCampo].ApplyCurrentValues(xGrupoValor);
        }

        #endregion

        #region Buscar Paginas

        public void MostrarPagina(int nroPagina)
        {
            this.crvImprimir.ShowNthPage(nroPagina);
        }


        #endregion

        private void TicketPrivilegioRefrigerioImprimir_Load(object sender, EventArgs e)
        {

        }
        #region Buscar Cadenas de Textos
        #endregion

    }
}
