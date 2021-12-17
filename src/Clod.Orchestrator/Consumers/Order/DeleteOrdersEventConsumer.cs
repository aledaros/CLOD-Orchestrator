using Gruppo3.ClientiDTO.Domain.Commands;
using Gruppo4MicroserviziDTO.DTOs;
using MassTransit;

namespace Clod.Orchestrator.Consumers.Order
{
    public class DeleteOrdersEventConsumer : IConsumer<DeletedOrderEvent>
    {
        public async Task Consume(ConsumeContext<DeletedOrderEvent> context)
        {
            var order = context.Message;

            //group 3
            await context.Publish(new ClientDeleteOrder
            {
                Id = order.Id
            });

            //group 1
            foreach (var p in order.Products)
            {
                await context.Publish(new MacNuget.Warehouse.Commands.DeleteOrderCommand
                {
                    ProductId = p.ProductId,
                    Quantity = p.OrderedQuantity
                });
            }

            //group 2
            await context.Publish(new Microservices.Ecommerce.DTO.Commands.DeleteOrderCommand
            {
                Id = context.Message.Id
            });
        }
    }
}
