using AutoMapper;
using Microsoft.EntityFrameworkCore;
using secondParcial.Contexto;
using secondParcial.DTOS;
using secondParcial.Model;
using secondParcial.Repositories.Interfaces;

namespace secondParcial.Repositories.Impl
{
    public class DBRepositorySocio : IServicio
    {
        public readonly ClubContext _clubContext;
        private readonly IMapper _mapper;

        public DBRepositorySocio(ClubContext clubContext, IMapper mapper)
        {
            _clubContext = clubContext;
            _mapper = mapper;
        }
        public async Task<SocioPostDTOResponse> CreateSocioAsync(SocioPostDTORequest dTORequest)
        {
            //el id de socio (guid) no es identity, obliga a insertar un nuevo gui desde el back

            var socioExist = await _clubContext.Socios.FirstOrDefaultAsync(s => s.Dni == dTORequest.Dni);
            if (socioExist != null)
            {
                return null;
            }
            else
            {
                var socioEntity = _mapper.Map<Socio>(dTORequest);
                socioEntity.Id = Guid.NewGuid();
                socioEntity.Activo = true;
                _clubContext.Socios.Add(socioEntity);
                await _clubContext.SaveChangesAsync();
                var socioResponse = _mapper.Map<SocioPostDTOResponse>(dTORequest);
                socioResponse.Id = socioEntity.Id;
                return socioResponse;
            }

        }

        public async Task<List<SocioDTOResponse>> GetAllSociosAsync()
        {
            var socios = await _clubContext.Socios
           .Include(socios => socios.IdDeporteNavigation)
           .Where(s => s.Activo).ToListAsync();

            var sociosResponse = _mapper.Map<List<SocioDTOResponse>>(socios);

            return sociosResponse;
        }
       

        public async Task<SocioDTOResponse> GetByIdSocioAsync(Guid id)
        {
            var socio = await _clubContext.Socios
                .Include(socio => socio.IdDeporteNavigation).FirstOrDefaultAsync(s => s.Id == id);
            if (socio == null || !socio.Activo)
            {
                return null;
            }
            var socioResponse = _mapper.Map<SocioDTOResponse>(socio);

            return socioResponse;
        }
        public async Task<List<Deporte>> GetAllDeportesAsync()
        {
            var deportes = await _clubContext.Deportes.ToListAsync();
            return deportes;
        }

    }
}
