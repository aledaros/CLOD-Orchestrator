using Gruppo3.ClientiDTO.Domain.Events;
using MassTransit;
using Microservices.Ecommerce.DTO.Commands;


namespace Clod.Orchestrator.Consumers
{
    public class DeleteClientConsumer : IConsumer<DeleteClientEvent>
    {
        public async Task Consume(ConsumeContext<DeleteClientEvent> context)
        {
            await context.Publish(new DeleteClientCommands
            {
                Id = context.Message.Id


            });
        }
    }
}
