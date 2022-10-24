using Demo3.Router;
using Demo3.Shared;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
//code reference: https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
//code reference: https://www.rabbitmq.com/tutorials/tutorial-two-dotnet.html
Console.WriteLine("Demo 3 - Router");

Router router = new Router("localhost", "demo3"); //creating the router

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
