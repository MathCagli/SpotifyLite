using MediatR;
using SpotifyLite.Application.Handler.Command;
using SpotifyLite.Application.Handler.Query;
using SpotifyLite.Application.Service;

namespace SpofityLite.Application.Playlist.Handler
{
    public class PlaylistHandler : IRequestHandler<CriarPlaylistCommand, CriarPlaylistCommandResponse>,
                                IRequestHandler<ListarTodasPlaylistsQuery, ListarTodasPlaylistsQueryResponse>,
                                IRequestHandler<BuscarPorIDPlaylistQuery, BuscarPorIDPlaylistQueryResponse>,
                                IRequestHandler<AtualizarPlaylistCommand, AtualizarPlaylistCommandResponse>,
                                IRequestHandler<RemoverPlaylistCommand, RemoverPlaylistCommandResponse>
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistHandler(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        public async Task<CriarPlaylistCommandResponse> Handle(CriarPlaylistCommand request, CancellationToken cancellationToken)
        {
            var result = await this._playlistService.Criar(request.Playlist);
            return new CriarPlaylistCommandResponse(result);
        }

        public async Task<ListarTodasPlaylistsQueryResponse> Handle(ListarTodasPlaylistsQuery request, CancellationToken cancellationToken)
        {
            var result = await this._playlistService.ListarTodos();
            return new ListarTodasPlaylistsQueryResponse(result);
        }

        public async Task<BuscarPorIDPlaylistQueryResponse> Handle(BuscarPorIDPlaylistQuery request, CancellationToken cancellationToken)
        {
            var result = await this._playlistService.BuscarPorID(request.Id);
            return new BuscarPorIDPlaylistQueryResponse(result);
        }

        public async Task<AtualizarPlaylistCommandResponse> Handle(AtualizarPlaylistCommand request, CancellationToken cancellationToken)
        {
            var result = await this._playlistService.Atualizar(request.Playlist);
            return new AtualizarPlaylistCommandResponse(result);
        }

        public async Task<RemoverPlaylistCommandResponse> Handle(RemoverPlaylistCommand request, CancellationToken cancellationToken)
        {
            var result = await this._playlistService.Remover(request.Id);
            return new RemoverPlaylistCommandResponse(result);
        }
    }
}
