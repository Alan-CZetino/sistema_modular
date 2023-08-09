﻿using MySql.Data.MySqlClient;
using sistema_modular_cafe_majada.model.Connection;
using sistema_modular_cafe_majada.model.Mapping.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.DAO
{
    class SocioDAO
    {
        private ConnectionDB conexion;

        public SocioDAO()
        {
            //Se crea la instancia de la clase conexion
            conexion = new ConnectionDB();
        }

        // Función para insertar un nuevo registro en la tabla Socio
        public bool InsertarSocio(Socio socio)
        {
            try
            {
                // Conectar a la base de datos
                conexion.Conectar();

                // Crear script SQL para insertar
                string consulta = @"INSERT INTO Socio (nombre_socio, descripcion_socio, ubicacion_socio, id_persona_resp_socio, id_finca_socio)
                            VALUES (@nombre, @descripcion, @ubicacion, @idPersonaResp, @ifinca)";
                conexion.CrearComando(consulta);

                // Agregar los parámetros a la consulta
                conexion.AgregarParametro("@nombre", socio.NombreSocio);
                conexion.AgregarParametro("@descripcion", socio.DescripcionSocio);
                conexion.AgregarParametro("@ubicacion", socio.UbicacionSocio);
                conexion.AgregarParametro("@idPersonaResp", socio.IdPersonaRespSocio);
                conexion.AgregarParametro("@ifinca", socio.IdFincaSocio);

                // Ejecutar la instrucción SQL
                int filasAfectadas = conexion.EjecutarInstruccion();

                // Si la fila se afecta, se insertó correctamente
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la inserción del Socio en la base de datos: " + ex.Message);
                return false;
            }
            finally
            {
                // Se cierra la conexión a la base de datos
                conexion.Desconectar();
            }
        }

        // Función para obtener todos los registros de la tabla Socio
        public List<Socio> ObtenerSocios()
        {
            List<Socio> listaSocios = new List<Socio>();

            try
            {
                // Se conecta con la base de datos
                conexion.Conectar();

                string consulta = @"SELECT * FROM Socio";
                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Socio socio = new Socio()
                        {
                            IdSocio = Convert.ToInt32(reader["id_socio"]),
                            NombreSocio = Convert.ToString(reader["nombre_socio"]),
                            DescripcionSocio = (reader["descripcion_socio"]) is DBNull ? "" : Convert.ToString(reader["descripcion_socio"]),
                            UbicacionSocio = Convert.ToString(reader["ubicacion_socio"]),
                            IdPersonaRespSocio = Convert.ToInt32(reader["id_persona_resp_socio"]),
                            IdFincaSocio = (reader["id_finca_socio"]) is DBNull ? 0 : Convert.ToInt32(reader["id_finca_socio"])
                        };

                        listaSocios.Add(socio);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener los datos: " + ex.Message);
            }
            finally
            {
                // Se cierra la conexión a la base de datos
                conexion.Desconectar();
            }
            return listaSocios;
        }

        // Función para obtener un registro específico por su id_socio en la tabla Socio
        public Socio ObtenerSocioPorId(int idSocio)
        {
            Socio socio = null;

            try
            {
                // Conectar a la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el socio
                string consulta = "SELECT * FROM Socio WHERE id_socio = @Id";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@Id", idSocio);

                // Ejecutar la consulta y leer el resultado
                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows && reader.Read())
                    {
                        socio = new Socio()
                        {
                            IdSocio = Convert.ToInt32(reader["id_socio"]),
                            NombreSocio = Convert.ToString(reader["nombre_socio"]),
                            DescripcionSocio = Convert.ToString(reader["descripcion_socio"]),
                            UbicacionSocio = Convert.ToString(reader["ubicacion_socio"]),
                            IdPersonaRespSocio = Convert.ToInt32(reader["id_persona_resp_socio"]),
                            IdFincaSocio = Convert.ToInt32(reader["id_finca_socio"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el Socio: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }

            return socio;
        }

        // Función para actualizar un registro en la tabla Socio
        public bool ActualizarSocio(int idSocio, string nombre, string descripcion, string ubicacion, int idPersonaResp, int ifinca)
        {
            bool exito = false;

            try
            {
                // Conectar a la base de datos
                conexion.Conectar();

                // Crear el script SQL para actualizar
                string consulta = @"UPDATE Socio SET nombre_socio = @nombre, descripcion_socio = @descripcion,
                            ubicacion_socio = @ubicacion, id_persona_resp_socio = @idPersonaResp, id_finca_socio = @iFinca
                            WHERE id_socio = @id";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@nombre", nombre);
                conexion.AgregarParametro("@descripcion", descripcion);
                conexion.AgregarParametro("@ubicacion", ubicacion);
                conexion.AgregarParametro("@idPersonaResp", idPersonaResp);
                conexion.AgregarParametro("@iFinca", ifinca);
                conexion.AgregarParametro("@id", idSocio);

                int filasAfectadas = conexion.EjecutarInstruccion();

                if (filasAfectadas > 0)
                {
                    Console.WriteLine("La actualización se realizó correctamente");
                    exito = true;
                }
                else
                {
                    Console.WriteLine("No se pudo realizar la actualización");
                    exito = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al actualizar los datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }

            return exito;
        }

        // Función para eliminar un registro de la tabla Socio
        public void EliminarSocio(int idSocio)
        {
            try
            {
                // Conectar a la base de datos
                conexion.Conectar();

                // Crear el script SQL
                string consulta = @"DELETE FROM Socio WHERE id_socio = @id";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@id", idSocio);

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

        //
        public List<Socio> ObtenerSocioNombrePersona()
        {
            List<Socio> socios = new List<Socio>();

            try
            {
                //Se conecta con la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el rol
                string consulta = @"SELECT s.*, p.nombres_persona, f.nombre_finca
                            FROM Socio s
                            INNER JOIN Persona p ON s.id_persona_resp_socio = p.id_persona
                            INNER JOIN Finca f ON s.id_finca_socio = f.id_finca";

                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Socio socio = new Socio()
                        {
                            IdSocio = Convert.ToInt32(reader["id_socio"]),
                            NombreSocio = Convert.ToString(reader["nombre_socio"]),
                            DescripcionSocio = Convert.ToString(reader["descripcion_socio"]),
                            UbicacionSocio = Convert.ToString(reader["ubicacion_socio"]),
                            IdPersonaRespSocio = Convert.ToInt32(reader["id_persona_resp_socio"]),
                            NombrePersonaResp = Convert.ToString(reader["nombres_persona"]),
                            IdFincaSocio = Convert.ToInt32(reader["id_finca_socio"]),
                            NombreFinca = Convert.ToString(reader["nombre_finca"])
                        };

                        socios.Add(socio);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error al obtener los datos: " + ex.Message);
            }
            finally
            {
                //se cierra la conexion a la base de datos
                conexion.Desconectar();
            }
            return socios;
        }

        //
        public List<Socio> BuscarSocio(string buscar)
        {
            List<Socio> socios = new List<Socio>();

            try
            {
                //Se conecta con la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el rol
                string consulta = @"SELECT s.*, p.nombres_persona, f.nombre_finca
                            FROM Socio s
                            INNER JOIN Persona p ON s.id_persona_resp_socio = p.id_persona
                            INNER JOIN Finca f ON s.id_finca_socio = f.id_finca
                            WHERE s.nombre_socio LIKE CONCAT('%', @search, '%') OR s.ubicacion_socio LIKE CONCAT('%', @search, '%') 
                                    OR p.nombres_persona LIKE CONCAT('%', @search, '%') OR f.nombre_finca LIKE CONCAT('%', @search, '%')";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@search", "%" + buscar + "%");

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Socio socio = new Socio()
                        {
                            IdSocio = Convert.ToInt32(reader["id_socio"]),
                            NombreSocio = Convert.ToString(reader["nombre_socio"]),
                            DescripcionSocio = Convert.ToString(reader["descripcion_socio"]),
                            UbicacionSocio = Convert.ToString(reader["ubicacion_socio"]),
                            IdPersonaRespSocio = Convert.ToInt32(reader["id_persona_resp_socio"]),
                            NombrePersonaResp = Convert.ToString(reader["nombres_persona"]),
                            IdFincaSocio = Convert.ToInt32(reader["id_finca_socio"]),
                            NombreFinca = Convert.ToString(reader["nombre_finca"])
                        };

                        socios.Add(socio);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error al obtener los datos: " + ex.Message);
            }
            finally
            {
                //se cierra la conexion a la base de datos
                conexion.Desconectar();
            }
            return socios;
        }

        //
        public Socio ObtenerSocioNombre(string nombre)
        {
            Socio socio = null;

            try
            {
                //Se conecta con la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el rol
                string consulta = @"SELECT s.*, p.nombres_persona, f.nombre_finca
                            FROM Socio s
                            INNER JOIN Persona p ON s.id_persona_resp_socio = p.id_persona
                            INNER JOIN Finca f ON s.id_finca_socio = f.id_finca
                            WHERE s.nombre_socio = @nombreS";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@nombreS", nombre);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows && reader.Read())
                    {
                        socio = new Socio()
                        {
                            IdSocio = Convert.ToInt32(reader["id_socio"]),
                            NombreSocio = Convert.ToString(reader["nombre_socio"]),
                            DescripcionSocio = Convert.ToString(reader["descripcion_socio"]),
                            UbicacionSocio = Convert.ToString(reader["ubicacion_socio"]),
                            IdPersonaRespSocio = Convert.ToInt32(reader["id_persona_resp_socio"]),
                            NombrePersonaResp = Convert.ToString(reader["nombres_persona"]),
                            IdFincaSocio = (reader["id_finca_socio"]) is DBNull ? 0 : Convert.ToInt32(reader["id_finca_socio"]),
                            NombreFinca = (reader["nombre_finca"]) is DBNull ? "" : Convert.ToString(reader["nombre_finca"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error al obtener los datos: " + ex.Message);
            }
            finally
            {
                //se cierra la conexion a la base de datos
                conexion.Desconectar();
            }
            return socio;
        }


    }
}
