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
    public partial class form_personas : Form
    {
        public form_personas()
        {
            InitializeComponent();

            // Llamar al método para obtener los datos de la base de datos
            var personController = new PersonController();
            List<Persona> datos = personController.ObtenerPersonas();

            //auto ajustar el contenido de los datos al area establecido para el datagrid
            dataGrid_PersonView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Establece el ancho deseado para la primera columna
            if (dataGrid_PersonView.Columns.Count > 0)
            {
                // Establece el ancho deseado para la primera columna
                dataGrid_PersonView.Columns[0].Width = 10;
            }
            // Establece el modo de ajuste automático para las demás columnas
            for (int i = 1; i < dataGrid_PersonView.Columns.Count; i++)
            {
                dataGrid_PersonView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Asignar los datos al DataGridView
            dataGrid_PersonView.DataSource = datos;

        }

        private void SavePerson_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = { txb_Nombre, txb_Apellido, txb_Direccion };
            ConvertFirstCharacter(textBoxes);

            // Obtener los valores ingresados por el usuario
            string namePerson = txb_Nombre.Text;
            string lastNamePerson = txb_Apellido.Text;
            string location = txb_Direccion.Text;
            string dui = txb_Dui.Text;
            string nit = txb_Nit.Text;
            string phone1 = txb_Tel1.Text;
            string phone2 = txb_Tel2.Text;
            DateTime fechaSeleccionada = txb_FechaNac.Value;

            // Crear una instancia de la clase Persona con los valores obtenidos
            Persona persona = new Persona()
            {
                NombresPersona = namePerson,
                ApellidosPersona = lastNamePerson,
                DireccionPersona = location,
                DuiPersona = dui,
                NitPersona = nit,
                Telefono1Persona = phone1,
                Telefono2Persona = phone2,
                FechaNacimientoPersona = fechaSeleccionada
            };

            // Llamar al controlador para insertar la persona en la base de datos
            PersonController personaController = new PersonController();
            bool exito = personaController.InsertarPersona(persona);

            if (exito)
            {
                MessageBox.Show("Persona guardada exitosamente");

                // Llamar al método para obtener los datos de la base de datos
                var personController = new PersonController();
                List<Persona> datos = personController.ObtenerPersonas();

                // Asignar los nuevos datos al DataGridView
                dataGrid_PersonView.DataSource = datos;

                ClearDataTxb();
            }
            else
            {
                MessageBox.Show("Error al guardar la persona");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
        }

        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> { txb_Nombre, txb_Apellido, txb_Direccion, txb_Dui, txb_Nit,
                                    txb_Tel1, txb_Tel2};

            foreach (TextBox textBox in txb)
            {
                textBox.Text = "";
            }

            txb_FechaNac.Value = DateTime.Now;
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

        private void dataGrid_PersonView_SelectionChanged(object sender, EventArgs e)
        {
            /*if (dataGrid_PersonView.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGrid_PersonView.SelectedRows[0];

                //int id = Convert.ToInt32(filaSeleccionada.Cells["id_persona"].Value);
                string nombres = filaSeleccionada.Cells["nombres_persona"].Value.ToString();
                string apellidos = filaSeleccionada.Cells["apellidos_persona"].Value.ToString();
                string direccion = filaSeleccionada.Cells["direccion_persona"].Value.ToString();
                DateTime fechaNacimiento = Convert.ToDateTime(filaSeleccionada.Cells["fecha_nac_persona"].Value);
                string dui = filaSeleccionada.Cells["dui_persona"].Value.ToString();
                string nit = filaSeleccionada.Cells["nit_persona"].Value != null ? filaSeleccionada.Cells["nit_persona"].Value.ToString() : null;
                string tel1 = filaSeleccionada.Cells["tel1_persona"].Value.ToString();
                string tel2 = filaSeleccionada.Cells["tel2_persona"].Value != null ? filaSeleccionada.Cells["tel2_persona"].Value.ToString() : null;

                txb_Nombre.Text = nombres;
                txb_Apellido.Text = apellidos;
                //ActualizarPersona(id, nombres, apellidos, direccion, fechaNacimiento, dui, nit, tel1, tel2);
            }

            */

        }
    }
}
