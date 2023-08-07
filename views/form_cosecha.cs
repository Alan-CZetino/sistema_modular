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
        public form_cosecha()
        {
            InitializeComponent();
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
    }
}
