using Gruppo3.ClientiDTO.Domain.Events;
using Gruppo4.Microservizi.Commands.CommandsDTO.Customers;
using MassTransit;
using Microservices.Ecommerce.DTO.Commands;

namespace Clod.Orchestrator.Consumers.Client
{
    public class DeleteClientEventConsumer : IConsumer<DeleteClientEvent>
    {
        public async Task Consume(ConsumeContext<DeleteClientEvent> context)
        {
            var client = context.Message;

            //group 4
            await context.Publish(new DeleteClient 
            { 
                Id = client.Id 
            });

            //group 2
            await context.Publish(new DeleteClientCommands
            {
                Id = client.Id
            });
        }
    }
}
