using System;

namespace RestauranteAPI.DTOs
{
    public class OrdenDTO
    {
        public int IdOrden { get; set; }
        public int? IdMesa { get; set; }
        public string ClienteOrden { get; set; }
        public DateTime FechaOrden { get; set; }
        public string TipoOrden { get; set; }
        public string Estado { get; set; }
        public string ComentarioOrden { get; set; }
    }
}
