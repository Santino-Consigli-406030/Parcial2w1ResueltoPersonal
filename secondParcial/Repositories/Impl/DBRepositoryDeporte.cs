using Microsoft.EntityFrameworkCore;
using secondParcial.Contexto;
using secondParcial.Model;
using secondParcial.Repositories.Interfaces;

namespace secondParcial.Repositories.Impl
{
    public class DBRepositoryDeporte : IDBRepositoryDeporte
    {
    
        public readonly ClubContext _clubContext;
        public DBRepositoryDeporte(ClubContext clubContext)
        {
            _clubContext = clubContext;
        }
        public async Task<Deporte> GetDeporteByIdAsync(Guid id)
        {
            var deporte = await _clubContext.Deportes.FirstOrDefaultAsync(x=> x.Id == id);
            return deporte;
        }
        public async Task<List<Deporte>> GetAllDeportesAsync()
        {
            var deportes = await _clubContext.Deportes.ToListAsync();
            return deportes;
        }
    }
}
