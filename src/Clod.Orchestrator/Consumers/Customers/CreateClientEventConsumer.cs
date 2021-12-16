using Gruppo3.ClientiDTO.Domain.Events;
using Gruppo3.ClientiDTO.Domain;
using MassTransit;
using Gruppo4.Microservizi.Commands.CommandsDTO.Customers;

namespace Gruppo4.Microservizi.AppCore.Consumers.Customers
{
    public class CreateClientEventConsumer : IConsumer<CreateClientEvent>
    {
        public async Task Consume(ConsumeContext<CreateClientEvent> context)
        {
            await context.Publish(new CreateClient
            {
                Id= context.Message.Id,
                Address= context.Message.Address,   
                Businessname= context.Message.Businessname,
                CF= context.Message.CF,
                Email= context.Message.Email,
                Name= context.Message.Name,
                Piva=context.Message.Piva,
                Surname= context.Message.Surname,
                Year= context.Message.Year
            });
        } 
    }
}
