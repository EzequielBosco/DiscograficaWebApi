using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscograficaWebApi.DAL.Models;

public class Cancion : EntidadBase
{
    [Required]
    public GeneroMusical GeneroMusical { get; set; }
    [Required]
    public int Duracion { get; set; }

    [ForeignKey(nameof(Disco))]
    public long? DiscoId { get; set; }
    public Disco? Disco { get; set; }

    [ForeignKey(nameof(Artista))]
    public long ArtistaId { get; set; }
    public Artista Artista { get; set; }
}
