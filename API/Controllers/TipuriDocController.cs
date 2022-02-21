using API.Dtos.TipDoc;
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
    public class TipuriDocController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TipuriDocController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<TipuriDocController>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TipDocToReturnDto>>> GetTipuriDoc()
        {
            var tipuri = await _unitOfWork.Repository<TipDocument>().ListAllAsync();
            return Ok(_mapper.Map<IReadOnlyList<TipDocToReturnDto>>(tipuri));
        }

        // GET api/<TipuriDocController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TipuriDocController>
        [HttpPost]
        public async Task<ActionResult<TipDocToReturnDto>> CreateTipDoc([FromBody] TipDocToSaveDto tipDocDto)
        {
            var tipDoc = _mapper.Map<TipDocument>(tipDocDto);
            _unitOfWork.Repository<TipDocument>().Add(tipDoc);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return BadRequest(new ApiResponse(400, "Probleme la salvarea tipului de document !"));
            return Ok(_mapper.Map<TipDocToReturnDto>(tipDoc));
        }

        // PUT api/<TipuriDocController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TipuriDocController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
