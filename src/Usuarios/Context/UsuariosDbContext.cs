using Microsoft.EntityFrameworkCore;
using Usuarios.Entidad;

namespace Usuarios.Context;

public class UsuariosDbContext: DbContext
{
    public UsuariosDbContext(DbContextOptions<UsuariosDbContext> options)
            : base(options)
    {
    }

    // Definición de la tabla
    public DbSet<Cliente> Usuarios { get; set; }
    public DbSet<Administrador> Administradores { get; set; }
    public DbSet<Repartidor> Repartidores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. Configurar índice único para Email
        modelBuilder.Entity<Cliente>()
            .HasIndex(u => u.Email)
            .IsUnique(); // Esto asegura que no se puedan insertar emails duplicados

        // 2. Configurar CreatedAt y UpdatedAt para MySQL (valores por defecto)
        modelBuilder.Entity<Cliente>()
            .Property(u => u.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

        base.OnModelCreating(modelBuilder);
    }
}
