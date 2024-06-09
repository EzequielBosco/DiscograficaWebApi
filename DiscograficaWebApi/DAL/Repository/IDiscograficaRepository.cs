using DiscograficaWebApi.DAL.Models;

namespace DiscograficaWebApi.DAL.Repository;

public interface IDiscograficaRepository : IRepository<Discografica>
{
    Task<Discografica> GetByNombre(string nombre);
}
