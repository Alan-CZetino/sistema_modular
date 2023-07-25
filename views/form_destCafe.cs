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
    public partial class form_destCafe : Form
    {
        public form_destCafe()
        {
            InitializeComponent();
        }

        private void btn_tBeneficio_Click(object sender, EventArgs e)
        {
            form_tablaBeneficio tablaBeneficio = new form_tablaBeneficio();
            tablaBeneficio.ShowDialog();
        }
    }
}
