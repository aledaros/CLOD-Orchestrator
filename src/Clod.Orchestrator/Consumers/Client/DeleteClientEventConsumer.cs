using Gruppo3.ClientiDTO.Domain.Events;
using MassTransit;

namespace Clod.Orchestrator.Consumers.Client
{
    public class DeleteClientEventConsumer : IConsumer<DeleteClientEvent>
    {
        public Task Consume(ConsumeContext<DeleteClientEvent> context)
        {
            var client = context.Message;
            throw new NotImplementedException();
        }
    }
}
