﻿using sistema_modular_cafe_majada.model.DAO;
using sistema_modular_cafe_majada.model.Mapping.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.controller.OperationsController
{
    class PersonalController
    {
        private PersonalDAO personalDAO;

        public PersonalController()
        {
            // Inicializa la instancia de la clase 
            personalDAO = new PersonalDAO();
        }

        //
        public List<Personal> ObtenerPersonals()
        {
            List<Personal> personals = new List<Personal>();

            try
            {
                // Llamada al método del DAO para obtener los roles
                personals = personalDAO.ObtenerPersonales();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener los roles: " + ex.Message);
            }

            return personals;
        }

        //
        public Personal ObtenerPersonalNombre(string nombre)
        {
            Personal personal = null;

            try
            {
                // Llamada al método del DAO para obtener el rol
                personal = personalDAO.ObtenerPersonalNombre(nombre);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener el rol: " + ex.Message);
            }

            return personal;
        }

        //
        public bool InsertarPersonal(Personal personal)
        {
            bool exito = false;

            try
            {
                // Llamada al método del DAO para insertar el rol
                exito = personalDAO.InsertarPersonal(personal);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la inserción del rol: " + ex.Message);
            }

            return exito;
        }

        //
        public bool ActualizarPersonal(int id, string nombre, string cargo, string descripcion, int idPersona)
        {
            bool exito = false;

            try
            {
                // Llamada al método del DAO para actualizar el rol
                exito = personalDAO.ActualizarPersonal(id, nombre, cargo, descripcion, idPersona);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la actualización del Personal: " + ex.Message);
            }

            return exito;
        }

        //
        public void EliminarPersonal(int id)
        {
            try
            {
                // Llamada al método del DAO para eliminar el rol
                personalDAO.EliminarPersonal(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al eliminar el rol: " + ex.Message);
            }
        }

        //
        public Personal ObtenerIPersonal(int id)
        {
            Personal personal = null;

            try
            {
                // Llamada al método del DAO para obtener el rol
                personal = personalDAO.ObtenerIdPersonal(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener el Personal: " + ex.Message);
            }

            return personal;
        }

    }
}
