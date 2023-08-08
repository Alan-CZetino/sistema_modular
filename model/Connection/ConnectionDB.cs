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

        public ConnectionDB()
        {
            connectionString = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;
            conexion = new MySqlConnection(connectionString);
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
