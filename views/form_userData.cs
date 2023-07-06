using sistema_modular_cafe_majada.controller.AccesController;
using sistema_modular_cafe_majada.controller.UserDataController;
using sistema_modular_cafe_majada.model.Acces;
using sistema_modular_cafe_majada.model.UserData;
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
    public partial class form_userData : Form
    {
        public form_userData()
        {
            InitializeComponent();

        }

        private void form_userData_Load(object sender, EventArgs e)
        {
            ReadOnlyTextbox(true);
            ShowDataUser();
        }

        private void btn_tableUser_Click(object sender, EventArgs e)
        {
            form_tableUser ftUser = new form_tableUser();
            ftUser.ShowDialog();
        }

        public void ReadOnlyTextbox(bool verific)
        {
            SetEnabledState(this, !verific);
        }

        private void SetEnabledState(Control control, bool enabled)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl is TextBox textBox)
                {
                    textBox.Enabled = enabled;
                }
                else if (childControl.HasChildren)
                {
                    SetEnabledState(childControl, enabled);
                }
            }
        }

        public void ReadOnlyTextboxUserProfile(bool verific)
        {
            List<TextBox> txb = new List<TextBox> { txb_UDname, txb_UDnameuser, txb_UDemail, txb_UDrol };

            foreach (TextBox textBox in txb)
            {
                textBox.ReadOnly = verific;
                textBox.Enabled = !verific;
            }
        }

        private void btn_editProfile_Click(object sender, EventArgs e)
        {
            ReadOnlyTextboxUserProfile(false); // Establece los TextBox específicos en solo lectura
        }

        public void ShowDataUser()
        {
            var userControl = new UserController();
            var personControl = new PersonController();
            var rolControl = new RoleController();
            Usuario user = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario);
            Persona person = personControl.ObtenerNombrePersona(user.IdPersonaUsuario);
            Role role = rolControl.ObtenerIRol(user.IdRolUsuario);

            txb_UDnameuser.Text = user.NombreUsuario;
            txb_UDemail.Text = user.EmailUsuario;
            txb_UDname.Text = person.NombresPersona;
            txb_UDrol.Text = role.NombreRol;
            txb_UDpassActual.Text = user.ClaveUsuario;
        }

        public void ClearDataTxb()
        {
            /*List<TextBox> txb = new List<TextBox> { txb_UDname, txb_UDnameuser, txb_Password, txb_PassConfirm, txb_Email };

            foreach (TextBox textBox in txb)
            {
                textBox.Clear();
            }*/
        }
    }
}
