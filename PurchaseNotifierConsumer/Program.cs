using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();


channel.QueueDeclare(queue: "Purchase",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);



Console.WriteLine("Esperando novas compras");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>

{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body); // Coda de UTF8 para String
    Console.WriteLine($" [x] Recebido: {message}");
    var aluno = JsonSerializer.Deserialize<Purchase>(message);


    Console.WriteLine($" [x] Recebido: {message}");

    try
    {
        // Deserializa a mensagem JSON para o objeto Purchase
        var purchase = JsonSerializer.Deserialize<Purchase>(message);
        if (purchase != null)
        {
            Console.WriteLine($"Produto: {purchase.ProductName}, Preço: {purchase.Price}");
        }
        else
        {
            Console.WriteLine("Falha ao deserializar a mensagem.");
        }
    }
    catch (JsonException ex)
    {
        Console.WriteLine($"Erro na deserialização: {ex.Message}");
    }
};


channel.BasicConsume(queue: "Purchase",
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine("Aperte [enter] para sair");
Console.ReadLine();


public class Purchase
{
    public string ProductName { get; set; }
    public double Price { get; set; }
}