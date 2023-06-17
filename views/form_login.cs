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


namespace sistema_modular_cafe_majada
{
    public partial class form_login : Form
    {
        public form_login()
        {
            InitializeComponent();
            

        }

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
            if (txb_username.Text == "")
            {
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
            form_main formPrin = new form_main();
            formPrin.Show();

            this.Hide();
        }

        
    }
}
