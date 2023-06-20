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
using sistema_modular_cafe_majada.model.UserData;
using sistema_modular_cafe_majada.controller;

namespace sistema_modular_cafe_majada
{
    public partial class form_login : Form
    {
        public form_login()
        {
            InitializeComponent();

            txb_username.TextChanged += txb_username_TextChanged;
        }

        //variable de tipo global para manejo de intentos fallidos en el login
        public static int contador = 0;

        //Codigo para mover el formulario en cualquier lugar de la pantalla

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwmd, int wmsg, int wparam, int lparam);

        //Evento para cuando el cursor del mouse este dentro del textbox
        private void txb_username_Enter(object sender, EventArgs e)
        {
            
            if (txb_username.Text == "Usuario")
            {
                txb_username.Text = "";
                txb_username.ForeColor = Color.LightGray;
            }
        }

        //Evento para cuando el curso del mouse sale del TextBox
        private void txb_username_Leave(object sender, EventArgs e)
        {
            string nombreUsuario = txb_username.Text;
            CbxDepartamento(nombreUsuario);
            if (txb_username.Text == "")
            {
                LimpiarComboBox();
                txb_username.Text = "Usuario";
                txb_username.ForeColor = Color.DimGray;
            }
        }

        private void txb_password_Enter(object sender, EventArgs e)
        {
            if (txb_password.Text == "Contraseña")
            {
                txb_password.Text = "";
                txb_password.ForeColor = Color.LightGray;
                txb_password.UseSystemPasswordChar = true;
            }
        }

        private void txb_password_Leave(object sender, EventArgs e)
        {
            if (txb_password.Text == "")
            {
                txb_password.Text = "Contraseña";
                txb_password.ForeColor = Color.DimGray;
                txb_password.UseSystemPasswordChar = false;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //funciones para mover el formulario a cualquier posicion en la pantalla
        private void form_login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            var login = new controller.LoginController();
            var log = new controller.SecurityData.LogController();
            var userDao = new model.DAO.UserDAO();

            string user = txb_username.Text;
            string password = txb_password.Text;

            bool loginSuccessful = login.AutenticarUsuario(user, password);
            var usuario = userDao.ObtenerUsuario(user); // Asignar el resultado de ObtenerUsuario

            contador++;
            if (loginSuccessful)
            {
                try
                {
                    //Console.WriteLine("el ID obtenido del usuario "+usuario.IdUsuario);
                    log.RegistrarLog(usuario.IdUsuario, "Inicio seccion satisfactoriamente", usuario.DeptoUsuario, "Inicio de Seccion", "Intentos realizados " + contador);
                    contador = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                }

                // Inicio de sesión exitoso, realiza las acciones necesarias
                // Navega a otra ventana, muestra un mensaje, etc.
                // MessageBox.Show("Inicio de sesión exitoso");
                form_main formPrin = new form_main();
                formPrin.NombreUsuario = user;
                UsuarioActual.NombreUsuario = user;

                LimpiarComboBox();
                formPrin.Show();

                //buca en la vista main el evento close del form 
                formPrin.FormClosed += Logout;
                this.Hide();
            }
            else
            {
                // Las credenciales son inválidas, muestra un mensaje de error
                MessageBox.Show("Credenciales inválidas");
            }
        }

        //mostrar nuevamente los datos en el login
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txb_username.Text = "Usuario";
            txb_username.ForeColor = Color.LightGray;
            txb_password.Text = "Contraseña";
            txb_password.ForeColor = Color.LightGray;
            txb_password.UseSystemPasswordChar = false;
            
            this.Show();

        }

        public void CbxDepartamento(string nombre)
        {
            LoginController deptoControl = new LoginController();
            List<Usuario> datoDepto = deptoControl.ObtenerDepartamentoCbx(nombre);

            cb_modulos.Items.Clear();

            if (datoDepto.Count > 0)
            {
                int i = 1;
                // Asignar los valores numéricos a los elementos del ComboBox
                foreach (Usuario dept in datoDepto)
                {
                    string nombreDepto = dept.DeptoUsuario;
                    cb_modulos.Items.Add(new KeyValuePair<int, string>(i, nombreDepto));
                    i++;
                }
                cb_modulos.SelectedIndex = 0;
            }
            else
            {
                // No hay elementos en el departamento, puedes mostrar un mensaje o tomar una acción apropiada
            }
        }

        public void LimpiarComboBox()
        {
            cb_modulos.Items.Clear();
            cb_modulos.Text = ""; // Establece el texto del ComboBox en vacío
        }

        private void txb_username_TextChanged(object sender, EventArgs e)
        {
            string nombreUsuario = txb_username.Text;
            CbxDepartamento(nombreUsuario);
        }
    }
}
