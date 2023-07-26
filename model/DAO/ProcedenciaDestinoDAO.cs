using MySql.Data.MySqlClient;
using sistema_modular_cafe_majada.model.Connection;
using sistema_modular_cafe_majada.model.Mapping.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.DAO
{
    class ProcedenciaDestinoDAO
    {
        private ConnectionDB conexion;

        public ProcedenciaDestinoDAO()
        {
            //Se crea la instancia de la clase conexion
            conexion = new ConnectionDB();
        }

        // Función para insertar un nuevo registro en la tabla Procedencia_Destino_Cafe
        public bool InsertarProcedenciaDestino(ProcedenciaDestino procedenciaDestino)
        {
            try
            {
                // Conexión a la base de datos
                conexion.Conectar();

                // Se crea el script SQL para insertar
                string consulta = @"INSERT INTO Procedencia_Destino_Cafe (
                                        nombre_procedencia,
                                        descripcion_procedencia,
                                        id_benficio_ubicacion_procedencia,
                                        id_socio_procedencia,
                                        id_maquinaria_procedencia
                                    ) VALUES (
                                        @nombreProcedencia,
                                        @descripcionProcedencia,
                                        @idBeneficioUbicacion,
                                        @idSocio,
                                        @idMaquinaria
                                    )";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@nombreProcedencia", procedenciaDestino.NombreProcedencia);
                conexion.AgregarParametro("@descripcionProcedencia", procedenciaDestino.DescripcionProcedencia);
                conexion.AgregarParametro("@idBeneficioUbicacion", procedenciaDestino.IdBenficioUbicacion);
                conexion.AgregarParametro("@idSocio", procedenciaDestino.IdSocioProcedencia);
                conexion.AgregarParametro("@idMaquinaria", procedenciaDestino.IdMaquinaria);

                int filasAfectadas = conexion.EjecutarInstruccion();

                // Si se afecta una fila, se insertó correctamente
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la inserción de la Procedencia/Destino en la base de datos: " + ex.Message);
                return false;
            }
            finally
            {
                // Se cierra la conexión a la base de datos
                conexion.Desconectar();
            }
        }

        // Función para actualizar un registro en la tabla Procedencia_Destino_Cafe
        public bool ActualizarProcedenciaDestino(ProcedenciaDestino procedenciaDestino)
        {
            bool exito = false;

            try
            {
                // Conexión a la base de datos
                conexion.Conectar();

                // Se crea el script SQL para actualizar
                string consulta = @"UPDATE Procedencia_Destino_Cafe 
                            SET nombre_procedencia = @nombreProcedencia,
                                descripcion_procedencia = @descripcionProcedencia,
                                id_benficio_ubicacion_procedencia = @idBeneficioUbicacion,
                                id_socio_procedencia = @idSocioProcedencia,
                                id_maquinaria_procedencia = @idMaquinaria
                            WHERE id_procedencia = @id";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@nombreProcedencia", procedenciaDestino.NombreProcedencia);
                conexion.AgregarParametro("@descripcionProcedencia", procedenciaDestino.DescripcionProcedencia);
                conexion.AgregarParametro("@idBeneficioUbicacion", procedenciaDestino.IdBenficioUbicacion);
                conexion.AgregarParametro("@idSocioProcedencia", procedenciaDestino.IdSocioProcedencia);
                conexion.AgregarParametro("@idMaquinaria", procedenciaDestino.IdMaquinaria);
                conexion.AgregarParametro("@id", procedenciaDestino.IdProcedencia);

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
                // Se cierra la conexión a la base de datos
                conexion.Desconectar();
            }

            return exito;
        }

        // Función para eliminar un registro de la tabla Procedencia_Destino_Cafe
        public bool EliminarProcedenciaDestino(int idProcedencia)
        {
            bool exito = false;

            try
            {
                // Conexión a la base de datos
                conexion.Conectar();

                // Se crea el script SQL para eliminar
                string consulta = @"DELETE FROM Procedencia_Destino_Cafe 
                            WHERE id_procedencia = @id";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@id", idProcedencia);

                int filasAfectadas = conexion.EjecutarInstruccion();

                if (filasAfectadas > 0)
                {
                    Console.WriteLine("El registro se eliminó correctamente");
                    exito = true;
                }
                else
                {
                    Console.WriteLine("No se pudo eliminar el registro");
                    exito = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al eliminar el registro: " + ex.Message);
            }
            finally
            {
                // Se cierra la conexión a la base de datos
                conexion.Desconectar();
            }

            return exito;
        }

        // Función para obtener todos los registros de la tabla Procedencia_Destino_Cafe
        public List<ProcedenciaDestino> ObtenerProcedenciasDestino()
        {
            List<ProcedenciaDestino> listaProcedenciasDestino = new List<ProcedenciaDestino>();

            try
            {
                // Conexión a la base de datos
                conexion.Conectar();

                string consulta = "SELECT * FROM Procedencia_Destino_Cafe";
                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        ProcedenciaDestino procedenciaDestino = new ProcedenciaDestino()
                        {
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia"]),
                            NombreProcedencia = Convert.ToString(reader["nombre_procedencia"]),
                            DescripcionProcedencia = Convert.ToString(reader["descripcion_procedencia"]),
                            IdBenficioUbicacion = Convert.ToInt32(reader["id_benficio_ubicacion_procedencia"]),
                            IdSocioProcedencia = Convert.ToInt32(reader["id_socio_procedencia"]),
                            IdMaquinaria = Convert.ToInt32(reader["id_maquinaria_procedencia"])
                        };

                        listaProcedenciasDestino.Add(procedenciaDestino);
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

            return listaProcedenciasDestino;
        }

        // Función para obtener todos los registros de la tabla Procedencia_Destino_Cafe
        public List<ProcedenciaDestino> ObtenerProcedenciasDestinoNombres()
        {
            List<ProcedenciaDestino> listaProcedenciasDestino = new List<ProcedenciaDestino>();

            try
            {
                // Conexión a la base de datos
                conexion.Conectar();

                string consulta = @"SELECT pd.*,
                                           b.nombre_beneficio,
                                           s.nombre_socio,
                                           m.nombre_maquinaria
                                    FROM Procedencia_Destino_Cafe pd
                                    INNER JOIN Beneficio b ON pd.id_benficio_ubicacion_procedencia = b.id_beneficio
                                    INNER JOIN Socio s ON pd.id_socio_procedencia = s.id_socio
                                    INNER JOIN Maquinaria m ON pd.id_maquinaria_procedencia = m.id_maquinaria";

                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        ProcedenciaDestino procedenciaDestino = new ProcedenciaDestino()
                        {
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia"]),
                            NombreProcedencia = Convert.ToString(reader["nombre_procedencia"]),
                            DescripcionProcedencia = Convert.ToString(reader["descripcion_procedencia"]),
                            IdBenficioUbicacion = Convert.ToInt32(reader["id_benficio_ubicacion_procedencia"]),
                            NombreBenficioUbicacion = Convert.ToString(reader["nombre_benficio_ubicacion"]),
                            IdSocioProcedencia = Convert.ToInt32(reader["id_socio_procedencia"]),
                            NombreSocioProcedencia = Convert.ToString(reader["nombre_socio_procedencia"]),
                            IdMaquinaria = Convert.ToInt32(reader["id_maquinaria_procedencia"]),
                            NombreMaquinaria = Convert.ToString(reader["nombre_maquinaria"])
                        };

                        listaProcedenciasDestino.Add(procedenciaDestino);
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

            return listaProcedenciasDestino;
        }

        // Función para obtener un registro de la tabla Procedencia_Destino_Cafe por ID
        public ProcedenciaDestino ObtenerProcedenciaDestinoPorId(int idProcedencia)
        {
            ProcedenciaDestino procedenciaDestino = null;

            try
            {
                // Conexión a la base de datos
                conexion.Conectar();

                string consulta = "SELECT * FROM Procedencia_Destino_Cafe WHERE id_procedencia = @id";
                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@id", idProcedencia);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.Read())
                    {
                        procedenciaDestino = new ProcedenciaDestino()
                        {
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia"]),
                            NombreProcedencia = Convert.ToString(reader["nombre_procedencia"]),
                            DescripcionProcedencia = Convert.ToString(reader["descripcion_procedencia"]),
                            IdBenficioUbicacion = Convert.ToInt32(reader["id_benficio_ubicacion_procedencia"]),
                            IdSocioProcedencia = Convert.ToInt32(reader["id_socio_procedencia"]),
                            IdMaquinaria = Convert.ToInt32(reader["id_maquinaria_procedencia"])
                        };
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

            return procedenciaDestino;
        }

        //
        public List<ProcedenciaDestino> BuscarProcedenciaDestino(string buscar)
        {
            List<ProcedenciaDestino> procedencias = new List<ProcedenciaDestino>();

            try
            {
                // Conexión a la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para buscar procedencias
                string consulta = @"SELECT pd.*,
                                           b.nombre_beneficio AS nombre_benficio_ubicacion,
                                           s.nombre_socio AS nombre_socio_procedencia,
                                           m.nombre_maquinaria AS nombre_maquinaria_procedencia
                                    FROM Procedencia_Destino_Cafe pd
                                    INNER JOIN Beneficio b ON pd.id_benficio_ubicacion_procedencia = b.id_beneficio
                                    INNER JOIN Socio s ON pd.id_socio_procedencia = s.id_socio
                                    INNER JOIN Maquinaria m ON pd.id_maquinaria_procedencia = m.id_maquinaria
                                    WHERE pd.nombre_procedencia LIKE CONCAT('%', @search, '%')
                                       OR b.nombre_beneficio LIKE CONCAT('%', @search, '%')
                                       OR s.nombre_socio LIKE CONCAT('%', @search, '%')
                                       OR m.nombre_maquinaria LIKE CONCAT('%', @search, '%')";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@search", buscar);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        ProcedenciaDestino procedencia = new ProcedenciaDestino()
                        {
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia"]),
                            NombreProcedencia = Convert.ToString(reader["nombre_procedencia"]),
                            DescripcionProcedencia = Convert.ToString(reader["descripcion_procedencia"]),
                            IdBenficioUbicacion = Convert.ToInt32(reader["id_benficio_ubicacion_procedencia"]),
                            NombreBenficioUbicacion = Convert.ToString(reader["nombre_benficio_ubicacion"]),
                            IdSocioProcedencia = Convert.ToInt32(reader["id_socio_procedencia"]),
                            NombreSocioProcedencia = Convert.ToString(reader["nombre_socio_procedencia"]),
                            IdMaquinaria = Convert.ToInt32(reader["id_maquinaria_procedencia"]),
                            NombreMaquinaria = Convert.ToString(reader["nombre_maquinaria_procedencia"])
                        };

                        procedencias.Add(procedencia);
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

            return procedencias;
        }

    }
}
