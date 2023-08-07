using sistema_modular_cafe_majada.controller.InfrastructureController;
using sistema_modular_cafe_majada.controller.SecurityData;
using sistema_modular_cafe_majada.controller.UserDataController;
using sistema_modular_cafe_majada.model.Acces;
using sistema_modular_cafe_majada.model.Mapping.Infrastructure;
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
    public partial class form_beneficios : Form
    {
        //variable global para verificar el estado del boton actualizar
        private bool imagenClickeada = false;
        //instancia de la clase mapeo beneficio para capturar los datos seleccionado por el usuario
        private Beneficio beneficioSeleccionado;

        public form_beneficios()
        {
            InitializeComponent();

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_beneficios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ShowBeneficioGrid();

            dtg_beneficios.CellPainting += dtgv_beneficios_CellPainting;
        }

        private void dtgv_beneficios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_beneficios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_beneficios.BorderStyle = BorderStyle.None;

            //configuracion de la fila de encabezado en el datagrid
            Font customFonten = new Font("Oswald", 9f, FontStyle.Bold);
            dtg_beneficios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(184, 89, 89);
            dtg_beneficios.ColumnHeadersDefaultCellStyle.Font = customFonten;
            dtg_beneficios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtg_beneficios.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 89, 89);
            dtg_beneficios.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dtg_beneficios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //configuracion de las filas por defecto en el datagrid
            Font customFontdef = new Font("Oswald Light", 10.2f, FontStyle.Regular);

            dtg_beneficios.DefaultCellStyle.BackColor = Color.White;
            dtg_beneficios.DefaultCellStyle.Font = customFontdef;
            dtg_beneficios.DefaultCellStyle.ForeColor = Color.Black;
            dtg_beneficios.DefaultCellStyle.SelectionBackColor = Color.White;
            dtg_beneficios.DefaultCellStyle.SelectionForeColor = Color.Black;
            dtg_beneficios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //configuracion de las filas que son seleccionadas
            dtg_beneficios.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 199, 199);
            dtg_beneficios.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        public void ShowBeneficioGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            var beneficioController = new BeneficioController();
            List<Beneficio> datos = beneficioController.ObtenerBeneficios();

            var datosPersonalizados = datos.Select(rol => new
            {
                ID = rol.IdBeneficio,
                Nombre = rol.NombreBeneficio,
                Ubicacion = rol.UbicacionBeneficio
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_beneficios.DataSource = datosPersonalizados;

            dtg_beneficios.RowHeadersVisible = false;
            dtg_beneficios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> { txb_nombreBeneficio, txb_Ubicacion };

            foreach (TextBox textBox in txb)
            {
                textBox.Text = "";
            }

        }

        public void ConvertFirstCharacter(TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                string input = textBox.Text; // Obtener el valor ingresado por el usuario desde el TextBox

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

                    // Asignar el valor modificado de vuelta al TextBox
                    textBox.Text = result;
                }
            }
        }

        private void btn_updateBeneficio_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas actualizar el registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // El usuario seleccionó "Sí"
                imagenClickeada = true;

                // Asignar los valores a los cuadros de texto solo si no se ha hecho clic en la imagen
                txb_nombreBeneficio.Text = beneficioSeleccionado.NombreBeneficio;
                txb_Ubicacion.Text = beneficioSeleccionado.UbicacionBeneficio;
            }
            else
            {
                // El usuario seleccionó "No" o cerró el cuadro de diálogo
            }

        }

        private void btn_deleteBeneficio_Click(object sender, EventArgs e)
        {
            //condicion para verificar si los datos seleccionados van nulos, para evitar error
            if (beneficioSeleccionado != null)
            {
                LogController log = new LogController();
                UserController userControl = new UserController();
                Usuario usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar los datos registrado del Beneficio: (" + beneficioSeleccionado.NombreBeneficio + ") ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //se llama la funcion delete del controlador para eliminar el registro
                    BeneficioController controller = new BeneficioController();
                    controller.EliminarBeneficio(beneficioSeleccionado.IdBeneficio);

                    //verificar el departamento del log
                    log.RegistrarLog(usuario.IdUsuario, "Eliminacion de los datos Beneficio", ModuloActual.NombreModulo, "Eliminacion", "Elimino los datos del Beneficio (" + beneficioSeleccionado.NombreBeneficio + ") en la base de datos");

                    MessageBox.Show("Beneficio Eliminado correctamente.", "Eliminacion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //se actualiza la tabla
                    ShowBeneficioGrid();
                    beneficioSeleccionado = null;
                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente las caracteristicas del Beneficio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtg_beneficios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila correspondiente a la celda en la que se hizo doble clic
            DataGridViewRow filaSeleccionada = dtg_beneficios.Rows[e.RowIndex];
            beneficioSeleccionado = new Beneficio();

            // Obtener los valores de las celdas de la fila seleccionada
            beneficioSeleccionado.IdBeneficio = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
            beneficioSeleccionado.NombreBeneficio = filaSeleccionada.Cells["Nombre"].Value.ToString();
            beneficioSeleccionado.UbicacionBeneficio = filaSeleccionada.Cells["Ubicacion"].Value.ToString();

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
        }

        private void btn_SaveBeneficio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_nombreBeneficio.Text))
            {
                MessageBox.Show("El campo Nombre, esta vacio y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txb_Ubicacion.Text))
            {
                MessageBox.Show("El campo Ubicacion, esta vacio y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BeneficioController beneficioController = new BeneficioController();
            LogController log = new LogController();
            var userControl = new UserController();
            var usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario

            TextBox[] textBoxes = { txb_nombreBeneficio };
            ConvertFirstCharacter(textBoxes);

            try
            {
                string name = txb_nombreBeneficio.Text;
                string location = txb_Ubicacion.Text;

                // Crear una instancia de la clase Beneficio con los valores obtenidos
                Beneficio beneficioInsert = new Beneficio()
                {
                    NombreBeneficio = name,
                    UbicacionBeneficio = location
                };

                if (!imagenClickeada)
                {
                    // Código que se ejecutará si no se ha hecho clic en la imagen update
                    // Llamar al controlador para insertar el beneficio en la base de datos
                    bool exito = beneficioController.InsertarBeneficio(beneficioInsert);

                    if (!exito)
                    {
                        MessageBox.Show("Error al agregar el Beneficio. Verifica los datos e intenta nuevamente.");
                        return;
                    }

                    MessageBox.Show("Beneficio agregado correctamente.", "Insercion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        //Console.WriteLine("el ID obtenido del usuario "+usuario.IdUsuario);
                        //verificar el departamento
                        log.RegistrarLog(usuario.IdUsuario, "Registro de caracteristicas del Beneficio", ModuloActual.NombreModulo, "Insercion", "Inserto un nuevo Beneficio a la base de datos");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos en el dataGrid
                    ShowBeneficioGrid();

                    //borrar datos de los textbox
                    ClearDataTxb();
                }
                else
                {
                    // Código que se ejecutará si se ha hecho clic en la imagen update
                    bool exito = beneficioController.ActualizarBeneficio(beneficioSeleccionado.IdBeneficio, name, location);

                    if (!exito)
                    {
                        MessageBox.Show("Error al actualizar los datos del Beneficio. Verifica los datos e intenta nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Beneficio actualizado correctamente.", "Actualizacion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        //verificar el departamento 
                        log.RegistrarLog(usuario.IdUsuario, "Actualizacion del dato Beneficio", ModuloActual.NombreModulo, "Actualizacion", "Actualizo las caracteristicas del Beneficio con ID " + beneficioSeleccionado.IdBeneficio + " en la base de datos");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos en el dataGrid
                    ShowBeneficioGrid();

                    ClearDataTxb();

                    imagenClickeada = false;
                    beneficioSeleccionado = null;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message);
                MessageBox.Show("Error de tipo (" + ex.Message + "), verifique los datos he intenta nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
