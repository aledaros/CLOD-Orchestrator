using Gruppo4.Microservizi.Commands.CommandsDTO.Warehouse;
using MacNuget.Warehouse.Events;
using MassTransit;

namespace Gruppo4.Microservizi.AppCore.Consumers.Warehouse
{
    public class NewRefillEventConsumer : IConsumer<NewRefillEvent>
    {
        public async Task Consume(ConsumeContext<NewRefillEvent> context)
        {
            await context.Publish(new RefillProduct
            {
                Id = context.Message.Product.Id,
                Quantity = context.Message.Product.Quantity
            });
        }
    }
}
