using DiscograficaWebApi.DAL.Data;
using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Disco;
using Microsoft.EntityFrameworkCore;

namespace DiscograficaWebApi.DAL.Repository.Implements;

public class DiscoRepository : Repository<Disco>, IDiscoRepository
{
    public DiscoRepository(DataContext context) : base(context)
    {
    }

    public async Task<List<Disco>> GetAllWithCanciones()
    {
        var result = await _context.Discos.Include(d => d.Artista).Include(d => d.Cancions).ToListAsync();

        return result;
    }

    public async Task<Disco> GetByNombre(string nombre)
    {
        var result = await _context.Discos.FirstOrDefaultAsync(d => d.Nombre == nombre);

        return result;
    }

    public async Task<Disco> GetBySKU(string sku)
    {
        var result = await _context.Discos.FirstOrDefaultAsync(d => d.SKU == sku);

        return result;
    }

    public async Task<List<Disco>> GetAllByGenero(GeneroMusical genero)
    {
        var result = await _context.Discos.Where(d => d.GeneroMusical == genero).ToListAsync();

        return result;
    }

    public async Task<List<Disco>> GetAllByArtista(Artista artista)
    {
        var result = await _context.Discos.Where(d => d.Artista == artista).ToListAsync();

        return result;
    }

    public async Task<List<Disco>> GetAllByUnidadesVendidas(int unidades)
    {
        var result = await _context.Discos.Where(d => d.UnidadesVendidas == unidades).ToListAsync();

        return result;
    }

    public async Task<List<Disco>> GetTop5MasVendidos()
    {
        var result = await _context.Discos.OrderByDescending(d => d.UnidadesVendidas)
            .Take(5)
            .Include(d => d.Artista)
            .Include(d => d.Cancions)
            .ToListAsync();

        return result;
    }

    public async Task<List<Disco>> GetByFilter(DiscoFilterRequestDto request)
    {
        var query = _context.Discos.Include(d => d.Artista).Include(d => d.Cancions).AsQueryable();

        if (request.GeneroMusical.HasValue)
        {
            query = query.Where(d => d.GeneroMusical == request.GeneroMusical.Value);
        }

        if (!string.IsNullOrEmpty(request.Nombre))
        {
            query = query.Where(d => d.Nombre.Contains(request.Nombre));
        }

        if (request.UnidadesVendidas.HasValue)
        {
            query = query.Where(d => d.UnidadesVendidas >= request.UnidadesVendidas.Value);
        }

        if (request.Artista != null)
        {
            if (!string.IsNullOrEmpty(request.Artista))
            {
                query = query.Where(d => d.Artista.NombreArtistico.Contains(request.Artista));
            }
        }

        return await query.ToListAsync();
    }
}
