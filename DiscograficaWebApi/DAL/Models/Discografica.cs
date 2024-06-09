using System.ComponentModel.DataAnnotations;

namespace DiscograficaWebApi.DAL.Models;

public class Discografica : EntidadBase
{
    [Required]
    [MaxLength(255)]
    public string Direccion { get; set; }
    [Required]
    [Phone]
    [MaxLength(15)]
    public string Telefono { get; set; }
    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; }
    [MaxLength(255)]
    public string? WebSite { get; set; }
    [Required]
    public DateTime FechaFundacion { get; set; }
    public List<Artista> Artistas { get; set; }
}
