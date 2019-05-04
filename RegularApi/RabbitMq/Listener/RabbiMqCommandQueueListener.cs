using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RegularApi.Domain.Model;

namespace RegularApi.RabbitMq.Listener
{
    public class RabbiMqCommandQueueListener : RabbitMqMessageListener
    {
        private readonly ILogger _logger;
        private readonly IModel _channel;

        public RabbiMqCommandQueueListener(ILoggerFactory loggerFactory, IConnectionFactory connectionFactory, string queue) : base(loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<RabbiMqCommandQueueListener>();
            _channel = CreateConnection(connectionFactory); 
            ConsumerTag = AddQueueListener(_channel, queue);
        }

        public override void OnMessage(string message)
        {
            var deploymentOrder = JsonConvert.DeserializeObject<DeploymentOrder>(message);


            _logger.LogInformation("message received: {0}", message);
        }
    }
}