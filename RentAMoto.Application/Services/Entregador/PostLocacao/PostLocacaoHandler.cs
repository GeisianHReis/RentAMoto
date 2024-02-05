using MediatR;
using RentAMoto.Application.Services.Entregador.PostLocacao.Handlers;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Application.Services.Entregador.PostLocacao
{
    public class PostLocacaoHandler : IRequestHandler<PostLocacaoRequest, PostLocacaoResponse>
    {
        private readonly IEntregadorRepository _entregadorRepository;
        private readonly IMotoRepository _motoRepository;
        private readonly ILocacaoRepository _locacaoRepository;

        public PostLocacaoHandler(IEntregadorRepository entregadorRepository, IMotoRepository motoRepository, ILocacaoRepository locacaoRepository)
        {
            _entregadorRepository = entregadorRepository;
            _motoRepository = motoRepository;
            _locacaoRepository = locacaoRepository;
        }

        public async Task<PostLocacaoResponse> Handle(PostLocacaoRequest request, CancellationToken cancellationToken)
        {
            var response = new PostLocacaoResponse();

            var h0 = new PostNovaLocacaoHandler(_motoRepository, _locacaoRepository, _entregadorRepository);

            await h0.Process(request, response);

            return response;
        }
    }
}