using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RentAMoto.Domain.Entities;
using RentAMoto.Messages.Intefarces;

namespace RentAMoto.Messages.Notificacao
{
    public class PedidoNotificationProducer : IPedidoNotificationProducer
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public PedidoNotificationProducer()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "pedidos_disponiveis",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
        }

        public void EnviarPedidoDisponivel(Pedido pedido)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(pedido));

            _channel.BasicPublish(exchange: "",
                                 routingKey: "pedidos_disponiveis",
                                 basicProperties: null,
                                 body: body);
        }
    }
}