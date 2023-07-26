﻿using sistema_modular_cafe_majada.model.DAO;
using sistema_modular_cafe_majada.model.Mapping.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_modular_cafe_majada.controller.OperationsController
{
    class SubPartidaController
    {
        private SubPartidaDAO subPartidaDAO;

        public SubPartidaController()
        {
            // Inicializa la instancia de la clase 
            subPartidaDAO = new SubPartidaDAO();
        }

        //
        public List<SubPartida> ObtenerSubPartidas()
        {
            try
            {
                // Llamada al método del DAO para obtener el nombre de las SubPartida
                return subPartidaDAO.ObtenerSubPartidas();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener la lista de SubPartida: " + ex.Message);
                return new List<SubPartida>();
            }
        }

        //
        public SubPartida ObtenerSubPartidaPorID(int idSubPartida)
        {
            try
            {
                // Llamada al método del DAO para obtener el nombre de la SubPartida
                return subPartidaDAO.ObtenerSubPartidaPorID(idSubPartida);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la SubPartida: " + ex.Message);
                return null;
            }
        }

        //
        public bool InsertarSubPartida(SubPartida subPartida)
        {
            try
            {
                // Llamada al método del DAO para insertar la SubPartida
                return subPartidaDAO.InsertarSubPartida(subPartida);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error durante la inserción de SubPartida en la base de datos: " + ex.Message);
                return false;
            }
        }

        //
        public List<SubPartida> ObtenerSubPartidasNombres()
        {
            try
            {
                // Llamada al método del DAO para obtener las SubPartida
                return subPartidaDAO.ObtenerSubPartidasNombres();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener la lista de SubPartida: " + ex.Message);
                return new List<SubPartida>();
            }
        }

        //
        public List<SubPartida> BuscarSubPartidas(string buscar)
        {
            try
            {
                // Llamada al método del DAO para obtener las SubPartida
                return subPartidaDAO.BuscarSubPartidas(buscar);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener la lista de SubPartida: " + ex.Message);
                return new List<SubPartida>();
            }
        }

        //
        public bool ActualizarSubPartida(SubPartida subPartida)
        {
            try
            {
                // Llamada al método del DAO para actualizar la SubPartida
                return subPartidaDAO.ActualizarSubPartida(subPartida);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al actualizar la SubPartida: " + ex.Message);
                return false;
            }
        }

        //
        public void EliminarSubPartida(int idSubPartida)
        {
            try
            {
                // Llamada al método del DAO para eliminar la SubPartida
                subPartidaDAO.EliminarSubPartida(idSubPartida);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al eliminar la SubPartida: " + ex.Message);
            }
        }

    }
}