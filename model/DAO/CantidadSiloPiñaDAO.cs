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
    class CantidadSiloPiñaDAO
    {
        private ConnectionDB conexion;

        public CantidadSiloPiñaDAO()
        {
            //Se crea la instancia de la clase conexion
            conexion = new ConnectionDB();
        }

        public bool InsertarCantidadCafeSiloPiña(CantidadSiloPiña cantidad)
        {
            try
            {
                // Conexión a la base de datos
                conexion.Conectar();

                // Se crea script SQL para insertar
                string consulta = @"INSERT INTO CantidadCafe_Silo_Piña (fecha_llenado, fecha_actualizado, fecha_vaciado,
                                                              cantidad_ingresada, cantidad_actual, cantidad_salida,
                                                              id_calidad_cafe, id_almacen_silo_piña)
                            VALUES (@fechaLlenado, @fechaActualizado, @fechaVaciado, @cantidadIngresada,
                                    @cantidadActual, @cantidadSalida, @idCalidadCafe, @idAlmacenSiloPiña)";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@fechaLlenado", cantidad.FechaLlenado);
                conexion.AgregarParametro("@fechaActualizado", cantidad.FechaActualizado);
                conexion.AgregarParametro("@fechaVaciado", cantidad.FechaVaciado);
                conexion.AgregarParametro("@cantidadIngresada", cantidad.CantidadIngresada);
                conexion.AgregarParametro("@cantidadActual", cantidad.CantidadActual);
                conexion.AgregarParametro("@cantidadSalida", cantidad.CantidadSalida);
                conexion.AgregarParametro("@idCalidadCafe", cantidad.IdCalidadCafe);
                conexion.AgregarParametro("@idAlmacenSiloPiña", cantidad.IdAlmacenSiloPiña);

                int filasAfectadas = conexion.EjecutarInstruccion();

                // Si la fila se afecta, se insertó correctamente
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la inserción en la base de datos: " + ex.Message);
                return false;
            }
            finally
            {
                // Se cierra la conexión a la base de datos
                conexion.Desconectar();
            }
        }

        //funcion para mostrar todos los registros
        public List<CantidadSiloPiña> ObtenerCantidadesSiloPiña()
        {
            List<CantidadSiloPiña> listaCantidad = new List<CantidadSiloPiña>();

            try
            {
                //Se conecta con la base de datos
                conexion.Conectar();

                string consulta = @"SELECT * FROM CantidadCafe_Silo_Piña";
                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        CantidadSiloPiña Almacens = new CantidadSiloPiña()
                        {
                            IdCantidadCafe = Convert.ToInt32(reader["id_cantidad_cafe"]),
                            FechaLlenado = Convert.ToDateTime(reader["fecha_llenado"]),
                            FechaActualizado = Convert.ToDateTime(reader["fecha_actualizado"]),
                            FechaVaciado = Convert.ToDateTime(reader["fecha_vaciado"]),
                            CantidadIngresada = Convert.ToDouble(reader["cantidad_ingresada"]),
                            CantidadActual = Convert.ToDouble(reader["cantidad_actual"]),
                            CantidadSalida = Convert.ToDouble(reader["cantidad_salida"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe"]),
                            IdAlmacenSiloPiña = Convert.ToInt32(reader["id_almacen_silo_piña"])
                        };

                        listaCantidad.Add(Almacens);
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
            return listaCantidad;
        }

        //obtener la Almacen en especifico mediante el id en la BD
        public CantidadSiloPiña ObtenerIdCantidadSiloPiña(int idCantidad)
        {
            CantidadSiloPiña cantidad = null;

            try
            {
                // Conectar a la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el rol
                string consulta = "SELECT * FROM CantidadCafe_Silo_Piña WHERE id_cantidad_cafe = @Id";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@Id", idCantidad);

                // Ejecutar la consulta y leer el resultado
                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows && reader.Read())
                    {
                        cantidad = new CantidadSiloPiña()
                        {
                            IdCantidadCafe = Convert.ToInt32(reader["id_cantidad_cafe"]),
                            FechaLlenado = Convert.ToDateTime(reader["fecha_llenado"]),
                            FechaActualizado = Convert.ToDateTime(reader["fecha_actualizado"]),
                            FechaVaciado = Convert.ToDateTime(reader["fecha_vaciado"]),
                            CantidadIngresada = Convert.ToDouble(reader["cantidad_ingresada"]),
                            CantidadActual = Convert.ToDouble(reader["cantidad_actual"]),
                            CantidadSalida = Convert.ToDouble(reader["cantidad_salida"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe"]),
                            IdAlmacenSiloPiña = Convert.ToInt32(reader["id_almacen_silo_piña"])
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la Cantidad de los Silos/Piña: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }

            return cantidad;
        }

        //obtener la Cantidad en especifico mediante el id del silo/Piña en la BD
        public CantidadSiloPiña ObtenerCantidadSiloPiña(string nombreSiloPiña)
        {
            CantidadSiloPiña cantidad = null;

            try
            {
                // Conectar a la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el rol
                string consulta = @"SELECT c.id_cantidad_cafe, c.fecha_llenado, c.fecha_actualizado, c.fecha_vaciado,
                                  c.cantidad_ingresada, c.cantidad_actual, c.cantidad_salida,
                                  c.id_calidad_cafe, cc.nombre_calidad_cafe, c.id_almacen_silo_piña, a.nombre_almacen
                            FROM CantidadCafe_Silo_Piña c
                            INNER JOIN Calidad_Cafe cc ON c.id_calidad_cafe = cc.id_calidad
                            INNER JOIN Almacen a ON c.id_almacen_silo_piña = a.id_almacen
                            WHERE a.nombre_almacen = @nombreA";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@nombreA", nombreSiloPiña);

                // Ejecutar la consulta y leer el resultado
                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows && reader.Read())
                    {
                        cantidad = new CantidadSiloPiña()
                        {
                            IdCantidadCafe = Convert.ToInt32(reader["id_cantidad_cafe"]),
                            FechaLlenado = Convert.ToDateTime(reader["fecha_llenado"]),
                            FechaActualizado = Convert.ToDateTime(reader["fecha_actualizado"]),
                            FechaVaciado = Convert.ToDateTime(reader["fecha_vaciado"]),
                            CantidadIngresada = Convert.ToDouble(reader["cantidad_ingresada"]),
                            CantidadActual = Convert.ToDouble(reader["cantidad_actual"]),
                            CantidadSalida = Convert.ToDouble(reader["cantidad_salida"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe"]),
                            NombreCalidadCafe = Convert.ToString(reader["nombre_calidad_cafe"]),
                            IdAlmacenSiloPiña = Convert.ToInt32(reader["id_almacen_silo_piña"]),
                            NombreAlmacen = Convert.ToString(reader["nombre_almacen"])
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la cantidad el silo/piña: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }

            return cantidad;
        }

        //obtener la Cantidad y el nombre almacen en la BD
        public List<CantidadSiloPiña> ObtenerCantidadNombreSiloPiña()
        {
            List<CantidadSiloPiña> listaCantidad = new List<CantidadSiloPiña>();

            try
            {
                // Conectar a la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el rol
                string consulta = @"SELECT c.id_cantidad_cafe, c.fecha_llenado, c.fecha_actualizado, c.fecha_vaciado,
                                  c.cantidad_ingresada, c.cantidad_actual, c.cantidad_salida,
                                  c.id_calidad_cafe, cc.nombre_calidad_cafe, c.id_almacen_silo_piña, a.nombre_almacen
                            FROM CantidadCafe_Silo_Piña c
                            INNER JOIN Calidad_Cafe cc ON c.id_calidad_cafe = cc.id_calidad
                            INNER JOIN Almacen a ON c.id_almacen_silo_piña = a.id_almacen";

                conexion.CrearComando(consulta);

                // Ejecutar la consulta y leer el resultado
                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        CantidadSiloPiña cantidad = new CantidadSiloPiña()
                        {
                            IdCantidadCafe = Convert.ToInt32(reader["id_cantidad_cafe"]),
                            FechaLlenado = Convert.ToDateTime(reader["fecha_llenado"]),
                            FechaActualizado = Convert.ToDateTime(reader["fecha_actualizado"]),
                            FechaVaciado = Convert.ToDateTime(reader["fecha_vaciado"]),
                            CantidadIngresada = Convert.ToDouble(reader["cantidad_ingresada"]),
                            CantidadActual = Convert.ToDouble(reader["cantidad_actual"]),
                            CantidadSalida = Convert.ToDouble(reader["cantidad_salida"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe"]),
                            NombreCalidadCafe = Convert.ToString(reader["nombre_calidad_cafe"]),
                            IdAlmacenSiloPiña = Convert.ToInt32(reader["id_almacen_silo_piña"]),
                            NombreAlmacen = Convert.ToString(reader["nombre_almacen"])
                        };
                        listaCantidad.Add(cantidad);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la cantidad y almacen: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }

            return listaCantidad;
        }

        //
        public List<CantidadSiloPiña> BuscarCantidadSiloPiña(string buscar)
        {
            List<CantidadSiloPiña> cantidads = new List<CantidadSiloPiña>();

            try
            {
                //Se conecta con la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el rol
                string consulta = @"SELECT c.id_cantidad_cafe, c.fecha_llenado, c.fecha_actualizado, c.fecha_vaciado,
                                  c.cantidad_ingresada, c.cantidad_actual, c.cantidad_salida,
                                  c.id_calidad_cafe, cc.nombre_calidad_cafe, c.id_almacen_silo_piña, a.nombre_almacen
                            FROM CantidadCafe_Silo_Piña c
                            INNER JOIN Calidad_Cafe cc ON c.id_calidad_cafe = cc.id_calidad
                            INNER JOIN Almacen a ON c.id_almacen_silo_piña = a.id_almacen
                            WHERE cc.nombre_calidad_cafe LIKE CONCAT('%', @search, '%') OR a.nombre_almacen LIKE CONCAT('%', @search, '%')";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@search", "%" + buscar + "%");

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        CantidadSiloPiña cantidad = new CantidadSiloPiña()
                        {
                            IdCantidadCafe = Convert.ToInt32(reader["id_cantidad_cafe"]),
                            FechaLlenado = Convert.ToDateTime(reader["fecha_llenado"]),
                            FechaActualizado = Convert.ToDateTime(reader["fecha_actualizado"]),
                            FechaVaciado = Convert.ToDateTime(reader["fecha_vaciado"]),
                            CantidadIngresada = Convert.ToDouble(reader["cantidad_ingresada"]),
                            CantidadActual = Convert.ToDouble(reader["cantidad_actual"]),
                            CantidadSalida = Convert.ToDouble(reader["cantidad_salida"]),
                            IdCalidadCafe = Convert.ToInt32(reader["id_calidad_cafe"]),
                            NombreCalidadCafe = Convert.ToString(reader["nombre_calidad_cafe"]),
                            IdAlmacenSiloPiña = Convert.ToInt32(reader["id_almacen_silo_piña"]),
                            NombreAlmacen = Convert.ToString(reader["nombre_almacen"])
                        };

                        cantidads.Add(cantidad);
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
            return cantidads;
        }

        public bool ActualizarCantidadCafeSiloPiña(CantidadSiloPiña cantidad)
        {
            bool exito = false;

            try
            {
                // Conexión a la base de datos
                conexion.Conectar();

                // Se crea el script SQL 
                string consulta = @"UPDATE CantidadCafe_Silo_Piña 
                            SET fecha_llenado = @fechaLlenado, fecha_actualizado = @fechaActualizado, fecha_vaciado = @fechaVaciado,
                                cantidad_ingresada = @cantidadIngresada, cantidad_actual = @cantidadActual, cantidad_salida = @cantidadSalida,
                                id_calidad_cafe = @idCalidadCafe, id_almacen_silo_piña = @idAlmacenSiloPiña
                            WHERE id_cantidad_cafe = @idCantidadCafe";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@fechaLlenado", cantidad.FechaLlenado);
                conexion.AgregarParametro("@fechaActualizado", cantidad.FechaActualizado);
                conexion.AgregarParametro("@fechaVaciado", cantidad.FechaVaciado);
                conexion.AgregarParametro("@cantidadIngresada", cantidad.CantidadIngresada);
                conexion.AgregarParametro("@cantidadActual", cantidad.CantidadActual);
                conexion.AgregarParametro("@cantidadSalida", cantidad.CantidadSalida);
                conexion.AgregarParametro("@idCalidadCafe", cantidad.IdCalidadCafe);
                conexion.AgregarParametro("@idAlmacenSiloPiña", cantidad.IdAlmacenSiloPiña);
                conexion.AgregarParametro("@idCantidadCafe", cantidad.IdCantidadCafe);

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
                // Se cierra la conexión con la base de datos
                conexion.Desconectar();
            }

            return exito;
        }

        //funcion para eliminar un registro de la base de datos
        public void EliminarCantidadSiloPiña(int idCantidad)
        {
            try
            {
                //conexion a la base de datos
                conexion.Conectar();

                //se crea script SQL
                string consulta = @"DELETE FROM CantidadCafe_Silo_Piña WHERE id_cantidad_cafe = @id";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@id", idCantidad);

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

    }
}
