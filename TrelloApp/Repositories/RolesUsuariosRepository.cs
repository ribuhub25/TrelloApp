using Microsoft.EntityFrameworkCore;
using TrelloApp.Models;

namespace TrelloApp.Repositories
{
    public interface IRolesUsuariosRepository
    {
        public Task<List<RolesUsuarios>> GetRolesUsuarios();
        public Task<List<RolesUsuarios>> GetRolesByUser(Usuario user);
    }

    public class RolesUsuariosRepository : IRolesUsuariosRepository
    {
        private readonly TrelloContext _context;
        public RolesUsuariosRepository(TrelloContext context)
        {
            _context = context;
        }
        public async Task<List<RolesUsuarios>> GetRolesUsuarios()
        {
            return await _context.RolesUsuarios.Include(ru=>ru.Rol).ToListAsync();
        }
        public async Task<List<RolesUsuarios>> GetRolesByUser(Usuario user)
        {
            return await _context.RolesUsuarios.Include(ru => ru.Rol).Where(ru=>ru.UsuarioId == user.Id).ToListAsync();
        }
    }
}
