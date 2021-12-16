using Gruppo3.ClientiDTO.Domain.Commands;
using Gruppo4MicroserviziDTO.DTOs;
using MassTransit;

namespace Clod.Orchestrator.Consumers
{
    public class ClientUpdateOrderEvent : IConsumer<UpdatedOrderEvent>
    {
        public Task Consume(ConsumeContext<UpdatedOrderEvent> context)
        {
            //get order
            var order = context.Message;

            //convert event to command
            var client = new ClientUpdateOrder
            {
                Id = order.Id,
                IdCliente = order.IdCliente,
                TotalPrice = order.TotalPrice
            };

            //publish
            context.Publish(client);

            return Task.CompletedTask;
        }
    }
}
