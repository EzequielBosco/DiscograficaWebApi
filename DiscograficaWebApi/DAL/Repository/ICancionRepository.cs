using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Cancion;

namespace DiscograficaWebApi.DAL.Repository;

public interface ICancionRepository : IRepository<Cancion>
{
    Task<Cancion> GetByNombre(string nombre);
    Task<List<Cancion>> GetAllByDuracion(int duracion);
    Task<List<Cancion>> GetAllByGenero(GeneroMusical genero);
    Task<List<Cancion>> GetAllByArtista(Artista artista);
    Task<List<Cancion>> GetAllByDisco(Disco disco);
    Task<List<Cancion>> GetByFilter(CancionFilterRequestDto request);
}
