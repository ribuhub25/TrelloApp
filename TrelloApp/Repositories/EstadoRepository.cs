using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TrelloApp.Models;

namespace TrelloApp.Repositories
{
    public interface IEstadoRepository
    {
        public Task<bool> AddEstado(Estado estado);
        public Task<bool> UpdateEstado(Estado estado);
        public Task<bool> DeleteEstado(int id);
    }
    public class EstadoRepository : IEstadoRepository
    {
        private readonly TrelloContext _context;
        public EstadoRepository(TrelloContext context)
        {
            _context = context;
        }
        public async Task<bool> AddEstado(Estado estado)
        {
            if (estado.TableroId != 0)
            {
                estado.date_created = DateTime.Now;
                await _context.Estados.AddAsync(estado);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<bool> DeleteEstado(int id)
        {
            var estado = await _context.Estados.FindAsync(id);
            if (estado != null)
            {
                _context.Estados.Remove(estado);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateEstado(Estado estado)
        {
            var estadoUpdated = await _context.Estados.FirstOrDefaultAsync(e=>e.Id == estado.Id);
            if (estadoUpdated != null)
            {
                estadoUpdated.TableroId = estado.TableroId;
                estadoUpdated.Name = estado.Name;
                estadoUpdated.date_updated = DateTime.Now;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
