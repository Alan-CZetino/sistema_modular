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
            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_tableUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_tableUser.BorderStyle = BorderStyle.None;

            //configuracion de la fila de encabezado en el datagrid
            Font customFonten = new Font("Oswald", 9f, FontStyle.Bold);
            dtg_tableUser.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(184, 89, 89);
            dtg_tableUser.ColumnHeadersDefaultCellStyle.Font = customFonten;
            dtg_tableUser.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtg_tableUser.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 89, 89);
            dtg_tableUser.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dtg_tableUser.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //configuracion de las filas por defecto en el datagrid
            Font customFontdef = new Font("Oswald Light", 10.2f, FontStyle.Regular);

            dtg_tableUser.DefaultCellStyle.BackColor = Color.White;
            dtg_tableUser.DefaultCellStyle.Font = customFontdef;
            dtg_tableUser.DefaultCellStyle.ForeColor = Color.Black;
            dtg_tableUser.DefaultCellStyle.SelectionBackColor = Color.White;
            dtg_tableUser.DefaultCellStyle.SelectionForeColor = Color.Black;
            dtg_tableUser.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //configuracion de las filas que son seleccionadas
            dtg_tableUser.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 199, 199);
            dtg_tableUser.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
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

            dtg_tableUser.RowHeadersVisible = false;
            dtg_tableUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtg_tableUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si el índice de fila es válido (mayor o igual a 0 y dentro del rango de filas con datos)
            if (e.RowIndex >= 0 && e.RowIndex < dtg_tableUser.Rows.Count)
            {
                // Obtener la fila correspondiente a la celda en la que se hizo doble clic
                DataGridViewRow filaSeleccionada = dtg_tableUser.Rows[e.RowIndex];

                // Obtener los valores de las celdas de la fila seleccionada
                UsuarioSeleccionado.Usuario = filaSeleccionada.Cells["Usuario"].Value.ToString();
                Console.WriteLine("depuracion - capturar datos dobleClick campo; nombre usuario: " + UsuarioSeleccionado.Usuario);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // El índice de fila no es válido, se muestra un mensaje para evitar realizar la acción de error.
                MessageBox.Show("Seleccione una fila válida antes de hacer doble clic en el encabezado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
