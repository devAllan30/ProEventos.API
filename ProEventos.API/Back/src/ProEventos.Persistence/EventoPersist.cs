using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventosPersist : IEventosPersist
    {
        private readonly ProEventosContext _context;

        public EventosPersist(ProEventosContext context)
        {
            _context = context;
        }
       



      
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);
            if(includePalestrantes){
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(e=> e.Palestrante);
            }
            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);
            if(includePalestrantes){
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(e=> e.Palestrante);
            }
            query = query.OrderBy(e => e.Id)
                            .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public Task<Palestrante[]> GetAllPalestrantesByAsync(bool includeEventos)
        {
            throw new System.NotImplementedException();
        }

        public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes)
        {
                        IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);
            if(includePalestrantes){
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe=> pe.Palestrante);
            }
            query = query.OrderBy(e => e.Id)
                            .Where(e => e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        public Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }
    }
}