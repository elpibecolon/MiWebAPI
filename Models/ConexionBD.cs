using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiWebAPI.Models
{
    public class ConexionBD
    {
        static public string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file.
            //Data Source = MARKETSAPPS - ACA\\SQLEXPRESS; Initial catalog = AgenciaViajes; Integrated Security = true"
            return "Data Source=MARKETSAPPS-ACA\\SQLEXPRESS;Initial Catalog=AgenciaViajes;"
                + "Integrated Security=true;";
        }
    }
}