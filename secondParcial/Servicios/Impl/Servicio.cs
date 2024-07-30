using AutoMapper;
using secondParcial.DTOS;
using secondParcial.Model;
using secondParcial.Repositories.Interfaces;
using secondParcial.Servicios.Interfaces;

namespace secondParcial.Servicios.Impl
{
    public class Servicio:IServicio
    {
        private readonly IDBRepositoryDeporte dBRepositoryDeporte;
        private readonly IDBRepositorySocio dBSocio;
        private readonly IMapper mapper;
        public Servicio(IDBRepositorySocio dBSocio,IDBRepositoryDeporte dBRepositoryDeporte IMapper mapper)
        {
            this.dBSocio = dBSocio;
            this.dBRepositoryDeporte = dBRepositoryDeporte;
            this.mapper = mapper;
        }

        public Task<SocioPostDTOResponse> CreateSocioAsync(SocioPostDTORequest dTORequest)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DeporteDTO>> GetAllDeportesAsync()
        {
            var deportes =  await dBRepositoryDeporte.GetAllDeportesAsync();
            var deportesResponse = mapper.Map<List<DeporteDTO>> (deportes);
            return deportesResponse;
        }

        public Task<List<SocioDTOResponse>> GetAllSociosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SocioDTOResponse> GetByIdSocioAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<DeporteDTO> GetDeporteByIdAsync(Guid id)
        {
            var deporte = await dBRepositoryDeporte.GetDeporteByIdAsync (id);
            var deporteResponse = mapper.Map<DeporteDTO>(deporte);
            return deporteResponse;
        }
    }
}
