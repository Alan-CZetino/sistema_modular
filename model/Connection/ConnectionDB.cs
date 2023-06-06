using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.model.Connection
{
    class ConnectionDB
    {
        private MySqlConnection conexion;
        private MySqlCommand comando;

        public ConnectionDB()
        {
            string servidor = "localhost";              // Cambiar esto por la dirección del servidor de la base de datos
            string baseDatos = "Cooperativa_Prueba";    // Cambiar esto por el nombre de la base de datos
            string usuario = "root";                    // Cambiar esto por tu nombre de usuario
            string password = "2001";                   // Cambiar esto por tu contraseña

            string cadenaConexion = $"server={servidor};database={baseDatos};uid={usuario};password={password};";
            conexion = new MySqlConnection(cadenaConexion);
        }

        public void Conectar()
        {
            try
            {
                conexion.Open();
                Console.WriteLine("Conexión establecida correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
        }

        public void Desconectar()
        {
            conexion.Close();
            Console.WriteLine("Conexión cerrada correctamente");
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
