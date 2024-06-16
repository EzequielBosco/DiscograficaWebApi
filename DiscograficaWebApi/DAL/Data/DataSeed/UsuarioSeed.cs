using DiscograficaWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscograficaWebApi.DAL.Data.DataSeed;

public class UsuarioSeed : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasData(new Usuario
        {
            Id= 1,
            UserName = "Emiliano1",
            Password ="123456",
            Nombre = "Emiliano",
            Email = "emiliano@gmail.com",
            FechaNacimiento = new DateTime(1997, 10, 10)
        }, new Usuario
        {
            Id= 2,
            UserName = "EzequielTomas",
            Password = "123456",
            Nombre = "Ezequiel",
            Email = "ezequiel@gmail.com",
            FechaNacimiento = new DateTime(1998, 11, 11)
        },
        new Usuario
        {
            Id= 3,
            UserName = "Juli123",
            Password = "123456",
            Nombre = "Julieta",
            Email = "julieta@gmail.com",
            FechaNacimiento = new DateTime(1999, 12, 12)
        });
    }
}
