using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Service
{
    public interface IPlaylistService
    {
        Task<PlaylistDTO> Criar(PlaylistDTO dto);
        Task<List<PlaylistDTO>> ListarTodos();
        Task<PlaylistDTO> BuscarPorID(string id);
        Task<PlaylistDTO> Atualizar(PlaylistDTO dto);
        Task<string> Remover(string id);
    }
}