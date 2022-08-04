using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpotifyLite.Application.DTO;
using SpotifyLite.Application.Handler.Command;
using SpotifyLite.Application.Handler.Query;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IMediator mediator;

        public PlaylistController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(PlaylistInputDto dto)
        {
            var result = await this.mediator.Send(new CriarPlaylistCommand(dto));
            return Created($"{result.Playlist.Id}", result.Playlist);
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            return Ok(await this.mediator.Send(new ListarTodasPlaylistsQuery()));
        }

        [HttpGet("BuscarPorID/{id}")]
        public async Task<IActionResult> BuscarPorID(string id)
        {
            return Ok(await this.mediator.Send(new BuscarPorIDPlaylistQuery { Id = id }));
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> Atualizar(PlaylistOutputDto dto)
        {
            var result = await this.mediator.Send(new AtualizarPlaylistCommand(dto));
            return Ok(result);
        }

        [HttpDelete("Remover/{id}")]
        public async Task<IActionResult> Remover(string id)
        {
            return Ok(await this.mediator.Send(new RemoverPlaylistCommand { Id = id }));
        }
    }
}