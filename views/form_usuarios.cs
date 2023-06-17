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
    public partial class form_usuarios : Form
    {
        public form_usuarios()
        {
            InitializeComponent();
        }

        private void btn_table_person_Click(object sender, EventArgs e)
        {
            form_tableperson ftperson = new form_tableperson();
            ftperson.ShowDialog();
        }

        private void form_usuarios_Load(object sender, EventArgs e)
        {
            label10.Visible = false;
            cbx_userStatus.Visible = false;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            label10.Visible = true;
            cbx_userStatus.Visible = true;
        }
    }
}
