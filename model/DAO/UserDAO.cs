using MySql.Data.MySqlClient;
using sistema_modular_cafe_majada.model.Connection;
using sistema_modular_cafe_majada.model.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.DAO
{
    class UserDAO
    {
        // funcion para obtener todos los usuarios
        private ConnectionDB conexion;

        public UserDAO()
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

        //funcion para obtener un usuario en especifico
        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            Usuario usuario = null;
            try
            {

                // Abre la conexión a la base de datos
                conexion.Conectar();
                string consulta = "SELECT * FROM Usuario WHERE nombre_usuario = @NombreUsuario";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@NombreUsuario", nombreUsuario);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario()
                            {

                                IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                                NombreUsuario = Convert.ToString(reader["nombre_usuario"]),
                                EmailUsuario = Convert.ToString(reader["email_usuario"]),
                                ClaveUsuario = Convert.ToString(reader["clave_usuario"]),
                                EstadoUsuario = Convert.ToString(reader["estado_usuario"]),
                                FechaCreacionUsuario = Convert.ToDateTime(reader["fecha_creacion_usuario"]),
                                IdRolUsuario = Convert.ToInt32(reader["id_rol_usuario"]),
                                IdPersonaUsuario = Convert.ToInt32(reader["id_persona_usuario"])

                            };

                            if (!reader.IsDBNull(reader.GetOrdinal("fecha_baja_usuario")))
                            {
                                usuario.FechaBajaUsuario = reader.GetDateTime("fecha_baja_usuario");
                            }
                            //Console.WriteLine("El usuario recogido es " + usuario.NombreUsuario + " con id " + usuario.IdUsuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir al obtener los usuarios de la base de datos
                Console.WriteLine("Error al obtener el usuario: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Desconectar();
            }

            return usuario;
        }
    }
}
