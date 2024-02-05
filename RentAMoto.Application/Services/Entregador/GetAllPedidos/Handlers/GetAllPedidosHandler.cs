using RentAMoto.Application.Commom;
using RentAMoto.Messages.Intefarces;

namespace RentAMoto.Application.Services.Entregador.GetAllPedidos.Handlers
{
    public class GetAllPedidosHandler : Handler<GetAllRequest, GetAllResponse, List<string>>
    {
        private readonly IPedidoNotificationConsumer _pedidoNotificationConsumer;

        public GetAllPedidosHandler(IPedidoNotificationConsumer pedidoNotificationConsumer)
        {
            _pedidoNotificationConsumer = pedidoNotificationConsumer;
        }
        public override async Task Process(GetAllRequest request, GetAllResponse response)
        {
            try
            {
                _pedidoNotificationConsumer.IniciarConsumo();              
                return;
            } catch (Exception ex)
            {
                response.HasError = true;
                response.Error = ex.Message;
            }
        }
    }
}