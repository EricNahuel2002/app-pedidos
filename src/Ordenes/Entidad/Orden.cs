using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ordenes.Entidad
{
    public class Orden
    {
        // PK
        [Key]
        public int OrderId { get; set; }

        // REFERENCIA remota: solo guardo el id, NO FK física
        [Required]
        public int UserId { get; set; }

        // Snapshot del usuario
        [Required]
        [MaxLength(150)] // Tamaño adecuado para un nombre
        public string UserName { get; set; } = null!;

        [Required]
        [MaxLength(255)] // Tamaño adecuado para un email
        public string UserEmail { get; set; } = null!;

        // Totales y metadatos
        [Required]
        public int TotalCents { get; set; }

        [Required]
        [MaxLength(50)] // Para estados como "pendiente", "en proceso", "entregado"
        public string Status { get; set; } = "pendiente";

        // El signo '?' en Address y Notes ya indica que son opcionales/nullable.
        [MaxLength(500)]
        public string? Address { get; set; }

        [MaxLength(1000)]
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Relación local: Order -> OrderItems (EF Core la detectará automáticamente)
        public ICollection<OrderItem>? Items { get; set; }
    }
}