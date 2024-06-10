using DiscograficaWebApi.DAL.Models;

namespace DiscograficaWebApi.DTOs.Disco;

public class DiscoUpdateRequestDto
{
    public string Nombre { get; set; }
    public GeneroMusical GeneroMusical { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public int UnidadesVendidas { get; set; }
    public long ArtistaId { get; set; }
}
