using sistema_modular_cafe_majada.controller.AccesController;
using sistema_modular_cafe_majada.controller.SecurityData;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_modular_cafe_majada.views
{
    public partial class form_userData : Form
    {
        private int idUser;
        private bool verificTxbReadOnly;
        private bool verificTxbPassReadOnly;
        private bool pressPerfile;
        private bool pressPass;
        
        public form_userData()
        {
            InitializeComponent();
            StyleChekedListBox();
        }

        public void StyleChekedListBox()
        {
            clb_permisos.ItemHeight = 30; // Cambiar la altura de cada elemento
            clb_permisos.Padding = new Padding(10, 5, 10, 5); // Cambiar el relleno interno de cada elemento
            clb_permisos.Margin = new Padding(5); // Cambiar el margen externo del CheckedListBox
            //clb_permisos.SelectionMode = SelectionMode.MultiSimple; // Permitir múltiples elementos seleccionados
            clb_permisos.BorderStyle = BorderStyle.Fixed3D; // Establecer un borde sólido
            clb_permisos.Font = new Font("Oswald-Medium", 12, FontStyle.Bold); // Establecer la fuente y tamaño del texto

        }

        private void form_userData_Load(object sender, EventArgs e)
        {
            ReadOnlyTextbox(true);
            ShowDataUser();
        }

        private void btn_tableUser_Click(object sender, EventArgs e)
        {
            form_tableUser ftUser = new form_tableUser();
            if (ftUser.ShowDialog() == DialogResult.OK)
            {
                CargarModulosCheckedListBox();
                txb_UDuser.Text = UsuarioSeleccionado.Usuario;
                //ftUser.ShowDialog();
            }
        }

        public void ReadOnlyTextbox(bool verific)
        {
            verificTxbReadOnly = verific;
            verificTxbPassReadOnly = verific;
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
            List<TextBox> txb = new List<TextBox> { txb_UDnameuser,  txb_UDemail
                                                        //, txb_UDname
                                                        //, txb_UDrol 
            };

            foreach (TextBox textBox in txb)
            {
                textBox.ReadOnly = verific;
                textBox.Enabled = !verific;
                verificTxbReadOnly = verific;
            }
        }

        private void btn_editProfile_Click(object sender, EventArgs e)
        {
            pressPerfile = !pressPerfile; // Cambiar el valor de pressPass

            if (pressPerfile == true)
            {
                ReadOnlyTextboxUserProfile(!pressPerfile); // Establecer el estado de solo lectura según pressPass
                return;
            }

            ReadOnlyTextboxUserProfile(!pressPerfile); // Establece los TextBox específicos en solo lectura
        }

        public void ShowDataUser()
        {
            var userControl = new UserController();
            var personControl = new PersonController();
            var rolControl = new RoleController();
            Usuario user = userControl.ObtenerIUsuario(UsuarioActual.IUsuario);
            UsuarioActual.NombreUsuario = user.NombreUsuario;
            Persona person = personControl.ObtenerNombrePersona(user.IdPersonaUsuario);
            Role role = rolControl.ObtenerIRol(user.IdRolUsuario);

            //Verificar porque no carga el nobre de usuario en el form main
            form_main form_Main = new form_main();
            form_Main.NombreUsuario = user.NombreUsuario;
            form_Main.Refresh();
            //===============================================================

            idUser = user.IdUsuario;
            txb_UDnameuser.Text = user.NombreUsuario;
            txb_UDemail.Text = user.EmailUsuario;
            txb_UDname.Text = person.NombresPersona;
            txb_UDrol.Text = role.NombreRol;
            txb_UDpassActual.Text = user.ClaveUsuario;
        }

        private void CargarModulosCheckedListBox()
        {
            var moduleControl = new ModuleController();
            // Obtener los módulos del controlador
            List<Module> modulos = moduleControl.ObtenerModulos();

            // Limpiar el CheckedListBox
            clb_permisos.Items.Clear();

            // Agregar los módulos al CheckedListBox
            foreach (Module modulo in modulos)
            {
                clb_permisos.Items.Add(modulo.NombreModulo);
            }
        }

        //
        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> { txb_UDname, txb_UDnameuser, txb_UDemail, txb_UDpassActual, txb_UDpassConf, txb_UDpassNew, txb_UDrol, txb_UDuser };

            foreach (TextBox textBox in txb)
            {
                textBox.Clear();
            }
        }

        //
        public bool ValidarFormatoCorreoElectronico(string correo)
        {
            // Expresión regular para verificar el formato del correo electrónico
            string patron = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(patron);

            return regex.IsMatch(correo);
        }

        private void btn_saveperfil_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificTxbReadOnly)
                {
                    MessageBox.Show("Error al actualizar. los campos estan bloqueados presione el boton *Editar Perfil* para poder actualizar.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var user = new UserController();
                var log = new LogController();

                string email = txb_UDemail.Text;
                string userName = txb_UDnameuser.Text;

                // Verificar si el texto cumple con el formato de un correo electrónico válido
                bool verificEmail = ValidarFormatoCorreoElectronico(email);

                if (string.IsNullOrEmpty(txb_UDnameuser.Text) || string.IsNullOrEmpty(txb_UDemail.Text))
                {
                    // Mostrar un mensaje de error al usuario
                    MessageBox.Show("Los campos que desea actualizar estan vacios. Verifique los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!verificEmail)
                    {
                        // Mostrar un mensaje de error al usuario
                        MessageBox.Show("El correo electrónico ingresado no es válido. Verifique el formato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Estás seguro de que deseas Actualizar los siguientes datos de su usuario: " + userName + " y el correo: " + email + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            bool exito = user.ActualizarNombreEmailUsuario(idUser, userName, email);

                            if (exito)
                            {
                                MessageBox.Show("Su Usuario se ha actualizada correctamente.");
                                try
                                {
                                    //verificar el departamento del log
                                    log.RegistrarLog(idUser, "Actualizacion del dato Usuario", ModuloActual.NombreModulo, "Actualizacion", "Actualizo los datos del usuario con ID " + idUser + " en la base de datos");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                                }
                                ShowDataUser();
                            }
                            else
                            {
                                MessageBox.Show("Error al actualizar el usuario. Verifica los datos e intenta nuevamente.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        ReadOnlyTextboxUserProfile(true); // Establece los TextBox específicos en solo lectura
                    }
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void btn_savePass_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificTxbPassReadOnly)
                {
                    MessageBox.Show("Error al actualizar. los campos estan bloqueados presione el boton *Cambiar* para poder actualizar la contraseña.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var user = new UserController();
                var log = new LogController();

                string passConfirm = txb_UDpassConf.Text;
                string newPass = txb_UDpassNew.Text;
                bool verificEncrypt = PasswordManager.VerifyPassword(passConfirm, txb_UDpassActual.Text);
                
                // Las contraseñas se cifra
                string encryptedPassword = PasswordManager.EncryptPassword(passConfirm);

                if (string.IsNullOrEmpty(txb_UDpassConf.Text) || string.IsNullOrEmpty(txb_UDpassNew.Text))
                {
                    // Mostrar un mensaje de error al usuario
                    MessageBox.Show("Los campos que desea actualizar estan vacios. Verifique los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (newPass != passConfirm)
                    {
                        MessageBox.Show("Las contraseñas Nueva y Confirmar no coinciden. Por favor, inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (verificEncrypt)
                    {
                        // Mostrar un mensaje de error al usuario
                        MessageBox.Show("La nueva contraseña es identica a la anterior.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Estás seguro que deseas Actualizar su Clave de usuario del sistema?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            bool exito = user.ActualizarClaveUsuario(idUser, encryptedPassword);

                            if (exito)
                            {
                                MessageBox.Show("Su Clave de Usuario se ha actualizada correctamente.");
                                try
                                {
                                    //verificar el departamento del log
                                    log.RegistrarLog(idUser, "Actualizacion del dato Usuario", ModuloActual.NombreModulo, "Actualizacion", "Actualizo la clave del usuario con ID " + idUser + " en la base de datos");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                                }

                                ClearDataTxb();
                                ShowDataUser();
                            }
                            else
                            {
                                MessageBox.Show("Error al actualizar la clave de usuario. Verifica los datos e intenta nuevamente.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        ReadOnlyTextboxPassword(true); // Establece los TextBox específicos en solo lectura
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void btn_editPass_Click(object sender, EventArgs e)
        {
            pressPass = !pressPass; // Cambiar el valor de pressPass

            if (pressPass == true)
            {
                ReadOnlyTextboxPassword(!pressPass); // Establecer el estado de solo lectura según pressPass
                return;
            }

            ReadOnlyTextboxPassword(!pressPass); // Establecer el estado de solo lectura según pressPass

        }

        public void ReadOnlyTextboxPassword(bool verific)
        {
            List<TextBox> txb = new List<TextBox> { txb_UDpassConf, txb_UDpassNew };

            foreach (TextBox textBox in txb)
            {
                textBox.ReadOnly = verific;
                textBox.Enabled = !verific;
                verificTxbPassReadOnly = verific;
            }
        }
    }
}
