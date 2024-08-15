using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrelloApp.Models;

namespace TrelloApp.Seeds
{
    public class TableroSeed:IEntityTypeConfiguration<Tablero>
    {
        public void Configure(EntityTypeBuilder<Tablero> builder)
        {
            builder.HasData(
                    new Tablero()
                    {
                        Id = 1,
                        Name = "tablero 1",
                        Title = "Tablero Kanban",
                        Status = true,
                        date_created = DateTime.Today,
                        date_updated = DateTime.Today,
                    }
                );
        }
    }
}
