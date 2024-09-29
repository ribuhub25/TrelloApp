using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrelloApp.Models
{
    public class Usuario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? date_created { get; set; }
        public DateTime? date_updated { get; set; }
        public IEnumerable<RolesUsuarios> RolesUsuarios { get; set; }
        public IEnumerable<Tablero> Tableros { get; set; }
        public IEnumerable<Tarjeta> Tarjetas { get; set; }
        public IEnumerable<Estado> Estados { get; set; }

    }
}
