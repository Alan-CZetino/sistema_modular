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
    class SubPartidaDAO
    {
        private ConnectionDB conexion;

        public SubPartidaDAO()
        {
            //Se crea la instancia de la clase conexion
            conexion = new ConnectionDB();
        }

        // Función para insertar un nuevo registro en la tabla SubPartida
        public bool InsertarSubPartida(SubPartida subPartida)
        {
            try
            {
                // Conexión a la base de datos
                conexion.Conectar();

                // Convertir TimeSpan a una cadena en formato de tiempo
                string tiempoSecadoFormatted = $"{(int)subPartida.TiempoSecado.TotalHours:00}:{subPartida.TiempoSecado.Minutes:00}:{subPartida.TiempoSecado.Seconds:00}";

                // Se crea el script SQL para insertar
                string consulta = @"INSERT INTO SubPartida (id_cosecha_subpartida, num_subpartida, id_procedencia_subpartida,
                                        id_calidad_cafe_subpartida,
                                        id_subproducto_subpartida,
                                        num1_semana_subpartida,
                                        num2_semana_subpartida,
                                        num3_semana_subpartida,
                                        dias1_subpartida,
                                        dias2_subpartida,
                                        dias3_subpartida,
                                        fecha1_subpartida,
                                        fecha2_subpartida,
                                        fecha3_subpartida,
                                        observacion_cafe_subpartida,
                                        fecha_carga_secado_subpartida,
                                        inicio_secado_subpartida,
                                        salida_punto_secado_subpartida,
                                        tiempo_secado_subpartida,
                                        humedad_secado_subpartida,
                                        rendimiento_subpartida,
                                        id_puntero_secado_subpartida,
                                        observacion_secado_subpartida,
                                        id_catador_subpartida,
                                        fecha_catacion_subpartida,
                                        observacion_catacion_subpartida,
                                        resultado_catacion_subpartida,
                                        fecha_pesado_subpartida,
                                        peso_saco_subpartida,
                                        peso_qqs_subpartida,
                                        id_almacen_subpartida,
                                        id_bodega_subpartida,
                                        id_pesador_subpartida,
                                        observacion_pesado_subpartida,
                                        docto_almacen_subpartida) VALUES (@idCosecha,
                                        @numSubParti,
                                        @idProcedencia,
                                        @idCalidadCafe,
                                        @idSubProducto,
                                        @num1Semana,
                                        @num2Semana,
                                        @num3Semana,
                                        @dias1,
                                        @dias2,
                                        @dias3,
                                        @fecha1,
                                        @fecha2,
                                        @fecha3,
                                        @observacionCafe,
                                        @fechaCargaSecado,
                                        @inicioSecado,
                                        @salidaPuntoSecado,
                                        @tiempoSecado,
                                        @humedadSecado,
                                        @rendimiento,
                                        @idPunteroSecado,
                                        @observacionSecado,
                                        @idCatador,
                                        @fechaCatacion,
                                        @observacionCatacion,
                                        @resultado,
                                        @fechaPesado,
                                        @pesoSaco,
                                        @pesoQQs,
                                        @idAlmacen,
                                        @idBodega,
                                        @idPesador,
                                        @observacionPesado,
                                        @docto)";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@idCosecha", subPartida.IdCosecha);
                conexion.AgregarParametro("@numSubParti", subPartida.NumeroSubpartida);
                conexion.AgregarParametro("@idProcedencia", subPartida.IdProcedencia);
                conexion.AgregarParametro("@idCalidadCafe", subPartida.IdCalidadCafe);
                conexion.AgregarParametro("@idSubProducto", subPartida.IdSubProducto);
                conexion.AgregarParametro("@num1Semana", subPartida.Num1Semana);
                conexion.AgregarParametro("@num2Semana", subPartida.Num2Semana);
                conexion.AgregarParametro("@num3Semana", subPartida.Num3Semana);
                conexion.AgregarParametro("@dias1", subPartida.Dias1SubPartida);
                conexion.AgregarParametro("@dias2", subPartida.Dias2SubPartida);
                conexion.AgregarParametro("@dias3", subPartida.Dias3SubPartida);
                conexion.AgregarParametro("@fecha1", subPartida.Fecha1SubPartida);
                conexion.AgregarParametro("@fecha2", subPartida.Fecha2SubPartida);
                conexion.AgregarParametro("@fecha3", subPartida.Fecha3SubPartida);
                conexion.AgregarParametro("@observacionCafe", subPartida.ObservacionIdentificacionCafe);
                conexion.AgregarParametro("@fechaCargaSecado", subPartida.FechaSecado);
                conexion.AgregarParametro("@inicioSecado", subPartida.InicioSecado);
                conexion.AgregarParametro("@salidaPuntoSecado", subPartida.SalidaSecado);
                conexion.AgregarParametro("@tiempoSecado", tiempoSecadoFormatted);
                conexion.AgregarParametro("@humedadSecado", subPartida.HumedadSecado);
                conexion.AgregarParametro("@rendimiento", subPartida.Rendimiento);
                conexion.AgregarParametro("@idPunteroSecado", subPartida.IdPunteroSecador);
                conexion.AgregarParametro("@observacionSecado", subPartida.ObservacionSecado);
                conexion.AgregarParametro("@idCatador", subPartida.IdCatador);
                conexion.AgregarParametro("@fechaCatacion", subPartida.FechaCatacion);
                conexion.AgregarParametro("@observacionCatacion", subPartida.ObservacionCatador);
                conexion.AgregarParametro("@resultado", subPartida.ResultadoCatador);
                conexion.AgregarParametro("@fechaPesado", subPartida.FechaPesado);
                conexion.AgregarParametro("@pesoSaco", subPartida.PesaSaco);
                conexion.AgregarParametro("@pesoQQs", subPartida.PesaQQs);
                conexion.AgregarParametro("@idAlmacen", subPartida.IdAlmacen);
                conexion.AgregarParametro("@idBodega", subPartida.IdBodega);
                conexion.AgregarParametro("@idPesador", subPartida.IdPesador);
                conexion.AgregarParametro("@observacionPesado", subPartida.ObservacionPesador);
                conexion.AgregarParametro("@docto", subPartida.DoctoAlmacen);

                int filasAfectadas = conexion.EjecutarInstruccion();

                // Si se afecta una fila, se insertó correctamente
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la inserción de la SubPartida en la base de datos: " + ex.Message);
                return false;
            }
            finally
            {
                // Se cierra la conexión a la base de datos
                conexion.Desconectar();
            }
        }

        // Función para actualizar un registro de la tabla SubPartida
        public bool ActualizarSubPartida(SubPartida subPartida)
        {
            bool exito = false;

            try
            {
                // Conexión a la base de datos
                conexion.Conectar();

                // Se crea el script SQL para actualizar
                string consulta = @"UPDATE SubPartida 
                                   SET id_cosecha_subpartida = @idCosecha,
                                    num_subpartida = @numSubParti,
                                    id_procedencia_subpartida = @idProcedencia,
                                    id_calidad_cafe_subpartida = @idCalidadCafe,
                                    id_subproducto_subpartida = @idSubProducto,
                                    num1_semana_subpartida = @num1Semana,
                                    num2_semana_subpartida = @num2Semana,
                                    num3_semana_subpartida = @num3Semana,
                                    dias1_subpartida = @dias1,
                                    dias2_subpartida = @dias2,
                                    dias3_subpartida = @dias3,
                                    fecha1_subpartida = @fecha1,
                                    fecha2_subpartida = @fecha2,
                                    fecha3_subpartida = @fecha3,
                                    observacion_cafe_subpartida = @observacionCafe,
                                    fecha_carga_secado_subpartida = @fechaCargaSecado,
                                    inicio_secado_subpartida = @inicioSecado,
                                    salida_punto_secado_subpartida = @salidaPuntoSecado,
                                    tiempo_secado_subpartida = @tiempoSecado,
                                    humedad_secado_subpartida = @humedadSecado,
                                    rendimiento_subpartida = @rendimiento,
                                    id_puntero_secado_subpartida = @idPunteroSecado,
                                    observacion_secado_subpartida = @observacionSecado,
                                    id_catador_subpartida = @idCatador,
                                    fecha_catacion_subpartida = @fechaCatacion,
                                    observacion_catacion_subpartida = @observacionCatacion,
                                    resultado_catacion_subpartida = @resultado,
                                    fecha_pesado_subpartida = @fechaPesado,
                                    peso_saco_subpartida = @pesoSaco,
                                    peso_qqs_subpartida = @pesoQQs,
                                    id_almacen_subpartida = @idAlmacen,
                                    id_bodega_subpartida = @idBodega,
                                    id_pesador_subpartida = @idPesador,
                                    observacion_pesado_subpartida = @observacionPesado,
                                    docto_almacen_subpartida = @docto
                                WHERE id_subpartida = @id";

                conexion.CrearComando(consulta);

                // Agregamos parámetros
                conexion.AgregarParametro("@idCosecha", subPartida.IdCosecha);
                conexion.AgregarParametro("@numSubParti", subPartida.NumeroSubpartida);
                conexion.AgregarParametro("@idProcedencia", subPartida.IdProcedencia);
                conexion.AgregarParametro("@idCalidadCafe", subPartida.IdCalidadCafe);
                conexion.AgregarParametro("@idSubProducto", subPartida.IdSubProducto);
                conexion.AgregarParametro("@num1Semana", subPartida.Num1Semana);
                conexion.AgregarParametro("@num2Semana", subPartida.Num2Semana);
                conexion.AgregarParametro("@num3Semana", subPartida.Num3Semana);
                conexion.AgregarParametro("@dias1", subPartida.Dias1SubPartida);
                conexion.AgregarParametro("@dias2", subPartida.Dias2SubPartida);
                conexion.AgregarParametro("@dias3", subPartida.Dias3SubPartida);
                conexion.AgregarParametro("@fecha1", subPartida.Fecha1SubPartida);
                conexion.AgregarParametro("@fecha2", subPartida.Fecha2SubPartida);
                conexion.AgregarParametro("@fecha3", subPartida.Fecha3SubPartida);
                conexion.AgregarParametro("@observacionCafe", subPartida.ObservacionIdentificacionCafe);
                conexion.AgregarParametro("@fechaCargaSecado", subPartida.FechaSecado);
                conexion.AgregarParametro("@inicioSecado", subPartida.InicioSecado);
                conexion.AgregarParametro("@salidaPuntoSecado", subPartida.SalidaSecado);
                conexion.AgregarParametro("@tiempoSecado", subPartida.TiempoSecado);
                conexion.AgregarParametro("@humedadSecado", subPartida.HumedadSecado);
                conexion.AgregarParametro("@rendimiento", subPartida.Rendimiento);
                conexion.AgregarParametro("@idPunteroSecado", subPartida.IdPunteroSecador);
                conexion.AgregarParametro("@observacionSecado", subPartida.ObservacionSecado);
                conexion.AgregarParametro("@idCatador", subPartida.IdCatador);
                conexion.AgregarParametro("@fechaCatacion", subPartida.FechaCatacion);
                conexion.AgregarParametro("@observacionCatacion", subPartida.ObservacionCatador);
                conexion.AgregarParametro("@resultado", subPartida.ResultadoCatador);
                conexion.AgregarParametro("@fechaPesado", subPartida.FechaPesado);
                conexion.AgregarParametro("@pesoSaco", subPartida.PesaSaco);
                conexion.AgregarParametro("@pesoQQs", subPartida.PesaQQs);
                conexion.AgregarParametro("@idAlmacen", subPartida.IdAlmacen);
                conexion.AgregarParametro("@idBodega", subPartida.IdBodega);
                conexion.AgregarParametro("@idPesador", subPartida.IdPesador);
                conexion.AgregarParametro("@observacionPesado", subPartida.ObservacionPesador);
                conexion.AgregarParametro("@docto", subPartida.DoctoAlmacen);
                conexion.AgregarParametro("@id", subPartida.IdSubpartida);

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
        public void EliminarSubPartida(int idSubPartida)
        {
            try
            {
                //conexion a la base de datos
                conexion.Conectar();

                //se crea script SQL
                string consulta = @"DELETE FROM SubPartida WHERE id_subpartida = @id";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@id", idSubPartida);

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

        // Función para obtener todos los registros de SubPartida en la base de datos
        public List<SubPartida> ObtenerSubPartidas()
        {
            List<SubPartida> listaSubPartidas = new List<SubPartida>();

            try
            {
                // Conexión a la base de datos (asegúrate de tener la clase "conexion" y los métodos correspondientes)
                conexion.Conectar();

                string consulta = "SELECT * FROM SubPartida";
                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        SubPartida subPartida = new SubPartida()
                        {
                            IdSubpartida = Convert.ToInt32(reader["id_subpartida"]),
                            IdCosecha = Convert.ToInt32(reader["id_cosecha_subpartida"]),
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia_subpartida"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe_subpartida"]),
                            IdSubProducto = Convert.ToInt32(reader["id_subproducto_subpartida"]),
                            Num1Semana = Convert.ToInt32(reader["num1_semana_subpartida"]),
                            Num2Semana = Convert.ToInt32(reader["num2_semana_subpartida"]),
                            Num3Semana = Convert.ToInt32(reader["num3_semana_subpartida"]),
                            Dias1SubPartida = Convert.ToInt32(reader["dias1_subpartida"]),
                            Dias2SubPartida = Convert.ToInt32(reader["dias2_subpartida"]),
                            Dias3SubPartida = Convert.ToInt32(reader["dias3_subpartida"]),
                            Fecha1SubPartida = Convert.ToString(reader["fecha1_subpartida"]),
                            Fecha2SubPartida = Convert.ToString(reader["fecha2_subpartida"]),
                            Fecha3SubPartida = Convert.ToString(reader["fecha3_subpartida"]),
                            ObservacionIdentificacionCafe = Convert.ToString(reader["observacion_cafe_subpartida"]),
                            FechaSecado = Convert.ToDateTime(reader["fecha_carga_secado_subpartida"]),
                            InicioSecado = Convert.ToDateTime(reader["inicio_secado_subpartida"]),
                            SalidaSecado = Convert.ToDateTime(reader["salida_punto_secado_subpartida"]),
                            TiempoSecado = TimeSpan.Parse(reader["tiempo_secado_subpartida"].ToString()),
                            HumedadSecado = Convert.ToDouble(reader["humedad_secado_subpartida"]),
                            Rendimiento = Convert.ToDouble(reader["rendimiento_subpartida"]),
                            IdPunteroSecador = Convert.ToInt32(reader["id_puntero_secado_subpartida"]),
                            ObservacionSecado = Convert.ToString(reader["observacion_secado_subpartida"]),
                            IdCatador = Convert.ToInt32(reader["id_catador_subpartida"]),
                            FechaCatacion = Convert.ToDateTime(reader["fecha_catacion_subpartida"]),
                            ObservacionCatador = Convert.ToString(reader["observacion_catacion_subpartida"]),
                            FechaPesado = Convert.ToDateTime(reader["fecha_pesado_subpartida"]),
                            PesaSaco = Convert.ToDouble(reader["peso_saco_subpartida"]),
                            PesaQQs = Convert.ToDouble(reader["peso_qqs_subpartida"]),
                            IdAlmacen = Convert.ToInt32(reader["id_almacen_subpartida"]),
                            IdBodega = Convert.ToInt32(reader["id_bodega_subpartida"]),
                            IdPesador = Convert.ToInt32(reader["id_pesador_subpartida"]),
                            ObservacionPesador = Convert.ToString(reader["observacion_pesado_subpartida"])
                        };

                        listaSubPartidas.Add(subPartida);
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

            return listaSubPartidas;
        }

        // Función para obtener todos los registros de SubPartida en la base de datos
        public List<SubPartida> ObtenerSubPartidasNombresPorCosecha(string cosecha)
        {
            List<SubPartida> listaSubPartidas = new List<SubPartida>();

            try
            {
                // Conexión a la base de datos (asegúrate de tener la clase "conexion" y los métodos correspondientes)
                conexion.Conectar();

                string consulta = @"SELECT sp.*,
                                           c.nombre_cosecha,
                                           pd.nombre_procedencia,
                                           cc.nombre_calidad,
                                           sbp.nombre_subproducto,
                                           p.nombre_personal,
                                           pb.nombre_bodega,
                                           a.nombre_almacen,
                                           ps.nombre_personal AS nombre_puntero_secador,
                                           pc.nombre_personal AS nombre_catador,
                                           pe.nombre_personal AS nombre_pesador
                                    FROM SubPartida sp
                                    INNER JOIN Cosecha c ON sp.id_cosecha_subpartida = c.id_cosecha
                                    INNER JOIN Procedencia_Destino_Cafe pd ON sp.id_procedencia_subpartida = pd.id_procedencia
                                    INNER JOIN Calidad_Cafe cc ON sp.id_calidad_cafe_subpartida = cc.id_calidad
                                    INNER JOIN SubProducto sbp ON sp.id_subproducto_subpartida = sbp.id_subproducto
                                    INNER JOIN Personal p ON sp.id_puntero_secado_subpartida = p.id_personal
                                    INNER JOIN Bodega_Cafe pb ON sp.id_bodega_subpartida = pb.id_bodega
                                    INNER JOIN Almacen a ON sp.id_almacen_subpartida = a.id_almacen
                                    INNER JOIN Personal ps ON sp.id_puntero_secado_subpartida = ps.id_personal
                                    INNER JOIN Personal pc ON sp.id_catador_subpartida = pc.id_personal
                                    INNER JOIN Personal pe ON sp.id_pesador_subpartida = pe.id_personal
                                    WHERE c.nombre_cosecha = @cosecha";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@cosecha", cosecha);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        SubPartida subPartida = new SubPartida()
                        {
                            IdSubpartida = Convert.ToInt32(reader["id_subpartida"]),
                            NumeroSubpartida = Convert.ToInt32(reader["num_subpartida"]),
                            IdCosecha = Convert.ToInt32(reader["id_cosecha_subpartida"]),
                            NombreCosecha = Convert.IsDBNull(reader["nombre_cosecha"]) ? null : Convert.ToString(reader["nombre_cosecha"]),
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia_subpartida"]),
                            NombreProcedencia = Convert.IsDBNull(reader["nombre_procedencia"]) ? null : Convert.ToString(reader["nombre_procedencia"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe_subpartida"]),
                            NombreCalidadCafe = Convert.IsDBNull(reader["nombre_calidad"]) ? null : Convert.ToString(reader["nombre_calidad"]),
                            IdSubProducto = Convert.ToInt32(reader["id_subproducto_subpartida"]),
                            NombreSubProducto = Convert.IsDBNull(reader["nombre_subproducto"]) ? null : Convert.ToString(reader["nombre_subproducto"]),
                            Num1Semana = Convert.ToInt32(reader["num1_semana_subpartida"]),
                            Num2Semana = Convert.IsDBNull(reader["num2_semana_subpartida"]) ? 0 : Convert.ToInt32(reader["num2_semana_subpartida"]),
                            Num3Semana = Convert.IsDBNull(reader["num3_semana_subpartida"]) ? 0 : Convert.ToInt32(reader["num3_semana_subpartida"]),
                            Dias1SubPartida = Convert.ToInt32(reader["dias1_subpartida"]),
                            Dias2SubPartida = Convert.IsDBNull(reader["dias2_subpartida"]) ? 0 : Convert.ToInt32(reader["dias2_subpartida"]),
                            Dias3SubPartida = Convert.IsDBNull(reader["dias3_subpartida"]) ? 0 : Convert.ToInt32(reader["dias3_subpartida"]),
                            Fecha1SubPartida = Convert.ToString(reader["fecha1_subpartida"]),
                            Fecha2SubPartida = Convert.IsDBNull(reader["fecha2_subpartida"]) ? null : Convert.ToString(reader["fecha2_subpartida"]),
                            Fecha3SubPartida = Convert.IsDBNull(reader["fecha3_subpartida"]) ? null : Convert.ToString(reader["fecha3_subpartida"]),
                            ObservacionIdentificacionCafe = Convert.IsDBNull(reader["observacion_cafe_subpartida"]) ? null : Convert.ToString(reader["observacion_cafe_subpartida"]),
                            FechaSecado = Convert.ToDateTime(reader["fecha_carga_secado_subpartida"]),
                            InicioSecado = Convert.ToDateTime(reader["inicio_secado_subpartida"]),
                            SalidaSecado = Convert.ToDateTime(reader["salida_punto_secado_subpartida"]),
                            TiempoSecado = TimeSpan.Parse(reader["tiempo_secado_subpartida"].ToString()),
                            HumedadSecado = Convert.ToDouble(reader["humedad_secado_subpartida"]),
                            Rendimiento = Convert.ToDouble(reader["rendimiento_subpartida"]),
                            IdPunteroSecador = Convert.ToInt32(reader["id_puntero_secado_subpartida"]),
                            NombrePunteroSecador = Convert.IsDBNull(reader["nombre_puntero_secador"]) ? null : Convert.ToString(reader["nombre_puntero_secador"]),
                            ObservacionSecado = Convert.IsDBNull(reader["observacion_secado_subpartida"]) ? null : Convert.ToString(reader["observacion_secado_subpartida"]),
                            IdCatador = Convert.ToInt32(reader["id_catador_subpartida"]),
                            NombreCatador = Convert.IsDBNull(reader["nombre_catador"]) ? null : Convert.ToString(reader["nombre_catador"]),
                            FechaCatacion = Convert.ToDateTime(reader["fecha_catacion_subpartida"]),
                            ObservacionCatador = Convert.IsDBNull(reader["observacion_catacion_subpartida"]) ? null : Convert.ToString(reader["observacion_catacion_subpartida"]),
                            FechaPesado = Convert.ToDateTime(reader["fecha_pesado_subpartida"]),
                            PesaSaco = Convert.ToDouble(reader["peso_saco_subpartida"]),
                            PesaQQs = Convert.ToDouble(reader["peso_qqs_subpartida"]),
                            IdAlmacen = Convert.ToInt32(reader["id_almacen_subpartida"]),
                            NombreAlmacen = Convert.IsDBNull(reader["nombre_almacen"]) ? null : Convert.ToString(reader["nombre_almacen"]),
                            IdBodega = Convert.ToInt32(reader["id_bodega_subpartida"]),
                            NombreBodega = Convert.IsDBNull(reader["nombre_bodega"]) ? null : Convert.ToString(reader["nombre_bodega"]),
                            DoctoAlmacen = Convert.IsDBNull(reader["docto_almacen_subpartida"]) ? null : Convert.ToString(reader["docto_almacen_subpartida"]),
                            IdPesador = Convert.ToInt32(reader["id_pesador_subpartida"]),
                            NombrePunteroPesador = Convert.IsDBNull(reader["nombre_pesador"]) ? null : Convert.ToString(reader["nombre_pesador"]),
                            ObservacionPesador = Convert.IsDBNull(reader["observacion_pesado_subpartida"]) ? null : Convert.ToString(reader["observacion_pesado_subpartida"])
                        };


                        listaSubPartidas.Add(subPartida);
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

            return listaSubPartidas;
        }
        
        // Función para obtener todos los registros de SubPartida en la base de datos
        public SubPartida ObtenerSubPartidasPorNombreAndCosecha(string nombre, string cosecha)
        {
            SubPartida subPartida = null;

            try
            {
                // Conexión a la base de datos (asegúrate de tener la clase "conexion" y los métodos correspondientes)
                conexion.Conectar();

                string consulta = @"SELECT sp.*,
                                           c.nombre_cosecha,
                                           pd.nombre_procedencia,
                                           cc.nombre_calidad,
                                           sbp.nombre_subproducto,
                                           p.nombre_personal,
                                           pb.nombre_bodega,
                                           a.nombre_almacen,
                                           ps.nombre_personal AS nombre_puntero_secador,
                                           pc.nombre_personal AS nombre_catador,
                                           pe.nombre_personal AS nombre_pesador
                                    FROM SubPartida sp
                                    INNER JOIN Cosecha c ON sp.id_cosecha_subpartida = c.id_cosecha
                                    INNER JOIN Procedencia_Destino_Cafe pd ON sp.id_procedencia_subpartida = pd.id_procedencia
                                    INNER JOIN Calidad_Cafe cc ON sp.id_calidad_cafe_subpartida = cc.id_calidad
                                    INNER JOIN SubProducto sbp ON sp.id_subproducto_subpartida = sbp.id_subproducto
                                    INNER JOIN Personal p ON sp.id_puntero_secado_subpartida = p.id_personal
                                    INNER JOIN Bodega_Cafe pb ON sp.id_bodega_subpartida = pb.id_bodega
                                    INNER JOIN Almacen a ON sp.id_almacen_subpartida = a.id_almacen
                                    INNER JOIN Personal ps ON sp.id_puntero_secado_subpartida = ps.id_personal
                                    INNER JOIN Personal pc ON sp.id_catador_subpartida = pc.id_personal
                                    INNER JOIN Personal pe ON sp.id_pesador_subpartida = pe.id_personal
                                    WHERE sp.num_subpartida = @nombre AND c.nombre_cosecha = @cosecha";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@nombre", nombre);
                conexion.AgregarParametro("@cosecha", cosecha);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows && reader.Read())
                    {
                        subPartida = new SubPartida()
                        {
                            IdSubpartida = Convert.ToInt32(reader["id_subpartida"]),
                            NumeroSubpartida = Convert.ToInt32(reader["num_subpartida"]),
                            IdCosecha = Convert.ToInt32(reader["id_cosecha_subpartida"]),
                            NombreCosecha = Convert.ToString(reader["nombre_cosecha"]),
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia_subpartida"]),
                            NombreProcedencia = Convert.ToString(reader["nombre_procedencia"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe_subpartida"]),
                            NombreCalidadCafe = Convert.ToString(reader["nombre_calidad"]),
                            IdSubProducto = Convert.ToInt32(reader["id_subproducto_subpartida"]),
                            NombreSubProducto = Convert.ToString(reader["nombre_subproducto"]),
                            Num1Semana = Convert.ToInt32(reader["num1_semana_subpartida"]),
                            Num2Semana = Convert.ToInt32(reader["num2_semana_subpartida"]),
                            Num3Semana = Convert.ToInt32(reader["num3_semana_subpartida"]),
                            Dias1SubPartida = Convert.ToInt32(reader["dias1_subpartida"]),
                            Dias2SubPartida = Convert.ToInt32(reader["dias2_subpartida"]),
                            Dias3SubPartida = Convert.ToInt32(reader["dias3_subpartida"]),
                            Fecha1SubPartida = Convert.ToString(reader["fecha1_subpartida"]),
                            Fecha2SubPartida = Convert.ToString(reader["fecha2_subpartida"]),
                            Fecha3SubPartida = Convert.ToString(reader["fecha3_subpartida"]),
                            ObservacionIdentificacionCafe = Convert.ToString(reader["observacion_cafe_subpartida"]),
                            FechaSecado = Convert.ToDateTime(reader["fecha_carga_secado_subpartida"]),
                            InicioSecado = Convert.ToDateTime(reader["inicio_secado_subpartida"]),
                            SalidaSecado = Convert.ToDateTime(reader["salida_punto_secado_subpartida"]),
                            TiempoSecado = TimeSpan.Parse(reader["tiempo_secado_subpartida"].ToString()),
                            HumedadSecado = Convert.ToDouble(reader["humedad_secado_subpartida"]),
                            Rendimiento = Convert.ToDouble(reader["rendimiento_subpartida"]),
                            IdPunteroSecador = Convert.ToInt32(reader["id_puntero_secado_subpartida"]),
                            NombrePunteroSecador = Convert.ToString(reader["nombre_puntero_secador"]),
                            ObservacionSecado = Convert.ToString(reader["observacion_secado_subpartida"]),
                            IdCatador = Convert.ToInt32(reader["id_catador_subpartida"]),
                            NombreCatador = Convert.ToString(reader["nombre_catador"]),
                            FechaCatacion = Convert.ToDateTime(reader["fecha_catacion_subpartida"]),
                            ObservacionCatador = Convert.ToString(reader["observacion_catacion_subpartida"]),
                            ResultadoCatador = Convert.ToString(reader["resultado_catacion_subpartida"]),
                            FechaPesado = Convert.ToDateTime(reader["fecha_pesado_subpartida"]),
                            PesaSaco = Convert.ToDouble(reader["peso_saco_subpartida"]),
                            PesaQQs = Convert.ToDouble(reader["peso_qqs_subpartida"]),
                            IdAlmacen = Convert.ToInt32(reader["id_almacen_subpartida"]),
                            NombreAlmacen = Convert.ToString(reader["nombre_almacen"]),
                            IdBodega = Convert.ToInt32(reader["id_bodega_subpartida"]),
                            NombreBodega = Convert.ToString(reader["nombre_bodega"]),
                            DoctoAlmacen = Convert.ToString(reader["docto_almacen_subpartida"]),
                            IdPesador = Convert.ToInt32(reader["id_pesador_subpartida"]),
                            NombrePunteroPesador = Convert.ToString(reader["nombre_pesador"]),
                            ObservacionPesador = Convert.ToString(reader["observacion_pesado_subpartida"])

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

            return subPartida;
        }

        // Función para obtener todos los registros de SubPartida en la base de datos
        public SubPartida ObtenerSubPartidaPorID(int idSubPartida)
        {
            SubPartida subPartida = null;

            try
            {
                // Conexión a la base de datos (asegúrate de tener la clase "conexion" y los métodos correspondientes)
                conexion.Conectar();

                string consulta = @"SELECT sp.*,
                                           c.nombre_cosecha,
                                           pd.nombre_procedencia,
                                           cc.nombre_calidad,
                                           sbp.nombre_subproducto,
                                           p.nombre_personal,
                                           pb.nombre_bodega,
                                           a.nombre_almacen,
                                           ps.nombre_personal AS nombre_puntero_secador,
                                           pc.nombre_personal AS nombre_catador,
                                           pe.nombre_personal AS nombre_pesador
                                    FROM SubPartida sp
                                    INNER JOIN Cosecha c ON sp.id_cosecha_subpartida = c.id_cosecha
                                    INNER JOIN Procedencia_Destino_Cafe pd ON sp.id_procedencia_subpartida = pd.id_procedencia
                                    INNER JOIN Calidad_Cafe cc ON sp.id_calidad_cafe_subpartida = cc.id_calidad
                                    INNER JOIN SubProducto sbp ON sp.id_subproducto_subpartida = sbp.id_subproducto
                                    INNER JOIN Personal p ON sp.id_puntero_secado_subpartida = p.id_personal
                                    INNER JOIN Bodega_Cafe pb ON sp.id_bodega_subpartida = pb.id_bodega
                                    INNER JOIN Almacen a ON sp.id_almacen_subpartida = a.id_almacen
                                    INNER JOIN Personal ps ON sp.id_puntero_secado_subpartida = ps.id_personal
                                    INNER JOIN Personal pc ON sp.id_catador_subpartida = pc.id_personal
                                    INNER JOIN Personal pe ON sp.id_pesador_subpartida = pe.id_personal
                                    WHERE id_subpartida = @Id";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@Id", idSubPartida);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows && reader.Read())
                    {
                        subPartida = new SubPartida()
                        {
                            IdSubpartida = Convert.ToInt32(reader["id_subpartida"]),
                            NumeroSubpartida = Convert.ToInt32(reader["num_subpartida"]),
                            IdCosecha = Convert.ToInt32(reader["id_cosecha_subpartida"]),
                            NombreCosecha = Convert.IsDBNull(reader["nombre_cosecha"]) ? null : Convert.ToString(reader["nombre_cosecha"]),
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia_subpartida"]),
                            NombreProcedencia = Convert.IsDBNull(reader["nombre_procedencia"]) ? null : Convert.ToString(reader["nombre_procedencia"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe_subpartida"]),
                            NombreCalidadCafe = Convert.IsDBNull(reader["nombre_calidad"]) ? null : Convert.ToString(reader["nombre_calidad"]),
                            IdSubProducto = Convert.ToInt32(reader["id_subproducto_subpartida"]),
                            NombreSubProducto = Convert.IsDBNull(reader["nombre_subproducto"]) ? null : Convert.ToString(reader["nombre_subproducto"]),
                            Num1Semana = Convert.ToInt32(reader["num1_semana_subpartida"]),
                            Num2Semana = Convert.IsDBNull(reader["num2_semana_subpartida"]) ? 0 : Convert.ToInt32(reader["num2_semana_subpartida"]),
                            Num3Semana = Convert.IsDBNull(reader["num3_semana_subpartida"]) ? 0 : Convert.ToInt32(reader["num3_semana_subpartida"]),
                            Dias1SubPartida = Convert.ToInt32(reader["dias1_subpartida"]),
                            Dias2SubPartida = Convert.IsDBNull(reader["dias2_subpartida"]) ? 0 : Convert.ToInt32(reader["dias2_subpartida"]),
                            Dias3SubPartida = Convert.IsDBNull(reader["dias3_subpartida"]) ? 0 : Convert.ToInt32(reader["dias3_subpartida"]),
                            Fecha1SubPartida = Convert.ToString(reader["fecha1_subpartida"]),
                            Fecha2SubPartida = Convert.IsDBNull(reader["fecha2_subpartida"]) ? null : Convert.ToString(reader["fecha2_subpartida"]),
                            Fecha3SubPartida = Convert.IsDBNull(reader["fecha3_subpartida"]) ? null : Convert.ToString(reader["fecha3_subpartida"]),
                            ObservacionIdentificacionCafe = Convert.IsDBNull(reader["observacion_cafe_subpartida"]) ? null : Convert.ToString(reader["observacion_cafe_subpartida"]),
                            FechaSecado = Convert.ToDateTime(reader["fecha_carga_secado_subpartida"]),
                            InicioSecado = Convert.ToDateTime(reader["inicio_secado_subpartida"]),
                            SalidaSecado = Convert.ToDateTime(reader["salida_punto_secado_subpartida"]),
                            TiempoSecado = TimeSpan.Parse(reader["tiempo_secado_subpartida"].ToString()),
                            HumedadSecado = Convert.ToDouble(reader["humedad_secado_subpartida"]),
                            Rendimiento = Convert.ToDouble(reader["rendimiento_subpartida"]),
                            IdPunteroSecador = Convert.ToInt32(reader["id_puntero_secado_subpartida"]),
                            NombrePunteroSecador = Convert.IsDBNull(reader["nombre_puntero_secador"]) ? null : Convert.ToString(reader["nombre_puntero_secador"]),
                            ObservacionSecado = Convert.IsDBNull(reader["observacion_secado_subpartida"]) ? null : Convert.ToString(reader["observacion_secado_subpartida"]),
                            IdCatador = Convert.ToInt32(reader["id_catador_subpartida"]),
                            NombreCatador = Convert.IsDBNull(reader["nombre_catador"]) ? null : Convert.ToString(reader["nombre_catador"]),
                            FechaCatacion = Convert.ToDateTime(reader["fecha_catacion_subpartida"]),
                            ObservacionCatador = Convert.IsDBNull(reader["observacion_catacion_subpartida"]) ? null : Convert.ToString(reader["observacion_catacion_subpartida"]),
                            FechaPesado = Convert.ToDateTime(reader["fecha_pesado_subpartida"]),
                            PesaSaco = Convert.ToDouble(reader["peso_saco_subpartida"]),
                            PesaQQs = Convert.ToDouble(reader["peso_qqs_subpartida"]),
                            IdAlmacen = Convert.ToInt32(reader["id_almacen_subpartida"]),
                            NombreAlmacen = Convert.IsDBNull(reader["nombre_almacen"]) ? null : Convert.ToString(reader["nombre_almacen"]),
                            IdBodega = Convert.ToInt32(reader["id_bodega_subpartida"]),
                            NombreBodega = Convert.IsDBNull(reader["nombre_bodega"]) ? null : Convert.ToString(reader["nombre_bodega"]),
                            DoctoAlmacen = Convert.IsDBNull(reader["docto_almacen_subpartida"]) ? null : Convert.ToString(reader["docto_almacen_subpartida"]),
                            IdPesador = Convert.ToInt32(reader["id_pesador_subpartida"]),
                            NombrePunteroPesador = Convert.IsDBNull(reader["nombre_pesador"]) ? null : Convert.ToString(reader["nombre_pesador"]),
                            ObservacionPesador = Convert.IsDBNull(reader["observacion_pesado_subpartida"]) ? null : Convert.ToString(reader["observacion_pesado_subpartida"])

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

            return subPartida;
        }

        // Función para buscar subpartidas por nombre de cosecha, procedencia, calidad de café, subproducto, tipo de movimiento o nombre de personal
        public List<SubPartida> BuscarSubPartidas(string buscar)
        {
            List<SubPartida> subpartidas = new List<SubPartida>();

            try
            {
                // Conexión a la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para buscar subpartidas
                string consulta = @"SELECT sp.*,
                                  c.nombre_cosecha,
                                  pd.nombre_procedencia,
                                  cc.nombre_calidad_cafe,
                                  sbp.nombre_subproducto,
                                  p.nombre_personal,
                                  pb.nombre_bodega,
                                  a.nombre_almacen,
                                  ps.nombre_personal AS nombre_puntero_secador,
                                  pc.nombre_personal AS nombre_catador,
                                  pe.nombre_personal AS nombre_pesador
                           FROM SubPartida sp
                           INNER JOIN Cosecha c ON sp.id_cosecha_subpartida = c.id_cosecha
                           INNER JOIN Procedencia_Destino_Cafe pd ON sp.id_procedencia_subpartida = pd.id_procedencia
                           INNER JOIN Calidad_Cafe cc ON sp.id_calidad_cafe_subpartida = cc.id_calidad
                           INNER JOIN SubProducto sbp ON sp.id_subproducto_subpartida = sbp.id_subproducto
                           INNER JOIN Personal p ON sp.id_puntero_secado_subpartida = p.id_personal
                           INNER JOIN Bodega_Cafe pb ON sp.id_bodega_subpartida = pb.id_bodega
                           INNER JOIN Almacen a ON sp.id_almacen_subpartida = a.id_almacen
                           INNER JOIN Personal ps ON sp.id_puntero_secado_subpartida = ps.id_personal
                           INNER JOIN Personal pc ON sp.id_catador_subpartida = pc.id_personal
                           INNER JOIN Personal pe ON sp.id_pesador_subpartida = pe.id_personal
                           WHERE c.nombre_cosecha LIKE CONCAT('%', @search, '%') OR
                                 pd.nombre_procedencia LIKE CONCAT('%', @search, '%') OR
                                 cc.nombre_calidad_cafe LIKE CONCAT('%', @search, '%') OR
                                 sbp.nombre_subproducto LIKE CONCAT('%', @search, '%') OR
                                 p.nombre_personal LIKE CONCAT('%', @search, '%') OR
                                 pb.nombre_bodega LIKE CONCAT('%', @search, '%') OR
                                 a.nombre_almacen LIKE CONCAT('%', @search, '%') OR
                                 ps.nombre_personal LIKE CONCAT('%', @search, '%') OR
                                 pc.nombre_personal LIKE CONCAT('%', @search, '%') OR
                                 pe.nombre_personal LIKE CONCAT('%', @search, '%')";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@search", buscar);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        SubPartida subpartida = new SubPartida()
                        {
                            IdSubpartida = Convert.ToInt32(reader["id_subpartida"]),
                            IdCosecha = Convert.ToInt32(reader["id_cosecha_subpartida"]),
                            NombreCosecha = Convert.ToString(reader["nombre_cosecha"]),
                            IdProcedencia = Convert.ToInt32(reader["id_procedencia_subpartida"]),
                            NombreProcedencia = Convert.ToString(reader["nombre_procedencia"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe_subpartida"]),
                            NombreCalidadCafe = Convert.ToString(reader["nombre_calidad_cafe"]),
                            IdSubProducto = Convert.ToInt32(reader["id_subproducto_subpartida"]),
                            NombreSubProducto = Convert.ToString(reader["nombre_subproducto"]),
                            Num1Semana = Convert.ToInt32(reader["num1_semana_subpartida"]),
                            Num2Semana = Convert.ToInt32(reader["num2_semana_subpartida"]),
                            Num3Semana = Convert.ToInt32(reader["num3_semana_subpartida"]),
                            Dias1SubPartida = Convert.ToInt32(reader["dias1_subpartida"]),
                            Dias2SubPartida = Convert.ToInt32(reader["dias2_subpartida"]),
                            Dias3SubPartida = Convert.ToInt32(reader["dias3_subpartida"]),
                            Fecha1SubPartida = Convert.ToString(reader["fecha1_subpartida"]),
                            Fecha2SubPartida = Convert.ToString(reader["fecha2_subpartida"]),
                            Fecha3SubPartida = Convert.ToString(reader["fecha3_subpartida"]),
                            ObservacionIdentificacionCafe = Convert.ToString(reader["observacion_cafe_subpartida"]),
                            FechaSecado = Convert.ToDateTime(reader["fecha_carga_secado_subpartida"]),
                            InicioSecado = Convert.ToDateTime(reader["inicio_secado_subpartida"]),
                            SalidaSecado = Convert.ToDateTime(reader["salida_punto_secado_subpartida"]),
                            TiempoSecado = TimeSpan.Parse(Convert.ToString(reader["tiempo_secado_subpartida"])),
                            HumedadSecado = Convert.ToDouble(reader["humedad_secado_subpartida"]),
                            Rendimiento = Convert.ToDouble(reader["rendimiento_subpartida"]),
                            IdPunteroSecador = Convert.ToInt32(reader["id_puntero_secado_subpartida"]),
                            NombrePunteroSecador = Convert.ToString(reader["nombre_puntero_secador"]),
                            ObservacionSecado = Convert.ToString(reader["observacion_secado_subpartida"]),
                            IdCatador = Convert.ToInt32(reader["id_catador_subpartida"]),
                            NombreCatador = Convert.ToString(reader["nombre_catador"]),
                            FechaCatacion = Convert.ToDateTime(reader["fecha_catacion_subpartida"]),
                            ObservacionCatador = Convert.ToString(reader["observacion_catacion_subpartida"]),
                            FechaPesado = Convert.ToDateTime(reader["fecha_pesado_subpartida"]),
                            PesaSaco = Convert.ToDouble(reader["peso_saco_subpartida"]),
                            PesaQQs = Convert.ToDouble(reader["peso_qqs_subpartida"]),
                            IdBodega = Convert.ToInt32(reader["id_bodega_subpartida"]),
                            NombreBodega = Convert.ToString(reader["nombre_bodega"]),
                            IdAlmacen = Convert.ToInt32(reader["id_almacen_subpartida"]),
                            NombreAlmacen = Convert.ToString(reader["nombre_almacen"]),
                            IdPesador = Convert.ToInt32(reader["id_pesador_subpartida"]),
                            NombrePunteroPesador = Convert.ToString(reader["nombre_pesador"]),
                            ObservacionPesador = Convert.ToString(reader["observacion_pesado_subpartida"])
                        };

                        subpartidas.Add(subpartida);
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
            return subpartidas;
        }

        //
        public SubPartida CountSubPartida(int idCosecha)
        {
            SubPartida subpartidas = null;
            try
            {
                //Se conecta con la base de datos
                conexion.Conectar();

                string consulta = @"SELECT COUNT(*) AS TotalSubPartida FROM SubPartida
                                    WHERE id_cosecha_subpartida = @id";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@id", idCosecha);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            subpartidas = new SubPartida()
                            {
                                CountSubPartida = Convert.ToInt32(reader["TotalSubPartida"])
                            };
                        }
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
            return subpartidas;
        }

        //


    }
}
