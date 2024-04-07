using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> Criar(UsuarioDTO dto);
        Task<List<UsuarioDTO>> ListarTodos();
        Task<UsuarioDTO> BuscarPorID(string id);
        Task<UsuarioDTO> Atualizar(UsuarioDTO dto);
        Task<string> Remover(string id);
        UsuarioDTO Autenticar(string email, string senha);
    }
}