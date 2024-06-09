using DiscograficaWebApi.DAL.Repository;

namespace DiscograficaWebApi.DAL;

public interface IUnitOfWork : IDisposable
{
    IDiscograficaRepository DiscograficaRepository { get; }
    IArtistaRepository ArtistaRepository { get; }
    IDiscoRepository DiscoRepository { get; }
    ICancionRepository CancionRepository { get; }
    IUsuarioRepository UsuarioRepository { get; }
    Task<int> Save();
}
