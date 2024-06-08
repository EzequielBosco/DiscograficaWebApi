namespace DiscograficaWebApi.DAL.Models
{
    public class Usuario : Persona
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }
    }
}
