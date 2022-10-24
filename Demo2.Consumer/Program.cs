using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
//code reference: https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
//code reference: https://www.rabbitmq.com/tutorials/tutorial-two-dotnet.html
Console.WriteLine("Demo 2 - Slow consuming from RabbitMQ");
var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "demo2",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);
    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false); //additional config
    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        Console.WriteLine(" [x] Received {0}", message);
        System.Threading.Thread.Sleep(200); //simulating looong work
    };
    channel.BasicConsume(queue: "demo2",
                         autoAck: false,
                         consumer: consumer);        

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}
