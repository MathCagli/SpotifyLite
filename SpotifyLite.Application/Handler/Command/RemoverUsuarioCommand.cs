using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Command
{
    public class RemoverUsuarioCommand : IRequest<RemoverUsuarioCommandResponse>
    {
        public string Id { get; set; }
    }

    public class RemoverUsuarioCommandResponse
    {
        public string Id { get; set; }

        public RemoverUsuarioCommandResponse(string id)
        {
            Id = id;
        }
    }
}
