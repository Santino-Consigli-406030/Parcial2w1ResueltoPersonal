using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using secondParcial.DTOS;
using secondParcial.Repositories;
using System.Net;

namespace secondParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Parcial : ControllerBase
    {
        private readonly IDBRepositoryClub _dbRepositoryClub;
        private readonly IMapper _mapper;
       public Parcial(IDBRepositoryClub repository ,IMapper mapper)
        {
            _dbRepositoryClub = repository;
            _mapper = mapper;
        }
        [HttpPost("postOne")]
        public async Task<IActionResult> CreateSocio([FromBody] SocioPostDTORequest dTORequest)
        {

            var response = await _dbRepositoryClub.CreateSocioAsync(dTORequest);
            if(response==null)
            {
                return Conflict(new { message = "El socio ya existe." });
            }

            return Ok(response);
        }
        [HttpGet("getByid")]
        public async Task<IActionResult> GetByIdSocio([FromHeader]Guid id)
        {

            var response = await _dbRepositoryClub.GetByIdSocioAsync(id);
           

            return Ok(response);
        }
       /* [HttpGet("getByidSocioBaloncesto/{id}")]
        public async Task<IActionResult> GetByIdSocioBaloncesto(Guid id)
        {

            var response = await _dbRepositoryClub.GetByIdSocioBaloncestoAsync( id);
            return Ok(response);
        }*/
        [HttpGet("getAllSocios")]
        public async Task<IActionResult> GetAllSocios()
        {

            var socios = await _dbRepositoryClub.GetAllSociosAsync();
            return Ok(socios);
        }
        [HttpGet("getAllDeportes")]
        public async Task<IActionResult> GetAllDeportes()
        {

            var response = await _dbRepositoryClub.GetAllDeportesAsync();

            return Ok(response);
        }
        [HttpGet("getDeporteById/{id}")]
        public async Task<IActionResult> GetDeporteById(Guid id )
        {

            var response = await _dbRepositoryClub.GetDeporteByIdAsync(id);

            return Ok(response);
        }


    }
}
