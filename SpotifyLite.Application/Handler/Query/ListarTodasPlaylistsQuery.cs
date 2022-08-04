using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Query
{
    public class ListarTodasPlaylistsQuery : IRequest<ListarTodasPlaylistsQueryResponse>
    {
    }

    public class ListarTodasPlaylistsQueryResponse
    {
        public IList<PlaylistOutputDto> Playlists { get; set; }

        public ListarTodasPlaylistsQueryResponse(IList<PlaylistOutputDto> playlists)
        {
            Playlists = playlists;
        }
    }
}
