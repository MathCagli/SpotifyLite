using MediatR;
using SpotifyLite.Application.Handler.Command;
using SpotifyLite.Application.Handler.Query;
using SpotifyLite.Application.Service;

namespace SpofityLite.Application.Album.Handler
{
    public class AlbumHandler : IRequestHandler<CriarAlbumCommand, CriarAlbumCommandResponse>,
                                IRequestHandler<ListarTodosAlbunsQuery, ListarTodosAlbunsQueryResponse>,
                                IRequestHandler<BuscarPorIDAlbumQuery, BuscarPorIDAlbumQueryResponse>,
                                IRequestHandler<AtualizarAlbumCommand, AtualizarAlbumCommandResponse>,
                                IRequestHandler<RemoverAlbumCommand, RemoverAlbumCommandResponse>
    {
        private readonly IAlbumService _albumService;

        public AlbumHandler(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public async Task<CriarAlbumCommandResponse> Handle(CriarAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.Criar(request.Album);
            return new CriarAlbumCommandResponse(result);
        }

        public async Task<ListarTodosAlbunsQueryResponse> Handle(ListarTodosAlbunsQuery request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.ListarTodos();
            return new ListarTodosAlbunsQueryResponse(result);
        }

        public async Task<BuscarPorIDAlbumQueryResponse> Handle(BuscarPorIDAlbumQuery request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.BuscarPorID(request.Id);
            return new BuscarPorIDAlbumQueryResponse(result);
        }

        public async Task<AtualizarAlbumCommandResponse> Handle(AtualizarAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.Atualizar(request.Album);
            return new AtualizarAlbumCommandResponse(result);
        }

        public async Task<RemoverAlbumCommandResponse> Handle(RemoverAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.Remover(request.Id);
            return new RemoverAlbumCommandResponse(result);
        }
    }
}
