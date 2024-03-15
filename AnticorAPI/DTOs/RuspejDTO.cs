using System.ComponentModel.DataAnnotations;

namespace AnticorAPI.DTOs
{
    public class RuspejDTO
    {
        public int Id { get; set; }
        public required string CURP { get; set; }

        [StringLength(maximumLength: 150)]
        public required string Nombres { get; set; }

        public string? Cargo { get; set; }

        public string? Adscripcion { get; set; }

        public string? ObjetoRespo { get; set; }

        public string? NivelRiesgo { get; set; }

        public string? DomicilioLaboral { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public string? Icono { get; set; }


    }
}
