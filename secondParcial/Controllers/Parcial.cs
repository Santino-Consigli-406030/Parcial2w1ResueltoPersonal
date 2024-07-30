using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using secondParcial.DTOS;
using secondParcial.Repositories.Interfaces;
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

            var response = await _servicio.CreateSocioAsync(dTORequest);
            if(response==null)
            {
                return Conflict(new { message = "El socio ya existe." });
            }

            return Ok(response);
        }
        [HttpGet("getByid")]
        public async Task<IActionResult> GetByIdSocio([FromHeader]Guid id)
        {

            var response = await _servicio.GetByIdSocioAsync(id);
           

            return Ok(response);
        }
 
        [HttpGet("getAllSocios")]
        public async Task<IActionResult> GetAllSocios()
        {

            var socios = await _servicio.GetAllSociosAsync();
            return Ok(socios);
        }
        [HttpGet("getAllDeportes")]
        public async Task<IActionResult> GetAllDeportes()
        {

            var response = await _servicio.GetAllDeportesAsync();

            return Ok(response);
        }
        [HttpGet("getDeporteById/{id}")]
        public async Task<IActionResult> GetDeporteById(Guid id )
        {

            var response = await _servicio.GetDeporteByIdAsync(id);

            return Ok(response);
        }


    }
}
