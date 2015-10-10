using NUnit.Framework;

namespace Testing.RabbitMq
{
    [SetUpFixture]
    public class ExampleSetupFixture
    {
        private RabbitMqInstance _rabbitMqInstance;

        [SetUp]
        public void Setup()
        {
            _rabbitMqInstance = new RabbitMqInstance();
            _rabbitMqInstance.Start();
        }

        [TearDown]
        public void TearDown()
        {
            _rabbitMqInstance.Stop();
        }
    }
}