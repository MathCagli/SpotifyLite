using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Query
{
    public class BuscarPorIDMusicaQuery : IRequest<BuscarPorIDMusicaQueryResponse>
    {
        public string Id { get; set; }
    }

    public class BuscarPorIDMusicaQueryResponse
    {
        public MusicaOutputDto Musica { get; set; }

        public BuscarPorIDMusicaQueryResponse(MusicaOutputDto musica)
        {
            Musica = musica;
        }
    }
}
