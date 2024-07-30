using secondParcial.DTOS;
using secondParcial.Model;

namespace secondParcial.Repositories.Interfaces
{
    public interface IServicio
    {
        Task<Deporte> GetDeporteByIdAsync(Guid id);
        Task<List<Deporte>> GetAllDeportesAsync();
        Task<SocioPostDTOResponse> CreateSocioAsync(SocioPostDTORequest dTORequest);
        Task<List<SocioDTOResponse>> GetAllSociosAsync();
        Task<SocioDTOResponse> GetByIdSocioAsync(Guid id);
        
    }
}
