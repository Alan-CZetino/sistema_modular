using sistema_modular_cafe_majada.model.DAO;
using sistema_modular_cafe_majada.model.Mapping.Harvest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.controller.HarvestController
{
    class CosechaController
    {
        private CosechaDAO cosechaDAO;

        public CosechaController()
        {
            // Inicializa la instancia de la clase 
            cosechaDAO = new CosechaDAO();
        }

        //
        public List<Cosecha> ObtenerCosecha()
        {
            List<Cosecha> cosechas = new List<Cosecha>();

            try
            {
                // Llamada al método del DAO para obtener los roles
                cosechas = cosechaDAO.ObtenerCosecha();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener los roles: " + ex.Message);
            }

            return cosechas;
        }

        //
        public Cosecha ObtenerNombreCosecha(string nombre)
        {
            Cosecha cosecha = null;

            try
            {
                // Llamada al método del DAO para obtener el rol
                cosecha = cosechaDAO.ObtenerNombreCosecha(nombre);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener la cosecha: " + ex.Message);
            }

            return cosecha;
        }

        //
        public bool InsertarCosecha(Cosecha cosecha)
        {
            bool exito = false;

            try
            {
                // Llamada al método del DAO para insertar el rol
                exito = cosechaDAO.InsertarCosecha(cosecha);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la inserción de la cosecha: " + ex.Message);
            }

            return exito;
        }

        //
        public bool ActualizarCosecha(int id, string nombre, DateTime fecha)
        {
            bool exito = false;

            try
            {
                // Llamada al método del DAO para actualizar el rol
                exito = cosechaDAO.ActualizarCosecha(id, nombre, fecha);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la actualización de la cosecha: " + ex.Message);
            }

            return exito;
        }

        //
        public void EliminarCosecha(int id)
        {
            try
            {
                // Llamada al método del DAO para eliminar el rol
                cosechaDAO.EliminarCosecha(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al eliminar la cosecha: " + ex.Message);
            }
        }

        //
        public Cosecha ObtenerICosecha(int id)
        {
            Cosecha cosecha = null;

            try
            {
                // Llamada al método del DAO para obtener el rol
                cosecha = cosechaDAO.ObtenerIdCosecha(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener el rol: " + ex.Message);
            }

            return cosecha;
        }

    }
}
