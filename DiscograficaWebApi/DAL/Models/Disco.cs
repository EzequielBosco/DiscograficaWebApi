namespace DiscograficaWebApi.DAL.Models
{
    public class Disco : EntidadBase
    {
        public Artista Artista { get; set; }
        public long ArtistaId { get; set; }
        public GeneroMusical GeneroMusical { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int UnidadesVendidas { get; set; } = 0;
        public string SKU { get; set; }
        public List<Cancion> Canciones { get; set; }
    }
}
