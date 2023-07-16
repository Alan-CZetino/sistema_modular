using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using sistema_modular_cafe_majada.views;

namespace sistema_modular_cafe_majada
{
    public partial class form_panel_principal : Form
    {
        public form_panel_principal()
        {
            InitializeComponent();
        }

        private void pnl_calCafe_Click(object sender, EventArgs e)
        {
            form_opcGeneralData form_Opc = new form_opcGeneralData();
            form_Opc.ShowDialog();
        }

        private void pnl_subProd_Click(object sender, EventArgs e)
        {
            form_opcGeneralData form_Opc = new form_opcGeneralData();
            form_Opc.ShowDialog();
        }

        private void pnl_Uva_Click(object sender, EventArgs e)
        {
            form_opcGeneralData form_Opc = new form_opcGeneralData();
            form_Opc.ShowDialog();
        }

        private void pnl_fincas_Click(object sender, EventArgs e)
        {
            form_opcGeneralData form_Opc = new form_opcGeneralData();
            form_Opc.ShowDialog();
        }

        private void pnl_beneficios_Click(object sender, EventArgs e)
        {
            form_opcGeneralData form_Opc = new form_opcGeneralData();
            form_Opc.ShowDialog();
        }
    }
}
