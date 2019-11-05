using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Asistencia.Datos;

namespace Asistencia
{
    public partial class CatalogoPersonaByParadero : Form
    {
        private string _companyId;
        private string _conection;
        private ASJ_USUARIOS _user;

        public CatalogoPersonaByParadero()
        {
            InitializeComponent();
        }

        public CatalogoPersonaByParadero(string conection, ASJ_USUARIOS user, string companyId)
        {
            _conection = conection;
            _user = user;
            _companyId = companyId;
        }

        private void CatalogoPersonaByParadero_Load(object sender, EventArgs e)
        {

        }
    }
}
