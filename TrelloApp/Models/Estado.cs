using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrelloApp.Models
{
    public class Estado
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TableroId { get; set; }
        public Tablero Tablero { get; set; }

        public string Name { get; set; }
        public DateTime? date_created { get; set; }
        public DateTime? date_updated { get; set; }

        public ICollection<Tarjeta> Tarjeta { get; set; }
    }
}
