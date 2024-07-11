using AutoMapper;
using secondParcial.DTOS;
using secondParcial.Model;

namespace secondParcial
{
    public class MapConfig:Profile
    {
        public MapConfig() {
            CreateMap<SocioPostDTORequest, Socio>();
            CreateMap<SocioPostDTORequest, SocioPostDTOResponse>();
            CreateMap<Deporte, SocioDTOResponse>();
            CreateMap<SocioPostDTORequest, Socio>();
            CreateMap<Socio,SocioDTOResponse>()
              .ForMember(dest => dest.DeporteDTO, opt => opt.MapFrom(src => new DeporteDTO
              {
                  Id = src.IdDeporteNavigation.Id,
                  Nombre = src.IdDeporteNavigation.Nombre,
                  Descripcion = src.IdDeporteNavigation.Descripcion,
                  FechaAlta = src.IdDeporteNavigation.FechaAlta
              }));
            CreateMap<Deporte, DeporteDTO>();

        }
    }
}
