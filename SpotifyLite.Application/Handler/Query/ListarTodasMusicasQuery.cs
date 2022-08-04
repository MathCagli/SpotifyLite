using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Query
{
    public class ListarTodasMusicasQuery : IRequest<ListarTodasMusicasQueryResponse>
    {
    }

    public class ListarTodasMusicasQueryResponse
    {
        public IList<MusicaOutputDto> Musicas { get; set; }

        public ListarTodasMusicasQueryResponse(IList<MusicaOutputDto> musicas)
        {
            Musicas = musicas;
        }
    }
}
