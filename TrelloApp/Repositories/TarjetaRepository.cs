using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using TrelloApp.Models;

namespace TrelloApp.Repositories
{
    public interface ITarjetaRepository
    {
        public Task<bool> Insert(Tarjeta tarjeta);
        public Task<IEnumerable<Tarjeta>> GetTarjetas();
        public Task<bool> DeleteTarjeta(int id);
        public Task<Tarjeta> DetalleTarjeta(int id);
        public Task<bool> Update(Tarjeta tarjeta);
        public Task<bool> PutEstado(Tarjeta tarjeta);
    }
    public class TarjetaRepository : ITarjetaRepository
    {
        private readonly TrelloContext _context;
        public TarjetaRepository(TrelloContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteTarjeta(int id)
        {
            var tarjeta = await _context.Tarjetas.FindAsync(id);
            if (tarjeta != null)
            {
                _context.Tarjetas.Remove(tarjeta);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
            
        }

        public async Task<Tarjeta> DetalleTarjeta(int id)
        {
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return  await _context.Tarjetas.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public async Task<IEnumerable<Tarjeta>> GetTarjetas()
        {
            return await _context.Tarjetas.ToListAsync();
        }
        public async Task<bool> Insert(Tarjeta tarjeta)
        {
            if(tarjeta.Description == null || tarjeta.Title == null)
            {
                return false;
            }
            else
            {
                await _context.Tarjetas.AddAsync(tarjeta);
                await _context.SaveChangesAsync();
                return true;
            }
            
        }

        public async Task<bool> PutEstado(Tarjeta tarjeta)
        {
            Tarjeta? tarjetaEncontrada = await _context.Tarjetas.FindAsync(tarjeta.Id);
            if(tarjetaEncontrada == null) { return false; }
            else
            {
                tarjetaEncontrada.EstadoId = tarjeta.EstadoId;
                tarjetaEncontrada.date_updated = DateTime.Now;
                await _context.SaveChangesAsync();
                return true;
            }    
        }

        public async Task<bool> Update(Tarjeta tarjeta)
        {
            if (tarjeta.Description == null || tarjeta.Title == null)
            {
                return false;
            }
            else
            {
                var tarjetaUpdate = await _context.Tarjetas.FindAsync(tarjeta.Id);
                if (tarjetaUpdate != null)
                {
                    tarjetaUpdate.Estado = tarjeta.Estado;
                    tarjetaUpdate.Description = tarjeta.Description;
                    tarjetaUpdate.Title = tarjeta.Title;
                    tarjetaUpdate.date_updated = DateTime.Now;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else return false;           
            }

        }
    }
}
