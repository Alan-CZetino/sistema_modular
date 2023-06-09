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
    public partial class form_administracion : Form
    {
        public form_administracion()
        {
            InitializeComponent();
        }

        //FUNCION PARA IR AGREGANDO Y REMOVIENDO FORMULARIOS
        public void AddFormulario(Form fp)
        {
            if (this.panel_container_admin.Controls.Count > 0)
            {
                this.panel_container_admin.Controls.RemoveAt(0);
            }


            fp.TopLevel = false;
            this.panel_container_admin.Controls.Add(fp);
            fp.Dock = DockStyle.Fill;
            fp.Show();
        }

        private void btn_cosecha_Click(object sender, EventArgs e)
        {
            form_cosecha cos = new form_cosecha();
            AddFormulario(cos);
        }

        private void btn_rol_Click(object sender, EventArgs e)
        {
            form_rol frol = new form_rol();
            AddFormulario(frol);
        }

        private void btn_persona_Click(object sender, EventArgs e)
        {
            form_personas fper = new form_personas();
            AddFormulario(fper);
        }

        private void btn_usuarios_Click(object sender, EventArgs e)
        {
            form_usuarios fusers = new form_usuarios();
            AddFormulario(fusers);
        }
    }
}
