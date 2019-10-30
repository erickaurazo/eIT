﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransportistaMto.Datos;


namespace Transportista
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