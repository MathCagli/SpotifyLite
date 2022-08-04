using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Command
{
    public class RemoverMusicaCommand : IRequest<RemoverMusicaCommandResponse>
    {
        public string Id { get; set; }
    }

    public class RemoverMusicaCommandResponse
    {
        public string Id { get; set; }

        public RemoverMusicaCommandResponse(string id)
        {
            Id = id;
        }
    }
}
