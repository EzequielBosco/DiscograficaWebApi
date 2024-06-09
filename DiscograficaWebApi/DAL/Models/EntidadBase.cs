using System.ComponentModel.DataAnnotations;

namespace DiscograficaWebApi.DAL.Models;

public abstract class EntidadBase
{
    [Key]
    [Required]
    public long Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; }
    [Required]
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    [Required]
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedTime { get; set; }
}
