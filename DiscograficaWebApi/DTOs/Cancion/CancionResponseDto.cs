using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Artista;

namespace DiscograficaWebApi.DTOs.Cancion;

public class CancionResponseDto
{
    public string Nombre { get; set; }
    public GeneroMusical GeneroMusical { get; set; }
    public int Duracion { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public string? Disco { get; set; }
    public ArtistaResponseDto Artista { get; set; }
}
