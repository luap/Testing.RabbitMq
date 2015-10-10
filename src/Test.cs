using NUnit.Framework;
using RabbitMQ.Client;

namespace Testing.RabbitMq
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void RabbitMqInstanceIsRunning()
        {
            var connectionFactory = new ConnectionFactory { Port = 5675 };

            var instance = connectionFactory.CreateConnection();

            Assert.That(instance.IsOpen, Is.True.After(5000, 100));
        }
    }
}
