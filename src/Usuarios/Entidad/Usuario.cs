using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuarios.Entidad;

public class Usuario
{
    // Indica la clave primaria (PK).
    [Key]
    public int UserId { get; set; }

    // Nombre es requerido y limitamos la longitud.
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = null!;

    // Email es requerido, limitamos la longitud y añadimos un índice único 
    // para asegurar que no haya dos usuarios con el mismo correo.
    [Required]
    [MaxLength(255)]
    [EmailAddress] // Para validación en el código C#
    public string Email { get; set; } = null!;

    // Teléfono es opcional/nullable.
    [MaxLength(20)]
    public string? Phone { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}