using sistema_modular_cafe_majada.controller.SecurityData;
using sistema_modular_cafe_majada.controller.UserDataController;
using sistema_modular_cafe_majada.model.DAO;
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
    public partial class form_usuarios : Form
    {
        //variable global para verificar el estado del boton actualizar
        private bool imagenClickeada = false;
        //instancia de la clase mapeo persona para capturar los datos seleccionado por el usuario
        private Usuario usuarioSeleccionado;

        public form_usuarios()
        {
            InitializeComponent();

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dataGrid_UserView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //funcion para mostrar de inicio los datos en el dataGrid
            ShowUserGrid();

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
                Departamento = usuario.DeptoUsuario,
                ID_Rol = usuario.IdRolUsuario,
                ID_Persona = usuario.IdPersonaUsuario
            }).ToList();

            // Asignar los datos al DataGridView
            dataGrid_UserView.DataSource = datosPersonalizados;

        }

        private void dataGrid_UserView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("depurador - evento click img update: " + imagenClickeada);
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
            usuarioSeleccionado.DeptoUsuario = filaSeleccionada.Cells["Departamento"].Value.ToString();
            usuarioSeleccionado.IdRolUsuario = Convert.ToInt32(filaSeleccionada.Cells["ID_Rol"].Value);
            usuarioSeleccionado.IdPersonaUsuario = Convert.ToInt32(filaSeleccionada.Cells["ID_Persona"].Value);

            Console.WriteLine("depuracion - capturar datos dobleClick campo; nombre persona: " + usuarioSeleccionado.NombreUsuario);
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
                    txb_Name.Text = Convert.ToString(usuarioSeleccionado.IdPersonaUsuario);
                    txb_NameUser.Text = usuarioSeleccionado.NombreUsuario;
                    txb_Email.Text = usuarioSeleccionado.EmailUsuario;
                    txb_Password.Text = usuarioSeleccionado.ClaveUsuario;
                    txb_PassConfirm.Text = "";
                    txb_Depto.Text = usuarioSeleccionado.DeptoUsuario;
                    /*
                    cbx_userStatus.Items.Add("Activo");
                    cbx_userStatus.Items.Add("Inactivo");
                    cbx_userStatus.Items.Add("Suspendido");
                    cbx_userStatus.Items.Add("Pendiente de activación");
                    cbx_userStatus.Items.Add("Eliminado");*/
                    //txb_Role.Text = usuarioSeleccionado.NitPersona;
                    
                    usuarioSeleccionado = null;
                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente el dato");
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
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro del usuario: " + usuarioSeleccionado.NombreUsuario + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //se llama la funcion delete del controlador para eliminar el registro
                    UserController controller = new UserController();
                    controller.EliminarUsuario(usuarioSeleccionado.IdUsuario);

                    log.RegistrarLog(usuario.IdUsuario, "Eliminacion de dato Usuario", usuario.DeptoUsuario, "Eliminacion", "Elimino los datos del usuario " + usuarioSeleccionado.NombreUsuario + " en la base de datos");

                    MessageBox.Show("Persona Eliminada correctamente.");

                    //se actualiza la tabla
                    ShowUserGrid();
                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente el dato");
            }
        }

        public void ColocarDato(string dataSelect)
        {
            // Aquí puedes realizar el procesamiento de los datos en tiempo real
            // Puedes actualizar otros controles en el formulario según sea necesario
            // Por ejemplo, si tienes otro TextBox, puedes actualizarlo así:
            // Obtener los valores ingresados por el usuario
            dataSelect = PersonSelect.NamePerson;
            txb_Name.Text = dataSelect;

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

            // Obtener los valores ingresados por el usuario
            string namePerson = txb_Name.Text;
            string nameUser = txb_NameUser.Text;
            string pass = txb_Password.Text;
            string passConfirm = txb_PassConfirm.Text;
            string email = txb_Email.Text;
            string depto = txb_Depto.Text;
            string role = txb_Role.Text;

            if (pass == passConfirm)
            {
                // Las contraseñas coinciden
                string encryptedPassword = PasswordManager.EncryptPassword(pass);

                // Crear una instancia de la clase Usuario con los valores obtenidos
                Usuario usuario1 = new Usuario()
                {
                    NombreUsuario = nameUser,
                    EmailUsuario = email,
                    ClaveUsuario = passConfirm,
                    IdRolUsuario = Convert.ToInt32(role),
                    DeptoUsuario = depto,
                    IdPersonaUsuario = PersonSelect.IdPerson
                };

                if (!imagenClickeada)
                {
                    // Código que se ejecutará si no se ha hecho clic en la imagen update
                    // Llamar al controlador para insertar la persona en la base de datos
                    bool exito = userController.InsertarUsuario(usuario1);

                    if (exito)
                    {
                        MessageBox.Show("Usuario agregada correctamente.");
                        try
                        {
                            //Console.WriteLine("el ID obtenido del usuario "+usuario.IdUsuario);
                            log.RegistrarLog(usuario.IdUsuario, "Registro dato Usuario", usuario.DeptoUsuario, "Insercion", "Inserto un nuevo usuario a la base de datos");

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
                    // Código que se ejecutará si se ha hecho clic en la imagen update
                    //bool exito = userController.ActualizarPersona(usuarioSeleccionada.IdUsuario, namePerson, lastNamePerson, location, fechaSeleccionada, nit, dui, phone1, phone2);
                    /*
                    if (exito)
                    {
                        MessageBox.Show("Persona actualizada correctamente.");
                        try
                        {
                            log.RegistrarLog(usuario.IdUsuario, "Actualizacion de dato Persona", usuario.DeptoUsuario, "Actualizacion", "Actualizo los datos de la persona con ID " + personaSeleccionada.IdPersona + " en la base de datos");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                        }

                        //funcion para actualizar los datos en el dataGrid
                        ShowPersonGrid();

                        ClearDataTxb();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar la persona. Verifica los datos e intenta nuevamente.");
                    }
                    imagenClickeada = false;*/
                }
            }
            else
            {
                // Las contraseñas no coinciden, mostrar un mensaje de error
                MessageBox.Show("Las contraseñas no coinciden. Por favor, inténtelo de nuevo.");
            }
        }

        public void ClearDataTxb()
        {

            PersonSelect.NamePerson = "";
            List<TextBox> txb = new List<TextBox> { txb_Name, txb_NameUser, txb_Password, txb_PassConfirm, txb_Email,
                                    txb_Role};

            foreach (TextBox textBox in txb)
            {
                textBox.Clear();
            }

            txb_Depto.Items.Clear();
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
        }

    }
}
