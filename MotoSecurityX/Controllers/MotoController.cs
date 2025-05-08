using Microsoft.AspNetCore.Mvc;
using MotoSecurityX.Models;
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
            if (string.IsNullOrEmpty(moto.Placa) || string.IsNullOrEmpty(moto.Modelo) || string.IsNullOrEmpty(moto.Situacao))
            {
                return BadRequest("Todos os campos são obrigatórios.");
            }
            if (id != moto.Id)
            {
                return BadRequest("O ID informado não corresponde ao ID da moto.");
            }

            var existenteMoto = await _repository.GetByIdAsync(id);
            if (existenteMoto == null)
            {
                return NotFound("Moto não encontrada.");
            }
            var atualizado = await _repository.UpdateAsync(moto);
            return atualizado ? NoContent() : StatusCode(500, "Erro ao tentar atualizar a moto.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _repository.DeleteAsync(id);
            return removido ? NoContent() : NotFound();
        }
    }
}

