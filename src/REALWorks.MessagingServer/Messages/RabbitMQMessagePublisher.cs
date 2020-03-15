using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REALWorks.MessagingServer.Messages
{
    public class RabbitMQMessagePublisher : IMessagePublisher
    {
        private readonly string _host;
        private readonly string _username;
        private readonly string _password;
        private readonly string _exchange;

        public RabbitMQMessagePublisher(string host, string username, string password, string exchange)
        {
            _host = host;
            _username = username;
            _password = password;
            _exchange = exchange;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="message"></param>
        /// <param name="routingKey"></param>
        /// <returns></returns>
        public Task PublishMessageAsync(string messageType, object message, string routingKey)
        {
            //throw new NotImplementedException();

            return Task.Run(() =>
            {
                var factory = new ConnectionFactory() { HostName = _host, UserName = _username, Password = _password }; // { HostName = "localhost", UserName ="guest", Password = "guest" }; // 
                using (var connection = factory.CreateConnection())
                {
                    using (var model = connection.CreateModel())
                    {
                        model.ExchangeDeclare(_exchange, "topic", durable: true, autoDelete: false);
                        string data = MessageSerializer.Serialize(message);
                        var body = Encoding.UTF8.GetBytes(data);
                        IBasicProperties properties = model.CreateBasicProperties();
                        properties.Headers = new Dictionary<string, object> { { "MessageType", messageType } };
                        model.BasicPublish(_exchange, routingKey, properties, body);
                    }
                }
            });

        }
    }
}
