using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Command
{
    public class RemoverPlaylistCommand : IRequest<RemoverPlaylistCommandResponse>
    {
        public string Id { get; set; }
    }

    public class RemoverPlaylistCommandResponse
    {
        public string Id { get; set; }

        public RemoverPlaylistCommandResponse(string id)
        {
            Id = id;
        }
    }
}
