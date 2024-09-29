using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrelloApp.Models;

namespace TrelloApp.Seeds
{
    public class RolSeed : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasData(
                new Rol()
                {
                    Id = 1,
                    Description = "Administrador",
                    created_at = DateTime.Now,
                },
                new Rol()
                {
                    Id = 2,
                    Description = "Premium",
                    created_at = DateTime.Now,
                },
                new Rol()
                {
                    Id = 3,
                    Description = "Estandar",
                    created_at = DateTime.Now,
                },
                new Rol()
                {
                    Id = 4,
                    Description = "Empleado",
                    created_at = DateTime.Now,
                }
            );
        }
    }
}
