using Asistencia.Datos;

namespace Asistencia
{
    static class UsuarioGlobales
    {
        public static string gbUsuario;
        public static string gbNombre;
        public static string gbPerfil;
        public static ASJ_USUARIOS sjUsuario;

        public static void Inicializar()
        {
            gbUsuario = "";
            gbPerfil = "";
            gbNombre = string.Empty;
            sjUsuario = new ASJ_USUARIOS();
            sjUsuario.IdUsuario = string.Empty;
            sjUsuario.NombreCompleto = string.Empty;
        }
    }
}
