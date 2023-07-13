using sistema_modular_cafe_majada.controller.HarvestController;
using sistema_modular_cafe_majada.controller.SecurityData;
using sistema_modular_cafe_majada.controller.UserDataController;
using sistema_modular_cafe_majada.model.Acces;
using sistema_modular_cafe_majada.model.Mapping.Harvest;
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
    public partial class form_lote : Form
    {
        //variable global para verificar el estado del boton actualizar
        private bool imagenClickeada = false;
        //instancia de la clase mapeo Lote para capturar los datos seleccionado por el usuario
        private Lote loteSeleccionado;


        form_opcLote form_Opc=new form_opcLote();

        public form_lote()
        {
            InitializeComponent();

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_lotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ShowLoteGrid();

            dtg_lotes.CellPainting += dtgv_lote_CellPainting;
        }

        private void dtgv_lote_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        public void ShowLoteGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            var loteController = new LoteController();
            List<Lote> datos = loteController.ObtenerLotesNombreID();

            var datosPersonalizados = datos.Select(lote => new
            {
                ID = lote.IdLote,
                Nombre = lote.NombreLote,
                Cantidad = lote.CantidadLote,
                Fecha = lote.FechaLote,
                Tipo_Cafe = lote.TipoCafe,
                Nombre_Calidad = lote.NombreCalidadLote,
                Nombre_Cosecha = lote.NombreCosechaLote,
                Nombre_Finca = lote.NombreFinca
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_lotes.DataSource = datosPersonalizados;

            dtg_lotes.RowHeadersVisible = false;
            dtg_lotes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> { txb_numLote, txb_nomFinca, txb_dateIngreso, txb_cantidad, txb_tipoCafe, txb_cosecha, txb_calidadCafe,  };

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

        private void btn_updateLote_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas actualizar el registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // El usuario seleccionó "Sí"
                imagenClickeada = true;

                // Asignar los valores a los cuadros de texto solo si no se ha hecho clic en la imagen
                txb_numLote.Text = loteSeleccionado.NombreLote;
                txb_nomFinca.Text = loteSeleccionado.NombreFinca;
                txb_calidadCafe.Text = loteSeleccionado.NombreCalidadLote;
                txb_cantidad.Text = loteSeleccionado.CantidadLote.ToString("0.00");
                txb_cosecha.Text = loteSeleccionado.NombreCalidadLote;
                //txb_dateIngreso.Text = loteSeleccionado.FechaLote;
                txb_tipoCafe.Text = loteSeleccionado.TipoCafe;
            }
            else
            {
                // El usuario seleccionó "No" o cerró el cuadro de diálogo
            }
        }

        private void btn_deleteLote_Click(object sender, EventArgs e)
        {
            //condicion para verificar si los datos seleccionados van nulos, para evitar error
            if (loteSeleccionado != null)
            {
                LogController log = new LogController();
                UserController userControl = new UserController();
                Usuario usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar los datos registrado del Lote: (" + loteSeleccionado.NombreLote + ") ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //se llama la funcion delete del controlador para eliminar el registro
                    LoteController controller = new LoteController();
                    controller.EliminarLote(loteSeleccionado.IdLote);

                    //verificar el departamento del log
                    log.RegistrarLog(usuario.IdUsuario, "Eliminado los datos Lote", ModuloActual.NombreModulo, "Eliminacion", "Elimino los datos del Lote (" + loteSeleccionado.NombreLote + ") en la base de datos");

                    MessageBox.Show("Lote Eliminado correctamente.", "Eliminacion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //se actualiza la tabla
                    ShowLoteGrid();
                    loteSeleccionado = null;
                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente las caracteristicas del Lote", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
        }

        private void btn_tFinca_Click(object sender, EventArgs e)
        {
            form_Opc.ShowDialog();
        }

        private void btn_tCafe_Click(object sender, EventArgs e)
        {
            form_Opc.ShowDialog();
        }

        private void btn_tcCafe_Click(object sender, EventArgs e)
        {
            form_Opc.ShowDialog();
        }

        private void btn_tCosecha_Click(object sender, EventArgs e)
        {
            form_Opc.ShowDialog();
        }
    }
}
