using Newtonsoft.Json.Linq;
using System;
using System.Data.SqlClient;
using MiWebAPI.Models;

namespace MiWebAPI.Operations
{
    public class Auth
    {

        public static JObject Autenticacion(JObject data)
        {
            JObject respuesta = new JObject();
            string connectionStrings = ConexionBD.GetConnectionString();

            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = connectionStrings;
                    cn.Open();

                    string usuario = (string)data.GetValue(ConstantesBD.USUARIO);
                    string pass = (string)data.GetValue(ConstantesBD.PASSWORD);

                    SqlCommand cmdAuth = new SqlCommand("SELECT * FROM dbo.Usuarios WHERE usuario = @usuario AND password = @pass", cn);

                    cmdAuth.Parameters.AddWithValue("@usuario", usuario);
                    cmdAuth.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader dr = cmdAuth.ExecuteReader();

                    if (dr.Read())
                    {
                        respuesta.Add(ConstantesBD.R, "0");
                        respuesta.Add(ConstantesBD.M, "Exitoso!!!");
                        //respuesta.Add(ConstantesBD.VIAJES_DISPONIBLES, Viajes.ViajesDisponibles().GetValue("viajes"));

                    }
                    else
                    {
                        respuesta.Add(ConstantesBD.R, "1");
                        respuesta.Add(ConstantesBD.M, "Login fallido!!!");
                    }
                    cn.Close();
                    return respuesta;
                }
            } 
            catch (Exception ex)
            {
                respuesta.Add(ConstantesBD.R, "3");
                respuesta.Add(ConstantesBD.M, "Error inesperado!");
                Console.WriteLine("Error Generated. Details: " + ex.Message.ToString());
            } 

            return respuesta;
        
        }

    }
}