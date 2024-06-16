using System.ComponentModel.DataAnnotations;
using DiscograficaWebApi.DAL.Models.Enums;

namespace DiscograficaWebApi.DAL.Models;

public class Usuario : Persona
{
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }
    [Required]
    [MaxLength(255)]
    public string Password { get; set; }
    [Required]
    public Rol Rol { get; set; } = Rol.Usuario;
}
