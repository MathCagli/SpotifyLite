using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Service
{
    public interface IPlanoService
    {
        Task<List<PlanoDTO>> ListarTodos();
    }
}