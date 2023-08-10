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
    public partial class form_tableperson : Form
    {
        List<Persona> datos = new List<Persona>();
        public form_tableperson()
        {
            InitializeComponent();

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_tablePerson.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //funcion para mostrar de inicio los datos en el dataGrid
            ShowPersonGrid(txb_buscarPer);

            //esta es una llamada para funcion para pintar las filas del datagrid
            dtg_tablePerson.CellPainting += dtg_tablePerson_CellPainting;
        }

        //esta es una funcion para pintar las filas del datagrid
        private void dtg_tablePerson_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_tablePerson.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_tablePerson.BorderStyle = BorderStyle.None;

            //configuracion de la fila de encabezado en el datagrid
            Font customFonten = new Font("Oswald", 9f, FontStyle.Bold);
            dtg_tablePerson.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(184, 89, 89);
            dtg_tablePerson.ColumnHeadersDefaultCellStyle.Font = customFonten;
            dtg_tablePerson.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtg_tablePerson.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 89, 89);
            dtg_tablePerson.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dtg_tablePerson.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //configuracion de las filas por defecto en el datagrid
            Font customFontdef = new Font("Oswald Light", 10.2f, FontStyle.Regular);

            dtg_tablePerson.DefaultCellStyle.BackColor = Color.White;
            dtg_tablePerson.DefaultCellStyle.Font = customFontdef;
            dtg_tablePerson.DefaultCellStyle.ForeColor = Color.Black;
            dtg_tablePerson.DefaultCellStyle.SelectionBackColor = Color.White;
            dtg_tablePerson.DefaultCellStyle.SelectionForeColor = Color.Black;
            dtg_tablePerson.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //configuracion de las filas que son seleccionadas
            dtg_tablePerson.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 199, 199);
            dtg_tablePerson.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowPersonGrid(TextBox text)
        {
            var personController = new PersonController();
            

            if (string.IsNullOrWhiteSpace(text.Text) || text.Text == "Buscar...")
            {
                // Llamar al método para obtener los datos de la base de datos
                datos = personController.ObtenerPersonas();
            }
            else
            {
                // Llamar al método para obtener los datos de la base de datos
                datos = personController.BuscarPersonas(text.Text);

            }

            var datosPersonalizados = datos.Select(persona => new
            {
                ID = persona.IdPersona,
                Nombres = persona.NombresPersona,
                Apellidos = persona.ApellidosPersona,
                Dirección = persona.DireccionPersona,
                DUI = persona.DuiPersona,
                Teléfono = persona.Telefono1Persona,
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_tablePerson.DataSource = datosPersonalizados;

            dtg_tablePerson.RowHeadersVisible = false;
            dtg_tablePerson.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void dtg_tablePerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si el índice de fila es válido (mayor o igual a 0 y dentro del rango de filas con datos)
            if (e.RowIndex >= 0 && e.RowIndex < dtg_tablePerson.Rows.Count)
            {
                // Obtener la fila correspondiente a la celda en la que se hizo doble clic
                DataGridViewRow filaSeleccionada = dtg_tablePerson.Rows[e.RowIndex];

                // Obtener los valores de las celdas de la fila seleccionada
                PersonSelect.IdPerson = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                PersonSelect.NamePerson = filaSeleccionada.Cells["Nombres"].Value.ToString();
            
                Console.WriteLine("depuracion - capturar datos dobleClick campo; nombre persona: " + PersonSelect.IdPerson);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // El índice de fila no es válido, se muestra un mensaje para evitar realizar la acción de error.
                MessageBox.Show("Seleccione una fila válida antes de hacer doble clic en el encabezado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txb_buscarPer_Enter(object sender, EventArgs e)
        {
            if (txb_buscarPer.Text == "Buscar...")
            {
                txb_buscarPer.Text = "";
                txb_buscarPer.ForeColor = Color.Black;
            }
        }

        private void txb_buscarPer_Leave(object sender, EventArgs e)
        {
            if (txb_buscarPer.Text == "")
            {
                txb_buscarPer.Text = "Buscar...";
                txb_buscarPer.ForeColor = Color.DimGray;
            }
        }

        private void txb_buscarPer_TextChanged(object sender, EventArgs e)
        {
            ShowPersonGrid(txb_buscarPer);
        }
    }
}
