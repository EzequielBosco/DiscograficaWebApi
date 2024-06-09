using DiscograficaWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscograficaWebApi.DAL.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Disco> Discos { get; set; }
    public DbSet<Cancion> Cancions { get; set; }
    public DbSet<Discografica> Discograficas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}