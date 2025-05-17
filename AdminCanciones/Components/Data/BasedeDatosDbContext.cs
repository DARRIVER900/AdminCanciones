using Microsoft.EntityFrameworkCore;
namespace AdminCanciones.Components.Data
{
    public class BasedeDatosDbContext : DbContext
    {
        public BasedeDatosDbContext(
            DbContextOptions<BasedeDatosDbContext> options
                                    )
            : base(options)
        {

        }
        public DbSet<Cancion> Canciones { get; set; }
        public DbSet<Album> Albumes { get; set; }
        public DbSet<Artista> Artistas { get; set; }
    }
}
