﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using sistema_modular_cafe_majada.views;

namespace sistema_modular_cafe_majada
{
    public partial class form_main : Form
    {
        public form_main()
        {
            InitializeComponent();

            //codigo para maximizar a pantalla completa solamente en area de trabajo
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void form_main_Load(object sender, EventArgs e)
        {
            form_panel_principal pre = new form_panel_principal();
            AddFormulario(pre);
        }

        //Codigo para mover el formulario en cualquier lugar de la pantalla

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwmd, int wmsg, int wparam, int lparam);

        //FUNCION PARA IR AGREGANDO Y REMOVIENDO FORMULARIOS
        public void AddFormulario(Form fp)
        {
            if (this.panel_container.Controls.Count > 0)
            {
                this.panel_container.Controls.RemoveAt(0);
            }


            fp.TopLevel = false;
            this.panel_container.Controls.Add(fp);
            fp.Dock = DockStyle.Fill;
            fp.Show();
        }

        //funcion para cerrar la aplicacion por completo
        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //funcion para maximizar a pantalla completa o minimizar a un tamaño minimo
        private void btn_max_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        //funcion para minimizar la pantalla (ocultar)
        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void barra_controles_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_principal_Click(object sender, EventArgs e)
        {
            form_panel_principal pre = new form_panel_principal();
            AddFormulario(pre);
        }

        private void btn_activos_Click(object sender, EventArgs e)
        {
            form_activos act = new form_activos();
            AddFormulario(act);
        }

        private void btn_admin_panel_Click(object sender, EventArgs e)
        {
            form_administracion fadmin = new form_administracion();
            AddFormulario(fadmin);
        }

        private void btn_reportes_Click(object sender, EventArgs e)
        {
            form_reportes frepor = new form_reportes();
            AddFormulario(frepor);
        }
    }
}
