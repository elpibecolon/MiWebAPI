using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiWebAPI.Operations
{
    public class ConstantesBD
    {
        //Respuestas
        public static string R = "R";
        public static string M = "M";

        //Auth
        public static string USUARIO = "usuario";
        public static string PASSWORD = "password";

        //Viajes
        public static string REF = "$id_viaje";
        public static string ID_VIAJE = "id_viaje";
        public static string CODIGO_VIAJE = "codigo_viajes";
        public static string NUMERO_PLAZAS = "numero_plazas";
        public static string LUGAR_ORIGEN = "lugar_origen";
        public static string DESTINO = "destino";
        public static string PRECIO = "precio";
        public static string CEDULA_VIAJERO = "cedula_viajero";
        public static string DISPONIBLE = "disponible";
        public static string VIAJES = "viajes";
        public static string VIAJES_DISPONIBLES = "ViajesDisponibles";

        //Viajeros
        public static string ID_VIAJERO = "id";
        public static string NOMBRE = "nombre";
        public static string APELLIDO = "apellido";
        public static string DIRECCION = "direccion";
        public static string TELEFONO = "telefono";
        public static string CEDULA = "cedula";
        public static string CEDULAS = "cedulas";
    }
}