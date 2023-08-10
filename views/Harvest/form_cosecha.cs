using sistema_modular_cafe_majada.controller.HarvestController;
using sistema_modular_cafe_majada.controller.SecurityData;
using sistema_modular_cafe_majada.controller.UserDataController;
using sistema_modular_cafe_majada.model.Acces;
using sistema_modular_cafe_majada.model.Mapping.Harvest;
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
    public partial class form_cosecha : Form
    {
        //variable global para verificar el estado del boton actualizar
        private bool imagenClickeada = false;
        //instancia de la clase mapeo beneficio para capturar los datos seleccionado por el usuario
        private Cosecha cosechaSeleccionado;

        public form_cosecha()
        {
            InitializeComponent();

            txb_id.ReadOnly = true;
            txb_id.Enabled = false;

            //coloca nueva mente el contador en el txb del cdigo
            CosechaController cosec = new CosechaController();
            var count = cosec.CountCosecha();
            txb_id.Text = Convert.ToString(count.CountCosecha + 1);

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_cosechas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ShowCosechaGrid();
        }

        private void dtgv_cosechas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_cosechas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_cosechas.BorderStyle = BorderStyle.None;

            //configuracion de la fila de encabezado en el datagrid
            Font customFonten = new Font("Oswald", 9f, FontStyle.Bold);
            dtg_cosechas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(184, 89, 89);
            dtg_cosechas.ColumnHeadersDefaultCellStyle.Font = customFonten;
            dtg_cosechas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtg_cosechas.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 89, 89);
            dtg_cosechas.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dtg_cosechas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //configuracion de las filas por defecto en el datagrid
            Font customFontdef = new Font("Oswald Light", 10.2f, FontStyle.Regular);

            dtg_cosechas.DefaultCellStyle.BackColor = Color.White;
            dtg_cosechas.DefaultCellStyle.Font = customFontdef;
            dtg_cosechas.DefaultCellStyle.ForeColor = Color.Black;
            dtg_cosechas.DefaultCellStyle.SelectionBackColor = Color.White;
            dtg_cosechas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dtg_cosechas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //configuracion de las filas que son seleccionadas
            dtg_cosechas.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 199, 199);
            dtg_cosechas.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        public void ShowCosechaGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            var cosechaController = new CosechaController();
            List<Cosecha> datos = cosechaController.ObtenerCosecha();

            var datosPersonalizados = datos.Select(cos => new
            {
                ID = cos.IdCosecha,
                Nombre = cos.NombreCosecha
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_cosechas.DataSource = datosPersonalizados;
            
            // Evitar que el usuario ajuste el tamaño de las filas y columnas manualmente
            dtg_cosechas.AllowUserToResizeRows = false;
            dtg_cosechas.AllowUserToResizeColumns = false;

            dtg_cosechas.RowHeadersVisible = false;
            dtg_cosechas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> { txb_id, txb_nombre };

            foreach (TextBox textBox in txb)
            {
                textBox.Text = "";
            }

            //coloca nueva mente el contador en el txb del cdigo
            CosechaController cosec = new CosechaController();
            var count = cosec.CountCosecha();
            txb_id.Text = Convert.ToString(count.CountCosecha + 1);

            cosechaSeleccionado = null;
        }

        private void dtg_cosechas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila correspondiente a la celda en la que se hizo doble clic
            DataGridViewRow filaSeleccionada = dtg_cosechas.Rows[e.RowIndex];
            cosechaSeleccionado = new Cosecha();

            // Obtener los valores de las celdas de la fila seleccionada
            cosechaSeleccionado.IdCosecha = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
            cosechaSeleccionado.NombreCosecha = filaSeleccionada.Cells["Nombre"].Value.ToString();
        }

        private void btn_mod_cosecha_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas actualizar el registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // El usuario seleccionó "Sí"
                imagenClickeada = true;

                // Asignar los valores a los cuadros de texto solo si no se ha hecho clic en la imagen
                txb_id.Text = Convert.ToString(cosechaSeleccionado.IdCosecha);
                txb_nombre.Text = cosechaSeleccionado.NombreCosecha;

            }
            else
            {
                // El usuario seleccionó "No" o cerró el cuadro de diálogo
            }
        }

        private void btn_delete_cosecha_Click(object sender, EventArgs e)
        {
            //condicion para verificar si los datos seleccionados van nulos, para evitar error
            if (cosechaSeleccionado != null)
            {
                LogController log = new LogController();
                UserController userControl = new UserController();
                Usuario usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar los datos registrado de la Cosecha: (" + cosechaSeleccionado.NombreCosecha + ") ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //se llama la funcion delete del controlador para eliminar el registro
                    CosechaController controller = new CosechaController();
                    controller.EliminarCosecha(cosechaSeleccionado.IdCosecha);

                    //verificar el departamento del log
                    log.RegistrarLog(usuario.IdUsuario, "Eliminacion de los datos Cosecha", ModuloActual.NombreModulo, "Eliminacion", "Elimino los datos de la Cosecha (" + cosechaSeleccionado.NombreCosecha + ") en la base de datos");

                    MessageBox.Show("Cosecha Eliminada correctamente.", "Eliminacion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //se actualiza la tabla
                    ShowCosechaGrid();
                    cosechaSeleccionado = null;
                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente las caracteristicas de la Procedencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //coloca nueva mente el contador en el txb del cdigo
            CosechaController cosec = new CosechaController();
            var count = cosec.CountCosecha();
            txb_id.Text = Convert.ToString(count.CountCosecha + 1);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_nombre.Text))
            {
                MessageBox.Show("El campo Nombre, esta vacio y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CosechaController cosController = new CosechaController();
            LogController log = new LogController();
            var userControl = new UserController();
            var usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario

            try
            {
                string name = txb_nombre.Text;

                // Crear una instancia de la clase Beneficio con los valores obtenidos
                Cosecha cosecha = new Cosecha()
                {
                    IdCosecha = Convert.ToInt32(txb_id.Text),
                    NombreCosecha = name
                };

                if (!imagenClickeada)
                {
                    // Código que se ejecutará si no se ha hecho clic en la imagen update
                    // Llamar al controlador para insertar la Procedencia en la base de datos
                    bool exito = cosController.InsertarCosecha(cosecha);

                    if (!exito)
                    {
                        MessageBox.Show("Error al agregar la Cosecha. Verifica los datos e intenta nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Cosecha agregado correctamente.", "Insercion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        //verificar el departamento
                        log.RegistrarLog(usuario.IdUsuario, "Registro de caracteristicas de la Cosecha", ModuloActual.NombreModulo, "Insercion", "Inserto una nueva Cosecha a la base de datos");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos en el dataGrid
                    ShowCosechaGrid();

                    //borrar datos de los textbox
                    ClearDataTxb();
                }
                else
                {
                    // Código que se ejecutará si se ha hecho clic en la imagen update
                    bool exito = cosController.ActualizarCosecha(Convert.ToInt32(txb_id.Text), name);

                    if (!exito)
                    {
                        MessageBox.Show("Error al actualizar los datos de la Cosecha. Verifica los datos e intenta nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Cosecha actualizada correctamente.", "Actualizacion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        //verificar el departamento 
                        log.RegistrarLog(usuario.IdUsuario, "Actualizacion del dato Cosecha", ModuloActual.NombreModulo, "Actualizacion", "Actualizo las caracteristicas de la Cosecha con ID " + cosechaSeleccionado.IdCosecha + " en la base de datos");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos en el dataGrid
                    ShowCosechaGrid();

                    ClearDataTxb();

                    imagenClickeada = false;
                    cosechaSeleccionado = null;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message);
                MessageBox.Show("Error de tipo (" + ex.Message + "), verifique los datos he intenta nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //coloca nueva mente el contador en el txb del cdigo
            CosechaController cosec = new CosechaController();
            var count = cosec.CountCosecha();
            txb_id.Text = Convert.ToString(count.CountCosecha + 1);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
            imagenClickeada = false;

            //coloca nueva mente el contador en el txb del cdigo
            CosechaController cosec = new CosechaController();
            var count = cosec.CountCosecha();
            txb_id.Text = Convert.ToString(count.CountCosecha + 1);
            this.Close();
        }
    }
}
