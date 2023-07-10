using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sistema_modular_cafe_majada.controller.SecurityData;
using sistema_modular_cafe_majada.controller.UserDataController;
using sistema_modular_cafe_majada.model.Acces;
using sistema_modular_cafe_majada.model.DAO;
using sistema_modular_cafe_majada.model.UserData;
using sistema_modular_cafe_majada.controller;
using sistema_modular_cafe_majada.model.Mapping;


namespace sistema_modular_cafe_majada.views
{
    public partial class form_finca : Form
    {
        //variable globar para verificar el estado del boton modificar
        private bool imagenClickeada = false;
        //instancia de la clase
        private Finca fincaSeleccionada;

        public form_finca()
        {
            InitializeComponent();
            
            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_fincas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ShowFincaGrid();
        }

        public void ShowFincaGrid()
        {
            FincaController fincaController = new FincaController();
            List<Finca> datosFinca = fincaController.ObtenerFincas();

            var fincasDatos = datosFinca.Select(fincas => new
            {
                codigoFinca = fincas.IdFinca,
                nomFinca = fincas.nombreFinca,
                ubiFinca = fincas.ubicacionFinca
            }).ToList();

            dtg_fincas.DataSource=fincasDatos;

            dtg_fincas.Columns["codigoFinca"].HeaderText = "Código de Finca";
            dtg_fincas.Columns["nomFinca"].HeaderText = "Nombre de la Finca";
            dtg_fincas.Columns["ubiFinca"].HeaderText = "Ubicación de la Finca";

            
        }

        private void btn_SaveFinca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_nombreFinca.Text) ||
                string.IsNullOrWhiteSpace(txb_ubiFinca.Text))
            {
                MessageBox.Show("Los campos Nombre de Finca y Ubicacion de Finca son obligatorios.");
                return;
            }

            FincaController fincaController = new FincaController();
            LogController log = new LogController();
            var userControl = new UserController();
            var usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario);

            /*TextBox[] textBoxes = {txb_nombreFinca };
            ConvertFirstCharacter(textBoxes);*/

            //se obtiene los valores ingresados por el usuario
            string namefinca = txb_nombreFinca.Text;
            string ubicFinca = txb_ubiFinca.Text;

            //Se crea una instancia de la clase Calidades_cafe
            Finca fincas = new Finca()
            {
                nombreFinca = namefinca,
                ubicacionFinca = ubicFinca
            };

            if (!imagenClickeada)
            {
                // Código que se ejecutará si no se ha hecho clic en la imagen update
                // Llamar al controlador para insertar en la base de datos
                bool exito = fincaController.InsertarFinca(fincas);

                if (exito)
                {
                    MessageBox.Show("Finca agregada correctamente.");

                    try
                    {
                        log.RegistrarLog(usuario.IdUsuario, "Registro una Finca", ModuloActual.NombreModulo, "Insercion", "Inserto una nueva finca a la base de datos");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos en el datagrid
                    ShowFincaGrid();
                    //borra los datos de los textbox
                    ClearDataTxb();
                }
                else
                {
                    MessageBox.Show("Error al agregar la finca. Verifique los datos ingresados");
                }
            }
            else
            {
                // Código que se ejecutará si se ha hecho clic en la imagen update
                bool exito = fincaController.ActualizarFincas(fincaSeleccionada.IdFinca,namefinca , ubicFinca);

                if (exito)
                {
                    MessageBox.Show("Finca actualizada correctamente.");

                    try
                    {
                        //verifica el departamento
                        log.RegistrarLog(usuario.IdUsuario, "Actualizo una Finca", ModuloActual.NombreModulo, "Actualizacion", "Actualizo datos con ID " + fincaSeleccionada.IdFinca + " en la base de datos");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos
                    ShowFincaGrid();

                    //funcion para limpiar las cajas de texto
                    ClearDataTxb();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la finca, Verifique los datos ingresados.");
                }

                imagenClickeada = false;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
            imagenClickeada = false;
        }

        private void btn_updateFinca_Click(object sender, EventArgs e)
        {
            if (fincaSeleccionada != null)
            {
                DialogResult result = MessageBox.Show("¿Desea actualizar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //si el usuario selecciono "SI"
                    imagenClickeada = true;

                    //se asignanlos registros a los cuadros de texto
                    txb_nombreFinca.Text = fincaSeleccionada.nombreFinca;
                    txb_ubiFinca.Text = fincaSeleccionada.ubicacionFinca;
                }
            }
            else
            {
                //muestra un mensaje de error o excepción
                MessageBox.Show("No se ha seleccionado correctamente el dato");
            }
        }

        private void btn_deleteFinca_Click(object sender, EventArgs e)
        {
            //condicion para verificar si lo datos seleccionados son nulos
            if (fincaSeleccionada != null)
            {
                LogController log = new LogController();
                UserController userController = new UserController();
                //asignar el resultado de obtenerusuario
                Usuario usuario = userController.ObtenerUsuario(UsuarioActual.NombreUsuario);
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro seleccionado " + fincaSeleccionada.nombreFinca + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //se llama la funcion delete del controlador
                    FincaController controller = new FincaController();
                    controller.EliminarFinca(fincaSeleccionada.IdFinca);

                    //verifica el departamento del log
                    log.RegistrarLog(usuario.IdUsuario, "Eliminacion de finca", ModuloActual.NombreModulo, "Eliminacion", "Elimino los datos de finca " + fincaSeleccionada.nombreFinca + " en la base de datos");

                    MessageBox.Show("Calidad de Café Eliminada correctamente");

                    ShowFincaGrid();
                    fincaSeleccionada = null;
                }
                else
                {
                    //muestra un mensaje de erro o excepcion
                    MessageBox.Show("No se ha seleccionado correctamente el dato");
                }
            }
        }

        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> { txb_nombreFinca, txb_ubiFinca };

            foreach (TextBox textBox in txb)
            {
                textBox.Clear();
            }
        }

        private void dtg_fincas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("depurador - evento click img update: " + imagenClickeada);

            //obtener la fila a la celda que se realizo el evento dobleClick
            DataGridViewRow filaSeleccionada = dtg_fincas.Rows[e.RowIndex];
            fincaSeleccionada = new Finca();

            fincaSeleccionada.IdFinca = Convert.ToInt32(filaSeleccionada.Cells["codigoFinca"].Value);
            fincaSeleccionada.nombreFinca = filaSeleccionada.Cells["nomFinca"].Value.ToString();
            fincaSeleccionada.ubicacionFinca = filaSeleccionada.Cells["ubiFinca"].Value.ToString();

        }
    }
}
