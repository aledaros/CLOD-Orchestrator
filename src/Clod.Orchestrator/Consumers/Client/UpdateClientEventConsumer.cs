using Gruppo3.ClientiDTO.Domain.Events;
using Gruppo4.Microservizi.Commands.CommandsDTO.Customers;
using MassTransit;
using Microservices.Ecommerce.DTO.Commands;

namespace Clod.Orchestrator.Consumers.Client
{
    public class UpdateClientEventConsumer : IConsumer<UpdateClientEvent>
    {
        public async Task Consume(ConsumeContext<UpdateClientEvent> context)
        {
            var client = context.Message;

            //group 4
            await context.Publish(new UpdateClient
            {
                Id = client.Id,
                Address = client.Address,
                Businessname = client.Businessname,
                CF = client.CF,
                Email = client.Email,
                Name = client.Name,
                Piva = client.Piva,
                Surname = client.Surname,
                Year = client.Year
            });

            //group 2
            await context.Publish(new UpdateClientCommands
            {
                Id = client.Id,
                Businessname = client.Businessname,
                Name = client.Name
            });
        }
    }
}
