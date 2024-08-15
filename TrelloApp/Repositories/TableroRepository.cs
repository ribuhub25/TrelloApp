using Microsoft.EntityFrameworkCore.ChangeTracking;
using TrelloApp.Models;

namespace TrelloApp.Repositories
{
    public interface ITableroRepository
    {
        Task<Tablero> Insert(Tablero tablero);
        Task<Tablero?> GetById(int id);

    }

    public class TableroRepository: ITableroRepository
    {
        private readonly TrelloContext _context;
        public TableroRepository(TrelloContext context)
        {
            _context = context;
        }

        public Task<Tablero?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tablero> Insert(Tablero tablero)
        {
            EntityEntry<Tablero> inserterTablero = await _context.Tableros.AddAsync(tablero);
            await _context.SaveChangesAsync();
            return inserterTablero.Entity;
        }
    }
}
