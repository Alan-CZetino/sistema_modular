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
    public partial class form_trasladoCafe : Form
    {
        public form_trasladoCafe()
        {
            InitializeComponent();
        }

        private void btn_tTraslado_Click(object sender, EventArgs e)
        {
            form_opcTraslado opcTraslado = new form_opcTraslado();
            opcTraslado.ShowDialog();
        }

        private void btn_tAlmacenP_Click(object sender, EventArgs e)
        {
            form_opcTraslado opcTraslado = new form_opcTraslado();
            opcTraslado.ShowDialog();
        }

        private void btn_tUbicacionP_Click(object sender, EventArgs e)
        {
            form_opcTraslado opcTraslado = new form_opcTraslado();
            opcTraslado.ShowDialog();
        }

        private void btn_tFincaP_Click(object sender, EventArgs e)
        {
            form_opcTraslado opcTraslado = new form_opcTraslado();
            opcTraslado.ShowDialog();
        }

        private void btn_tCCafe_Click(object sender, EventArgs e)
        {
            form_opcTraslado opcTraslado = new form_opcTraslado();
            opcTraslado.ShowDialog();
        }

        private void btn_tSPCafe_Click(object sender, EventArgs e)
        {
            form_opcTraslado opcTraslado = new form_opcTraslado();
            opcTraslado.ShowDialog();
        }

        private void btn_tAlmacenD_Click(object sender, EventArgs e)
        {
            form_opcTraslado opcTraslado = new form_opcTraslado();
            opcTraslado.ShowDialog();
        }

        private void btn_tUbicacionD_Click(object sender, EventArgs e)
        {
            form_opcTraslado opcTraslado = new form_opcTraslado();
            opcTraslado.ShowDialog();
        }

        private void btn_tFincaD_Click(object sender, EventArgs e)
        {
            form_opcTraslado opcTraslado = new form_opcTraslado();
            opcTraslado.ShowDialog();
        }

        private void btn_tPesadores_Click(object sender, EventArgs e)
        {
            form_opcTraslado opcTraslado = new form_opcTraslado();
            opcTraslado.ShowDialog();
        }
    }
}
