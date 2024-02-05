using MediatR;
using RentAMoto.Application.Services.Admin.PostPedido.Handlers;
using RentAMoto.Messages.Intefarces;

namespace RentAMoto.Application.Services.Admin.PostPedido
{
    public class PostPedidoHandler : IRequestHandler<PostPedidoRequest, PostPedidoResponse>
    {
        private readonly IPedidoNotificationProducer _pedidoNotificationProducer;

        public PostPedidoHandler(IPedidoNotificationProducer pedidoNotificationProducer)
        {
            _pedidoNotificationProducer = pedidoNotificationProducer;
        }

        public async Task<PostPedidoResponse> Handle(PostPedidoRequest request, CancellationToken cancellationToken)
        {
            var response = new PostPedidoResponse();

            var h0 = new PostNovoPedidoHandler(_pedidoNotificationProducer);

            await h0.Process(request, response);

            return response;
        }
    }
}