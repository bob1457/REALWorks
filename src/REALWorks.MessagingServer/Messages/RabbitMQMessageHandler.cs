using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REALWorks.MessagingServer.Messages
{
    public class RabbitMQMessageHandler : IMessageHandler
    {
        private readonly string _host;
        private readonly string _username;
        private readonly string _password;
        private readonly string _exchange;
        private readonly string _connName;
        private readonly string _queuename;
        private readonly string _routingKey;
        private IConnection _connection;
        private IModel _model;
        private AsyncEventingBasicConsumer _consumer;
        private string _consumerTag;
        private IMessageHandlerCallback _callback;

        public RabbitMQMessageHandler(string host, string username, string password, string exchange, string connName, string queuename, string routingKey)
        {
            _host = host;
            _username = username;
            _password = password;
            _exchange = exchange;
            _connName = connName;
            _queuename = queuename;
            _routingKey = routingKey;
        }

        public void Start(IMessageHandlerCallback callback)
        {
            //throw new NotImplementedException();

            _callback = callback;

            var factory = new ConnectionFactory() { HostName = _host, UserName = _username, Password = _password, DispatchConsumersAsync = true };
            _connection = factory.CreateConnection(_connName);
            _model = _connection.CreateModel();
            _model.ExchangeDeclare(_exchange, "topic", durable: true, autoDelete: false);
            //_model.ExchangeDeclare(_exchange, "fanout", durable: true, autoDelete: false);
            _model.QueueDeclare(_queuename, durable: true, autoDelete: false, exclusive: false);
            _model.QueueBind(_queuename, _exchange, _routingKey);
            _consumer = new AsyncEventingBasicConsumer(_model);
            _consumer.Received += Consumer_ReceivedAsync;
            _consumerTag = _model.BasicConsume(_queuename, false, _consumer);
        }

        private async Task Consumer_ReceivedAsync(object sender, BasicDeliverEventArgs @event)
        {
            //throw new NotImplementedException();

            if (await HandleEvent(@event))
            {
                _model.BasicAck(@event.DeliveryTag, false);
            }
        }

        private Task<bool> HandleEvent(BasicDeliverEventArgs @event)
        {
            //throw new NotImplementedException();

            // determine messagetype
            string messageType = Encoding.UTF8.GetString((byte[])@event.BasicProperties.Headers["MessageType"]);

            // get body
            string body = Encoding.UTF8.GetString(@event.Body);

            // call callback to handle the message
            return _callback.HandleMessageAsync(messageType, body);

        }

        public void Stop()
        {
            //throw new NotImplementedException();

            _model.BasicCancel(_consumerTag);
            _model.Close(200, "Goodbye");
            _connection.Close();
        }
    }
}
