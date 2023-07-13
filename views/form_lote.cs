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
    public partial class form_lote : Form
    {

        form_opcLote form_Opc=new form_opcLote();

        public form_lote()
        {
            InitializeComponent();
        }

        private void btn_tFinca_Click(object sender, EventArgs e)
        {
            form_Opc.ShowDialog();
        }

        private void btn_tCafe_Click(object sender, EventArgs e)
        {
            form_Opc.ShowDialog();
        }

        private void btn_tcCafe_Click(object sender, EventArgs e)
        {
            form_Opc.ShowDialog();
        }

        private void btn_tCosecha_Click(object sender, EventArgs e)
        {
            form_Opc.ShowDialog();
        }
    }
}
