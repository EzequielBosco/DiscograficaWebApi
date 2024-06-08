namespace DiscograficaWebApi.DAL.Models
{
    public class Cancion : EntidadBase
    {
        public GeneroMusical GeneroMusical { get; set; }
        public int Duracion { get; set; }
        public Disco? Disco { get; set; }
        public long? DiscoId { get; set; }
        public Artista Artista { get; set; }
        public long ArtistaId { get; set; }
    }
}
