using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Query
{
    public class BuscarPorIDPlaylistQuery : IRequest<BuscarPorIDPlaylistQueryResponse>
    {
        public string Id { get; set; }
    }

    public class BuscarPorIDPlaylistQueryResponse
    {
        public PlaylistOutputDto Playlist { get; set; }

        public BuscarPorIDPlaylistQueryResponse(PlaylistOutputDto playlist)
        {
            Playlist = playlist;
        }
    }
}
