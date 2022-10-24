using Demo3.Shared;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
//code reference: https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
//code reference: https://www.rabbitmq.com/tutorials/tutorial-two-dotnet.html
Console.WriteLine("Demo 3 - Consume even numbers");
Consumer evenConsumer = new Consumer("localhost", "evenqueue", (message) =>
{
    Console.WriteLine(message);
});
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
