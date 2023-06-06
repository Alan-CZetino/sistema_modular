using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sistema_modular_cafe_majada.model;            // Importa los modelos correspondientes
using sistema_modular_cafe_majada.model.Connection; // Importa el contexto de la base de datos

namespace sistema_modular_cafe_majada.controller
{
    class LoginController
    {
        private ConnectionDB conexionBD; // Instancia de la clase ConexionBD

        public LoginController()
        {
            // Inicializar la instancia de ConexionBD
            conexionBD = new ConnectionDB();
        }

        public bool AutenticarUsuario(string nombreUsuario, string contraseña)
        {
            try
            {
                // Obtener una conexión a la base de datos
                conexionBD.Conectar();

                string query = "SELECT COUNT(*) FROM Usuario WHERE nombre_usuario = @nombreUsuario AND clave_usuario = @contraseña";

                // Crear un comando con la consulta y la conexión
                conexionBD.CrearComando(query);
                conexionBD.AgregarParametro("@nombreUsuario", nombreUsuario);
                conexionBD.AgregarParametro("@contraseña", contraseña);

                int count = Convert.ToInt32(conexionBD.EjecutarConsultaEscalar());

                // Cerrar la conexión a la base de datos
                conexionBD.Desconectar();

                if (count > 0)
                {
                    return true; // Las credenciales son válidas
                }
                else
                {
                    return false; // Las credenciales son inválidas
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al autenticar al usuario: " + ex.Message);
                return false;
            }
        }
    }
}
