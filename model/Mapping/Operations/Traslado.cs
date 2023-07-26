using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.Mapping.Operations
{
    class Traslado
    {
        public int Idtraslado_cafe { get; set; }
        public int IdCosecha { get; set; }
        public string NombreCosecha { get; set; }
        public int IdSubPartida { get; set; }
        public string NombreSubPartida { get; set; }
        public int IdProcedencia { get; set; }
        public string NombreProcedencia { get; set; }
        public int IdDestino { get; set; }
        public string NombreDestino { get; set; }
        public int IdCalidadCafe { get; set; }
        public string NombreCalidadCafe { get; set; }
        public int IdSubProducto { get; set; }
        public string NombreSubProducto { get; set; }
        public double CantidadTrasladoQQs { get; set; }
        public double CantidadTrasladoSacos { get; set; }
        public DateTime FechaTrasladoCafe { get; set; }
        public int IdPersonal { get; set; }
        public string NombrePersonal { get; set; }
        public string ObservacionTraslado { get; set; }
    }
}
