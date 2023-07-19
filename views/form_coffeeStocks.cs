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
    public partial class form_coffeeStocks : Form
    {
        public form_coffeeStocks()
        {
            InitializeComponent();
        }

        //FUNCION PARA IR AGREGANDO Y REMOVIENDO FORMULARIOS
        public void AddFormulario(Form fp)
        {
            if (this.pnl_opcStock.Controls.Count > 0)
            {
                this.pnl_opcStock.Controls.RemoveAt(0);
            }


            fp.TopLevel = false;
            this.pnl_opcStock.Controls.Add(fp);
            fp.Dock = DockStyle.Fill;
            fp.Show();
        }

        private void form_coffeeStocks_Load(object sender, EventArgs e)
        {

        }

        private void btn_lavadaCafe_Click(object sender, EventArgs e)
        {
            form_lavadaCafe form_Lavada = new form_lavadaCafe();
            AddFormulario(form_Lavada);
        }

        private void btn_despulpaCafe_Click(object sender, EventArgs e)
        {
            form_despulpaCafe form_Despulpa = new form_despulpaCafe();
            AddFormulario(form_Despulpa);
        }

        private void btn_trillaCafe_Click(object sender, EventArgs e)
        {
            form_trillaCafe form_Trilla = new form_trillaCafe();
            AddFormulario(form_Trilla);
        }

        private void btn_subPartida_Click(object sender, EventArgs e)
        {
            form_subPartidas form_SubPartidas = new form_subPartidas();
            AddFormulario(form_SubPartidas);
        }

        private void btn_entradaCafe_Click(object sender, EventArgs e)
        {
            form_entradaCafe form_Entrada = new form_entradaCafe();
            AddFormulario(form_Entrada);
        }

        private void btn_salidaCafe_Click(object sender, EventArgs e)
        {
            form_salidasCafe form_Salidas = new form_salidasCafe();
            AddFormulario(form_Salidas);
        }
    }
}
