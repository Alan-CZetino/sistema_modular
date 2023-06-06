using sistema_modular_cafe_majada.model.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.controller.SecurityData
{
    class LogController
    {
        private ConnectionDB conexionBD;

        public LogController()
        {
            // Obtiene la cadena de conexión de la configuración de la aplicación
            conexionBD = new ConnectionDB();
        }

        public void RegistrarLog(int idUsuario, string descripcion, string modulo, string tipoAccion, string datosAdicionales)
        {

            try
            {
                // Abre la conexión
                conexionBD.Conectar();

                string direccionIP = ObtenerDireccionIP();
                string direccionMAC = ObtenerDireccionMAC();

                // Crea un nuevo comando para insertar el log en la base de datos
                string query = "INSERT INTO Log (id_usuario_log, fecha_hora_log, descripcion_log, modulo_log, " +
                    "tipo_accion_log, direccion_ip_log, direccion_mac_log, datos_adic_log) " +
                    "VALUES (@IdUsuario, @FechaHora, @Descripcion, @Modulo, @TipoAccion, @DireccionIP, @DireccionMAC, @DatosAdicionales)";

                conexionBD.CrearComando(query);
                conexionBD.AgregarParametro("@IdUsuario", idUsuario);
                conexionBD.AgregarParametro("@FechaHora", DateTime.Now);
                conexionBD.AgregarParametro("@Descripcion", descripcion);
                conexionBD.AgregarParametro("@Modulo", modulo);
                conexionBD.AgregarParametro("@TipoAccion", tipoAccion);
                conexionBD.AgregarParametro("@DireccionIP", direccionIP);
                conexionBD.AgregarParametro("@DireccionMAC", direccionMAC);
                conexionBD.AgregarParametro("@DatosAdicionales", datosAdicionales);

                // Ejecuta el comando
                conexionBD.EjecutarInstruccion();
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que ocurra al registrar el log
                Console.WriteLine("Error al registrar el log: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión
                conexionBD.Desconectar();
            }
        }

        // Método para obtener la dirección IP del cliente
        private string ObtenerDireccionIP()
        {
            string direccionIP = string.Empty;

            try
            {
                // Obtener el nombre del host local
                string hostName = Dns.GetHostName();

                // Obtener la información de entrada del host
                IPHostEntry hostEntry = Dns.GetHostEntry(hostName);

                // Obtener la primera dirección IP disponible en la lista de direcciones
                IPAddress ipAddress = hostEntry.AddressList.FirstOrDefault();

                if (ipAddress != null)
                {
                    direccionIP = ipAddress.ToString();
                }
            }
            catch (Exception ex)
            {
                string mensajeError = "Ocurrió un error al obtener la dirección IP: " + ex.Message;
                //string rutaArchivoLog = "ruta_del_archivo_log.txt";

                Console.WriteLine(mensajeError);
                // Escribir el mensaje de error en el archivo de registro
                /*using (StreamWriter writer = new StreamWriter(rutaArchivoLog, true))
                {
                    writer.WriteLine(mensajeError);
                }*/
            }

            return direccionIP;
        }

        // Método para obtener la dirección MAC del cliente
        private string ObtenerDireccionMAC()
        {
            string macAddress = string.Empty;

            try
            {
                // Obtener todas las interfaces de red disponibles
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

                // Recorrer las interfaces de red y obtener la dirección MAC de la primera interfaz con dirección física (MAC)
                foreach (NetworkInterface networkInterface in interfaces)
                {
                    if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                        || networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    {
                        macAddress = networkInterface.GetPhysicalAddress().ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                string mensajeError = "Ocurrió un error al obtener la dirección MAC: " + ex.Message;
                //string rutaArchivoLog = "ruta_del_archivo_log.txt";

                Console.WriteLine(mensajeError);
                // Escribir el mensaje de error en el archivo de registro
                /*using (StreamWriter writer = new StreamWriter(rutaArchivoLog, true))
                {
                    writer.WriteLine(mensajeError);
                }*/
            }

            return macAddress;
        }
    }
}
