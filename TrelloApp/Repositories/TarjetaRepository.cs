using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using TrelloApp.Models;

namespace TrelloApp.Repositories
{
    public interface ITarjetaRepository
    {
        public Task<Tarjeta> Insert(Tarjeta tarjeta);
        public IEnumerable<Tarjeta> GetTarjetas();

        public Tarjeta DetalleTarjeta(int id);
    }
    public class TarjetaRepository : ITarjetaRepository
    {
        private readonly TrelloContext _context;
        public TarjetaRepository(TrelloContext context)
        {
            _context = context;
        }

        public Tarjeta DetalleTarjeta(int id)
        {
            return _context.Tarjetas.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Tarjeta> GetTarjetas()
        {
            return _context.Tarjetas.ToList();
        }

        public async Task<Tarjeta> Insert(Tarjeta tarjeta)
        {
            EntityEntry<Tarjeta> insertarTarjeta = await _context.Tarjetas.AddAsync(tarjeta);
            await _context.SaveChangesAsync();
            return insertarTarjeta.Entity;
        }
    }
}
