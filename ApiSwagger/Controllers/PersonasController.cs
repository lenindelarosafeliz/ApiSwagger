using Applications.Interfaces;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /Personas
        [HttpGet]
        public async Task<IEnumerable<Persona>> GetAsync()
        {
            IEnumerable<Persona> personas = await _unitOfWork.Personas.GetAllAsync();
            return personas;
        }

        // GET: /Personas
        [HttpGet("id")]
        public async Task<ActionResult<Persona>> GetAsync(int id)
        {
            Persona persona = await _unitOfWork.Personas.GetAsync(id);
            if (persona == null) return NotFound();
            return Ok(persona);
        }

        // POST: /Personas
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Persona persona)
        {
            return await _unitOfWork.Personas.AddAsync(persona);
        }

        // PUT: /Personas/5
        [HttpPut]
        public async Task<ActionResult<int>> Put(int id, [FromBody] Persona persona)
        {
            return await _unitOfWork.Personas.UpdateAsync(persona);
        }

        // PUT: /Personas/5
        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id, Persona persona)
        {
            return await _unitOfWork.Personas.DeleteAsync(persona);
        }
    }
}