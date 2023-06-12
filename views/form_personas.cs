using sistema_modular_cafe_majada.controller.SecurityData;
using sistema_modular_cafe_majada.controller.UserDataController;
using sistema_modular_cafe_majada.model.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_modular_cafe_majada.views
{
    public partial class form_personas : Form
    {
        public form_personas()
        {
            InitializeComponent();

            // Mensaje de depuración
            Console.WriteLine("Constructor - Nombre de usuario: " + UsuarioActual.NombreUsuario);

            //funcion que restringe el uso de caracteres en los textbox necesarios
            List<TextBox> textBoxListN = new List<TextBox> { txb_Tel1, txb_Tel2, txb_Nit, txb_Dui };
            List<TextBox> textBoxListC = new List<TextBox> { txb_Nombre, txb_Apellido};

            //funcion para restringir cual quier caracter y solo acepta unicamente num
            RestrictTextBoxNum(textBoxListN);
            RestrictTextBoxCharacter(textBoxListC);

            LimitDigits(txb_Tel1, 8);
            LimitDigits(txb_Tel2, 8);
            LimitDigits(txb_Dui, 9);

            // Llamar al método para obtener los datos de la base de datos
            var personController = new PersonController();
            List<Persona> datos = personController.ObtenerPersonas();

            // Limpia las columnas existentes en el DataGridView
            dataGrid_PersonView.Columns.Clear();

            // Crea una nueva columna para cada propiedad en la clase mapeada y asigna los nombres deseados
            dataGrid_PersonView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "IdPersona",
                HeaderText = "ID Persona"
            });
            dataGrid_PersonView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NombresPersona",
                HeaderText = "Nombres"
            });
            dataGrid_PersonView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ApellidosPersona",
                HeaderText = "Apellidos"
            });
            dataGrid_PersonView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DireccionPersona",
                HeaderText = "Dirección"
            });
            dataGrid_PersonView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FechaNacimientoPersona",
                HeaderText = "Fecha de Nacimiento"
            });
            dataGrid_PersonView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NitPersona",
                HeaderText = "NIT"
            });
            dataGrid_PersonView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DuiPersona",
                HeaderText = "DUI"
            });
            dataGrid_PersonView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Telefono1Persona",
                HeaderText = "Teléfono"
            });
            dataGrid_PersonView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Telefono2Persona",
                HeaderText = "Teléfono Secundario"
            });

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dataGrid_PersonView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Asignar los datos al DataGridView
            dataGrid_PersonView.DataSource = datos;

        }

        // Evento CellPainting para personalizar el encabezado del DataGridView
        private void dataGrid_PersonView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                // Centrar el texto del encabezado
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Dibujar el fondo del encabezado
                e.PaintBackground(e.CellBounds, true);

                // Dibujar el texto del encabezado
                e.PaintContent(e.CellBounds);

                // Evitar que se dibuje el encabezado predeterminado
                e.Handled = true;
            }
        }


        private void SavePerson_Click(object sender, EventArgs e)
        {
            LogController log = new LogController();
            var userDao = new model.DAO.UserDAO();
            var usuario = userDao.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario
            
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
            DateTime fechaSeleccionada = dtp_FechaNac.Value;

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
                try
                {
                    //Console.WriteLine("el ID obtenido del usuario "+usuario.IdUsuario);
                    log.RegistrarLog(usuario.IdUsuario, "Registro dato Persona", usuario.DeptoUsuario, "Insercion", "Inserto una nueva persona a la base de datos");
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                }
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

            dtp_FechaNac.Value = DateTime.Now;
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

        private void txb_Tel1_Leave(object sender, EventArgs e)
        {
            FormatPhoneNumber(txb_Tel1);
        }

        private void FormatPhoneNumber(TextBox textBox)
        {
            
            string input = textBox.Text;

            // Verificar si hay suficientes dígitos para el número de teléfono
            if (input.Length >= 8)
            {
                string codigoPais = "(+503)";
                string prefijo = input.Substring(0, 4);
                string sufijo = input.Substring(4);

                // Formatear el número de teléfono completo
                string numeroTelefono = $"{codigoPais} {prefijo} - {sufijo}";

                // Establecer el texto formateado en el TextBox
                textBox.Text = numeroTelefono;
            }
            else
            {
                // Si no hay suficientes dígitos, establecer el texto ingresado sin formato
                textBox.Text = input;
            }
        }

        private void FormatDui(TextBox textBox)
        {

            string input = textBox.Text;

            // Verificar si hay suficientes dígitos para el número de teléfono
            if (input.Length >= 9)
            {
                string prefijo = input.Substring(0, 8);
                string sufijo = input.Substring(8);

                // Formatear el número de teléfono completo
                string numeroTelefono = $"{prefijo} - {sufijo}";

                // Establecer el texto formateado en el TextBox
                textBox.Text = numeroTelefono;
            }
            else
            {
                // Si no hay suficientes dígitos, establecer el texto ingresado sin formato
                textBox.Text = input;
            }
        }

        public void LimitDigits(TextBox textBox, int maxLength)
        {
            textBox.KeyPress += (sender, e) =>
            {
                // Verificar si el carácter ingresado es un dígito y si la longitud máxima se ha alcanzado
                if (char.IsDigit(e.KeyChar) && textBox.Text.Length >= maxLength)
                {
                    e.Handled = true; // Cancela el evento KeyPress para evitar que se ingrese el dígito
                }
            };
        }

        public void RestrictTextBoxNum(List<TextBox> textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.KeyPress += (sender, e) =>
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true; // Cancela el evento KeyPress si no es un dígito o una tecla de control
                    }
                };
            }
        }

        public void RestrictTextBoxCharacter(List<TextBox> textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.TextChanged += (sender, e) =>
                {
                    TextBox currentTextBox = (TextBox)sender;
                    string text = currentTextBox.Text;

                    // Eliminar caracteres no alfabéticos, espacios y tildes
                    string filteredText = new string(text.Where(c => char.IsLetter(c) || c == ' ' || c.ToString() == "á" || c.ToString() == "é" || c.ToString() == "í" || c.ToString() == "ó" || c.ToString() == "ú").ToArray());

                    // Actualizar el texto en el TextBox
                    currentTextBox.Text = filteredText;
                };
            }
        }

        private void txb_Tel2_Leave(object sender, EventArgs e)
        {
            FormatPhoneNumber(txb_Tel2);
        }

        private void txb_Dui_Leave(object sender, EventArgs e)
        {
            FormatDui(txb_Dui);
        }
    }
}
