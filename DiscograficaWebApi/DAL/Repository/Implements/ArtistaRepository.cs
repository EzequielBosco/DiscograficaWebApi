using Microsoft.EntityFrameworkCore;
using DiscograficaWebApi.DAL.Data;
using DiscograficaWebApi.DAL.Models;

namespace DiscograficaWebApi.DAL.Repository.Implements;

public class ArtistaRepository : Repository<Artista>, IArtistaRepository
{
    public ArtistaRepository(DataContext context) : base(context)
    {
    }

    public async Task<Artista> GetByNombreArtistico(string nombre)
    {
        var result = await _context.Artistas.FirstOrDefaultAsync(a => a.NombreArtistico == nombre);

        return result;
    }

    public async Task<Artista> GetById(long id)
    {
        var result = await _context.Artistas.FirstOrDefaultAsync(a => a.Id == id);

        return result;
    }
}
