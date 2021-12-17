using Gruppo4.Microservizi.Commands.CommandsDTO.Products;
using MassTransit;
using Microservices.Ecommerce.DTO.Events;

namespace Gruppo4.Microservizi.AppCore.Consumers.Products
{
    public class NewProductEventConsumer : IConsumer<NewProductEvent>
    {
        public async Task Consume(ConsumeContext<NewProductEvent> context)
        {
            await context.Publish(new CreateProduct
            {
                Id = context.Message.Id,
                Aliquota = context.Message.Aliquota,
                Descrizione = context.Message.Descrizione, 
                Marca = context.Message.Marca,
                Nome = context.Message.Nome,
                Prezzo= context.Message.Prezzo
            });
        }
    }
}
