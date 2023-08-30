using MySql.Data.MySqlClient;
using sistema_modular_cafe_majada.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace sistema_modular_cafe_majada.model.Connection
{
    class ConnectionDB
    {
        private MySqlConnection conexion;
        private MySqlCommand comando;

        public ConnectionDB()
        {
            Controlador_de_rutas Ruta = new Controlador_de_rutas();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Ruta.RutaXML); // Cambia esto a la ruta correcta de tu archivo XML

                string servidorCifrado = xmlDoc.SelectSingleNode("/Cifrado/Servidor").InnerText;
                string usuarioCifrado = xmlDoc.SelectSingleNode("/Cifrado/Usuario").InnerText;
                string contrasenaCifrada = xmlDoc.SelectSingleNode("/Cifrado/Contrasena").InnerText;
                string baseDeDatosCifrada = xmlDoc.SelectSingleNode("/Cifrado/BaseDeDatos").InnerText;

                string servidorDescifrado = EncryptionUtility.DecryptString(servidorCifrado);
                string usuarioDescifrado = EncryptionUtility.DecryptString(usuarioCifrado);
                string contrasenaDescifrada = EncryptionUtility.DecryptString(contrasenaCifrada);
                string baseDeDatosDescifrada = EncryptionUtility.DecryptString(baseDeDatosCifrada);

                // Construir la cadena de conexión con los valores descifrados
                string connectionString = $"Server={servidorDescifrado};Database={baseDeDatosDescifrada};User Id={usuarioDescifrado};Password={contrasenaDescifrada};";

                conexion = new MySqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar y descifrar valores del XML: " + ex.Message);
                // Manejar el error adecuadamente
            }
        }



        //private MySqlConnection connection;
        private string connectionString;

        public MySqlConnection Conectar()
        {
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            return conexion;
        }

        public void Desconectar()
        {
            if (conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
            }
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
