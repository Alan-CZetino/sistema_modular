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

        private void btn_calidades_cafe_Click(object sender, EventArgs e)
        {
            form_calidades_cafe fcal_cafe = new form_calidades_cafe();
            AddFormulario(fcal_cafe);
        }

        private void btn_subprod_cafe_Click(object sender, EventArgs e)
        {
            form_subprod_cafe fsubprod_cafe = new form_subprod_cafe();
            AddFormulario(fsubprod_cafe);
        }

        private void btn_fincas_Click(object sender, EventArgs e)
        {
            form_finca fFinca = new form_finca();
            AddFormulario(fFinca);
        }

        private void btn_beneficios_Click(object sender, EventArgs e)
        {
            form_beneficios fBeneficio = new form_beneficios();
            AddFormulario(fBeneficio);
        }

        private void btn_lote_Click(object sender, EventArgs e)
        {
            form_lote fLotes = new form_lote();
            AddFormulario(fLotes);
        }
        
        private void btn_proce_cafe_Click(object sender, EventArgs e)
        {
            form_prodCafe fProceCafe = new form_prodCafe();
            AddFormulario(fProceCafe);
        }

        private void btn_dest_cafe_Click(object sender, EventArgs e)
        {
            form_destCafe fDestCafe = new form_destCafe();
            AddFormulario(fDestCafe);
        }

        private void btn_ubicacion_Click(object sender, EventArgs e)
        {
            form_ubicacion fDestino = new form_ubicacion();
             AddFormulario(fDestino);
        }

        private void btn_maquinas_Click(object sender, EventArgs e)
        {
            form_maquinas fMaquinas = new form_maquinas();
            AddFormulario(fMaquinas);
        }

        private void btn_clase_cafeuva_Click(object sender, EventArgs e)
        {
            form_claseUva fClaseUva = new form_claseUva();
            AddFormulario(fClaseUva);
        }

        private void btn_personal_Click(object sender, EventArgs e)
        {
            form_personal fPersonal = new form_personal();
            AddFormulario(fPersonal);
        }

    }
}
