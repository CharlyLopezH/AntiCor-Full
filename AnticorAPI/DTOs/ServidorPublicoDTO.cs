using System.ComponentModel.DataAnnotations;

namespace AnticorAPI.DTOs
{
    public class ServidorPublicoDTO
    {
        public int Id { get; set; }
        public required string CURP { get; set; }

        [StringLength(maximumLength: 50)]
        public required string Nombres { get; set; }

        [StringLength(maximumLength: 50)]
        public required string PrimerAp { get; set; }

        [StringLength(maximumLength: 50)]
        public required string SegundoAP { get; set; }

        public string? Cargo { get; set; }

        public string? OrganismoPublico { get; set; }

        public string? ObjetoResp { get; set; }

        public string? NivelRiesgo { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }
    }
}
