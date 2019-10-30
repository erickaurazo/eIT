using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModuloRecursosHumanos.Controller;
using RRHH.Controller;


namespace ModuloRecursosHumanos
{
    static class UsuarioGlobales
    {
        public static string gbUsuario;
        public static string gbNombre;
        public static string gbPerfil;
        public static SJ_Usuario sjUsuario;

        public static void Inicializar()
        {
            gbUsuario = "";
            gbPerfil = "";
            gbNombre = string.Empty;
            sjUsuario = new SJ_Usuario();
            sjUsuario.IdUsuario = string.Empty;
            sjUsuario.UserNombres = string.Empty;
        }
    }
}
