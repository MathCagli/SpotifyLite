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
        private readonly IBandaService service;

        public BandaController(IBandaService service)
        {
            this.service = service;
        }

        [HttpGet("ListarTodos")]
        public IActionResult GetBandas()
        {
            var result = this.service.Obter();

            return Ok(result);
        }

        [HttpGet("ObterPorId/{id}")]
        public IActionResult GetBandas(Guid id)
        {
            var result = this.service.Obter(id);

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

            var result = this.service.Criar(dto);

            return Created($"/banda/{result.Id}", result);
        }

        [HttpPost("AssociarAlbum/{id}/albums")]
        public IActionResult AssociarAlbum(AlbumDTO dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this.service.AssociarAlbum(dto);

            return Created($"/banda/{result.BandaId}/albums/{result.Id}", result);

        }

        [HttpGet("ObterAlbumPorId/{idBanda}/albums/{id}")]
        public IActionResult ObterAlbumPorId(Guid idBanda, Guid id)
        {
            var result = this.service.ObterAlbumPorId(idBanda, id);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpGet("ListarAlbuns/{idBanda}/albums")]
        public IActionResult ObterAlbuns(Guid idBanda)
        {
            var result = this.service.ObterAlbum(idBanda);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpGet("ListarMusicas/{idUsuario}/albums/{idAlbum}")]
        public IActionResult ListarMusicas(String idUsuario, String idAlbum)
        {
            
            var result = this.service.ListarMusicas(new Guid(idUsuario), new Guid(idAlbum));

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        // Tabela MusicaPlaylist não há Mapeamento
        // Como Posso Criar um Favorito?
        //[HttpPost("FavoritarDesfavoritarMusica/{idMusica}/albums/{idPlaylist}")]
        //public IActionResult FavoritarDesfavoritarMusica(String idMusica, String idPlaylist)
        //{

        //    var result = this.service.FavoritarDesfavoritarMusica(new Guid(idMusica), new Guid(idPlaylist));

        //    if (result == null)
        //        return NotFound();

        //    return Ok(result);

        //}
    }
}
