using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using secondParcial.DTOS;
using secondParcial.Repositories.Interfaces;
using secondParcial.Servicios.Interfaces;
using System.Net;

namespace secondParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Parcial : ControllerBase
    {
        private readonly IServicio _servicio;
        private readonly IMapper _mapper;
       public Parcial(IServicio repository ,IMapper mapper)
        {
            _servicio = repository;
            _mapper = mapper;
        }
        [HttpPost("postOne")]
        public async Task<IActionResult> CreateSocio([FromBody] SocioPostDTORequest dTORequest)
        {

            var response = await _servicio.CreateSocio(dTORequest);
            if(response==null)
            {
                return Conflict(new { message = "El socio ya existe." });
            }

            return Ok(response);
        }
        [HttpGet("getByid")]
        public async Task<IActionResult> GetByIdSocio([FromHeader]Guid id)
        {

            var response = await _servicio.GetSocioById(id);
           

            return Ok(response);
        }
 
        [HttpGet("getAllSocios")]
        public async Task<IActionResult> GetAllSocios()
        {

            var socios = await _servicio.GetAllSocios();
            return Ok(socios);
        }
        [HttpGet("getAllDeportes")]
        public async Task<IActionResult> GetAllDeportes()
        {

            var response = await _servicio.GetAllDeportes();

            return Ok(response);
        }
        [HttpGet("getDeporteById/{id}")]
        public async Task<IActionResult> GetDeporteById(Guid id )
        {
            var response = await _servicio.GetDeporteById(id);
            return Ok(response);
        }


    }
}
