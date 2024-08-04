using secondParcial.DTOS;
using secondParcial.Model;

namespace secondParcial.Repositories.Interfaces
{
    public interface IDBRepositorySocio
    {
        Task<SocioPostDTOResponse> CreateSocioAsync(SocioPostDTORequest dTORequest);
        Task<List<SocioDTOResponse>> GetAllSociosAsync();
        Task<SocioDTOResponse> GetByIdSocioAsync(Guid id);
        
    }
}
