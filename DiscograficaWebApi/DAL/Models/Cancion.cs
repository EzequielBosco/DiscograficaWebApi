using System.ComponentModel.DataAnnotations.Schema;

namespace DiscograficaWebApi.DAL.Models;

public class Cancion : EntidadBase
{
    public GeneroMusical GeneroMusical { get; set; }
    public int Duracion { get; set; }

    [ForeignKey(nameof(Disco))]
    public long? DiscoId { get; set; }
    public Disco? Disco { get; set; }

    [ForeignKey(nameof(Artista))]
    public long ArtistaId { get; set; }
    public Artista Artista { get; set; }
}
