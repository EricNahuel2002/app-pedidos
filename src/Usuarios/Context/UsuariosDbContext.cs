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
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. Configurar índice único para Email
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique(); // Esto asegura que no se puedan insertar emails duplicados

        // 2. Configurar CreatedAt y UpdatedAt para MySQL (valores por defecto)
        modelBuilder.Entity<Usuario>()
            .Property(u => u.CreatedAt)
            .HasDefaultValueSql("NOW()");

        modelBuilder.Entity<Usuario>()
            .Property(u => u.UpdatedAt)
            .HasDefaultValueSql("NOW()");

        base.OnModelCreating(modelBuilder);
    }
}
