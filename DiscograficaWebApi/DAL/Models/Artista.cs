using System.ComponentModel.DataAnnotations.Schema;

namespace DiscograficaWebApi.DAL.Models;

public class Artista : Persona
{
    public string NombreArtistico { get; set; }
    public GeneroMusical GeneroMusical { get; set; }
    public string? Biografia { get; set; }

    [ForeignKey(nameof(Discografica))]
    public long DiscograficaId { get; set; }
    public Discografica Discografica { get; set; }

    public List<Disco> Discos { get; set; }
    public List<Cancion> Canciones { get; set;}
}
