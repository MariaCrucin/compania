using API.Dtos.Magazin;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications.Magazine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagazineController : ControllerBase
    {
        private readonly IMagazinService _magazinService;
        private readonly IMapper _mapper;

        public MagazineController(IMagazinService magazinService, IMapper mapper)
        {
            _magazinService = magazinService;
            _mapper = mapper;
        }

        [HttpPost, Route("Import")]
        public async Task<ActionResult> ImportaComenziCadru([FromForm] FileForCCDto cc)
        {
            var result = await _magazinService.ImportaComenziCadruDinFisier(cc.File, cc.ClientId);

            if (result <= 0)
                return BadRequest(new ApiResponse(400, "Nu s-a efectuat importul din fisier !"));

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<MagazinToReturnDto>>> GetMagazine([FromQuery] MagazinSpecParams magazinParams)
        {
            var totalItems = await _magazinService.GetNumberOfMagazine(magazinParams);

            var magazine = await _magazinService.GetMagazine(magazinParams);
            var data = _mapper.Map<IReadOnlyList<MagazinToReturnDto>>(magazine);

            return Ok(new Pagination<MagazinToReturnDto>(magazinParams.PageIndex, magazinParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MagazinToReturnDto>> GetMagazinById(int id)
        {
            var magazin = await _magazinService.GetMagazin(id);

            if (magazin == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<MagazinToReturnDto>(magazin);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMagazin([FromBody] MagazinToSaveDto magazinDto)
        {
            var magazinToSave = _mapper.Map<Magazin>(magazinDto);
            var magazin = await _magazinService.CreateMagazin(magazinToSave);
            if (magazin == null) return BadRequest(new ApiResponse(400, "Probleme la crearea magazinului"));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMagazin(int id, [FromBody] MagazinToSaveDto magazinDto)
        {
            if (id < 1) return BadRequest(new ApiResponse(400, "Datele trimise sunt invalide"));

            var magazin = await _magazinService.GetMagazin(id);
            if (magazin == null) return BadRequest(new ApiResponse(400, "Datele trimise sunt invalide"));

            _mapper.Map(magazinDto, magazin);

            var result = await _magazinService.UpdateMagazin(magazin);

            if (result == null) return BadRequest(new ApiResponse(400, "Probleme la actualizarea magazinului"));

            return NoContent();
        }
    }
}
