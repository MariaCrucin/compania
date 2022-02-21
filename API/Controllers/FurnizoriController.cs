using API.Dtos.Furnizor;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications.Furnizori;
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
    public class FurnizoriController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FurnizoriController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<FurnizoriController>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<FurnizorToReturnDto>>> GetFurnizori([FromQuery] FurnizoriSpecParams furnizoriParams)
        {
            var spec = new FurnizoriSpecification(furnizoriParams);
            var furnizori = await _unitOfWork.Repository<Furnizor>().ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<FurnizorToReturnDto>>(furnizori));
        }

        // GET: api/<FurnizoriController>/instoc
        [HttpGet, Route("InStoc")]
        public async Task<ActionResult<IReadOnlyList<FurnizoriWithStocSpecification>>> GetFurnizoriWithStoc([FromQuery] FurnizoriSpecParams furnizorParams)
        {
            var spec = new FurnizoriWithStocSpecification(furnizorParams);
            var furnizori = await _unitOfWork.Repository<Furnizor>().ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<FurnizorWithStoc>>(furnizori));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FurnizorToReturnDto>> GetFurnizorById(int id) {
            var furnizor = await _unitOfWork.Repository<Furnizor>().GetByIdAsync(id);
            if (furnizor == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<FurnizorToReturnDto>(furnizor);
        }

        // POST api/<FurnizoriController>
        [HttpPost]
        public async Task<ActionResult<FurnizorToReturnDto>> CreateFurnizor([FromBody] FurnizorToSaveDto furnizorDto)
        {
            var spec = new FurnizoriSpecification(furnizorDto.NrCif);
            var furnizorCuCif = await _unitOfWork.Repository<Furnizor>().GetEntityWithSpec(spec);
            if (furnizorCuCif != null) return BadRequest(new ApiResponse(400, "Exista deja CIF-ul inregistrat la FURNIZORI !"));

            var furnizor = _mapper.Map<Furnizor>(furnizorDto);
            _unitOfWork.Repository<Furnizor>().Add(furnizor);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return BadRequest(new ApiResponse(400, "Probleme la crearea furnizorului !"));

            return Ok(_mapper.Map<FurnizorToReturnDto>(furnizor));
        }

        // PUT api/<FurnizoriController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FurnizoriController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
