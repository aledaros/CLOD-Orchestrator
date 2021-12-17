using Gruppo4.Microservizi.Commands.CommandsDTO.Products;
using MacNuget.Warehouse.Commands;
using MassTransit;
using Microservices.Ecommerce.DTO.Events;

namespace Clod.Orchestrator.Consumers.Products
{
    public class NewProductEventConsumer : IConsumer<NewProductEvent>
    {
        public async Task Consume(ConsumeContext<NewProductEvent> context)
        {
            // Gruppo 4
            await context.Publish(new CreateProduct
            {
                Id = context.Message.Id,
                Aliquota = context.Message.Aliquota,
                Descrizione = context.Message.Descrizione,
                Marca = context.Message.Marca,
                Nome = context.Message.Nome,
                Prezzo = context.Message.Prezzo
            });

            // Gruppo 1
            await context.Publish(new CreateProductCommand
            {
                Id = context.Message.Id,
                Name = context.Message.Nome,
                Quantity = 0
            });
        }
    }
}
