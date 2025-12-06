using Microsoft.EntityFrameworkCore;
using Usuarios.Entidad;

namespace Usuarios.Context;

public class UsuariosDbContext: DbContext
{
    public UsuariosDbContext(DbContextOptions<UsuariosDbContext> options)
            : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Administrador> Administradores { get; set; }
    public DbSet<Repartidor> Repartidores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Cliente>()
            .Property(u => u.FechaCreacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

        base.OnModelCreating(modelBuilder);
    }
}
