using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ordenes.Entidad
{
    public class OrderItem
    {
        // PK
        [Key]
        public int OrderItemId { get; set; }

        // FK local hacia Order. 
        // EF Core infiere la relación basándose en el nombre de la propiedad y la propiedad de navegación 'Order'.
        [Required]
        public int OrderId { get; set; }

        // Propiedad de navegación para la relación 1:N local (OrderItem pertenece a una Orden)
        public Orden? Order { get; set; }

        // Referencia remota al menu (NO FK física)
        [Required]
        public int ItemId { get; set; }

        // Snapshot de menú
        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int UnitPriceCents { get; set; } // snapshot

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}