using API.Dtos.Firma;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications.Firme;
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
    public class FirmeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FirmeController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<FirmeController>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<FirmaToReturnDto>>> GetFirme()
        {
            var firme = await _unitOfWork.Repository<Firma>().ListAllAsync();
            return Ok(_mapper.Map<IReadOnlyList<FirmaToReturnDto>>(firme));
        }

        // GET api/<FirmeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FirmaToReturnDto>> GetFirmaById(int id)
        {
            var firma = await _unitOfWork.Repository<Firma>().GetByIdAsync(id);

            if (firma == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<FirmaToReturnDto>(firma);
        }

        // POST api/<FirmeController>
        [HttpPost]
        public async Task<ActionResult<FirmaToReturnDto>> CreateFirma ([FromBody] FirmaToSaveDto firmaDto)
        {
            var spec = new FirmeSpecification(firmaDto.NrCif);
            var firmaCuCif = await _unitOfWork.Repository<Firma>().GetEntityWithSpec(spec);
            if (firmaCuCif != null) return BadRequest(new ApiResponse(400, "Exista deja CIF-ul inregistrat !"));

            var firma = _mapper.Map<Firma>(firmaDto);
            _unitOfWork.Repository<Firma>().Add(firma);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return BadRequest(new ApiResponse(400, "Probleme la salvarea firmei!"));

            return Ok(_mapper.Map<FirmaToReturnDto>(firma));
        }

        // PUT api/<FirmeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FirmeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
