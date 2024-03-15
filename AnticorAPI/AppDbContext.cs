using AnticorAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AnticorAPI
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {        

        
        //Configuración del DbSet
        public DbSet<Ruspej> Ruspej_DT { get; set; }
        public DbSet<Sepifape> Sepifape_DT{ get; set; }
    }
}
