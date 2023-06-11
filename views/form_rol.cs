using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_modular_cafe_majada.views
{
    public partial class form_rol : Form
    {
        public form_rol()
        {
            InitializeComponent();
        }

        private void btn_SaveRol_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
        }

        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> { txb_NameRol, txb_Description, txb_permits};

            foreach (TextBox textBox in txb)
            {
                textBox.Text = "";
            }
            cbx_access.Items.Clear(); // Eliminar todos los elementos del ComboBox
            cbx_access.SelectedIndex = -1; // Deseleccionar cualquier elemento seleccionado previamente

        }
    }
}
