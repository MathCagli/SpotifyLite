using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Query
{
    public class BuscarPorIDUsuarioQuery : IRequest<BuscarPorIDUsuarioQueryResponse>
    {
        public string Id { get; set; }
    }

    public class BuscarPorIDUsuarioQueryResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public BuscarPorIDUsuarioQueryResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
