using API.Dtos.Client;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications.Clienti;
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
    public class ClientiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClientiController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ClientiController>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ClientToChooseDto>>> GetClienti(int? firmaId, string beginDen)
        {
            Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Debug.WriteLine(beginDen);
            Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            var spec = new ClientiSpecification(firmaId, beginDen);
            var clienti = await _unitOfWork.Repository<Client>().ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<ClientToChooseDto>>(clienti));
        }

        // GET api/<ClientiController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientToReturnDto>> GetClient(int id)
        {
            var client = await _unitOfWork.Repository<Client>().GetByIdAsync(id);

            if (client == null)
                return NotFound(new ApiResponse(404));

            return _mapper.Map<ClientToReturnDto>(client);
        }

        // POST api/<ClientiController>
        [HttpPost]
        public async Task<ActionResult<ClientToReturnDto>> CreateClient ([FromBody] ClientToSaveDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            _unitOfWork.Repository<Client>().Add(client);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return BadRequest(new ApiResponse(400, "Probleme la salvarea clientului!"));

            return Ok(_mapper.Map<ClientToReturnDto>(client));
        }

        // PUT api/<ClientiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
