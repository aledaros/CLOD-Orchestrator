using Gruppo3.ClientiDTO.Domain.Events;
using Gruppo3.ClientiDTO.Domain.Commands;
using MassTransit;
using Gruppo4.Microservizi.Commands.CommandsDTO.Customers;

namespace Gruppo4.Microservizi.AppCore.Consumers.Customers
{
    public class DeleteClientEventConsumer : IConsumer<DeleteClientEvent>
    {

        public async Task Consume(ConsumeContext<DeleteClientEvent> context)
        {
            await context.Publish(new DeleteClient { Id=context.Message.Id} );
        }
    }
}
