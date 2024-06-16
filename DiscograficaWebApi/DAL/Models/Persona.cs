using DiscograficaWebApi.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DiscograficaWebApi.DAL.Models;

public abstract class Persona : EntidadBase
{
    public string? Apellido { get; set; }
    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; }
    [Phone]
    [MaxLength(15)]
    public string? Telefono { get; set; }
    public Nacionalidad? Nacionalidad { get; set; }
    [Required]
    public DateTime FechaNacimiento { get; set; }
}
