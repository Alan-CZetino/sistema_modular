using sistema_modular_cafe_majada.controller.UserDataController;
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
    public partial class form_tableUser : Form
    {
        public form_tableUser()
        {
            InitializeComponent();

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_tableUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //funcion para mostrar de inicio los datos en el dataGrid
            ShowUserGrid();

            //esta es una llamada para funcion para pintar las filas del datagrid
            dtg_tableUser.CellPainting += dtg_tableUser_CellPainting;
        }

        private void dtg_tableUser_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
            var userController = new UserController();
            List<Usuario> datos = userController.ObtenerUsuariosConRol();

            var datosPersonalizados = datos.Select(user => new
            {
                ID = user.IdUsuario,
                Usuario = user.NombreUsuario,
                Email = user.EmailUsuario,
                Estado = user.EstadoUsuario,
                Rol = user.NombreRol,
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_tableUser.DataSource = datosPersonalizados;

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtg_tableUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila correspondiente a la celda en la que se hizo doble clic
            DataGridViewRow filaSeleccionada = dtg_tableUser.Rows[e.RowIndex];

            Console.WriteLine("depuracion - capturar datos dobleClick campo; nombre usuario: " + "");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
