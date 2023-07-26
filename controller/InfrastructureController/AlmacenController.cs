using sistema_modular_cafe_majada.model.DAO;
using sistema_modular_cafe_majada.model.Mapping.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.controller.InfrastructureController
{
    class AlmacenController
    {
        private AlmacenDAO almacenDAO;

        public AlmacenController()
        {
            // Inicializa la instancia de la clase 
            almacenDAO = new AlmacenDAO();
        }

        //
        public List<Almacen> ObtenerAlmacenNombreBodega()
        {
            try
            {
                // Llamada al método del DAO para obtener el nombre de la Almacen
                return almacenDAO.ObtenerAlmacenNombreBodega();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener la lista de Almacens: " + ex.Message);
                return new List<Almacen>();
            }
        }

        //
        public Almacen ObtenerIdAlmacen(int idAlmacen)
        {
            try
            {
                // Llamada al método del DAO para obtener el nombre de la Almacens
                return almacenDAO.ObtenerIdAlmacen(idAlmacen);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la Almacens: " + ex.Message);
                return null;
            }
        }

        //
        public Almacen ObtenerNombreAlmacen(string nombodega)
        {
            try
            {
                // Llamada al método del DAO para obtener el nombre de la Almacens
                return almacenDAO.ObtenerAlmacenNombre(nombodega);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la Almacens: " + ex.Message);
                return null;
            }
        }

        //
        public bool InsertarAlmacen(Almacen almacen)
        {
            try
            {
                // Llamada al método del DAO para insertar la almacen
                return almacenDAO.InsertarAlmacen(almacen);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la inserción de Almacen en la base de datos: " + ex.Message);
                return false;
            }
        }

        //
        public List<Almacen> ObtenerAlmacens()
        {
            try
            {
                // Llamada al método del DAO para obtener las Almacens
                return almacenDAO.ObtenerAlmacenes();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener la lista de Almacens: " + ex.Message);
                return new List<Almacen>();
            }
        }

        //
        public List<Almacen> BuscarAlmacens(string buscar)
        {
            try
            {
                // Llamada al método del DAO para obtener las Almacens
                return almacenDAO.BuscarAlmacen(buscar);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener la lista de Almacens: " + ex.Message);
                return new List<Almacen>();
            }
        }

        //
        public bool ActualizarAlmacens(int idAlmacen, string nombre, string descripcion, double capacidad, string ubicacion, int idBodega)
        {
            try
            {
                // Llamada al método del DAO para actualizar la Almacens
                return almacenDAO.ActualizarAlmacen(idAlmacen, nombre, descripcion, capacidad, ubicacion, idBodega);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al actualizar la Almacens: " + ex.Message);
                return false;
            }
        }

        //
        public void EliminarAlmacens(int idAlmacens)
        {
            try
            {
                // Llamada al método del DAO para eliminar la Almacens
                almacenDAO.EliminarAlmacen(idAlmacens);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al eliminar la Almacens: " + ex.Message);
            }
        }

    }
}
