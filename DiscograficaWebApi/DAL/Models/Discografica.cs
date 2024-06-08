namespace DiscograficaWebApi.DAL.Models
{
    public class Discografica : EntidadBase
    {
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string? WebSite { get; set; }
        public DateTime FechaFundacion { get; set; }
        public List<Artista> Artistas { get; set; }
    }
}
