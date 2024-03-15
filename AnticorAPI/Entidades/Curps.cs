using System.ComponentModel.DataAnnotations;

namespace AnticorAPI.Entidades
{
    public class Curps
    {
        public int Id { get; set; }

        public required string CURP { get; set; }
        public required string  Nombre { get; set; }
    }
}
