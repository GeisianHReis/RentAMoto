using MediatR;
using RentAMoto.Application.Services.Entregador.GetAllPedidos.Handlers;
using RentAMoto.Messages.Intefarces;

namespace RentAMoto.Application.Services.Entregador.GetAllPedidos
{
    public class GetAllHandler : IRequestHandler<GetAllRequest, GetAllResponse>
    {
        private readonly IPedidoNotificationConsumer _pedidoNotificationConsumer;

        public GetAllHandler(IPedidoNotificationConsumer pedidoNotificationConsumer)
        {
            _pedidoNotificationConsumer = pedidoNotificationConsumer;
        }
        public async Task<GetAllResponse> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var response = new GetAllResponse();
            
            var h0 = new GetAllPedidosHandler(_pedidoNotificationConsumer);

            await h0.Process(request, response);

            return response;
        }
    }
}