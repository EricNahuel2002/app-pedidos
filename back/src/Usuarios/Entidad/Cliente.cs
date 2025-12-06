using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuarios.Entidad;

public class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [Required]
    [MaxLength(150)]
    public string Nombre { get; set; } = null!;

    [Required]
    [MaxLength(255)]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    [MaxLength(255)]
    public string Contrasenia { get; set; } = null!;
    [Required]
    [MaxLength(255)]
    public string Direccion { get; set; } = null!;

    [MaxLength(20)]
    public string? Telefono { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}