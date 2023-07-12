﻿using MySql.Data.MySqlClient;
using sistema_modular_cafe_majada.model.Connection;
using sistema_modular_cafe_majada.model.Mapping.Harvest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.DAO
{
    class LoteDAO
    {
        private ConnectionDB conexion;

        public LoteDAO()
        {
            //Se crea la instancia de la clase conexion
            conexion = new ConnectionDB();
        }

        //funcion para insertar un nuevo registro en la base de datos
        public bool InsertarLote(Lote lote)
        {
            try
            {
                //conexion a la base de datos
                conexion.Conectar();

                //se crea script SQL para insertar
                string consulta = @"INSERT INTO Lote (nombre_lote, fecha_lote, cantidad_lote, tipo_cafe_lote, id_calidad_lote, id_cosecha_lote, id_finca_lote)
                                    VALUES ( @nombre, @fecha, @cantidad, @tipo, @idCalida, @idCosecha, @idFinca)";
                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@nombre", lote.NombreLote);
                conexion.AgregarParametro("@fecha", DateTime.Now);
                conexion.AgregarParametro("@cantidad", lote.CantidadLote);
                conexion.AgregarParametro("@tipo", lote.TipoCafe);
                conexion.AgregarParametro("@idCalidad", lote.IdCalidadLote);
                conexion.AgregarParametro("@idCosecha", lote.IdCosechaLote);
                conexion.AgregarParametro("@idFinca", lote.IdFinca);

                int filasAfectadas = conexion.EjecutarInstruccion();

                //si la fila se afecta, se inserto correctamente
                return filasAfectadas > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error durante la inserción del Lote en la base de datos: " + ex.Message);
                return false;
            }
            finally
            {
                //Se cierra la conexion a la base de datos
                conexion.Desconectar();
            }
        }

        //funcion para mostrar todos los registros
        public List<Lote> ObtenerLotes()
        {
            List<Lote> listaLote = new List<Lote>();

            try
            {
                //Se conecta con la base de datos
                conexion.Conectar();

                string consulta = @"SELECT * FROM Lote";
                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Lote lotes = new Lote()
                        {
                            IdLote = Convert.ToInt32(reader["id_lote"]),
                            NombreLote = Convert.ToString(reader["nombre_lote"]),
                            FechaLote = Convert.ToDateTime(reader["fecha_lote"]),
                            CantidadLote = Convert.ToDouble(reader["cantidad_lote"]),
                            TipoCafe = Convert.ToString(reader["tipo_cafe_lote"]),
                            IdCalidadLote = Convert.ToInt32(reader["id_calidad_lote"]),
                            IdCosechaLote = Convert.ToInt32(reader["id_cosecha_lote"]),
                            IdFinca = Convert.ToInt32(reader["id_finca_lote"])
                        };

                        listaLote.Add(lotes);
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
            return listaLote;
        }

        //obtener el Lote en especifico mediante el id en la BD
        public Lote ObtenerIdLote(int id)
        {
            Lote lote = null;

            try
            {
                // Conectar a la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el rol
                string consulta = "SELECT * FROM Lote WHERE id_lote = @Id";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@Id", id);

                // Ejecutar la consulta y leer el resultado
                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows && reader.Read())
                    {
                        lote = new Lote()
                        {
                            IdLote = Convert.ToInt32(reader["id_lote"]),
                            NombreLote = Convert.ToString(reader["nombre_lote"]),
                            FechaLote = Convert.ToDateTime(reader["fecha_lote"]),
                            CantidadLote = Convert.ToDouble(reader["cantidad_lote"]),
                            TipoCafe = Convert.ToString(reader["tipo_cafe_lote"]),
                            IdCalidadLote = Convert.ToInt32(reader["id_calidad_lote"]),
                            IdCosechaLote = Convert.ToInt32(reader["id_cosecha_lote"]),
                            IdFinca = Convert.ToInt32(reader["id_finca_lote"])
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el Lote: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }

            return lote;
        }

        //obtener el lote en especifico mediante el id en la BD
        public Lote ObtenerLoteNombre(string nombre)
        {
            Lote lote = null;

            try
            {
                // Conectar a la base de datos
                conexion.Conectar();

                // Crear la consulta SQL para obtener el rol
                string consulta = "SELECT * FROM Lote WHERE nombre_lote = @nombreLote";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@nombreLote", nombre);

                // Ejecutar la consulta y leer el resultado
                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    if (reader.HasRows && reader.Read())
                    {
                        lote = new Lote()
                        {
                            IdLote = Convert.ToInt32(reader["id_lote"]),
                            NombreLote = Convert.ToString(reader["nombre_lote"]),
                            FechaLote = Convert.ToDateTime(reader["fecha_lote"]),
                            CantidadLote = Convert.ToDouble(reader["cantidad_lote"]),
                            TipoCafe = Convert.ToString(reader["tipo_cafe_lote"]),
                            IdCalidadLote = Convert.ToInt32(reader["id_calidad_lote"]),
                            IdCosechaLote = Convert.ToInt32(reader["id_cosecha_lote"]),
                            IdFinca = Convert.ToInt32(reader["id_finca_lote"])
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el lote: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }

            return lote;
        }

        //funcion para actualizar un registro en la base de datos
        public bool ActualizarLote(int id, string nombre, double cantidad, string tipo, int idCalidad, int idCosecha, int idFinca)
        {
            bool exito = false;

            try
            {
                //conexion a la base de datos
                conexion.Conectar();

                //se crea el script SQL 
                string consulta = @"UPDATE Lote SET nombre_lote = @nombre, fecha_lote = @fecha, cantidad_lote = @cantidad, tipo_cafe_lote = @tipo, 
                                        id_calidad_lote = @calidad, id_cosecha_lote = @idCosecha, id_finca_lote = @idFinca
                                    WHERE id_lote = @id";
                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@nombre", nombre);
                conexion.AgregarParametro("@fecha", DateTime.Today);
                conexion.AgregarParametro("@cantidad", cantidad);
                conexion.AgregarParametro("@tipo", tipo);
                conexion.AgregarParametro("@idCalidad", idCalidad);
                conexion.AgregarParametro("@idCosecha", idCosecha);
                conexion.AgregarParametro("@idFinca", idFinca);
                conexion.AgregarParametro("@id", id);

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
        public void EliminarLote(int id)
        {
            try
            {
                //conexion a la base de datos
                conexion.Conectar();

                //se crea script SQL
                string consulta = @"DELETE FROM Lote WHERE id_lote = @id";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@id", id);

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
