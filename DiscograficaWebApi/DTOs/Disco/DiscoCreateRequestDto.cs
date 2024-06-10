using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Cancion;

namespace DiscograficaWebApi.DTOs.Disco;

public class DiscoCreateRequestDto
{
    public string Nombre { get; set; }
    public GeneroMusical GeneroMusical { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public int UnidadesVendidas { get; set; } = 0;
    public string SKU { get; set; }
    public long ArtistaId { get; set; }
    public List<CancionResponseDto> Cancions { get; set; }
}
