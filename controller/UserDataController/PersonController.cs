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
    class PersonController
    {
        private ConnectionDB conexion;

        public PersonController()
        {
            // Inicializa la instancia de la clase ConexionBD
            conexion = new ConnectionDB();
        }

        public bool InsertarPersona(Persona persona)
        {
            try
            {
                // Abre la conexión
                conexion.Conectar();

                // Crea la consulta para insertar la persona en la base de datos
                string consulta = "INSERT INTO Persona (id_persona, nombres_persona, apellidos_persona, direccion_persona, fecha_nac_persona, nit_persona, dui_persona, tel1_persona, tel2_persona)" +
                                   "VALUES(@IdPersona , @NombresPersona , @ApellidosPersona, @DireccionPersona, @FechaNacimientoPersona, " +
                                   "@NitPersona, @DuiPersona , @Telefono1Persona, @Telefono2Persona)";
                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@IdPersona", persona.IdPersona);
                conexion.AgregarParametro("@NombresPersona", persona.NombresPersona);
                conexion.AgregarParametro("@ApellidosPersona", persona.ApellidosPersona);
                conexion.AgregarParametro("@DireccionPersona", persona.DireccionPersona);
                conexion.AgregarParametro("@FechaNacimientoPersona", persona.FechaNacimientoPersona);
                conexion.AgregarParametro("@NitPersona", persona.NitPersona);
                conexion.AgregarParametro("@DuiPersona", persona.DuiPersona);
                conexion.AgregarParametro("@Telefono1Persona", persona.Telefono1Persona);
                conexion.AgregarParametro("@Telefono2Persona", persona.Telefono2Persona);

                int filasAfectadas = conexion.EjecutarInstruccion();

                if (filasAfectadas > 0)
                {
                    return true; // Inserción exitosa
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la inserción de persona en la base de datos: " + ex.Message);
            }

            return false; // Error durante la inserción
        }

        public List<Persona> ObtenerPersonas()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                // Abre la conexión a la base de datos
                conexion.Conectar();

                string consulta = "SELECT * FROM Persona";
                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Persona persona = new Persona()
                        {
                            IdPersona = Convert.ToInt32(reader["id_persona"]),
                            NombresPersona = Convert.ToString(reader["nombres_persona"]),
                            ApellidosPersona = Convert.ToString(reader["apellidos_persona"]),
                            DireccionPersona = Convert.ToString(reader["direccion_persona"]),
                            FechaNacimientoPersona = Convert.ToDateTime(reader["fecha_nac_persona"]),
                            DuiPersona = Convert.ToString(reader["dui_persona"]),
                            Telefono1Persona = Convert.ToString(reader["tel1_persona"])
                        };

                        // Verifica si el campo es nulo antes de asignarlo
                        if (!Convert.IsDBNull(reader["nit_persona"]))
                        {
                            persona.NitPersona = Convert.ToString(reader["nit_persona"]);
                        }

                        if (!Convert.IsDBNull(reader["tel2_persona"]))
                        {
                            persona.Telefono2Persona = Convert.ToString(reader["tel2_persona"]);
                        }

                        personas.Add(persona);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir al obtener los usuarios de la base de datos
                Console.WriteLine("Error al obtener la lista personas: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Desconectar();
            }

            return personas;
        }

        //verificar la consulta sql
        public Persona ObtenerPersona(string nombrePersona)
        {
            Persona persona = null;
            try
            {

                // Abre la conexión a la base de datos
                conexion.Conectar();
                string consulta = "SELECT * FROM Persona WHERE nombres_persona = @NombrePersona";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@NombrePersona", nombrePersona);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            persona = new Persona()
                            {

                                IdPersona = Convert.ToInt32(reader["id_persona"]),
                                NombresPersona = Convert.ToString(reader["nombres_persona"]),
                                ApellidosPersona = Convert.ToString(reader["apellidos_persona"]),
                                DireccionPersona = Convert.ToString(reader["direccion_persona"]),
                                FechaNacimientoPersona = Convert.ToDateTime(reader["fecha_nac_persona"]),
                                DuiPersona = Convert.ToString(reader["dui_persona"]),
                                Telefono1Persona = Convert.ToString(reader["tel1_persona"])
                            };

                            // Verifica si el campo es nulo antes de asignarlo
                            if (!Convert.IsDBNull(reader["nit_persona"]))
                            {
                                persona.NitPersona = Convert.ToString(reader["nit_persona"]);
                            }

                            if (!Convert.IsDBNull(reader["tel2_persona"]))
                            {
                                persona.Telefono2Persona = Convert.ToString(reader["tel2_persona"]);
                            }
                            //Console.WriteLine("La persona obtenida es " + persona.NombresPersona);
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

        public bool ActualizarPersona(int id, string nombres, string apellidos, string direccion, DateTime fechaNacimiento, string nit, string dui, string tel1, string tel2)
        {
            bool exito = false;
            try
            {
                // Abre la conexión a la base de datos
                conexion.Conectar();

                string consulta = "UPDATE Persona SET nombres_persona = @nombres, apellidos_persona = @apellidos, direccion_persona = @direccion, fecha_nac_persona = @fechaNacimiento, " +
                    "nit_persona = @nit, dui_persona = @dui, tel1_persona = @tel1, tel2_persona = @tel2 WHERE id_persona = @id";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@nombres", nombres);
                conexion.AgregarParametro("@apellidos", apellidos);
                conexion.AgregarParametro("@direccion", direccion);
                conexion.AgregarParametro("@fechaNacimiento", fechaNacimiento);
                conexion.AgregarParametro("@nit", string.IsNullOrEmpty(nit) ? DBNull.Value : (object)nit);
                conexion.AgregarParametro("@dui", dui);
                conexion.AgregarParametro("@tel1", tel1);
                conexion.AgregarParametro("@tel2", string.IsNullOrEmpty(tel2) ? DBNull.Value : (object)tel2);
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
                Console.WriteLine("Error al actualizar la persona: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Desconectar();
            }
            return exito;
        }

        public void EliminarPersona(int idPersona)
        {
            // Crear la conexión a la base de datos
            ConnectionDB conexion = new ConnectionDB();
            conexion.Conectar();

            try
            {
                // Crear el comando SQL para eliminar el registro
                string consulta = "DELETE FROM Persona WHERE id_persona = @idPersona";
                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@idPersona", idPersona);

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
