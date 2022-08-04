using System.ComponentModel.DataAnnotations;

namespace SpotifyLite.Application.DTO
{
    public record MusicaInputDto([Required(ErrorMessage = "Nome é obrigatório!")] string Nome, 
        [Required(ErrorMessage = "Duração é obrigatório!")] int Duracao, 
        int Nota, int QtdVotos);
    public record MusicaOutputDto(Guid Id, string Nome, string Duracao, int Nota, int QtdVotos);
}