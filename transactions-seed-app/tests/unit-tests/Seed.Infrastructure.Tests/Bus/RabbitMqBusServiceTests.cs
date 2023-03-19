using System.Collections.Generic;
using Moq;
using RabbitMQ.Client;
using Seed.Domain.Interfaces.Bus;
using Seed.Infrastructure.Bus;
using Seed.Infrastructure.Bus.Interfaces;
using Xunit;

namespace Seed.Infrastructure.Tests.Bus
{
    public class RabbitMqBusServiceTests
    {
        private readonly Mock<IRabbitMqConnection> _rabbitMqConnectionMock;
        
        private readonly IBusService _busService;

        public RabbitMqBusServiceTests()
        {
            _rabbitMqConnectionMock = new Mock<IRabbitMqConnection>();
            
            _busService = new RabbitMqBusService(_rabbitMqConnectionMock.Object);
        }


        [Fact]
        public void PublicBatch_ShouldDeclareExchangeAndPublishBatch_WithSuccess()
        {
            // Arrange
            var connectionMock = new Mock<IConnection>(); 
            var modelMock = new Mock<IModel>();
            var batchMock = new Mock<IBasicPublishBatch>();

            connectionMock
                .Setup(x => x.CreateModel())
                .Returns(modelMock.Object);

            modelMock
                .Setup(x => x.CreateBasicPublishBatch())
                .Returns(batchMock.Object);
            
            _rabbitMqConnectionMock
                .Setup(x => x.CreateConnection())
                .Returns(connectionMock.Object);

            // Act
            _busService.PublishBatch("exchange", "key", new List<string> { "message1", "message2"});

            // Assert
            modelMock.Verify(x => 
                x.ExchangeDeclare("exchange", ExchangeType.Fanout, true, false, null));

            batchMock.Verify(x => x.Publish());
        }
    }
}