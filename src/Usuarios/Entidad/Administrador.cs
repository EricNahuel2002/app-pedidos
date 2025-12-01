using System.ComponentModel.DataAnnotations;

namespace Usuarios.Entidad;

public class Administrador
{
    [Key]
    public int IdAdmin { get; set; }
    [Required]
    public string Nombre { get; set; } = null!;
    [Required]
    public string Contrasenia { get; set; } = null!;
}
