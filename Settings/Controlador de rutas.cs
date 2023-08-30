using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.Settings
{
    class Controlador_de_rutas
    {
        public string RutaXML = "../../Settings/Cifrado.xml";
        public string rutaMySqlDump = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe";
        public string Ruta_Reporte_Calidad = "../../views/Reports/repor_ccalidad.rdlc";
        public string Ruta_Reporte_Bodega = "../../views/Reports/repor_bodega.rdlc";
        public string Ruta_Reporte_CafeBodega = "../../views/Reports/repor_cafebodega.rdlc";
        public string Ruta_Reporte_Grafico = "../../views/Reports/repor_grafico.rdlc";
        public string Ruta_Reporte_Salida = "../../views/Reports/repor_salidas.rdlc";
        public string Ruta_Reporte_Subpartida = "../../views/Reports/repor_subpartida.rdlc";
        public string Ruta_Reporte_Traslado = "../../views/Reports/repor_traslados.rdlc";
        public string Ruta_Reporte_Trilla = "../../views/Reports/repor_trillado.rdlc";
        public string Ruta_Reporte_Numsubpartida = "../../views/Reports/report_numsubpartida.rdlc";
    }
}
