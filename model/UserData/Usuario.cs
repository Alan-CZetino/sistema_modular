using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.UserData
{
    class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public string EstadoUsuario { get; set; }
        public DateTime FechaCreacionUsuario { get; set; }
        public DateTime? FechaBajaUsuario { get; set; }
        public string DeptoUsuario { get; set; }
        public int IdRolUsuario { get; set; }
        public int IdPersonaUsuario { get; set; }
    }
}
