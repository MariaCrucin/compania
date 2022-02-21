using API.Dtos.Receptie;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications.Receptii;
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
    public class ReceptiiController : ControllerBase
    {
        private readonly IReceptieService _receptieService;
        private readonly IMapper _mapper;

        public ReceptiiController(IReceptieService receptieService, IMapper mapper)
        {
            _receptieService = receptieService;
            _mapper = mapper;
        }

        // GET: api/<ReceptiiController>
        [HttpGet]
        public async Task<ActionResult<Pagination<ReceptieInListDto>>> GetReceptii([FromQuery] ReceptieSpecParams receptieParams)
        {
            var totalItems = await _receptieService.GetNumberOfReceptii(receptieParams);

            var receptii = await _receptieService.GetReceptii(receptieParams);
            var data = _mapper.Map<IReadOnlyList<ReceptieInListDto>>(receptii);

            return Ok(new Pagination<ReceptieInListDto>(receptieParams.PageIndex, receptieParams.PageSize, totalItems, data));
        }

        // GET: api/<ReceptiiController>/instoc
        [HttpGet, Route("InStoc")]
        public async Task<ActionResult<IReadOnlyList<ReceptieInStocDto>>> GetReceptiiInStoc([FromQuery] ReceptieSpecParams receptieParams) {
            var receptii = await _receptieService.GetReceptiiInStoc(receptieParams);
            
            return Ok(_mapper.Map<IReadOnlyList<ReceptieInStocDto>>(receptii));
        }


        // GET: api/<ReceptiiController>/nextnir
        [HttpGet, Route("NextNir")]
        public async Task<ActionResult<int>> GetNextNir()
        {
            var rece = await _receptieService.GetReceptieWithMaxNir();

            if (rece == null)
            {
                return Ok(1);
            }
            else {
                return Ok(rece.NrNir + 1);
            }
        }

        // GET api/<ReceptiiController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceptieToReturnDto>> GetReceptie(int id)
        {
            var receptie = await _receptieService.GetReceptie(id, "ReceptiiWithMaterialeAndFurnizorSpecification");

            if (receptie == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<ReceptieToReturnDto>(receptie);
        }

        // POST api/<ReceptiiController>
        [HttpPost]
        public async Task<ActionResult> CreateReceptie([FromBody] ReceptieToSaveDto receptieDto)
        {
            var receptieToSave = _mapper.Map<Receptie>(receptieDto);
            var receptie = await _receptieService.CreateReceptie(receptieToSave);
            if (receptie == null) return BadRequest(new ApiResponse(400, "Probleme la crearea receptiei !"));
            return NoContent();
        }

        // PUT api/<ReceptiiController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReceptie(int id, [FromBody] ReceptieToSaveDto receptieDto)
        {
            var receptie = await _receptieService.GetReceptie(id, "ReceptiiWithMaterialeSpecification");
            if (receptie == null) return BadRequest(new ApiResponse(400, "Datele trimise sunt invalide"));
            _mapper.Map(receptieDto, receptie);

            var result = await _receptieService.UpdateReceptie(receptie);
            if (result == null) return BadRequest(new ApiResponse(400, "Probleme la actualizarea magazinului"));

            return NoContent();
        }

        // DELETE api/<ReceptiiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var receptie = await _receptieService.DeleteReceptie(id);
            if (receptie == null) return BadRequest(new ApiResponse(400, "Probleme la stergerea receptiei !"));
            return NoContent();
        }
    }
}
