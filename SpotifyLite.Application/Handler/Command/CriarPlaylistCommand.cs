using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Command
{
    public class CriarPlaylistCommand : IRequest<CriarPlaylistCommandResponse>
    {
        public PlaylistInputDto Playlist { get; set; }
        public Guid IdBanda { get; set; }

        public CriarPlaylistCommand(PlaylistInputDto playlist)
        {
            Playlist = playlist;
        }
    }

    public class CriarPlaylistCommandResponse
    {
        public PlaylistOutputDto Playlist { get; set; }

        public CriarPlaylistCommandResponse(PlaylistOutputDto playlist)
        {
            Playlist = playlist;
        }
    }
}
