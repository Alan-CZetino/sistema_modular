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
    class SalidaDAO
    {
        private ConnectionDB conexion;

        public SalidaDAO()
        {
            //Se crea la instancia de la clase conexion
            conexion = new ConnectionDB();
        }

        //funcion para insertar un nuevo registro en la base de datos
        public bool InsertarSalidaCafe(Salida salidaCafe)
        {
            try
            {
                //conexion a la base de datos (asumiendo que tienes una clase llamada "conexion" que maneja la conexión y ejecución de consultas)
                conexion.Conectar();

                //se crea script SQL para insertar
                string consulta = @"INSERT INTO Salida_Cafe (id_cosecha_salida, id_subpartida_salida, id_procedencia_salida, id_calidad_cafe_salida,
                                        id_subproducto_salida, tipo_salida, cantidad_salida_qqs_cafe, cantidad_salida_sacos_cafe, fecha_salidaCafe,
                                        id_personal_salida, observacion_salida )
                                    VALUES ( @idCosecha, @idSubPartida, @idProcedencia, @idCalidadCafe, @idSubProducto, @tipoSalida,
                                                @cantidadSalidaQQs, @cantidadSalidaSacos, @fechaSalidaCafe, @idPersonal, @observacionSalida)";
                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@idCosecha", salidaCafe.IdCosecha);
                conexion.AgregarParametro("@idSubPartida", salidaCafe.IdSubPartida);
                conexion.AgregarParametro("@idProcedencia", salidaCafe.IdProcedencia);
                conexion.AgregarParametro("@idCalidadCafe", salidaCafe.IdCalidadCafe);
                conexion.AgregarParametro("@idSubProducto", salidaCafe.IdSubProducto);
                conexion.AgregarParametro("@tipoSalida", salidaCafe.TipoSalida);
                conexion.AgregarParametro("@cantidadSalidaQQs", salidaCafe.CantidadSalidaQQs);
                conexion.AgregarParametro("@cantidadSalidaSacos", salidaCafe.CantidadSalidaSacos);
                conexion.AgregarParametro("@fechaSalidaCafe", salidaCafe.FechaSalidaCafe);
                conexion.AgregarParametro("@idPersonal", salidaCafe.IdPersonal);
                conexion.AgregarParametro("@observacionSalida", salidaCafe.ObservacionSalida);

                int filasAfectadas = conexion.EjecutarInstruccion();

                //si la fila se afecta, se insertó correctamente
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la inserción de la Salida de Café en la base de datos: " + ex.Message);
                return false;
            }
            finally
            {
                //Se cierra la conexión a la base de datos
                conexion.Desconectar();
            }
        }

        // Función para mostrar todas las salidas de café
        public List<Salida> ObtenerSalidasCafe()
        {
            List<Salida> listaSalidasCafe = new List<Salida>();

            try
            {
                // Conexión a la base de datos 
                conexion.Conectar();

                string consulta = @"SELECT * FROM Salida_Cafe";
                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Salida salidaCafe = new Salida()
                        {
                            IdSalida_cafe = Convert.ToInt32(reader["id_salida_cafe"]),
                            IdCosecha = Convert.ToInt32(reader["id_cosecha_salida"]),
                            IdSubPartida = Convert.ToInt32(reader["id_subpartida_salida"]),
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia_salida"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe_salida"]),
                            IdSubProducto = Convert.ToInt32(reader["id_subproducto_salida"]),
                            TipoSalida = Convert.ToString(reader["tipo_salida"]),
                            CantidadSalidaQQs = Convert.ToDouble(reader["cantidad_salida_qqs_cafe"]),
                            CantidadSalidaSacos = Convert.ToDouble(reader["cantidad_salida_sacos_cafe"]),
                            FechaSalidaCafe = Convert.ToDateTime(reader["fecha_salidaCafe"]),
                            IdPersonal = Convert.ToInt32(reader["id_personal_salida"]),
                            ObservacionSalida = Convert.ToString(reader["observacion_salida"])
                        };

                        listaSalidasCafe.Add(salidaCafe);
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
            return listaSalidasCafe;
        }

        // Función para obtener una salida de café por su ID
        public Salida ObtenerSalidaCafePorId(int idSalidaCafe)
        {
            Salida salidaCafe = null;

            try
            {
                // Conexión a la base de datos 
                conexion.Conectar();

                string consulta = "SELECT * FROM Salida_Cafe WHERE id_salida_cafe = @Id";
                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@Id", idSalidaCafe);

                // Ejecutar la consulta y leer el resultado
                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows && reader.Read())
                    {
                        salidaCafe = new Salida()
                        {
                            IdSalida_cafe = Convert.ToInt32(reader["id_salida_cafe"]),
                            IdCosecha = Convert.ToInt32(reader["id_cosecha_salida"]),
                            IdSubPartida = Convert.ToInt32(reader["id_subpartida_salida"]),
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia_salida"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe_salida"]),
                            IdSubProducto = Convert.ToInt32(reader["id_subproducto_salida"]),
                            TipoSalida = Convert.ToString(reader["tipo_salida"]),
                            CantidadSalidaQQs = Convert.ToDouble(reader["cantidad_salida_qqs_cafe"]),
                            CantidadSalidaSacos = Convert.ToDouble(reader["cantidad_salida_sacos_cafe"]),
                            FechaSalidaCafe = Convert.ToDateTime(reader["fecha_salidaCafe"]),
                            IdPersonal = Convert.ToInt32(reader["id_personal_salida"]),
                            ObservacionSalida = Convert.ToString(reader["observacion_salida"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la Salida de Café: " + ex.Message);
            }
            finally
            {
                // Se cierra la conexión a la base de datos
                conexion.Desconectar();
            }

            return salidaCafe;
        }

        // Función para obtener una salida de café por su ID
        public List<Salida> ObtenerSalidaCafeNombres()
        {
            List<Salida> salidaCafes = null;

            try
            {
                // Conexión a la base de datos 
                conexion.Conectar();

                string consulta = @"SELECT s.*, c.nombre_cosecha, spa.nombre_subpartida, pd.nombre_procedencia, cc.nombre_calidad, spo.nombre_subproducto pl.nombre_personal
                                    FROM Salida_Cafe s 
                                    INNER JOIN Cosecha c ON s.id_cosecha_salida = c.id_cosecha
                                    INNER JOIN SubPartida spa ON s.id_subpartida_salida = spa.id_subpartida
                                    INNER JOIN Procedencia_Destino_Cafe pd ON s.id_procedencia_salida = pd.id_procedencia
                                    INNER JOIN Calidad_Cafe cc ON s.id_calidad_cafe_salida = cc.id_calidad
                                    INNER JOIN SubProducto spo ON s.id_subproducto_salida = spo.id_subproducto
                                    INNER JOIN Personal pl ON s.id_personal_salida = pl.id_personal";
                conexion.CrearComando(consulta);

                // Ejecutar la consulta y leer el resultado
                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Salida salidaCafe = new Salida()
                        {
                            IdSalida_cafe = Convert.ToInt32(reader["id_salida_cafe"]),
                            IdCosecha = Convert.ToInt32(reader["id_cosecha_salida"]),
                            NombreCosecha = Convert.ToString(reader["nombre_cosecha"]),
                            IdSubPartida = Convert.ToInt32(reader["id_subpartida_salida"]),
                            NombreSubPartida = Convert.ToString(reader["nombre_subpartida"]),
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia_salida"]),
                            NombreProcedencia = Convert.ToString(reader["nombre_procedencia"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe_salida"]),
                            NombreCalidadCafe = Convert.ToString(reader["nombre_calidad_cafe"]),
                            IdSubProducto = Convert.ToInt32(reader["id_subproducto_salida"]),
                            NombreSubProducto = Convert.ToString(reader["nombre_subproducto"]),
                            TipoSalida = Convert.ToString(reader["tipo_salida"]),
                            CantidadSalidaQQs = Convert.ToDouble(reader["cantidad_salida_qqs_cafe"]),
                            CantidadSalidaSacos = Convert.ToDouble(reader["cantidad_salida_sacos_cafe"]),
                            FechaSalidaCafe = Convert.ToDateTime(reader["fecha_salidaCafe"]),
                            IdPersonal = Convert.ToInt32(reader["id_personal_salida"]),
                            NombrePersonal = Convert.ToString(reader["nombre_personal"]),
                            ObservacionSalida = Convert.ToString(reader["observacion_salida"])
                        };
                        salidaCafes.Add(salidaCafe);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la Salida de Café: " + ex.Message);
            }
            finally
            {
                // Se cierra la conexión a la base de datos
                conexion.Desconectar();
            }

            return salidaCafes;
        }

        // Función para actualizar un registro en la base de datos
        public bool ActualizarSalidaCafe(int idSalidaCafe, Salida salidaCafe)
        {
            bool exito = false;

            try
            {
                // Conexión a la base de datos 
                conexion.Conectar();

                // Se crea el script SQL para actualizar
                string consulta = @"
                UPDATE Salida_Cafe SET
                    id_cosecha_salida = @idCosecha,
                    id_subpartida_salida = @idSubPartida,
                    id_procedencia_salida = @idProcedencia,
                    id_calidad_cafe_salida = @idCalidadCafe,
                    id_subproducto_salida = @idSubProducto,
                    tipo_salida = @tipoSalida,
                    cantidad_salida_qqs_cafe = @cantidadSalidaQQs,
                    cantidad_salida_sacos_cafe = @cantidadSalidaSacos,
                    fecha_salidaCafe = @fechaSalidaCafe,
                    id_personal_salida = @idPersonal,
                    observacion_salida = @observacionSalida
                WHERE id_salida_cafe = @id";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@idCosecha", salidaCafe.IdCosecha);
                conexion.AgregarParametro("@idSubPartida", salidaCafe.IdSubPartida);
                conexion.AgregarParametro("@idProcedencia", salidaCafe.IdProcedencia);
                conexion.AgregarParametro("@idCalidadCafe", salidaCafe.IdCalidadCafe);
                conexion.AgregarParametro("@idSubProducto", salidaCafe.IdSubProducto);
                conexion.AgregarParametro("@tipoSalida", salidaCafe.TipoSalida);
                conexion.AgregarParametro("@cantidadSalidaQQs", salidaCafe.CantidadSalidaQQs);
                conexion.AgregarParametro("@cantidadSalidaSacos", salidaCafe.CantidadSalidaSacos);
                conexion.AgregarParametro("@fechaSalidaCafe", salidaCafe.FechaSalidaCafe);
                conexion.AgregarParametro("@idPersonal", salidaCafe.IdPersonal);
                conexion.AgregarParametro("@observacionSalida", salidaCafe.ObservacionSalida);
                conexion.AgregarParametro("@id", idSalidaCafe);

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

        // Función para eliminar un registro en la base de datos
        public bool EliminarSalidaCafe(int idSalidaCafe)
        {
            bool exito = false;

            try
            {
                // Conexión a la base de datos 
                conexion.Conectar();

                // Se crea el script SQL para eliminar
                string consulta = "DELETE FROM Salida_Cafe WHERE id_salida_cafe = @id";
                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@id", idSalidaCafe);

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

        // Función para buscar salidas de café
        public List<Salida> BuscarSalidaCafe(string buscar)
        {
            List<Salida> salidasCafe = new List<Salida>();

            try
            {
                // Conexión a la base de datos 
                conexion.Conectar();

                // Crear la consulta SQL para buscar salidas de café
                string consulta = @"
                SELECT s.*,
                       c.nombre_cosecha,
                       sp.nombre_subpartida,
                       pd.nombre_procedencia,
                       cc.nombre_calidad_cafe,
                       sbp.nombre_subproducto,
                       p.nombre_personal
                FROM Salida_Cafe s
                INNER JOIN Cosecha c ON s.id_cosecha_salida = c.id_cosecha
                INNER JOIN SubPartida sp ON s.id_subpartida_salida = sp.id_subpartida
                INNER JOIN Procedencia_Destino_Cafe pd ON s.id_procedencia_salida = pd.id_procedencia
                INNER JOIN Calidad_Cafe cc ON s.id_calidad_cafe_salida = cc.id_calidad
                INNER JOIN SubProducto sbp ON s.id_subproducto_salida = sbp.id_subproducto
                INNER JOIN Personal p ON s.id_personal_salida = p.id_personal
                WHERE c.nombre_cosecha LIKE CONCAT('%', @search, '%') OR
                      sp.nombre_subpartida LIKE CONCAT('%', @search, '%') OR
                      pd.nombre_procedencia LIKE CONCAT('%', @search, '%') OR
                      cc.nombre_calidad_cafe LIKE CONCAT('%', @search, '%') OR
                      sbp.nombre_subproducto LIKE CONCAT('%', @search, '%') OR
                      s.tipo_salida LIKE CONCAT('%', @search, '%') OR
                      p.nombre_personal LIKE CONCAT('%', @search, '%')";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@search", buscar);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Salida salidaCafe = new Salida()
                        {
                            IdSalida_cafe = Convert.ToInt32(reader["id_salida_cafe"]),
                            IdCosecha = Convert.ToInt32(reader["id_cosecha_salida"]),
                            NombreCosecha = Convert.ToString(reader["nombre_cosecha"]),
                            IdSubPartida = Convert.ToInt32(reader["id_subpartida_salida"]),
                            NombreSubPartida = Convert.ToString(reader["nombre_subpartida"]),
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia_salida"]),
                            NombreProcedencia = Convert.ToString(reader["nombre_procedencia"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe_salida"]),
                            NombreCalidadCafe = Convert.ToString(reader["nombre_calidad_cafe"]),
                            IdSubProducto = Convert.ToInt32(reader["id_subproducto_salida"]),
                            NombreSubProducto = Convert.ToString(reader["nombre_subproducto"]),
                            TipoSalida = Convert.ToString(reader["tipo_salida"]),
                            CantidadSalidaQQs = Convert.ToDouble(reader["cantidad_salida_qqs_cafe"]),
                            CantidadSalidaSacos = Convert.ToDouble(reader["cantidad_salida_sacos_cafe"]),
                            FechaSalidaCafe = Convert.ToDateTime(reader["fecha_salidaCafe"]),
                            IdPersonal = Convert.ToInt32(reader["id_personal_salida"]),
                            NombrePersonal = Convert.ToString(reader["nombre_personal"]),
                            ObservacionSalida = Convert.ToString(reader["observacion_salida"])
                        };

                        salidasCafe.Add(salidaCafe);
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
            return salidasCafe;
        }
    }
}
