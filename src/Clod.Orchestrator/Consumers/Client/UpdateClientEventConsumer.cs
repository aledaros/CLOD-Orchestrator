using Gruppo3.ClientiDTO.Domain.Events;
using MassTransit;

namespace Clod.Orchestrator.Consumers.Client
{
    public class UpdateClientEventConsumer : IConsumer<UpdateClientEvent>
    {
        public Task Consume(ConsumeContext<UpdateClientEvent> context)
        {
            var client = context.Message;
            throw new NotImplementedException();
        }
    }
}
