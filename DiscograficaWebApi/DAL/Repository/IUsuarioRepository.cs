using DiscograficaWebApi.DAL.Models;

namespace DiscograficaWebApi.DAL.Repository;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<Usuario> GetByUserName(string username);
    Task<List<Usuario>> GetAllByRol(Rol rol);
}
