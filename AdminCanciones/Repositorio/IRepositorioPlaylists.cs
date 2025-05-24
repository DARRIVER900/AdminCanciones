using AdminCanciones.Components.Data;
using System.Threading.Tasks;
namespace AdminCanciones.Repositorio
{
    public interface IRepositorioPlaylists
    {
        Task<List<Playlist>> GetAll();
        Task<Playlist?> Get(int id);
        Task Add(Playlist playlist);
        Task Update(Playlist playlist);
        Task Delete(int id);
    }
}
