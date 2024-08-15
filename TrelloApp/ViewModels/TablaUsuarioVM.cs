using TrelloApp.Models;

namespace TrelloApp.ViewModels
{
    public class TablaUsuarioVM
    {
        public List<Usuario> Usuarios { get; set; }
        public List<RolesUsuarios> RolesByUser { get; set; }
    }
}
