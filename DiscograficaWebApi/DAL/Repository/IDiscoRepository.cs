using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DAL.Models.Enums;
using DiscograficaWebApi.DTOs.Disco;

namespace DiscograficaWebApi.DAL.Repository;

public interface IDiscoRepository : IRepository<Disco>
{
    Task<List<Disco>> GetAllWithCanciones();
    Task<Disco> GetBySKU(string sku);
    Task<Disco> GetByNombre(string nombre);
    Task<List<Disco>> GetAllByGenero(GeneroMusical genero);
    Task<List<Disco>> GetAllByArtista(Artista artista);
    Task<List<Disco>> GetAllByUnidadesVendidas(int unidades);
    Task<List<Disco>> GetTop5MasVendidos();
    Task<List<Disco>> GetByFilter(DiscoFilterRequestDto request);
}
