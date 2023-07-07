﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using sistema_modular_cafe_majada.model.Mapping;
using sistema_modular_cafe_majada.model.Connection;

namespace sistema_modular_cafe_majada.model.DAO
{
    class CalidadCafeDAO
    {

        private ConnectionDB conexion;

        public CalidadCafeDAO()
        {
            //Inicializa la instancia de la clase conexion
            conexion = new ConnectionDB();
        }

        public bool InsertarCalidadCafe(CalidadCafe calidadCafe )
        {
            try
            {
                //conexion a la base de datos
                conexion.Conectar();

                //Se crea la consulta para insertar las calidades de cafe
                string consulta = @"INSERT INTO calidad_cafe (id_calidad,nombre_calidad,descripcion)
                                  VALUES (@IdCalidad, @Calidad, @Comentario)";
                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@IdCalidad", calidadCafe.IdCalidad);
                conexion.AgregarParametro("@Calidad", calidadCafe.nombreCalidad);
                conexion.AgregarParametro("@Comentario", calidadCafe.descripcionCalidad);

                int filasAfectadas = conexion.EjecutarInstruccion();

                return filasAfectadas > 0; //si la fila se afecta, inserto la calidad con exito

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error durante la inserción de la calidad del café en la base de datos: " + ex.Message);
                return false;
            }
            finally
            {
                //Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }

        }

        public List<CalidadCafe> ObtenerCalidades()
        {
            List<CalidadCafe> calidadesCafe = new List<CalidadCafe>();

            try
            {
                //Se conecta con la base de datos
                conexion.Conectar();

                string consulta = @"SELECT * FROM calidad_cafe";
                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        CalidadCafe calCafe = new CalidadCafe()
                        {
                            IdCalidad = Convert.ToInt32(reader["id_calidad"]),
                            nombreCalidad = Convert.ToString(reader["nombre_calidad"]),
                            descripcionCalidad = Convert.ToString(reader["descripcion"])
                        };

                        calidadesCafe.Add(calCafe);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ocurrio un error al obtener los datos: " + ex.Message);
            }
            finally
            {
                //se cierra la conexion a la base de datos
                conexion.Desconectar();
            }
            return calidadesCafe;
        }

        public bool ActualizarCalidades(int id,string cCafe, string descrip)
        {
            bool exito = false;

            try
            {
                //conexion a base de datos
                conexion.Conectar();

                string consulta = @"UPDATE calidad_cafe SET nombre_calidad=@nomCalidad,descripcion=@dCalidad
                                  WHERE id_calidad=@id";

                conexion.CrearComando(consulta);

                conexion.AgregarParametro("@nomCalidad", cCafe);
                conexion.AgregarParametro("@dCalidad",descrip);
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
            catch(Exception ex)
            {
                Console.WriteLine("Ocurrio un error al actualizar los datos: " + ex.Message);
            }
            finally
            {
                //se cierra la conexion con la base de datos
                conexion.Desconectar();
            }

            return exito;
        }

        //public CalidadCafe Obtenerpersona(string nomCalidad)
        //{
        //    CalidadCafe calidad = null;

        //    try
        //    {
        //        conexion.Conectar();

        //        string consulta = "SELECT * FROM calidad_cafe WHERE nombre_calidad = @nomCal";
        //        conexion.CrearComando(consulta);
        //        conexion.AgregarParametro("@nomCal", nomCalidad);

        //        using(MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
        //        {
        //            if(reader.Read())
        //            {
        //                calidad = new CalidadCafe()
        //                {
        //                    IdCalidad = Convert.ToInt32(reader["id_calidad"]),
        //                    nombreCalidad = Convert.ToString(reader["nombre_calidad"]),
        //                    descripcionCalidad = Convert.ToString(reader["descripcion"])
        //                };
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine("Ocurrio un error al obtener los datos: " + ex.Message);
        //    }
        //    finally
        //    {
        //        conexion.Desconectar();
        //    }
        //}

        public void EliminarCalidad (int idCalidad)
        {
            try
            {
                //conexion a la base de datos
                conexion.Conectar();

                //se crea el comando SQL 
                string consulta = @"DELETE FROM calidad_cafe WHERE id_calidad=@idCal";
                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@idCal", idCalidad);

                //se ejecuta la isntruccion
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
            catch(Exception ex)
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