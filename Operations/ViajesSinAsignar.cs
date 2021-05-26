using System;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using MiWebAPI.Models;

namespace MiWebAPI.Operations
{
    public class ViajesSinAsignar
    {
        public static JObject ViajesDisponibles()
        {
            JObject respuesta = new JObject();
            string connectionStrings = ConexionBD.GetConnectionString();

            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = connectionStrings;
                cn.Open();
                SqlCommand cmdViajesDisponibles = new SqlCommand("SELECT id_viaje, codigo_viajes, numero_plazas, destino, lugar_origen, precio" +
                    " FROM dbo.Viajes WHERE cedula_viajero IS NULL", cn);

                SqlDataReader dr = cmdViajesDisponibles.ExecuteReader();
                JArray viajes = new JArray();
                JObject viaje;

                if (dr.HasRows)
                {
                    int count = 1;
                    while (dr.Read())
                    {
                        viaje = new JObject();
                        viaje.Add(ConstantesBD.REF, count++);
                        viaje.Add(ConstantesBD.ID_VIAJE, dr.GetInt64(0));
                        viaje.Add(ConstantesBD.CODIGO_VIAJE, dr.GetString(1));
                        viaje.Add(ConstantesBD.NUMERO_PLAZAS, dr.GetInt32(2));
                        viaje.Add(ConstantesBD.DESTINO, dr.GetString(3));
                        viaje.Add(ConstantesBD.LUGAR_ORIGEN, dr.GetString(4));
                        viaje.Add(ConstantesBD.PRECIO, dr.GetDecimal(5));
                        //viaje.Add(ConstantesBD.CEDULA_VIAJERO, dr.GetInt16(6));

                        viajes.Add(viaje);
                    }

                    respuesta.Add(ConstantesBD.VIAJES, viajes);
                    respuesta.Add(ConstantesBD.R, "0");

                    return respuesta;
                } 
                else
                {
                    respuesta.Add(ConstantesBD.R, "1");
                    respuesta.Add(ConstantesBD.M, "No posee registros");
                }
                dr.Close();
                return respuesta;

            }
            catch (Exception ex)
            {
                respuesta.Add(ConstantesBD.R, "3");
                respuesta.Add(ConstantesBD.M, "Error inesperado");
                respuesta.Add("Error Generated. Details: ", ex.Message.ToString());
            }

            return respuesta;

        }

        public static JObject ViajesNoDisponibles()
        {
            JObject respuesta = new JObject();
            string connectionStrings = ConexionBD.GetConnectionString();

            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = connectionStrings;
                cn.Open();
                SqlCommand cmdViajesDisponibles = new SqlCommand("SELECT id_viaje, codigo_viajes, numero_plazas, destino, lugar_origen, precio, cedula_viajero" +
                    " FROM dbo.Viajes WHERE cedula_viajero IS NOT NULL", cn);

                SqlDataReader dr = cmdViajesDisponibles.ExecuteReader();
                JArray viajes = new JArray();
                JObject viaje;

                if (dr.HasRows)
                {
                    int count = 1;
                    while (dr.Read())
                    {
                        viaje = new JObject();
                        viaje.Add(ConstantesBD.REF, count++);
                        viaje.Add(ConstantesBD.ID_VIAJE, dr.GetInt64(0));
                        viaje.Add(ConstantesBD.CODIGO_VIAJE, dr.GetString(1));
                        viaje.Add(ConstantesBD.NUMERO_PLAZAS, dr.GetInt32(2));
                        viaje.Add(ConstantesBD.DESTINO, dr.GetString(3));
                        viaje.Add(ConstantesBD.LUGAR_ORIGEN, dr.GetString(4));
                        viaje.Add(ConstantesBD.PRECIO, dr.GetDecimal(5));
                        viaje.Add(ConstantesBD.CEDULA_VIAJERO, dr.GetInt64(6));

                        viajes.Add(viaje);
                    }

                    respuesta.Add(ConstantesBD.VIAJES, viajes);
                    respuesta.Add(ConstantesBD.R, "0");

                    return respuesta;
                }
                else
                {
                    respuesta.Add(ConstantesBD.R, "1");
                    respuesta.Add(ConstantesBD.M, "No posee registros");
                }
                dr.Close();
                return respuesta;

            }
            catch (Exception ex)
            {
                respuesta.Add(ConstantesBD.R, "3");
                respuesta.Add(ConstantesBD.M, "Error inesperado");
                respuesta.Add("Error Generated. Details: ", ex.Message.ToString());
            }

            return respuesta;

        }
    }
}