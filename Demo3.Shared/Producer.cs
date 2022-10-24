using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo3.Shared
{
    public class Producer
    {
        private IModel channel;
        private string queuename;
        private int sleepms = 0;
        public Producer(string hostname, string queuename, int sleepms = 50)
        {
            this.sleepms = sleepms;
            this.queuename = queuename;
            var factory = new ConnectionFactory() { HostName = hostname };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: queuename,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            Console.WriteLine($"Producer started, attached to: {hostname}.{queuename}");
        }

        public void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "",
                                     routingKey: queuename,
                                     basicProperties: null,
                                     body: body);
            System.Threading.Thread.Sleep(sleepms);
        }
    }
}
