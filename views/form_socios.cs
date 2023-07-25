using sistema_modular_cafe_majada.controller;
using sistema_modular_cafe_majada.controller.HarvestController;
using sistema_modular_cafe_majada.controller.ProductController;
using sistema_modular_cafe_majada.controller.SecurityData;
using sistema_modular_cafe_majada.controller.UserDataController;
using sistema_modular_cafe_majada.model.Acces;
using sistema_modular_cafe_majada.model.Mapping;
using sistema_modular_cafe_majada.model.Mapping.Harvest;
using sistema_modular_cafe_majada.model.Mapping.Product;
using sistema_modular_cafe_majada.model.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_modular_cafe_majada.views
{
    public partial class form_socios : Form
    {
        //variable global para verificar el estado del boton actualizar
        private bool imagenClickeada = false;
        //instancia de la clase mapeo Lote para capturar los datos seleccionado por el usuario
        private Lote loteSeleccionado;
        
        form_opcLote form_Opc;

        public form_socios()
        {
            InitializeComponent();

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_lotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ShowLoteGrid();

            dtg_lotes.CellPainting += dtgv_lote_CellPainting;

            //restringir los txb para que no se puedan editar
            //txb_cosecha.ReadOnly = true;
            //txb_calidadCafe.ReadOnly = true;
            txb_nomFinca.ReadOnly = true;
            //txb_tipoCafe.ReadOnly = true;
            //txb_cosecha.Enabled = false;
            txb_nomFinca.Enabled = false;
            //txb_calidadCafe.Enabled = false;
            //txb_tipoCafe.Enabled = false;

            //funcion que restringe el uso de caracteres en los textbox necesarios
            List<TextBox> textBoxListN = new List<TextBox> { txb_cantidad };

            //funcion para restringir cual quier caracter y solo acepta unicamente num
            RestrictTextBoxNum(textBoxListN);
        }

        private void dtgv_lote_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        public void ShowLoteGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            var loteController = new LoteController();
            List<Lote> datos = loteController.ObtenerLotesNombreID();

            var datosPersonalizados = datos.Select(lote => new
            {
                ID = lote.IdLote,
                Nombre = lote.NombreLote,
                Cantidad = lote.CantidadLote,
                Fecha = lote.FechaLote,
                Tipo_Cafe = lote.TipoCafe,
                Nombre_Calidad = lote.NombreCalidadLote,
                Nombre_Cosecha = lote.NombreCosechaLote,
                Nombre_Finca = lote.NombreFinca
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_lotes.DataSource = datosPersonalizados;

            dtg_lotes.RowHeadersVisible = false;
            dtg_lotes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> { txb_numLote, txb_nomFinca, txb_cantidad/*, txb_tipoCafe, txb_cosecha, txb_calidadCafe,*/  };

            foreach (TextBox textBox in txb)
            {
                textBox.Text = "";
            }

            //dtp_fecha.Value = DateTime.Now;

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

        private void btn_updateLote_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas actualizar el registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // El usuario seleccionó "Sí"
                imagenClickeada = true;

                // Asignar los valores a los cuadros de texto solo si no se ha hecho clic en la imagen
                txb_numLote.Text = loteSeleccionado.NombreLote;
                txb_nomFinca.Text = loteSeleccionado.NombreFinca;
                //txb_calidadCafe.Text = loteSeleccionado.NombreCalidadLote;
                txb_cantidad.Text = loteSeleccionado.CantidadLote.ToString("0.00");
                //txb_cosecha.Text = loteSeleccionado.NombreCosechaLote;
                //dtp_fecha.Value = loteSeleccionado.FechaLote;
                //txb_tipoCafe.Text = loteSeleccionado.TipoCafe;
            }
            else
            {
                // El usuario seleccionó "No" o cerró el cuadro de diálogo
            }
        }

        private void btn_deleteLote_Click(object sender, EventArgs e)
        {
            //condicion para verificar si los datos seleccionados van nulos, para evitar error
            if (loteSeleccionado != null)
            {
                LogController log = new LogController();
                UserController userControl = new UserController();
                Usuario usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar los datos registrado del Lote: (" + loteSeleccionado.NombreLote + ") ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //se llama la funcion delete del controlador para eliminar el registro
                    LoteController controller = new LoteController();
                    controller.EliminarLote(loteSeleccionado.IdLote);

                    //verificar el departamento del log
                    log.RegistrarLog(usuario.IdUsuario, "Eliminado los datos Lote", ModuloActual.NombreModulo, "Eliminacion", "Elimino los datos del Lote (" + loteSeleccionado.NombreLote + ") en la base de datos");

                    MessageBox.Show("Lote Eliminado correctamente.", "Eliminacion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //se actualiza la tabla
                    ShowLoteGrid();
                    loteSeleccionado = null;
                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente las caracteristicas del Lote", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
        }

        private void btn_tFinca_Click(object sender, EventArgs e)
        {
            TablaSeleccionada.ITable = 1;
            form_Opc = new form_opcLote();

            if (form_Opc.ShowDialog() == DialogResult.OK)
            {
                txb_nomFinca.Text = FincaSeleccionada.NombreFincaSeleccionada;
            }
        }

        private void btn_tCafe_Click(object sender, EventArgs e)
        {
            TablaSeleccionada.ITable = 2;
            form_Opc = new form_opcLote();

            if (form_Opc.ShowDialog() == DialogResult.OK)
            {
                //txb_tipoCafe.Text = TipoCafeSeleccionado.NombreTipoCafeSeleccionado;
            }
        }

        private void btn_tcCafe_Click(object sender, EventArgs e)
        {
            TablaSeleccionada.ITable = 3;
            form_Opc = new form_opcLote();

            if (form_Opc.ShowDialog() == DialogResult.OK)
            {
                //txb_calidadCafe.Text = CalidadSeleccionada.NombreCalidadSeleccionada;
            }
        }

        private void btn_tCosecha_Click(object sender, EventArgs e)
        {
            TablaSeleccionada.ITable = 4;
            form_Opc = new form_opcLote();

            if (form_Opc.ShowDialog() == DialogResult.OK)
            {
                //txb_cosecha.Text = CosechaSeleccionada.NombreCosechaSeleccionada;
            }
        }

        //
        public void RestrictTextBoxNum(List<TextBox> textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.KeyPress += (sender, e) =>
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    {
                        e.Handled = true; // Cancela el evento KeyPress si no es un dígito, un punto o una tecla de control
                    }

                    // Permitir solo un punto decimal
                    if (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1)
                    {
                        e.Handled = true;
                    }
                };
            }
        }

        private void dtg_lotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila correspondiente a la celda en la que se hizo doble clic
            DataGridViewRow filaSeleccionada = dtg_lotes.Rows[e.RowIndex];
            loteSeleccionado = new Lote();

            // Obtener los valores de las celdas de la fila seleccionada
            loteSeleccionado.IdLote = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
            loteSeleccionado.NombreLote = filaSeleccionada.Cells["Nombre"].Value.ToString();
            loteSeleccionado.CantidadLote = Convert.ToDouble(filaSeleccionada.Cells["Cantidad"].Value);
            loteSeleccionado.FechaLote = Convert.ToDateTime(filaSeleccionada.Cells["Fecha"].Value);
            loteSeleccionado.TipoCafe = filaSeleccionada.Cells["Tipo_Cafe"].Value.ToString();
            loteSeleccionado.NombreCalidadLote = filaSeleccionada.Cells["Nombre_Calidad"].Value.ToString();
            loteSeleccionado.NombreCosechaLote = filaSeleccionada.Cells["Nombre_Cosecha"].Value.ToString();
            loteSeleccionado.NombreFinca = filaSeleccionada.Cells["Nombre_Finca"].Value.ToString();
        }

        private void btn_SaveLote_Click(object sender, EventArgs e)
        {
            LoteController loteController = new LoteController();
            LogController log = new LogController();
            var userControl = new UserController();
            var usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario

            TextBox[] textBoxes = { txb_numLote };
            ConvertFirstCharacter(textBoxes);

            try
            {
                double cantidad;
                if (double.TryParse(txb_cantidad.Text, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out cantidad))
                {
                    // El parseo se realizó con éxito, el valor de cantidad contiene el número parseado
                    // Realiza las operaciones que necesites con la variable cantidad
                }

                string nameLote = txb_numLote.Text;
                //DateTime fecha = dtp_fecha.Value;
                //string calidad = txb_calidadCafe.Text;
                //string cosecha = txb_cosecha.Text;
                string finca = txb_nomFinca.Text;
                //string tipoCafe = txb_tipoCafe.Text;


                // Crear una instancia de la clase Lote con los valores obtenidos
                Lote loteInsert = new Lote()
                {
                    NombreLote = nameLote,
                    CantidadLote = cantidad,
                    IdCalidadLote = CalidadSeleccionada.ICalidadSeleccionada,
                    IdCosechaLote = CosechaSeleccionada.ICosechaSeleccionada,
                    IdFinca = FincaSeleccionada.IFincaSeleccionada,
                    IdTipoCafe = TipoCafeSeleccionado.ITipoCafeSeleccionado
                };

                if (!imagenClickeada)
                {
                    // Código que se ejecutará si no se ha hecho clic en la imagen update
                    // Llamar al controlador para insertar el Lote en la base de datos
                    bool exito = loteController.InsertarLote(loteInsert);

                    if (!exito)
                    {
                        MessageBox.Show("Error al agregar el Lote. Verifica los datos e intenta nuevamente.");
                        return;
                    }

                    MessageBox.Show("Lote agregado correctamente.", "Insercion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        //Console.WriteLine("el ID obtenido del usuario "+usuario.IdUsuario);
                        //verificar el departamento
                        log.RegistrarLog(usuario.IdUsuario, "Registro de caracteristicas del Lote", ModuloActual.NombreModulo, "Insercion", "Inserto un nuevo Lote a la base de datos");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos en el dataGrid
                    ShowLoteGrid();

                    //borrar datos de los textbox
                    ClearDataTxb();
                }
                /*else
                {
                    var cosechaC = new CosechaController();
                    var calidadC = new CCafeController();
                    var tipoC = new TipoCafeController();
                    FincaController fincaC = new FincaController();
                    
                    Cosecha cos = new Cosecha();
                    Finca fin = new Finca();
                    TipoCafe tip = new TipoCafe();
                    CalidadCafe cali = new CalidadCafe();

                    //cos = cosechaC.ObtenerNombreCosecha(cosecha);
                    fin = fincaC.ObtenerNombreFincas(finca);
                    //cali = calidadC.ObtenerNombreCalidad(calidad);
                    //tip = tipoC.ObtenerTipoCafeNombre(tipoCafe);

                    // Código que se ejecutará si se ha hecho clic en la imagen update
                    bool exito= loteController.ActualizarLote(loteSeleccionado.IdLote, nameLote, cantidad, fecha, cos.IdCosecha, 
                                                   fin.IdFinca, cali.IdCalidad ,tip.IdTipoCafe);
                    
                    if (!exito)
                    {
                        MessageBox.Show("Error al actualizar los datos del Lote. Verifica los datos e intenta nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Lote actualizado correctamente.", "Actualizacion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        //verificar el departamento 
                        log.RegistrarLog(usuario.IdUsuario, "Actualizacion del dato Lote", ModuloActual.NombreModulo, "Actualizacion", "Actualizo las caracteristicas del Lote con ID " + loteSeleccionado.IdLote + " en la base de datos");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                    }

                    //funcion para actualizar los datos en el dataGrid
                    ShowLoteGrid();

                    ClearDataTxb();

                    imagenClickeada = false;
                    loteSeleccionado = null;

                }*/
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message);
                MessageBox.Show("Error de tipo (" + ex.Message + "), verifique los datos he intenta nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
