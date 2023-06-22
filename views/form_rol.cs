using sistema_modular_cafe_majada.controller.AccesController;
using sistema_modular_cafe_majada.controller.SecurityData;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_modular_cafe_majada.views
{
    public partial class form_rol : Form
    {
        //variable global para verificar el estado del boton actualizar
        private bool imagenClickeada = false;
        //instancia de la clase mapeo rol para capturar los datos seleccionado por el usuario
        private Role rolSeleccionado;

        public form_rol()
        {
            InitializeComponent();

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtgv_roles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ShowRolGrid();
            ShowLevelRole();

            dtgv_roles.CellPainting += dtgv_roles_CellPainting;

        }

        private void dtgv_roles_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        public void ShowRolGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            var rolController = new RoleController();
            List<Role> datos = rolController.ObtenerRoles();

            var datosPersonalizados = datos.Select(rol => new
            {
                ID = rol.IdRol,
                Nombre = rol.NombreRol,
                Descripcion = rol.DescripcionRol,
                Nivel = rol.NivelAccesoRol,
                Permiso = rol.PermisosRol,
                Fecha_Creacion = rol.FechaCreacionRol,
                Fecha_Modificacion = rol.UltFechaModRol
            }).ToList();

            // Asignar los datos al DataGridView
            dtgv_roles.DataSource = datosPersonalizados;

        }

        private void btn_SaveRol_Click(object sender, EventArgs e)
        {
            RoleController rolController = new RoleController();
            LogController log = new LogController();
            var userDao = new UserDAO();
            var usuario = userDao.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario

            ComboBox[] comBoxes = { cbx_access };
            ConvertFirstCharacter(comBoxes);

            try
            {
                string nameRol = txb_NameRol.Text;
                string description = txb_Description.Text;
                string permits = txb_permits.Text;

                // Verificar si se ha seleccionado un nivel del rol
                
                object selectedItem = cbx_access.SelectedItem; // Obtiene el objeto seleccionado

                if (selectedItem != null)
                {
                    string valorSeleccionado = selectedItem.ToString(); // Convierte el objeto a string si es necesario
                    
                    // Crear una instancia de la clase Rol con los valores obtenidos
                    Role rolInsert = new Role()
                    {
                        NombreRol = nameRol,
                        DescripcionRol = description,
                        PermisosRol = permits,
                        NivelAccesoRol = valorSeleccionado
                    };

                    if (!imagenClickeada)
                    {
                        // Código que se ejecutará si no se ha hecho clic en la imagen update
                        // Llamar al controlador para insertar la persona en la base de datos
                        bool exito = rolController.InsertarRol(rolInsert);

                        if (exito)
                        {
                            MessageBox.Show("Rol agregado correctamente." , "Insercion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            try
                            {
                                //Console.WriteLine("el ID obtenido del usuario "+usuario.IdUsuario);
                                //verificar el departamento
                                log.RegistrarLog(usuario.IdUsuario, "Registro de caracteristicas del Rol", ModuloActual.NombreModulo, "Insercion", "Inserto un nuevo Rol a la base de datos");

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                            }

                            //funcion para actualizar los datos en el dataGrid
                            ShowRolGrid();

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
                        bool exito = rolController.ActualizarRol(rolSeleccionado.IdRol, nameRol, description, valorSeleccionado, permits);

                        if (exito)
                        {
                            MessageBox.Show("Rol actualizada correctamente.", "Actualizacion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            try
                            {
                                //verificar el departamento 
                                log.RegistrarLog(usuario.IdUsuario, "Actualizacion del dato Rol", ModuloActual.NombreModulo, "Actualizacion", "Actualizo las caracteristicas del Rol con ID " + rolSeleccionado.IdRol + " en la base de datos");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                            }

                            //funcion para actualizar los datos en el dataGrid
                            ShowRolGrid();

                            ClearDataTxb();

                            imagenClickeada = false;
                            rolSeleccionado = null;
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar las caracteristicas del rol. Verifica los datos e intenta nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el nivel del rol ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salir de la función para evitar excepciones adicionales
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - seleccion de nivel de rol; no seleccionado " + ex.Message);
                MessageBox.Show("Debe seleccionar un nivel de acceso al rol", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
            rolSeleccionado = null;
        }

        public void ShowLevelRole()
        {
            cbx_access.Items.Clear();
            cbx_access.Items.Add("1");
            cbx_access.Items.Add("2");
            cbx_access.Items.Add("3");
            cbx_access.Items.Add("4");
            cbx_access.Items.Add("5");
        }

        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> { txb_NameRol, txb_Description, txb_permits};

            foreach (TextBox textBox in txb)
            {
                textBox.Text = "";
            }
            cbx_access.Items.Clear(); // Eliminar todos los elementos del ComboBox
            cbx_access.Text = ""; // Deseleccionar cualquier elemento seleccionado previamente

        }

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

        private void btn_mod_rol_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas actualizar el registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // El usuario seleccionó "Sí"
                imagenClickeada = true;

                // Asignar los valores a los cuadros de texto solo si no se ha hecho clic en la imagen
                txb_NameRol.Text = rolSeleccionado.NombreRol;
                txb_Description.Text = rolSeleccionado.DescripcionRol;
                txb_permits.Text = rolSeleccionado.PermisosRol;

                ShowLevelRole();

            }
            else
            {
                // El usuario seleccionó "No" o cerró el cuadro de diálogo
            }
        }

        private void btn_delete_rol_Click(object sender, EventArgs e)
        {
            //condicion para verificar si los datos seleccionados van nulos, para evitar error
            if (rolSeleccionado != null)
            {
                LogController log = new LogController();
                UserDAO userDao = new UserDAO();
                Usuario usuario = userDao.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar las caracyeristicas registrada del Rol: " + rolSeleccionado.NombreRol + "?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //se llama la funcion delete del controlador para eliminar el registro
                    RoleController controller = new RoleController();
                    controller.EliminarRol(rolSeleccionado.IdRol);

                    //verificar el departamento del log
                    log.RegistrarLog(usuario.IdUsuario, "Eliminacion de las caracteristicas Rol", ModuloActual.NombreModulo, "Eliminacion", "Elimino las caracteristicas del Rol " + rolSeleccionado.NombreRol + " en la base de datos");

                    MessageBox.Show("Rol Eliminada correctamente.", "Eliminacion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //se actualiza la tabla
                    ShowRolGrid();
                    rolSeleccionado = null;
                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente las caracteristicas del Rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dtgv_roles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila correspondiente a la celda en la que se hizo doble clic
            DataGridViewRow filaSeleccionada = dtgv_roles.Rows[e.RowIndex];
            rolSeleccionado = new Role();

            // Obtener los valores de las celdas de la fila seleccionada
            rolSeleccionado.IdRol = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
            rolSeleccionado.NombreRol = filaSeleccionada.Cells["Nombre"].Value.ToString();
            rolSeleccionado.DescripcionRol = filaSeleccionada.Cells["Descripcion"].Value.ToString();
            rolSeleccionado.PermisosRol = filaSeleccionada.Cells["Permiso"].Value.ToString();

        }

        private void txb_NameRol_Leave(object sender, EventArgs e)
        {
            ShowLevelRole();
        }
    }
}
