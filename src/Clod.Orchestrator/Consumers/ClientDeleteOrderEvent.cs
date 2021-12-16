using Gruppo3.ClientiDTO.Domain.Commands;
using Gruppo4MicroserviziDTO.DTOs;
using MassTransit;

namespace Clod.Orchestrator.Consumers
{
    public class ClientDeleteOrderEvent : IConsumer<DeletedOrderEvent>
    {
        public Task Consume(ConsumeContext<DeletedOrderEvent> context)
        {
            //get order
            var order = context.Message;

            //convert event to command
            var client = new ClientDeleteOrder
            {
                Id = order.Id
            };

            //publish
            context.Publish(client);

            return Task.CompletedTask;
        }
    }
}
