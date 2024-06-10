using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Disco;

namespace DiscograficaWebApi.DAL.Repository;

public interface IDiscoRepository : IRepository<Disco>
{
    Task<Disco> GetBySKU(string sku);
    Task<Disco> GetByNombre(string nombre);
    Task<List<Disco>> GetAllByGenero(GeneroMusical genero);
    Task<List<Disco>> GetAllByArtista(Artista artista);
    Task<List<Disco>> GetAllByUnidadesVendidas(int unidades);
    Task<Disco> Update(Disco disco);
    Task<List<Disco>> GetTop5MasVendidos();
    Task<List<Disco>> GetByFilter(DiscoFilterRequestDto request);
}
