using SpotifyLite.Application.DTO;

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
    }
}
