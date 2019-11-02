using Asistencia.Datos;
using Asistencia.Helper;
using Asistencia.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;


namespace Asistencia
{
    public partial class Privilegio : Form
    {
        public Privilegio()
        {
            InitializeComponent();
        }

        private void Privilegio_Load(object sender, EventArgs e)
        {
            ImagePrimitive searchIcon = new ImagePrimitive();
            searchIcon.Image = imageList1.Images[4];
            searchIcon.Alignment = ContentAlignment.MiddleRight;

            //this.txtFormulario.TextBoxElement.Children.Add(searchIcon);
            //this.txtFormulario.TextBoxElement.TextBoxItem.Alignment = ContentAlignment.MiddleLeft;
            //this.txtFormulario.TextBoxElement.TextBoxItem.StretchHorizontally = false;
            //this.txtFormulario.TextBoxElement.TextBoxItem.HostedControl.MinimumSize = new Size(120, 0);
            //this.txtFormulario.TextBoxElement.TextBoxItem.PropertyChanged += new PropertyChangedEventHandler(TextBoxItem_PropertyChanged);
        }
    }
}
