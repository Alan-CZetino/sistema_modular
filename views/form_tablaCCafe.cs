using sistema_modular_cafe_majada.controller.ProductController;
using sistema_modular_cafe_majada.model.Mapping;
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
    public partial class form_tablaCCafe : Form
    {
        List<CalidadCafe> datos = new List<CalidadCafe>();

        public form_tablaCCafe()
        {
            InitializeComponent();
            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_tablaCCafe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //funcion para mostrar de inicio los datos en el dataGrid
            ShowDTGCCafeGrid(txb_buscarOpc);

            //esta es una llamada para funcion para pintar las filas del datagrid
            dtg_tablaCCafe.CellPainting += dtg_tableCCafe_CellPainting;
        }

        //
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //esta es una funcion para pintar las filas del datagrid
        private void dtg_tableCCafe_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        //
        public void ShowDTGCCafeGrid(TextBox text)
        {
            var ccafeController = new CCafeController();

            if (string.IsNullOrWhiteSpace(text.Text) || text.Text == "Buscar...")
            {
                // Llamar al método para obtener los datos de la base de datos
                datos = ccafeController.ObtenerCalidades();
            }
            else
            {
                // Llamar al método para obtener los datos de la base de datos
                datos = ccafeController.BuscarCalidades(text.Text);

            }

            var datosPersonalizados = datos.Select(ccafe => new
            {
                ID = ccafe.IdCalidad,
                Nombre = ccafe.NombreCalidad,
                Descripcion = ccafe.DescripcionCalidad
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_tablaCCafe.DataSource = datosPersonalizados;

            dtg_tablaCCafe.RowHeadersVisible = false;
            dtg_tablaCCafe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void dtg_tablaCCafe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila correspondiente a la celda en la que se hizo doble clic
            DataGridViewRow filaSeleccionada = dtg_tablaCCafe.Rows[e.RowIndex];

            // Obtener los valores de las celdas de la fila seleccionada
            CalidadSeleccionada.ICalidadSeleccionada = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
            CalidadSeleccionada.NombreCalidadSeleccionada = filaSeleccionada.Cells["Nombre"].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txb_buscarPer_Enter(object sender, EventArgs e)
        {
            if (txb_buscarOpc.Text == "Buscar...")
            {
                txb_buscarOpc.Text = "";
                txb_buscarOpc.ForeColor = Color.Black;
            }
        }

        private void txb_buscarPer_Leave(object sender, EventArgs e)
        {
            if (txb_buscarOpc.Text == "")
            {
                txb_buscarOpc.Text = "Buscar...";
                txb_buscarOpc.ForeColor = Color.DimGray;
            }
        }

        private void txb_buscarPer_TextChanged(object sender, EventArgs e)
        {
            ShowDTGCCafeGrid(txb_buscarOpc);
        }
    }
}
