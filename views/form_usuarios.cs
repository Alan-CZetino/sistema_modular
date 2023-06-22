using sistema_modular_cafe_majada.controller;
using sistema_modular_cafe_majada.controller.SecurityData;
using sistema_modular_cafe_majada.controller.UserDataController;
using sistema_modular_cafe_majada.model.Acces;
using sistema_modular_cafe_majada.model.DAO;
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
    public partial class form_usuarios : Form
    {
        //variable global para verificar el estado del boton actualizar
        private bool imagenClickeada = false;
        //instancia de la clase mapeo persona para capturar los datos seleccionado por el usuario
        private Usuario usuarioSeleccionado;
        private int idPerson;
        public int contador = 0;

        public form_usuarios()
        {
            InitializeComponent();

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dataGrid_UserView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //funcion para mostrar de inicio los datos en el dataGrid
            ShowUserGrid();

            CbxRoles();

            dataGrid_UserView.CellPainting += dataGrid_UserView_CellPainting;

            txb_Name.ReadOnly = true;
        }

        private void dataGrid_UserView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            string headerColorHex = "#D7D7D7"; // Color hexadecimal deseado

            Color headerColor = ColorTranslator.FromHtml(headerColorHex);

            if (e.RowIndex == -1)
            {
                using (SolidBrush brush = new SolidBrush(headerColor))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                    // Centrar el texto del encabezado
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    // Dibujar el fondo del encabezado
                    e.PaintContent(e.CellBounds);
                    e.Handled = true;
                }
            }
        }

        public void ShowUserGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            UserController userController = new UserController();
            List<Usuario> datos = userController.ObtenerTodosUsuarios();

            var datosPersonalizados = datos.Select(usuario => new
            {
                ID = usuario.IdUsuario,
                Usuario = usuario.NombreUsuario,
                Email = usuario.EmailUsuario,
                Clave_Usuario = usuario.ClaveUsuario,
                Estado = usuario.EstadoUsuario,
                Fecha_Creacion = usuario.FechaCreacionUsuario,
                Fecha_Baja = usuario.FechaBajaUsuario,
                ID_Rol = usuario.IdRolUsuario,
                ID_Persona = usuario.IdPersonaUsuario
            }).ToList();

            // Asignar los datos al DataGridView
            dataGrid_UserView.DataSource = datosPersonalizados;

        }

        private void dataGrid_UserView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila correspondiente a la celda en la que se hizo doble clic
            DataGridViewRow filaSeleccionada = dataGrid_UserView.Rows[e.RowIndex];
            usuarioSeleccionado = new Usuario();

            // Obtener los valores de las celdas de la fila seleccionada
            usuarioSeleccionado.IdUsuario = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
            usuarioSeleccionado.NombreUsuario = filaSeleccionada.Cells["Usuario"].Value.ToString();
            usuarioSeleccionado.EmailUsuario = filaSeleccionada.Cells["Email"].Value.ToString();
            usuarioSeleccionado.ClaveUsuario = filaSeleccionada.Cells["Clave_Usuario"].Value.ToString();
            usuarioSeleccionado.EstadoUsuario = filaSeleccionada.Cells["Estado"].Value.ToString();
            usuarioSeleccionado.FechaCreacionUsuario = Convert.ToDateTime(filaSeleccionada.Cells["Fecha_Creacion"].Value);
            // Obtener el valor de la celda
            object valorCelda = filaSeleccionada.Cells["Fecha_Baja"].Value;
            // Verificar si el valor de la celda es nulo y asignar el valor correspondiente a la propiedad
            usuarioSeleccionado.FechaBajaUsuario = valorCelda != null ? Convert.ToDateTime(valorCelda) : (DateTime?)null;
            usuarioSeleccionado.IdRolUsuario = Convert.ToInt32(filaSeleccionada.Cells["ID_Rol"].Value);
            usuarioSeleccionado.IdPersonaUsuario = Convert.ToInt32(filaSeleccionada.Cells["ID_Persona"].Value);

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            //condicion para verificar si los datos seleccionados van nulos, para evitar error
            if (usuarioSeleccionado != null)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas actualizar el registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // El usuario seleccionó "Sí"
                    imagenClickeada = true;

                    // Asignar los valores a los cuadros de texto solo si no se ha hecho clic en la imagen
                    UserController userC = new UserController();
                    idPerson = usuarioSeleccionado.IdPersonaUsuario;
                    var name = userC.ObtenerNombrePersona(idPerson);

                    txb_Name.Text = name.NombresPersona;
                    txb_NameUser.Text = usuarioSeleccionado.NombreUsuario;
                    txb_Email.Text = usuarioSeleccionado.EmailUsuario;
                    txb_Password.Text = usuarioSeleccionado.ClaveUsuario;
                    txb_PassConfirm.Text = "";

                    label10.Visible = true;
                    cbx_userStatus.Visible = true;

                    cbx_role.Items.Clear();
                    CbxRoles();

                    cbx_userStatus.Items.Clear();
                    cbx_userStatus.Items.Add("Activo");
                    cbx_userStatus.Items.Add("Inactivo");
                    cbx_userStatus.Items.Add("Suspendido");
                    cbx_userStatus.Items.Add("Pendiente de activación");
                    cbx_userStatus.Items.Add("Eliminado");

                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente el dato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            //condicion para verificar si los datos seleccionados van nulos, para evitar error
            if (usuarioSeleccionado != null)
            {
                LogController log = new LogController();
                UserDAO userDao = new UserDAO();
                Usuario usuario = userDao.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro del usuario: " + usuarioSeleccionado.NombreUsuario + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //se llama la funcion delete del controlador para eliminar el registro
                    UserController controller = new UserController();
                    controller.EliminarUsuario(usuarioSeleccionado.IdUsuario);

                    //verificar el departamento del log
                    log.RegistrarLog(usuario.IdUsuario, "Eliminacion de dato Usuario", ModuloActual.NombreModulo, "Eliminacion", "Elimino los datos del usuario " + usuarioSeleccionado.NombreUsuario + " en la base de datos");

                    MessageBox.Show("Persona Eliminada correctamente.");

                    //se actualiza la tabla
                    ShowUserGrid();
                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente el dato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CbxRoles()
        {
            UserController roles = new UserController();
            List<Role> datoRol = roles.ObtenerRolCbx();
            
            cbx_role.Items.Clear();

            // Asignar los valores numéricos a los elementos del ComboBox
            foreach (Role role in datoRol)
            {
                int idRol = role.IdRol;
                string nombreRol = role.NombreRol;

                cbx_role.Items.Add(new KeyValuePair<int, string>(idRol, nombreRol));
            }

        }

        //Funcion para colocar mayusculas en la primera letra de la palabra y verificar que no vayan mayusculas intercaladas
        public void ConvertFirstCharacter(ComboBox[] comboBoxes)
        {
            foreach (ComboBox comboBox in comboBoxes)
            {
                string input = comboBox.Text; // Obtener el valor seleccionado por el usuario desde el ComboBox

                // Verificar si la cadena no está vacía
                if (!string.IsNullOrEmpty(input))
                {
                    // Convertir toda la cadena a minúsculas
                    string lowerCaseInput = input.ToLower();

                    // Dividir la cadena en palabras utilizando espacios como delimitadores
                    string[] words = lowerCaseInput.Split(' ');

                    // Recorrer cada palabra y convertir el primer carácter a mayúscula
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(words[i]))
                        {
                            words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
                        }
                    }

                    // Unir las palabras nuevamente en una sola cadena
                    string result = string.Join(" ", words);

                    // Asignar el valor modificado de vuelta al ComboBox
                    comboBox.Text = result;
                }
            }
        }

        private void btn_SaveUser_Click(object sender, EventArgs e)
        {
            UserController userController = new UserController();
            LogController log = new LogController();
            var userDao = new UserDAO();
            var usuario = userDao.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario

            ComboBox[] comBoxes = { txb_Depto };
            ConvertFirstCharacter(comBoxes);

            string nameUser = txb_NameUser.Text;
            string pass = txb_Password.Text;
            string passConfirm = txb_PassConfirm.Text;
            string email = txb_Email.Text;

            // Las contraseñas se cifra
            string encryptedPassword = PasswordManager.EncryptPassword(pass);
            
            // Obtener los valores ingresados por el usuario
            try
            {
                // Verificar si se ha seleccionado un rol de usuario
                if (cbx_role.SelectedItem != null)
                {
                    
                    // Obtener el valor numérico seleccionado
                    KeyValuePair<int, string> selectedStatus = new KeyValuePair<int, string>();
                    if (cbx_role.SelectedItem is KeyValuePair<int, string> keyValue)
                    {
                        selectedStatus = keyValue;
                    }
                    else if (cbx_role.SelectedItem != null)
                    {
                        selectedStatus = (KeyValuePair<int, string>)cbx_role.SelectedItem;
                    }

                    int selectedValue = selectedStatus.Key;

                    //verifica si han clikeado el icono update
                    if (!imagenClickeada)
                    {
                        // Código que se ejecutará si no se ha hecho clic en la imagen update

                        // Verificar si el texto cumple con el formato de un correo electrónico válido
                        bool esValido = ValidarFormatoCorreoElectronico(email);
                        if (!esValido)
                        {
                            // Mostrar un mensaje de error al usuario
                            MessageBox.Show("El correo electrónico ingresado no es válido. Verifique el formato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                
                            // Puedes lanzar una excepción si deseas manejar el error en otro lugar
                            // throw new Exception("El correo electrónico ingresado no es válido. Verifique el formato.");
                                
                        }
                        else
                        {
                            //verifica si la contraseña coinciden
                            if (pass == passConfirm)
                            {
                                string estado;

                                DialogResult result = MessageBox.Show("¿Desea dejar al usuario en estado pendiente de activación? Esto permitirá una revisión adicional antes de otorgarle acceso al sistema.", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                if (result == DialogResult.Yes)
                                {
                                    estado = "Pendiente de Activacion";
                                }
                                else
                                {
                                    estado = "Activo";
                                }

                                // Crear una instancia de la clase Usuario con los valores obtenidos
                                Usuario usuarioInsert = new Usuario()
                                {
                                    NombreUsuario = nameUser,
                                    EmailUsuario = email,
                                    ClaveUsuario = encryptedPassword,
                                    EstadoUsuario = estado,
                                    IdRolUsuario = selectedValue,
                                    IdPersonaUsuario = PersonSelect.IdPerson
                                };

                                // Llamar al controlador para insertar la persona en la base de datos
                                bool exito = userController.InsertarUsuario(usuarioInsert);
                                if (exito)
                                {
                                    MessageBox.Show("Usuario agregada correctamente.");
                                    try
                                    {
                                        //Console.WriteLine("el ID obtenido del usuario "+usuario.IdUsuario);
                                        //verificar el departamento del log
                                        log.RegistrarLog(usuario.IdUsuario, "Registro dato Usuario", ModuloActual.NombreModulo, "Insercion", "Inserto un nuevo usuario a la base de datos");

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                                    }

                                    //funcion para actualizar los datos en el dataGrid
                                    ShowUserGrid();

                                    //borrar datos de los textbox
                                    ClearDataTxb();
                                }
                                else
                                {
                                    MessageBox.Show("Error al agregar la persona. Verifica los datos e intenta nuevamente.");
                                }
                            }
                            else
                            {
                                // Las contraseñas no coinciden, mostrar un mensaje de error
                                MessageBox.Show("Las contraseñas no coinciden. Por favor, inténtelo de nuevo.");
                            }
                        }
                    }
                    else
                    {
                        // Código que se ejecutará
                        // si se ha hecho clic en la imagen update
                        int idRol = usuarioSeleccionado.IdRolUsuario;
                        bool baja = false;
                        object selectedItem = cbx_userStatus.SelectedItem; // Obtiene el objeto seleccionado
                        bool verificEncrypt = PasswordManager.VerifyPassword(passConfirm, txb_Password.Text);

                        if (selectedItem != null)
                        {
                            string valorSeleccionado = selectedItem.ToString(); // Convierte el objeto a string si es necesario
                            usuario.EstadoUsuario = valorSeleccionado;

                            if (selectedItem.Equals("Inactivo") || selectedItem.Equals("Suspendido") || selectedItem.Equals("Eliminado"))
                            {
                                baja = true;
                            }
                            DateTime? fechaBaja = null;
                            if (baja)
                            {
                                fechaBaja = DateTime.Today;
                            }
                            // Verificar si el texto cumple con el formato de un correo electrónico válido
                            bool esValido = ValidarFormatoCorreoElectronico(email);

                            if (!esValido)
                            {
                                // Mostrar un mensaje de error al usuario
                                MessageBox.Show("El correo electrónico ingresado no es válido. Verifique el formato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    
                                // Puedes lanzar una excepción si deseas manejar el error en otro lugar
                                // throw new Exception("El correo electrónico ingresado no es válido. Verifique el formato.");
                            }
                            else
                            {
                                //verifica si la contraseña coinciden
                                Console.WriteLine("condicion verificar clave " + verificEncrypt);
                                if (verificEncrypt)
                                {
                                    bool exito = userController.ActualizarUsuario(usuarioSeleccionado.IdUsuario, nameUser, email, pass, fechaBaja, usuario.EstadoUsuario, idRol, idPerson);

                                    if (exito)
                                    {
                                        MessageBox.Show("Persona actualizada correctamente.");
                                        try
                                        {
                                            //verificar el departamento del log
                                            log.RegistrarLog(usuario.IdUsuario, "Actualizacion del dato Usuario", ModuloActual.NombreModulo, "Actualizacion", "Actualizo los datos del usuario con ID " + usuarioSeleccionado.IdUsuario + " en la base de datos");
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                                        }

                                        //funcion para actualizar los datos en el dataGrid
                                        ShowUserGrid();

                                        label10.Visible = false;
                                        cbx_userStatus.Visible = false;
                                        ClearDataTxb();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error al actualizar la persona. Verifica los datos e intenta nuevamente.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    // Las contraseñas no coinciden, mostrar un mensaje de error
                                    MessageBox.Show("Las contraseñas no coinciden. Por favor, inténtelo de nuevo.");
                                }
                            }
                            imagenClickeada = false;
                        }
                        else
                        {
                            MessageBox.Show("Asigne el dato de estado de usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un rol de usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - seleccion de rol; no seleccionado " + ex.Message);
                MessageBox.Show("Debe seleccionar un rol de usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ClearDataTxb()
        {

            PersonSelect.NamePerson = "";
            List<TextBox> txb = new List<TextBox> { txb_Name, txb_NameUser, txb_Password, txb_PassConfirm, txb_Email };

            foreach (TextBox textBox in txb)
            {
                textBox.Clear();
            }

            cbx_role.Items.Clear();
            cbx_userStatus.Items.Clear();
            cbx_role.Text = "";
            cbx_userStatus.Text = "";
        }

        private void btn_table_person_Click(object sender, EventArgs e)
        {
            form_tableperson ftperson = new form_tableperson();
            if (ftperson.ShowDialog() == DialogResult.OK)
            {
                txb_Name.Text = PersonSelect.NamePerson;
            }
            //ftperson.ShowDialog();

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
            label10.Visible = false;
            cbx_userStatus.Visible = false;
            usuarioSeleccionado = null;
            CbxRoles();
        }

        private void form_usuarios_Load(object sender, EventArgs e)
        {
            label10.Visible = false;
            cbx_userStatus.Visible = false;
        }

        public string FormatearCorreoElectronico(string correo)
        {
            // Verificar si el texto cumple con el formato de un correo electrónico válido
            bool esValido = ValidarFormatoCorreoElectronico(correo);

            if (!esValido)
            {
                // Mostrar un mensaje de error al usuario
                MessageBox.Show("El correo electrónico ingresado no es válido. Verifique el formato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("El correo electrónico ingresado no es válido. Verifique el formato.");

                // Puedes lanzar una excepción si deseas manejar el error en otro lugar
                // throw new Exception("El correo electrónico ingresado no es válido. Verifique el formato.");
            }

            return correo;
        }

        public bool ValidarFormatoCorreoElectronico(string correo)
        {
            // Expresión regular para verificar el formato del correo electrónico
            string patron = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(patron);

            return regex.IsMatch(correo);
        }

        private void txb_NameUser_Enter(object sender, EventArgs e)
        {
            CbxRoles();
        }
    }
}
