using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Query
{
    public class BuscarPorIDBandaQuery : IRequest<BuscarPorIDBandaQueryResponse>
    {
        public string Id { get; set; }
    }

    public class BuscarPorIDBandaQueryResponse
    {
        public BandaOutputDto Banda { get; set; }

        public BuscarPorIDBandaQueryResponse(BandaOutputDto banda)
        {
            Banda = banda;
        }
    }
}
