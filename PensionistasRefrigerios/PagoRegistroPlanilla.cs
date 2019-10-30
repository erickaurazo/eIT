using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Transportista
{
    public partial class PagoRegistroPlanilla : Form
    {
        public PagoRegistroPlanilla()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            PagoRegistroPlanillaEdicion ofrm = new PagoRegistroPlanillaEdicion();
            ofrm.ShowDialog();
        }

        private void PagoRegistroPlanilla_Load(object sender, EventArgs e)
        {

        }
    }
}
