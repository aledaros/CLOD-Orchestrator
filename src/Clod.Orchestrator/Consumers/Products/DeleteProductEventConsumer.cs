using Gruppo4.Microservizi.Commands.CommandsDTO.Products;
using MassTransit;
using Microservices.Ecommerce.DTO.Events;

namespace Gruppo4.Microservizi.AppCore.Consumers.Products
{
    public class DeleteProductEventConsumer : IConsumer<DeleteProductEvent>
    {
        public async Task Consume(ConsumeContext<DeleteProductEvent> context)
        {
            await context.Publish(new CreateProduct
            {
                Id = context.Message.Id,
            });
        }
    }
}
