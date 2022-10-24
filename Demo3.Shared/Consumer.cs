using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo3.Shared
{
    public class Consumer
    {
        private string queuename = string.Empty;
        public Consumer(string hostname, string queuename, Action<string> action)
        {
            Console.WriteLine($"Consumer started, listening to: {hostname}.{queuename}");
            this.queuename = queuename;
            var factory = new ConnectionFactory() { HostName = hostname };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queuename,
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
                action(message); //invoke the callback
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false); //send the manual ack
            };
            channel.BasicConsume(queue: queuename,
                                 autoAck: false,
                                 consumer: consumer);

        }

        public string QueueName
        {
            get
            {
                return queuename;
            }
        }
    }
}
