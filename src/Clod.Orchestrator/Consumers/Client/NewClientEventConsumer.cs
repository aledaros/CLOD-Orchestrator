using Gruppo3.ClientiDTO.Domain.Events;
using Gruppo4.Microservizi.Commands.CommandsDTO.Customers;
using MassTransit;
using Microservices.Ecommerce.DTO.Commands;

namespace Clod.Orchestrator.Consumers.Client
{
    public class NewClientEventConsumer : IConsumer<CreateClientEvent>
    {
        public async Task Consume(ConsumeContext<CreateClientEvent> context)
        {
            var client = context.Message;

            //group 2
            await context.Publish(new CreateClientCommands
            {

                Id = client.Id,
                Name = client.Name,
                Businessname = client.Businessname


            });

            //group 4
            await context.Publish(new CreateClient
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

        }
    }
}
