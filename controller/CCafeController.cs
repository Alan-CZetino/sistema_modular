﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sistema_modular_cafe_majada.model.DAO;
using sistema_modular_cafe_majada.model.Mapping;

namespace sistema_modular_cafe_majada.controller
{
    class CCafeController
    {

        private CalidadCafeDAO ccafeDAO;

        public CCafeController()
        {
            // Se inicia la instancia de la clase CalidadCafeDAO
            ccafeDAO = new CalidadCafeDAO();
        }

        public bool InsertarCalidad(CalidadCafe calidadCafe)
        {
            try
            {
                //Se realiza el llamado al metodo DAO para insertar
                return ccafeDAO.InsertarCalidadCafe(calidadCafe);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ocurrio un error durante la inserción de la calidad del café en la base de datos: " + ex.Message);
                return false;
            }
        }

        public List<CalidadCafe> ObtenerCalidades()
        {
            try
            {
                //se llama al metodo DAO para obtener las calidades
                return ccafeDAO.ObtenerCalidades();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ocurrio un error al obtener la lista de calidades de café: " + ex.Message);
                return new List<CalidadCafe>();
            }
        }

        //public CalidadCafe ObtenerCalidad (string nomCalidad)
        //{
        //    try
        //    {
        //        //llamada al metodo DAO para obtener los datos
        //        return ccafeDAO.ObtenerCalidades(nomCalidad);
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine("Ocurrio un error la obtener los datos: " + ex.Message);
        //        return null;
        //    }
        //}

        public void EliminarCalidades(int idCalidades)
        {
            try
            {
                // se realiza el llamado el metodo DAO para eliminar
                ccafeDAO.EliminarCalidad(idCalidades);
            }
            catch(Exception ex)
            {
                Console.WriteLine("OCurrio un error al eliminar una calidad de café: " + ex.Message);
            }
        }

        public bool ActualizarCalidades(int id,string calidad, string descrip)
        {
            try
            {
                //llamada al metodo DAO para actualizar
                return ccafeDAO.ActualizarCalidades(id, calidad, descrip);
            }
            catch(Exception ex)
            {
                Console.WriteLine("OCurrio un error al actualizar los datos: " + ex.Message);
                return false;
            }
        }
    }
}
