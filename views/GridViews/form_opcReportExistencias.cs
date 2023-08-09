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
    public partial class form_opcReportExistencias : Form
    {
        public string ReportPath;
        public form_opcReportExistencias( string ReportPF)
        {
            InitializeComponent();
            ReportPath = ReportPF;
            CargarInforme();
        }
        public void CargarInforme()
        {
      
            reportViewerDetallado.Reset();
            // Código para cargar el informe en el ReportViewer usando el OrigenPath
            // Ejemplo: reportViewer1.LocalReport.ReportPath = OrigenPath;
            reportViewerDetallado.LocalReport.ReportPath = ReportPath;
            
            reportViewerDetallado.RefreshReport();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_opcReportExistencias_Load(object sender, EventArgs e)
        {
      
            
        }

    }
}
