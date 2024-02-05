using RentAMoto.Domain.Entities;

namespace RentAMoto.Messages.Intefarces
{
    public interface IPedidoNotificationProducer

    {
        void EnviarPedidoDisponivel(Pedido pedido);
    }
}