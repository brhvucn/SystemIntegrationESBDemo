using RabbitMQ.Client;
using System.Text;
//code reference: https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
Console.WriteLine("Demo 2 - Producing numbers 0-1000");
var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "demo2",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);
    int i = 0;
    for (i = 0; i < 1000; i++)
    {
        string message = $"Message: {i}";
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: "",
                             routingKey: "demo2",
                             basicProperties: null,
                             body: body);
        System.Threading.Thread.Sleep(50); //change this to simulate faster/slower production
    }
    Console.WriteLine(" [x] Sent {0} messages", i);
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
