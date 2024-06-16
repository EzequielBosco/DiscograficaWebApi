using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DAL.Models.Enums;

namespace DiscograficaWebApi.DAL.Repository;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<Usuario> GetByUserName(string username);
    Task<List<Usuario>> GetAllByRol(Rol rol);
}
