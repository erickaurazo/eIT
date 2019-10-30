using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Transportista
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
            //Application.Run(new ReporteAsistenciaDiarioByPuertaIngreso());
            

            //Application.Run(new PensionesRefrigerio());
            //Application.Run(new Pension());
            //Application.Run(new ReporteAsistenciaRefrigerio());
            //Application.Run(new ReporteAsistenciaPersonalAdministrativo());
            //Application.Run(new RegistroAsistenciaPersonalAdministrativo());

            //Application.Run(new RefrigerioxPersonal());
            //Application.Run(new ReporteAsistenciaRefrigerio());
            //Application.Run(new Transportista());
            //Application.Run(new Rutas());
            //Application.Run(new Pension());
            //Application.Run(new RefrigerioxPersonal());  // RefrigerioxPersonal
            //Application.Run(new MovimientoRecorridos()); 
            //Application.Run(new RegistroAsistenciaRefrigerio());
            //Application.Run(new ConsolidadoMovimientoMovilidades());
            //Application.Run(new FacturacionMovilidades());
            //Application.Run(new ReporteAsistenciaPersonalAdministrativo());
        }
    }
}
