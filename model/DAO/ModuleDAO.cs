using MySql.Data.MySqlClient;
using sistema_modular_cafe_majada.model.Acces;
using sistema_modular_cafe_majada.model.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.DAO
{
    class ModuleDAO
    {
        // funcion para obtener todos los usuarios
        private ConnectionDB conexion;

        public ModuleDAO()
        {
            // Inicializa la instancia de la clase ConexionBD
            conexion = new ConnectionDB();
        }

        //funcion para obtner los modulos de la bd utilizada en el login y
        public List<Module> ObtenerModulosCbx()
        {
            List<Module> modulos = new List<Module>();

            try
            {
                // Abre la conexión a la base de datos
                conexion.Conectar();

                string consulta = "SELECT DISTINCT id_modulo, nombre_modulo FROM Modulo";
                conexion.CrearComando(consulta);

                using (MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta))
                {
                    while (reader.Read())
                    {
                        Module modulo = new Module();
                        modulo.IdModule = Convert.ToInt32(reader["id_modulo"]);
                        modulo.NombreModulo = Convert.ToString(reader["nombre_modulo"]);
                        modulos.Add(modulo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los módulos: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Desconectar();
            }

            return modulos;
        }

        //obtener los modulos al cual pertenece el usuario
        public List<Module> ObtenerModulosDeUsuario(int idUsuario)
        {
            try
            {
                // Conectar a la base de datos
                conexion.Conectar();

                string query = @"SELECT m.id_modulo, m.nombre_modulo
                            FROM Modulo m
                            INNER JOIN Usuario_Modulo um ON um.id_modulo = m.id_modulo
                            WHERE um.id_usuario = @idUsuario";

                // Crear un comando con la consulta
                conexion.CrearComando(query);
                conexion.AgregarParametro("@idUsuario", idUsuario);

                List<Module> modulos = new List<Module>();

                using (var reader = conexion.EjecutarConsultaReader(query))
                {
                    while (reader.Read())
                    {
                        Module modulo = new Module();
                        modulo.IdModule = Convert.ToInt32(reader["id_modulo"]);
                        modulo.NombreModulo = Convert.ToString(reader["nombre_modulo"]);
                        modulos.Add(modulo);
                    }
                }

                return modulos;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los módulos del usuario: " + ex.Message);
                return null;
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.Desconectar();
            }
        }
    }
}
