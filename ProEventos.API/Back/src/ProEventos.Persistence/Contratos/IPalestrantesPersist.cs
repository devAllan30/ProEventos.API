using System.Threading.Tasks;
using ProEventos.Domain;
namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantesPersist
    {
       

        //PALESTRANTES
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesByAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos);
    
}
}