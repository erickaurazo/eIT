using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asistencia.Datos
{
    public class PrivilegesByUser : PrivilegioFormulario
    {        
        public string jerarquia { get; set; }
        public string descripcionFormulario { get; set; }

        public string modulo { get; set; }

        public string moduloCodigo { get; set; }

        public string tipoFormulario { get; set; }

    }
}
