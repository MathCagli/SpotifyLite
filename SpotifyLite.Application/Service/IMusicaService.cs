using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Service
{
    public interface IMusicaService
    {
        Task<MusicaOutputDto> Criar(MusicaInputDto dto);
        Task<List<MusicaOutputDto>> ListarTodos();
        Task<MusicaOutputDto> BuscarPorID(string id);
        Task<MusicaOutputDto> Atualizar(MusicaOutputDto dto);
        Task<string> Remover(string id);
    }
}