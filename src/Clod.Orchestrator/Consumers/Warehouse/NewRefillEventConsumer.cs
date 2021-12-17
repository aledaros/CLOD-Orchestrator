using MacNuget.Warehouse.Events;
using MassTransit;

namespace Clod.Orchestrator.Consumers.Warehouse
{
    public class NewRefillEventConsumer : IConsumer<NewRefillEvent>
    {
        public Task Consume(ConsumeContext<NewRefillEvent> context)
        {
            var refill = context.Message;
            throw new NotImplementedException();
        }
    }
}
