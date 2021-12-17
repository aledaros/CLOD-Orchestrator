namespace Clod.Orchestrator.Consumers
{
    using System.Threading.Tasks;
    using MacNuget.Warehouse.Commands;
    using MassTransit;
    using Microservices.Ecommerce.DTO.Events;

    public class DeleteProductConsumer : IConsumer<DeleteProductEvent>
    {
        public async Task Consume(ConsumeContext<DeleteProductEvent> context)
        {
            await context.Publish(new DeleteProductCommand
            {
                Id = context.Message.Id
            });
        }
    }
}
