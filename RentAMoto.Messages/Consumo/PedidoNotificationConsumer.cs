using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RentAMoto.Domain.Entities;
using RentAMoto.Messages.Intefarces;

namespace RentAMoto.Messages.Consumo
{
    public class PedidoNotificationConsumer : IPedidoNotificationConsumer
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public PedidoNotificationConsumer()
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

        public void IniciarConsumo()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var pedido = JsonSerializer.Deserialize<Pedido>(message);

                Console.WriteLine($"Pedido disponível recebido: {pedido.Id}");

                _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };
            _channel.BasicConsume(queue: "pedidos_disponiveis",
                                 autoAck: false,
                                 consumer: consumer);
        }
    }
}