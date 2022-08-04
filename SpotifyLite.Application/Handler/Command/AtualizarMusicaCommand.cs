using MediatR;
using SpotifyLite.Application.DTO;

namespace SpotifyLite.Application.Handler.Command
{
    public class AtualizarMusicaCommand : IRequest<AtualizarMusicaCommandResponse>
    {
        public MusicaOutputDto Musica { get; set; }
        public Guid IdBanda { get; set; }

        public AtualizarMusicaCommand(MusicaOutputDto musica)
        {
            Musica = musica;
        }
    }

    public class AtualizarMusicaCommandResponse
    {
        public MusicaOutputDto Musica { get; set; }

        public AtualizarMusicaCommandResponse(MusicaOutputDto musica)
        {
            Musica = musica;
        }
    }
}
