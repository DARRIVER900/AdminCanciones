using AdminCanciones.Components.Data;
using Microsoft.EntityFrameworkCore;
namespace AdminCanciones.Repositorio
{
    public class RepositorioArtista : IRepositorioArtistas
    {
        private readonly BasedeDatosDbContext _dbContext;

        public RepositorioArtista(BasedeDatosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Artista artista)
        {
            await _dbContext.Artistas.AddAsync(artista);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _dbContext.Database.ExecuteSqlRawAsync("DELETE FROM Artistas WHERE Id = {0}", id);
        }

        public async Task<Artista?> Get(int id)
        {
            return await _dbContext.Artistas.FindAsync(id);
        }

        public async Task<List<Artista>> GetAll()
        {
            return await _dbContext.Artistas.AsNoTracking().ToListAsync();
        }

        public async Task Update(Artista artista)
        {
            _dbContext.Entry(artista).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
