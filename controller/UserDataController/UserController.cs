using MySql.Data.MySqlClient;
using sistema_modular_cafe_majada.model.Acces;
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

        public bool InsertarUsuario(Usuario user)
        {
            bool exito = false;
            try
            {
                // Abrir la conexión a la base de datos
                conexion.Conectar();

                // Consulta SQL para insertar un nuevo usuario
                string consulta = "INSERT INTO Usuario (nombre_usuario, email_usuario, clave_usuario, estado_usuario, "
                    + "fecha_creacion_usuario, id_rol_usuario, id_persona_usuario) "
                    + "VALUES (@nombre, @email, @clave, @estado, "
                    + "@fechaCreacion, @idRol, @idPersona)";

                // Crear el comando SQL
                conexion.CrearComando(consulta);

                // Obtener la fecha actual
                DateTime fechaCreacion = DateTime.Now;

                // Agregar los parámetros al comando SQL
                conexion.AgregarParametro("@nombre", user.NombreUsuario);
                conexion.AgregarParametro("@email", user.EmailUsuario);
                conexion.AgregarParametro("@clave", user.ClaveUsuario);
                conexion.AgregarParametro("@estado", user.EstadoUsuario);
                conexion.AgregarParametro("@fechaCreacion", fechaCreacion);
                conexion.AgregarParametro("@idRol", user.IdRolUsuario);
                conexion.AgregarParametro("@idPersona", user.IdPersonaUsuario);

                // Ejecutar la instrucción de inserción
                int filasAfectadas = conexion.EjecutarInstruccion();

                // Verificar si la inserción fue exitosa
                if (filasAfectadas > 0)
                {
                    Console.WriteLine("La inserción se realizó correctamente.");
                    exito = true;
                }
                else
                {
                    Console.WriteLine("No se pudo realizar la inserción.");
                    exito = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar el usuario: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }
            return exito;
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
        
        public bool ActualizarUsuario(int id, string nombreUsuario, string email, string clave, DateTime? fechaBaja, string estado, int idRol, int idPersona)
        {
            bool exito = false;
            try
            {
                // Crear una instancia de la clase ConnectionDB
                ConnectionDB conexion = new ConnectionDB();

                // Abrir la conexión a la base de datos
                conexion.Conectar();

                // Consulta SQL para actualizar el usuario
                string consulta = "UPDATE Usuario SET nombre_usuario = @nombre, email_usuario = @email, "
                    + "clave_usuario = @clave, fecha_baja_usuario = @fechaBaja, estado_usuario = @estado, "
                    + "id_rol_usuario = @idRol, id_persona_usuario = @idPersona "
                    + "WHERE id_usuario = @id";

                // Crear el comando SQL
                conexion.CrearComando(consulta);

                // Agregar los parámetros al comando SQL
                conexion.AgregarParametro("@nombre", nombreUsuario);
                conexion.AgregarParametro("@email", email);
                conexion.AgregarParametro("@clave", clave);
                conexion.AgregarParametro("@fechaBaja", fechaBaja);
                conexion.AgregarParametro("@estado", estado);
                conexion.AgregarParametro("@idRol", idRol);
                conexion.AgregarParametro("@idPersona", idPersona);
                conexion.AgregarParametro("@id", id);

                // Ejecutar la instrucción de actualización
                int filasAfectadas = conexion.EjecutarInstruccion();

                // Verificar si la actualización fue exitosa
                if (filasAfectadas > 0)
                {
                    Console.WriteLine("La actualización se realizó correctamente.");
                    exito = true;
                }
                else
                {
                    Console.WriteLine("No se pudo realizar la actualización.");
                    exito = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el usuario: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }
            return exito;
        }

        //verificar si vale la pena mantener esta funcion aqui o pasarla a el controlador persona
        public Persona ObtenerNombrePersona(int idPersona)
        {
            Persona persona = new Persona();
            try
            {
                // Abre la conexión a la base de datos
                conexion.Conectar();
                string consulta = "SELECT nombres_persona FROM Persona WHERE id_persona = @NombrePersona";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@NombrePersona", idPersona);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            persona.NombresPersona = Convert.ToString(reader["nombres_persona"]);
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
                conexion.Desconectar();
            }

            return persona;
        }

        //verificar si vale la pena mantener esta funcion aqui o pasarla a el controlador rol
        public List<Role> ObtenerRolCbx()
        {
            List<Role> roles = new List<Role>();

            try
            {
                // Abre la conexión a la base de datos
                conexion.Conectar();

                string consulta = "SELECT id_rol, nombre_rol FROM Rol";
                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Role role = new Role();
                        role.IdRol = Convert.ToInt32(reader["id_rol"]);
                        role.NombreRol = Convert.ToString(reader["nombre_rol"]);
                        roles.Add(role);
                    }
                }
            }
            catch(Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir al obtener los usuarios de la base de datos
                Console.WriteLine("Error al obtener los roles: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Desconectar();
            }

            return roles;
        }
    }
}
