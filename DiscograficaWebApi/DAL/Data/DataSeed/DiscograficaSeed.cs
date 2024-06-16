using DiscograficaWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscograficaWebApi.DAL.Data.DataSeed;

public class DiscograficaSeed : IEntityTypeConfiguration<Discografica>
{
    public void Configure(EntityTypeBuilder<Discografica> builder)
    {
        builder.HasData(new Discografica
        {
            Id = 1,
            Nombre = "Sony Music",
            Direccion = "Av. Corrientes 1234",
            Telefono = "123456789",
            Email = "info@sonymusic.com",
            FechaFundacion = new System.DateTime(1929, 1, 1),
            WebSite = "www.sonymusic.com"
        }, new Discografica
        {
            Id = 2,
            Nombre = "Universal Music",
            Direccion = "Av. Rivadavia 1234",
            Telefono = "987654321",
            Email = "info@universal.com",
            FechaFundacion = new System.DateTime(1934, 1, 1),
            WebSite = "www.universalmusic.com"
        },
        new Discografica
        {
            Id = 3,
            Nombre = "Warner Music",
            Direccion = "Av. Santa Fe 1234",
            Telefono = "456789123",
            Email = "info@warner.com",
            FechaFundacion = new System.DateTime(1958, 1, 1),
            WebSite = "www.warnermusic.com"
        });
    }
}
