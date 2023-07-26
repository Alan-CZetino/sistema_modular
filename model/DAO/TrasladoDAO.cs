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
    class TrasladoDAO
    {
        private ConnectionDB conexion;

        public TrasladoDAO()
        {
            //Se crea la instancia de la clase conexion
            conexion = new ConnectionDB();
        }

        // Función para insertar un nuevo registro en la base de datos
        public bool InsertarTrasladoCafe(Traslado traslado)
        {
            try
            {
                // Conexión a la base de datos (asegúrate de tener la clase "conexion" y los métodos correspondientes)
                conexion.Conectar();

                // Se crea el script SQL para insertar
                string consulta = @"INSERT INTO Traslado_Cafe (
                                    id_cosecha_traslado, id_subpartida_traslado, id_procedencia_traslado, id_destino_traslado, 
                                    id_calidad_cafe_traslado, id_subproducto_traslado, cantidad_traslado_qqs_cafe, cantidad_traslado_sacos_cafe, 
                                    fecha_trasladoCafe, id_personal_traslado, observacion_traslado)
                                VALUES (
                                    @idCosecha, @idSubPartida, @idProcedencia, @idDestino, @idCalidadCafe, @idSubProducto, @cantidadQQs, @cantidadSacos,
                                    @fechaTraslado, @idPersonal, @observacion)";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@idCosecha", traslado.IdCosecha);
                conexion.AgregarParametro("@idSubPartida", traslado.IdSubPartida);
                conexion.AgregarParametro("@idProcedencia", traslado.IdProcedencia);
                conexion.AgregarParametro("@idDestino", traslado.IdDestino);
                conexion.AgregarParametro("@idCalidadCafe", traslado.IdCalidadCafe);
                conexion.AgregarParametro("@idSubProducto", traslado.IdSubProducto);
                conexion.AgregarParametro("@cantidadQQs", traslado.CantidadTrasladoQQs);
                conexion.AgregarParametro("@cantidadSacos", traslado.CantidadTrasladoSacos);
                conexion.AgregarParametro("@fechaTraslado", traslado.FechaTrasladoCafe);
                conexion.AgregarParametro("@idPersonal", traslado.IdPersonal);
                conexion.AgregarParametro("@observacion", traslado.ObservacionTraslado);

                int filasAfectadas = conexion.EjecutarInstruccion();

                // Si la fila se afecta, se insertó correctamente
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la inserción del TrasladoCafe en la base de datos: " + ex.Message);
                return false;
            }
            finally
            {
                // Se cierra la conexión a la base de datos
                conexion.Desconectar();
            }
        }

        // Función para actualizar un registro en la base de datos
        public bool ActualizarTrasladoCafe(Traslado traslado)
        {
            bool exito = false;

            try
            {
                // Conexión a la base de datos (asegúrate de tener la clase "conexion" y los métodos correspondientes)
                conexion.Conectar();

                // Se crea el script SQL para actualizar
                string consulta = @"UPDATE Traslado_Cafe 
                                SET id_cosecha_traslado = @idCosecha,
                                    id_subpartida_traslado = @idSubPartida,
                                    id_procedencia_traslado = @idProcedencia,
                                    id_destino_traslado = @idDestino,
                                    id_calidad_cafe_traslado = @idCalidadCafe,
                                    id_subproducto_traslado = @idSubProducto,
                                    cantidad_traslado_qqs_cafe = @cantidadTrasladoQQs,
                                    cantidad_traslado_sacos_cafe = @cantidadTrasladoSacos,
                                    fecha_trasladoCafe = @fechaTraslado,
                                    id_personal_traslado = @idPersonal,
                                    observacion_traslado = @observacionTraslado
                                WHERE id_traslado_cafe = @id";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@idCosecha", traslado.IdCosecha);
                conexion.AgregarParametro("@idSubPartida", traslado.IdSubPartida);
                conexion.AgregarParametro("@idProcedencia", traslado.IdProcedencia);
                conexion.AgregarParametro("@idDestino", traslado.IdDestino);
                conexion.AgregarParametro("@idCalidadCafe", traslado.IdCalidadCafe);
                conexion.AgregarParametro("@idSubProducto", traslado.IdSubProducto);
                conexion.AgregarParametro("@cantidadTrasladoQQs", traslado.CantidadTrasladoQQs);
                conexion.AgregarParametro("@cantidadTrasladoSacos", traslado.CantidadTrasladoSacos);
                conexion.AgregarParametro("@fechaTraslado", traslado.FechaTrasladoCafe);
                conexion.AgregarParametro("@idPersonal", traslado.IdPersonal);
                conexion.AgregarParametro("@observacionTraslado", traslado.ObservacionTraslado);
                conexion.AgregarParametro("@id", traslado.Idtraslado_cafe);

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

        //funcion para eliminar un registro de la base de datos
        public void EliminarTraslado(int idTraslado)
        {
            try
            {
                //conexion a la base de datos
                conexion.Conectar();

                //se crea script SQL
                string consulta = @"DELETE FROM Traslado_Cafe WHERE id_traslado_cafe = @id";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@id", idTraslado);

                int filasAfectadas = conexion.EjecutarInstruccion();

                if (filasAfectadas > 0)
                {
                    Console.WriteLine("El registro se elimino correctamente");
                }
                else
                {
                    Console.WriteLine("No se encontró el registro a eliminar");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el registro" + ex.Message);
            }
            finally
            {
                //se cierra la conexion con la base de datos
                conexion.Desconectar();
            }
        }

        // Función para buscar trillas
        public List<Traslado> BuscarTrasladoCafe(string buscar)
        {
            List<Traslado> traslados = new List<Traslado>();

            try
            {
                // Conexión a la base de datos (asegúrate de tener la clase "conexion" y los métodos correspondientes)
                conexion.Conectar();

                // Crear la consulta SQL para buscar trillas
                string consulta = @"SELECT t.*, c.nombre_cosecha, sp.nombre_subpartida, pd.nombre_procedencia,
                                    pd2.nombre_procedencia as nombre_destino, cc.nombre_calidad_cafe,
                                    sbp.nombre_subproducto, p.nombre_personal
                               FROM Traslado_Cafe t
                               INNER JOIN Cosecha c ON t.id_cosecha_traslado = c.id_cosecha
                               INNER JOIN SubPartida sp ON t.id_subpartida_traslado = sp.id_subpartida
                               INNER JOIN Procedencia_Destino_Cafe pd ON t.id_procedencia_traslado = pd.id_procedencia
                               INNER JOIN Procedencia_Destino_Cafe pd2 ON t.id_destino_traslado = pd2.id_procedencia
                               INNER JOIN Calidad_Cafe cc ON t.id_calidad_cafe_traslado = cc.id_calidad
                               INNER JOIN SubProducto sbp ON t.id_subproducto_traslado = sbp.id_subproducto
                               INNER JOIN Personal p ON t.id_personal_traslado = p.id_personal
                               WHERE c.nombre_cosecha LIKE CONCAT('%', @search, '%') OR
                                     sp.nombre_subpartida LIKE CONCAT('%', @search, '%') OR
                                     pd.nombre_procedencia LIKE CONCAT('%', @search, '%') OR
                                     pd2.nombre_procedencia LIKE CONCAT('%', @search, '%') OR
                                     cc.nombre_calidad_cafe LIKE CONCAT('%', @search, '%') OR
                                     sbp.nombre_subproducto LIKE CONCAT('%', @search, '%') OR
                                     t.tipo_movimiento_traslado LIKE CONCAT('%', @search, '%') OR
                                     p.nombre_personal LIKE CONCAT('%', @search, '%')";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@search", buscar);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Traslado traslado = new Traslado()
                        {
                            Idtraslado_cafe = Convert.ToInt32(reader["id_traslado_cafe"]),
                            IdCosecha = Convert.ToInt32(reader["id_cosecha_traslado"]),
                            NombreCosecha = Convert.ToString(reader["nombre_cosecha"]),
                            IdSubPartida = Convert.ToInt32(reader["id_subpartida_traslado"]),
                            NombreSubPartida = Convert.ToString(reader["nombre_subpartida"]),
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia_traslado"]),
                            NombreProcedencia = Convert.ToString(reader["nombre_procedencia"]),
                            IdDestino = Convert.ToInt32(reader["id_destino_traslado"]),
                            NombreDestino = Convert.ToString(reader["nombre_destino"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe_traslado"]),
                            NombreCalidadCafe = Convert.ToString(reader["nombre_calidad_cafe"]),
                            IdSubProducto = Convert.ToInt32(reader["id_subproducto_traslado"]),
                            NombreSubProducto = Convert.ToString(reader["nombre_subproducto"]),
                            CantidadTrasladoQQs = Convert.ToDouble(reader["cantidad_traslado_qqs_cafe"]),
                            CantidadTrasladoSacos = Convert.ToDouble(reader["cantidad_traslado_sacos_cafe"]),
                            FechaTrasladoCafe = Convert.ToDateTime(reader["fecha_trasladoCafe"]),
                            IdPersonal = Convert.ToInt32(reader["id_personal_traslado"]),
                            NombrePersonal = Convert.ToString(reader["nombre_personal"]),
                            ObservacionTraslado = Convert.ToString(reader["observacion_traslado"])
                        };

                        traslados.Add(traslado);
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

            return traslados;
        }

        // Función para obtener todos los registros de Traslado_Cafe en la base de datos
        public List<Traslado> ObtenerTrasladosCafe()
        {
            List<Traslado> listaTraslados = new List<Traslado>();

            try
            {
                // Conexión a la base de datos (asegúrate de tener la clase "conexion" y los métodos correspondientes)
                conexion.Conectar();

                string consulta = "SELECT * FROM Traslado_Cafe";
                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Traslado traslado = new Traslado()
                        {
                            Idtraslado_cafe = Convert.ToInt32(reader["id_traslado_cafe"]),
                            IdCosecha = Convert.ToInt32(reader["id_cosecha_traslado"]),
                            IdSubPartida = Convert.ToInt32(reader["id_subpartida_traslado"]),
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia_traslado"]),
                            IdDestino = Convert.ToInt32(reader["id_destino_traslado"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe_traslado"]),
                            IdSubProducto = Convert.ToInt32(reader["id_subproducto_traslado"]),
                            CantidadTrasladoQQs = Convert.ToDouble(reader["cantidad_traslado_qqs_cafe"]),
                            CantidadTrasladoSacos = Convert.ToDouble(reader["cantidad_traslado_sacos_cafe"]),
                            FechaTrasladoCafe = Convert.ToDateTime(reader["fecha_trasladoCafe"]),
                            IdPersonal = Convert.ToInt32(reader["id_personal_traslado"]),
                            ObservacionTraslado = Convert.ToString(reader["observacion_traslado"])
                        };

                        listaTraslados.Add(traslado);
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

            return listaTraslados;
        }

        // Función para obtener un registro de Traslado_Cafe por su ID
        public Traslado ObtenerTrasladoCafePorID(int idTraslado)
        {
            Traslado traslado = null;

            try
            {
                // Conexión a la base de datos (asegúrate de tener la clase "conexion" y los métodos correspondientes)
                conexion.Conectar();

                string consulta = "SELECT * FROM Traslado_Cafe WHERE id_traslado_cafe = @Id";
                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@Id", idTraslado);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows && reader.Read())
                    {
                        traslado = new Traslado()
                        {
                            Idtraslado_cafe = Convert.ToInt32(reader["id_traslado_cafe"]),
                            IdCosecha = Convert.ToInt32(reader["id_cosecha_traslado"]),
                            IdSubPartida = Convert.ToInt32(reader["id_subpartida_traslado"]),
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia_traslado"]),
                            IdDestino = Convert.ToInt32(reader["id_destino_traslado"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe_traslado"]),
                            IdSubProducto = Convert.ToInt32(reader["id_subproducto_traslado"]),
                            CantidadTrasladoQQs = Convert.ToDouble(reader["cantidad_traslado_qqs_cafe"]),
                            CantidadTrasladoSacos = Convert.ToDouble(reader["cantidad_traslado_sacos_cafe"]),
                            FechaTrasladoCafe = Convert.ToDateTime(reader["fecha_trasladoCafe"]),
                            IdPersonal = Convert.ToInt32(reader["id_personal_traslado"]),
                            ObservacionTraslado = Convert.ToString(reader["observacion_traslado"])
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

            return traslado;
        }

        // Función para obtener todos los registros de TrasladoCafe con sus respectivos nombres de referencias
        public List<Traslado> ObtenerTrasladosCafeNombres()
        {
            List<Traslado> listaTraslados = new List<Traslado>();

            try
            {
                // Conexión a la base de datos (asegúrate de tener la clase "conexion" y los métodos correspondientes)
                conexion.Conectar();

                string consulta = @"SELECT tc.*,
                                       c.nombre_cosecha,
                                       sp.nombre_subpartida,
                                       pd.nombre_procedencia,
                                       pd2.nombre_procedencia AS nombre_destino,
                                       cc.nombre_calidad_cafe,
                                       sbp.nombre_subproducto,
                                       p.nombre_personal
                                FROM Traslado_Cafe tc
                                INNER JOIN Cosecha c ON tc.id_cosecha_traslado = c.id_cosecha
                                INNER JOIN SubPartida sp ON tc.id_subpartida_traslado = sp.id_subpartida
                                INNER JOIN Procedencia_Destino_Cafe pd ON tc.id_procedencia_traslado = pd.id_procedencia
                                INNER JOIN Procedencia_Destino_Cafe pd2 ON tc.id_destino_traslado = pd2.id_procedencia
                                INNER JOIN Calidad_Cafe cc ON tc.id_calidad_cafe_traslado = cc.id_calidad
                                INNER JOIN SubProducto sbp ON tc.id_subproducto_traslado = sbp.id_subproducto
                                INNER JOIN Personal p ON tc.id_personal_traslado = p.id_personal";

                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Traslado traslado = new Traslado()
                        {
                            Idtraslado_cafe = Convert.ToInt32(reader["id_traslado_cafe"]),
                            IdCosecha = Convert.ToInt32(reader["id_cosecha_traslado"]),
                            NombreCosecha = Convert.ToString(reader["nombre_cosecha"]),
                            IdSubPartida = Convert.ToInt32(reader["id_subpartida_traslado"]),
                            NombreSubPartida = Convert.ToString(reader["nombre_subpartida"]),
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia_traslado"]),
                            NombreProcedencia = Convert.ToString(reader["nombre_procedencia"]),
                            IdDestino = Convert.ToInt32(reader["id_destino_traslado"]),
                            NombreDestino = Convert.ToString(reader["nombre_destino"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe_traslado"]),
                            NombreCalidadCafe = Convert.ToString(reader["nombre_calidad_cafe"]),
                            IdSubProducto = Convert.ToInt32(reader["id_subproducto_traslado"]),
                            NombreSubProducto = Convert.ToString(reader["nombre_subproducto"]),
                            CantidadTrasladoQQs = Convert.ToDouble(reader["cantidad_traslado_qqs_cafe"]),
                            CantidadTrasladoSacos = Convert.ToDouble(reader["cantidad_traslado_sacos_cafe"]),
                            FechaTrasladoCafe = Convert.ToDateTime(reader["fecha_trasladoCafe"]),
                            IdPersonal = Convert.ToInt32(reader["id_personal_traslado"]),
                            NombrePersonal = Convert.ToString(reader["nombre_personal"]),
                            ObservacionTraslado = Convert.ToString(reader["observacion_traslado"])
                        };

                        listaTraslados.Add(traslado);
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

            return listaTraslados;
        }
    }
}
