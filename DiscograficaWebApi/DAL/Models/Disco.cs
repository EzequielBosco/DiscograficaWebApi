using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscograficaWebApi.DAL.Models;

public class Disco : EntidadBase
{
    [Required]
    public GeneroMusical GeneroMusical { get; set; }
    [Required]
    public DateTime FechaLanzamiento { get; set; }
    [Required]
    public int UnidadesVendidas { get; set; } = 0;
    [Required]
    [MaxLength(50)]
    public string SKU { get; set; }

    [ForeignKey(nameof(Artista))]
    public long ArtistaId { get; set; }
    public Artista Artista { get; set; }

    public List<Cancion> Cancions { get; set; }
}
