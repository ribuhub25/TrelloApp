using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrelloApp.Models
{
    public class Tarjeta
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? date_created { get; set; }
        public DateTime? date_updated { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
