using API.Dtos.Lucrare;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications.Lucrari;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordonatoriController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CoordonatoriController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<CoordonatoriController>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CoordonatorToReturnDto>>> GetCoordonatori(int? clientId)
        {
            var spec = new CoordonatoriSpecification(clientId);
            var coordonatori = await _unitOfWork.Repository<Coordonator>().ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<CoordonatorToReturnDto>>(coordonatori));
        }

        // GET api/<CoordonatoriController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoordonatorToReturnDto>> GetCoordonator(int id)
        {
            var coordonator = await _unitOfWork.Repository<Coordonator>().GetByIdAsync(id);

            if (coordonator == null)
                return NotFound(new ApiResponse(404));

            return _mapper.Map<CoordonatorToReturnDto>(coordonator);
        }

        // POST api/<CoordonatoriController>
        [HttpPost]
        public async Task<ActionResult<CoordonatorToReturnDto>> CreateCoordonator ([FromBody] CoordonatorToSaveDto coordonatorDto)
        {
            var coordonator = _mapper.Map<Coordonator>(coordonatorDto);
            _unitOfWork.Repository<Coordonator>().Add(coordonator);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
                return BadRequest(new ApiResponse(400, "Probleme la salvarea coordonatorului!"));

            return Ok(_mapper.Map<CoordonatorToReturnDto>(coordonator));
        }

        // POST api/coordonatori/range
        [HttpPost, Route("Range")]
        public async Task<ActionResult<IReadOnlyList<CoordonatorToReturnDto>>> CreateCoordonatori([FromBody] IEnumerable<CoordonatorToSaveDto> coordonatoriDto)
        {
            var coordonatori = _mapper.Map<IEnumerable<Coordonator>>(coordonatoriDto);
            _unitOfWork.Repository<Coordonator>().AddRange(coordonatori);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return BadRequest(new ApiResponse(400, "Probleme la salvarea coordonatorilor!"));

            return Ok(_mapper.Map<IReadOnlyList<CoordonatorToReturnDto>>(coordonatori));
        }

        // PUT api/<CoordonatoriController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CoordonatoriController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
