using sistema_modular_cafe_majada.controller.InfrastructureController;
using sistema_modular_cafe_majada.model.Mapping.Infrastructure;
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
    public partial class form_tablaBeneficio : Form
    {
        public form_tablaBeneficio()
        {
            InitializeComponent();

            this.KeyPreview = true; // Habilita la captura de eventos de teclado para el formulario

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_tOpc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //
            SearchRegister(txb_buscar);
            txb_buscar.TextChanged += txb_buscarOpc_TextChanged;

            //esta es una llamada para funcion para pintar las filas del datagrid
            dtg_tOpc.CellPainting += dtg_tableOpc_CellPainting;
        }

        //
        public void ShowBeneficioGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            var beneficioController = new BeneficioController();
            List<Beneficio> datos = beneficioController.ObtenerBeneficios();

            var datosPersonalizados = datos.Select(benef => new
            {
                ID = benef.IdBeneficio,
                Nombre = benef.NombreBeneficio,
                Ubicacion = benef.UbicacionBeneficio
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_tOpc.DataSource = datosPersonalizados;

            dtg_tOpc.RowHeadersVisible = false;
            dtg_tOpc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        //esta es una funcion para pintar las filas del datagrid
        private void dtg_tableOpc_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtg_tOpc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila correspondiente a la celda en la que se hizo doble clic
            DataGridViewRow filaSeleccionada = dtg_tOpc.Rows[e.RowIndex];

            int opc = TablaSeleccionadabodega.ITable;

            switch (opc)
            {
                case 1:
                    //beneficio
                    {
                        // Obtener los valores de las celdas de la fila seleccionada
                        BeneficioSeleccionado.IdBeneficioSleccionado = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                        BeneficioSeleccionado.NombreBeneficioSeleccionado = filaSeleccionada.Cells["Nombre"].Value.ToString();

                    }
                    break;
                default:
                    MessageBox.Show("Ocurrio un Error. La tabla que desea acceder no exite. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void txb_buscarOpc_TextChanged(object sender, EventArgs e)
        {
            SearchRegister(txb_buscar);
        }

        //
        public void SearchRegister(TextBox text)
        {
            int opc = TablaSeleccionadabodega.ITable;

            switch (opc)
            {
                case 1:
                    {
                        //Beneficio
                        if (string.IsNullOrWhiteSpace(text.Text) || text.Text == "Buscar...")
                        {
                            //funcion para mostrar de inicio los datos en el dataGrid
                            ShowBeneficioGrid();
                        }
                        else
                        {
                            // Llamar al método para obtener los datos de la base de datos
                            var benefController = new BeneficioController();
                            List<Beneficio> datos = benefController.BuscarBeneficio(text.Text);

                            var datosPersonalizados = datos.Select(benef => new
                            {
                                ID = benef.IdBeneficio,
                                Nombre = benef.NombreBeneficio,
                                Ubicacion = benef.UbicacionBeneficio
                            }).ToList();

                            // Asignar los datos al DataGridView
                            dtg_tOpc.DataSource = datosPersonalizados;

                            dtg_tOpc.RowHeadersVisible = false;
                            dtg_tOpc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        }
                    }

                    break;
                default:
                    MessageBox.Show("Ocurrio un Error. La tabla que desea acceder no exite. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        //
        private void txb_buscarOpc_Enter(object sender, EventArgs e)
        {
            if (txb_buscar.Text == "Buscar...")
            {
                txb_buscar.Text = string.Empty;
                txb_buscar.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txb_buscarOpc_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_buscar.Text))
            {
                txb_buscar.Text = "Buscar...";
                txb_buscar.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
}
