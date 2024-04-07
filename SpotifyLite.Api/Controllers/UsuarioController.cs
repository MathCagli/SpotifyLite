using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using SpotifyLite.Application.DTO;
using SpotifyLite.Application.Service;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService service;

        public UsuarioController(IUsuarioService service)
        {
            this.service = service;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(UsuarioDTO dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

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
        public async Task<IActionResult> Atualizar(UsuarioDTO dto)
        {
            var result = await this.service.Atualizar(dto);
            return Ok(result);
        }

        [HttpDelete("Remover/{id}")]
        public async Task<IActionResult> Remover(string id)
        {
            return Ok(await this.service.Remover(id));
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var result = this.service.Autenticar(login.Email, login.Senha);

            if (result == null)
            {
                return BadRequest(new
                {
                    Error = "email ou senha inválidos"
                });
            }

            return Ok(result);

        }

    }
}