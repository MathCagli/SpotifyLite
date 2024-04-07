using Microsoft.AspNetCore.Mvc;
using SpotifyLite.Application.Service;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoController : ControllerBase
    {
        private readonly IPlanoService service;

        public PlanoController(IPlanoService service)
        {
            this.service = service;
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            return Ok(await this.service.ListarTodos());
        }
    }
}