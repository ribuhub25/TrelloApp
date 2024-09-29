using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TrelloApp.Models;

namespace TrelloApp.Repositories
{
    public interface ITableroRepository
    {
        public Task<bool> Insert(Tablero tablero);
        public Task<Tablero?> GetById(int id);
        public Task<List<Estado>> GetEstadosByTableroId(int tableroid);
        public Task<IEnumerable<Tablero>> GetAll();

    }

    public class TableroRepository: ITableroRepository
    {
        private readonly TrelloContext _context;
        public TableroRepository(TrelloContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tablero>> GetAll()
        {
            return await _context.Tableros.Include(t=>t.Usuario).ToListAsync();
        }

        public Task<Tablero?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Estado>> GetEstadosByTableroId(int tableroid)
        {
            List<Estado> estados = await _context.Estados.Where(e => e.TableroId == tableroid).ToListAsync();
            return estados;
        }

        public async Task<bool> Insert(Tablero tablero)
        {
            if(tablero != null)
            {
                await _context.Tableros.AddAsync(tablero);
                await _context.SaveChangesAsync();
                return true;
            }else return false;
        }
    }
}
