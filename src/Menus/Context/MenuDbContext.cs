using Microsoft.EntityFrameworkCore;
using Menus.Entidad;
namespace Menus.Context
{

        public class MenuDbContext : DbContext
        {
            public MenuDbContext(DbContextOptions<MenuDbContext> options)
            : base(options)
            {
            }
            public DbSet<Menu> Menus { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Menu>()
                    .Property(m => m.CreatedAt)
                    .HasDefaultValueSql("NOW()");
                modelBuilder.Entity<Menu>()
                    .Property(m => m.UpdatedAt)
                    .HasDefaultValueSql("NOW()");
                base.OnModelCreating(modelBuilder);
            }
    }
    
}
