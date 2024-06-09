using DiscograficaWebApi.DAL.Data;
using DiscograficaWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscograficaWebApi.DAL.Repository.Implements;

public class DiscograficaRepository : Repository<Discografica>, IDiscograficaRepository
{
    public DiscograficaRepository(DataContext context) : base(context)
    {
    }

    public async Task<Discografica> GetByNombre(string nombre)
    {
        var result = await _context.Discograficas.FirstOrDefaultAsync(d => d.Nombre == nombre);

        return result;
    }
}
