using secondParcial.DTOS;
using secondParcial.Model;

namespace secondParcial.Servicios.Interfaces
{
    public interface IServicio
    {
        Task<DeporteDTO> GetDeporteByIdAsync(Guid id);
        Task<List<DeporteDTO>> GetAllDeportesAsync();
    }
}
