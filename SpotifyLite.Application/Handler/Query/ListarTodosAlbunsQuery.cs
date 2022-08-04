using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Query
{
    public class ListarTodosAlbunsQuery : IRequest<ListarTodosAlbunsQueryResponse>
    {
    }

    public class ListarTodosAlbunsQueryResponse
    {
        public IList<AlbumOutputDto> Albuns { get; set; }

        public ListarTodosAlbunsQueryResponse(IList<AlbumOutputDto> albuns)
        {
            Albuns = albuns;
        }
    }
}
