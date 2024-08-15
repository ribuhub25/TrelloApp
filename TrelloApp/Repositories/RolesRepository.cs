using Microsoft.EntityFrameworkCore;
using TrelloApp.Models;
using System.Linq;

namespace TrelloApp.Repositories
{
    public interface IRolesRepository
    {
        public List<Rol> GetRoles();
        public Task<string> GetRolById(int id);
        public Task<List<RolesUsuarios>> GetRolesByIdUser();
    }
    public class RolesRepository : IRolesRepository
    {
        private readonly TrelloContext _context;
        public RolesRepository(TrelloContext context)
        {
            _context = context;
        }

        public async Task<string> GetRolById(int id)
        {
            Rol? rol = await _context.Roles.Where(r=>r.Id == id).FirstOrDefaultAsync();
            string name = rol.Description;
            return name;
        }

        public List<Rol> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public async Task<List<RolesUsuarios>> GetRolesByIdUser()
        {
            var query = await (from ru in _context.RolesUsuarios
                         join r in _context.Roles   
                         on ru.RolId equals r.Id
                         select ru).ToListAsync();
            return query;
        }
    }
}
