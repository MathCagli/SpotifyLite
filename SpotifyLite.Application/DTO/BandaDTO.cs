using System.ComponentModel.DataAnnotations;

namespace SpotifyLite.Application.DTO
{
    public record BandaInputDto([Required(ErrorMessage = "Nome é obrigatório!")] string Nome, 
        [Required(ErrorMessage = "Descrição é obrigatória!")] string Descricao, 
        [Required(ErrorMessage = "Foto é obrigatória!")] string Foto);
    public record BandaOutputDto(Guid Id, string Nome, string Descricao, string Foto);
}