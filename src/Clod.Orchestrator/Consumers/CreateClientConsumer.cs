using Gruppo3.ClientiDTO.Domain.Events;
using MassTransit;
using Microservices.Ecommerce.DTO.Commands;


namespace Clod.Orchestrator.Consumers
{
    public class CreateClientConsumer : IConsumer<CreateClientEvent>
    {
        public async Task Consume(ConsumeContext<CreateClientEvent> context)
        {
            await context.Publish(new CreateClientCommands
            {

                Id = context.Message.Id,
                Name = context.Message.Name,
                Businessname = context.Message.Businessname
                

            });
        }
    }
}
