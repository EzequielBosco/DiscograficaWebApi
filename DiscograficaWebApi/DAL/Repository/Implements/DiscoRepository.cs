using DiscograficaWebApi.DAL.Data;
using DiscograficaWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscograficaWebApi.DAL.Repository.Implements;

public class DiscoRepository : Repository<Disco>, IDiscoRepository
{
    public DiscoRepository(DataContext context) : base(context)
    {
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
}
