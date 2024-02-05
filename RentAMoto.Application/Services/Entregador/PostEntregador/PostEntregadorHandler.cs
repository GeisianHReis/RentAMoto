using MediatR;
using RentAMoto.Application.Services.Entregador.PostEntregador.Handler;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Application.Services.Entregador.PostEntregador
{
    public class PostEntregadorHandler : IRequestHandler<PostEntregadorRequest, PostEntregadorResponse>
    {
        private readonly IEntregadorRepository _entregadorRepository;

        public PostEntregadorHandler(IEntregadorRepository entregadorRepository)
        {
            _entregadorRepository = entregadorRepository;
        }
        public async Task<PostEntregadorResponse> Handle(PostEntregadorRequest request, CancellationToken cancellationToken)
        {
            var response = new PostEntregadorResponse();

            var h0 = new PostHandler(_entregadorRepository);

            await h0.Process(request, response);

            return response;

        }
    }

}