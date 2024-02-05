using RentAMoto.Application.Commom;
using RentAMoto.Domain.Entities;
using RentAMoto.Messages.Intefarces;

namespace RentAMoto.Application.Services.Admin.PostPedido.Handlers
{
    public class PostNovoPedidoHandler : Handler<PostPedidoRequest, PostPedidoResponse, string>
    {
        private readonly IPedidoNotificationProducer _pedidoNotificationProducer;

        public PostNovoPedidoHandler(IPedidoNotificationProducer pedidoNotificationProducer)
        {
            _pedidoNotificationProducer = pedidoNotificationProducer;
        }
        public override async Task Process(PostPedidoRequest request, PostPedidoResponse response)
        {
            try{
                if(request == null)
                {
                    response.HasError = true;
                    response.Error = "Pedido não informado";
                    return;
                }
                _pedidoNotificationProducer.EnviarPedidoDisponivel(new Pedido
                {
                    DataDeCriacao = request.DataDeCriacao,
                    ValorCorrida = request.ValorCorrida,
                    Situacao = request.Situacao
                });

            }
            catch(Exception ex)
            {
                response.HasError = true;
                response.Error = ex.Message;
            }
        }
    }
}