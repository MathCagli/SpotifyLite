using Microsoft.AspNetCore.Mvc;
using SpotifyLite.Application.DTO;
using SpotifyLite.Application.Service;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService service;

        public PlaylistController(IPlaylistService service)
        {
            this.service = service;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(PlaylistInputDto dto)
        {
            var result = await this.service.Criar(dto);
            return Created($"{result.Id}", result);
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            return Ok(await this.service.ListarTodos());
        }

        [HttpGet("BuscarPorID/{id}")]
        public async Task<IActionResult> BuscarPorID(string id)
        {
            return Ok(await this.service.BuscarPorID(id));
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> Atualizar(PlaylistOutputDto dto)
        {
            var result = await this.service.Atualizar(dto);
            return Ok(result);
        }

        [HttpDelete("Remover/{id}")]
        public async Task<IActionResult> Remover(string id)
        {
            return Ok(await this.service.Remover(id));
        }
    }
}