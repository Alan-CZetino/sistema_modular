using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.Mapping.Harvest
{
    class Lote
    {
        public int IdLote { get; set; }
        public string NombreLote { get; set; }
        public int IdFinca { get; set; }
        public DateTime FechaLote { get; set; }
        public double CantidadLote { get; set; }
        public string TipoCafe { get; set; }
        public int IdCalidadLote { get; set; }
        public int IdCosechaLote { get; set; }
    }
}
