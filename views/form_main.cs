using System;
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
using sistema_modular_cafe_majada.model.UserData;
using sistema_modular_cafe_majada.controller.SecurityData;
using sistema_modular_cafe_majada.model.Acces;
using sistema_modular_cafe_majada.controller.UserDataController;

namespace sistema_modular_cafe_majada
{
    public partial class form_main : Form
    {
        private string _nombreUsuario;
        private Usuario usuario;
        private LogController log;


        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set
            {
                _nombreUsuario = value;
                lbl_User.Text = _nombreUsuario;
            }
        }

        public form_main()
        {
            InitializeComponent();

            //codigo para maximizar a pantalla completa solamente en area de trabajo
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            // Código 
            this.Shown += form_main_Shown;
            // Mensaje de depuración
            //Console.WriteLine("Constructor - Nombre de usuario: " + NombreUsuario);

            lbl_nameModule.Text = ModuloActual.NombreModulo;
        }

        private void form_main_Load(object sender, EventArgs e)
        {
            form_panel_principal pre = new form_panel_principal();
            AddFormulario(pre);
        }

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
        //private void btn_max_Click(object sender, EventArgs e)
        //{
        //    if (this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
        //    else this.WindowState = FormWindowState.Normal;
        //}

        //funcion para minimizar la pantalla (ocultar)
        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_principal_Click(object sender, EventArgs e)
        {
            form_panel_principal pre = new form_panel_principal();
            AddFormulario(pre);
        }

        private void btn_activos_Click(object sender, EventArgs e)
        {
            form_coffeeStocks fact = new form_coffeeStocks();
            AddFormulario(fact);
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

        private void btn_CloseSection_Click(object sender, EventArgs e)
        {
            log = new LogController();
            UserController usuarioControl = new UserController();
            var usuario = usuarioControl.ObtenerUsuario(UsuarioActual.NombreUsuario);

            DialogResult result = MessageBox.Show("¿Estás seguro de cerrar seccion?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //verificar el departamento
                log.RegistrarLog(usuario.IdUsuario, "Salio del Sistema", ModuloActual.NombreModulo, "Cierre de seccion", "El Usuario: " + _nombreUsuario + " salio del sistema");

                this.Close();

            }
            else
            {
                // El usuario seleccionó "No" o cerró el cuadro de diálogo
            }
        }

        private void form_main_Shown(object sender, EventArgs e)
        {
            string name = "Usuario: " + NombreUsuario;
            lbl_User.Text = name;
        }

        private void lbl_username_Click(object sender, EventArgs e)
        {
            form_userData fUserData = new form_userData();
            AddFormulario(fUserData);
        }

        private void form_main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Left)
                {
                    // Evita que el formulario se redimensione hacia la izquierda
                    e.Handled = true;
                }
                else if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Right)
                {
                    // Evita que el formulario se redimensione hacia la derecha
                    e.Handled = true;
                }
                else if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Up)
                {
                    // Evita que el formulario se redimensione hacia arriba
                    e.Handled = true;
                }
                else if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Down)
                {
                    // Evita que el formulario se redimensione hacia abajo
                    e.Handled = true;
                }
            }
        }
    }
}
