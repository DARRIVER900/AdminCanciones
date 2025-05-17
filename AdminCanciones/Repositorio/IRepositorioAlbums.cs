using AdminCanciones.Components.Data;
using System.Threading.Tasks;
namespace AdminCanciones.Repositorio
{
    public interface IRepositorioAlbums
    {
        Task<List<Album>> GetAll();
        Task<Album?> Get(int id);
        Task Add(Album album);
        Task Update(Album album);
        Task Delete(int id);
    }

}
