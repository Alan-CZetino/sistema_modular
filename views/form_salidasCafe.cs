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
    public partial class form_salidasCafe : Form
    {
        //variable para refrescar el formulario cad cierto tiempo
        private System.Timers.Timer refreshTimer;

        private List<TextBox> txbRestrict;
        private int icosechaCambio;
        SalidaController countSl = null;

        public string rbSelect;
        public double cantidaQQsUpdate = 0.00;
        public double cantidaQQsActUpdate = 0.00;
        public double cantidaSacoUpdate = 0.00;
        public double cantidaSacoActUpdate = 0.00;

        private bool imagenClickeadaSL = false;
        private bool imgClickAlmacen = false;
        private bool imgClickUpdAlmacen = false;
        private bool imgClickBodega = false;

        private int iSalida;
        private int iProcedencia;
        private int iPesador;
        private int isubProducto;
        private int iBodega;
        private int iAlmacen;
        private int iCalidad;
        private int iCalidadNoUpd;
        public form_salidasCafe()
        {
            InitializeComponent();

            // Configurar el temporizador para que se dispare cada cierto intervalo (por ejemplo, cada 5 segundos).
            refreshTimer = new System.Timers.Timer();
            refreshTimer.Interval = 5000; // Intervalo en milisegundos (5 segundos en este caso).
            refreshTimer.Elapsed += RefreshTimer_Elapsed;
            refreshTimer.Start();

            txbRestrict = new List<TextBox> { txb_pesoQQs, txb_pesoSaco };

            RestrictTextBoxNum(txbRestrict);

            CbxSubProducto();

            countSl = new SalidaController();
            var sald = countSl.CountSalida(CosechaActual.ICosechaActual);
            //
            txb_numSalida.Text = Convert.ToInt32(sald.CountSalida + 1).ToString();
            txb_personal.Enabled = false;
            txb_personal.ReadOnly = true;
            txb_cosecha.Enabled = false;
            txb_cosecha.ReadOnly = true;
            txb_cosecha.Text = CosechaActual.NombreCosechaActual;
            txb_almacen.Enabled = false;
            txb_almacen.ReadOnly = true;
            txb_calidadCafe.Enabled = false;
            txb_calidadCafe.ReadOnly = true;
            txb_bodega.Enabled = false;
            txb_bodega.ReadOnly = true;
            txb_finca.Enabled = false;
            txb_finca.ReadOnly = true;
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
                        if (icosechaCambio != CosechaActual.ICosechaActual || string.IsNullOrWhiteSpace(txb_numSalida.Text))
                        {
                            countSl = new SalidaController();
                            var sald = countSl.CountSalida(CosechaActual.ICosechaActual);
                            //
                            txb_numSalida.Text = Convert.ToInt32(sald.CountSalida + 1).ToString();
                            icosechaCambio = CosechaActual.ICosechaActual;
                        }
                        txb_cosecha.Text = CosechaActual.NombreCosechaActual;
                    }
                }));
            }
        }

        //
        public void ShowSalidaView()
        {
            var sld = new SalidaController();
            SubProductoController subPro = new SubProductoController();
            var sub = sld.ObtenerSalidasPorIDNombre(SalidaSeleccionado.ISalida);
            var name = subPro.ObtenerSubProductoPorNombre(sub.NombreSubProducto);
            isubProducto = name.IdSubProducto;

            //cbx
            cbx_subProducto.Items.Clear();
            CbxSubProducto();
            int isP = name.IdSubProducto - 1;

            // Obtener la fecha y la hora por separado
            DateTime fechaSalida = sub.FechaSalidaCafe.Date;

            dtp_fechaSalida.Value = fechaSalida;
            iSalida = SalidaSeleccionado.ISalida;
            txb_numSalida.Text = Convert.ToString(SalidaSeleccionado.NumSalida);
            txb_calidadCafe.Text = sub.NombreCalidadCafe;
            iCalidad = sub.IdCalidadCafe;
            iCalidadNoUpd = sub.IdCalidadCafe;
            cbx_subProducto.SelectedIndex = isP;
            txb_observacion.Text = sub.ObservacionSalida;
            txb_pesoSaco.Text = sub.CantidadSalidaSacos.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));
            txb_pesoQQs.Text = sub.CantidadSalidaQQs.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));
            cantidaQQsUpdate = sub.CantidadSalidaQQs;
            cantidaSacoUpdate = sub.CantidadSalidaSacos;
            txb_bodega.Text = sub.NombreBodega;
            iBodega = sub.IdBodega;
            txb_almacen.Text = sub.NombreAlmacen;
            iAlmacen = sub.IdAlmacen;
            txb_personal.Text = sub.NombrePersonal;
            iPesador = sub.IdPersonal;
            txb_finca.Text = sub.NombreProcedencia;
            iProcedencia = sub.IdProcedencia;

            if (sub.TipoSalida == "Exportacion")
            {
                rb_export.Checked = true;
            }
            else if(sub.TipoSalida == "Torre Factora")
            {
                rb_torreFactor.Checked = true;
            }
            else
            {
                rb_otros.Checked = true;
            }
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
        public void ClearDataTxb()
        {
            List<TextBox> txb = new List<TextBox> {txb_almacen,txb_bodega,txb_calidadCafe,txb_finca,txb_numSalida,txb_observacion,
                                                    txb_personal,txb_pesoQQs, txb_pesoSaco};

            foreach (TextBox textBox in txb)
            {
                textBox.Clear();
            }

            AlmacenBodegaClick.IBodega = 0;
            dtp_fechaSalida.Value = DateTime.Now;
            rb_export.Checked = false;
            rb_otros.Checked = false;
            rb_torreFactor.Checked = false;
        }

        //
        public bool VerificarCamposObligatorios()
        {
            // Verificar campo num_subpartida
            if (string.IsNullOrWhiteSpace(txb_numSalida.Text))
            {
                MessageBox.Show("El campo Numero Salida vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo id_calidad_cafe_subpartida
            if (string.IsNullOrWhiteSpace(txb_calidadCafe.Text))
            {
                MessageBox.Show("El campo Calidad_Cafe está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo fecha_carga_secado_subpartida
            if (dtp_fechaSalida.Value == DateTimePicker.MinimumDateTime)
            {
                MessageBox.Show("La fecha de carga de Salida está sin seleccionar y es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo peso_saco_subpartida
            if (string.IsNullOrWhiteSpace(txb_pesoSaco.Text))
            {
                MessageBox.Show("El campo cantidad_Saco está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo peso_qqs_subpartida
            if (string.IsNullOrWhiteSpace(txb_pesoQQs.Text))
            {
                MessageBox.Show("El campo cantidad_QQs está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txb_finca.Text) && (string.IsNullOrWhiteSpace(txb_almacen.Text) || string.IsNullOrWhiteSpace(txb_bodega.Text)))
            {
                MessageBox.Show("El area de Procedencia del Cafe sus campos estan vacío y es necesario al menos llenar uno de ellos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo id_pesador_subpartida
            if (string.IsNullOrWhiteSpace(txb_personal.Text))
            {
                MessageBox.Show("El campo nombre Pesador está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txb_almacen.Text) || string.IsNullOrWhiteSpace(txb_bodega.Text))
            {
                MessageBox.Show("El campo Almacen o el de Bodega esta vacío y es necesario llenar ambos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true; // Si todos los campos obligatorios están completos, retornamos true
        }

        private void btn_tSalidas_Click(object sender, EventArgs e)
        {
            TablaSeleccionadaSalida.ITable = 1;
            form_opcSalida opcSalida = new form_opcSalida();
            if (opcSalida.ShowDialog() == DialogResult.OK)
            {
                ShowSalidaView();
            }
        }

        private void btn_tAlmacen_Click(object sender, EventArgs e)
        {
            TablaSeleccionadaSalida.ITable = 2;
            imgClickAlmacen = true;
            imgClickUpdAlmacen = true;
            form_opcSalida opcSalida = new form_opcSalida();
            if (opcSalida.ShowDialog() == DialogResult.OK)
            {
                if (!imgClickBodega)
                {
                    // Llamar al método para obtener los datos de la base de datos
                    AlmacenController almacenController = new AlmacenController();
                    Almacen datoA = almacenController.ObtenerIdAlmacen(AlmacenSeleccionado.IAlmacen);
                    BodegaController bodegaController = new BodegaController();
                    Bodega datoB = bodegaController.ObtenerIdBodega(datoA.IdBodegaUbicacion);

                    txb_bodega.Text = datoB.NombreBodega;
                    iBodega = datoB.IdBodega;
                    BodegaSeleccionada.IdBodega = iBodega;
                    imgClickBodega = false;
                }
                iAlmacen = AlmacenSeleccionado.IAlmacen;
                txb_almacen.Text = AlmacenSeleccionado.NombreAlmacen;
            }
        }

        private void btn_tUbicacion_Click(object sender, EventArgs e)
        {
            TablaSeleccionadaSalida.ITable = 3;
            imgClickBodega = true;
            form_opcSalida opcSalida = new form_opcSalida();
            if (opcSalida.ShowDialog() == DialogResult.OK)
            {
                iBodega = BodegaSeleccionada.IdBodega;

                if (iBodega != AlmacenBodegaClick.IBodega)
                {
                    imgClickAlmacen = false;
                }
                if (!imgClickAlmacen)
                {
                    AlmacenBodegaClick.IBodega = iBodega;
                }

                txb_bodega.Text = BodegaSeleccionada.NombreBodega;
            }
        }

        private void btn_tFinca_Click(object sender, EventArgs e)
        {
            TablaSeleccionadaSalida.ITable = 4;
            form_opcSalida opcSalida = new form_opcSalida();
            if (opcSalida.ShowDialog() == DialogResult.OK)
            {
                iProcedencia = ProcedenciaSeleccionada.IProcedencia;
                txb_finca.Text = ProcedenciaSeleccionada.NombreProcedencia;
            }
        }

        private void btn_tCCafe_Click(object sender, EventArgs e)
        {
            TablaSeleccionadaSalida.ITable = 5;
            form_opcSalida opcSalida = new form_opcSalida();
            if (opcSalida.ShowDialog() == DialogResult.OK)
            {
                iCalidad = CalidadSeleccionada.ICalidadSeleccionada;
                txb_calidadCafe.Text = CalidadSeleccionada.NombreCalidadSeleccionada;
            }
        }

        private void btn_tPesador_Click(object sender, EventArgs e)
        {
            TablaSeleccionadaSalida.ITable = 6;
            PersonalSeleccionado.TipoPersonal = "esa";
            form_opcSalida opcSalida = new form_opcSalida();
            if (opcSalida.ShowDialog() == DialogResult.OK)
            {
                iPesador = PersonalSeleccionado.IPersonalPesador;
                txb_personal.Text = PersonalSeleccionado.NombrePersonalPesador;
            }
        }

        //
        public void SaveSalida()
        {
            bool verific = VerificarCamposObligatorios();
            if (!verific)
            {
                return;
            }

            var almacenC = new AlmacenController();
            var cantSP = almacenC.ObtenerCantidadCafeAlmacen(iAlmacen);
            double cantMax = cantSP.CapacidadAlmacen;
            double cantAct = cantSP.CantidadActualAlmacen;
            double cantRest = cantMax - cantAct;
            int idAlmacenUpd;

            int numSalida = Convert.ToInt32(txb_numSalida.Text);
            string observacion = txb_observacion.Text;

            if (rb_export.Checked)
            {
                rbSelect = "Exportacion";
            }
            else if (rb_torreFactor.Checked)
            {
                rbSelect = "Torre Factora";
            }
            else if (rb_otros.Checked)
            {
                rbSelect = "Otro";
            }
            else
            {
                MessageBox.Show("Ninguna Tipo de Movimiento en Salida de Cafe a sido seleccionado. Por favor seleccionar uno.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            // Verificar si se ha seleccionado un rol de usuario
            if (cbx_subProducto.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un SubProducto en Datos del Producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double pesoSaco;
            if (double.TryParse(txb_pesoSaco.Text, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out pesoSaco)) { cantidaSacoActUpdate = pesoSaco; }
            else
            {
                MessageBox.Show("El valor ingresado en el campo Cantidad Saco no es un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double pesoQQs;
            if (double.TryParse(txb_pesoQQs.Text, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out pesoQQs)) { cantidaQQsActUpdate = pesoQQs; }
            else
            {
                MessageBox.Show("El valor ingresado en el campo Cantidad QQs no es un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime fechaSalida = dtp_fechaSalida.Value.Date;

            Salida salida = new Salida()
            {
                NumSalida_cafe = numSalida,
                IdCosecha = CosechaActual.ICosechaActual,
                FechaSalidaCafe = fechaSalida,
                TipoSalida = rbSelect,
                IdCalidadCafe = CalidadSeleccionada.ICalidadSeleccionada,
                IdSubProducto = selectedValue,
                CantidadSalidaSacos = pesoSaco,
                CantidadSalidaQQs = pesoQQs,
                IdAlmacen = AlmacenSeleccionado.IAlmacen,
                IdBodega = BodegaSeleccionada.IdBodega,
                IdProcedencia = ProcedenciaSeleccionada.IProcedencia,
                IdPersonal = PersonalSeleccionado.IPersonalPesador,
                ObservacionSalida = observacion
            };

            // Llamar al controlador para insertar la SubPartida en la base de datos
            LogController log = new LogController();
            var userControl = new UserController();
            var usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario

            var salidaController = new SalidaController();

            //
            var almCM = almacenC.ObtenerCantidadCafeAlmacen(iAlmacen);
            double actcantidad = almCM.CantidadActualAlmacen;

            if (!SalidaSeleccionado.clickImg)
            {
                bool verificexisten = salidaController.VerificarExistenciaSalida(CosechaActual.ICosechaActual, Convert.ToInt32(txb_numSalida.Text));

                if (!verificexisten)
                {

                    if (cantAct < pesoQQs)
                    {
                        MessageBox.Show("Error, la cantidad QQs de cafe que desea Sacar del almacen excede sus limite. Desea Sacar la cantidad de " + pesoQQs + " en el contenido disponible " + cantAct, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var cantidadCafeC = new CantidadSiloPiñaController();

                    CantidadSiloPiña cantidad = new CantidadSiloPiña()
                    {
                        FechaMovimiento = fechaSalida,
                        IdCosechaCantidad = CosechaActual.ICosechaActual,
                        CantidadCafe = pesoQQs,
                        CantidadCafeSaco = pesoQQs,
                        TipoMovimiento = "Salida Cafe No.SalidaCafe " + numSalida,
                        IdAlmacenSiloPiña = iAlmacen
                    };

                    bool exitoregistroCantidad = cantidadCafeC.InsertarCantidadCafeSiloPiña(cantidad);
                    if (!exitoregistroCantidad)
                    {
                        MessageBox.Show("Error, Ocurrio un problema en la insercion de la cantidad de cafe verifique los campos QQs ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bool exito = salidaController.InsertarSalidaCafe(salida);

                    if (exito)
                    {
                        MessageBox.Show("Salida de Cafe agregada correctamente.");

                        double resultCa = actcantidad - pesoQQs;

                        almacenC.ActualizarCantidadEntradaCafeAlmacen(iAlmacen, resultCa, iCalidad, selectedValue);

                        try
                        {
                            log.RegistrarLog(usuario.IdUsuario, "Registro dato Salida de Cafe", ModuloActual.NombreModulo, "Insercion", "Inserto una nueva Salida de Cafe a la base de datos");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                        }

                        //borrar datos de los textbox
                        ClearDataTxb();
                        imgClickBodega = false;
                        imagenClickeadaSL = false;
                        imgClickAlmacen = false;
                        SalidaSeleccionado.clickImg = false;
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar la Salida de Cafe. Verifica los datos e intenta nuevamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Error al agregar la Salida de Cafe. El numero de Salida de Cafe ya existe en la cosecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                Salida salidaUpd = new Salida()
                {
                    IdSalida_cafe = iSalida,
                    NumSalida_cafe = numSalida,
                    IdCosecha = CosechaActual.ICosechaActual,
                    FechaSalidaCafe = fechaSalida,
                    TipoSalida = rbSelect,
                    IdCalidadCafe = iCalidad,
                    IdSubProducto = selectedValue,
                    CantidadSalidaSacos = pesoSaco,
                    CantidadSalidaQQs = pesoQQs,
                    IdAlmacen = iAlmacen,
                    IdBodega = iBodega,
                    IdProcedencia = iProcedencia,
                    IdPersonal = iPesador,
                    ObservacionSalida = observacion
                };

                var cantidadCafeC = new CantidadSiloPiñaController();
                string search = "No.SalidaCafe " + SalidaSeleccionado.NumSalida;
                Console.WriteLine("Depuracion - buscador   " + search);
                var cantUpd = cantidadCafeC.BuscarCantidadSiloPiñaSub(search);

                if (cantAct < pesoQQs)
                {
                    MessageBox.Show("Error, la cantidad QQs de cafe que desea Sacar del almacen excede sus limite. Desea Sacar la cantidad de " + pesoQQs + " en el contenido disponible " + cantAct, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool exito = salidaController.ActualizarSalidaCafe(salidaUpd);

                if (!exito)
                {
                    MessageBox.Show("Error al actualizar la Salida de Cafe. Verifica los datos e intenta nuevamente.");
                    return;
                }

                if (imgClickUpdAlmacen)
                {
                    iAlmacen = AlmacenSeleccionado.IAlmacen;
                }

                if (cantUpd.IdAlmacenSiloPiña != iAlmacen)
                {
                    var cantidadActC = almacenC.ObtenerCantidadCafeAlmacen(cantUpd.IdAlmacenSiloPiña);
                    double cantidAct = cantidadActC.CantidadActualAlmacen;
                    double resultCaNoUpd = cantidAct + cantidaQQsUpdate;

                    //actual almacen
                    //no actualiza los id, unicamnete la cantidad sumara ya que detecto que el almacen es diferente 
                    almacenC.ActualizarCantidadEntradaCafeUpdateSubPartidaAlmacen(cantUpd.IdAlmacenSiloPiña, resultCaNoUpd, iCalidadNoUpd, selectedValue);

                    var cantidadNewC = almacenC.ObtenerCantidadCafeAlmacen(iAlmacen);
                    double cantidNew = cantidadNewC.CantidadActualAlmacen;
                    double resultCaUpd = cantidNew - cantidaQQsActUpdate;

                    //nuevo almacen
                    //cambia los nuevos datos ya que detecto que el almacen cambio 
                    almacenC.ActualizarCantidadEntradaCafeUpdateSubPartidaAlmacen(iAlmacen, resultCaUpd, iCalidad, selectedValue);

                    CantidadSiloPiña cantidadUpd = new CantidadSiloPiña()
                    {
                        IdCantidadCafe = cantUpd.IdCantidadCafe,
                        FechaMovimiento = fechaSalida,
                        IdCosechaCantidad = CosechaActual.ICosechaActual,
                        CantidadCafe = cantidaQQsActUpdate,
                        CantidadCafeSaco = cantidaSacoActUpdate,
                        IdAlmacenSiloPiña = iAlmacen
                    };

                    bool exitoUpdateCantidad = cantidadCafeC.ActualizarCantidadCafeSiloPiña(cantidadUpd);
                    if (!exitoUpdateCantidad)
                    {
                        MessageBox.Show("Error, Ocurrio un problema en la actualizacion de la cantidad de cafe verifique los campos QQs ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                else
                {
                    double resultCaUpd = actcantidad + cantidaQQsUpdate - cantidaQQsActUpdate;
                    almacenC.ActualizarCantidadEntradaCafeUpdateSubPartidaAlmacen(cantUpd.IdAlmacenSiloPiña, resultCaUpd, iCalidad, selectedValue);

                    CantidadSiloPiña cantidad = new CantidadSiloPiña()
                    {
                        IdCantidadCafe = cantUpd.IdCantidadCafe,
                        FechaMovimiento = fechaSalida,
                        IdCosechaCantidad = CosechaActual.ICosechaActual,
                        CantidadCafe = cantidaQQsActUpdate,
                        CantidadCafeSaco = cantidaSacoActUpdate,
                        IdAlmacenSiloPiña = cantUpd.IdAlmacenSiloPiña
                    };

                    bool exitoactualizarCantidad = cantidadCafeC.ActualizarCantidadCafeSiloPiña(cantidad);
                    if (!exitoactualizarCantidad)
                    {
                        MessageBox.Show("Error, Ocurrio un problema en la actualizacion de la cantidad de cafe verifique los campos QQs ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

                MessageBox.Show("Salida de Cafe Actualizada correctamente.");
                try
                {
                    //verificar el departamento
                    log.RegistrarLog(usuario.IdUsuario, "Actualizacion dato Salida de Cafe", ModuloActual.NombreModulo, "Actualizacion", "Actualizo los datos de la Salida de Cafe con id ( " + salida.IdSalida_cafe + " ) en la base de datos");
                    SalidaSeleccionado.clickImg = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                }

                //borrar datos de los textbox
                ClearDataTxb();
                imgClickBodega = false;
                imagenClickeadaSL = false;
                imgClickAlmacen = false;
            }
        }

        private void btn_SaveSalida_Click(object sender, EventArgs e)
        {
            SaveSalida();
            cbx_subProducto.SelectedIndex = -1;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
            cbx_subProducto.SelectedIndex = -1;
            imgClickBodega = false;
            imagenClickeadaSL = false;
            imgClickAlmacen = false;
            SalidaSeleccionado.clickImg = false;
        }

        private void btn_deleteSalida_Click(object sender, EventArgs e)
        {
            //condicion para verificar si los datos seleccionados van nulos, para evitar error
            if (SalidaSeleccionado.NumSalida != 0)
            {
                LogController log = new LogController();
                UserController userControl = new UserController();

                Usuario usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro Salida No: " + SalidaSeleccionado.NumSalida + ", de la cosecha: " + CosechaActual.NombreCosechaActual + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
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

                    //se llama la funcion delete del controlador para eliminar el registro
                    SalidaController controller = new SalidaController();
                    controller.EliminarSalidaCafe(SalidaSeleccionado.ISalida);

                    var cantidadCafeC = new CantidadSiloPiñaController();
                    string search = "No.SalidaCafe " + SalidaSeleccionado.NumSalida;
                    var cantUpd = cantidadCafeC.BuscarCantidadSiloPiñaSub(search);

                    var almacenC = new AlmacenController();
                    var almCM = almacenC.ObtenerCantidadCafeAlmacen(iAlmacen);
                    double actcantidad = almCM.CantidadActualAlmacen;

                    double resultCaUpd = actcantidad + cantidaQQsUpdate;
                    almacenC.ActualizarCantidadEntradaCafeUpdateSubPartidaAlmacen(iAlmacen, resultCaUpd, iCalidad, selectedValue);

                    cantidadCafeC.EliminarCantidadSiloPiña(cantUpd.IdCantidadCafe);

                    //verificar el departamento del log
                    log.RegistrarLog(usuario.IdUsuario, "Eliminacion de dato Salida Cafe", ModuloActual.NombreModulo, "Eliminacion", "Elimino los datos de la Salida No: " + SalidaSeleccionado.NumSalida + " del ID en la BD: " + SalidaSeleccionado.ISalida + " en la base de datos");

                    MessageBox.Show("Salida de Cafe Eliminada correctamente.");

                    //se actualiza la tabla
                    ClearDataTxb();
                    cbx_subProducto.SelectedIndex = -1;
                    SalidaSeleccionado.ISalida = 0;
                    SalidaSeleccionado.NumSalida = 0;
                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente el dato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
