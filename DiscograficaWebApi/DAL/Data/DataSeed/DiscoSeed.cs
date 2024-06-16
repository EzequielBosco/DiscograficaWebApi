using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DAL.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DiscograficaWebApi.DAL.Data.DataSeed;

public class DiscoSeed : IEntityTypeConfiguration<Disco>
{
    public void Configure(EntityTypeBuilder<Disco> builder)
    {

        builder.HasData(new Disco
        {
            Id = 1,
            Nombre = "The Dark Side of the Moon",
            GeneroMusical = GeneroMusical.Rock,
            FechaLanzamiento = new System.DateTime(1973, 3, 1),
            UnidadesVendidas = 4500000,
            SKU = "DSM",
            ArtistaId = 1
        },
        new Disco
        {
            Id = 2,
            Nombre = "Thriller",
            GeneroMusical = GeneroMusical.Pop,
            FechaLanzamiento = new System.DateTime(1982, 11, 30),
            UnidadesVendidas = 70000000,
            SKU = "THR",
            ArtistaId = 2
        },
        new Disco
        {
            Id = 3,
            Nombre = "Back in Black",
            GeneroMusical = GeneroMusical.Rock,
            FechaLanzamiento = new System.DateTime(1980, 7, 25),
            UnidadesVendidas = 50000000,
            SKU = "BIA",
            ArtistaId = 3
        });
    }
}
