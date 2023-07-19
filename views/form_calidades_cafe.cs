using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using sistema_modular_cafe_majada.controller.SecurityData;
using sistema_modular_cafe_majada.controller.UserDataController;
using sistema_modular_cafe_majada.model.Acces;
using sistema_modular_cafe_majada.model.DAO;
using sistema_modular_cafe_majada.model.UserData;
using sistema_modular_cafe_majada.controller;
using sistema_modular_cafe_majada.model.Mapping;
using sistema_modular_cafe_majada.controller.ProductController;

namespace sistema_modular_cafe_majada.views
{
    public partial class form_calidades_cafe : Form
    {
        //variable global para verificar el estado del boton 
        private bool imagenClickeada = false;
        //instancia de la clase
        private CalidadCafe calidadSeleccionada;

        public form_calidades_cafe()
        {
            InitializeComponent();

            //ShowCalidadCafeGid();
        }

        private void form_calidades_cafe_Load(object sender, EventArgs e)
        {
            //se verifica si ya se agregaron columnas al DataGrid
            //if(dtg_calidadCafe.Columns.Count == 0)
            //{
            //    //Se crea una nueva columna
            //    dtg_calidadCafe.Columns.Add(new DataGridViewTextBoxColumn()
            //    {
            //        DataPropertyName = "ID",
            //        DisplayIndex = 0
            //    });
            //    dtg_calidadCafe.Columns.Add(new DataGridViewTextBoxColumn()
            //    {
            //        DataPropertyName = "Calidad",
            //        DisplayIndex = 1
            //    });
            //    dtg_calidadCafe.Columns.Add(new DataGridViewTextBoxColumn()
            //    {
            //        DataPropertyName = "Descrip",
            //        DisplayIndex = 2
            //    });
            //}

            ShowCalidadCafeGid();
        }

        private void btn_SaveCalidad_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txb_nameCalidad.Text))
            {
                MessageBox.Show("El campo Calidad del Café, esta vacio y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            CCafeController cCafeController = new CCafeController();
            LogController log = new LogController();
            var userControl = new UserController();
            var usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario);

            TextBox[] textBoxes = { txb_nameCalidad };
            ConvertFirstCharacter(textBoxes);

            //se obtiene los valores ingresados por el usuario
            string nameCalidad = txb_nameCalidad.Text;
            string description = txb_desCalidad.Text;

            //Se crea una instancia de la clase Calidades_cafe
            CalidadCafe calidadCafe = new CalidadCafe()
            {
                NombreCalidad = nameCalidad,
                DescripcionCalidad = description
            };

            if (string.IsNullOrWhiteSpace(txb_desCalidad.Text))
            {
                DialogResult result = MessageBox.Show("¿Desea dejar el campo descripcion vacio? Llenar dicho campo permitirá dar una informacion extra a futuros usuarios", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            if (!imagenClickeada)
            {
                // Código que se ejecutará si no se ha hecho clic en la imagen update
                // Llamar al controlador para insertar en la base de datos
                bool exito = cCafeController.InsertarCalidad(calidadCafe);

                if(exito)
                {
                    MessageBox.Show("Calidad de Café agregada correctamente.");

                    try
                    {
                        log.RegistrarLog(usuario.IdUsuario, "Registro una Calidad de Café", ModuloActual.NombreModulo, "Insercion", "Inserto una nueva calidad de café a la base de datos");

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: "+ex.Message);
                    }

                    //funcion para actualizar los datos en el datagrid
                    ShowCalidadCafeGid();
                    //borra los datos de los textbox
                    ClearDataTxb();
                }
                else
                {
                    MessageBox.Show("Error al agregar la calidad del café. Verifique los datos ingresados");
                }
            }
            else
            {
                // Código que se ejecutará si se ha hecho clic en la imagen update
                bool exito = cCafeController.ActualizarCalidades(calidadSeleccionada.IdCalidad, nameCalidad,description);

                if (exito)
                {
                    MessageBox.Show("Calidad de Café actualizada correctamente.");

                    try
                    {
                        //verifica el departamento
                        log.RegistrarLog(usuario.IdUsuario, "Actualizo una calidad de café", ModuloActual.NombreModulo, "Actualizacion", "Actualizo datos datos con ID "+calidadSeleccionada.IdCalidad+" en la base de datos");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos
                    ShowCalidadCafeGid();

                    //funcion para limpiar las cajas de texto
                    ClearDataTxb();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la calidad de café, Verifique los datos ingresados.");
                }

                imagenClickeada = false;
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
            imagenClickeada = false;
        }

        private void btn_modCalidad_Click(object sender, EventArgs e)
        {
            //condicicion para verificar si los datos seleccionados son nulos
            if(calidadSeleccionada !=null)
            {
                DialogResult result = MessageBox.Show("¿Desea actualizar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(result == DialogResult.Yes)
                {
                    //si el usuario selecciono "SI"
                    imagenClickeada = true;

                    //se asignanlos registros a los cuadros de texto
                    txb_nameCalidad.Text = calidadSeleccionada.NombreCalidad;
                    txb_desCalidad.Text = calidadSeleccionada.DescripcionCalidad;
                    
                    calidadSeleccionada = null;
                }
            }
            else
            {
                //muestra un mensaje de error o excepción
                MessageBox.Show("No se ha seleccionado conrrectamente el dato");
            }
        }

        private void btn_deleteCalidad_Click(object sender, EventArgs e)
        {
            //condicion para verificar si lo datos seleccionados son nulos
            if(calidadSeleccionada !=null)
            {
                LogController log = new LogController();
                UserController userController = new UserController();
                //asignar el resultado de obtenerusuario
                Usuario usuario = userController.ObtenerUsuario(UsuarioActual.NombreUsuario);
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro seleccionado "+calidadSeleccionada.NombreCalidad +"?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if(result==DialogResult.Yes)
                {
                    //se llama la funcion delete del controlador
                    CCafeController controller = new CCafeController();
                    controller.EliminarCalidades(calidadSeleccionada.IdCalidad);

                    //verifica el departamento del log
                    log.RegistrarLog(usuario.IdUsuario, "Eliminacion de calidad de café", ModuloActual.NombreModulo, "Eliminacion", "Elimino los datos de Calidad de Café " + calidadSeleccionada.NombreCalidad + " en la base de datos");

                    MessageBox.Show("Calidad de Café Eliminada correctamente");

                    ShowCalidadCafeGid();
                    calidadSeleccionada = null;
                }
                else
                {
                    //muestra un mensaje de erro o excepcion
                    MessageBox.Show("No se ha seleccionado correctamente el dato");
                }
            }
        }

        public void ShowCalidadCafeGid()
        {
            //se llama el metodo para obtener los datos de la base de datos
            var calidadesController = new CCafeController();
            List<CalidadCafe> datosCCafe = calidadesController.ObtenerCalidades();

            var datosCalidades = datosCCafe.Select(calidades => new
            {
                Codigo = calidades.IdCalidad,
                Calidad = calidades.NombreCalidad,
                Descripcion = calidades.DescripcionCalidad
            }).ToList();

            //se asignan los datos al datagrid
            dtg_calidadCafe.DataSource = datosCalidades;
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

        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> {txb_nameCalidad,txb_desCalidad};

            foreach (TextBox textBox in txb)
            {
                textBox.Clear();
            }
        }

        private void dtg_calidadCafe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("depurador - evento click img update: " + imagenClickeada);

            //obtener la fila a la celda que se realizo el evento dobleClick
            DataGridViewRow filaSeleccionada = dtg_calidadCafe.Rows[e.RowIndex];
            calidadSeleccionada = new CalidadCafe();

            calidadSeleccionada.IdCalidad = Convert.ToInt32(filaSeleccionada.Cells["Codigo"].Value);
            calidadSeleccionada.NombreCalidad = filaSeleccionada.Cells["Calidad"].Value.ToString();
            calidadSeleccionada.DescripcionCalidad = filaSeleccionada.Cells["Descripcion"].Value.ToString();


            Console.WriteLine("depuracion - capturar datos dobleclick; nombre de calidad de café: " + calidadSeleccionada.NombreCalidad);
        }
    }
}
