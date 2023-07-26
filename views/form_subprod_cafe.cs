using sistema_modular_cafe_majada.controller.OperationsController;
using sistema_modular_cafe_majada.controller.ProductController;
using sistema_modular_cafe_majada.controller.SecurityData;
using sistema_modular_cafe_majada.controller.UserDataController;
using sistema_modular_cafe_majada.model.Acces;
using sistema_modular_cafe_majada.model.Mapping;
using sistema_modular_cafe_majada.model.Mapping.Operations;
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
    public partial class form_subprod_cafe : Form
    {
        private SubProducto subProdcSeleccionado;
        private int iccafe;
        private bool imagenClickeada = false;

        public form_subprod_cafe()
        {
            InitializeComponent();

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_subProdCafe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //funcion para mostrar de inicio los datos en el dataGrid
            ShowSubProductGrid();

            dtg_subProdCafe.CellPainting += dataGrid_SubProduct_CellPainting;
            
            txb_calidadCafe.ReadOnly = true;
            txb_calidadCafe.Enabled = false;
        }

        private void dataGrid_SubProduct_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        public void ShowSubProductGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            SubProductoController subController = new SubProductoController();
            List<SubProducto> datos = subController.ObtenerNombreSubProductos();

            var datosPersonalizados = datos.Select(sub => new
            {
                ID = sub.IdSubProducto,
                Nombre = sub.NombreSubProducto,
                Descripcion = sub.DescripcionSubProducto,
                Calidad_Cafe = sub.NombreCalidadCafe
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_subProdCafe.DataSource = datosPersonalizados;

            dtg_subProdCafe.RowHeadersVisible = false;
            dtg_subProdCafe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void btn_tableCalidades_Click(object sender, EventArgs e)
        {
            form_tablaCCafe tablaCCafe = new form_tablaCCafe();
            if (tablaCCafe.ShowDialog() == DialogResult.OK)
            {
                txb_calidadCafe.Text = CalidadSeleccionada.NombreCalidadSeleccionada;
            }
        }

        private void dtg_subProdCafe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila correspondiente a la celda en la que se hizo doble clic
            DataGridViewRow filaSeleccionada = dtg_subProdCafe.Rows[e.RowIndex];
            subProdcSeleccionado = new SubProducto();

            // Obtener los valores de las celdas de la fila seleccionada
            subProdcSeleccionado.IdSubProducto = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
            subProdcSeleccionado.NombreSubProducto = filaSeleccionada.Cells["Nombre"].Value.ToString();
            subProdcSeleccionado.DescripcionSubProducto = filaSeleccionada.Cells["Descripcion"].Value.ToString();
            subProdcSeleccionado.NombreCalidadCafe = filaSeleccionada.Cells["Calidad_Cafe"].Value.ToString();
            CalidadSeleccionada.NombreCalidadSeleccionada = subProdcSeleccionado.NombreCalidadCafe;
        }

        private void btn_modSubProdCafe_Click(object sender, EventArgs e)
        {
            //condicion para verificar si los datos seleccionados van nulos, para evitar error
            if (subProdcSeleccionado != null)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas actualizar el registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // El usuario seleccionó "Sí"
                    imagenClickeada = true;

                    // Asignar los valores a los cuadros de texto solo si no se ha hecho clic en la imagen
                    SubProductoController subC = new SubProductoController();
                    CCafeController cCafe = new CCafeController();
                    var name = cCafe.ObtenerNombreCalidad(CalidadSeleccionada.NombreCalidadSeleccionada);
                    iccafe = name.IdCalidad;

                    txb_subProdCafe.Text = subProdcSeleccionado.NombreSubProducto;
                    txb_descripcion.Text = subProdcSeleccionado.DescripcionSubProducto;
                    txb_calidadCafe.Text = subProdcSeleccionado.NombreCalidadCafe;

                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente el dato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_deleteSubProdCafe_Click(object sender, EventArgs e)
        {
            //condicion para verificar si los datos seleccionados van nulos, para evitar error
            if (subProdcSeleccionado != null)
            {
                LogController log = new LogController();
                UserController userControl = new UserController();

                Usuario usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro del usuario: " + subProdcSeleccionado.NombreSubProducto + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //se llama la funcion delete del controlador para eliminar el registro
                    SubProductoController controller = new SubProductoController();
                    controller.EliminarSubProducto(subProdcSeleccionado.IdSubProducto);

                    //verificar el departamento del log
                    log.RegistrarLog(usuario.IdUsuario, "Eliminacion de dato SubProducto", ModuloActual.NombreModulo, "Eliminacion", "Elimino los datos del SubProducto " + subProdcSeleccionado.NombreSubProducto + " en la base de datos");

                    MessageBox.Show("SubProducto Eliminada correctamente.");

                    //se actualiza la tabla
                    ShowSubProductGrid();
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
            subProdcSeleccionado = null;
        }

        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> { txb_subProdCafe, txb_descripcion, txb_calidadCafe};

            foreach (TextBox textBox in txb)
            {
                textBox.Clear();
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

        private void btn_SaveSubProdCafe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_subProdCafe.Text))
            {
                MessageBox.Show("El campo Sub Producto Cafe, esta vacio y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txb_calidadCafe.Text))
            {
                MessageBox.Show("El campo Calidad Cafe, esta vacio y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SubProductoController subController = new SubProductoController();
            LogController log = new LogController();
            var userControl = new UserController();
            var usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario);

            TextBox[] textBoxes = { txb_subProdCafe };
            ConvertFirstCharacter(textBoxes);

            //se obtiene los valores ingresados por el usuario
            string nameSubProducto = txb_subProdCafe.Text;
            string description = txb_descripcion.Text;

            //Se crea una instancia de la clase SubProducto
            SubProducto subPro = new SubProducto()
            {
                IdSubProducto = (subProdcSeleccionado != null) ? subProdcSeleccionado.IdSubProducto : 0,
                NombreSubProducto = nameSubProducto,
                DescripcionSubProducto = description,
                IdCalidadCafe = CalidadSeleccionada.ICalidadSeleccionada
            };

            if (string.IsNullOrWhiteSpace(txb_descripcion.Text))
            {
                DialogResult result = MessageBox.Show("¿Desea dejar el campo descripcion vacio? Llenar dicho campo permitirá dar una informacion extra a futuros usuarios", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            if (!imagenClickeada)
            {
                // Código que se ejecutará si no se ha hecho clic en la imagen update
                // Llamar al controlador para insertar en la base de datos
                bool exito = subController.InsertarSubProducto(subPro);

                if (exito)
                {
                    MessageBox.Show("SubProducto agregada correctamente.");

                    try
                    {
                        log.RegistrarLog(usuario.IdUsuario, "Registro un SubProducto", ModuloActual.NombreModulo, "Insercion", "Inserto una nueva SubProducto a la base de datos");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos en el datagrid
                    ShowSubProductGrid();
                    //borra los datos de los textbox
                    ClearDataTxb();
                }
                else
                {
                    MessageBox.Show("Error al agregar el SubProducto. Verifique los datos ingresados");
                }
            }
            else
            {
                // Código que se ejecutará si se ha hecho clic en la imagen update
                bool exito = subController.ActualizarSubProducto(subPro);

                if (exito)
                {
                    MessageBox.Show("SubProducto actualizada correctamente.");

                    try
                    {
                        //verifica el departamento
                        log.RegistrarLog(usuario.IdUsuario, "Actualizo un SubProducto", ModuloActual.NombreModulo, "Actualizacion", "Actualizo datos con ID " + subProdcSeleccionado.IdSubProducto + " en la base de datos");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos
                    ShowSubProductGrid();

                    //funcion para limpiar las cajas de texto
                    ClearDataTxb();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el SubProducto, Verifique los datos ingresados.");
                }

                imagenClickeada = false;
            }

        }
    }
}
