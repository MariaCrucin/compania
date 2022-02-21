using API.Dtos.Tarif;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications.Tarife;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciiController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ServiciiController>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ServiciuToReturnDto>>> GetServicii(string cod)
        {
            var spec = new ServiciiSpecification(cod);
            var servicii = await _unitOfWork.Repository<Serviciu>().ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<ServiciuToReturnDto>>(servicii));
        }

        // GET api/<ServiciiController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiciuToReturnDto>> GetServiciu(int id)
        {
            var serviciu = await _unitOfWork.Repository<Serviciu>().GetByIdAsync(id);

            if (serviciu == null)
                return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<ServiciuToReturnDto>(serviciu));
        }

        // POST api/<ServiciiController>
        [HttpPost]
        public async Task<ActionResult<ServiciuToSaveDto>> CreateServiciu ([FromBody] ServiciuToSaveDto serviciuDto)
        {
            var spec = new ServiciiSpecification(serviciuDto.Cod);
            var serviciuCuCod = _unitOfWork.Repository<Serviciu>().GetEntityWithSpec(spec);
            if (serviciuCuCod != null) return BadRequest(new ApiResponse(400, "Exista deja Cod-ul inregistrat !"));

            var serviciu = _mapper.Map<Serviciu>(serviciuDto);

            _unitOfWork.Repository<Serviciu>().Add(serviciu);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
                return BadRequest(new ApiResponse(400, "Probleme la salvarea serviciului!"));

            return Ok(_mapper.Map<ServiciuToReturnDto>(serviciu));
        }

        // PUT api/<ServiciiController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateServiciu(int id, [FromBody] ServiciuToSaveDto serviciuDto)
        {
            var serviciu = await _unitOfWork.Repository<Serviciu>().GetByIdAsync(id);
            if (serviciu == null)
                return BadRequest(new ApiResponse(400, "Datele trimise sunt invalide!"));
            _mapper.Map(serviciuDto, serviciu);

            var result = await _unitOfWork.Complete();
            if (result <= 0)
                return BadRequest(new ApiResponse(400, "Probleme la salvarea serviciului!"));

            return NoContent();
        }

        // DELETE api/<ServiciiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
