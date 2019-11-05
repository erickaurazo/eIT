using Asistencia.Datos;
using Asistencia.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Asistencia
{
    public partial class Privileges : Form
    {
        private string _userId;
        private string _fullName;
        private UsersController model;
        private List<PrivilegesByUser> privileges;
        private string period;
        private string _conection;
        private ASJ_USUARIOS _user;
        private string _companyId;

        public Privileges()
        {
            InitializeComponent();
        }

        public Privileges(string userId, string fullName, string conection, ASJ_USUARIOS user, string companyId)
        {
            InitializeComponent();
            _userId = userId;
            _fullName = fullName;
            _conection = conection;
            _user = user;
            _companyId = companyId;
            period = DateTime.Now.Year.ToString();
            this.txtFullName.Text = _fullName.Trim();
            this.txtUserCode.Text = _userId.Trim();
            RefreshList();
        }

        private void RefreshList()
        {
            period = DateTime.Now.Year.ToString();
            gbEdition.Enabled = false;
            gbList.Enabled = false;
            ProgressBar.Visible = true;
            bgwHilo.RunWorkerAsync();
        }

        private void Privileges_Load(object sender, EventArgs e)
        {

        }



        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            model = new UsersController();
            privileges = new List<PrivilegesByUser>();
            privileges = model.GetListPrivilegesByUser(period, _userId,_companyId);
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvList.DataSource = privileges;
            dgvList.Refresh();
            gbEdition.Enabled = !false;
            gbList.Enabled = !false;
            ProgressBar.Visible = !true;
        }

        private void dgvList_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //nada

        }

        private void dgvList_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            //nada
        }

        private void dgvList_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
        {
            if (this.dgvList.CurrentColumn.Name == "chNinguno")
            {
                this.dgvList.CurrentRow.Cells["chNuevo"].Value = false;
                this.dgvList.CurrentRow.Cells["chEditar"].Value = false;
                this.dgvList.CurrentRow.Cells["chAnular"].Value = false;
                this.dgvList.CurrentRow.Cells["chEliminar"].Value = false;
                this.dgvList.CurrentRow.Cells["chImprimir"].Value = false;
                this.dgvList.CurrentRow.Cells["chExportar"].Value = false;
                this.dgvList.CurrentRow.Cells["chConsultar"].Value = false;
            }

            if (this.dgvList.CurrentColumn.Name == "chConsultar")
            {
                this.dgvList.CurrentRow.Cells["chNinguno"].Value = false;
            }

            if (this.dgvList.CurrentColumn.Name == "chNuevo")
            {
                this.dgvList.CurrentRow.Cells["chConsultar"].Value = true;
                this.dgvList.CurrentRow.Cells["chNinguno"].Value = false;
            }

            if (this.dgvList.CurrentColumn.Name == "chEditar")
            {
                this.dgvList.CurrentRow.Cells["chConsultar"].Value = true;
                this.dgvList.CurrentRow.Cells["chNinguno"].Value = false;
            }


            if (this.dgvList.CurrentColumn.Name == "chAnular")
            {
                this.dgvList.CurrentRow.Cells["chConsultar"].Value = true;
                this.dgvList.CurrentRow.Cells["chNinguno"].Value = false;
            }

            if (this.dgvList.CurrentColumn.Name == "chEliminar")
            {
                this.dgvList.CurrentRow.Cells["chConsultar"].Value = true;
                this.dgvList.CurrentRow.Cells["chNinguno"].Value = false;
            }


            if (this.dgvList.CurrentColumn.Name == "chImprimir")
            {
                this.dgvList.CurrentRow.Cells["chConsultar"].Value = true;
                this.dgvList.CurrentRow.Cells["chNinguno"].Value = false;
            }


            if (this.dgvList.CurrentColumn.Name == "chExportar")
            {
                this.dgvList.CurrentRow.Cells["chConsultar"].Value = true;
                this.dgvList.CurrentRow.Cells["chNinguno"].Value = false;
            }


        }

        private void dgvList_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //nada   
        }

        private void dgvList_ValueChanged(object sender, EventArgs e)
        {
            // nadad
        }

        private void dgvList_CurrentCellChanged(object sender, Telerik.WinControls.UI.CurrentCellChangedEventArgs e)
        {

        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (_fullName != string.Empty && _userId != string.Empty)
            {
                if (dgvList.RowCount > 0)
                {
                    List<PrivilegioFormulario> privileges = new List<PrivilegioFormulario>();
                    foreach (GridViewRowInfo rowInfo in dgvList.Rows)
                    {
                        privileges.Add(new PrivilegioFormulario
                        {
                            usuarioCodigo = _userId,
                            formularioCodigo = rowInfo.Cells["chFormularioCodigo"].Value != null ? rowInfo.Cells["chFormularioCodigo"].Value.ToString().Trim() : string.Empty,
                            nuevo = rowInfo.Cells["chNuevo"].Value != null ? Convert.ToByte(rowInfo.Cells["chnuevo"].Value.ToString().Trim()) : Convert.ToByte("0"),
                            editar = rowInfo.Cells["chEditar"].Value != null ? Convert.ToByte(rowInfo.Cells["chEditar"].Value.ToString().Trim()) : Convert.ToByte("0"),
                            anular = rowInfo.Cells["chAnular"].Value != null ? Convert.ToByte(rowInfo.Cells["chAnular"].Value.ToString().Trim()) : Convert.ToByte("0"),
                            eliminar = rowInfo.Cells["chEliminar"].Value != null ? Convert.ToByte(rowInfo.Cells["chEliminar"].Value.ToString().Trim()) : Convert.ToByte("0"),
                            imprimir = rowInfo.Cells["chImprimir"].Value != null ? Convert.ToByte(rowInfo.Cells["chImprimir"].Value.ToString().Trim()) : Convert.ToByte("0"),
                            exportar = rowInfo.Cells["chExportar"].Value != null ? Convert.ToByte(rowInfo.Cells["chExportar"].Value.ToString().Trim()) : Convert.ToByte("0"),
                            ninguno = rowInfo.Cells["chNinguno"].Value != null ? Convert.ToByte(rowInfo.Cells["chNinguno"].Value.ToString().Trim()) : Convert.ToByte("0"),
                            consultar = rowInfo.Cells["chConsultar"].Value != null ? Convert.ToByte(rowInfo.Cells["chConsultar"].Value.ToString().Trim()) : Convert.ToByte("0"),
                        });
                    }

                    if (model.AddListPrivilegesByUser(period, privileges,_companyId) == true)
                    {
                        MessageBox.Show("Actualización correcta", "Confirmación del sistem");
                        RefreshList();
                    }

                }


            }
        }
    }
}
