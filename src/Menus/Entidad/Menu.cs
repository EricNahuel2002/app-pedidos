using System.ComponentModel.DataAnnotations;

namespace Menus.Entidad;
public class Menu
{
    [Key]
    public int ItemId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public string Description { get; set; } = string.Empty;
    [Required]
    public int PriceCents { get; set; }

    public bool Available { get; set; } = true;
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
