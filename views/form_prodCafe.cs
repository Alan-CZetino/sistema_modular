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
    public partial class form_prodCafe : Form
    {
        public form_prodCafe()
        {
            InitializeComponent();
        }

        private void dtg_proceCafe_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //auto ajustar el contenido de los datos al área establecido para el datagrid
            dtg_proceCafe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_proceCafe.BorderStyle = BorderStyle.None;

            //configuracion de la fila de encabezado en el datagrid
            Font customFonten = new Font("Oswald", 9f, FontStyle.Bold);
            dtg_proceCafe.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(184, 89, 89);
            dtg_proceCafe.ColumnHeadersDefaultCellStyle.Font = customFonten;
            dtg_proceCafe.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtg_proceCafe.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 89, 89);
            dtg_proceCafe.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dtg_proceCafe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //configuracion de las filas por defecto en el datagrid
            Font customFontdef = new Font("Oswald Light", 10.2f, FontStyle.Regular);

            dtg_proceCafe.DefaultCellStyle.BackColor = Color.White;
            dtg_proceCafe.DefaultCellStyle.Font = customFontdef;
            dtg_proceCafe.DefaultCellStyle.ForeColor = Color.Black;
            dtg_proceCafe.DefaultCellStyle.SelectionBackColor = Color.White;
            dtg_proceCafe.DefaultCellStyle.SelectionForeColor = Color.Black;
            dtg_proceCafe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //configuracion de las filas que son seleccionadas
            dtg_proceCafe.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 199, 199);
            dtg_proceCafe.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }
    }
}
