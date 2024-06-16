using DiscograficaWebApi.DAL.Models.Enums;
using DiscograficaWebApi.DTOs.Artista;

namespace DiscograficaWebApi.DTOs.Disco;

public class DiscoFilterRequestDto
{
    public string? Nombre { get; set; }
    public GeneroMusical? GeneroMusical { get; set; }
    public int? UnidadesVendidas { get; set; }
    public string? Artista { get; set; }
}
