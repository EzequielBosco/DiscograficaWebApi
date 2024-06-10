using DiscograficaWebApi.DAL.Data;
using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Cancion;
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

    public async Task<List<Cancion>> GetAllByDisco(Disco disco)
    {
        var result = await _context.Cancions.Where(c => c.Disco == disco).ToListAsync();

        return result;
    }

    public async Task<List<Cancion>> GetByFilter(CancionFilterRequestDto request)
    {
        var query = _context.Cancions.AsQueryable();

        if (!string.IsNullOrEmpty(request.Nombre))
        {
            query = query.Where(c => c.Nombre.Contains(request.Nombre));
        }

        if (request.Duracion != 0)
        {
            query = query.Where(c => c.Duracion == request.Duracion);
        }

        if (request.GeneroMusical.HasValue)
        {
            query = query.Where(c => c.GeneroMusical == request.GeneroMusical.Value);
        }

        if (request.Artista != null && !string.IsNullOrEmpty(request.Artista.NombreArtistico))
        {
            query = query.Where(c => c.Artista.NombreArtistico.Contains(request.Artista.NombreArtistico));
        }

        return await query.ToListAsync();
    }
}
