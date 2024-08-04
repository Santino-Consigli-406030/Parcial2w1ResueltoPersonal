using AutoMapper;
using Microsoft.VisualBasic;
using secondParcial.DTOS;
using secondParcial.Repositories.Interfaces;
using secondParcial.Servicios.Interfaces;

namespace secondParcial.Servicios.Impl

{
    public class Servicio:IServicio
    {
        private readonly IDBRepositoryDeporte dBRepositoryDeporte;
        private readonly IDBRepositorySocio dBSocio;
        private readonly IMapper mapper;
        public Servicio(IDBRepositorySocio dBSocio,IDBRepositoryDeporte dBRepositoryDeporte, IMapper mapper)
        {
            this.dBSocio = dBSocio;
            this.dBRepositoryDeporte = dBRepositoryDeporte;
            this.mapper = mapper;
        }

        public async Task<List<SocioDTOResponse>> GetAllSocios()
        {
            var socios = await dBSocio.GetAllSociosAsync();
            var sociosResponse = mapper.Map<List<SocioDTOResponse>>(socios);
            return sociosResponse;
        }

        public async Task<SocioDTOResponse> GetSocioById(Guid id)
        {
                var socio = await dBSocio.GetByIdSocioAsync(id);
                var socioResponse =mapper.Map<SocioDTOResponse>(socio);
                return socioResponse;
        }
        public async Task<List<DeporteDTO>> GetAllDeportes()
        {
            var deportes = await dBRepositoryDeporte.GetAllDeportesAsync();
            var deportesResponse = mapper.Map<List<DeporteDTO>>(deportes);
            return deportesResponse;
        }

        public async Task<DeporteDTO> GetDeporteById(Guid id)
        {
            var deporte = await dBRepositoryDeporte.GetDeporteByIdAsync (id);
            var deporteResponse = mapper.Map<DeporteDTO>(deporte);
            return deporteResponse;
        }

        public async Task<SocioPostDTOResponse> CreateSocio(SocioPostDTORequest dTORequest)
        {
            var socio  = await dBSocio.CreateSocioAsync (dTORequest);
            var socioResponse = mapper.Map<SocioPostDTOResponse>(dTORequest);
            return socioResponse;
        }
    }
}
