using DiscograficaWebApi.DAL.Data.DataSeed;
using DiscograficaWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using WebApI_Preparcial_II.Dal.Data.DataSeed;

namespace DiscograficaWebApi.DAL.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DiscograficaSeed());
        modelBuilder.ApplyConfiguration(new ArtistaSeed());
        modelBuilder.ApplyConfiguration(new DiscoSeed());
        modelBuilder.ApplyConfiguration(new CancionSeed());
        modelBuilder.ApplyConfiguration(new UsuarioSeed());
    }

    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Disco> Discos { get; set; }
    public DbSet<Cancion> Cancions { get; set; }
    public DbSet<Discografica> Discograficas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}