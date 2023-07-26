using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.Mapping.Operations
{
    class CantidadSiloPiña
    {
        public int IdCantidadCafe { get; set; }
        public DateTime FechaLlenado { get; set; }
        public DateTime FechaActualizado { get; set; }
        public DateTime FechaVaciado { get; set; }
        public double CantidadIngresada { get; set; }
        public double CantidadActual { get; set; }
        public double CantidadSalida { get; set; }
        public int IdCalidadCafe { get; set; }
        public string NombreCalidadCafe { get; set; }
        public int IdAlmacenSiloPiña { get; set; }
        public string NombreAlmacen { get; set; }
    }
}
