using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Command
{
    public class AtualizarPlaylistCommand : IRequest<AtualizarPlaylistCommandResponse>
    {
        public PlaylistOutputDto Playlist { get; set; }
        public Guid IdBanda { get; set; }

        public AtualizarPlaylistCommand(PlaylistOutputDto playlist)
        {
            Playlist = playlist;
        }
    }

    public class AtualizarPlaylistCommandResponse
    {
        public PlaylistOutputDto Playlist { get; set; }

        public AtualizarPlaylistCommandResponse(PlaylistOutputDto playlist)
        {
            Playlist = playlist;
        }
    }
}
