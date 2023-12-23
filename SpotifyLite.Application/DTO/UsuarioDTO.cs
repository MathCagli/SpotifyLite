using System.ComponentModel.DataAnnotations;

namespace SpotifyLite.Application.DTO
{
    public record UsuarioInputDto(
        [Required(ErrorMessage = "Nome é obrigatório!")] string Nome, 
        [Required(ErrorMessage = "Data de nascimento é obrigatória!")] DateTime DataNascimento, 
        [Required(ErrorMessage = "Email é obrigatório!")] string Email, 
        [Required(ErrorMessage = "Senha é obrigatória!")] string Senha, 
        [Required(ErrorMessage = "Sexo é obrigatório!")] string Sexo, 
        List<PlaylistInputDto> Playlists
        );

    public record UsuarioOutputDto(
        Guid Id, 
        string Nome, 
        DateTime DataNascimento, 
        string Email, 
        string Senha, 
        string Sexo, 
        List<PlaylistOutputDto> Playlists
        );
}