using AdminCanciones.Components.Data;
using Microsoft.EntityFrameworkCore;
namespace AdminCanciones.Repositorio
{
    public class RepositorioCancion : IRepositorioCanciones
    {
        private readonly BasedeDatosDbContext _dbContext;

        public RepositorioCancion(BasedeDatosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Cancion cancion)
        {
            await _dbContext.Canciones.AddAsync(cancion);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _dbContext.Database.ExecuteSqlRawAsync("DELETE FROM Canciones WHERE Id = {0}", id);
        }

        public async Task<Cancion?> Get(int id)
        {
            return await _dbContext.Canciones.FindAsync(id);
        }

        public async Task<List<Cancion>> GetAll()
        {
            return await _dbContext.Canciones
                .Include(c => c.Album)
                    .ThenInclude(a => a.Artista)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Update(Cancion cancion)
        {
            _dbContext.Entry(cancion).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
