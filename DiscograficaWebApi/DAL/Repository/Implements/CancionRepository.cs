using DiscograficaWebApi.DAL.Data;
using DiscograficaWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscograficaWebApi.DAL.Repository.Implements;

public class CancionRepository : Repository<Cancion>, ICancionRepository
{
    public CancionRepository(DataContext context) : base(context)
    {
    }

    public async Task<Cancion> GetByNombre(string nombre)
    {
        var result = await _context.Cancions.FirstOrDefaultAsync(c => c.Nombre == nombre);

        return result;
    }

    public async Task<List<Cancion>> GetAllByDuracion(int duracion)
    {
        var result = await _context.Cancions.Where(c => c.Duracion == duracion).ToListAsync();

        return result;
    }

    public async Task<List<Cancion>> GetAllByGenero(GeneroMusical genero)
    {
        var result = await _context.Cancions.Where(c => c.GeneroMusical == genero).ToListAsync();

        return result;
    }

    public async Task<List<Cancion>> GetAllByArtista(Artista artista)
    {
        var result = await _context.Cancions.Where(c => c.Artista == artista).ToListAsync();

        return result;
    }
}
