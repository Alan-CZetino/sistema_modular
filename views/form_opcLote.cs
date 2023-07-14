using sistema_modular_cafe_majada.controller;
using sistema_modular_cafe_majada.controller.HarvestController;
using sistema_modular_cafe_majada.controller.ProductController;
using sistema_modular_cafe_majada.model.Mapping;
using sistema_modular_cafe_majada.model.Mapping.Harvest;
using sistema_modular_cafe_majada.model.Mapping.Product;
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
    public partial class form_opcLote : Form
    {

        public form_opcLote()
        {
            InitializeComponent();

            this.KeyPreview = true; // Habilita la captura de eventos de teclado para el formulario

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_tableOpc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            int opc = TablaSeleccionada.ITable;

            switch (opc)
            {
                case 1:
                    //finca
                    //funcion para mostrar de inicio los datos en el dataGrid
                    ShowFincaGrid();
                    break;
                case 2:
                    //tipo de cafe
                    //funcion para mostrar de inicio los datos en el dataGrid
                    ShowTipoCafeGrid();
                    break;
                case 3:
                    //calidad
                    //funcion para mostrar de inicio los datos en el dataGrid
                    ShowCalidadGrid();
                    break;
                case 4:
                    //cosecha
                    //funcion para mostrar de inicio los datos en el dataGrid
                    ShowCosechaGrid();
                    break;
                default:
                    MessageBox.Show("Ocurrio un Error. La tabla que desea acceder no exite. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            //esta es una llamada para funcion para pintar las filas del datagrid
            dtg_tableOpc.CellPainting += dtg_tableOpc_CellPainting;
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

        //
        public void ShowCalidadGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            var calidadController = new CCafeController();
            List<CalidadCafe> datos = calidadController.ObtenerCalidades();

            var datosPersonalizados = datos.Select(calidad => new
            {
                ID = calidad.IdCalidad,
                Nombre = calidad.NombreCalidad,
                Descripcion = calidad.DescripcionCalidad
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_tableOpc.DataSource = datosPersonalizados;

            dtg_tableOpc.RowHeadersVisible = false;
            dtg_tableOpc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        //
        public void ShowCosechaGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            var cosechaController = new CosechaController();
            List<Cosecha> datos = cosechaController.ObtenerCosecha();

            var datosPersonalizados = datos.Select(cosecha => new
            {
                ID = cosecha.IdCosecha,
                Nombre = cosecha.NombreCosecha,
                Fecha_Inicio = cosecha.FechaCosecha
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_tableOpc.DataSource = datosPersonalizados;

            dtg_tableOpc.RowHeadersVisible = false;
            dtg_tableOpc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        //
        public void ShowFincaGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            var fincaController = new FincaController();
            List<Finca> datos = fincaController.ObtenerFincas();

            var datosPersonalizados = datos.Select(finca => new
            {
                ID = finca.IdFinca,
                Nombres = finca.nombreFinca,
                Ubicacion = finca.ubicacionFinca
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_tableOpc.DataSource = datosPersonalizados;

            dtg_tableOpc.RowHeadersVisible = false;
            dtg_tableOpc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        //
        public void ShowTipoCafeGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            var tipoCafeController = new TipoCafeController();
            List<TipoCafe> datos = tipoCafeController.ObtenerTipoCafes();

            var datosPersonalizados = datos.Select(tipoC => new
            {
                ID = tipoC.IdTipoCafe,
                Nombre = tipoC.NombreTipoCafe,
                Descripcion = tipoC.DescripcionTipoCafe
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_tableOpc.DataSource = datosPersonalizados;

            dtg_tableOpc.RowHeadersVisible = false;
            dtg_tableOpc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtg_tableOpc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila correspondiente a la celda en la que se hizo doble clic
            DataGridViewRow filaSeleccionada = dtg_tableOpc.Rows[e.RowIndex];

            int opc = TablaSeleccionada.ITable;

            switch (opc)
            {
                case 1:
                    //finca
                    {
                        // Obtener los valores de las celdas de la fila seleccionada
                        FincaSeleccionada.IFincaSeleccionada = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                        FincaSeleccionada.NombreFincaSeleccionada = filaSeleccionada.Cells["Nombres"].Value.ToString();

                        Console.WriteLine("depuracion - capturar datos dobleClick campo; nombre finca: " + FincaSeleccionada.NombreFincaSeleccionada);
                    }
                    break;
                case 2:
                    //tipo de cafe
                    {
                        // Obtener los valores de las celdas de la fila seleccionada
                        TipoCafeSeleccionado.ITipoCafeSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                        TipoCafeSeleccionado.NombreTipoCafeSeleccionado = filaSeleccionada.Cells["Nombre"].Value.ToString();

                        Console.WriteLine("depuracion - capturar datos dobleClick campo; nombre finca: " + FincaSeleccionada.NombreFincaSeleccionada);
                    }
                    break;
                case 3:
                    //calidad
                    {
                        // Obtener los valores de las celdas de la fila seleccionada
                        CalidadSeleccionada.ICalidadSeleccionada = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                        CalidadSeleccionada.NombreCalidadSeleccionada = filaSeleccionada.Cells["Nombre"].Value.ToString();

                        Console.WriteLine("depuracion - capturar datos dobleClick campo; nombre finca: " + FincaSeleccionada.NombreFincaSeleccionada);
                    }
                    break;
                case 4:
                    //cosecha
                    {
                        // Obtener los valores de las celdas de la fila seleccionada
                        CosechaSeleccionada.ICosechaSeleccionada = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                        CosechaSeleccionada.NombreCosechaSeleccionada = filaSeleccionada.Cells["Nombre"].Value.ToString();

                        Console.WriteLine("depuracion - capturar datos dobleClick campo; nombre finca: " + FincaSeleccionada.NombreFincaSeleccionada);
                    }
                    break;
                default:
                    MessageBox.Show("Ocurrio un Error. La tabla que desea acceder no exite. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void form_opcLote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Cierra el formulario actual
            }
        }
    }
}
