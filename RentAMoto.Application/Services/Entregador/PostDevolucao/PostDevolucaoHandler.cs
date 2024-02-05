using MediatR;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Application.Services.Entregador.PostDevolucao.Handlers
{
    public class PostDevolucaoHandler : IRequestHandler<PostDevolucaoRequest, PostDevolucaoResponse>
    {
        private readonly IEntregadorRepository _entregadorRepository;
        private readonly ILocacaoRepository _locacaoRepository;

        public PostDevolucaoHandler(IEntregadorRepository entregadorRepository, ILocacaoRepository locacaoRepository)
        {
            _entregadorRepository = entregadorRepository;
            _locacaoRepository = locacaoRepository;
        }
        public async Task<PostDevolucaoResponse> Handle(PostDevolucaoRequest request, CancellationToken cancellationToken)
        {
            var response = new PostDevolucaoResponse();
            
            var h0 = new PostDevolucaoMotoHandler(_entregadorRepository, _locacaoRepository);

            await h0.Process(request, response);
            
            return response;
        }
    }
}