using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Command
{
    public class RemoverBandaCommand : IRequest<RemoverBandaCommandResponse>
    {
        public string Id { get; set; }
    }

    public class RemoverBandaCommandResponse
    {
        public string Id { get; set; }

        public RemoverBandaCommandResponse(string id)
        {
            Id = id;
        }
    }
}
