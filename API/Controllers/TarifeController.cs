using API.Dtos.Tarif;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
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
    public class TarifeController : ControllerBase
    {
        private readonly ITarifService _tarifService;
        private readonly IMapper _mapper;

        public TarifeController(ITarifService tarifService, IMapper mapper)
        {
            _tarifService = tarifService;
            _mapper = mapper;
        }

        // GET: api/<TarifeController>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TarifToReturnDto>>> GetTarife(int? clientId, string cod)
        {
            var tarife = await _tarifService.GetTarife(clientId, cod);
            return Ok(_mapper.Map<IReadOnlyList<TarifToReturnDto>>(tarife));
        }

        // GET api/<TarifeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarifToReturnDto>> GetTarif(int id)
        {
            var tarif = await _tarifService.GetTarif(id);

            if (tarif == null) return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<TarifToReturnDto>(tarif));

        }

        // POST api/<TarifeController>
        [HttpPost]
        public async Task<ActionResult> CreateTarif ([FromBody] TarifToSaveDto tarifDto)
        {
            var tarifToSave = _mapper.Map<Tarif>(tarifDto);
            var tarif = await _tarifService.CreateTarif(tarifToSave);
            if (tarif == null) return BadRequest(new ApiResponse(400, "Probleme la crearea tarifului !"));
            return NoContent();
        }

        // PUT api/<TarifeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTarif (int id, [FromBody] TarifToSaveDto tarifDto)
        {
            var tarif = await _tarifService.GetTarif(id);
            if (tarif == null)
                return BadRequest(new ApiResponse(400, "Datele trimise sunt invalide!"));
            _mapper.Map(tarifDto, tarif);

            var result = await _tarifService.UpdateTarif(tarif);

            if (result == null) return BadRequest(new ApiResponse(400, "Probleme la actualizarea magazinului"));

            return NoContent();
        }


        // DELETE api/<TarifeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
