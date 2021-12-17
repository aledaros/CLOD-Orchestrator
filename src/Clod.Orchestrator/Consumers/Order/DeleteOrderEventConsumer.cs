using Gruppo4MicroserviziDTO.DTOs;
using MassTransit;

namespace Clod.Orchestrator.Consumers.Order
{
    public class DeleteOrderEventConsumer : IConsumer<DeletedOrderEvent>
    {
        public Task Consume(ConsumeContext<DeletedOrderEvent> context)
        {
            var order = context.Message;
            throw new NotImplementedException();
        }
    }
}
