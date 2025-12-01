using System.ComponentModel.DataAnnotations;

namespace Usuarios.Entidad;

public class Repartidor
{
    [Key]
    public int IdRepartidor { get; set; }
    [Required]
    public string Nombre { get; set; } = null!;
    [Required]
    public string Contrasenia { get; set; } = null!;
}
