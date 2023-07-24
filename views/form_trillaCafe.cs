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
    public partial class form_trillaCafe : Form
    {
        public form_trillaCafe()
        {
            InitializeComponent();
        }

        private void btn_tTrillas_Click(object sender, EventArgs e)
        {
            form_opcTrilla opcTrilla = new form_opcTrilla();
            opcTrilla.ShowDialog();
        }

        private void btn_tCCafe_Click(object sender, EventArgs e)
        {
            form_opcTrilla opcTrilla = new form_opcTrilla();
            opcTrilla.ShowDialog();
        }

        private void btn_tSPCafe_Click(object sender, EventArgs e)
        {
            form_opcTrilla opcTrilla = new form_opcTrilla();
            opcTrilla.ShowDialog();
        }

        private void btn_tAlmacen_Click(object sender, EventArgs e)
        {
            form_opcTrilla opcTrilla = new form_opcTrilla();
            opcTrilla.ShowDialog();
        }

        private void btn_tUbicacion_Click(object sender, EventArgs e)
        {
            form_opcTrilla opcTrilla = new form_opcTrilla();
            opcTrilla.ShowDialog();
        }

        private void btn_tPesador_Click(object sender, EventArgs e)
        {
            form_opcTrilla opcTrilla = new form_opcTrilla();
            opcTrilla.ShowDialog();
        }
    }
}
