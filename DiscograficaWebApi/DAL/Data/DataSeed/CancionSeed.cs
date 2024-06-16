using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DAL.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApI_Preparcial_II.Dal.Data.DataSeed;

public class CancionSeed : IEntityTypeConfiguration<Cancion>
{
    public void Configure(EntityTypeBuilder<Cancion> builder)
    {

        builder.HasData(new Cancion
        {
            Id = 1,
            Nombre = "Time",
            GeneroMusical = GeneroMusical.Rock,
            Duracion = 420,
            FechaLanzamiento = new System.DateTime(1973, 3, 1),
            DiscoId = 1,
            ArtistaId = 1
        },
        new Cancion
        {
            Id = 2,
            Nombre = "Money",
            GeneroMusical = GeneroMusical.Rock,
            Duracion = 382,
            FechaLanzamiento = new System.DateTime(1973, 3, 1),
            DiscoId = 1,
            ArtistaId = 1
        },
        new Cancion
        {
            Id = 3,
            Nombre = "Us and Them",
            GeneroMusical = GeneroMusical.Rock,
            Duracion = 462,
            FechaLanzamiento = new System.DateTime(1973, 3, 1),
            DiscoId = 1,
            ArtistaId = 1
        },
        new Cancion
        {
            Id = 4,
            Nombre = "Bohemian Rhapsody",
            GeneroMusical = GeneroMusical.Rock,
            Duracion = 300,
            FechaLanzamiento = new System.DateTime(1973, 3, 1),
            DiscoId = 2,
            ArtistaId = 2,
        },
        new Cancion
        {
            Id = 5,
            Nombre = "Killer Queen",
            GeneroMusical = GeneroMusical.Rock,
            Duracion = 180,
            FechaLanzamiento = new System.DateTime(1973, 3, 1),
            DiscoId = 2,
            ArtistaId = 2
        },
        new Cancion
        {
            Id = 6,
            Nombre = "Somebody to Love",
            GeneroMusical = GeneroMusical.Rock,
            Duracion = 240,
            FechaLanzamiento = new System.DateTime(1973, 3, 1),
            DiscoId = 2,
            ArtistaId = 2
        },
        new Cancion
        {
            Id = 7,
            Nombre = "Another One Bites the Dust",
            GeneroMusical = GeneroMusical.Rock,
            Duracion = 240,
            FechaLanzamiento = new System.DateTime(1973, 3, 1),
            DiscoId = 2,
            ArtistaId = 2
        },
        new Cancion
        {
            Id = 8,
            Nombre = "Stairway to Heaven",
            GeneroMusical = GeneroMusical.Rock,
            Duracion = 480,
            FechaLanzamiento = new System.DateTime(1973, 3, 1),
            DiscoId = 3,
            ArtistaId = 3
        },
        new Cancion
        {
            Id = 9,
            Nombre = "Black Dog",
            GeneroMusical = GeneroMusical.Rock,
            Duracion = 240,
            FechaLanzamiento = new System.DateTime(1973, 3, 1),
            DiscoId = 3,
            ArtistaId = 3
        },
        new Cancion
        {
            Id = 10,
            Nombre = "Rock and Roll",
            GeneroMusical = GeneroMusical.Rock,
            Duracion = 240,
            FechaLanzamiento = new System.DateTime(1973, 3, 1),
            DiscoId = 3,
            ArtistaId = 3
        });
    }
}
