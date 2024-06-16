using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DiscograficaWebApi.DAL.Models.Enums;

namespace DiscograficaWebApi.DAL.Models;

public class Cancion : EntidadBase
{
    [Required]
    public GeneroMusical GeneroMusical { get; set; }
    [Required]
    public int Duracion { get; set; }
    [Required]
    public DateTime FechaLanzamiento { get; set; }

    [ForeignKey(nameof(Disco))]
    public long? DiscoId { get; set; }
    public Disco? Disco { get; set; }

    [Required]
    [ForeignKey(nameof(Artista))]
    public long ArtistaId { get; set; }
    public Artista Artista { get; set; }
}
