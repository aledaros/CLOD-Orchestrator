using Gruppo4.Microservizi.Commands.CommandsDTO.Warehouse;
using MacNuget.Warehouse.Events;
using MassTransit;

namespace Clod.Orchestrator.Consumers.Warehouse
{
    public class NewRefillEventConsumer : IConsumer<NewRefillEvent>
    {
        public async Task Consume(ConsumeContext<NewRefillEvent> context)
        {
            // Gruppo 4
            await context.Publish(new RefillProduct
            {
                Id = context.Message.Product.Id,
                Quantity = context.Message.Product.Quantity
            });
        }
    }
}
