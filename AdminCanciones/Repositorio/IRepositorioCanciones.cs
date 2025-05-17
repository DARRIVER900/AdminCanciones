using AdminCanciones.Components.Data;
using System.Threading.Tasks;
namespace AdminCanciones.Repositorio
{
    public interface IRepositorioCanciones
    {
        Task<List<Cancion>> GetAll();
        Task<Cancion?> Get(int id);
        Task Add(Cancion cancion);
        Task Update(Cancion cancion);
        Task Delete(int id);
    }
}
