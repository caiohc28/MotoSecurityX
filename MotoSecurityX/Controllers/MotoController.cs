using Microsoft.AspNetCore.Mvc;
using MotoSecurityX.Domain;
using MotoSecurityX.Repositories;

namespace MotoSecurityX.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly IMotoRepository _repository;

        public MotoController(IMotoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moto>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> GetById(int id)
        {
            var moto = await _repository.GetByIdAsync(id);
            return moto is null ? NotFound() : Ok(moto);
        }

        [HttpGet("placa/{placa}")]
        public async Task<ActionResult<Moto>> GetByPlaca(string placa)
        {
            var moto = await _repository.GetByPlacaAsync(placa);
            return moto is null ? NotFound() : Ok(moto);
        }


        [HttpGet("situacao/{situacao}")]
        public async Task<ActionResult<IEnumerable<Moto>>> GetBySituacao(string situacao)
            => Ok(await _repository.GetBySituacaoAsync(situacao));
        [HttpPost]
        public async Task<ActionResult<Moto>> Create(Moto moto)
        {
            var novaMoto = await _repository.CreateAsync(moto);
            return CreatedAtAction(nameof(GetById), new { id = novaMoto.Id }, novaMoto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Moto moto)
        {
            if (id != moto.Id)
                return BadRequest("ID inconsistente.");

            var atualizado = await _repository.UpdateAsync(moto);

            // Retorna o resultado apropriado
            return atualizado ? Ok(moto) : NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _repository.DeleteAsync(id);
            return removido ? NoContent() : NotFound();
        }
    }
}

