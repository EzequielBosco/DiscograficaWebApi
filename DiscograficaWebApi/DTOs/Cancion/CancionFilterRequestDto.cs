using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Artista;

namespace DiscograficaWebApi.DTOs.Cancion;

public class CancionFilterRequestDto
{
    public string? Nombre { get; set; }
    public int? Duracion { get; set; }
    public GeneroMusical? GeneroMusical { get; set; }
    public string? Artista { get; set; }
}
