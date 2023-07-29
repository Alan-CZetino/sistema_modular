using sistema_modular_cafe_majada.controller.InfrastructureController;
using sistema_modular_cafe_majada.controller.OperationsController;
using sistema_modular_cafe_majada.controller.SecurityData;
using sistema_modular_cafe_majada.controller.UserDataController;
using sistema_modular_cafe_majada.model.Acces;
using sistema_modular_cafe_majada.model.Mapping;
using sistema_modular_cafe_majada.model.Mapping.Harvest;
using sistema_modular_cafe_majada.model.Mapping.Infrastructure;
using sistema_modular_cafe_majada.model.Mapping.Operations;
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
using System.Timers;
using System.Windows.Forms;

namespace sistema_modular_cafe_majada.views
{
    public partial class form_subPartidas : Form
    {
        private List<TextBox> txbRestrict;
        private bool imagenClickeada = false;
        private bool imgClickAlmacen = false;
        private bool imgClickBodega = false;
        SubPartidaController countSP = null;

        //variable para refrescar el formulario cad cierto tiempo
        private System.Timers.Timer refreshTimer;

        private SubPartida subptdaSeleccionado;
        private int ibenef;

        private int iProcedencia;
        private int icosechaCambio;
        private int isubProducto;
        private int iCatador;
        private int iPesador;
        private int iSecador;
        private int iBodega;
        private int iAlmacen;
        private int iCalidad;
        private int iSubPartida;

        public form_subPartidas()
        {
            InitializeComponent();

            // Configurar el temporizador para que se dispare cada cierto intervalo (por ejemplo, cada 5 segundos).
            refreshTimer = new System.Timers.Timer();
            refreshTimer.Interval = 5000; // Intervalo en milisegundos (5 segundos en este caso).
            refreshTimer.Elapsed += RefreshTimer_Elapsed;
            refreshTimer.Start();

            txbRestrict = new List<TextBox> { txb_pdasSemana1, txb_pdasSemana2, txb_pdasSemana3, txb_diasPdas1, txb_diasPdas2, txb_diasPdas3,
                                                txb_humedad, txb_rendimiento, txb_cantidadQQs, txb_CantidadSaco };

            RestrictTextBoxNum(txbRestrict);

            CbxSubProducto();

            countSP = new SubPartidaController();
            var subSPa = countSP.CountSubPartida(CosechaActual.ICosechaActual);
            //
            txb_subPartida.Text = Convert.ToInt32(subSPa.CountSubPartida + 1 ).ToString();
            txb_nombreCatador.Enabled = false;
            txb_nombreCatador.ReadOnly = true;
            txb_nombrePesador.Enabled = false;
            txb_nombrePesador.ReadOnly = true;
            txb_nombrePuntero.Enabled = false;
            txb_nombrePuntero.ReadOnly = true;
            txb_cosecha.Enabled = false;
            txb_cosecha.ReadOnly = true;
            txb_cosecha.Text = CosechaActual.NombreCosechaActual;
            txb_horaInicio.Text = "00:00:00";
            txb_horaSalida.Text = "00:00:00";
            txb_tiempoSecad.Text = "00:00:00";
            txb_procedencia.Enabled = false;
            txb_procedencia.ReadOnly = true;
            txb_calidad.Enabled = false;
            txb_calidad.ReadOnly = true;
            txb_ubicadoBodega.Enabled = false;
            txb_ubicadoBodega.ReadOnly = true;
            txb_almacenSiloPiña.Enabled = false;
            txb_almacenSiloPiña.ReadOnly = true;
        }

        //
        private void RefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Utilizar Invoke para actualizar los controles de la interfaz de usuario desde el hilo del temporizador.
            if (!this.IsDisposed && this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    // Aquí se puede escribir la lógica para refrescar el formulario, actualizar los datos.
                    // Por ejemplo, si queremos actualizar datos desde una base de datos o un servicio, lo haríamos aquí.
                    if (!this.IsDisposed)
                    {
                        // Llamamos a la función ConvertTimeTxb y almacenamos el resultado formateado en la variable "miVariableTime".
                        string miVariableTime = ConvertILimitTimeTxb(txb_tiempoSecad);

                        Console.WriteLine("Resultado formateado: " + miVariableTime); // Esto imprimirá "Resultado formateado: 02:30:00"

                        // Llamamos a la función ConvertTimeTxb y almacenamos el resultado formateado en la variable "miVariableTime".
                        try
                        {
                            string miVariableTime1 = ConvertTimeLimitTxb(txb_horaInicio);
                            DateTime fechaInicioSecado = dtp_fechaInicioSecad.Value.Date + TimeSpan.Parse(miVariableTime1);
                            Console.WriteLine("Resultado formateado: " + fechaInicioSecado);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (icosechaCambio != CosechaActual.ICosechaActual)
                        {
                            countSP = new SubPartidaController();
                            var subSPa = countSP.CountSubPartida(CosechaActual.ICosechaActual);
                            //
                            txb_subPartida.Text = Convert.ToInt32(subSPa.CountSubPartida + 1 ).ToString();
                            icosechaCambio = CosechaActual.ICosechaActual;
                        }
                        txb_cosecha.Text = CosechaActual.NombreCosechaActual;
                    }
                }));
            }
        }

        //
        public void CbxSubProducto()
        {
            SubProductoController subPro = new SubProductoController();
            List<SubProducto> datoSubPro = subPro.ObtenerSubProductos();

            cbx_subProducto.Items.Clear();

            // Asignar los valores numéricos a los elementos del ComboBox
            foreach (SubProducto subP in datoSubPro)
            {
                int idSubP = subP.IdSubProducto;
                string nombreSubP = subP.NombreSubProducto;

                cbx_subProducto.Items.Add(new KeyValuePair<int, string>(idSubP, nombreSubP));
            }
        }

        //
        public static string ConvertTimeLimitTxb(TextBox textTime)
        {
            string horaCompleta = textTime.Text;

            // Dividir la cadena en partes utilizando el carácter ':'
            string[] partesHora = horaCompleta.Split(':');

            try
            {
                // Convertir a horas, minutos y segundos
                if (partesHora.Length == 1 && int.TryParse(partesHora[0], out int horas))
                {
                    // Si hay solo una parte y se pudo convertir a entero, asumimos que es el número de horas.

                    // Ajuste para las horas en formato de 24 horas
                    // Si el formato no es de 12 horas, verificamos que el valor esté dentro del rango de 0 a 24.
                    if (horas < 0 || horas > 24)
                    {
                        throw new FormatException("El valor ingresado está fuera del rango de horas válido (0 a 24).");
                    }

                    // Ajuste para las horas: Si la parte de las horas tiene un solo dígito y es menor a 10, se añade un cero a la izquierda.
                    horaCompleta = horas < 10 ? "0" + horas : horas.ToString();

                    // Añadimos los minutos y segundos con valor 00.
                    horaCompleta += ":00:00";
                
                }
                else if (partesHora.Length == 2 && int.TryParse(partesHora[0], out int horas2) && int.TryParse(partesHora[1], out int minutos))
                {
                    // Si hay dos partes y ambas se pudieron convertir a enteros, asumimos que es el número de horas y minutos.

                    // Ajuste para las horas: Si la parte de las horas tiene un solo dígito y es menor a 10, se añade un cero a la izquierda.
                    horaCompleta = horas2 < 10 ? "0" + horas2 : horas2.ToString();

                    // Ajuste para los minutos: Si la parte de los minutos tiene un solo dígito y es menor a 10, se añade un cero a la izquierda.
                    horaCompleta += ":" + (minutos < 10 ? "0" + minutos : minutos.ToString());

                    // Añadimos los segundos con valor 00.
                    horaCompleta += ":00";
                }
                else if (partesHora.Length == 3 && int.TryParse(partesHora[0], out int horas3) && int.TryParse(partesHora[1], out int minutos3) && int.TryParse(partesHora[2], out int segundos))
                {
                    // Si hay tres partes y todas se pudieron convertir a enteros, asumimos que es el número de horas, minutos y segundos.

                    // Ajuste para las horas: Si la parte de las horas tiene un solo dígito y es menor a 10, se añade un cero a la izquierda.
                    horaCompleta = horas3 < 10 ? "0" + horas3 : horas3.ToString();

                    // Ajuste para los minutos: Si la parte de los minutos tiene un solo dígito y es menor a 10, se añade un cero a la izquierda.
                    horaCompleta += ":" + (minutos3 < 10 ? "0" + minutos3 : minutos3.ToString());

                    // Ajuste para los segundos: Si la parte de los segundos tiene un solo dígito y es menor a 10, se añade un cero a la izquierda.
                    horaCompleta += ":" + (segundos < 10 ? "0" + segundos : segundos.ToString());
                }
                else
                {
                    // Si no se cumple ninguna de las condiciones, el formato ingresado no es válido.
                    Console.WriteLine("Formato de hora no válido.");
                    return string.Empty;
                }


                // Devolvemos el resultado formateado.
                return horaCompleta;
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                // Lanzamos una excepción personalizada con el mensaje de error.
                throw new FormatException("El valor ingresado en el campo Inicio Secado o Salida Secado está fuera del rango de horas válido (0 a 24).", ex);
                
            }

        }

        //
        public static string ConvertILimitTimeTxb(TextBox textTime)
        {
            string horaCompleta = textTime.Text;

            // Dividir la cadena en partes utilizando el carácter ':'
            string[] partesHora = horaCompleta.Split(':');

            if (partesHora.Length == 1 && int.TryParse(partesHora[0], out int horas))
            {
                // Si hay solo una parte y se pudo convertir a entero, asumimos que es el número de horas.

                // Ajuste para las horas: Si la parte de las horas tiene un solo dígito y es menor a 10, se añade un cero a la izquierda.
                horaCompleta = horas < 10 ? "0" + horas : horas.ToString();

                // Añadimos los minutos y segundos con valor 00.
                horaCompleta += ":00:00";
            }
            else if (partesHora.Length == 2 && int.TryParse(partesHora[0], out int horas2) && int.TryParse(partesHora[1], out int minutos))
            {
                // Si hay dos partes y ambas se pudieron convertir a enteros, asumimos que es el número de horas y minutos.

                // Ajuste para las horas: Si la parte de las horas tiene un solo dígito y es menor a 10, se añade un cero a la izquierda.
                horaCompleta = horas2 < 10 ? "0" + horas2 : horas2.ToString();

                // Ajuste para los minutos: Si la parte de los minutos tiene un solo dígito y es menor a 10, se añade un cero a la izquierda.
                horaCompleta += ":" + (minutos < 10 ? "0" + minutos : minutos.ToString());

                // Añadimos los segundos con valor 00.
                horaCompleta += ":00";
            }
            else if (partesHora.Length == 3 && int.TryParse(partesHora[0], out int horas3) && int.TryParse(partesHora[1], out int minutos3) && int.TryParse(partesHora[2], out int segundos))
            {
                // Si hay tres partes y todas se pudieron convertir a enteros, asumimos que es el número de horas, minutos y segundos.

                // Ajuste para las horas: Si la parte de las horas tiene un solo dígito y es menor a 10, se añade un cero a la izquierda.
                horaCompleta = horas3 < 10 ? "0" + horas3 : horas3.ToString();

                // Ajuste para los minutos: Si la parte de los minutos tiene un solo dígito y es menor a 10, se añade un cero a la izquierda.
                horaCompleta += ":" + (minutos3 < 10 ? "0" + minutos3 : minutos3.ToString());

                // Ajuste para los segundos: Si la parte de los segundos tiene un solo dígito y es menor a 10, se añade un cero a la izquierda.
                horaCompleta += ":" + (segundos < 10 ? "0" + segundos : segundos.ToString());
            }
            else
            {
                // Si no se cumple ninguna de las condiciones, el formato ingresado no es válido.
                Console.WriteLine("Formato de hora no válido.");
                return string.Empty; // O puedes lanzar una excepción si es necesario.
            }

            // Devolvemos el resultado formateado.
            return horaCompleta;
        }

        //
        public void RestrictTextBoxNum(List<TextBox> textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.KeyPress += (sender, e) =>
                {
                    char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator && e.KeyChar != '.')
                    {
                        e.Handled = true; // Cancela el evento KeyPress si no es un dígito, el punto o la coma
                    }

                    // Permite solo un punto o una coma en el TextBox
                    if ((e.KeyChar == decimalSeparator || e.KeyChar == '.') && (textBox.Text.Contains(decimalSeparator.ToString()) || textBox.Text.Contains('.')))
                    {
                        e.Handled = true; // Cancela el evento KeyPress si ya hay un punto o una coma en el TextBox
                    }
                };
            }
        }

        private void btn_sPartida_Click(object sender, EventArgs e)
        {
            imagenClickeada = true;
            TablaSeleccionadasubPartd.ITable = 1;
            var subPC = new SubPartidaController();
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            if (form_OpcSub.ShowDialog() == DialogResult.OK)
            {
                SubProductoController subProC = new SubProductoController();
                var sub = subPC.ObtenerSubPartidaPorID(SubPartidaSeleccionado.ISubPartida);
                var name = subProC.ObtenerSubProductoPorNombre(sub.NombreSubProducto);
                isubProducto = name.IdSubProducto;

                //cbx
                cbx_subProducto.Items.Clear();
                CbxSubProducto();

                int isP = name.IdSubProducto - 1;
                
                // Obtener la fecha y la hora por separado
                DateTime fechaInicio = sub.InicioSecado.Date;
                TimeSpan horaInicio = sub.InicioSecado.TimeOfDay;
                DateTime fechaSalida = sub.SalidaSecado.Date;
                TimeSpan horaSalida = sub.SalidaSecado.TimeOfDay;

                iSubPartida = SubPartidaSeleccionado.ISubPartida;
                txb_subPartida.Text = SubPartidaSeleccionado.NombreSubParti;
                txb_procedencia.Text = sub.NombreProcedencia;
                iProcedencia = sub.IdProcedencia ?? 0;
                txb_calidad.Text = sub.NombreCalidadCafe;
                iCalidad = sub.IdCalidadCafe ?? 0;
                cbx_subProducto.SelectedIndex = isP;
                txb_pdasSemana1.Text = Convert.ToString(sub.Num1Semana);
                txb_pdasSemana2.Text = Convert.ToString(sub.Num2Semana);
                txb_pdasSemana3.Text = Convert.ToString(sub.Num3Semana);
                txb_diasPdas1.Text = Convert.ToString(sub.Dias1SubPartida);
                txb_diasPdas2.Text = Convert.ToString(sub.Dias2SubPartida);
                txb_diasPdas3.Text = Convert.ToString(sub.Dias3SubPartida);
                txb_fechaPartd1.Text = sub.Fecha1SubPartida;
                txb_fechaPartd2.Text = sub.Fecha2SubPartida;
                txb_fechaPartd3.Text = sub.Fecha3SubPartida;
                txb_observacionCafe.Text = sub.ObservacionIdentificacionCafe;
                dtp_fechaSecado.Value = sub.FechaSecado;
                dtp_fechaInicioSecad.Value = fechaInicio;
                dtp_fechaSalidaSecad.Value = fechaSalida;
                txb_horaInicio.Text = Convert.ToString(horaInicio);
                txb_horaSalida.Text = Convert.ToString(horaSalida);
                txb_tiempoSecad.Text = Convert.ToString(sub.TiempoSecado);
                txb_humedad.Text = Convert.ToString(sub.HumedadSecado);
                txb_rendimiento.Text = Convert.ToString(sub.Rendimiento);
                txb_nombrePuntero.Text = sub.NombrePunteroSecador;
                iSecador = sub.IdPunteroSecador ?? 0;
                txb_observacionSecad.Text = sub.ObservacionSecado;
                txb_resultadoCatacion.Text = sub.ResultadoCatador;
                dtp_fechaCatacion.Value = sub.FechaCatacion;
                txb_nombreCatador.Text = sub.NombreCatador;
                iCatador = sub.IdCatador ?? 0;
                txb_observacionCatador.Text = sub.ObservacionCatador;
                dtp_fechaPesa.Value = sub.FechaPesado;
                txb_CantidadSaco.Text = Convert.ToString(sub.PesaSaco);
                txb_cantidadQQs.Text = Convert.ToString(sub.PesaQQs);
                txb_ubicadoBodega.Text = sub.NombreBodega;
                iBodega = sub.IdBodega ?? 0;
                txb_almacenSiloPiña.Text = sub.NombreAlmacen;
                iAlmacen = sub.IdAlmacen ?? 0;
                txb_nombrePesador.Text = sub.NombrePunteroPesador;
                iPesador = sub.IdPesador ?? 0;
                txb_doctoAlmacen.Text = sub.DoctoAlmacen;
                txb_observacionPesa.Text = sub.ObservacionPesador;

            }
        }

        private void btn_prodCafe_Click(object sender, EventArgs e)
        {
            TablaSeleccionadasubPartd.ITable = 2;
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            if (form_OpcSub.ShowDialog() == DialogResult.OK)
            {
                iProcedencia = ProcedenciaSeleccionada.IProcedencia;
                txb_procedencia.Text = ProcedenciaSeleccionada.NombreProcedencia;
            }
        }

        private void btn_CCafe_Click(object sender, EventArgs e)
        {
            TablaSeleccionadasubPartd.ITable = 3;
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            if (form_OpcSub.ShowDialog() == DialogResult.OK)
            {
                iCalidad = CalidadSeleccionada.ICalidadSeleccionada;
                txb_calidad.Text = CalidadSeleccionada.NombreCalidadSeleccionada;
            }
        }

        private void btn_puntero_Click(object sender, EventArgs e)
        {
            TablaSeleccionadasubPartd.ITable = 4;
            PersonalSeleccionado.TipoPersonal = "eca";
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            if (form_OpcSub.ShowDialog() == DialogResult.OK)
            {
                iSecador = PersonalSeleccionado.IPersonalPuntero;
                txb_nombrePuntero.Text = PersonalSeleccionado.NombrePersonalPuntero;
            }
        }

        private void btn_catador_Click(object sender, EventArgs e)
        {
            TablaSeleccionadasubPartd.ITable = 5;
            PersonalSeleccionado.TipoPersonal = "ata";
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            if (form_OpcSub.ShowDialog() == DialogResult.OK)
            {
                iCatador = PersonalSeleccionado.IPersonalCatador;
                txb_nombreCatador.Text = PersonalSeleccionado.NombrePersonalCatador;
            }
        }

        private void btn_ubicacionCafe_Click(object sender, EventArgs e)
        {
            TablaSeleccionadasubPartd.ITable = 6;
            imgClickBodega = true;
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            if (form_OpcSub.ShowDialog() == DialogResult.OK)
            {
                iBodega = BodegaSeleccionada.IdBodega;
                
                if(iBodega != AlmacenBodegaClick.IBodega)
                {
                    imgClickAlmacen = false;
                }
                if (!imgClickAlmacen)
                {
                    AlmacenBodegaClick.IBodega = iBodega;
                }

                txb_ubicadoBodega.Text = BodegaSeleccionada.NombreBodega;
            }
        }
        
        private void btn_ubiFisicaCafe_Click(object sender, EventArgs e)
        {
            TablaSeleccionadasubPartd.ITable = 7;
            imgClickAlmacen = true;
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            if (form_OpcSub.ShowDialog() == DialogResult.OK)
            {
                if (!imgClickBodega)
                {
                    // Llamar al método para obtener los datos de la base de datos
                    AlmacenController almacenController = new AlmacenController();
                    Almacen datoA = almacenController.ObtenerIdAlmacen(AlmacenSeleccionado.IAlmacen);
                    BodegaController bodegaController = new BodegaController();
                    Bodega datoB = bodegaController.ObtenerIdBodega(datoA.IdBodegaUbicacion);

                    txb_ubicadoBodega.Text = datoB.NombreBodega;
                    iBodega = datoB.IdBodega;
                    imgClickBodega = false;
                }
                iAlmacen = AlmacenSeleccionado.IAlmacen;
                txb_almacenSiloPiña.Text = AlmacenSeleccionado.NombreAlmacen;
            }
        }

        private void btn_pesador_Click(object sender, EventArgs e)
        {
            TablaSeleccionadasubPartd.ITable = 8;
            PersonalSeleccionado.TipoPersonal = "esa";
            form_opcSubPartida form_OpcSub = new form_opcSubPartida();
            if (form_OpcSub.ShowDialog() == DialogResult.OK)
            {
                iPesador = PersonalSeleccionado.IPersonalPesador;
                txb_nombrePesador.Text = PersonalSeleccionado.NombrePersonalPesador;
            }
        }

        public void SaveSubPartida() 
        {
            bool verific = VerificarCamposObligatorios();
            if(verific == true)
            {
                // Obtener los valores de los controles (txb, dtp, cbx)
                int subPartida = Convert.ToInt32(txb_subPartida.Text);
                string procedenciaNombre = txb_procedencia.Text;
                string calidadNombre = txb_calidad.Text;
                
                // Obtener el valor numérico seleccionado
                KeyValuePair<int, string> selectedStatus = new KeyValuePair<int, string>();
                if (cbx_subProducto.SelectedItem is KeyValuePair<int, string> keyValue)
                {
                    selectedStatus = keyValue;
                }
                else if (cbx_subProducto.SelectedItem != null)
                {
                    selectedStatus = (KeyValuePair<int, string>)cbx_subProducto.SelectedItem;
                }

                int selectedValue = selectedStatus.Key;

                int? num1Semana = string.IsNullOrWhiteSpace(txb_pdasSemana1.Text) ? 0 : Convert.ToInt32(txb_pdasSemana1.Text);
                int? num2Semana = string.IsNullOrWhiteSpace(txb_pdasSemana2.Text) ? 0 : Convert.ToInt32(txb_pdasSemana2.Text);
                int? num3Semana = string.IsNullOrWhiteSpace(txb_pdasSemana3.Text) ? 0 : Convert.ToInt32(txb_pdasSemana3.Text);
                int? dias1SubPartida = string.IsNullOrWhiteSpace(txb_diasPdas1.Text) ? 0 : Convert.ToInt32(txb_diasPdas1.Text);
                int? dias2SubPartida = string.IsNullOrWhiteSpace(txb_diasPdas2.Text) ? 0 : Convert.ToInt32(txb_diasPdas2.Text);
                int? dias3SubPartida = string.IsNullOrWhiteSpace(txb_diasPdas3.Text) ? 0 : Convert.ToInt32(txb_diasPdas3.Text);
                
                string fecha1SubPartida = txb_fechaPartd1.Text;
                string fecha2SubPartida = txb_fechaPartd2.Text;
                string fecha3SubPartida = txb_fechaPartd3.Text;
                
                string observacionCafe = txb_observacionCafe.Text;
                DateTime fechaSecado = dtp_fechaSecado.Value;
                
                DateTime fechaInicioSecado = dtp_fechaInicioSecad.Value.Date + TimeSpan.Parse(txb_horaInicio.Text);
                DateTime fechaSalidaSecado = dtp_fechaSalidaSecad.Value.Date + TimeSpan.Parse(txb_horaSalida.Text);

                TimeSpan tiempoSecado = TimeSpan.Parse(txb_tiempoSecad.Text);
                double humedadSecado = Convert.ToDouble(txb_humedad.Text);
                double rendimiento = Convert.ToDouble(txb_rendimiento.Text);

                string nombrePunteroSecador = txb_nombrePuntero.Text;
                string observacionSecado = txb_observacionSecad.Text;

                string resultadoCatador = txb_resultadoCatacion.Text;
                DateTime fechaCatacion = dtp_fechaCatacion.Value;
                string observacionCatador = txb_observacionCatador.Text;
                DateTime fechaPesado = dtp_fechaPesa.Value;

                string nombreBodega = txb_ubicadoBodega.Text;
                string nombreAlmacen = txb_almacenSiloPiña.Text;
                string doctoAlmacen = txb_doctoAlmacen.Text;
                string nombrePunteroPesador = txb_nombrePesador.Text;
                string observacionPesador = txb_observacionPesa.Text;

                double pesoSaco;
                if (double.TryParse(txb_CantidadSaco.Text, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out pesoSaco)){}
                else
                {
                    MessageBox.Show("El valor ingresado en el campo Capacidad no es un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double pesoQQs;
                if (double.TryParse(txb_cantidadQQs.Text, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out pesoQQs)){}
                else
                {
                    MessageBox.Show("El valor ingresado en el campo Capacidad no es un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear una instancia de la clase SubPartida con los valores obtenidos
                SubPartida subPart = new SubPartida()
                {
                    // Asignar los valores a las propiedades de la instancia
                    IdSubpartida = iSubPartida,
                    NumeroSubpartida = subPartida,
                    NombreProcedencia = procedenciaNombre,
                    IdProcedencia = iProcedencia,
                    NombreCalidadCafe = calidadNombre,
                    IdCalidadCafe = iCalidad,
                    IdSubProducto = selectedValue,
                    IdCosecha = CosechaActual.ICosechaActual,
                    NombreCosecha = CosechaActual.NombreCosechaActual,

                    Num1Semana = num1Semana,
                    Num2Semana = num2Semana,
                    Num3Semana = num3Semana,

                    Dias1SubPartida = dias1SubPartida,
                    Dias2SubPartida = dias2SubPartida,
                    Dias3SubPartida = dias3SubPartida,

                    Fecha1SubPartida = fecha1SubPartida,
                    Fecha2SubPartida = fecha2SubPartida,
                    Fecha3SubPartida = fecha3SubPartida,

                    ObservacionIdentificacionCafe = observacionCafe,
                    FechaSecado = fechaSecado,
                    InicioSecado = fechaInicioSecado,
                    SalidaSecado = fechaSalidaSecado,

                    TiempoSecado = tiempoSecado,
                    HumedadSecado = humedadSecado,
                    Rendimiento = rendimiento,
                    IdPunteroSecador = iSecador,
                    NombrePunteroSecador = nombrePunteroSecador,
                    ObservacionSecado = observacionSecado,
                    IdCatador = iCatador,
                    NombreCatador = resultadoCatador,
                    FechaCatacion = fechaCatacion,
                    ObservacionCatador = observacionCatador,
                    FechaPesado = fechaPesado,
                    PesaSaco = pesoSaco,
                    PesaQQs = pesoQQs,
                    IdBodega = iBodega,
                    NombreBodega = nombreBodega,
                    IdAlmacen = iAlmacen,
                    NombreAlmacen = nombreAlmacen,
                    DoctoAlmacen = doctoAlmacen,
                    IdPesador = iPesador,
                    NombrePunteroPesador = nombrePunteroPesador,
                    ObservacionPesador = observacionPesador
                };


                // Llamar al controlador para insertar la SubPartida en la base de datos
                LogController log = new LogController();
                var userControl = new UserController();
                var usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario
                var subPartController = new SubPartidaController();

                if (!imagenClickeada)
                {
                    Console.WriteLine("depuracion - img cliqueada " + imagenClickeada);
                    bool exito = subPartController.InsertarSubPartida(subPart);

                    if (exito)
                    {
                        MessageBox.Show("SubPartida agregada correctamente.");
                        try
                        {
                            //Console.WriteLine("el ID obtenido del usuario "+usuario.IdUsuario);
                            //verificar el departamento
                            log.RegistrarLog(usuario.IdUsuario, "Registro dato SubPartida", ModuloActual.NombreModulo, "Insercion", "Inserto una nueva SubPartida a la base de datos");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                        }

                        //borrar datos de los textbox
                        ClearDataTxb();
                        imgClickBodega = false;
                        imgClickAlmacen = false;
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar la SubPartida. Verifica los datos e intenta nuevamente.");
                    }

                }
                else
                {
                    bool exito = subPartController.ActualizarSubPartida(subPart);

                    if (exito)
                    {
                        MessageBox.Show("SubPartida Actualizada correctamente.");
                        try
                        {
                            //Console.WriteLine("el ID obtenido del usuario "+usuario.IdUsuario);
                            //verificar el departamento
                            log.RegistrarLog(usuario.IdUsuario, "Actualizacion dato SubPartida", ModuloActual.NombreModulo, "Actualizacion", "Actualizo los datos de la SubPartida con id ( " + subPart.IdSubpartida + " ) en la base de datos");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                        }

                        //borrar datos de los textbox
                        ClearDataTxb();
                        imgClickBodega = false;
                        imgClickAlmacen = false;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar la SubPartida. Verifica los datos e intenta nuevamente.");
                    }
                }
            }
        }

        public bool VerificarCamposObligatorios()
        {
            // Verificar campo num_subpartida
            if (string.IsNullOrWhiteSpace(txb_subPartida.Text))
            {
                MessageBox.Show("El campo Subpartida está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo id_procedencia_subpartida
            if (string.IsNullOrWhiteSpace(txb_procedencia.Text))
            {
                MessageBox.Show("El campo Procedencia está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo id_calidad_cafe_subpartida
            if (string.IsNullOrWhiteSpace(txb_calidad.Text))
            {
                MessageBox.Show("El campo Calidad_Cafe está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo num1_semana_subpartida
            if (string.IsNullOrWhiteSpace(txb_pdasSemana1.Text))
            {
                MessageBox.Show("El campo Num1_Semana está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo dias1_subpartida
            if (string.IsNullOrWhiteSpace(txb_diasPdas1.Text))
            {
                MessageBox.Show("El campo Dias1_Subpartida está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo fecha1_subpartida
            if (string.IsNullOrWhiteSpace(txb_fechaPartd1.Text))
            {
                MessageBox.Show("La fechaPdas 1 está vacio y es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo fecha_carga_secado_subpartida
            if (dtp_fechaSecado.Value == DateTimePicker.MinimumDateTime)
            {
                MessageBox.Show("La fecha de carga de secado está sin seleccionar y es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo inicio_secado_subpartida
            if (dtp_fechaInicioSecad.Value == DateTimePicker.MinimumDateTime)
            {
                MessageBox.Show("La fecha de inicio de secado está sin seleccionar y es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo salida_punto_secado_subpartida
            if (dtp_fechaSalidaSecad.Value == DateTimePicker.MinimumDateTime)
            {
                MessageBox.Show("La fecha de salida de secado está sin seleccionar y es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo tiempo_secado_subpartida
            if (string.IsNullOrWhiteSpace(txb_tiempoSecad.Text))
            {
                MessageBox.Show("El campo Tiempo_Secado está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo humedad_secado_subpartida
            if (string.IsNullOrWhiteSpace(txb_humedad.Text))
            {
                MessageBox.Show("El campo Humedad_Secado está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo rendimiento_subpartida
            if (string.IsNullOrWhiteSpace(txb_rendimiento.Text))
            {
                MessageBox.Show("El campo Rendimiento está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo id_puntero_secado_subpartida
            if (string.IsNullOrWhiteSpace(txb_nombrePuntero.Text))
            {
                MessageBox.Show("El campo Puntero_Secado está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo id_catador_subpartida
            if (string.IsNullOrWhiteSpace(txb_nombreCatador.Text))
            {
                MessageBox.Show("El campo nombre Catador está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo fecha_catacion_subpartida
            if (dtp_fechaCatacion.Value == DateTimePicker.MinimumDateTime)
            {
                MessageBox.Show("La fecha de catación está sin seleccionar y es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo fecha_pesado_subpartida
            if (dtp_fechaPesa.Value == DateTimePicker.MinimumDateTime)
            {
                MessageBox.Show("La fecha de pesado está sin seleccionar y es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo peso_saco_subpartida
            if (string.IsNullOrWhiteSpace(txb_CantidadSaco.Text))
            {
                MessageBox.Show("El campo cantidad_Saco está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo peso_qqs_subpartida
            if (string.IsNullOrWhiteSpace(txb_cantidadQQs.Text))
            {
                MessageBox.Show("El campo cantidad_QQs está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo id_almacen_subpartida
            if (string.IsNullOrWhiteSpace(txb_almacenSiloPiña.Text))
            {
                MessageBox.Show("El campo Almacen está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo id_bodega_subpartida
            if (string.IsNullOrWhiteSpace(txb_ubicadoBodega.Text))
            {
                MessageBox.Show("El campo Bodega está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo id_pesador_subpartida
            if (string.IsNullOrWhiteSpace(txb_nombrePesador.Text))
            {
                MessageBox.Show("El campo nombre Pesador está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true; // Si todos los campos obligatorios están completos, retornamos true
        }

        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> {txb_subPartida,txb_procedencia,txb_calidad,
                                                    txb_pdasSemana1,txb_pdasSemana2,txb_pdasSemana3,txb_diasPdas1,txb_diasPdas2,txb_diasPdas3,
                                                    txb_observacionCafe,txb_horaInicio,txb_horaSalida,txb_tiempoSecad,txb_humedad,txb_rendimiento,
                                                    txb_nombrePuntero,txb_observacionSecad,txb_resultadoCatacion,
                                                    txb_nombreCatador,txb_observacionCatador,txb_CantidadSaco,txb_cantidadQQs,
                                                    txb_ubicadoBodega,txb_almacenSiloPiña,txb_nombrePesador,txb_doctoAlmacen,txb_observacionPesa};

            foreach (TextBox textBox in txb)
            {
                textBox.Clear();
            }

            AlmacenBodegaClick.IBodega = 0;
            dtp_fechaSecado.Value = DateTime.Now;
            dtp_fechaInicioSecad.Value = DateTime.Now;
            dtp_fechaSalidaSecad.Value = DateTime.Now;
            dtp_fechaCatacion.Value = DateTime.Now;
            dtp_fechaPesa.Value = DateTime.Now;
        }

        private void btn_SaveUser_Click(object sender, EventArgs e)
        {
            SaveSubPartida();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
            imgClickBodega = false;
            imgClickAlmacen = false;

        }
    }
}
