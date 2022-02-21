using API.Dtos.Pozitia;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications.Pozitii;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PozitiiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PozitiiController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // POST api/pozitii/range
        [HttpPost, Route("Range")]
        public async Task<ActionResult<IReadOnlyList<PozitiaToReturnDto>>> CreatePozitii([FromBody] IEnumerable<PozitiaToSaveDto> pozitiiDto)
        {
            var pozitii = _mapper.Map<IEnumerable<Pozitia>>(pozitiiDto);
            _unitOfWork.Repository<Pozitia>().AddRange(pozitii);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return BadRequest(new ApiResponse(400, "Probleme la salvarea pozitiilor!"));

            return Ok(_mapper.Map<IReadOnlyList<PozitiaToReturnDto>>(pozitii));
        }

        // POST api/pozitii/one
        [HttpPost, Route("One")]
        public async Task<ActionResult<PozitiaToReturnDto>> CreatePozitia([FromBody] PozitiaToSaveDto pozitiaDto)
        {
            var pozitia = _mapper.Map<Pozitia>(pozitiaDto);
            _unitOfWork.Repository<Pozitia>().Add(pozitia);
            var result = await _unitOfWork.Complete();
            if (result < 0) return BadRequest(new ApiResponse(400, "Probleme la crearea pozitiei!"));

            return Ok(_mapper.Map<PozitiaToReturnDto>(pozitia));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PozitiaToReturnDto>>> GetPozitii(int? clientId)
        {
            var spec = new PozitiiSpecification(clientId);
            var pozitii = await _unitOfWork.Repository<Pozitia>().ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<PozitiaToReturnDto>>(pozitii));

        }
    }
}
