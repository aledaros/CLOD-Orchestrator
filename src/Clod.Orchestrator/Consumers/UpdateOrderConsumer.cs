using Gruppo4MicroserviziDTO.DTOs;
using MassTransit;
using Microservices.Ecommerce.DTO.Commands;

namespace Clod.Orchestrator.Consumers
{
    public class UpdateOrderEvent : IConsumer<UpdatedOrderEvent>
    {

        public async Task Consume(ConsumeContext<UpdatedOrderEvent> context)
        {

            var productsForOrderCommand = new List<ProductInOrder>();

            foreach (var product in context.Message.Products)
            {
                productsForOrderCommand.Add(new ProductInOrder
                {
                    ProductId = product.ProductId,
                    OrderedQuantity = product.OrderedQuantity
                });
            }

            await context.Publish(new UpdateOrderCommand
            {
                Id = context.Message.Id,
                IdCliente = context.Message.IdCliente,
                DiscountAmount = context.Message.DiscountAmount,
                DiscountedPrice = context.Message.DiscountedPrice,
                TotalPrice = context.Message.TotalPrice,
                Products = productsForOrderCommand
            });
        }

     
    }
}
