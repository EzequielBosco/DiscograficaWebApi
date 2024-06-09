using DiscograficaWebApi.DAL.Models;

namespace DiscograficaWebApi.DAL.Repository;

public interface IArtistaRepository : IRepository<Artista>
{
    Task<Artista> GetByNombreArtistico(string nombre);
}
