using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpotifyLite.Application.DTO;
using SpotifyLite.Application.Handler.Command;
using SpotifyLite.Application.Handler.Query;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandaController : ControllerBase
    {
        private readonly IMediator mediator;

        public BandaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(BandaInputDto dto)
        {
            var result = await this.mediator.Send(new CriarBandaCommand(dto));
            return Created($"{result.Banda.Id}", result.Banda);
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            return Ok(await this.mediator.Send(new ListarTodasBandasQuery()));
        }

        [HttpGet("BuscarPorID/{id}")]
        public async Task<IActionResult> BuscarPorID(string id)
        {
            return Ok(await this.mediator.Send(new BuscarPorIDBandaQuery { Id = id }));
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> Atualizar(BandaOutputDto dto)
        {
            var result = await this.mediator.Send(new AtualizarBandaCommand(dto));
            return Ok(result);
        }

        [HttpDelete("Remover/{id}")]
        public async Task<IActionResult> Remover(string id)
        {
            return Ok(await this.mediator.Send(new RemoverBandaCommand { Id = id }));
        }
    }
}