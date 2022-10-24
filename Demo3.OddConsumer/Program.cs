using Demo3.Shared;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
//code reference: https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
//code reference: https://www.rabbitmq.com/tutorials/tutorial-two-dotnet.html
Console.WriteLine("Demo 3 - Consume odd numbers");
Consumer oddConsumer = new Consumer("localhost", "oddqueue", (message) =>
{
    Console.WriteLine(message);
});
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
