using Gruppo4MicroserviziDTO.DTOs;
using MassTransit;

namespace Clod.Orchestrator.Consumers.Order
{
    public class UpdateOrderEventConsumer : IConsumer<UpdatedOrderEvent>
    {
        public Task Consume(ConsumeContext<UpdatedOrderEvent> context)
        {
            var order = context.Message;
            throw new NotImplementedException();
        }
    }
}
