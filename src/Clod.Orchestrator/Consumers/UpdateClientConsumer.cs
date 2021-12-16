using Gruppo3.ClientiDTO.Domain.Events;
using MassTransit;
using Microservices.Ecommerce.DTO.Commands;


namespace Clod.Orchestrator.Consumers
{
    public class UpdateClientConsumer : IConsumer<UpdateClientEvent>
    {
        public async Task Consume(ConsumeContext<UpdateClientEvent> context)
        {
            await context.Publish(new UpdateClientCommands
            {
                
                Id = context.Message.Id,
                Name = context.Message.Name,
                Businessname = context.Message.Businessname
                 

            });
        }
    }
}
