using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using sistema_modular_cafe_majada.model;            // Importa los modelos correspondientes
using sistema_modular_cafe_majada.model.Connection; // Importa el contexto de la base de datos
using sistema_modular_cafe_majada.model.UserData;

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

                string query = "SELECT clave_usuario FROM Usuario WHERE nombre_usuario = @nombreUsuario";

                // Crear un comando con la consulta y la conexión
                conexionBD.CrearComando(query);
                conexionBD.AgregarParametro("@nombreUsuario", nombreUsuario);

                string hashedPasswordFromDB = conexionBD.EjecutarConsultaEscalar() as string;

                // Cerrar la conexión a la base de datos
                conexionBD.Desconectar();

                if (hashedPasswordFromDB != null)
                {
                    bool isMatch = SecurityData.PasswordManager.VerifyPassword(contraseña, hashedPasswordFromDB);

                    if (isMatch)
                    {
                        return true; // Las credenciales son válidas
                    }
                }

                return false; // Las credenciales son inválidas
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al autenticar al usuario: " + ex.Message);
                return false;
            }
        }

        public bool VerificarUsuarioDepartamento(string nombreUsuario, string departamento)
        {
            try
            {
                // Obtener una conexión a la base de datos
                conexionBD.Conectar();

                string query = "SELECT COUNT(*) FROM Usuario WHERE nombre_usuario = @nombreUsuario AND depto_usuario = @departamento";

                // Crear un comando con la consulta y la conexión
                conexionBD.CrearComando(query);
                conexionBD.AgregarParametro("@nombreUsuario", nombreUsuario);
                conexionBD.AgregarParametro("@departamento", departamento);

                int count = Convert.ToInt32(conexionBD.EjecutarConsultaEscalar());

                // Cerrar la conexión a la base de datos
                conexionBD.Desconectar();

                return count > 0; // Si count es mayor a 0, el usuario pertenece al departamento; de lo contrario, no pertenece
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al autenticar al usuario: " + ex.Message);
                return false;
            }
        }


        public List<Usuario> ObtenerDepartamentoCbx(string nombre)
        {
            List<Usuario> depto = new List<Usuario>();

            try
            {
                // Abre la conexión a la base de datos
                conexionBD.Conectar();

                string consulta = "SELECT DISTINCT depto_usuario FROM Usuario WHERE nombre_usuario = @nombreUsuario";
                conexionBD.CrearComando(consulta);
                conexionBD.AgregarParametro("@nombreUsuario", nombre);

                using (MySqlDataReader reader = conexionBD.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Usuario user = new Usuario();
                        user.DeptoUsuario = Convert.ToString(reader["depto_usuario"]);
                        depto.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir al obtener los usuarios de la base de datos
                Console.WriteLine("Error al obtener los roles: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexionBD.Desconectar();
            }

            return depto;
        }

        public Usuario ObtenerEstadoUsuario(string nombreUsuario)
        {
            Usuario estado = new Usuario();
            try
            {
                // Abre la conexión a la base de datos
                conexionBD.Conectar();
                string consulta = "SELECT estado_usuario FROM Usuario WHERE nombre_usuario = @NombreUsuario";

                conexionBD.CrearComando(consulta);
                conexionBD.AgregarParametro("@NombreUsuario", nombreUsuario);

                using (MySqlDataReader reader = conexionBD.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            estado.EstadoUsuario = Convert.ToString(reader["estado_usuario"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir al obtener los usuarios de la base de datos
                Console.WriteLine("Error al obtener la persona: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexionBD.Desconectar();
            }

            return estado;
        }

    }
}
