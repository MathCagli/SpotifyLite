using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpotifyLite.Application.DTO;
using SpotifyLite.Application.Handler.Command;
using SpotifyLite.Application.Handler.Query;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator mediator;

        public AlbumController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(AlbumInputDto dto)
        {
            var result = await this.mediator.Send(new CriarAlbumCommand(dto));
            return Created($"{result.Album.Id}", result.Album);
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            return Ok(await this.mediator.Send(new ListarTodosAlbunsQuery()));
        }

        [HttpGet("BuscarPorID/{id}")]
        public async Task<IActionResult> BuscarPorID(string id)
        {
            return Ok(await this.mediator.Send(new BuscarPorIDAlbumQuery { Id = id }));
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> Atualizar(AlbumOutputDto dto)
        {
            var result = await this.mediator.Send(new AtualizarAlbumCommand(dto));
            return Ok(result);
        }

        [HttpDelete("Remover/{id}")]
        public async Task<IActionResult> Remover(string id)
        {
            return Ok(await this.mediator.Send(new RemoverAlbumCommand { Id = id }));
        }
    }
}