using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using Seed.Domain.Interfaces.Bus;
using Seed.Infrastructure.Bus.Interfaces;

namespace Seed.Infrastructure.Bus
{
    public class RabbitMqBusService : IBusService
    {
        private readonly IRabbitMqConnection _rabbitMqConnection;

        public RabbitMqBusService(IRabbitMqConnection rabbitMqConnection)
        {
            _rabbitMqConnection = rabbitMqConnection;
        }

        public void PublishBatch(string exchangeName, string key, List<string> messages)
        {
            using var connection = _rabbitMqConnection.CreateConnection();
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout, true);

            var batch = channel.CreateBasicPublishBatch();

            foreach (var message in messages)
            {
                var json = JsonSerializer.Serialize(message);
                var bytes = Encoding.UTF8.GetBytes(json);

                batch.Add(exchangeName, key, false, null, new ReadOnlyMemory<byte>(bytes));
            }

            batch.Publish();
        }
    }
}