using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Command
{
    public class RemoverAlbumCommand : IRequest<RemoverAlbumCommandResponse>
    {
        public string Id { get; set; }
    }

    public class RemoverAlbumCommandResponse
    {
        public string Id { get; set; }

        public RemoverAlbumCommandResponse(string id)
        {
            Id = id;
        }
    }
}
