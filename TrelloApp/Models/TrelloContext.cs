using Microsoft.EntityFrameworkCore;
using TrelloApp.Seeds;

namespace TrelloApp.Models
{
    public class TrelloContext: DbContext
    {
        public DbSet<Tablero> Tableros { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<RolesUsuarios> RolesUsuarios { get; set; }

        public TrelloContext(DbContextOptions<TrelloContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RolesUsuarios>().HasKey(ru=> new {ru.UsuarioId,ru.RolId});

            builder.Entity<RolesUsuarios>()
                .HasOne<Rol>(ru => ru.Rol)
                .WithMany(r => r.RolesUsuarios)
                .HasForeignKey(ru => ru.RolId);

            builder.Entity<RolesUsuarios>()
                .HasOne<Usuario>(ru => ru.Usuario)
                .WithMany(u => u.RolesUsuarios)
                .HasForeignKey(ru => ru.UsuarioId);

            //builder.ApplyConfiguration(new TableroSeed());
            builder.ApplyConfiguration(new RolSeed());
            builder.ApplyConfiguration(new UsuarioSeed());
            builder.ApplyConfiguration(new RolesUsuariosSeed());
        }
    }
}
