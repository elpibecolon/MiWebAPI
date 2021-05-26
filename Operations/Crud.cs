using MiWebAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Data.SqlClient;


namespace MiWebAPI.Operations
{
    public class Crud
    {
        public static JObject EliminarViajero(JObject data)
        {
            JObject respuesta = new JObject();
            string connectionStrings = ConexionBD.GetConnectionString();

            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = connectionStrings;
                cn.Open();

                int id = (int)data.GetValue(ConstantesBD.ID_VIAJERO);

                SqlCommand cmdRemoveViajero = new SqlCommand("DELETE FROM dbo.Viajeros WHERE id=@id", cn);

                cmdRemoveViajero.Parameters.AddWithValue("@id", id);

                if (cmdRemoveViajero.ExecuteNonQuery() > 0)
                {
                    respuesta.Add(ConstantesBD.R, "0");
                    respuesta.Add(ConstantesBD.M, "Viajero Eliminado!!!");
                    //respuesta.Add(ConstantesBD.VIAJES_DISPONIBLES, Viajes.ViajesDisponibles().GetValue("viajes"));

                }
                else
                {
                    respuesta.Add(ConstantesBD.R, "1");
                    respuesta.Add(ConstantesBD.M, "Eliminacion fallida!!!");
                }
                cn.Close();
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

        public static JObject ActualizarViajero(JObject data)
        {
            JObject respuesta = new JObject();
            string connectionStrings = ConexionBD.GetConnectionString();

            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = connectionStrings;
                cn.Open();

                int id = (int)data.GetValue(ConstantesBD.ID_VIAJERO);
                String nombre = (string)data.GetValue(ConstantesBD.NOMBRE);
                String apellido = (string)data.GetValue(ConstantesBD.APELLIDO);
                String direccion = (string)data.GetValue(ConstantesBD.DIRECCION);
                String telefono = (string)data.GetValue(ConstantesBD.TELEFONO);
                int cedula_viajero = (int)data.GetValue(ConstantesBD.CEDULA);

                SqlCommand cmdUpdateViajero = new SqlCommand("UPDATE dbo.Viajeros SET nombre = @nombre, apellido = @apellido, direccion = @direccion, telefono = @telefono," +
                    " cedula = @cedula WHERE id = @id", cn);

                cmdUpdateViajero.Parameters.AddWithValue("@id", id);
                cmdUpdateViajero.Parameters.AddWithValue("@nombre", nombre);
                cmdUpdateViajero.Parameters.AddWithValue("@apellido", apellido);
                cmdUpdateViajero.Parameters.AddWithValue("@direccion", direccion);
                cmdUpdateViajero.Parameters.AddWithValue("@telefono", telefono);
                cmdUpdateViajero.Parameters.AddWithValue("@cedula", cedula_viajero);

                //cmdUpdateViajero.ExecuteNonQuery();

                if (cmdUpdateViajero.ExecuteNonQuery() > 0)
                {
                    respuesta.Add(ConstantesBD.R, "0");
                    respuesta.Add(ConstantesBD.M, "Viajero Actualizado!!!");
                }
                else
                {
                    respuesta.Add(ConstantesBD.R, "1");
                    respuesta.Add(ConstantesBD.M, "Actualizacion fallida!!!");
                }
                cn.Close();
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

        public static JObject ListarCedulasViajeros()
        {
            JObject respuesta = new JObject();
            string connectionStrings = ConexionBD.GetConnectionString();

            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = connectionStrings;
                cn.Open();
                SqlCommand cmdCedulas = new SqlCommand("SELECT cedula FROM dbo.Viajeros ORDER BY cedula", cn);

                SqlDataReader dr = cmdCedulas.ExecuteReader();
                JArray cedulas = new JArray();
                JObject cedula;

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cedula = new JObject();

                        cedula.Add(ConstantesBD.CEDULA, dr.GetInt64(0));

                        cedulas.Add(cedula);
                    }

                    respuesta.Add(ConstantesBD.CEDULAS, cedulas);
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

        //SECCION DE VIAJES
        public static JObject EliminarViaje(JObject data)
        {
            JObject respuesta = new JObject();
            string connectionStrings = ConexionBD.GetConnectionString();

            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = connectionStrings;
                cn.Open();

                int id_viaje = (int)data.GetValue(ConstantesBD.ID_VIAJE);

                SqlCommand cmdRemoveViajero = new SqlCommand("DELETE FROM dbo.Viajes WHERE id_viaje = @id_viaje", cn);

                cmdRemoveViajero.Parameters.AddWithValue("@id_viaje", id_viaje);


                

                if (cmdRemoveViajero.ExecuteNonQuery() > 0)
                {
                    respuesta.Add(ConstantesBD.R, "0");
                    respuesta.Add(ConstantesBD.M, "Viaje Eliminado!!!");

                }
                else
                {
                    respuesta.Add(ConstantesBD.R, "1");
                    respuesta.Add(ConstantesBD.M, "Eliminacion fallida!!!");
                }
                cn.Close();
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

        public static JObject ActualizarViaje(JObject data)
        {
            JObject respuesta = new JObject();
            string connectionStrings = ConexionBD.GetConnectionString();

            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = connectionStrings;
                cn.Open();

                Int64 id_viaje = (Int64)data.GetValue(ConstantesBD.ID_VIAJE);
                //String codigo_viajes = (string)data.GetValue(ConstantesBD.CODIGO_VIAJE);
                int numero_plazas = (int)data.GetValue(ConstantesBD.NUMERO_PLAZAS);
                String destino = (string)data.GetValue(ConstantesBD.DESTINO);
                String lugar_origen = (string)data.GetValue(ConstantesBD.LUGAR_ORIGEN);
                decimal precio = (decimal)data.GetValue(ConstantesBD.PRECIO);
                Int64 cedula_viajero = (Int64)data.GetValue(ConstantesBD.CEDULA_VIAJERO);

                SqlCommand cmdUpdateViajes = new SqlCommand("UPDATE dbo.Viajes SET numero_plazas = @numero_plazas," +
                    " destino = @destino, lugar_origen = @lugar_origen, precio = @precio, cedula_viajero = @cedula_viajero WHERE id_viaje = @id_viaje", cn);

                cmdUpdateViajes.Parameters.AddWithValue("@id_viaje", id_viaje);
                //cmdUpdateViajes.Parameters.AddWithValue("@codigo_viajes", codigo_viajes);
                cmdUpdateViajes.Parameters.AddWithValue("@numero_plazas", numero_plazas);
                cmdUpdateViajes.Parameters.AddWithValue("@destino", destino);
                cmdUpdateViajes.Parameters.AddWithValue("@lugar_origen", lugar_origen);
                cmdUpdateViajes.Parameters.AddWithValue("@precio", precio);
                cmdUpdateViajes.Parameters.AddWithValue("@cedula_viajero", cedula_viajero);
                

                //cmdUpdateViajero.ExecuteNonQuery();

                if (cmdUpdateViajes.ExecuteNonQuery() > 0)
                {
                    respuesta.Add(ConstantesBD.R, "0");
                    respuesta.Add(ConstantesBD.M, "Viaje Actualizado!!!");
                }
                else
                {
                    respuesta.Add(ConstantesBD.R, "1");
                    respuesta.Add(ConstantesBD.M, "Actualizacion fallida!!!");
                }
                cn.Close();
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