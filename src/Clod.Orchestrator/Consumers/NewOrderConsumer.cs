﻿namespace Clod.Orchestrator.Consumers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Gruppo4MicroserviziDTO.DTOs;
    using MacNuget.Warehouse.Commands;
    using MassTransit;

    public class NewOrderConsumer : IConsumer<NewOrderEvent>
    {
        public async Task Consume(ConsumeContext<NewOrderEvent> context)
        {
            foreach (var p in context.Message.Products)
            {
                await context.Publish(new CreateOrderCommand
                {
                    ProductId = p.ProductId,
                    Quantity = p.OrderedQuantity
                });
            }
            
        }
    }
}
