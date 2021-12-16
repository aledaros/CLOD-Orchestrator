namespace Clod.Orchestrator.Consumers
{
    using System.Threading.Tasks;
    using MacNuget.Warehouse.Commands;
    using MassTransit;
    using Microservices.Ecommerce.DTO.Events;

    public class NewProductConsumer : IConsumer<NewProductEvent>
    {
        public async Task Consume(ConsumeContext<NewProductEvent> context)
        {
            await context.Publish(new CreateProductCommand
            {
                Id = context.Message.Id,
                Name = context.Message.Nome,
                Quantity = 0
            });

        }
    }
}
