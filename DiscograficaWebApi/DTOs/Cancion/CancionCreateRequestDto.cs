using DiscograficaWebApi.DAL.Models;

namespace DiscograficaWebApi.DTOs.Cancion;

public class CancionCreateRequestDto
{
    public string Nombre { get; set; }
    public GeneroMusical GeneroMusical { get; set; }
    public int Duracion { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public long? DiscoId { get; set; }
    public long ArtistaId { get; set; }
}
