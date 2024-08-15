using Microsoft.EntityFrameworkCore;
using TrelloApp.Models;

namespace TrelloApp.Repositories
{
    public interface IRolesUsuariosRepository
    {
        public Task<List<RolesUsuarios>> GetRolesUsuarios();
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
    }
}
