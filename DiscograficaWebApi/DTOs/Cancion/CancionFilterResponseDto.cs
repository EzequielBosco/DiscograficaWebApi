using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Artista;

namespace DiscograficaWebApi.DTOs.Cancion;

public class CancionFilterResponseDto
{
    public string Nombre { get; set; }
    public GeneroMusical GeneroMusical { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public ArtistaResponseDto Artista { get; set; }
}
