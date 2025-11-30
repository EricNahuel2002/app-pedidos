using System.ComponentModel.DataAnnotations;

namespace Usuarios.modelview;

public class UsuarioModelView
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
}
