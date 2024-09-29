using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using TrelloApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;


namespace TrelloApp.Repositories
{

    public interface IUsuarioRepository
    {
        public Task<Usuario> Insert(Usuario usuario);
        public Task<Usuario?> GetByCredencials(string correo, string pwd);
        public Task<bool> GetByEmail(string correo);
        public Task<RolesUsuarios> AddRole(int roleid, int userid);
        public IQueryable<Usuario> GetUsuarios2();
        public Task<List<Usuario>> GetUsuarios();
        public Task<string> GetUsuarioById(int id);
        public Task<Usuario> GetUsuario(int id);

    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TrelloContext _context;
        public UsuarioRepository(TrelloContext context)
        {
            _context = context;
        }
        public async Task<Usuario?> GetByCredencials(string correo,string pwd)
        {
            Usuario? usuario = await _context.Usuarios
                                .Where( u =>
                                u.Password == pwd &&
                                u.Email == correo
                                ).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<Usuario> Insert(Usuario usuario)
        {
            EntityEntry<Usuario> insertarUsuario = await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return insertarUsuario.Entity;
        }

        public async Task<bool> GetByEmail(string correo)
        {
            Usuario? usuario = await _context.Usuarios
                                .Where(u =>
                                u.Email == correo
                                ).FirstOrDefaultAsync();
            if(usuario == null) return false;
            else return true;
        }

        public async Task<RolesUsuarios> AddRole(int roleid, int userid)
        {
            if (_context.RolesUsuarios.Any(ru => ru.RolId == roleid && ru.UsuarioId == userid))
            {
                // Record already exists, return null
                return null;
            }

            var usuario =  _context.Usuarios
                .Include(u=>u.RolesUsuarios)
                .FirstOrDefault(u=>u.Id == userid);
            var rol =  _context.Roles
                .Include(r => r.RolesUsuarios)
                .FirstOrDefault(r => r.Id == roleid);
            if (usuario != null && rol != null)
            {
                var nuevoRolUser = new RolesUsuarios
                {
                    RolId = roleid,
                    UsuarioId = userid
                };
                await _context.RolesUsuarios.AddAsync(nuevoRolUser);
                await  _context.SaveChangesAsync();
                return nuevoRolUser;
            }
            else
            {
                return null;
            }
        }
        public IQueryable<Usuario> GetUsuarios2()
        {
            return _context.Usuarios.Include(u => u.RolesUsuarios);
        }
        public async Task<List<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<string> GetUsuarioById(int id)
        {
            Usuario? usuario = await _context.Usuarios.Where(u => u.Id == id).FirstOrDefaultAsync();
            string name = usuario.Name;
            return name;
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _context.Usuarios.Where(u=>u.Id == id).FirstOrDefaultAsync();
        }
    }
}
