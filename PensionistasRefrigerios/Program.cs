using ComparativoHorasVisualSATNISIRA;
using ComparativoHorasVisualSATNISIRA.T.I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Asistencia
{
    static class Program
    {
        //////////////[STAThread]
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // deplegar la app de cruce de maquinaria
            // Application.Run(new GoMaquinariaReporteUsoMaquinariaPorSemana());        
            //Application.Run(new DetalleRevisionDatosContableSAS());
            Application.Run(new Menu());
            //Application.Run(new SolicitudDeEquipamientoTecnologico());
            //Application.Run(new CuentaDeCorreos());
            //Application.Run(new GestionDeSolicitudPedidoParaCompras());
            //Application.Run(new ReporteStockProductosRequerimientosPedidos());
            //Application.Run(new ImpresionTicketsAbastecimientoMateriaPrima());
            //Application.Run(new ImpresionTicketsAbastecimientoMateriaPrimaImprimir());
            //Application.Run(new GoVentasHabilitarSegundaLiquidación());
            //Application.Run(new ReporteDiferencialTipoCambio());
            ////Application.Run(new GestionDeSolicitudPedidoParaCompras());
            ////Application.Run(new ReasignacionDeClientesEnPaletasLibres());
            //Application.Run(new ColaboradoresListado());
            //Application.Run(new DispositivosListado());
        }
    }
}
