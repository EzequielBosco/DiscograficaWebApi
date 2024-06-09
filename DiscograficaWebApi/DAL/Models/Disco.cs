using System.ComponentModel.DataAnnotations.Schema;

namespace DiscograficaWebApi.DAL.Models;

public class Disco : EntidadBase
{
    public GeneroMusical GeneroMusical { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public int UnidadesVendidas { get; set; } = 0;
    public string SKU { get; set; }

    [ForeignKey(nameof(Artista))]
    public long ArtistaId { get; set; }
    public Artista Artista { get; set; }

    public List<Cancion> Canciones { get; set; }
}
