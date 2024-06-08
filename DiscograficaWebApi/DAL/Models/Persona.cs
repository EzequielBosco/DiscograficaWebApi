namespace DiscograficaWebApi.DAL.Models
{
    public abstract class Persona : EntidadBase
    {
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
