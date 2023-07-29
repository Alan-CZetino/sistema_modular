using MySql.Data.MySqlClient;
using sistema_modular_cafe_majada.model.Connection;
using sistema_modular_cafe_majada.model.Mapping.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.DAO
{
    class AlmacenDAO
    {
        private ConnectionDB conexion;

        public AlmacenDAO()
        {
            //Se crea la instancia de la clase conexion
            conexion = new ConnectionDB();
        }

        //funcion para insertar un nuevo registro en la base de datos
        public bool InsertarAlmacen(Almacen almacen)
        {
            try
            {
                //conexion a la base de datos
                conexion.Conectar();

                //se crea script SQL para insertar
                string consulta = @"INSERT INTO Almacen ( nombre_almacen, descripcion_almacen,  capacidad_almacen ,ubicacion_almacen, id_bodega_ubicacion_almacen)
                                    VALUES ( @nombre, @descrip, @capacidad, @ubicacion, @iBodega)";
                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@nombre", almacen.NombreAlmacen);
                conexion.AgregarParametro("@descrip", almacen.DescripcionAlmacen);
                conexion.AgregarParametro("@capacidad", almacen.CapacidadAlmacen);
                conexion.AgregarParametro("@ubicacion", almacen.UbicacionAlmacen);
                conexion.AgregarParametro("@iBodega", almacen.IdBodegaUbicacion);

                int filasAfectadas = conexion.EjecutarInstruccion();

                //si la fila se afecta, se inserto correctamente
                return filasAfectadas > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error durante la inserción de la Almacen en la base de datos: " + ex.Message);
                return false;
            }
            finally
            {
                //Se cierra la conexion a la base de datos
                conexion.Desconectar();
            }
        }

        //funcion para mostrar todos los registros
        public List<Almacen> ObtenerAlmacenes()
        {
            List<Almacen> listaAlmacen = new List<Almacen>();

            try
            {
                //Se conecta con la base de datos
                conexion.Conectar();

                string consulta = @"SELECT * FROM Almacen";
                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Almacen Almacens = new Almacen()
                        {
                            IdAlmacen = Convert.ToInt32(reader["id_almacen"]),
                            NombreAlmacen = Convert.ToString(reader["descripcion_almacen"]),
                            DescripcionAlmacen = Convert.ToString(reader["nombre_almacen"]),
                            CapacidadAlmacen = Convert.ToDouble(reader["capacidad_almacen"]),
                            UbicacionAlmacen = Convert.ToString(reader["ubicacion_almacen"]),
                            IdBodegaUbicacion = Convert.ToInt32(reader["id_bodega_ubicacion_almacen"])
                        };

                        listaAlmacen.Add(Almacens);
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
            return listaAlmacen;
        }

        //obtener la Almacen en especifico mediante el id en la BD
        public Almacen ObtenerIdAlmacen(int idAlmacen)
        {
            Almacen Almacen = null;

            try
            {
                // Conectar a la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el rol
                string consulta = "SELECT * FROM Almacen WHERE id_almacen = @Id";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@Id", idAlmacen);

                // Ejecutar la consulta y leer el resultado
                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows && reader.Read())
                    {
                        Almacen = new Almacen()
                        {
                            IdAlmacen = Convert.ToInt32(reader["id_almacen"]),
                            NombreAlmacen = Convert.ToString(reader["descripcion_almacen"]),
                            DescripcionAlmacen = Convert.ToString(reader["nombre_almacen"]),
                            CapacidadAlmacen = Convert.ToDouble(reader["capacidad_almacen"]),
                            UbicacionAlmacen = Convert.ToString(reader["ubicacion_almacen"]),
                            IdBodegaUbicacion = Convert.ToInt32(reader["id_bodega_ubicacion_almacen"])
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el Almacen: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }

            return Almacen;
        }

        //obtener la Almacen en especifico mediante el id de la maquinaria en la BD
        public Almacen ObtenerAlmacenNombre(string nombreAlmacen)
        {
            Almacen Almacen = null;

            try
            {
                // Conectar a la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el rol
                string consulta = @"SELECT a.id_almacen, a.nombre_almacen, a.descripcion_almacen, a.capacidad_almacen, a.ubicacion_almacen, a.id_bodega_ubicacion_almacen, b.nombre_bodega
                                        FROM Almacen a
                                        INNER JOIN Bodega_Cafe b ON a.id_bodega_ubicacion_almacen = b.id_bodega
                                        WHERE b.nombre_bodega = @nombreM";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@nombreM", nombreAlmacen);

                // Ejecutar la consulta y leer el resultado
                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows && reader.Read())
                    {
                        Almacen = new Almacen()
                        {
                            IdAlmacen = Convert.ToInt32(reader["id_almacen"]),
                            NombreAlmacen = Convert.ToString(reader["descripcion_almacen"]),
                            DescripcionAlmacen = Convert.ToString(reader["nombre_almacen"]),
                            CapacidadAlmacen = Convert.ToDouble(reader["capacidad_almacen"]),
                            UbicacionAlmacen = Convert.ToString(reader["ubicacion_almacen"]),
                            IdBodegaUbicacion = Convert.ToInt32(reader["id_bodega_ubicacion_almacen"]),
                            NombreBodegaUbicacion = Convert.ToString(reader["nombre_bodega"])
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el Almacen: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }

            return Almacen;
        }

        //obtener la Almacen y el nombre maquinaria en la BD
        public List<Almacen> ObtenerAlmacenNombreBodega()
        {
            List<Almacen> listaAlmacen = new List<Almacen>();

            try
            {
                // Conectar a la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el rol
                string consulta = @"SELECT a.id_almacen, a.nombre_almacen, a.descripcion_almacen, a.capacidad_almacen, a.ubicacion_almacen, a.id_bodega_ubicacion_almacen, b.nombre_bodega
                                        FROM Almacen a
                                        INNER JOIN Bodega_Cafe b ON a.id_bodega_ubicacion_almacen = b.id_bodega";

                conexion.CrearComando(consulta);

                // Ejecutar la consulta y leer el resultado
                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Almacen almacen = new Almacen()
                        {
                            IdAlmacen = Convert.ToInt32(reader["id_almacen"]),
                            NombreAlmacen = Convert.ToString(reader["descripcion_almacen"]),
                            DescripcionAlmacen = Convert.ToString(reader["nombre_almacen"]),
                            CapacidadAlmacen = Convert.ToDouble(reader["capacidad_almacen"]),
                            UbicacionAlmacen = Convert.ToString(reader["ubicacion_almacen"]),
                            IdBodegaUbicacion = Convert.ToInt32(reader["id_bodega_ubicacion_almacen"]),
                            NombreBodegaUbicacion = Convert.ToString(reader["nombre_bodega"])
                        };
                        listaAlmacen.Add(almacen);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el Almacen: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }

            return listaAlmacen;
        }

        //
        public List<Almacen> BuscarAlmacen(string buscar)
        {
            List<Almacen> almacens = new List<Almacen>();

            try
            {
                //Se conecta con la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el rol
                string consulta = @"SELECT a.id_almacen, a.nombre_almacen, a.descripcion_almacen, a.capacidad_almacen, a.ubicacion_almacen, a.id_bodega_ubicacion_almacen, b.nombre_bodega
                                        FROM Almacen a
                                        INNER JOIN Bodega_Cafe b ON a.id_bodega_ubicacion_almacen = b.id_bodega
                                        WHERE b.nombre_bodega LIKE CONCAT('%', @search, '%') OR a.nombre_almacen LIKE CONCAT('%', @search, '%') 
                                                OR a.id_bodega_ubicacion_almacen LIKE CONCAT('%', @search, '%')";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@search", "%" + buscar + "%");

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Almacen almacen = new Almacen()
                        {
                            IdAlmacen = Convert.ToInt32(reader["id_almacen"]),
                            NombreAlmacen = Convert.ToString(reader["descripcion_almacen"]),
                            DescripcionAlmacen = Convert.ToString(reader["nombre_almacen"]),
                            CapacidadAlmacen = Convert.ToDouble(reader["capacidad_almacen"]),
                            UbicacionAlmacen = Convert.ToString(reader["ubicacion_almacen"]),
                            IdBodegaUbicacion = Convert.ToInt32(reader["id_bodega_ubicacion_almacen"]),
                            NombreBodegaUbicacion = Convert.ToString(reader["nombre_bodega"])
                        };

                        almacens.Add(almacen);
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
            return almacens;
        }
        
        //
        public List<Almacen> BuscarIDBodegaAlmacen(int buscar)
        {
            List<Almacen> almacens = new List<Almacen>();

            try
            {
                //Se conecta con la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el rol
                string consulta = @"SELECT a.id_almacen, a.nombre_almacen, a.descripcion_almacen, a.capacidad_almacen, a.ubicacion_almacen, a.id_bodega_ubicacion_almacen, b.nombre_bodega
                                        FROM Almacen a
                                        INNER JOIN Bodega_Cafe b ON a.id_bodega_ubicacion_almacen = b.id_bodega
                                        WHERE a.id_bodega_ubicacion_almacen LIKE CONCAT('%', @search, '%')";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@search", "%" + buscar + "%");

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Almacen almacen = new Almacen()
                        {
                            IdAlmacen = Convert.ToInt32(reader["id_almacen"]),
                            NombreAlmacen = Convert.ToString(reader["descripcion_almacen"]),
                            DescripcionAlmacen = Convert.ToString(reader["nombre_almacen"]),
                            CapacidadAlmacen = Convert.ToDouble(reader["capacidad_almacen"]),
                            UbicacionAlmacen = Convert.ToString(reader["ubicacion_almacen"]),
                            IdBodegaUbicacion = Convert.ToInt32(reader["id_bodega_ubicacion_almacen"]),
                            NombreBodegaUbicacion = Convert.ToString(reader["nombre_bodega"])
                        };

                        almacens.Add(almacen);
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
            return almacens;
        }

        //funcion para actualizar un registro en la base de datos
        public bool ActualizarAlmacen(int idAlmacen, string nombre, string descripcion, double capacidad, string ubicacion, int idBodega)
        {
            bool exito = false;

            try
            {
                //conexion a la base de datos
                conexion.Conectar();

                //se crea el script SQL 
                string consulta = @"UPDATE Almacen SET nombre_almacen = @nombre, descripcion_almacen = @descrip, capacidad_almacen = @capacidad, 
                                                        ubicacion_almacen = @ubicacion, id_bodega_ubicacion_almacen = @iBodega
                                    WHERE id_almacen = @id";
                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@nombre", nombre);
                conexion.AgregarParametro("@descrip", descripcion);
                conexion.AgregarParametro("@capacidad", capacidad);
                conexion.AgregarParametro("@ubicacion", ubicacion);
                conexion.AgregarParametro("@iBodega", idBodega);
                conexion.AgregarParametro("@id", idAlmacen);

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
                Console.WriteLine("Ocurrio un error al actualizar los datos: " + ex.Message);
            }
            finally
            {
                //se cierra la conexion con la base de datos{
                conexion.Desconectar();
            }

            return exito;
        }

        //funcion para eliminar un registro de la base de datos
        public void EliminarAlmacen(int idAlmacen)
        {
            try
            {
                //conexion a la base de datos
                conexion.Conectar();

                //se crea script SQL
                string consulta = @"DELETE FROM Almacen WHERE id_almacen = @id";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@id", idAlmacen);

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
