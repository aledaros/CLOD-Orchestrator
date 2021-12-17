using Gruppo4.Microservizi.Commands.CommandsDTO.Products;
using MacNuget.Warehouse.Commands;
using MassTransit;
using Microservices.Ecommerce.DTO.Events;

namespace Clod.Orchestrator.Consumers.Products
{
    public class DeleteProductEventConsumer : IConsumer<DeleteProductEvent>
    {
        public async Task Consume(ConsumeContext<DeleteProductEvent> context)
        {
            // Gruppo 1
            await context.Publish(new DeleteProductCommand
            {
                Id = context.Message.Id
            });

            // Gruppo 4
            await context.Publish(new CreateProduct
            {
                Id = context.Message.Id,
            });
        }
    }
}
