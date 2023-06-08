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
    }
}
