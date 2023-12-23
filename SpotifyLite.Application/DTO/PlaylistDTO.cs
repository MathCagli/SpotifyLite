using System.ComponentModel.DataAnnotations;

namespace SpotifyLite.Application.DTO
{
    public record PlaylistInputDto([Required(ErrorMessage = "Nome é obrigatório!")] string Nome, 
        [Required(ErrorMessage = "Descrição é obrigatória!")] string Descricao);
    public record PlaylistOutputDto(Guid Id, string Nome, string Descricao);
}
