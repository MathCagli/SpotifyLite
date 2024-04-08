using SpotifyLite.Application.DTO;
using SpotifyLite.Domain.Models.Conta.Agreggates;
using SpotifyLite.Domain.Models.Streaming.Agreggates;

namespace SpotifyLite.Application.Service
{
    public interface IBandaService
    {
        BandaDTO Criar(BandaDTO dto);

        BandaDTO Obter(Guid id);

        IEnumerable<BandaDTO> Obter();

        AlbumDTO AssociarAlbum(AlbumDTO dto);
        AlbumDTO ObterAlbumPorId(Guid idBanda, Guid id);
        List<AlbumDTO> ObterAlbum(Guid idBanda);

        List<MusicaPlaylistDTO> ListarMusicas(Guid idUsuario, Guid idAlbum);
    }
}
