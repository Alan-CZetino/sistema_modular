﻿using sistema_modular_cafe_majada.model.DAO;
using sistema_modular_cafe_majada.model.Mapping.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.controller.InfrastructureController
{
    class BeneficioController
    {
        private BeneficioDAO beneficioDAO;

        public BeneficioController()
        {
            // Inicializa la instancia de la clase 
            beneficioDAO = new BeneficioDAO();
        }

        //
        public List<Beneficio> ObtenerBeneficios()
        {
            List<Beneficio> beneficios = new List<Beneficio>();

            try
            {
                // Llamada al método del DAO para obtener los roles
                beneficios = beneficioDAO.ObtenerBeneficios();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener los roles: " + ex.Message);
            }

            return beneficios;
        }

        //
        public Beneficio ObtenerBeneficioNombre(string nombre)
        {
            Beneficio beneficio = null;

            try
            {
                // Llamada al método del DAO para obtener el rol
                beneficio = beneficioDAO.ObtenerBeneficioNombre(nombre);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener el rol: " + ex.Message);
            }

            return beneficio;
        }

        //
        public bool InsertarBeneficio(Beneficio beneficio)
        {
            bool exito = false;

            try
            {
                // Llamada al método del DAO para insertar el rol
                exito = beneficioDAO.InsertarBeneficio(beneficio);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la inserción del rol: " + ex.Message);
            }

            return exito;
        }

        //
        public bool ActualizarBeneficio(int id, string nombre, string ubicacion)
        {
            bool exito = false;

            try
            {
                // Llamada al método del DAO para actualizar el rol
                exito = beneficioDAO.ActualizarBeneficio(id, nombre, ubicacion);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la actualización del Beneficio: " + ex.Message);
            }

            return exito;
        }

        //
        public void EliminarBeneficio(int id)
        {
            try
            {
                // Llamada al método del DAO para eliminar el rol
                beneficioDAO.EliminarBeneficio(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al eliminar el rol: " + ex.Message);
            }
        }

        //
        public Beneficio ObtenerIBeneficio(int id)
        {
            Beneficio beneficio = null;

            try
            {
                // Llamada al método del DAO para obtener el rol
                beneficio = beneficioDAO.ObtenerIdBeneficio(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener el rol: " + ex.Message);
            }

            return beneficio;
        }

    }
}
