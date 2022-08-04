using System.ComponentModel.DataAnnotations;

namespace SpotifyLite.Application.DTO
{
    public record AlbumInputDto(
        [Required(ErrorMessage = "Nome é obrigatório!")] string Nome, 
        [Required(ErrorMessage = "Descrição é obrigatória!")] string Descricao, 
        [Required(ErrorMessage = "Data do lançamento é obrigatória!")] DateTime DataLancamento, 
        [Required(ErrorMessage = "Capa é obrigatória!")] string Capa, 
        List<MusicaInputDto> Musicas);
    public record AlbumOutputDto(Guid Id, string Nome, string Descricao, DateTime DataLancamento, string Capa, List<MusicaOutputDto> Musicas);
}