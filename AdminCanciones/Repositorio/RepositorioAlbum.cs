using AdminCanciones.Components.Data;
using Microsoft.EntityFrameworkCore;
namespace AdminCanciones.Repositorio
{
    public class RepositorioAlbum : IRepositorioAlbums
    {
        private readonly BasedeDatosDbContext _dbContext;

        public RepositorioAlbum(BasedeDatosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Album album)
        {
            await _dbContext.Albumes.AddAsync(album);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _dbContext.Database.ExecuteSqlRawAsync("DELETE FROM Albumes WHERE Id = {0}", id);
        }

        public async Task<Album?> Get(int id)
        {
            return await _dbContext.Albumes.FindAsync(id);
        }

        public async Task<List<Album>> GetAll()
        {
         return await _dbContext.Albumes
        .Include(a => a.Artista)  // Incluir la entidad relacionada
        .AsNoTracking()
        .ToListAsync();
        }

        public async Task Update(Album album)
        {
            _dbContext.Entry(album).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
