using MediatR;
using SpotifyLite.Application.Handler.Command;
using SpotifyLite.Application.Handler.Query;
using SpotifyLite.Application.Service;

namespace SpofityLite.Application.Banda.Handler
{
    public class BandaHandler : IRequestHandler<CriarBandaCommand, CriarBandaCommandResponse>,
                                IRequestHandler<ListarTodasBandasQuery, ListarTodasBandasQueryResponse>,
                                IRequestHandler<BuscarPorIDBandaQuery, BuscarPorIDBandaQueryResponse>,
                                IRequestHandler<AtualizarBandaCommand, AtualizarBandaCommandResponse>,
                                IRequestHandler<RemoverBandaCommand, RemoverBandaCommandResponse>
    {
        private readonly IBandaService _bandaService;

        public BandaHandler(IBandaService bandaService)
        {
            _bandaService = bandaService;
        }

        public async Task<CriarBandaCommandResponse> Handle(CriarBandaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.Criar(request.Banda);
            return new CriarBandaCommandResponse(result);
        }

        public async Task<ListarTodasBandasQueryResponse> Handle(ListarTodasBandasQuery request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.ListarTodos();
            return new ListarTodasBandasQueryResponse(result);
        }

        public async Task<BuscarPorIDBandaQueryResponse> Handle(BuscarPorIDBandaQuery request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.BuscarPorID(request.Id);
            return new BuscarPorIDBandaQueryResponse(result);
        }

        public async Task<AtualizarBandaCommandResponse> Handle(AtualizarBandaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.Atualizar(request.Banda);
            return new AtualizarBandaCommandResponse(result);
        }

        public async Task<RemoverBandaCommandResponse> Handle(RemoverBandaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.Remover(request.Id);
            return new RemoverBandaCommandResponse(result);
        }
    }
}
