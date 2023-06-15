using MySql.Data.MySqlClient;
using sistema_modular_cafe_majada.model.Connection;
using sistema_modular_cafe_majada.model.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.controller.UserDataController
{
    class UserController
    {
        // funcion para obtener todos los usuarios
        private ConnectionDB conexion;

        public UserController()
        {
            // Inicializa la instancia de la clase ConexionBD
            conexion = new ConnectionDB();
        }

        public List<Usuario> ObtenerTodosUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                // Abre la conexión a la base de datos
                conexion.Conectar();

                string consulta = "SELECT * FROM Usuario";
                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                            NombreUsuario = Convert.ToString(reader["nombre_usuario"]),
                            EmailUsuario = Convert.ToString(reader["email_usuario"]),
                            ClaveUsuario = Convert.ToString(reader["clave_usuario"]),
                            EstadoUsuario = Convert.ToString(reader["estado_usuario"]),
                            FechaCreacionUsuario = Convert.ToDateTime(reader["fecha_creacion_usuario"]),
                            FechaBajaUsuario = reader.IsDBNull(reader.GetOrdinal("fecha_baja_usuario")) ? null : (DateTime?)reader["fecha_baja_usuario"],
                            DeptoUsuario = Convert.ToString(reader["depto_usuario"]),
                            IdRolUsuario = Convert.ToInt32(reader["id_rol_usuario"]),
                            IdPersonaUsuario = Convert.ToInt32(reader["id_persona_usuario"])
                        };

                        usuarios.Add(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir al obtener los usuarios de la base de datos
                Console.WriteLine("Error al obtener los usuario: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Desconectar();
            }

            return usuarios;
        }

        public bool InsertarUsuario(Usuario usuario)
        {
            try
            {
                // Abre la conexión
                conexion.Conectar();

                string query = "INSERT INTO tu_tabla (nombre_usuario, email_usuario, clave_usuario, estado_usuario, fecha_creacion_usuario, fecha_baja_usuario, depto_usuario, id_rol_usuario, id_persona_usuario) " +
               "VALUES (@NombreUsuario, @EmailUsuario, @ClaveUsuario, @EstadoUsuario, @FechaCreacionUsuario, @FechaBajaUsuario, @DeptoUsuario, @IdRolUsuario, @IdPersonaUsuario)";

                conexion.CrearComando(query);

                conexion.AgregarParametro("@NombreUsuario", usuario.NombreUsuario);
                conexion.AgregarParametro("@EmailUsuario", usuario.EmailUsuario);
                conexion.AgregarParametro("@ClaveUsuario", usuario.ClaveUsuario);
                conexion.AgregarParametro("@EstadoUsuario", "Activo");
                conexion.AgregarParametro("@FechaCreacionUsuario", DateTime.Today);
                conexion.AgregarParametro("@FechaBajaUsuario", usuario.FechaBajaUsuario ?? (object)DBNull.Value);
                conexion.AgregarParametro("@DeptoUsuario", usuario.DeptoUsuario);
                conexion.AgregarParametro("@IdRolUsuario", usuario.IdRolUsuario);
                conexion.AgregarParametro("@IdPersonaUsuario", usuario.IdPersonaUsuario);

                int filasAfectadas = conexion.EjecutarInstruccion();

                if (filasAfectadas > 0)
                {
                    return true; // Inserción exitosa
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la inserción del usuario en la base de datos: " + ex.Message);
            }

            return false; // Error durante la inserción
        }

        public void EliminarUsuario(int idUsuario)
        {
            // Crear la conexión a la base de datos
            ConnectionDB conexion = new ConnectionDB();
            conexion.Conectar();

            try
            {
                // Crear el comando SQL para eliminar el registro
                string consulta = "DELETE FROM Usuario WHERE id_usuario = @idUsuario";
                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@idUsuario", idUsuario);

                // Ejecutar la instrucción de eliminación
                int filasAfectadas = conexion.EjecutarInstruccion();

                if (filasAfectadas > 0)
                {
                    Console.WriteLine("El registro se eliminó correctamente");
                }
                else
                {
                    Console.WriteLine("No se encontró el registro a eliminar");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el registro: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }
        }

    }
}
