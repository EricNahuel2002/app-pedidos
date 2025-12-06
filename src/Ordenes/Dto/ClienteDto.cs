using System.ComponentModel.DataAnnotations;

namespace Ordenes.Dto;

public class ClienteDto
{
    public int IdCliente { get; set; }
    public string Nombre { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Contrasenia { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string? Telefono { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
