using MySql.Data.MySqlClient;
using sistema_modular_cafe_majada.model.Connection;
using sistema_modular_cafe_majada.model.Mapping.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_modular_cafe_majada.model.DAO
{
    class ReportesDAO
    {
        private ConnectionDB conexion;

        public ReportesDAO()
        {
            //Se crea la instancia de la clase conexion
            conexion = new ConnectionDB();
        }
        public List<ReportesCCaliadades> GetCCalidadData(int cosecha)
        {
            List<ReportesCCaliadades> data = new List<ReportesCCaliadades>();

            try
            {
                conexion.Conectar();
                string consulta = @"
                                    SELECT
                                        cc.nombre_calidad AS calidad_cafe,
                                        spro.nombre_subproducto AS subproducto,
                                        CONCAT(bc.nombre_bodega, ' - ', a.nombre_almacen) AS almacenado_en,
                                        SUM(sp.peso_saco_subpartida) AS sacos,
                                        SUM(sp.peso_qqs_subpartida) AS qqspunto
                                    FROM
                                        SubPartida sp
                                    JOIN Calidad_Cafe cc ON sp.id_calidad_cafe_subpartida = cc.id_calidad
                                    JOIN SubProducto spro ON sp.id_subproducto_subpartida = spro.id_subproducto
                                    JOIN Almacen a ON sp.id_almacen_subpartida = a.id_almacen
                                    JOIN Bodega_Cafe bc ON a.id_bodega_ubicacion_almacen = bc.id_bodega
                                    WHERE
	                                    sp.id_cosecha_subpartida = @id_cosecha
                                    GROUP BY
                                        cc.nombre_calidad,
                                        spro.nombre_subproducto,
                                        almacenado_en;
            ";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@id_cosecha", cosecha);
                MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta);

                while (reader.Read())
                {
                    ReportesCCaliadades reportesCCalidades = new ReportesCCaliadades()
                    {
                        nombre_calidad = reader["calidad_cafe"].ToString(),
                        nombre_subproducto = reader["subproducto"].ToString(),
                        almacenado_en = reader["almacenado_en"].ToString(),
                        total_sacos = Convert.ToDouble(reader["sacos"]),
                        total_qqspunto = Convert.ToDouble(reader["qqspunto"]),
                    };
                    data.Add(reportesCCalidades);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener datos del reporte de calidades de cafe: " + ex.Message);
            }
            finally
            {
                conexion.Desconectar();
            }

            return data;
        }
        public List<ReportesSubpartida> GetSubpartidaData(int cosecha, string fechaini, string fechafin)
        {
            List<ReportesSubpartida> data = new List<ReportesSubpartida>();

            try
            {
                conexion.Conectar();
                string consulta = @"
                                    SELECT
                                        sp.num_subpartida AS subpartida,
                                        sp.num1_semana_subpartida AS semana,
                                        dias1_subpartida AS partida,
                                        sp.fecha1_subpartida AS fecha,
                                        cc.nombre_calidad AS calidad_cafe,
                                        pd.nombre_procedencia AS procedencia,
                                        CONCAT(bodega.nombre_bodega, ' - ', al.nombre_almacen) AS almacenado_en,
                                        sp.peso_saco_subpartida AS sacos,
                                        sp.peso_qqs_subpartida AS qqs_punto,
                                        DATE_FORMAT(sp.inicio_secado_subpartida, '%d/%m/%Y') AS inicio_secado,
                                        DATE_FORMAT(sp.salida_punto_secado_subpartida, '%d/%m/%Y') AS fin_secado,
                                        ROUND(HOUR(sp.tiempo_secado_subpartida) + MINUTE(sp.tiempo_secado_subpartida) / 60, 1) AS tiempo,
                                        ROUND((sp.peso_qqs_subpartida / sp.rendimiento_subpartida), 2) AS qqs_oro,
                                        sp.humedad_secado_subpartida AS humedad,
                                        sp.rendimiento_subpartida AS rendimiento,
                                        per.nombre_personal AS puntero,
                                        DATE_FORMAT(sp.fecha_catacion_subpartida, '%d/%m/%Y') AS fecha_catacion,
                                        sp.observacion_catacion_subpartida AS catacion,
                                        sp.docto_almacen_subpartida AS almacen,
                                        DATE_FORMAT(sp.fecha_carga_secado_subpartida, '%d/%m/%Y') AS fecha_secado
                                    FROM
                                        SubPartida sp
                                    LEFT JOIN Calidad_Cafe cc ON sp.id_calidad_cafe_subpartida = cc.id_calidad
                                    LEFT JOIN Procedencia_Destino_Cafe pd ON sp.id_procedencia_subpartida = pd.id_procedencia
                                    LEFT JOIN Almacen al ON sp.id_almacen_subpartida = al.id_almacen
                                    LEFT JOIN Bodega_Cafe bodega ON sp.id_bodega_subpartida = bodega.id_bodega
                                    LEFT JOIN Personal per ON sp.id_puntero_secado_subpartida = per.id_personal
                                    WHERE
                                        sp.id_cosecha_subpartida = @id_cosecha AND 
                                        IF(
                                          fecha1_subpartida LIKE '%al%',
                                          STR_TO_DATE(CONCAT(SUBSTRING_INDEX(fecha1_subpartida, ' al ', 1), '/', SUBSTRING(fecha1_subpartida, LOCATE('al ', fecha1_subpartida) + 7)), '%d/%m/%Y'),
                                          STR_TO_DATE(fecha1_subpartida, '%d/%m/%Y')
                                        ) BETWEEN STR_TO_DATE(@fecha_inicial, '%d/%m/%Y') AND STR_TO_DATE(@fecha_final, '%d/%m/%Y');
            ";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@id_cosecha", cosecha);
                conexion.AgregarParametro("@fecha_inicial", fechaini);
                conexion.AgregarParametro("@fecha_final", fechafin);
                //
                MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta);

                while (reader.Read())
                {
                    ReportesSubpartida reportesSubpartida = new ReportesSubpartida()
                    {
                        Subpartida = Convert.ToInt32(reader["subpartida"]),
                        Semana = Convert.ToInt32(reader["semana"]),
                        Partida = reader["partida"].ToString(),
                        Fecha = reader["fecha"].ToString(),
                        CalidadCafe = reader["calidad_cafe"].ToString(),
                        Procedencia = reader["procedencia"].ToString(),
                        AlmacenadoEn = reader["almacenado_en"].ToString(),
                        Sacos = Convert.ToDouble(reader["sacos"]),
                        QqsPunto = Convert.ToDouble(reader["qqs_punto"]),
                        InicioSecado = reader["inicio_secado"].ToString(),
                        FinSecado = reader["fin_secado"].ToString(),
                        Tiempo = reader["tiempo"].ToString(),
                        QqsOro = Convert.ToDouble(reader["qqs_oro"]),
                        Humedad = Convert.ToDouble(reader["humedad"]),
                        Rendimiento = Convert.ToDouble(reader["rendimiento"]),
                        Puntero = reader["puntero"].ToString(),
                        FechaCatacion = reader["fecha_catacion"].ToString(),
                        Catacion = reader["catacion"].ToString(),
                        Almacen = reader["almacen"].ToString(),
                        FechaSecado = reader["fecha_secado"].ToString()
                    };

                    data.Add(reportesSubpartida);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener datos del reporte de subpartida: " + ex.Message);
            }
            finally
            {
                conexion.Desconectar();
            }

            return data;
        }
        public List<ReportesBodegas> GetBodegaData(int cosecha)
        {
            List<ReportesBodegas> data = new List<ReportesBodegas>();

            try
            {
                conexion.Conectar();
                string consulta = @"
                SELECT
                    TRIM(bc.nombre_bodega) AS nombre_bodega,
                    cc.nombre_calidad AS calidad_cafe,
                    SUM(sp.peso_saco_subpartida) AS total_sacos,
                    SUM(sp.peso_qqs_subpartida) AS total_qqspunto
                FROM
                    Bodega_Cafe bc
                JOIN SubPartida sp ON bc.id_bodega = sp.id_bodega_subpartida
                JOIN Calidad_Cafe cc ON sp.id_calidad_cafe_subpartida = cc.id_calidad
                WHERE
                    sp.id_cosecha_subpartida = @id_cosecha
                GROUP BY
                    TRIM(bc.nombre_bodega),
                    cc.nombre_calidad
                ORDER BY
                    TRIM(bc.nombre_bodega);

            ";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@id_cosecha", cosecha);
                MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta);

                while (reader.Read())
                {
                    ReportesBodegas reportesBodegas = new ReportesBodegas()
                    {

                        nombre_bodega = reader["nombre_bodega"].ToString(),
                        calidad_cafe = reader["calidad_cafe"].ToString(),
                        total_sacos = Convert.ToDouble(reader["total_sacos"]),
                        total_qqspunto = Convert.ToDouble(reader["total_qqspunto"]),
                    };
                    data.Add(reportesBodegas);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener datos del reporte de subpartida: " + ex.Message);
            }
            finally
            {
                conexion.Desconectar();
            }

            return data;
        }
        public List<ReportesCafeBodegas> GetCafeBodegaData(int cosecha)
        {
            List<ReportesCafeBodegas> data = new List<ReportesCafeBodegas>();

            try
            {
                conexion.Conectar();
                string consulta = @"
                SELECT
                    bc.nombre_bodega,
                    a.nombre_almacen,
                    cc.id_calidad,
                    cc.nombre_calidad AS calidad_cafe,
                    spro.nombre_subproducto AS subproducto,
                    sp.peso_saco_subpartida AS sacos,
                    sp.peso_qqs_subpartida AS qqspunto
                FROM
                    SubPartida sp
                JOIN Calidad_Cafe cc ON sp.id_calidad_cafe_subpartida = cc.id_calidad
                JOIN SubProducto spro ON sp.id_subproducto_subpartida = spro.id_subproducto
                JOIN Almacen a ON sp.id_almacen_subpartida = a.id_almacen
                JOIN Bodega_Cafe bc ON a.id_bodega_ubicacion_almacen = bc.id_bodega
                WHERE sp.id_cosecha_subpartida = @id_cosecha ;
            ";

                conexion.CrearComando(consulta);
                conexion.AgregarParametro("@id_cosecha", cosecha);

                MySqlDataReader reader = conexion.EjecutarConsultaReader(consulta);

                while (reader.Read())
                {
                    ReportesCafeBodegas reportesCafeBodegas = new ReportesCafeBodegas()
                    {
                        
                        nombre_bodega = reader["nombre_bodega"].ToString(),
                        nombre_almacen = reader["nombre_almacen"].ToString(),
                        id_calidad = Convert.ToInt32(reader["id_calidad"]),
                        nombre_calidad = reader["calidad_cafe"].ToString(),
                        nombre_subproducto = reader["subproducto"].ToString(),
                        total_sacos = Convert.ToDouble(reader["sacos"]),
                        total_qqspunto = Convert.ToDouble(reader["qqspunto"]),
                    };
                    data.Add(reportesCafeBodegas);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener datos del reporte de cafe bodegas: " + ex.Message);
            }
            finally
            {
                conexion.Desconectar();
            }

            return data;
        }

    }
}
