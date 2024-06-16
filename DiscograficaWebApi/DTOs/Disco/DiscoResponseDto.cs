using DiscograficaWebApi.DAL.Models.Enums;
using DiscograficaWebApi.DTOs.Artista;
using DiscograficaWebApi.DTOs.Cancion;

namespace DiscograficaWebApi.DTOs.Disco;

public class DiscoResponseDto
{
    public string Nombre { get; set; }
    public GeneroMusical GeneroMusical { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public int UnidadesVendidas { get; set; }
    public string SKU { get; set; }
    public ArtistaResponseDto Artista { get; set; }
    public List<CancionResponseDto> Cancions { get; set; }
}
