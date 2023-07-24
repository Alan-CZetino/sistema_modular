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
    public partial class form_salidasCafe : Form
    {
        public form_salidasCafe()
        {
            InitializeComponent();
        }

        private void btn_tSalidas_Click(object sender, EventArgs e)
        {
            form_opcSalida opcSalida = new form_opcSalida();
            opcSalida.ShowDialog();
        }

        private void btn_tAlmacen_Click(object sender, EventArgs e)
        {
            form_opcSalida opcSalida = new form_opcSalida();
            opcSalida.ShowDialog();
        }

        private void btn_tUbicacion_Click(object sender, EventArgs e)
        {
            form_opcSalida opcSalida = new form_opcSalida();
            opcSalida.ShowDialog();
        }

        private void btn_tFinca_Click(object sender, EventArgs e)
        {
            form_opcSalida opcSalida = new form_opcSalida();
            opcSalida.ShowDialog();
        }

        private void btn_tCCafe_Click(object sender, EventArgs e)
        {
            form_opcSalida opcSalida = new form_opcSalida();
            opcSalida.ShowDialog();
        }

        private void btn_tSPCafe_Click(object sender, EventArgs e)
        {
            form_opcSalida opcSalida = new form_opcSalida();
            opcSalida.ShowDialog();
        }

        private void btn_tPesador_Click(object sender, EventArgs e)
        {
            form_opcSalida opcSalida = new form_opcSalida();
            opcSalida.ShowDialog();
        }
    }
}
