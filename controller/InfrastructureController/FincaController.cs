﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sistema_modular_cafe_majada.model.DAO;
using sistema_modular_cafe_majada.model.Mapping;

namespace sistema_modular_cafe_majada.controller
{
    class FincaController
    {
        private FincaDAO FincaDao;

        public FincaController()
        {
            //se inicia la instancia de la clase FincaDAO
            FincaDao = new FincaDAO();
        }

        //funcion que se enlaza con FincaDao para insertar un registro en la base de datos
        public bool InsertarFinca(Finca finca)
        {
            try
            {
                //se realiza el llamado al metodo DAO para insertar
                return FincaDao.InsertarFinca(finca);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ocurrio un error durante la inserción del registro en la base de datos: "+ex.Message);
                return false;
            }
        }

        public List<Finca> ObtenerFincas()
        {
            try
            {
                //se realiza el llamado al metodo DAO para obtener fincas
                return FincaDao.ObtenerFincas();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ocurrio un error al obtener la lista de Fincas: " + ex.Message);
                return new List<Finca>();
            }
        }

        public bool ActualizarFincas(int id,string nomFinca,string ubiFinca)
        {
            try
            {
                //se realiza el llamado al metodo DAO para modificar
                return FincaDao.ActualizarFinca(id, nomFinca, ubiFinca);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ocurrio un error al actualizar los datos: " + ex.Message);
                return false;
            }
        }

        public void EliminarFinca(int id)
        {
            try
            {
                //se realiza el llamado al metodo DAO para eliminar
                FincaDao.EliminarFinca(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ocurrio un error al eliminar una finca" + ex.Message);
            }
        }
    }
}