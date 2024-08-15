namespace TrelloApp.Models
{
    public class RolesUsuarios
    {
        //public int Id { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
