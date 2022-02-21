using API.Dtos.UnitateDeMasura;
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
    public class UnitatiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UnitatiController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<UnitatiController>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UnitateDeMasuraToReturnDto>>> GetUnitati()
        {
            var unitati = await _unitOfWork.Repository<UnitateDeMasura>().ListAllAsync();
            return Ok(_mapper.Map<IReadOnlyList<UnitateDeMasuraToReturnDto>>(unitati));
        }

        // GET api/<UnitatiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UnitatiController>
        [HttpPost]
        public async Task<ActionResult<UnitateDeMasuraToReturnDto>> CreateUnitate([FromBody] UnitateDeMasuraToSaveDto unitateDto)
        {
            var unitate = _mapper.Map<UnitateDeMasura>(unitateDto);
            _unitOfWork.Repository<UnitateDeMasura>().Add(unitate);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return BadRequest(new ApiResponse(400, "Probleme la crearea unitatii de masaura!"));

            return Ok(_mapper.Map<UnitateDeMasuraToReturnDto>(unitate));
        }

        // PUT api/<UnitatiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UnitatiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
