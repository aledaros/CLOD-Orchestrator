using Gruppo4.Microservizi.Commands.CommandsDTO.Products;
using MassTransit;
using Microservices.Ecommerce.DTO.Events;

namespace Gruppo4.Microservizi.AppCore.Consumers.Products
{
    public class UpdateProductEventConsumer : IConsumer<UpdateProductEvent>
    {
        public async Task Consume(ConsumeContext<UpdateProductEvent> context)
        {
            await context.Publish(new UpdateProduct
            {
                Id = context.Message.Id,
                Prezzo = context.Message.Prezzo,
                Nome = context.Message.Nome,
                Marca = context.Message.Marca,
                Descrizione = context.Message.Descrizione
            });
        }
    }
}
