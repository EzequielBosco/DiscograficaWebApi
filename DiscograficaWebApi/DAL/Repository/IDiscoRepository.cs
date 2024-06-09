using DiscograficaWebApi.DAL.Models;

namespace DiscograficaWebApi.DAL.Repository;

public interface IDiscoRepository : IRepository<Disco>
{
    Task<Disco> GetBySKU(string sku);
    Task<Disco> GetByNombre(string nombre);
    Task<List<Disco>> GetAllByGenero(GeneroMusical genero);
    Task<List<Disco>> GetAllByArtista(Artista artista);
    Task<List<Disco>> GetAllByUnidadesVendidas(int unidades);
}
