using secondParcial.DTOS;
using secondParcial.Model;

namespace secondParcial.Servicios.Interfaces
{
    public interface IServicio
    {
        Task<SocioPostDTOResponse> CreateSocio(SocioPostDTORequest dTORequest);
        Task<List<SocioDTOResponse>> GetAllSocios();
        Task<SocioDTOResponse> GetSocioById(Guid id);
        Task<DeporteDTO> GetDeporteById(Guid id);
        Task<List<DeporteDTO>> GetAllDeportes();
    }
}
