using Gruppo3.ClientiDTO.Domain.Events;
using MassTransit;

namespace Clod.Orchestrator.Consumers.Client
{
    public class NewClientEventConsumer : IConsumer<CreateClientEvent>
    {
        public Task Consume(ConsumeContext<CreateClientEvent> context)
        {
            var client = context.Message;
            throw new NotImplementedException();
        }
    }
}
