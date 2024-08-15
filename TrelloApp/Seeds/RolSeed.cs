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
                },
                new Rol()
                {
                    Id = 2,
                    Description = "Empleado",
                }
            );
        }
    }
}
