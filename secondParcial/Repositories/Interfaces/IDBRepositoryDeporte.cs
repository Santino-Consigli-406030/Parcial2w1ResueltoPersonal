using secondParcial.Model;

namespace secondParcial.Repositories.Interfaces
{
    public interface IDBRepositoryDeporte
    {
        Task<Deporte> GetDeporteByIdAsync(Guid id);
        Task<List<Deporte>> GetAllDeportesAsync();
    }
}
