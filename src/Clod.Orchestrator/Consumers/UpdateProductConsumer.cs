namespace Clod.Orchestrator.Consumers
{
    using System.Threading.Tasks;
    using MacNuget.Warehouse.Commands;
    using MassTransit;
    using Microservices.Ecommerce.DTO.Events;

    public class UpdateProductConsumer : IConsumer<UpdateProductEvent>
    {
        public async Task Consume(ConsumeContext<UpdateProductEvent> context)
        {
            await context.Publish(new UpdateProductCommand
            {
                Id = context.Message.Id,
                Name = context.Message.Nome
            });
        }
    }
}
