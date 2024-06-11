using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Cancion;
using DiscograficaWebApi.DTOs.Disco;
using DiscograficaWebApi.DTOs.Discografica;

namespace DiscograficaWebApi.DTOs.Artista;

public class ArtistaResponseDto
{
    public string Nombre { get; set; }
    public string? Apellido { get; set; }
    public string NombreArtistico { get; set; }
    public GeneroMusical? GeneroMusical { get; set; }
    public string Email { get; set; }
    public string? Telefono { get; set; }
    public string? Biografia { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public DiscograficaResponseDto Discografica { get; set; }
    //public List<DiscoResponseDto> Discos { get; set; }
    //public List<CancionResponseDto> Cancions { get; set; }
}
