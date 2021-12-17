using Gruppo4.Microservizi.Commands.CommandsDTO.Products;
using MacNuget.Warehouse.Commands;
using MassTransit;
using Microservices.Ecommerce.DTO.Events;

namespace Clod.Orchestrator.Consumers.Products
{
    public class UpdateProductEventConsumer : IConsumer<UpdateProductEvent>
    {
        public async Task Consume(ConsumeContext<UpdateProductEvent> context)
        {
            // Gruppo 4
            await context.Publish(new UpdateProduct
            {
                Id = context.Message.Id,
                Prezzo = context.Message.Prezzo,
                Nome = context.Message.Nome,
                Marca = context.Message.Marca,
                Descrizione = context.Message.Descrizione
            });

            // Gruppo 1
            await context.Publish(new UpdateProductCommand
            {
                Id = context.Message.Id,
                Name = context.Message.Nome
            });
        }
    }
}
