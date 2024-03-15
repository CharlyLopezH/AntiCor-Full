namespace AnticorAPI.Servicios
{
    public class BuscarCurp
    {
        private readonly AppDbContext _dbContext;

        //Constructor
        public BuscarCurp(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CheckCurpExists(string curp)
        {
            // Lógica para verificar si la CURP existe en la tabla Sepifape
            //return _dbContext.Sepifape.Any(s => s.Curp == curp);
            return (false);
        }
    }
}
