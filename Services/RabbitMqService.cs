using RabbitMQ.Client;

namespace PurchaseNotify.Services
{
    public class RabbitMqService
    {
        private readonly string _hostName;
        private readonly string _queueName;

        public RabbitMqService(string hostName, string queueName)
        {
            _hostName = hostName;
            _queueName = queueName;
        }

        public void SendMessage(byte[] message)
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "",
                                     routingKey: _queueName,
                                     basicProperties: properties,
                                     body: message);
            }
        }
    }

}
