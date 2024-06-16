using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DAL.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscograficaWebApi.DAL.Data.DataSeed;

public class ArtistaSeed : IEntityTypeConfiguration<Artista>
{
    public void Configure(EntityTypeBuilder<Artista> builder)
    {
        builder.HasData(new Artista
        {
            Id = 1,
            Nombre = "Pink Floyd",
            NombreArtistico = "Pink Floyd",
            FechaNacimiento = new System.DateTime(1965, 1, 1),
            Nacionalidad = Nacionalidad.Britanica,
            GeneroMusical = GeneroMusical.Rock,
            Email = "pinkfloyd@gmail.com",
        },
        new Artista
        {
            Id = 2,
            Nombre = "Queen",
            NombreArtistico = "Queen",
            FechaNacimiento = new System.DateTime(1970, 1, 1),
            Nacionalidad = Nacionalidad.Britanica,
            GeneroMusical = GeneroMusical.Rock,
            Email = "queen@gmail.com"
        },
        new Artista
        {
            Id = 3,
            Nombre = "The Beatles",
            NombreArtistico = "The Beatles",
            FechaNacimiento = new System.DateTime(1960, 1, 1),
            Nacionalidad = Nacionalidad.Britanica,
            GeneroMusical = GeneroMusical.Rock,
            Email = "beatles@gmail.com"
        });
    }
}
