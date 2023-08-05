using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.Connection
{
    class ConnectionDB
    {
        private MySqlConnection conexion;
        private MySqlCommand comando;

        //ruta correcta al archivo XML
        string rutaArchivoConfiguracion = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings", "app.config");

        public ConnectionDB()
        {
            // Verificar si el archivo existe
            if (File.Exists(rutaArchivoConfiguracion))
            {
                // Cargar la configuración desde el archivo
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = rutaArchivoConfiguracion;
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                // Acceder a las credenciales de la base de datos
                string servidor = configuration.AppSettings.Settings["DBServer"].Value;
                string baseDatos = configuration.AppSettings.Settings["DBName"].Value;
                string usuario = configuration.AppSettings.Settings["DBUsername"].Value;
                string password = configuration.AppSettings.Settings["DBPassword1"].Value;

                string cadenaConexion = $"server={servidor};database={baseDatos};uid={usuario};password={password};";
                conexion = new MySqlConnection(cadenaConexion);
                
            }
            else
            {
                Console.WriteLine("El archivo de configuración no existe en la ruta especificada.");
            }
        }

        public void Conectar()
        {
            try
            {
                conexion.Open();
                //Console.WriteLine("Conexión establecida correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
        }

        public void Desconectar()
        {
            conexion.Close();
            //Console.WriteLine("Conexión cerrada correctamente");
        }

        // Aquí se añadiran más métodos para realizar consultas, inserciones, actualizaciones, etc.
        public void CrearComando(string consulta)
        {
            comando = new MySqlCommand(consulta, conexion);
            comando.CommandType = CommandType.Text;
        }

        public void AgregarParametro(string nombreParametro, object valorParametro)
        {
            comando.Parameters.AddWithValue(nombreParametro, valorParametro);
        }

        //
        public MySqlParameter ObtenerParametro(string nombreParametro)
        {
            return comando.Parameters[nombreParametro];
        }

        public object EjecutarConsultaEscalar()
        {
            return comando.ExecuteScalar();
        }

        public int EjecutarInstruccion()
        {
            return comando.ExecuteNonQuery();
        }
        public MySqlDataReader EjecutarConsultaReader(string consulta)
        {
            return comando.ExecuteReader();
        }



    }
}
