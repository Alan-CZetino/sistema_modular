using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.Mapping.Infrastructure
{
    class Bodega
    {
        public int IdBodega { get; set; }
        public string NombreBodega { get; set; }
        public string DescripcionBodega { get; set; }
        public string UbicacionBodega { get; set; }
        public int IdBenficioUbicacion { get; set; }
        public string NombreBenficioUbicacion { get; set; }
    }
}
