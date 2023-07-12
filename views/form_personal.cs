using sistema_modular_cafe_majada.controller.OperationsController;
using sistema_modular_cafe_majada.controller.SecurityData;
using sistema_modular_cafe_majada.controller.UserDataController;
using sistema_modular_cafe_majada.model.Acces;
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
    public partial class form_personal : Form
    {
        //variable global para verificar el estado del boton actualizar
        private bool imagenClickeada = false;
        //instancia de la clase mapeo personal para capturar los datos seleccionado por el usuario
        private Personal personalSeleccionado;

        public form_personal()
        {
            InitializeComponent();

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_personal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ShowPersonalGrid();

            dtg_personal.CellPainting += dtgv_personal_CellPainting;
        }

        private void btn_tablePerson_Click(object sender, EventArgs e)
        {
            form_tableperson ftperson = new form_tableperson();
            if (ftperson.ShowDialog() == DialogResult.OK)
            {
                //txb_NamePerson.Text = PersonSelect.NamePerson;
            }
        }

        private void dtgv_personal_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        public void ShowPersonalGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            var personalController = new PersonalController();
            List<Personal> datos = personalController.ObtenerPersonals();

            var datosPersonalizados = datos.Select(personal => new
            {
                ID = personal.IdPersonal,
                Nombre = personal.NombrePersonal,
                Cargo = personal.CargoPersonal,
                Descripcion = personal.Descripcion,
                ID_Persona = personal.IdPersona,
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_personal.DataSource = datosPersonalizados;

            dtg_personal.RowHeadersVisible = false;
            dtg_personal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> { txb_namePersonal,txb_Descrip };

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

        private void dtg_personal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila correspondiente a la celda en la que se hizo doble clic
            DataGridViewRow filaSeleccionada = dtg_personal.Rows[e.RowIndex];
            personalSeleccionado = new Personal();

            // Obtener los valores de las celdas de la fila seleccionada
            personalSeleccionado.IdPersonal = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
            personalSeleccionado.IdPersona = Convert.ToInt32(filaSeleccionada.Cells["ID_Persona"].Value);
            personalSeleccionado.NombrePersonal = filaSeleccionada.Cells["Nombre"].Value.ToString();
            personalSeleccionado.CargoPersonal = filaSeleccionada.Cells["Cargo"].Value.ToString();
            personalSeleccionado.Descripcion = filaSeleccionada.Cells["Descripcion"].Value.ToString();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
        }

        private void btn_deletePersonal_Click(object sender, EventArgs e)
        {
            //condicion para verificar si los datos seleccionados van nulos, para evitar error
            if (personalSeleccionado != null)
            {
                LogController log = new LogController();
                UserController userControl = new UserController();
                Usuario usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar los datos registrado del Personal: (" + personalSeleccionado.NombrePersonal + ") ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //se llama la funcion delete del controlador para eliminar el registro
                    PersonalController controller = new PersonalController();
                    controller.EliminarPersonal(personalSeleccionado.IdPersonal);

                    //verificar el departamento del log
                    log.RegistrarLog(usuario.IdUsuario, "Eliminacion de los datos Personal", ModuloActual.NombreModulo, "Eliminacion", "Elimino los datos del Personal (" + personalSeleccionado.NombrePersonal + ") en la base de datos");

                    MessageBox.Show("Personal Eliminado correctamente.", "Eliminacion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //se actualiza la tabla
                    ShowPersonalGrid();
                    personalSeleccionado = null;
                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente las caracteristicas del Personal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_modPersonal_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas actualizar el registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // El usuario seleccionó "Sí"
                imagenClickeada = true;

                // Asignar los valores a los cuadros de texto solo si no se ha hecho clic en la imagen
                txb_namePersonal.Text = personalSeleccionado.NombrePersonal;
                //txb_cargo.Text = personalSeleccionado.CargoPersonal;
                //txb_descripcion.Text = personalSeleccionado.Descripcion;
                //txb_idPersona.Text = personalSeleccionado.IdPersona;
            }
            else
            {
                // El usuario seleccionó "No" o cerró el cuadro de diálogo
            }


        }

        private void btn_SavePersonal_Click(object sender, EventArgs e)
        {

        }
    }
}
