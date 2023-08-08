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
using sistema_modular_cafe_majada.controller.AccesController;
using sistema_modular_cafe_majada.model.Mapping.Acces;

namespace sistema_modular_cafe_majada.views
{
    public partial class form_cargosPersonal : Form
    {
        //variable globar para verificar el estado del boton modificar
        private bool imagenClickeada = false;
        //instancia de la clase
        private Charge cargoSeleccionada;

        public form_cargosPersonal()
        {
            InitializeComponent();

            ShowCargoGrid();
        }

        private void dtg_cargosPersonal_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_cargosPersonal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_cargosPersonal.BorderStyle = BorderStyle.None;

            //configuracion de la fila de encabezado en el datagrid
            Font customFonten = new Font("Oswald", 9f, FontStyle.Bold);
            dtg_cargosPersonal.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(184, 89, 89);
            dtg_cargosPersonal.ColumnHeadersDefaultCellStyle.Font = customFonten;
            dtg_cargosPersonal.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtg_cargosPersonal.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 89, 89);
            dtg_cargosPersonal.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dtg_cargosPersonal.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //configuracion de las filas por defecto en el datagrid
            Font customFontdef = new Font("Oswald Light", 10.2f, FontStyle.Regular);

            dtg_cargosPersonal.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dtg_cargosPersonal.DefaultCellStyle.Font = customFontdef;
            dtg_cargosPersonal.DefaultCellStyle.ForeColor = Color.Black;
            dtg_cargosPersonal.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
            dtg_cargosPersonal.DefaultCellStyle.SelectionForeColor = Color.Black;
            dtg_cargosPersonal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //configuracion de las filas que son seleccionadas
            dtg_cargosPersonal.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 199, 199);
            dtg_cargosPersonal.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> { txb_cargo, txb_descripCargo };

            foreach (TextBox textBox in txb)
            {
                textBox.Clear();
            }
        }

        public void ShowCargoGrid()
        {
            ChargeController cargoController = new ChargeController();
            List<Charge> datosCargo = cargoController.ObtenerCargos();

            var infoCargos = datosCargo.Select(cargos => new
            {
                ID = cargos.IdCargo,
                nombre = cargos.NombreCargo,
                descripcion = cargos.DescripcionCargo
            }).ToList();

            dtg_cargosPersonal.DataSource = infoCargos;

            dtg_cargosPersonal.Columns["ID"].HeaderText = "Código de Cargo";
            dtg_cargosPersonal.Columns["nombre"].HeaderText = "Nombre del Cargo";
            dtg_cargosPersonal.Columns["descripcion"].HeaderText = "Descripcion";

            dtg_cargosPersonal.RowHeadersVisible = false;
            dtg_cargosPersonal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dtg_cargosPersonal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("depurador - evento click img update: " + imagenClickeada);

            //obtener la fila a la celda que se realizo el evento dobleClick
            DataGridViewRow filaSeleccionada = dtg_cargosPersonal.Rows[e.RowIndex];
            cargoSeleccionada = new Charge();

            cargoSeleccionada.IdCargo = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
            cargoSeleccionada.NombreCargo = filaSeleccionada.Cells["nombre"].Value.ToString();
            cargoSeleccionada.DescripcionCargo = filaSeleccionada.Cells["descripcion"].Value.ToString();
        }

        private void btn_SaveCargo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_cargo.Text))
            {
                MessageBox.Show("El campo Cargo, esta vacio y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            ChargeController cargoController = new ChargeController();
            LogController log = new LogController();
            var userControl = new UserController();
            var usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario);

            /*TextBox[] textBoxes = {txb_nombreFinca };
            ConvertFirstCharacter(textBoxes);*/

            //se obtiene los valores ingresados por el usuario
            string namecargo = txb_cargo.Text;
            string descripcion = txb_descripCargo.Text;

            //Se crea una instancia de la clase Calidades_cafe
            Charge cargo = new Charge()
            {
                NombreCargo = namecargo,
                DescripcionCargo = descripcion
            };

            if (!imagenClickeada)
            {
                // Código que se ejecutará si no se ha hecho clic en la imagen update
                // Llamar al controlador para insertar en la base de datos
                bool exito =cargoController.InsertarCargo(cargo);

                if (exito)
                {
                    MessageBox.Show("Cargo agregado correctamente.");

                    try
                    {
                        log.RegistrarLog(usuario.IdUsuario, "Registro un Cargo", ModuloActual.NombreModulo, "Insercion", "Inserto un nuevo cargo a la base de datos");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos en el datagrid
                    ShowCargoGrid();
                    //borra los datos de los textbox
                    ClearDataTxb();
                }
                else
                {
                    MessageBox.Show("Error al agregar el cargo. Verifique los datos ingresados");
                }
            }
            else
            {
                // Código que se ejecutará si se ha hecho clic en la imagen update
                bool exito = cargoController.ActualizarCargos(cargoSeleccionada.IdCargo, namecargo, descripcion);

                if (exito)
                {
                    MessageBox.Show("Cargo actualizado correctamente.");

                    try
                    {
                        //verifica el departamento
                        log.RegistrarLog(usuario.IdUsuario, "Actualizo un cargo", ModuloActual.NombreModulo, "Actualizacion", "Actualizo datos con ID " + cargoSeleccionada.IdCargo + " en la base de datos");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos
                    ShowCargoGrid();

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

        private void btn_deleteCargo_Click(object sender, EventArgs e)
        {
            //condicion para verificar si lo datos seleccionados son nulos
            if (cargoSeleccionada != null)
            {
                LogController log = new LogController();
                UserController userController = new UserController();
                //asignar el resultado de obtenerusuario
                Usuario usuario = userController.ObtenerUsuario(UsuarioActual.NombreUsuario);
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro seleccionado " + cargoSeleccionada.NombreCargo + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //se llama la funcion delete del controlador
                    ChargeController controller = new ChargeController();
                    controller.EliminarCargos(cargoSeleccionada.IdCargo);

                    //verifica el departamento del log
                    log.RegistrarLog(usuario.IdUsuario, "Eliminacion de Cargo", ModuloActual.NombreModulo, "Eliminacion", "Elimino los datos de cargo " + cargoSeleccionada.NombreCargo + " en la base de datos");

                    MessageBox.Show("Cargo Eliminado correctamente");

                    ShowCargoGrid();
                    cargoSeleccionada = null;
                }
                else
                {
                    //muestra un mensaje de erro o excepcion
                    MessageBox.Show("No se ha seleccionado correctamente el dato");
                }
            }
        }

        private void btn_modCargo_Click(object sender, EventArgs e)
        {
            if (cargoSeleccionada != null)
            {
                DialogResult result = MessageBox.Show("¿Desea actualizar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //si el usuario selecciono "SI"
                    imagenClickeada = true;

                    //se asignanlos registros a los cuadros de texto
                    txb_cargo.Text = cargoSeleccionada.NombreCargo;
                    txb_descripCargo.Text = cargoSeleccionada.DescripcionCargo;
                }
            }
            else
            {
                //muestra un mensaje de error o excepción
                MessageBox.Show("No se ha seleccionado correctamente el dato");
            }
        }


    }
}
