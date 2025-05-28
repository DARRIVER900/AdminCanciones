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
            // Si hay canciones, asegúrate de que sean entidades existentes
            if (playlist.Canciones != null && playlist.Canciones.Any())
            {
                var cancionesIds = playlist.Canciones.Select(c => c.Id).ToList();
                var cancionesExistentes = await _dbContext.Canciones
                    .Where(c => cancionesIds.Contains(c.Id))
                    .ToListAsync();

                playlist.Canciones = cancionesExistentes;
            }

            await _dbContext.Playlists.AddAsync(playlist);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var playlist = await _dbContext.Playlists
                .Include(p => p.Canciones)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (playlist != null)
            {
                playlist.Canciones?.Clear(); // Limpia la relación muchos-a-muchos
                _dbContext.Playlists.Remove(playlist);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<Playlist?> Get(int id)
        {
            return await _dbContext.Playlists.Include(c => c.Canciones).FirstAsync(r => r.Id == id);
        }
        public async Task<List<Playlist>> GetAll()
        {
            return await _dbContext.Playlists
                    .Include(p => p.Canciones)
        .AsNoTracking()
        .ToListAsync();

        }
        public async Task Update(Playlist playlist)
        {
            var playlistExistente = await _dbContext.Playlists
                            .Include(p => p.Canciones)
                            .FirstOrDefaultAsync(p => p.Id == playlist.Id);

            if (playlistExistente != null)
            {
                // Actualiza propiedades simples
                playlistExistente.Nombre = playlist.Nombre;
                playlistExistente.Descripcion = playlist.Descripcion;

                // Actualiza la relación de canciones
                playlistExistente.Canciones?.Clear();
                if (playlist.Canciones != null && playlist.Canciones.Any())
                {
                    var cancionesIds = playlist.Canciones.Select(c => c.Id).ToList();
                    var cancionesExistentes = await _dbContext.Canciones
                        .Where(c => cancionesIds.Contains(c.Id))
                        .ToListAsync();

                    foreach (var cancion in cancionesExistentes)
                    {
                        playlistExistente.Canciones?.Add(cancion);
                    }
                }

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
