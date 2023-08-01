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
                string consulta = @"INSERT INTO CantidadCafe_Silo_Piña (fecha_movimiento_cantidad_cafe, tipo_movimiento_cantidad_cafe, 
                                                                cantidad_cafe ,id_almacen_silo_piña)
                                    VALUES (@fecha, @cantidad, @tipo, @idAlmacenSiloPiña)";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@fecha", cantidad.FechaMovimiento);
                conexion.AgregarParametro("@cantidad", cantidad.CantidadCafe);
                conexion.AgregarParametro("@tipo", cantidad.TipoMovimiento);
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
                            FechaMovimiento = Convert.ToDateTime(reader["fecha_movimiento_cantidad_cafe"]),
                            CantidadCafe = Convert.ToDouble(reader["cantidad_cafe"]),
                            TipoMovimiento = Convert.ToString(reader["tipo_movimiento_cantidad_cafe"]),
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
                            FechaMovimiento = Convert.ToDateTime(reader["fecha_movimiento_cantidad_cafe"]),
                            CantidadCafe = Convert.ToDouble(reader["cantidad_cafe"]),
                            TipoMovimiento = Convert.ToString(reader["tipo_movimiento_cantidad_cafe"]),
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
                string consulta = @"SELECT c.id_cantidad_cafe, c.fecha_movimiento_cantidad_cafe,
                                  c.cantidad_cafe, c.tipo_movimiento_cantidad_cafe,
                                  c.id_almacen_silo_piña, a.nombre_almacen
                            FROM CantidadCafe_Silo_Piña c
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
                            FechaMovimiento = Convert.ToDateTime(reader["fecha_movimiento_cantidad_cafe"]),
                            CantidadCafe = Convert.ToDouble(reader["cantidad_cafe"]),
                            TipoMovimiento = Convert.ToString(reader["tipo_movimiento_cantidad_cafe"]),
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
                string consulta = @"SELECT c.id_cantidad_cafe, c.fecha_movimiento_cantidad_cafe,
                                  c.cantidad_cafe, c.tipo_movimiento_cantidad_cafe,
                                  c.id_almacen_silo_piña, a.nombre_almacen
                            FROM CantidadCafe_Silo_Piña c
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
                            FechaMovimiento = Convert.ToDateTime(reader["fecha_movimiento_cantidad_cafe"]),
                            CantidadCafe = Convert.ToDouble(reader["cantidad_cafe"]),
                            TipoMovimiento = Convert.ToString(reader["tipo_movimiento_cantidad_cafe"]),
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
                string consulta = @"SELECT c.id_cantidad_cafe, c.fecha_movimiento_cantidad_cafe,
                                  c.cantidad_cafe, c.tipo_movimiento_cantidad_cafe,
                                  c.id_almacen_silo_piña, a.nombre_almacen
                            FROM CantidadCafe_Silo_Piña c
                            INNER JOIN Almacen a ON c.id_almacen_silo_piña = a.id_almacen
                            WHERE a.nombre_almacen = @nombreA
                            WHERE a.nombre_almacen LIKE CONCAT('%', @search, '%')";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@search", "%" + buscar + "%");

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        CantidadSiloPiña cantidad = new CantidadSiloPiña()
                        {
                            IdCantidadCafe = Convert.ToInt32(reader["id_cantidad_cafe"]),
                            FechaMovimiento = Convert.ToDateTime(reader["fecha_movimiento_cantidad_cafe"]),
                            CantidadCafe = Convert.ToDouble(reader["cantidad_cafe"]),
                            TipoMovimiento = Convert.ToString(reader["tipo_movimiento_cantidad_cafe"]),
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
                            SET fecha_movimiento_cantidad_cafe = @fecha, cantidad_cafe = @cantidad, tipo_movimiento_cantidad_cafe = @tipo,
                                id_almacen_silo_piña = @idAlmacenSiloPiña
                            WHERE id_cantidad_cafe = @idCantidadCafe";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@fecha", cantidad.FechaMovimiento);
                conexion.AgregarParametro("@cantidad", cantidad.CantidadCafe);
                conexion.AgregarParametro("@tipo", cantidad.TipoMovimiento);
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
