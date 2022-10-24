using Demo3.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo3.Router
{
    public class Router
    {
        private string queuename;
        private string hostname;
        private Consumer consumer;
        private Producer oddProducer;
        private Producer evenProducer;
        /// <summary>
        /// This is a router for routing messages
        /// </summary>
        /// <param name="hostname">The host of the incoming queue</param>
        /// <param name="queuename">The name of the incoming queue</param>
        public Router(string hostname, string queuename)
        {
            this.hostname = hostname;
            this.queuename = queuename;            
            oddProducer = new Producer("localhost", "oddqueue");
            evenProducer = new Producer("localhost", "evenqueue");
            consumer = new Consumer("localhost", "demo3", DoConsume);//initialize the consumers last, otherwise the producers are null
        }

        private void DoConsume(string message)
        {
            Console.WriteLine($"Routing message: {message}");
            int intMessage = int.Parse(message);
            if(intMessage % 2 == 0)
            {
                //its an even message
                evenProducer.SendMessage($"Even Message: {message}");
            }
            else
            {
                //its an odd message
                oddProducer.SendMessage($"Odd Message: {message}");
            }
        }
    }
}
