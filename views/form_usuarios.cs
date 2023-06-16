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
        private Usuario usuarioSeleccionada;

        public form_usuarios()
        {
            InitializeComponent();

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dataGrid_UserView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //funcion para mostrar de inicio los datos en el dataGrid
            ShowUserGrid();

            dataGrid_UserView.CellPainting += dataGrid_UserView_CellPainting;
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
            usuarioSeleccionada = new Usuario();

            // Obtener los valores de las celdas de la fila seleccionada
            usuarioSeleccionada.IdUsuario = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
            usuarioSeleccionada.NombreUsuario = filaSeleccionada.Cells["Usuario"].Value.ToString();
            usuarioSeleccionada.EmailUsuario = filaSeleccionada.Cells["Email"].Value.ToString();
            usuarioSeleccionada.ClaveUsuario = filaSeleccionada.Cells["Clave_Usuario"].Value.ToString();
            usuarioSeleccionada.EstadoUsuario = filaSeleccionada.Cells["Estado"].Value.ToString();
            usuarioSeleccionada.FechaCreacionUsuario = Convert.ToDateTime(filaSeleccionada.Cells["Fecha_Creacion"].Value);
            // Obtener el valor de la celda
            object valorCelda = filaSeleccionada.Cells["Fecha_Baja"].Value;
            // Verificar si el valor de la celda es nulo y asignar el valor correspondiente a la propiedad
            usuarioSeleccionada.FechaBajaUsuario = valorCelda != null ? Convert.ToDateTime(valorCelda) : (DateTime?)null;
            usuarioSeleccionada.DeptoUsuario = filaSeleccionada.Cells["Departamento"].Value.ToString();
            usuarioSeleccionada.IdRolUsuario = Convert.ToInt32(filaSeleccionada.Cells["ID_Rol"].Value);
            usuarioSeleccionada.IdPersonaUsuario = Convert.ToInt32(filaSeleccionada.Cells["ID_Persona"].Value);

            Console.WriteLine("depuracion - capturar datos dobleClick campo; nombre persona: " + usuarioSeleccionada.NombreUsuario);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            /*
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas actualizar el registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // El usuario seleccionó "Sí"
                imagenClickeada = true;

                // Asignar los valores a los cuadros de texto solo si no se ha hecho clic en la imagen
                txb_Nombre.Text = personaSeleccionada.NombresPersona;
                txb_Apellido.Text = personaSeleccionada.ApellidosPersona;
                txb_Direccion.Text = personaSeleccionada.DireccionPersona;
                dtp_FechaNac.Value = personaSeleccionada.FechaNacimientoPersona;
                txb_Dui.Text = personaSeleccionada.DuiPersona;
                txb_Nit.Text = personaSeleccionada.NitPersona ?? ""; // Asignar cadena vacía si nit es nulo
                txb_Tel1.Text = personaSeleccionada.Telefono1Persona;
                txb_Tel2.Text = personaSeleccionada.Telefono2Persona ?? ""; // Asignar cadena vacía si tel2 es nulo

            }
            else
            {
                // El usuario seleccionó "No" o cerró el cuadro de diálogo
            }
             */
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            LogController log = new LogController();
            UserDAO userDao = new UserDAO();
            Usuario usuario = userDao.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro del usuario: " + usuarioSeleccionada.NombreUsuario + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //se llama la funcion delete del controlador para eliminar el registro
                UserController controller = new UserController();
                controller.EliminarUsuario(usuarioSeleccionada.IdUsuario);

                log.RegistrarLog(usuario.IdUsuario, "Eliminacion de dato Usuario", usuario.DeptoUsuario, "Eliminacion", "Elimino los datos del usuario " + usuarioSeleccionada.NombreUsuario + " en la base de datos");

                MessageBox.Show("Persona Eliminada correctamente.");

                //se actualiza la tabla
                ShowUserGrid();
            }
            else
            {
                // El usuario seleccionó "No" o cerró el cuadro de diálogo
            }
        }

        private void btn_SaveUser_Click(object sender, EventArgs e)
        {
            UserController userController = new UserController();
            LogController log = new LogController();
            var userDao = new UserDAO();
            var usuario = userDao.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario

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
                    //IdRolUsuario = role,
                    DeptoUsuario = depto,
                    //IdPersonaUsuario = namePerson;
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
            List<TextBox> txb = new List<TextBox> { txb_Name, txb_NameUser, txb_Password, txb_PassConfirm, txb_Email,
                                    txb_Role};

            foreach (TextBox textBox in txb)
            {
                textBox.Clear();
            }

            txb_Depto.Items.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_table_person_Click(object sender, EventArgs e)
        {
            form_tableperson ftperson = new form_tableperson();
            ftperson.ShowDialog();
        }
    }
}
