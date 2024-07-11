using secondParcial.DTOS;
using secondParcial.Model;

namespace secondParcial.Repositories
{
    public interface IDBRepositoryClub
    {
        Task<SocioPostDTOResponse> CreateSocioAsync(SocioPostDTORequest dTORequest);
        Task<List<SocioDTOResponse>> GetAllSociosAsync();
        Task<SocioDTOResponse> GetByIdSocioAsync(Guid id);
        Task<Deporte> GetDeporteByIdAsync(Guid id);
        Task<List<Deporte>> GetAllDeportesAsync();
    }
}
