using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrelloApp.Models;

namespace TrelloApp.Seeds
{
    public class UsuarioSeed:IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData(
                    new Usuario()
                    {
                        Id = 1,
                        Name = "Auron",
                        Email = "admin@gmail.com",
                        Password = "12345"
                    },
                    new Usuario()
                    {
                        Id = 2,
                        Name = "Hefesto",
                        Email = "Hefestinho@gmail.com",
                        Password = "12345",
                    },
                    new Usuario()
                    {
                        Id = 3,
                        Name = "Gilgamesh",
                        Email = "Snapero@gmail.com",
                        Password = "snap",
                    },
                    new Usuario()
                    {
                        Id = 4,
                        Name ="Javi",
                        Email = "atlas@gmail.com",
                        Password = "atlas",
                    }
                );
        }
    }
}
