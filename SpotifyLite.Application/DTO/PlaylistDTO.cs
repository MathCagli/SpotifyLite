using System.ComponentModel.DataAnnotations;

namespace SpotifyLite.Application.DTO
{
    public record PlaylistInputDto([Required(ErrorMessage = "Nome é obrigatório!")] string Nome, 
        [Required(ErrorMessage = "Descrição é obrigatória!")] string Descricao, 
        [Required(ErrorMessage = "Foto é obrigatória!")] string Foto, 
        List<MusicaInputDto> Musicas);
    public record PlaylistOutputDto(Guid Id, string Nome, string Descricao, string Foto, List<MusicaOutputDto> Musicas);
}
