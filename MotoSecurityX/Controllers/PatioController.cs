using System.IO;
using Microsoft.AspNetCore.Mvc;
using MotoSecurityX.Domain;
using MotoSecurityX.Repositories;

namespace MotoSecurityX.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatioController : ControllerBase
    {
        private readonly IPatioRepository _repository;

        public PatioController(IPatioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patio>>> GetAll()
            => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Patio>> GetById(int id)
        {
            var patio = await _repository.GetByIdAsync(id);
            return patio == null ? NotFound() : Ok(patio);
        }

        [HttpPost]
        public async Task<ActionResult<Patio>> Create(Patio patio)
        {
            if (string.IsNullOrWhiteSpace(patio.Nome_local))
                return BadRequest("Nome é obrigatório.");

            var novo = await _repository.CreateAsync(patio);
            return CreatedAtAction(nameof(GetById), new { id = novo.Id }, novo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Patio patio)
        {
            if (id != patio.Id)
                return BadRequest("ID inconsistente.");

            var atualizado = await _repository.UpdateAsync(patio);
            return atualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _repository.DeleteAsync(id);
            return removido ? NoContent() : NotFound();
        }
    }
}
