using sistema_modular_cafe_majada.controller.InfrastructureController;
using sistema_modular_cafe_majada.controller.OperationsController;
using sistema_modular_cafe_majada.controller.ProductController;
using sistema_modular_cafe_majada.model.Mapping;
using sistema_modular_cafe_majada.model.Mapping.Harvest;
using sistema_modular_cafe_majada.model.Mapping.Infrastructure;
using sistema_modular_cafe_majada.model.Mapping.Operations;
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
    public partial class form_opcSubPartida : Form
    {
        public form_opcSubPartida()
        {
            InitializeComponent();

            this.KeyPreview = true; // Habilita la captura de eventos de teclado para el formulario

            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_opcSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //
            SearchRegister(txb_buscarOpc);
            txb_buscarOpc.TextChanged += txb_buscarOpc_TextChanged;

            //esta es una llamada para funcion para pintar las filas del datagrid
            dtg_opcSP.CellPainting += dtg_opcSP_CellPainting;
        }
        
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //esta es una funcion para pintar las filas del datagrid
        private void dtg_opcSP_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        public void ShowBodegaGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            BodegaController bodegaController = new BodegaController();
            List<Bodega> datos = bodegaController.ObtenerBodegaNombreBeneficio();

            var datosPersonalizados = datos.Select(bodega => new
            {
                ID = bodega.IdBodega,
                Nombre = bodega.NombreBodega,
                Descripcion = bodega.DescripcionBodega,
                Ubicacion = bodega.UbicacionBodega,
                Beneficio = bodega.NombreBenficioUbicacion
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_opcSP.DataSource = datosPersonalizados;

            dtg_opcSP.RowHeadersVisible = false;
            dtg_opcSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        //
        public void ShowPersonalGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            var personalController = new PersonalController();
            List<Personal> datosP = null;

            // Verificar si se obtuvieron datos
            if (PersonalSeleccionado.TipoPersonal.Length != 0)
            {
                datosP = personalController.BuscarPersonalCargo(PersonalSeleccionado.TipoPersonal);
            }
            else
            {
                datosP = personalController.ObtenerPersonalesNombreCargo();
            }

            var datosPersonalizados = datosP.Select(personal => new
            {
                ID = personal.IdPersonal,
                Nombre = personal.NombrePersonal,
                Cargo = personal.NombreCargo,
                Descripcion = personal.Descripcion,
                ID_Persona = personal.IdPersona,
            }).ToList();
            
            // Asignar los datos al DataGridView
            dtg_opcSP.DataSource = datosPersonalizados;

            dtg_opcSP.RowHeadersVisible = false;
            dtg_opcSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //
        public void ShowAlmacenGrid()
        {
            // Llamar al método para obtener los datos de la base de datos
            AlmacenController almacenController = new AlmacenController();
            List<Almacen> datos = null;

            Console.WriteLine("Depuracion - id Bodega" + AlmacenBodegaClick.IBodega);
            if (AlmacenBodegaClick.IBodega != 0)
            {
                datos = almacenController.BuscarIDBodegaAlmacens(AlmacenBodegaClick.IBodega);
            }
            else
            {
                datos = almacenController.ObtenerAlmacenNombreBodega();
            }

            var datosPersonalizados = datos.Select(almacen => new
            {
                ID = almacen.IdAlmacen,
                Nombre = almacen.NombreAlmacen,
                Descripcion = almacen.DescripcionAlmacen,
                Capacidad = almacen.CapacidadAlmacen,
                Ubicacion = almacen.UbicacionAlmacen,
                Bodega_Ubicacion = almacen.NombreBodegaUbicacion
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_opcSP.DataSource = datosPersonalizados;

            dtg_opcSP.RowHeadersVisible = false;
            dtg_opcSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        //
        public void ShowCalidadCGrid()
        {
            //se llama el metodo para obtener los datos de la base de datos
            var calidadesController = new CCafeController();
            List<CalidadCafe> datosCCafe = calidadesController.ObtenerCalidades();

            var datosCalidades = datosCCafe.Select(calidades => new
            {
                ID = calidades.IdCalidad,
                Calidad = calidades.NombreCalidad,
                Descripcion = calidades.DescripcionCalidad
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_opcSP.DataSource = datosCalidades;

            dtg_opcSP.RowHeadersVisible = false;
            dtg_opcSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        //
        public void ShowProcedenciaGrid()
        {
            //se llama el metodo para obtener los datos de la base de datos
            var procedenciaController = new ProcedenciaDestinoController();
            List<ProcedenciaDestino> datosP = procedenciaController.ObtenerProcedenciasDestinoNombres();

            var datosProcedencia = datosP.Select(proced => new
            {
                ID = proced.IdProcedencia,
                Nombre = proced.NombreProcedencia,
                Descripcion = string.IsNullOrWhiteSpace(proced.DescripcionProcedencia) ? proced.DescripcionProcedencia = "" : proced.DescripcionProcedencia,
                Nombre_Socio = proced.NombreSocioProcedencia ?? "", // Verificar si es NULL y establecer cadena vacía en ese caso
                Nombre_Finca = proced.NombreFincaSocio ?? "",       
                Nombre_Beneficio = proced.NombreBenficioUbicacion ?? "", 
                Nombre_Maquinaria = proced.NombreMaquinaria ?? "" 
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_opcSP.DataSource = datosProcedencia;

            dtg_opcSP.RowHeadersVisible = false;
            dtg_opcSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        //
        public void ShowSubPartidaGrid()
        {
            //se llama el metodo para obtener los datos de la base de datos
            var subPartdController = new SubPartidaController();
            List<SubPartida> datosSP = subPartdController.ObtenerSubPartidasNombresPorCosecha(CosechaActual.NombreCosechaActual);

            var datosCalidades = datosSP.Select(subP => new
            {
                ID = subP.IdSubpartida,
                Numero_SubPartida = subP.NumeroSubpartida,
                Nombre_Cosecha = subP.NombreCosecha,
                Nombre_Procedencia = subP.NombreProcedencia,
                Nombre_CalidadCafe = subP.NombreCalidadCafe,
                Nombre_SubProducto = subP.NombreSubProducto,
                Fecha1_SubPartida = subP.Fecha1SubPartida,
                Fecha2_SubPartida = subP.Fecha2SubPartida,
                Fecha_CargaSecado = subP.FechaSecado,
                Puntero = subP.NombrePunteroSecador
            }).ToList();

            // Asignar los datos al DataGridView
            dtg_opcSP.DataSource = datosCalidades;

            dtg_opcSP.RowHeadersVisible = false;
            dtg_opcSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        //
        private void dtg_opcSP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila correspondiente a la celda en la que se hizo doble clic
            DataGridViewRow filaSeleccionada = dtg_opcSP.Rows[e.RowIndex];

            int opc = TablaSeleccionadasubPartd.ITable;

            switch (opc)
            {
                case 1:
                    //SubPartida
                    {
                        form_subPartidas subSPa = new form_subPartidas();
                        SubPartidaSeleccionado.clickImg = true;
                        // Obtener los valores de las celdas de la fila seleccionada
                        SubPartidaSeleccionado.ISubPartida = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                        SubPartidaSeleccionado.NumSubPartida = Convert.ToInt32(filaSeleccionada.Cells["Numero_SubPartida"].Value);
                        subSPa.SubSPartCosecha = filaSeleccionada.Cells["Nombre_Cosecha"].Value.ToString();
                        SubPartidaSeleccionado.NombreSubParti = filaSeleccionada.Cells["Numero_SubPartida"].Value.ToString();
                    }
                    break;
                case 2:
                    //Procedencia
                    {
                        // Obtener los valores de las celdas de la fila seleccionada
                        ProcedenciaSeleccionada.IProcedencia = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                        ProcedenciaSeleccionada.NombreProcedencia = filaSeleccionada.Cells["Nombre"].Value.ToString();
                    }
                    break;
                case 3:
                    //Calidad Cafe
                    {
                        // Obtener los valores de las celdas de la fila seleccionada
                        CalidadSeleccionada.ICalidadSeleccionada = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                        CalidadSeleccionada.NombreCalidadSeleccionada = filaSeleccionada.Cells["Calidad"].Value.ToString();
                    }
                    break;
                case 4:
                    //Puntero Secador
                    {
                        // Obtener los valores de las celdas de la fila seleccionada
                        PersonalSeleccionado.IPersonalPuntero = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                        PersonalSeleccionado.NombrePersonalPuntero = filaSeleccionada.Cells["Nombre"].Value.ToString();
                    }
                    break;
                case 5:
                    //Catador
                    {
                        // Obtener los valores de las celdas de la fila seleccionada
                        PersonalSeleccionado.IPersonalCatador = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                        PersonalSeleccionado.NombrePersonalCatador = filaSeleccionada.Cells["Nombre"].Value.ToString();
                    }
                    break;
                case 6:
                    //Ubicacion Bodega
                    {
                        // Obtener los valores de las celdas de la fila seleccionada
                        BodegaSeleccionada.IdBodega = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                        BodegaSeleccionada.NombreBodega = filaSeleccionada.Cells["Nombre"].Value.ToString();
                    }
                    break;
                case 7:
                    //Almacen
                    {
                        // Obtener los valores de las celdas de la fila seleccionada
                        AlmacenSeleccionado.IAlmacen = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                        AlmacenSeleccionado.NombreAlmacen = filaSeleccionada.Cells["Nombre"].Value.ToString();
                    }
                    break;
                case 8:
                    //Pesador
                    {
                        // Obtener los valores de las celdas de la fila seleccionada
                        PersonalSeleccionado.IPersonalPesador = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                        PersonalSeleccionado.NombrePersonalPesador = filaSeleccionada.Cells["Nombre"].Value.ToString();
                    }
                    break;
                default:
                    MessageBox.Show("Ocurrio un Error. La tabla que desea acceder no exite. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void form_opcSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Cierra el formulario actual
            }
        }

        private void txb_buscarOpc_TextChanged(object sender, EventArgs e)
        {
            SearchRegister(txb_buscarOpc);
        }

        //
        public void SearchRegister(TextBox text)
        {
            int opc = TablaSeleccionadasubPartd.ITable;

            switch (opc)
            {
                case 1:
                    {
                        //SubPartida
                        if (string.IsNullOrWhiteSpace(text.Text) || text.Text == "Buscar...")
                        {
                            //funcion para mostrar de inicio los datos en el dataGrid
                            ShowSubPartidaGrid();
                        }
                        else
                        {
                            //se llama el metodo para obtener los datos de la base de datos
                            var subPartdController = new SubPartidaController();
                            List<SubPartida> datosSP = subPartdController.BuscarSubPartidas(text.Text);

                            var datosCalidades = datosSP.Select(subP => new
                            {
                                ID = subP.IdSubpartida,
                                Numero_SubPartida = subP.NumeroSubpartida,
                                Nombre_Procedencia = subP.NombreProcedencia,
                                Nombre_CalidadCafe = subP.NombreCalidadCafe,
                                Nombre_SubProducto = subP.NombreSubProducto,
                                Fecha1_SubPartida = subP.Fecha1SubPartida,
                                Fecha2_SubPartida = subP.Fecha2SubPartida,
                                Fecha_CargaSecado = subP.FechaSecado,
                                Puntero = subP.NombrePunteroSecador
                            }).ToList();

                            // Asignar los datos al DataGridView
                            dtg_opcSP.DataSource = datosCalidades;

                            dtg_opcSP.RowHeadersVisible = false;
                            dtg_opcSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        }
                    }
                    break;
                case 2:
                    {
                        //Procedencia
                        if (string.IsNullOrWhiteSpace(text.Text) || text.Text == "Buscar...")
                        {
                            //funcion para mostrar de inicio los datos en el dataGrid
                            ShowProcedenciaGrid();
                        }
                        else
                        {
                            //se llama el metodo para obtener los datos de la base de datos
                            var procedenciaController = new ProcedenciaDestinoController();
                            List<ProcedenciaDestino> datosP = procedenciaController.BuscarProcedenciaDestino(text.Text);

                            var datosProcedencia = datosP.Select(proced => new
                            {
                                ID = proced.IdProcedencia,
                                Nombre = proced.NombreProcedencia,
                                Descripcion = string.IsNullOrWhiteSpace(proced.DescripcionProcedencia) ? proced.DescripcionProcedencia = "" : proced.DescripcionProcedencia,
                                Nombre_Socio = proced.NombreSocioProcedencia ?? "", // Verificar si es NULL y establecer cadena vacía en ese caso
                                Nombre_Finca = proced.NombreFincaSocio ?? "",
                                Nombre_Beneficio = proced.NombreBenficioUbicacion ?? "",
                                Nombre_Maquinaria = proced.NombreMaquinaria ?? ""
                            }).ToList();

                            // Asignar los datos al DataGridView
                            dtg_opcSP.DataSource = datosProcedencia;

                            dtg_opcSP.RowHeadersVisible = false;
                            dtg_opcSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        }
                    }
                    break;
                case 3:
                    //Calidad Cafe
                    {
                        //Procedencia
                        if (string.IsNullOrWhiteSpace(text.Text) || text.Text == "Buscar...")
                        {
                            //funcion para mostrar de inicio los datos en el dataGrid
                            ShowCalidadCGrid();
                        }
                        else
                        {
                            //se llama el metodo para obtener los datos de la base de datos
                            var calidadesController = new CCafeController();
                            List<CalidadCafe> datosCCafe = calidadesController.BuscarCalidades(text.Text);

                            var datosCalidades = datosCCafe.Select(calidades => new
                            {
                                ID = calidades.IdCalidad,
                                Calidad = calidades.NombreCalidad,
                                Descripcion = calidades.DescripcionCalidad
                            }).ToList();

                            // Asignar los datos al DataGridView
                            dtg_opcSP.DataSource = datosCalidades;

                            dtg_opcSP.RowHeadersVisible = false;
                            dtg_opcSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        }
                    }
                    break;
                case 4:
                    //Puntero Secador
                    {
                        //Procedencia
                        if (string.IsNullOrWhiteSpace(text.Text) || text.Text == "Buscar...")
                        {
                            //funcion para mostrar de inicio los datos en el dataGrid
                            ShowPersonalGrid();
                        }
                        else
                        {
                            // Llamar al método para obtener los datos de la base de datos
                            var personalController = new PersonalController();
                            List<Personal> datos = personalController.BuscarPersonal(text.Text);

                            var datosPersonalizados = datos.Select(personal => new
                            {
                                ID = personal.IdPersonal,
                                Nombre = personal.NombrePersonal,
                                Cargo = personal.NombreCargo,
                                Descripcion = personal.Descripcion,
                                ID_Persona = personal.IdPersona,
                            }).ToList();

                            // Asignar los datos al DataGridView
                            dtg_opcSP.DataSource = datosPersonalizados;

                            dtg_opcSP.RowHeadersVisible = false;
                            dtg_opcSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        }
                    }
                    break;
                case 5:
                    //Catador
                    {
                        //Procedencia
                        if (string.IsNullOrWhiteSpace(text.Text) || text.Text == "Buscar...")
                        {
                            //funcion para mostrar de inicio los datos en el dataGrid
                            ShowPersonalGrid();
                        }
                        else
                        {
                            // Llamar al método para obtener los datos de la base de datos
                            var personalController = new PersonalController();
                            List<Personal> datos = personalController.BuscarPersonal(text.Text);

                            var datosPersonalizados = datos.Select(personal => new
                            {
                                ID = personal.IdPersonal,
                                Nombre = personal.NombrePersonal,
                                Cargo = personal.NombreCargo,
                                Descripcion = personal.Descripcion,
                                ID_Persona = personal.IdPersona,
                            }).ToList();

                            // Asignar los datos al DataGridView
                            dtg_opcSP.DataSource = datosPersonalizados;

                            dtg_opcSP.RowHeadersVisible = false;
                            dtg_opcSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        }
                    }
                    break;
                case 6:
                    //Ubicacion Bodega
                    {
                        //Procedencia
                        if (string.IsNullOrWhiteSpace(text.Text) || text.Text == "Buscar...")
                        {
                            //funcion para mostrar de inicio los datos en el dataGrid
                            ShowBodegaGrid();
                        }
                        else
                        {
                            // Llamar al método para obtener los datos de la base de datos
                            BodegaController bodegaController = new BodegaController();
                            List<Bodega> datos = bodegaController.BuscarBodegas(text.Text);

                            var datosPersonalizados = datos.Select(bodega => new
                            {
                                ID = bodega.IdBodega,
                                Nombre = bodega.NombreBodega,
                                Descripcion = bodega.DescripcionBodega,
                                Ubicacion = bodega.UbicacionBodega,
                                Beneficio = bodega.NombreBenficioUbicacion
                            }).ToList();

                            // Asignar los datos al DataGridView
                            dtg_opcSP.DataSource = datosPersonalizados;

                            dtg_opcSP.RowHeadersVisible = false;
                            dtg_opcSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        }
                    }
                    break;
                case 7:
                    //Almacen
                    {
                        //Procedencia
                        if (string.IsNullOrWhiteSpace(text.Text) || text.Text == "Buscar...")
                        {
                            //funcion para mostrar de inicio los datos en el dataGrid
                            ShowAlmacenGrid();
                        }
                        else
                        {
                            // Llamar al método para obtener los datos de la base de datos
                            AlmacenController almacenController = new AlmacenController();
                            List<Almacen> datos = almacenController.BuscarAlmacens(text.Text);

                            var datosPersonalizados = datos.Select(almacen => new
                            {
                                ID = almacen.IdAlmacen,
                                Nombre = almacen.NombreAlmacen,
                                Descripcion = almacen.DescripcionAlmacen,
                                Capacidad = almacen.CapacidadAlmacen,
                                Ubicacion = almacen.UbicacionAlmacen,
                                Bodega_Ubicacion = almacen.NombreBodegaUbicacion
                            }).ToList();

                            // Asignar los datos al DataGridView
                            dtg_opcSP.DataSource = datosPersonalizados;

                            dtg_opcSP.RowHeadersVisible = false;
                            dtg_opcSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        }
                    }
                    break;
                case 8:
                    //Pesador
                    {
                        //Procedencia
                        if (string.IsNullOrWhiteSpace(text.Text) || text.Text == "Buscar...")
                        {
                            //funcion para mostrar de inicio los datos en el dataGrid
                            ShowPersonalGrid();
                        }
                        else
                        {
                            // Llamar al método para obtener los datos de la base de datos
                            var personalController = new PersonalController();
                            List<Personal> datos = personalController.BuscarPersonal(text.Text);

                            var datosPersonalizados = datos.Select(personal => new
                            {
                                ID = personal.IdPersonal,
                                Nombre = personal.NombrePersonal,
                                Cargo = personal.NombreCargo,
                                Descripcion = personal.Descripcion,
                                ID_Persona = personal.IdPersona,
                            }).ToList();

                            // Asignar los datos al DataGridView
                            dtg_opcSP.DataSource = datosPersonalizados;

                            dtg_opcSP.RowHeadersVisible = false;
                            dtg_opcSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        }
                    }
                    break;
                default:
                    MessageBox.Show("Ocurrio un Error. La tabla que desea acceder no exite. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        //
        private void txb_buscarOpc_Enter(object sender, EventArgs e)
        {
            if (txb_buscarOpc.Text == "Buscar...")
            {
                txb_buscarOpc.Text = string.Empty;
                txb_buscarOpc.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txb_buscarOpc_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_buscarOpc.Text))
            {
                txb_buscarOpc.Text = "Buscar...";
                txb_buscarOpc.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
}
