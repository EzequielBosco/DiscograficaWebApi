namespace DiscograficaWebApi.DTOs.Discografica;

public class DiscograficaCreateRequestDto
{
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public DateTime FechaFundacion { get; set; }
    public string? WebSite { get; set; }
}
