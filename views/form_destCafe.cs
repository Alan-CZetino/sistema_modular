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
    public partial class form_destCafe : Form
    {
        private Bodega bodegaSeleccionado;
        private int ibenef;
        private bool imagenClickeada = false;

        public form_destCafe()
        {
            InitializeComponent();

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_destCafe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //funcion para mostrar de inicio los datos en el dataGrid
            ShowBodegaGrid();

            dtg_destCafe.CellPainting += dataGrid_Bodega_CellPainting;

            txb_beneficio.ReadOnly = true;
            txb_beneficio.Enabled = false;
        }

        private void btn_tBeneficio_Click(object sender, EventArgs e)
        {
            TablaSeleccionadabodega.ITable = 1;
            form_tablaBeneficio tablaBeneficio = new form_tablaBeneficio();
            if (tablaBeneficio.ShowDialog() == DialogResult.OK)
            {
                txb_beneficio.Text = BeneficioSeleccionado.NombreBeneficioSeleccionado;
            }
        }

        private void dataGrid_Bodega_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        public void ShowBodegaGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            BodegaController bodegaController = new BodegaController();
            List<Bodega> datos = bodegaController.ObtenerBodegaNombreBeneficio();

            var datosPersonalizados = datos.Select(bodega => new
            {
                ID = bodega.IdBodega,
                Nombre = bodega.NombreBodega,
                Descripcion = bodega.DescripcionBodega,
                Ubicacion = bodega.UbicacionBodega,
                Beneficio = bodega.NombreBenficioUbicacion
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_destCafe.DataSource = datosPersonalizados;

            dtg_destCafe.RowHeadersVisible = false;
            dtg_destCafe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void dtg_Bodega_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila correspondiente a la celda en la que se hizo doble clic
            DataGridViewRow filaSeleccionada = dtg_destCafe.Rows[e.RowIndex];
            bodegaSeleccionado = new Bodega();

            // Obtener los valores de las celdas de la fila seleccionada
            bodegaSeleccionado.IdBodega = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
            bodegaSeleccionado.NombreBodega = filaSeleccionada.Cells["Nombre"].Value.ToString();
            bodegaSeleccionado.DescripcionBodega = filaSeleccionada.Cells["Descripcion"].Value.ToString();
            bodegaSeleccionado.UbicacionBodega = filaSeleccionada.Cells["Ubicacion"].Value.ToString();
            bodegaSeleccionado.NombreBenficioUbicacion = filaSeleccionada.Cells["Beneficio"].Value.ToString();
            BeneficioSeleccionado.NombreBeneficioSeleccionado = bodegaSeleccionado.NombreBenficioUbicacion;
        }

        private void btn_deleteDestino_Click(object sender, EventArgs e)
        {
            //condicion para verificar si los datos seleccionados van nulos, para evitar error
            if (bodegaSeleccionado != null)
            {
                LogController log = new LogController();
                UserController userControl = new UserController();

                Usuario usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro de la Bodega: " + bodegaSeleccionado.NombreBodega + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //se llama la funcion delete del controlador para eliminar el registro
                    BodegaController controller = new BodegaController();
                    controller.EliminarBodegas(bodegaSeleccionado.IdBodega);

                    //verificar el departamento del log
                    log.RegistrarLog(usuario.IdUsuario, "Eliminacion de dato Bodega", ModuloActual.NombreModulo, "Eliminacion", "Elimino los datos de la Bodega " + bodegaSeleccionado.NombreBodega + " en la base de datos");

                    MessageBox.Show("Bodega Eliminada correctamente.");

                    //se actualiza la tabla
                    ShowBodegaGrid();
                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente el dato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
            imagenClickeada = false;
            bodegaSeleccionado = null;
        }

        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> { txb_nombre, txb_descripcion, txb_ubicacion, txb_beneficio };

            foreach (TextBox textBox in txb)
            {
                textBox.Clear();
            }
        }

        //
        public void ConvertFirstLetter(TextBox[] textBoxes)
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

                    // Recorrer cada palabra y convertir el primer carácter a mayúscula solo si es la primera palabra
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(words[i]))
                        {
                            if (i == 0) // Verificar si es la primera palabra
                            {
                                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
                            }
                        }
                    }

                    // Unir las palabras nuevamente en una sola cadena
                    string result = string.Join(" ", words);

                    // Asignar el valor modificado de vuelta al TextBox
                    textBox.Text = result;
                }
            }
        }

        //
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

        private void btn_modDestino_Click(object sender, EventArgs e)
        {
            //condicion para verificar si los datos seleccionados van nulos, para evitar error
            if (bodegaSeleccionado != null)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas actualizar el registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // El usuario seleccionó "Sí"
                    imagenClickeada = true;

                    // Asignar los valores a los cuadros de texto solo si no se ha hecho clic en la imagen
                    BodegaController bodegaC = new BodegaController();
                    BeneficioController benefC = new BeneficioController();
                    var name = benefC.ObtenerBeneficioNombre(BeneficioSeleccionado.NombreBeneficioSeleccionado);
                    ibenef = name.IdBeneficio;

                    txb_nombre.Text = bodegaSeleccionado.NombreBodega;
                    txb_descripcion.Text = bodegaSeleccionado.DescripcionBodega;
                    txb_ubicacion.Text = bodegaSeleccionado.UbicacionBodega;
                    txb_beneficio.Text = bodegaSeleccionado.NombreBenficioUbicacion;

                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente el dato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_SaveDestino_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_nombre.Text))
            {
                MessageBox.Show("El campo Nombre Destino, esta vacio y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txb_ubicacion.Text))
            {
                MessageBox.Show("El campo Ubicacion, esta vacio y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txb_beneficio.Text))
            {
                MessageBox.Show("El campo Beneficio, esta vacio y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txb_descripcion.Text))
            {
                DialogResult result = MessageBox.Show("¿Desea dejar el campo descripcion vacio? Llenar dicho campo permitirá dar una informacion extra a futuros usuarios", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            BodegaController subController = new BodegaController();
            LogController log = new LogController();
            var userControl = new UserController();
            var usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario);

            TextBox[] textBoxes = { txb_nombre, txb_ubicacion };
            TextBox[] textBoxesLetter = { txb_descripcion };
            ConvertFirstCharacter(textBoxes);
            ConvertFirstLetter(textBoxesLetter);

            //se obtiene los valores ingresados por el usuario
            string nameBodega = txb_nombre.Text;
            string ubicacion = txb_ubicacion.Text;
            string description = txb_descripcion.Text;

            //Se crea una instancia de la clase Bodega
            Bodega bodegaInsert = new Bodega()
            {
                NombreBodega = nameBodega,
                DescripcionBodega = description,
                UbicacionBodega = ubicacion,
                IdBenficioUbicacion = BeneficioSeleccionado.IdBeneficioSleccionado
            };

            if (!imagenClickeada)
            {
                // Código que se ejecutará si no se ha hecho clic en la imagen update
                // Llamar al controlador para insertar en la base de datos
                bool exito = subController.InsertarBodega(bodegaInsert);

                if (exito)
                {
                    MessageBox.Show("Bodega agregada correctamente.");

                    try
                    {
                        log.RegistrarLog(usuario.IdUsuario, "Registro una Bodega", ModuloActual.NombreModulo, "Insercion", "Inserto una nueva Bodega a la base de datos");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos en el datagrid
                    ShowBodegaGrid();
                    //borra los datos de los textbox
                    ClearDataTxb();
                }
                else
                {
                    MessageBox.Show("Error al agregar la Bodega. Verifique los datos ingresados");
                }
            }
            else
            {
                // Código que se ejecutará si se ha hecho clic en la imagen update
                bool exito = subController.ActualizarBodegas(bodegaSeleccionado.IdBodega, nameBodega, description, ubicacion, ibenef);

                if (exito)
                {
                    MessageBox.Show("Bodega actualizada correctamente.");

                    try
                    {
                        //verifica el departamento
                        log.RegistrarLog(usuario.IdUsuario, "Actualizo una Bodega", ModuloActual.NombreModulo, "Actualizacion", "Actualizo datos con ID " + bodegaSeleccionado.IdBodega + " en la base de datos");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos
                    ShowBodegaGrid();

                    //funcion para limpiar las cajas de texto
                    ClearDataTxb();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la Bodega, Verifique los datos ingresados.");
                }

                imagenClickeada = false;
            }

        }
    }
}
