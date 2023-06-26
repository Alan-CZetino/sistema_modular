using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using sistema_modular_cafe_majada.model;            // Importa los modelos correspondientes
using sistema_modular_cafe_majada.model.Acces;
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

        //autentifica si el usuario que desea ingresar cumple con sus credenciales si cumple accede y guarda su id
        public bool AutenticarUsuario(string nombreUsuario, string contraseña)
        {
            try
            {
                // Crear una instancia de la clase ConnectionDB
                ConnectionDB conexionBD = new ConnectionDB();

                // Conectar a la base de datos
                conexionBD.Conectar();

                string query = "SELECT clave_usuario FROM Usuario WHERE nombre_usuario = @nombreUsuario";

                // Crear un comando con la consulta
                conexionBD.CrearComando(query);
                conexionBD.AgregarParametro("@nombreUsuario", nombreUsuario);

                string hashedPasswordFromDB = conexionBD.EjecutarConsultaEscalar() as string;

                bool isMatch = false;

                if (hashedPasswordFromDB != null)
                {
                    isMatch = SecurityData.PasswordManager.VerifyPassword(contraseña, hashedPasswordFromDB);
                }

                // Cerrar la conexión a la base de datos
                conexionBD.Desconectar();

                return isMatch; // Devolver true si las credenciales son válidas, false en caso contrario
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al autenticar al usuario: " + ex.Message);
                return false;
            }
        }

        //funcion para obtener el tipo de estado del usuario
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

        //funcion para obtner los modulos de la bd
        public List<Module> ObtenerModulosCbx()
        {
            List<Module> depto = new List<Module>();

            try
            {
                // Abre la conexión a la base de datos
                conexionBD.Conectar();

                string consulta = "SELECT DISTINCT id_modulo, nombre_modulo FROM Modulo";
                conexionBD.CrearComando(consulta);

                using (MySqlDataReader reader = conexionBD.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Module modulo = new Module();
                        modulo.IdModule = Convert.ToInt32(reader["id_modulo"]);
                        modulo.NombreModulo = Convert.ToString(reader["nombre_modulo"]);
                        depto.Add(modulo);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir al obtener los usuarios de la base de datos
                Console.WriteLine("Error al obtener los modulos: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexionBD.Desconectar();
            }

            return depto;
        }

        //obtener los modulos al cual pertenece el usuario
        public List<Module> ObtenerModulosDeUsuario(int idUsuario)
        {
            try
            {
                // Crear una instancia de la clase ConnectionDB
                ConnectionDB conexionBD = new ConnectionDB();

                // Conectar a la base de datos
                conexionBD.Conectar();

                string query = @"SELECT m.id_modulo m.nombre_modulo
                        FROM Modulo m
                        INNER JOIN Usuario_Modulo um ON um.id_modulo = m.id_modulo
                        WHERE um.id_usuario = @idUsuario";

                // Crear un comando con la consulta
                conexionBD.CrearComando(query);
                conexionBD.AgregarParametro("@idUsuario", idUsuario);

                List<Module> modulos = new List<Module>();

                using (var reader = conexionBD.EjecutarConsultaReader(query))
                {
                    while (reader.Read())
                    {
                        Module modulo = new Module();
                        modulo.IdModule = Convert.ToInt32(reader["id_modulo"]);
                        modulo.NombreModulo = Convert.ToString(reader["nombre_modulo"]);
                        modulos.Add(modulo);
                    }
                }

                // Cerrar la conexión a la base de datos
                conexionBD.Desconectar();

                return modulos;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los módulos del usuario: " + ex.Message);
                return null;
            }
        }

        //verificar el modulo al que pertenece el usuario
        public bool VerificarUsuarioDepartamento(string nombreUsuario, int iDepartamento)
        {
            try
            {
                // Crear una instancia de la clase ConnectionDB
                ConnectionDB conexionBD = new ConnectionDB();

                // Conectar a la base de datos
                conexionBD.Conectar();

                // Consulta para obtener el ID del usuario
                string usuarioQuery = "SELECT id_usuario FROM Usuario WHERE nombre_usuario = @nombreUsuario";
                conexionBD.CrearComando(usuarioQuery);
                conexionBD.AgregarParametro("@nombreUsuario", nombreUsuario);

                int idUsuario = Convert.ToInt32(conexionBD.EjecutarConsultaEscalar());

                // Consulta para verificar la existencia del usuario en el departamento seleccionado
                string verificacionQuery = @"SELECT COUNT(*) FROM Usuario_Modulo um
                                    INNER JOIN Modulo m ON um.id_modulo = m.id_modulo
                                    WHERE um.id_usuario = @idUsuario AND m.id_modulo = @iDepartamento";
                conexionBD.CrearComando(verificacionQuery);
                conexionBD.AgregarParametro("@idUsuario", idUsuario);
                conexionBD.AgregarParametro("@iDepartamento", iDepartamento);

                int count = Convert.ToInt32(conexionBD.EjecutarConsultaEscalar());

                // Cerrar la conexión a la base de datos
                conexionBD.Desconectar();

                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar el usuario en el departamento: " + ex.Message);
                return false;
            }
        }
        
    }
}
