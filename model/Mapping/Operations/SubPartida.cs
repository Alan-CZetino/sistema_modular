using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.Mapping.Operations
{
    class SubPartida
    {
        public int IdSubpartida { get; set; }
        public int NumeroSubpartida { get; set; }
        public int IdCosecha { get; set; }
        public string NombreCosecha { get; set; }
        public int? IdProcedencia { get; set; } // Modificación: nulleable
        public string NombreProcedencia { get; set; }
        public int? IdCalidadCafe { get; set; } // Modificación: nulleable
        public string NombreCalidadCafe { get; set; }
        public int? IdSubProducto { get; set; } // Modificación: nulleable
        public string NombreSubProducto { get; set; }
        public int? Num1Semana { get; set; } // Modificación: nulleable
        public int? Num2Semana { get; set; } // Modificación: nulleable
        public int? Num3Semana { get; set; } // Modificación: nulleable
        public int? Dias1SubPartida { get; set; } // Modificación: nulleable
        public int? Dias2SubPartida { get; set; } // Modificación: nulleable
        public int? Dias3SubPartida { get; set; } // Modificación: nulleable
        public DateTime Fecha1SubPartida { get; set; }
        public DateTime? Fecha2SubPartida { get; set; } // Modificación: nulleable
        public DateTime? Fecha3SubPartida { get; set; } // Modificación: nulleable
        public string ObservacionIdentificacionCafe { get; set; }
        public DateTime FechaSecado { get; set; }
        public DateTime InicioSecado { get; set; }
        public DateTime SalidaSecado { get; set; }
        public TimeSpan TiempoSecado { get; set; }
        public double HumedadSecado { get; set; }
        public double Rendimiento { get; set; }
        public int? IdPunteroSecador { get; set; } // Modificación: nulleable
        public string NombrePunteroSecador { get; set; }
        public string ObservacionSecado { get; set; }
        public int? IdCatador { get; set; } // Modificación: nulleable
        public string NombreCatador { get; set; }
        public string ResultadoCatador { get; set; }
        public DateTime FechaCatacion { get; set; }
        public string ObservacionCatador { get; set; }
        //falta ver ubicacion
        public DateTime FechaPesado { get; set; }
        public double PesaSaco { get; set; }
        public double PesaQQs { get; set; }
        public int? IdBodega { get; set; } // Modificación: nulleable
        public string NombreBodega { get; set; }
        public int? IdAlmacen { get; set; } // Modificación: nulleable
        public string NombreAlmacen { get; set; }
        public string DoctoAlmacen { get; set; }
        public int? IdPesador { get; set; } // Modificación: nulleable
        public string NombrePunteroPesador { get; set; }
        public string ObservacionPesador { get; set; }
    }


    public static class TablaSeleccionadasubPartd
    {
        public static int ITable { get; set; }
    }

    public static class SubPartidaSeleccionado
    {
        public static int ISubPartida { get; set; }
        public static string NombreSubParti { get; set; }
    }
}
