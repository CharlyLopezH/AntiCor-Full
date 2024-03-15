namespace AnticorAPI.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        private int recordsPorPagina = 10000;
        private readonly int cantidadMaximaRecordsPorPagina = 10000;

        public int RecordsPorPagina
        {
            get
            {
                return recordsPorPagina;
            }
            set
            {
                recordsPorPagina = (value > cantidadMaximaRecordsPorPagina) ? cantidadMaximaRecordsPorPagina : value;
            }
        }
    }
}
