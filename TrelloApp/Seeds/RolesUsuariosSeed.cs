using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrelloApp.Models;

namespace TrelloApp.Seeds
{
    public class RolesUsuariosSeed : IEntityTypeConfiguration<RolesUsuarios>
    {
        public void Configure(EntityTypeBuilder<RolesUsuarios> builder)
        {
            builder.HasData(
                new RolesUsuarios()
                {
                    RolId = 1,
                    UsuarioId = 1,
                }
            );
        }
    }
}
