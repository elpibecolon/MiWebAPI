//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConectarDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Viajes
    {
        public long id_viaje { get; set; }
        public string codigo_viajes { get; set; }
        public int numero_plazas { get; set; }
        public string destino { get; set; }
        public string lugar_origen { get; set; }
        public decimal precio { get; set; }
        public Nullable<long> cedula_viajero { get; set; }
        public short disponible { get; set; }
    }
}
