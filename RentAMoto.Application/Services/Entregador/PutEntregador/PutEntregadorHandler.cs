using MediatR;
using RentAMoto.Application.Services.Entregador.PutEntregador.Handlers;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Application.Services.Entregador.PutEntregador
{
    public class PutEntregadorHandler : IRequestHandler<PutEntregadorRequest, PutEntregadorResponse>
    {
        private readonly IEntregadorRepository _entregadorRepository;
        private readonly IFotoCNHService _fotoCNHService;

        public PutEntregadorHandler(IEntregadorRepository entregadorRepository, IFotoCNHService fotoCNHService)
        {
            _entregadorRepository = entregadorRepository;
            _fotoCNHService = fotoCNHService;
        }
        public async Task<PutEntregadorResponse> Handle(PutEntregadorRequest request, CancellationToken cancellationToken)
        {
            var response = new PutEntregadorResponse();

            var h0 = new PutImagemCnhEntregador(_entregadorRepository, _fotoCNHService);

            await h0.Process(request, response);

            return response;
        }
    }
}