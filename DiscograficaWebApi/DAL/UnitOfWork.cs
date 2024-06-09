using DiscograficaWebApi.DAL.Data;
using DiscograficaWebApi.DAL.Repository;

namespace DiscograficaWebApi.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    public IDiscograficaRepository DiscograficaRepository { get; }
    public IArtistaRepository ArtistaRepository { get; }
    public IDiscoRepository DiscoRepository { get; }
    public ICancionRepository CancionRepository { get; }
    public IUsuarioRepository UsuarioRepository { get; }

    public UnitOfWork(DataContext context, IDiscograficaRepository discograficaRepository, IArtistaRepository artistaRepository, IDiscoRepository discoRepository, ICancionRepository cancionRepository, IUsuarioRepository usuarioRepository)
    {
        _context = context;
        DiscograficaRepository = discograficaRepository;
        ArtistaRepository = artistaRepository;
        DiscoRepository = discoRepository;
        CancionRepository = cancionRepository;
        UsuarioRepository = usuarioRepository;
    }

    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
