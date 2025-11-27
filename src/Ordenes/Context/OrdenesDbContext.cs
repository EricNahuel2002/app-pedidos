using Microsoft.EntityFrameworkCore;
using Ordenes.Entidad;

namespace Ordenes.Context;

public class OrdenesDbContext: DbContext
{
    public OrdenesDbContext(DbContextOptions<OrdenesDbContext> options)
            : base(options)
    {
    }

    // Tablas principales
    public DbSet<Orden> Ordenes { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. Configuración para la entidad Orden
        modelBuilder.Entity<Orden>()
            // Se configura la clave primaria y las restricciones con Data Annotations.
            // Usamos Fluent API para los valores por defecto de tiempo en MySQL:
            .Property(o => o.CreatedAt)
            .HasDefaultValueSql("NOW()");

        modelBuilder.Entity<Orden>()
            .Property(o => o.UpdatedAt)
            .HasDefaultValueSql("NOW()");

        // 2. Configuración de la relación local (Foreign Key)
        modelBuilder.Entity<OrderItem>()
            .HasOne(item => item.Order)               // OrderItem tiene una Orden
            .WithMany(order => order.Items)           // La Orden tiene muchos OrderItems
            .HasForeignKey(item => item.OrderId)      // Usa OrderId como la clave foránea local
            .OnDelete(DeleteBehavior.Cascade);        // Si se elimina la Orden, sus OrderItems también se eliminan.

        // 3. Configuración para OrderItem
        modelBuilder.Entity<OrderItem>()
            .Property(item => item.CreatedAt)
            .HasDefaultValueSql("NOW()");

        base.OnModelCreating(modelBuilder);
    }
}
