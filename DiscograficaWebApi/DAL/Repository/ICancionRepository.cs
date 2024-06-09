using DiscograficaWebApi.DAL.Models;

namespace DiscograficaWebApi.DAL.Repository
{
    public interface ICancionRepository : IRepository<Cancion>
    {
        Task<Cancion> GetByNombre(string nombre);
        Task<List<Cancion>> GetAllByDuracion(int duracion);
        Task<List<Cancion>> GetAllByGenero(GeneroMusical genero);
        Task<List<Cancion>> GetAllByArtista(Artista artista);
    }
}
