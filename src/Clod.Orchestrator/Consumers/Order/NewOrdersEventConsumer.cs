using Gruppo3.ClientiDTO.Domain.Commands;
using Gruppo4MicroserviziDTO.DTOs;
using MassTransit;

namespace Clod.Orchestrator.Consumers.Order
{
    public class NewOrdersEventConsumer : IConsumer<NewOrderEvent>
    {
        public async Task Consume(ConsumeContext<NewOrderEvent> context)
        {
            var order = context.Message;

            //group 3
            await context.Publish(new ClientNewOrder
            {
                Id = order.Id,
                IdCliente = order.IdCliente,
                TotalPrice = order.TotalPrice
            });

            //group 2
            var productsForOrderCommand = new List<Microservices.Ecommerce.DTO.Commands.ProductInOrder>();
            foreach (var product in order.Products)
            {
                productsForOrderCommand.Add(new Microservices.Ecommerce.DTO.Commands.ProductInOrder
                {
                    ProductId = product.ProductId,
                    OrderedQuantity = product.OrderedQuantity
                });
            }

            await context.Publish(new Microservices.Ecommerce.DTO.Commands.CreateOrderCommand
            {
                Id = order.Id,
                IdCliente = order.IdCliente,
                DiscountAmount = order.DiscountAmount,
                DiscountedPrice = order.DiscountedPrice,
                TotalPrice = order.TotalPrice,
                Products = productsForOrderCommand
            });

            //group 1
            foreach (var p in order.Products)
            {
                await context.Publish(new MacNuget.Warehouse.Commands.CreateOrderCommand
                {
                    ProductId = p.ProductId,
                    Quantity = p.OrderedQuantity
                });
            }
        }
    }
}
