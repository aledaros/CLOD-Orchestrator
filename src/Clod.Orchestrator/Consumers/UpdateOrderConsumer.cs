namespace Clod.Orchestrator.Consumers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Gruppo4MicroserviziDTO.DTOs;
    using MacNuget.Warehouse.Commands;
    using MassTransit;

    public class UpdateOrderConsumer : IConsumer<UpdatedOrderEvent>
    {
        public async Task Consume(ConsumeContext<UpdatedOrderEvent> context)
        {
            foreach (var p in context.Message.Products)
            {
                await context.Publish(new UpdateOrderCommand
                {
                    ProductId = p.ProductId,
                    Quantity = p.OrderedQuantity
                });
            }
        }
    }
}
