using AdminCanciones.Components.Data;
using Microsoft.EntityFrameworkCore;
namespace AdminCanciones.Repositorio
{
    public class RepositorioPlaylist : IRepositorioPlaylists
    {
        private readonly BasedeDatosDbContext _dbContext;
        public RepositorioPlaylist(BasedeDatosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Playlist playlist)
        {
            await _dbContext.Playlists.AddAsync(playlist);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            await _dbContext.Database.ExecuteSqlRawAsync("DELETE FROM Playlists WHERE Id = {0}", id);
        }
        public async Task<Playlist?> Get(int id)
        {
            return await _dbContext.Playlists.FindAsync(id);
        }
        public async Task<List<Playlist>> GetAll()
        {
            return await _dbContext.Playlists.AsNoTracking().ToListAsync();
        }
        public async Task Update(Playlist playlist)
        {
            _dbContext.Entry(playlist).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
