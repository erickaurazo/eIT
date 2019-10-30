using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RecursosHumanos
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ReportAsistenciaPersonalASJBySistemasVarios());
            //Application.Run(new Menu());
            //Application.Run(new ReporteListadoConsumidoreByNroPlantasByNroRacimos());
            Application.Run(new PersonalBloqueado());            

        }

        public static class ClaseCompartida
        {
            public static string CodigoUnicoAccesoSistema;
            public static string codigoUsuario;
            public static string nombreUsuario;
            public static string codigoTipoPlanilla;
            public static string semanaPlanilla;
            public static string periodoElegido;
            public static DateTime? fechaAcceso;
            public static DateTime? desde;
            public static DateTime? hasta;

            // otras variables estáticas
        }


    }
}
