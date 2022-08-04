using MediatR;
using SpotifyLite.Application.Handler.Command;
using SpotifyLite.Application.Handler.Query;
using SpotifyLite.Application.Service;

namespace SpofityLite.Application.Musica.Handler
{
    public class MusicaHandler : IRequestHandler<CriarMusicaCommand, CriarMusicaCommandResponse>,
                                IRequestHandler<ListarTodasMusicasQuery, ListarTodasMusicasQueryResponse>,
                                IRequestHandler<BuscarPorIDMusicaQuery, BuscarPorIDMusicaQueryResponse>,
                                IRequestHandler<AtualizarMusicaCommand, AtualizarMusicaCommandResponse>,
                                IRequestHandler<RemoverMusicaCommand, RemoverMusicaCommandResponse>
    {
        private readonly IMusicaService _musicaService;

        public MusicaHandler(IMusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        public async Task<CriarMusicaCommandResponse> Handle(CriarMusicaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._musicaService.Criar(request.Musica);
            return new CriarMusicaCommandResponse(result);
        }

        public async Task<ListarTodasMusicasQueryResponse> Handle(ListarTodasMusicasQuery request, CancellationToken cancellationToken)
        {
            var result = await this._musicaService.ListarTodos();
            return new ListarTodasMusicasQueryResponse(result);
        }

        public async Task<BuscarPorIDMusicaQueryResponse> Handle(BuscarPorIDMusicaQuery request, CancellationToken cancellationToken)
        {
            var result = await this._musicaService.BuscarPorID(request.Id);
            return new BuscarPorIDMusicaQueryResponse(result);
        }

        public async Task<AtualizarMusicaCommandResponse> Handle(AtualizarMusicaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._musicaService.Atualizar(request.Musica);
            return new AtualizarMusicaCommandResponse(result);
        }

        public async Task<RemoverMusicaCommandResponse> Handle(RemoverMusicaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._musicaService.Remover(request.Id);
            return new RemoverMusicaCommandResponse(result);
        }
    }
}
