using MySql.Data.MySqlClient;
using sistema_modular_cafe_majada.model.Acces;
using sistema_modular_cafe_majada.model.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.controller.AccesController
{
    class RoleController
    {
        private ConnectionDB conexion;

        public RoleController()
        {
            // Inicializa la instancia de la clase ConexionBD
            conexion = new ConnectionDB();
        }

        public List<Role> ObtenerRoles()
        {
            List<Role> roles = new List<Role>();

            try
            {
                // Abre la conexión a la base de datos
                conexion.Conectar();

                string consulta = "SELECT * FROM Rol";
                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Role rol = new Role()
                        {
                            IdRol = Convert.ToInt32(reader["id_rol"]),
                            NombreRol = Convert.ToString(reader["nombre_rol"]),
                            DescripcionRol = Convert.ToString(reader["descripcion_rol"]),
                            NivelAccesoRol = Convert.ToString(reader["nivel_acceso_rol"]),
                            PermisosRol = Convert.ToString(reader["permisos_rol"]),
                            FechaCreacionRol = Convert.ToDateTime(reader["fecha_creacion_rol"])
                        };

                        // Verifica si el campo es nulo antes de asignarlo
                        if (reader["ult_fecha_mod_rol"] != DBNull.Value)
                        {
                            rol.UltFechaModRol = Convert.ToDateTime(reader["ult_fecha_mod_rol"]);
                        }

                        roles.Add(rol);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir al obtener los roles de la base de datos
                Console.WriteLine("Error al obtener la lista de roles: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Desconectar();
            }

            return roles;
        }


        public Role ObtenerRol(string nombreRol)
        {
            Role rol = null;
            try
            {

                // Abre la conexión a la base de datos
                conexion.Conectar();
                string consulta = "SELECT * FROM Rol WHERE nombre_rol = @NombreRol";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@NombreRol", nombreRol);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            rol = new Role()
                            {

                                IdRol = Convert.ToInt32(reader["id_rol"]),
                                NombreRol = Convert.ToString(reader["nombre_rol"]),
                                DescripcionRol = Convert.ToString(reader["descripcion_rol"]),
                                NivelAccesoRol = Convert.ToString(reader["nivel_acceso_rol"]),
                                PermisosRol = Convert.ToString(reader["permisos_rol"]),
                                FechaCreacionRol = Convert.ToDateTime(reader["fecha_creacion_rol"]),
                                UltFechaModRol = Convert.ToDateTime(reader["ult_fecha_mod_rol"])
                            };

                            // Verifica si el campo es nulo antes de asignarlo
                            if (!Convert.IsDBNull(reader["ult_fecha_mod_rol"]))
                            {
                                rol.UltFechaModRol = Convert.ToDateTime(reader["ult_fecha_mod_rol"]);
                            }
                            //Console.WriteLine("La persona obtenida es " + persona.NombresPersona);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir al obtener los usuarios de la base de datos
                Console.WriteLine("Error al obtener el rol: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Desconectar();
            }

            return rol;
        }

        public bool InsertarRol(Role rol)
        {
            try
            {
                // Abre la conexión
                conexion.Conectar();

                // Crea la consulta para insertar la persona en la base de datos
                string consulta = "INSERT INTO Rol (id_rol, nombre_rol, descripcion_rol, nivel_acceso_rol, permisos_rol, fecha_creacion_rol)" +
                                   "VALUES(@IdRol , @NombreRol , @DescripcionRol, @NivelRol, @PermisoRol, @FechaCreacion)";
                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@IdRol", rol.IdRol);
                conexion.AgregarParametro("@NombreRol", rol.NombreRol);
                conexion.AgregarParametro("@DescripcionRol", rol.DescripcionRol);
                conexion.AgregarParametro("@NivelRol", rol.NivelAccesoRol);
                conexion.AgregarParametro("@PermisoRol", rol.PermisosRol);
                conexion.AgregarParametro("@FechaCreacion", rol.FechaCreacionRol);

                int filasAfectadas = conexion.EjecutarInstruccion();

                if (filasAfectadas > 0)
                {
                    return true; // Inserción exitosa
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la inserción del Rol en la base de datos: " + ex.Message);
            }

            return false; // Error durante la inserción
        }

        public bool ActualizarPersona(int id, string nombre, string descripcion, string nivel, string permisos)
        {
            
            bool exito = false;
            try
            {
                // Abre la conexión a la base de datos
                conexion.Conectar();

                string consulta = "UPDATE Rol SET nombre_rol = @nombres, descripcion_rol = @descripcion, nivel_acceso_rol = @nivel, permisos_rol = @permisos, " +
                    " ult_fecha_mod_rol = @fechaModificacion WHERE id_rol = @id";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@nombres", nombre);
                conexion.AgregarParametro("@descripcion", descripcion);
                conexion.AgregarParametro("@nivel", nivel);
                conexion.AgregarParametro("@permisos", permisos);
                conexion.AgregarParametro("@fechaModificacion", DateTime.Today);
                conexion.AgregarParametro("@id", id);

                int filasAfectadas = conexion.EjecutarInstruccion();

                // Puedes realizar alguna acción adicional en función del resultado de la actualización
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
                // Manejar cualquier excepción que pueda ocurrir al obtener los usuarios de la base de datos
                Console.WriteLine("Error al actualizar Rol: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Desconectar();
            }
            return exito;
        }

        public void EliminarRol(int idRol)
        {
            // Crear la conexión a la base de datos
            ConnectionDB conexion = new ConnectionDB();
            conexion.Conectar();

            try
            {
                // Crear el comando SQL para eliminar el registro
                string consulta = "DELETE FROM Rol WHERE id_rol = @idRol";
                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@idRol", idRol);

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
