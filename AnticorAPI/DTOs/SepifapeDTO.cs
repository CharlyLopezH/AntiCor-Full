using System.ComponentModel.DataAnnotations;

namespace AnticorAPI.DTOs
{
    public class SepifapeDTO
    {

        public int id { get; set; }

        public required string CURP { get; set; }

        [StringLength(maximumLength: 80)]
        public required string Nombres { get; set; }

        [StringLength(maximumLength: 80)]
        public required string PrimerAp { get; set; }

        [StringLength(maximumLength: 80)]
        public string? SegundoAp { get; set; }

        [StringLength(maximumLength: 50)]
        public string? Email { get; set; }

        [StringLength(maximumLength: 50)]
        public string? Folio { get; set; }

        public string? TipoDecla { get; set; }

        public string? Estatus { get; set; }

        public string? EstatusRecep { get; set; }

        public string? Adscripcion { get; set; }

        public string? UnidadRespo { get; set; }

        public string? Encargo { get; set; }

    }
}
