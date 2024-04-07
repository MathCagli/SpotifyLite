using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyLite.Application.DTO;
using SpotifyLite.Application.Service;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandaController : ControllerBase
    {
        private BandaService _bandaService;

        public BandaController(BandaService bandaService)
        {
            _bandaService = bandaService;
        }

        [HttpGet("ListarTodos")]
        public IActionResult GetBandas()
        {
            var result = this._bandaService.Obter();

            return Ok(result);
        }

        
        [HttpGet("ObterPorId/{id}")]
        public IActionResult GetBandas(Guid id)
        {
            var result = this._bandaService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("Criar")]
        public IActionResult Criar([FromBody] BandaDTO dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._bandaService.Criar(dto);

            return Created($"/banda/{result.Id}", result);
        }

        [HttpPost("AssociarAlbum/{id}/albums")]
        public IActionResult AssociarAlbum(AlbumDTO dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._bandaService.AssociarAlbum(dto);

            return Created($"/banda/{result.BandaId}/albums/{result.Id}", result);

        }

        [HttpGet("ObterAlbumPorId/{idBanda}/albums/{id}")]
        public IActionResult ObterAlbumPorId(Guid idBanda, Guid id)
        {
            var result = this._bandaService.ObterAlbumPorId(idBanda, id);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpGet("ListarAlbuns/{idBanda}/albums")]
        public IActionResult ObterAlbuns(Guid idBanda)
        {
            var result = this._bandaService.ObterAlbum(idBanda);

            if (result == null)
                return NotFound();

            return Ok(result);

        }
    }
}
