using sistema_modular_cafe_majada.controller.AccesController;
using sistema_modular_cafe_majada.model.Acces;
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
    public partial class form_rol : Form
    {
        //variable global para verificar el estado del boton actualizar
        private bool imagenClickeada = false;
        //instancia de la clase mapeo rol para capturar los datos seleccionado por el usuario
        private Role rolSeleccionado;

        public form_rol()
        {
            InitializeComponent();

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtgv_roles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ShowRolGrid();

            dtgv_roles.CellPainting += dtgv_roles_CellPainting;
        }

        private void dtgv_roles_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        public void ShowRolGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            var rolController = new RoleController();
            List<Role> datos = rolController.ObtenerRoles();

            var datosPersonalizados = datos.Select(rol => new
            {
                ID = rol.IdRol,
                Nombre = rol.NombreRol,
                Descripcion = rol.DescripcionRol,
                Nivel = rol.NivelAccesoRol,
                Permiso = rol.PermisosRol,
                Fecha_Creacion = rol.FechaCreacionRol,
                Fecha_Modificacion = rol.UltFechaModRol
            }).ToList();

            // Asignar los datos al DataGridView
            dtgv_roles.DataSource = datosPersonalizados;

        }

        private void btn_SaveRol_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
        }

        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> { txb_NameRol, txb_Description, txb_permits};

            foreach (TextBox textBox in txb)
            {
                textBox.Text = "";
            }
            cbx_access.Items.Clear(); // Eliminar todos los elementos del ComboBox
            cbx_access.SelectedIndex = -1; // Deseleccionar cualquier elemento seleccionado previamente

        }

        private void btn_mod_rol_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas actualizar el registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // El usuario seleccionó "Sí"
                imagenClickeada = true;

                // Asignar los valores a los cuadros de texto solo si no se ha hecho clic en la imagen
                txb_NameRol.Text = rolSeleccionado.NombreRol;
                txb_Description.Text = rolSeleccionado.DescripcionRol;
                txb_permits.Text = rolSeleccionado.PermisosRol;

                cbx_access.Items.Add("Tier 1");
                cbx_access.Items.Add("Tier 2");
                cbx_access.Items.Add("Tier 3");

            }
            else
            {
                // El usuario seleccionó "No" o cerró el cuadro de diálogo
            }
        }

        private void btn_delete_rol_Click(object sender, EventArgs e)
        {

        }

        private void dtgv_roles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila correspondiente a la celda en la que se hizo doble clic
            DataGridViewRow filaSeleccionada = dtgv_roles.Rows[e.RowIndex];
            rolSeleccionado = new Role();

            // Obtener los valores de las celdas de la fila seleccionada
            rolSeleccionado.IdRol = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
            rolSeleccionado.NombreRol = filaSeleccionada.Cells["Nombre"].Value.ToString();
            rolSeleccionado.DescripcionRol = filaSeleccionada.Cells["Descripcion"].Value.ToString();
            rolSeleccionado.PermisosRol = filaSeleccionada.Cells["Permiso"].Value.ToString();

            Console.WriteLine("depuracion - capturar datos dobleClick campo; nombre persona: " + rolSeleccionado.NombreRol);
        }
    }
}
