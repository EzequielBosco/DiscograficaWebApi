using DiscograficaWebApi.DTOs.Artista;

namespace DiscograficaWebApi.DTOs.Discografica;

public class DiscograficaResponseDto
{
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public DateTime FechaFundacion { get; set; }
    public string? WebSite { get; set; }
    public List<ArtistaResponseDto> Artistas { get; set; }
}
