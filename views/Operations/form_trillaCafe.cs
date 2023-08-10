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
    public partial class form_trillaCafe : Form
    {
        //variable para refrescar el formulario cad cierto tiempo
        private System.Timers.Timer refreshTimer;

        private List<TextBox> txbRestrict;
        private int icosechaCambio;
        TrillaController countTr = null;

        public string rbSelect;
        public double cantidaQQsUpdate = 0.00;
        public double cantidaQQsActUpdate = 0.00;
        public double cantidaSacoUpdate = 0.00;
        public double cantidaSacoActUpdate = 0.00;

        private bool imagenClickeadaTR = false;
        private bool imgClickAlmacen = false;
        private bool imgClickUpdAlmacen = false;
        private bool imgClickBodega = false;

        private int iTrilla;
        private int iProcedencia;
        private int iPesador;
        private int isubProducto;
        private int iBodega;
        private int iAlmacen;
        private int iCalidad;
        private int iCalidadNoUpd;

        public form_trillaCafe()
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

            countTr = new TrillaController();
            var trll = countTr.CountTrilla(CosechaActual.ICosechaActual);
            //
            txb_numTrilla.Text = Convert.ToInt32(trll.CountTrilla + 1).ToString();
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
            cbx_subProducto.DropDownStyle = ComboBoxStyle.DropDownList;

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
                        if (icosechaCambio != CosechaActual.ICosechaActual || string.IsNullOrWhiteSpace(txb_numTrilla.Text))
                        {
                            icosechaCambio = CosechaActual.ICosechaActual;
                        }
                        txb_cosecha.Text = CosechaActual.NombreCosechaActual;
                    }
                }));
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
        public void ShowTrillaView()
        {
            var Trll = new TrillaController();
            SubProductoController subPro = new SubProductoController();
            var sub = Trll.ObtenerTrillasPorIDNombre(TrillaSeleccionado.ITrilla);
            var name = subPro.ObtenerSubProductoPorNombre(sub.NombreSubProducto);
            isubProducto = name.IdSubProducto;

            //cbx
            cbx_subProducto.Items.Clear();
            CbxSubProducto();
            int isP = name.IdSubProducto - 1;

            // Obtener la fecha y la hora por separado
            DateTime fechaTrilla = sub.FechaTrillaCafe.Date;

            dtp_fechaTrilla.Value = fechaTrilla;
            iTrilla = TrillaSeleccionado.ITrilla;
            txb_numTrilla.Text = Convert.ToString(TrillaSeleccionado.NumTrilla);
            txb_calidadCafe.Text = sub.NombreCalidadCafe;
            iCalidad = sub.IdCalidadCafe;
            iCalidadNoUpd = sub.IdCalidadCafe;
            cbx_subProducto.SelectedIndex = isP;
            txb_observacion.Text = sub.ObservacionTrilla;
            txb_pesoSaco.Text = sub.CantidadTrillaSacos.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));
            txb_pesoQQs.Text = sub.CantidadTrillaQQs.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));
            cantidaQQsUpdate = sub.CantidadTrillaQQs;
            cantidaSacoUpdate = sub.CantidadTrillaSacos;
            txb_bodega.Text = sub.NombreBodega;
            iBodega = sub.IdBodega;
            txb_almacen.Text = sub.NombreAlmacen;
            iAlmacen = sub.IdAlmacen;
            txb_personal.Text = sub.NombrePersonal;
            iPesador = sub.IdPersonal;
            txb_finca.Text = sub.NombreProcedencia;
            iProcedencia = sub.IdProcedencia;
            
            if (sub.TipoMovimientoTrilla == "SubProducto de Trilla")
            {
                rb_subProducto.Checked = true;
            }
            else
            {
                rb_cafeTrilla.Checked = true;
            }
        }

        private void btn_tTrillas_Click(object sender, EventArgs e)
        {
            TablaSeleccionadaTrilla.ITable = 1;
            form_opcTrilla opcTrilla = new form_opcTrilla();
            if (opcTrilla.ShowDialog() == DialogResult.OK)
            {
                ShowTrillaView();
            }
        }

        private void btn_tCCafe_Click(object sender, EventArgs e)
        {
            TablaSeleccionadaTrilla.ITable = 2;
            form_opcTrilla opcTrilla = new form_opcTrilla();
            if (opcTrilla.ShowDialog() == DialogResult.OK)
            {
                iCalidad = CalidadSeleccionada.ICalidadSeleccionada;
                txb_calidadCafe.Text = CalidadSeleccionada.NombreCalidadSeleccionada;
            }
            
        }

        private void btn_tAlmacen_Click(object sender, EventArgs e)
        {
            TablaSeleccionadaTrilla.ITable = 3;
            imgClickAlmacen = true;
            imgClickUpdAlmacen = true;
            form_opcTrilla opcTrilla = new form_opcTrilla();
            if (opcTrilla.ShowDialog() == DialogResult.OK)
            {
                if (!imgClickBodega)
                {
                    // Llamar al método para obtener los datos de la base de datos
                    AlmacenController almacenController = new AlmacenController();
                    Almacen datoA = almacenController.ObtenerIdAlmacen(AlmacenSeleccionado.IAlmacen);
                    BodegaController bodegaController = new BodegaController();
                    Bodega datoB = bodegaController.ObtenerIdBodega(datoA.IdBodegaUbicacion);

                    //
                    /*txb_bodega.Text = datoB.NombreBodega;
                    iBodega = datoB.IdBodega;*/
                    imgClickBodega = false;
                }
                iAlmacen = AlmacenSeleccionado.IAlmacen;
                txb_almacen.Text = AlmacenSeleccionado.NombreAlmacen;
            }
        }

        private void btn_tUbicacion_Click(object sender, EventArgs e)
        {
            TablaSeleccionadaTrilla.ITable = 4;
            imgClickBodega = true;
            form_opcTrilla opcTrilla = new form_opcTrilla();
            if (opcTrilla.ShowDialog() == DialogResult.OK)
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
                Console.WriteLine("depuracion - id Bodega obtenida " + BodegaSeleccionada.IdBodega);
                Console.WriteLine("depuracion2 - id Bodega obtenida " + iBodega);
                /*txb_almacen.Text = null;
                iAlmacen = 0;
                AlmacenSeleccionado.NombreAlmacen = null;
                AlmacenSeleccionado.IAlmacen = 0;*/
            }
        }

        private void btn_tPesador_Click(object sender, EventArgs e)
        {
            TablaSeleccionadaTrilla.ITable = 5;
            PersonalSeleccionado.TipoPersonal = "esa";
            form_opcTrilla opcTrilla = new form_opcTrilla();
            if (opcTrilla.ShowDialog() == DialogResult.OK)
            {
                iPesador = PersonalSeleccionado.IPersonalPesador;
                txb_personal.Text = PersonalSeleccionado.NombrePersonalPesador;
            }
        }
        
        private void btn_tProcedencia_Click(object sender, EventArgs e)
        {
            TablaSeleccionadaTrilla.ITable = 6;
            form_opcTrilla opcTrilla = new form_opcTrilla();
            if (opcTrilla.ShowDialog() == DialogResult.OK)
            {
                iProcedencia = ProcedenciaSeleccionada.IProcedencia;
                txb_finca.Text = ProcedenciaSeleccionada.NombreProcedencia;
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
            List<TextBox> txb = new List<TextBox> {txb_almacen,txb_bodega,txb_calidadCafe,txb_finca,txb_numTrilla,txb_observacion,
                                                    txb_personal,txb_pesoQQs, txb_pesoSaco};

            foreach (TextBox textBox in txb)
            {
                textBox.Clear();
            }

            AlmacenBodegaClick.IBodega = 0;
            AlmacenBodegaClick.IBodega = 0;
            dtp_fechaTrilla.Value = DateTime.Now;
            rb_cafeTrilla.Checked = false;
            rb_subProducto.Checked = false;

            countTr = new TrillaController();
            var tril = countTr.CountTrilla(CosechaActual.ICosechaActual);
            //
            txb_numTrilla.Text = Convert.ToString(tril.CountTrilla + 1);
        }

        //
        public void SaveTrilla()
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
            double cantActSaco = cantSP.CantidadActualSacoAlmacen;
            double cantRestSaco = cantMax - cantActSaco;
            int idAlmacenUpd;

            int numTrilla = Convert.ToInt32(txb_numTrilla.Text);
            string observacion = txb_observacion.Text;

            if (rb_cafeTrilla.Checked)
            {
                rbSelect = "Cafe a Trilla";
            }
            else if (rb_subProducto.Checked)
            {
                rbSelect = "SubProducto de Trilla";
            }
            else
            {
                MessageBox.Show("Ninguna Tipo de Movimiento en Trilla a sido seleccionado. Por favor seleccionar uno.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string selectedValueName = selectedStatus.Value;

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

            DateTime fechaTrilla = dtp_fechaTrilla.Value.Date;

            Trilla trilla = new Trilla()
            {
                NumTrilla = numTrilla,
                IdCosecha = CosechaActual.ICosechaActual,
                FechaTrillaCafe = fechaTrilla,
                TipoMovimientoTrilla = rbSelect,
                IdCalidadCafe = CalidadSeleccionada.ICalidadSeleccionada,
                IdSubProducto = selectedValue,
                CantidadTrillaSacos = pesoSaco,
                CantidadTrillaQQs = pesoQQs,
                IdAlmacen = AlmacenSeleccionado.IAlmacen,
                IdBodega = BodegaSeleccionada.IdBodega,
                IdProcedencia = ProcedenciaSeleccionada.IProcedencia,
                IdPersonal = PersonalSeleccionado.IPersonalPesador,
                ObservacionTrilla = observacion
            };

            // Llamar al controlador para insertar la SubPartida en la base de datos
            LogController log = new LogController();
            var userControl = new UserController();
            var usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario

            var trillaController = new TrillaController();

            //
            var almCM = almacenC.ObtenerCantidadCafeAlmacen(iAlmacen);
            var almNCM = almacenC.ObtenerAlmacenNombreCalidad(iAlmacen);
            double actcantidad = almCM.CantidadActualAlmacen;
            double actcantidadSaco = almCM.CantidadActualSacoAlmacen;

            if (!TrillaSeleccionado.clickImg)
            {
                bool verificexisten = trillaController.VerificarExistenciaTrilla(CosechaActual.ICosechaActual, Convert.ToInt32(txb_numTrilla.Text));

                if (!verificexisten)
                {
                    if (cantAct < pesoQQs || cantAct == 0)
                    {
                        MessageBox.Show("Error, la cantidad QQs de cafe que desea Sacar del almacen excede sus limite. Desea Sacar la cantidad de " + pesoQQs + " en el contenido disponible " + cantAct, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (cantActSaco < pesoSaco || cantActSaco == 0)
                    {
                        MessageBox.Show("Error, la cantidad en Saco de cafe que desea Sacar del almacen excede sus limite. Desea Sacar la cantidad de " + pesoSaco + " en el contenido disponible " + cantActSaco, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (almNCM.IdCalidadCafe != CalidadSeleccionada.ICalidadSeleccionada)
                    {
                        MessageBox.Show("La Calidad Cafe que se a seleccionado en el formulario no es compatible, La calidad a dar Salida es " + almNCM.NombreCalidadCafe + " y a seleccionado la calidad "
                            + CalidadSeleccionada.NombreCalidadSeleccionada + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (almNCM.IdSubProducto != selectedValue)
                    {
                        MessageBox.Show("El SubProducto Cafe que se a seleccionado en el formulario no es compatible, El SubProducto a dar Salida es " + almNCM.NombreSubProducto + " y a seleccionado el SubProducto "
                            + selectedValueName + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var cantidadCafeC = new CantidadSiloPiñaController();

                    CantidadSiloPiña cantidad = new CantidadSiloPiña()
                    {
                        FechaMovimiento = fechaTrilla,
                        IdCosechaCantidad = CosechaActual.ICosechaActual,
                        CantidadCafe = pesoQQs,
                        CantidadCafeSaco = pesoSaco,
                        TipoMovimiento = "Salida Cafe No.Trilla " + numTrilla,
                        IdAlmacenSiloPiña = iAlmacen
                    };

                    bool exitoregistroCantidad = cantidadCafeC.InsertarCantidadCafeSiloPiña(cantidad);
                    if (!exitoregistroCantidad)
                    {
                        MessageBox.Show("Error, Ocurrio un problema en la insercion de la cantidad de cafe verifique los campos QQs ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bool exito = trillaController.InsertarTrilla(trilla);

                    if (exito)
                    {
                        MessageBox.Show("Trilla agregada correctamente.");

                        double resultCa = actcantidad - pesoQQs;
                        double resultCaSaco = actcantidadSaco - pesoSaco;
                        
                        Console.WriteLine("Depuracion - cantidad resultante " + resultCa);
                        Console.WriteLine("Depuracion - cantidad obtenida a actualizar en subP" + pesoQQs);

                        almacenC.ActualizarCantidadEntradaCafeAlmacen(iAlmacen, resultCa, resultCaSaco, iCalidad, selectedValue);

                        try
                        {
                            //Console.WriteLine("el ID obtenido del usuario "+usuario.IdUsuario);
                            //verificar el departamento
                            log.RegistrarLog(usuario.IdUsuario, "Registro dato Trilla", ModuloActual.NombreModulo, "Insercion", "Inserto una nueva Trilla a la base de datos");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                        }

                        //borrar datos de los textbox
                        ClearDataTxb();
                        imgClickBodega = false;
                        imagenClickeadaTR = false;
                        imgClickAlmacen = false;
                        TrillaSeleccionado.clickImg = false;
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar la Trilla. Verifica los datos e intenta nuevamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Error al agregar la Trilla. El numero de Trilla ya existe en la cosecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                Trilla trillaUpd = new Trilla()
                {
                    IdTrilla_cafe = iTrilla,
                    NumTrilla = numTrilla,
                    IdCosecha = CosechaActual.ICosechaActual,
                    FechaTrillaCafe = fechaTrilla,
                    TipoMovimientoTrilla = rbSelect,
                    IdCalidadCafe = iCalidad,
                    IdSubProducto = selectedValue,
                    CantidadTrillaSacos = pesoSaco,
                    CantidadTrillaQQs = pesoQQs,
                    IdAlmacen = iAlmacen,
                    IdBodega = iBodega,
                    IdProcedencia = iProcedencia,
                    IdPersonal = iPesador,
                    ObservacionTrilla = observacion
                };

                var cantidadCafeC = new CantidadSiloPiñaController();
                string search = "No.Trilla " + TrillaSeleccionado.NumTrilla;
                Console.WriteLine("Depuracion - buscador   " + search);
                var cantUpd = cantidadCafeC.BuscarCantidadSiloPiñaSub(search);
                
                if (cantAct < pesoQQs || cantAct == 0)
                {
                    MessageBox.Show("Error, la cantidad QQs de cafe que desea Sacar del almacen excede sus limite. Desea Sacar la cantidad de " + pesoQQs + " en el contenido disponible " + cantAct, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cantActSaco < pesoSaco || cantActSaco == 0)
                {
                    MessageBox.Show("Error, la cantidad en Saco de cafe que desea Sacar del almacen excede sus limite. Desea Sacar la cantidad de " + pesoSaco + " en el contenido disponible " + cantActSaco, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (almNCM.IdCalidadCafe != CalidadSeleccionada.ICalidadSeleccionada)
                {
                    MessageBox.Show("La Calidad Cafe que se a seleccionado en el formulario no es compatible, La calidad a dar Salida es " + almNCM.NombreCalidadCafe + " y a seleccionado la calidad "
                        + CalidadSeleccionada.NombreCalidadSeleccionada + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (almNCM.IdSubProducto != selectedValue)
                {
                    MessageBox.Show("El SubProducto Cafe que se a seleccionado en el formulario no es compatible, El SubProducto a dar Salida es " + almNCM.NombreSubProducto + " y a seleccionado el SubProducto "
                        + selectedValueName + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool exito = trillaController.ActualizarTrilla(trillaUpd);

                if (!exito)
                {
                    MessageBox.Show("Error al actualizar la Trilla. Verifica los datos e intenta nuevamente.");
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
                    double cantidActSaco = cantidadActC.CantidadActualSacoAlmacen;
                    double resultCaNoUpdSaco = cantidActSaco + cantidaSacoUpdate;
                    
                    //actual almacen
                    //no actualiza los id, unicamnete la cantidad sumara ya que detecto que el almacen es diferente 
                    almacenC.ActualizarCantidadEntradaCafeUpdateSubPartidaAlmacen(cantUpd.IdAlmacenSiloPiña, resultCaNoUpd, resultCaNoUpdSaco, iCalidadNoUpd, selectedValue);

                    var cantidadNewC = almacenC.ObtenerCantidadCafeAlmacen(iAlmacen);
                    double cantidNew = cantidadNewC.CantidadActualAlmacen;
                    double resultCaUpd = cantidNew - cantidaQQsActUpdate;
                    double cantidNewSaco = cantidadNewC.CantidadActualSacoAlmacen;
                    double resultCaUpdSaco = cantidNewSaco - cantidaSacoActUpdate;
                    
                    //nuevo almacen
                    //cambia los nuevos datos ya que detecto que el almacen cambio 
                    almacenC.ActualizarCantidadEntradaCafeUpdateSubPartidaAlmacen(iAlmacen, resultCaUpd, resultCaUpdSaco, iCalidad, selectedValue);

                    CantidadSiloPiña cantidadUpd = new CantidadSiloPiña()
                    {
                        IdCantidadCafe = cantUpd.IdCantidadCafe,
                        FechaMovimiento = fechaTrilla,
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
                    double resultCaUpdSaco = actcantidadSaco + cantidaSacoUpdate - cantidaSacoActUpdate;
                    almacenC.ActualizarCantidadEntradaCafeUpdateSubPartidaAlmacen(cantUpd.IdAlmacenSiloPiña, resultCaUpd, resultCaUpdSaco, iCalidad, selectedValue);

                    CantidadSiloPiña cantidad = new CantidadSiloPiña()
                    {
                        IdCantidadCafe = cantUpd.IdCantidadCafe,
                        FechaMovimiento = fechaTrilla,
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

                MessageBox.Show("Trilla Actualizada correctamente.");
                try
                {
                    //verificar el departamento
                    log.RegistrarLog(usuario.IdUsuario, "Actualizacion dato Trilla", ModuloActual.NombreModulo, "Actualizacion", "Actualizo los datos de la Trilla con id ( " + trilla.IdTrilla_cafe + " ) en la base de datos");
                    TrillaSeleccionado.clickImg = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener el usuario: " + ex.Message);
                }

                //borrar datos de los textbox
                ClearDataTxb();
                imgClickBodega = false;
                imagenClickeadaTR = false;
                imgClickAlmacen = false;
            }
        }

        //
        public bool VerificarCamposObligatorios()
        {
            // Verificar campo num_subpartida
            if (string.IsNullOrWhiteSpace(txb_numTrilla.Text))
            {
                MessageBox.Show("El campo Numero Trilla está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo id_calidad_cafe_subpartida
            if (string.IsNullOrWhiteSpace(txb_calidadCafe.Text))
            {
                MessageBox.Show("El campo Calidad_Cafe está vacío y es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Verificar campo fecha_carga_secado_subpartida
            if (dtp_fechaTrilla.Value == DateTimePicker.MinimumDateTime)
            {
                MessageBox.Show("La fecha de carga de Trilla está sin seleccionar y es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_SaveTrilla_Click(object sender, EventArgs e)
        {
            SaveTrilla();
            cbx_subProducto.SelectedIndex = -1;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearDataTxb();
            cbx_subProducto.SelectedIndex = -1;
            imgClickBodega = false;
            imagenClickeadaTR = false;
            imgClickAlmacen = false;
            TrillaSeleccionado.clickImg = false;
        }

        private void btn_deleteTrilla_Click(object sender, EventArgs e)
        {
            //condicion para verificar si los datos seleccionados van nulos, para evitar error
            if (TrillaSeleccionado.NumTrilla != 0)
            {
                LogController log = new LogController();
                UserController userControl = new UserController();

                Usuario usuario = userControl.ObtenerUsuario(UsuarioActual.NombreUsuario); // Asignar el resultado de ObtenerUsuario
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro Trilla No: " + TrillaSeleccionado.NumTrilla + ", de la cosecha: " + CosechaActual.NombreCosechaActual + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
                    TrillaController controller = new TrillaController();
                    controller.EliminarTrilla(TrillaSeleccionado.ITrilla);

                    DateTime fechaTrilla = dtp_fechaTrilla.Value.Date;
                    var cantidadCafeC = new CantidadSiloPiñaController();
                    string search = "No.Trilla " + TrillaSeleccionado.NumTrilla;
                    var cantUpd = cantidadCafeC.BuscarCantidadSiloPiñaSub(search);

                    var almacenC = new AlmacenController();
                    var almCM = almacenC.ObtenerCantidadCafeAlmacen(iAlmacen);
                    double actcantidad = almCM.CantidadActualAlmacen;
                    double actcantidadSaco = almCM.CantidadActualSacoAlmacen;

                    double resultCaUpd = actcantidad + cantidaQQsUpdate;
                    double resultCaUpdSaco = actcantidadSaco + cantidaSacoUpdate;
                    almacenC.ActualizarCantidadEntradaCafeUpdateSubPartidaAlmacen(iAlmacen, resultCaUpd, resultCaUpdSaco, iCalidad, selectedValue);

                    cantidadCafeC.EliminarCantidadSiloPiña(cantUpd.IdCantidadCafe);
                    
                    //verificar el departamento del log
                    log.RegistrarLog(usuario.IdUsuario, "Eliminacion de dato Trilla", ModuloActual.NombreModulo, "Eliminacion", "Elimino los datos de la Trilla No: " + TrillaSeleccionado.NumTrilla + " del ID en la BD: " + TrillaSeleccionado.ITrilla + " en la base de datos");

                    MessageBox.Show("Trilla Eliminada correctamente.");

                    //se actualiza la tabla
                    ClearDataTxb();
                    cbx_subProducto.SelectedIndex = -1;
                    TrillaSeleccionado.ITrilla = 0;
                    TrillaSeleccionado.NumTrilla = 0;
                }
            }
            else
            {
                // Mostrar un mensaje de error o lanzar una excepción
                MessageBox.Show("No se ha seleccionado correctamente el dato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_pdfTrilla_Click(object sender, EventArgs e)
        {
            string reportPR = "../../views/Reports/report_numsubpartida.rdlc";
            form_opcReportExistencias reportSPartida = new form_opcReportExistencias(reportPR);
            reportSPartida.ShowDialog();
        }
    }
}
