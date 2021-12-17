using Gruppo4MicroserviziDTO.DTOs;
using MassTransit;

namespace Clod.Orchestrator.Consumers.Order
{
    public class NewOrderEventConsumer : IConsumer<NewOrderEvent>
    {
        public Task Consume(ConsumeContext<NewOrderEvent> context)
        {
            var order = context.Message;
            throw new NotImplementedException();
        }
    }
}
