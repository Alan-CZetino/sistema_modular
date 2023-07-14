﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.Mapping.Harvest
{
    class Cosecha
    {
        public int IdCosecha { get; set; }
        public string NombreCosecha { get; set; }
        public DateTime FechaCosecha { get; set; }
    }

    public static class CosechaSeleccionada
    {
        public static int ICosechaSeleccionada { get; set; }
        public static string NombreCosechaSeleccionada { get; set; }
    }
}
