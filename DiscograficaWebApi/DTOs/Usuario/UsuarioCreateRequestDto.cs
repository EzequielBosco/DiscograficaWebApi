namespace DiscograficaWebApi.DTOs.Usuario;

public class UsuarioCreateRequestDto
{
    public string Nombre { get; set; }
    public string? Apellido { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string? Telefono { get; set; }
    public DateTime FechaNacimiento { get; set; }
}
