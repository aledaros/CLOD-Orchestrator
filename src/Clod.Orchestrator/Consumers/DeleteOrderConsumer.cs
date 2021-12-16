namespace Clod.Orchestrator.Consumers
{
    using System.Threading.Tasks;
    using Gruppo4MicroserviziDTO.DTOs;
    using MacNuget.Warehouse.Commands;
    using MassTransit;

    public class DeleteOrderConsumer : IConsumer<DeletedOrderEvent>
    {
        public async Task Consume(ConsumeContext<DeletedOrderEvent> context)
        {
            foreach (var p in context.Message.Products)
            {
                await context.Publish(new DeleteOrderCommand
                {
                    ProductId = p.ProductId,
                    Quantity = p.OrderedQuantity
                });
            }
        }
    }
}
