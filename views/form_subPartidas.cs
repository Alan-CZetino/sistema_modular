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
    public partial class form_subPartidas : Form
    {
        public form_subPartidas()
        {
            InitializeComponent();
        }

        private void btn_ubicacionCafe_Click(object sender, EventArgs e)
        {
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            form_OpcSub.ShowDialog();
        }

        private void btn_prodCafe_Click(object sender, EventArgs e)
        {
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            form_OpcSub.ShowDialog();
        }

        private void btn_CCafe_Click(object sender, EventArgs e)
        {
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            form_OpcSub.ShowDialog();
        }

        private void btn_SPCafe_Click(object sender, EventArgs e)
        {
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            form_OpcSub.ShowDialog();
        }

        private void btn_puntero_Click(object sender, EventArgs e)
        {
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            form_OpcSub.ShowDialog();
        }

        private void btn_catador_Click(object sender, EventArgs e)
        {
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            form_OpcSub.ShowDialog();
        }

        private void btn_pesador_Click(object sender, EventArgs e)
        {
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            form_OpcSub.ShowDialog();
        }

        private void btn_sPartida_Click(object sender, EventArgs e)
        {
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            form_OpcSub.ShowDialog();
        }

        private void btn_ubiFisicaCafe_Click(object sender, EventArgs e)
        {
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            form_OpcSub.ShowDialog();
        }
    }
}
